using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Channels.Markets;
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
    /// consent narrative, volume, sample messages and keywords, under their keys
    /// (`description`, `message_flow`, `use_cases`, `volume`, …). It has to be
    /// complete. A rejected field is keyed by its name (`description`). `id` and
    /// `inherit` are ignored, so an entry of `campaigns` can be sent as read.</para>
    ///
    /// <para>The identity is the market's and is not sent here. A market whose identity
    /// has no registration yet, or one not yet submitted for review, is `400`.</para>
    ///
    /// <para>## What happens</para>
    ///
    /// <para>The campaign is recorded and goes for review; it is not filed with The
    /// Campaign Registry by this call. **It comes without numbers**: send its `id` from
    /// `compliance.campaigns` to `POST /v3/channels/sms/{country}/{type}/numbers` to
    /// give it some. **The campaign you already have, and its numbers, are not
    /// touched** — including a campaign you run on from your organization.</para>
    ///
    /// <para>**Each call files a new campaign**, which is charged when it is submitted.
    /// Send an `Idempotency-Key` so a retried request does not file a second one.</para>
    ///
    /// <para>To change a campaign, use `PATCH
    /// /v3/channels/sms/US/TEN_DLC/campaigns/{campaignId}`; `PATCH
    /// /v3/channels/sms/US/TEN_DLC` changes the brand and documents only, and refuses a
    /// campaign or numbers (`400`).</para>
    ///
    /// <para>Returns **the market**, in the shape `GET /v3/channels/sms/US/TEN_DLC`
    /// returns, with `202`.</para>
    /// </summary>
    Task<ApiResponseOfChannelMarket> AddCampaign(
        TenDlcAddCampaignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Every campaign your US `TEN_DLC` market registers, oldest first, each with its
    /// `id`, where it stands and `inherit` (`true` for your organization's) beside its
    /// fields — the list `GET /v3/channels/sms/US/TEN_DLC` reports under
    /// `compliance.campaigns`. Add one with `POST` on this path, and change one of your
    /// own with `PATCH /v3/channels/sms/US/TEN_DLC/campaigns/{id}`.
    ///
    /// <para>Each campaign has a `status` of its own, so a market on several says which
    /// is approved: `ACTIVE` once the carriers have elected it, `PENDING_REVIEW` until
    /// then, `ACTION_NEEDED` when it came back for correction, `DECLINED` when the
    /// carriers refused it, `INACTIVE` once it has ended. Why the market is held up is
    /// the market's own `reason`, which names the campaign concerned. `status` is
    /// read-only and ignored when the entry is sent back.</para>
    ///
    /// <para>A customer without a US `TEN_DLC` market is `404`.</para>
    /// </summary>
    Task<TenDlcListCampaignsResponse> ListCampaigns(
        TenDlcListCampaignsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Changes **one campaign of your own** on the US `TEN_DLC` market, named by its
    /// `id` in the market's `compliance.campaigns`.
    ///
    /// <para>## What to send</para>
    ///
    /// <para>The fields to change, at the top level of the body, under their keys
    /// (`description`, `message_flow`, `use_cases`, `help_message`, …). A field you
    /// leave out keeps its value, and a rejected one is keyed by its name. `id` and
    /// `"inherit": false` are ignored, so an entry of `campaigns` can be sent as read;
    /// `"inherit": true` is `400`, because this call changes a campaign's fields, not
    /// whose campaign you run on. The campaign only: add numbers with `POST
    /// /v3/channels/sms/US/TEN_DLC/numbers`, and change the brand or documents with
    /// `PATCH /v3/channels/sms/US/TEN_DLC`.</para>
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
    Task<ApiResponseOfChannelMarket> UpdateCampaign(
        TenDlcUpdateCampaignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateCampaign(TenDlcUpdateCampaignParams, CancellationToken)"/>
    Task<ApiResponseOfChannelMarket> UpdateCampaign(
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
    /// Returns a raw HTTP response for <c>post /v3/channels/sms/US/TEN_DLC/campaigns</c>, but is otherwise the
    /// same as <see cref="ITenDlcService.AddCampaign(TenDlcAddCampaignParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfChannelMarket>> AddCampaign(
        TenDlcAddCampaignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/channels/sms/US/TEN_DLC/campaigns</c>, but is otherwise the
    /// same as <see cref="ITenDlcService.ListCampaigns(TenDlcListCampaignsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TenDlcListCampaignsResponse>> ListCampaigns(
        TenDlcListCampaignsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/channels/sms/US/TEN_DLC/campaigns/{campaignId}</c>, but is otherwise the
    /// same as <see cref="ITenDlcService.UpdateCampaign(TenDlcUpdateCampaignParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfChannelMarket>> UpdateCampaign(
        TenDlcUpdateCampaignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateCampaign(TenDlcUpdateCampaignParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfChannelMarket>> UpdateCampaign(
        string campaignID,
        TenDlcUpdateCampaignParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
