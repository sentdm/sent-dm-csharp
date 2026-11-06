using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Channels.Rcs;

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
public interface IRcService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRcServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRcService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Asks for an RCS agent and records the order form the carriers vet it against.
    /// Always `202`: an agent is approved by the carriers, not by this call, and
    /// nothing here can make that happen sooner.
    ///
    /// <para>## What it asks for</para>
    ///
    /// <para>The RCS Agent Order Form — the same one our team fills in on your behalf
    /// today, so nothing has to be collected from you twice. **All fields are
    /// required** and must be submitted together so the carrier review has everything
    /// it needs. The only exception is `opt_in_screenshot_url`.</para>
    ///
    /// <para>**Agent identity:** `display_name`, `description`, `agent_use_case` (must
    /// be one of the accepted use cases; the error names the set), `brand_color`
    /// (six-digit hex, `#RRGGBB`).</para>
    ///
    /// <para>**Brand identity:** `brand_name` — the brand this agent presents. Not
    /// taken from `compliance.brand`: a business may present a different brand on RCS
    /// than the one its 10DLC registration is filed against, and the carriers vet this
    /// one. `privacy_policy_url`, `terms_and_conditions_url`, `website_url`,
    /// `logo_url`, and `banner_url` must be absolute `http(s)` URLs that the carriers
    /// can fetch without authentication. The form specifies 224×224 px and 50 KB for
    /// the logo and 1440×448 px and 200 KB for the banner; these cannot be checked
    /// without the image bytes.</para>
    ///
    /// <para>**Contact details:** `brand_phone_number`,
    /// `customer_support_phone_number`, `brand_email`, `customer_support_email`,
    /// `contact_name_and_title`.</para>
    ///
    /// <para>**Company:** `company_ein`, `entity_type`, `official_address` (street,
    /// city, state, postal_code, country), `brief_company_description`.</para>
    ///
    /// <para>**Consent and messages:** `opt_in_process_description`, `start_message`,
    /// `help_message`, `stop_message`, `sample_messages` (at least one example
    /// message).</para>
    ///
    /// <para>**Optional:** `opt_in_screenshot_url` (validated as an http(s) URL if
    /// supplied).</para>
    ///
    /// <para>Anything supplied is checked against accepted values rather than passed
    /// through: a value the provider rejects would otherwise surface days later, to
    /// somebody who cannot fix it without asking you.</para>
    ///
    /// <para>**A customer has one agent.** Asking again while you have one is `409`.</para>
    ///
    /// <para>## What comes back, and what does not</para>
    ///
    /// <para>Returns **the agent** — the form as stored, plus `id` and `status`. Not
    /// your other channels, which this call cannot have changed.</para>
    ///
    /// <para>`status` is `PROVISIONING` until the agent is handed to the carriers and
    /// approved. **`GET /v3/channels` reports `rcs: null` until then** — a channel row
    /// is what routing reads to decide you are sendable, and writing one for an
    /// unapproved agent would claim a channel that cannot carry traffic.</para>
    ///
    /// <para>Send `x-profile-id` with an organization key to ask for one of your
    /// profiles' agents.</para>
    /// </summary>
    Task<ApiResponseOfRcsAgent> Create(
        RcCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRcService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRcServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRcServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/channels/rcs</c>, but is otherwise the
    /// same as <see cref="IRcService.Create(RcCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfRcsAgent>> Create(
        RcCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
