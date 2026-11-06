using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Channels.Whatsapp;

namespace Sentdm.Services.Channels;

/// <summary>
/// The senders you send from, one per channel.
///
/// <para>**SMS is a list of markets**, each keyed by `(country, number_type)` —
/// a customer can hold `us/10dlc` and `gb/alphanumeric` at once, so a market is addressed
/// by the pair rather than by country alone. **WhatsApp and RCS are single**: a
/// customer has one business account and one agent. **Voice is per number**: each
/// number you hold can carry phone calls on its own (`POST /v3/channels/voice`),
/// each with the callback URL Sent asks what to do with its calls, one of them is
/// the default line for calls placed from your app, and voice tokens are minted
/// with `POST /v3/voice/tokens`. Read your voice numbers with `GET /v3/channels/voice`
/// and change one with `PATCH /v3/channels/voice/{number}`.</para>
///
/// <para>## Compliance lives on the market</para>
///
/// <para>Adding a market records everything that market registers with, in its `compliance`
/// object. Only **US `TEN_DLC`** registers with a regime — The Campaign Registry
/// — and it is the only market whose compliance carries `brand` and `campaign`. Everywhere
/// else compliance is documents, and many markets ask for none at all.</para>
///
/// <para>`GET` and `PATCH` on a market return and accept the same shape, so what
/// comes back can be sent back: an omitted key is left alone, and a key reported
/// in `requirements` is the path into the body that clears it.</para>
///
/// <para>Call `GET /v3/compliance/requirements` first — it answers what a market
/// demands before you hold it, with a body you can fill in and post.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWhatsappService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWhatsappServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWhatsappService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Connects a WhatsApp Business Account shared with us through a Multi-Partner
    /// Solution to the calling sender profile. Send `x-profile-id` for the profile the
    /// account belongs to.
    ///
    /// <para>**Two fields, because everything else is derived.** `waba_id` says which
    /// of your organization's shared accounts this is — you hold one per client, and
    /// nothing else can say which. `phone_number_id` names the account's number, which
    /// is what assigns it to the profile as the number it sends from.</para>
    ///
    /// <para>The solution the account arrived through, the client business portfolio
    /// that owns it, the access token and its expiry are all resolved from your
    /// organization. They are not accepted here: the first two are Meta's answer about
    /// provenance, and the token is minted per client business and rotates roughly
    /// every sixty days, so a value you sent would be stale before it was useful.</para>
    ///
    /// <para>`phone_number_id` is optional. Omit it to connect the account now and
    /// settle the number later — the channel reads as `ACTION_NEEDED` with
    /// `reason_code` `CHANNEL_007`, and the profile's WhatsApp messages fail until a
    /// number is named. They do not fall back to your organization's account. Call this
    /// endpoint again with `phone_number_id` to name one.</para>
    ///
    /// <para>The same resolution runs behind `channels.whatsapp` on `POST
    /// /v3/sender-profiles`, so connecting at create and connecting afterwards fill the
    /// same fields.</para>
    ///
    /// <para>Returns **the account**, not every channel you have — adding one cannot
    /// change a market or an RCS agent, and `GET /v3/channels` is the whole picture.
    /// Giving an account up is not self-service: ask support, because deregistering a
    /// number lands in your own Meta business.</para>
    /// </summary>
    Task<ApiResponseOfWhatsappChannel> Create(
        WhatsappCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWhatsappService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWhatsappServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWhatsappServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/channels/whatsapp</c>, but is otherwise the
    /// same as <see cref="IWhatsappService.Create(WhatsappCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfWhatsappChannel>> Create(
        WhatsappCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
