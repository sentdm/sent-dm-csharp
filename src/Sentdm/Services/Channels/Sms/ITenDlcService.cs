using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Channels.Sms;
using Sentdm.Models.Channels.Sms.TenDlc;

namespace Sentdm.Services.Channels.Sms;

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
public interface ITenDlcService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITenDlcServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITenDlcService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Registers **a new campaign** on the US `TEN_DLC` market you already hold — the
    /// one market that registers campaigns. Use it when you want numbers for a
    /// different use case than the market's existing campaign covers. The campaign is
    /// filed under the brand the market files under — your organization's when you
    /// inherit its identity.
    ///
    /// <para>## What to send</para>
    ///
    /// <para>The new campaign's fields, at the top level of the body: use cases,
    /// consent narrative, volume, sample messages and keywords, under the
    /// `compliance.campaign.*` keys `GET
    /// /v3/compliance/requirements?country=US&amp;type=TEN_DLC` lists, without that
    /// prefix. It has to be complete. A rejected field is keyed by its name
    /// (`description`). `id` and `inherit` are ignored, so an entry of
    /// `compliance.campaigns` can be sent as read.</para>
    ///
    /// <para>The identity is the market's and is not sent here. A market whose identity
    /// has no registration yet, or one not yet submitted for review, is `400`.</para>
    ///
    /// <para>## What happens</para>
    ///
    /// <para>The campaign is recorded and goes for review; it is not filed with The
    /// Campaign Registry by this call. **It comes without numbers**: send its `id` from
    /// `compliance.campaigns` to `POST /v3/channels/sms/numbers/US/TEN_DLC` to give it
    /// some. **The campaign you already have, and its numbers, are not touched** —
    /// including a campaign you run on from your organization.</para>
    ///
    /// <para>**Each call files a new campaign**, which is charged when it is submitted.
    /// Send an `Idempotency-Key` so a retried request does not file a second one.</para>
    ///
    /// <para>To change the campaign a market already has, use `PATCH
    /// /v3/channels/sms/US/TEN_DLC`. Once a market holds more than one campaign, that
    /// `PATCH` refuses a campaign or numbers change (`409`) rather than guess which
    /// campaign is meant; numbers are added to a named campaign with `POST
    /// /v3/channels/sms/numbers/US/TEN_DLC`.</para>
    ///
    /// <para>Returns **the market**, in the shape `GET /v3/channels/sms/US/TEN_DLC`
    /// returns, with `202`.</para>
    /// </summary>
    Task<ApiResponseOfSmsMarket> AddCampaign(
        TenDlcAddCampaignParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds numbers to **one campaign of your own** on the US `TEN_DLC` market you
    /// hold, named by `campaign_id` — the `id` of an entry in the market's
    /// `compliance.campaigns`.
    ///
    /// <para>## What to send</para>
    ///
    /// <para>- `campaign_id` — the campaign. One you inherit from your organization is
    /// `400`: its numbers are the organization's. One out of service — expired,
    /// deactivated or released — is `409`. - `numbers` — the list `POST
    /// /v3/channels/sms` takes, one entry per area code.</para>
    ///
    /// <para>## What happens</para>
    ///
    /// <para>The entries are **added** to what the campaign already asks for. With
    /// everything it asks for, a campaign holds at most 49 numbers, counting one for
    /// each sender profile inheriting it. A campaign the carriers have not approved yet
    /// gets its numbers when they do; an approved one gets them now. Until a number is
    /// assigned it reads as `PROVISIONING` in the market's `numbers`, with the area
    /// code it was asked for.</para>
    ///
    /// <para>Returns **the market**, in the shape `GET /v3/channels/sms/US/TEN_DLC`
    /// returns, with `202`.</para>
    /// </summary>
    Task<ApiResponseOfSmsMarket> AddNumbers(
        TenDlcAddNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Reads what the US `TEN_DLC` market you hold has registered: the `brand` it files
    /// under, **every campaign** under `campaigns` (each with its `id` and `inherit`),
    /// and its `documents`. It is the `compliance` object `GET
    /// /v3/channels/sms/US/TEN_DLC` returns, without the sender and numbers.
    ///
    /// <para>Use a campaign's `id` to change it with `PATCH
    /// /v3/channels/sms/compliances/US/TEN_DLC/campaigns/{campaignId}`, or to add
    /// numbers to it with `POST /v3/channels/sms/numbers/US/TEN_DLC`.</para>
    ///
    /// <para>Send `x-profile-id` with an organization key to read one of your profiles'
    /// markets.</para>
    /// </summary>
    Task<ApiResponseOfSuppliedCompliance> RetrieveCompliance(
        TenDlcRetrieveComplianceParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Changes **one campaign of your own** on the US `TEN_DLC` market, named by its
    /// `id` in the market's `compliance.campaigns`.
    ///
    /// <para>## What to send</para>
    ///
    /// <para>The fields to change, at the top level of the body, under the
    /// `compliance.campaign.*` keys `GET
    /// /v3/compliance/requirements?country=US&amp;type=TEN_DLC` lists, without that
    /// prefix. A field you leave out keeps its value, and a rejected one is keyed by
    /// its name. `id` and `"inherit": false` are ignored, so an entry of
    /// `compliance.campaigns` can be sent as read; `"inherit": true` is `400`, because
    /// this call changes a campaign's fields, not whose campaign you run on. The
    /// campaign only: add numbers with `POST /v3/channels/sms/numbers/US/TEN_DLC`, and
    /// change the brand or documents with `PATCH /v3/channels/sms/US/TEN_DLC`.</para>
    ///
    /// <para>## When it can be changed</para>
    ///
    /// <para>Until it is filed with The Campaign Registry, and again when we ask you to
    /// correct it. That correction sends it back for review. A filed campaign is
    /// otherwise `409`, and so is a change between low and high volume once it is
    /// registered. A campaign you run on from your organization is `409` too: it is the
    /// organization's to change. So is one out of service: expired, deactivated or
    /// released.</para>
    ///
    /// <para>Returns **the market**, in the shape `GET /v3/channels/sms/US/TEN_DLC`
    /// returns.</para>
    /// </summary>
    Task<ApiResponseOfSmsMarket> UpdateCampaign(
        TenDlcUpdateCampaignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateCampaign(TenDlcUpdateCampaignParams, CancellationToken)"/>
    Task<ApiResponseOfSmsMarket> UpdateCampaign(
        string campaignID,
        TenDlcUpdateCampaignParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITenDlcService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITenDlcServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITenDlcServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/channels/sms/compliances/US/TEN_DLC/campaigns</c>, but is otherwise the
    /// same as <see cref="ITenDlcService.AddCampaign(TenDlcAddCampaignParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfSmsMarket>> AddCampaign(
        TenDlcAddCampaignParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/channels/sms/numbers/US/TEN_DLC</c>, but is otherwise the
    /// same as <see cref="ITenDlcService.AddNumbers(TenDlcAddNumbersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfSmsMarket>> AddNumbers(
        TenDlcAddNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/channels/sms/compliances/US/TEN_DLC</c>, but is otherwise the
    /// same as <see cref="ITenDlcService.RetrieveCompliance(TenDlcRetrieveComplianceParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfSuppliedCompliance>> RetrieveCompliance(
        TenDlcRetrieveComplianceParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/channels/sms/compliances/US/TEN_DLC/campaigns/{campaignId}</c>, but is otherwise the
    /// same as <see cref="ITenDlcService.UpdateCampaign(TenDlcUpdateCampaignParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfSmsMarket>> UpdateCampaign(
        TenDlcUpdateCampaignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateCampaign(TenDlcUpdateCampaignParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfSmsMarket>> UpdateCampaign(
        string campaignID,
        TenDlcUpdateCampaignParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
