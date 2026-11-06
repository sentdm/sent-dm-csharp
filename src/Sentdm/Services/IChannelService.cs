using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Channels;
using Channels = Sentdm.Services.Channels;

namespace Sentdm.Services;

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
public interface IChannelService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IChannelServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChannelService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Channels::ISmsService Sms { get; }

    Channels::IRcService Rcs { get; }

    Channels::IWhatsappService Whatsapp { get; }

    Channels::IVoiceService Voice { get; }

    /// <summary>
    /// Every market you send SMS in, your WhatsApp account, your RCS agent and the
    /// numbers you carry phone calls on — with each one's status, and what each market
    /// has supplied.
    ///
    /// <para>**Status lives on the channel, never on you or your brand.** An identity
    /// has no lifecycle; what has one is the registration of a sender in a market and
    /// the approval of a channel. So a customer live in one country and
    /// mid-registration in another reports exactly that, rather than one flattened
    /// answer.</para>
    ///
    /// <para>`sms[n].compliance` carries what each market holds: `brand` and `campaign`
    /// for markets that register with a compliance regime such as US TEN_DLC, and
    /// `documents` for markets that pre-register an alphanumeric or similar sender.
    /// Absent means the market registers with nobody and nothing has been supplied.
    /// `GET /v3/compliance/requirements` says what a market demands of any new
    /// customer; this says what you gave it.</para>
    ///
    /// <para>Send `x-profile-id` with an organization key to read one of your profiles'
    /// channels.</para>
    /// </summary>
    Task<ApiResponseOfChannelsState> List(
        ChannelListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IChannelService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IChannelServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChannelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Channels::ISmsServiceWithRawResponse Sms { get; }

    Channels::IRcServiceWithRawResponse Rcs { get; }

    Channels::IWhatsappServiceWithRawResponse Whatsapp { get; }

    Channels::IVoiceServiceWithRawResponse Voice { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/channels</c>, but is otherwise the
    /// same as <see cref="IChannelService.List(ChannelListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfChannelsState>> List(
        ChannelListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
