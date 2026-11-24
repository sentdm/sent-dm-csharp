using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Channels.Markets;

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
public interface IMarketService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMarketServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMarketService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Reads one market you send in — its sender, where that sender stands, and
    /// everything its compliance holds.
    ///
    /// <para>## What `compliance` carries</para>
    ///
    /// <para>A market that registers with a compliance regime reports `brand` — the
    /// identity the registration is filed against — and `campaign`, the programme filed
    /// against it. Each carries `inherit`, saying whether it is yours or your
    /// organization's.</para>
    ///
    /// <para>`compliance.brand.vetting` is the brand's external vetting at The Campaign
    /// Registry, read-only: `score` (0-100, the figure US carriers set 10DLC throughput
    /// by), `status` (`PENDING`, `UNSCORE`, `ACTIVE`, `FAILED` or `EXPIRED`; carriers
    /// read the score of an `ACTIVE` vet only), `vetted_at` and `expires_at`. It is
    /// `null` while no vetting record is held for the brand, and `score` is `null` for
    /// a vet that has none yet. A profile on your organization's brand reads your
    /// organization's vetting.</para>
    ///
    /// <para>A market that registers with nobody has neither, so **both keys are
    /// absent** rather than null: absent says this market does not ask, where null
    /// would say it asks and you supplied nothing. It reports `documents` instead.</para>
    ///
    /// <para>`GET /v3/compliance/requirements` says what a market demands of any new
    /// customer; this says what you gave it.</para>
    ///
    /// <para>## Writing it back</para>
    ///
    /// <para>**`PATCH` this same path**, with the `compliance` object from this
    /// response:</para>
    ///
    /// <para>```json { "compliance": { "brand": { "tax_id": "12-3456789" } } } ```</para>
    ///
    /// <para>Nothing else to learn — what comes back can be sent back, an omitted key
    /// is left alone. There is no sub-resource for either half: both are singletons of
    /// the market, so both are written here.</para>
    ///
    /// <para>`GET /v3/compliance/requirements` says what a market demands of anybody;
    /// this says what you gave it.</para>
    ///
    /// <para>Send `x-profile-id` with an organization key to read one of your profiles'
    /// markets.</para>
    /// </summary>
    Task<ApiResponseOfChannelMarket> Retrieve(
        MarketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MarketRetrieveParams, CancellationToken)"/>
    Task<ApiResponseOfChannelMarket> Retrieve(
        string type,
        MarketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Supplies the market's identity and documents, and answers with the market as
    /// stored — the same shape `GET` on this path returns.
    ///
    /// <para>| To change | Send | | --- | --- | | a `brand` value (US `TEN_DLC`) |
    /// `compliance.brand`, as below | | a registration sent back for correction |
    /// `compliance.brand` — the identity is accepted even once filed, and the
    /// registration goes back for review | | a document, in any market | a multipart
    /// file named after the document's key | | a campaign | `PATCH
    /// /v3/channels/sms/US/TEN_DLC/campaigns/{id}` — `compliance.campaign` here is
    /// `400` | | the numbers | `POST /v3/channels/{channel}/{country}/{type}/numbers` —
    /// `numbers` here is `400` |</para>
    ///
    /// <para>## Partial, at every level</para>
    ///
    /// <para>**An omitted key is left alone. An explicit `null` clears it.** Those are
    /// different requests, so `{}` changes nothing and is refused rather than silently
    /// accepted, and correcting one field does not blank the others.</para>
    ///
    /// <para>```json { "compliance": { "brand": { "contact_phone": "+12125550123" } } }
    /// ```</para>
    ///
    /// <para>| Body | Effect | | --- | --- | | `"brand": { … }` | supplies or corrects
    /// the identity, and takes one of your own | | `"brand": { "inherit": true }` |
    /// runs on your organization's, giving up your own | | `"brand": null` | the same
    /// thing, said the short way | | key omitted | left exactly as it is |</para>
    ///
    /// <para>The brand read on this path, its `id` and `vetting` included, can be sent
    /// back unchanged: both are read-only and ignored.</para>
    ///
    /// <para>## Every other market</para>
    ///
    /// <para>Markets that register with no regime have no brand, so `compliance` is
    /// `400` there. Their compliance is documents, sent here as multipart.</para>
    ///
    /// <para>## Documents</para>
    ///
    /// <para>Send `multipart/form-data` with **each file named after the compliance key
    /// it satisfies** — the key `GET /v3/channels/{channel}/{country}/compliance`
    /// lists. A file that matches no document the market asks for is `400` naming the
    /// keys that would, and a file the upload rules refuse (empty, too large, an
    /// unsupported type) is `422`. `compliance` may ride in the same form as a text
    /// part holding its JSON.</para>
    ///
    /// <para>## What it will refuse</para>
    ///
    /// <para>**A filed identity is `409`.** Once the registration has gone to The
    /// Campaign Registry they hold a copy, and a local change would diverge from it
    /// silently. The exception is a registration sent back for correction: the identity
    /// is accepted, and the registration goes back for review. Refiling it with The
    /// Campaign Registry stays with Sent.</para>
    ///
    /// <para>Nothing is submitted to a regime here. Send `x-profile-id` with an
    /// organization key to write one of your profiles' markets.</para>
    /// </summary>
    Task<ApiResponseOfChannelMarket> Update(
        MarketUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(MarketUpdateParams, CancellationToken)"/>
    Task<ApiResponseOfChannelMarket> Update(
        string type,
        MarketUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Every market you send SMS in, each with its sender, where that sender stands,
    /// and what its compliance holds.
    ///
    /// <para>The same entries `GET /v3/channels` reports under `sms`, and the same
    /// shape `GET /v3/channels/sms/{country}/{type}` returns for one of them — so a
    /// list, a member read and the all-channels read cannot describe a market
    /// differently.</para>
    ///
    /// <para>Send `x-profile-id` with an organization key to list one of your profiles'
    /// markets.</para>
    /// </summary>
    Task<ApiResponseOfListOfChannelMarket> List(
        MarketListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MarketListParams, CancellationToken)"/>
    Task<ApiResponseOfListOfChannelMarket> List(
        string channel,
        MarketListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds numbers to a market you hold. They are **added** to what it already asks
    /// for, never replacing it — with one exception: a US `TEN_DLC` campaign opened
    /// without `numbers` asks for one number in any area code by default, and while it
    /// holds no number yet, the first numbers added replace that default. Once it holds
    /// one, they are added beside it.
    ///
    /// <para>## Where they go</para>
    ///
    /// <para>- **SMS US `TEN_DLC`**: to **one campaign of your own**, named by
    /// `campaign_id` — the `id` of an entry in the market's `compliance.campaigns`
    /// (`GET /v3/channels/sms/US/TEN_DLC`). Required: left out it is `400` naming your
    /// campaigns in service. One you inherit from your organization is `400`: its
    /// numbers are the organization's. One out of service — expired, deactivated or
    /// released — is `409`. A campaign the carriers have not approved yet gets its
    /// numbers when they do; an approved one gets them now. With everything it asks
    /// for, a campaign holds at most 49 numbers, counting one for each sender profile
    /// inheriting it. - **`LOCAL`**: to the market, claimed from inventory now; what
    /// inventory cannot cover stays pending. No `campaign_id`. A market holds at most
    /// 49 numbers. - **Any other sender type** takes no numbers: `400`.</para>
    ///
    /// <para>## What to send</para>
    ///
    /// <para>`numbers` — the list `POST /v3/channels/sms` takes, one entry per area
    /// code — and, on US `TEN_DLC`, `campaign_id`, required.</para>
    ///
    /// <para>Until a number is assigned it reads as `PROVISIONING` in the market's
    /// `numbers`, with the area code it was asked for. Returns **the market**, in the
    /// shape `GET /v3/channels/sms/{country}/{type}` returns, with `202`.</para>
    /// </summary>
    Task<ApiResponseOfChannelMarket> AddNumbers(
        MarketAddNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="AddNumbers(MarketAddNumbersParams, CancellationToken)"/>
    Task<ApiResponseOfChannelMarket> AddNumbers(
        string type,
        MarketAddNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Every number you hold in one market (country and sender type): `ACTIVE` once it
    /// can send, `PROVISIONING` while it is still to be assigned (it then has no
    /// `sender_value` yet), `INACTIVE` once it could send and no longer can. US
    /// `TEN_DLC` numbers name their `campaign_id`, and `?campaign_id=` keeps one
    /// campaign's.
    ///
    /// <para>A market you do not hold is `404`. Add numbers with `POST` on the same
    /// path.</para>
    /// </summary>
    Task<ApiResponseOfMarketNumbers> ListNumbers(
        MarketListNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListNumbers(MarketListNumbersParams, CancellationToken)"/>
    Task<ApiResponseOfMarketNumbers> ListNumbers(
        string type,
        MarketListNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replaces the numbers a market you hold asks for — their area codes and counts —
    /// with the list you send. To add to them instead, use `POST` on this path.
    ///
    /// <para>## Whose numbers</para>
    ///
    /// <para>- **SMS US `TEN_DLC`**: **one campaign of your own**, named by
    /// `campaign_id` — the `id` of an entry in the market's `compliance.campaigns`.
    /// Required. So a campaign sent back for correction can change its area codes
    /// without being recreated. One you inherit from your organization is `400`; one
    /// out of service is `409`. With everything it asks for, a campaign holds at most
    /// 49 numbers, counting one for each sender profile inheriting it. - **`LOCAL`**:
    /// the market's own, claimed from inventory now; what inventory cannot cover stays
    /// pending. No `campaign_id`. - **Any other sender type** takes no numbers: `400`.</para>
    ///
    /// <para>## What to send</para>
    ///
    /// <para>`numbers` — the list `POST /v3/channels/sms` takes, one entry per area
    /// code, an entry without `area_code` meaning any — and, on US `TEN_DLC`,
    /// `campaign_id`.</para>
    ///
    /// <para>**Numbers already assigned are kept.** Nothing is released here, so a list
    /// that no longer covers a number already held is `400`, naming how many it leaves
    /// out. Lowering a count nothing has filled yet is fine.</para>
    ///
    /// <para>Until a number is assigned it reads as `PROVISIONING` in the market's
    /// `numbers`, with the area code it was asked for. Returns **the market**, in the
    /// shape `GET /v3/channels/sms/{country}/{type}` returns.</para>
    /// </summary>
    Task<ApiResponseOfChannelMarket> ReplaceNumbers(
        MarketReplaceNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ReplaceNumbers(MarketReplaceNumbersParams, CancellationToken)"/>
    Task<ApiResponseOfChannelMarket> ReplaceNumbers(
        string type,
        MarketReplaceNumbersParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMarketService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMarketServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMarketServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/channels/{channel}/{country}/{type}</c>, but is otherwise the
    /// same as <see cref="IMarketService.Retrieve(MarketRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfChannelMarket>> Retrieve(
        MarketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MarketRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfChannelMarket>> Retrieve(
        string type,
        MarketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/channels/{channel}/{country}/{type}</c>, but is otherwise the
    /// same as <see cref="IMarketService.Update(MarketUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfChannelMarket>> Update(
        MarketUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(MarketUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfChannelMarket>> Update(
        string type,
        MarketUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/channels/{channel}</c>, but is otherwise the
    /// same as <see cref="IMarketService.List(MarketListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfListOfChannelMarket>> List(
        MarketListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MarketListParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfListOfChannelMarket>> List(
        string channel,
        MarketListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/channels/{channel}/{country}/{type}/numbers</c>, but is otherwise the
    /// same as <see cref="IMarketService.AddNumbers(MarketAddNumbersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfChannelMarket>> AddNumbers(
        MarketAddNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="AddNumbers(MarketAddNumbersParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfChannelMarket>> AddNumbers(
        string type,
        MarketAddNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/channels/{channel}/{country}/{type}/numbers</c>, but is otherwise the
    /// same as <see cref="IMarketService.ListNumbers(MarketListNumbersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfMarketNumbers>> ListNumbers(
        MarketListNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListNumbers(MarketListNumbersParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfMarketNumbers>> ListNumbers(
        string type,
        MarketListNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/channels/{channel}/{country}/{type}/numbers</c>, but is otherwise the
    /// same as <see cref="IMarketService.ReplaceNumbers(MarketReplaceNumbersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfChannelMarket>> ReplaceNumbers(
        MarketReplaceNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ReplaceNumbers(MarketReplaceNumbersParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfChannelMarket>> ReplaceNumbers(
        string type,
        MarketReplaceNumbersParams parameters,
        CancellationToken cancellationToken = default
    );
}
