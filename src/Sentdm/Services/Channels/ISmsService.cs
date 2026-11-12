using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Channels.Sms;
using Sentdm.Services.Channels.Sms;

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
public interface ISmsService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISmsServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISmsService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITenDlcService TenDlc { get; }

    /// <summary>
    /// Gives the customer a sender in one country — the first market it sends in, and
    /// the fifth.
    ///
    /// <para>## What to have in place first</para>
    ///
    /// <para>**Call `GET /v3/compliance/requirements?country=US&amp;type=TEN_DLC`
    /// first.** It returns this request's body ready to fill in, plus the brand and
    /// campaign calls to make before it, in order. You never have to track forty
    /// countries' rules yourself.</para>
    ///
    /// <para>**A market that registers with a compliance regime needs an identity, and
    /// this call takes one.** US `TEN_DLC` registers with The Campaign Registry and
    /// files that registration against a business identity. Send it in
    /// `compliance.brand` and it is recorded here, before the registration that
    /// attaches to it — so a customer with no identity reaches a first 10DLC market in
    /// one call.</para>
    ///
    /// <para>`{ "inherit": true }` runs on your organization's instead. A market with
    /// neither — none stored, none sent — is `400`, because accepting it would write a
    /// channel that could never register and leave it provisioning for ever with
    /// nothing saying why.</para>
    ///
    /// <para>**Everything the regime wants arrives in this request's `compliance`**, as
    /// two declared objects: `brand` — the identity the registration is filed against —
    /// and `campaign`, with the use case, the consent narrative, the volume, the sample
    /// messages and the keywords. There is nothing to set up first. Nothing is
    /// submitted here either: the rows are what a submission is later assembled from,
    /// and filing is externally rejectable so it happens on its own path.</para>
    ///
    /// <para>**A half you run yourself has to be complete here.** Whichever of `brand`
    /// and `campaign` is your own rather than your organization's must carry every
    /// field the regime asks of it, counting what you already hold — send the rest in
    /// this request. A missing one is `400` naming each field, rather than a `202` for
    /// a market that could never be filed. A half you inherit is asked for nothing.</para>
    ///
    /// <para>A market that registers with nobody — an alphanumeric sender in most
    /// countries — needs neither, and may need documents instead.</para>
    ///
    /// <para>## Sending it</para>
    ///
    /// <para>Takes the same fields `channels.sms` takes on `POST /v3/sender-profiles`,
    /// because it is the same work, and both run one provisioning path. `compliance` is
    /// top-level and answers for the market in this request, carrying `brand` and
    /// `campaign` where the market registers.</para>
    ///
    /// <para>**Accepts multipart as well as JSON**, with each file named after the
    /// compliance key it satisfies — a market that pre-registers its sender needs its
    /// documents at the same moment it needs the sender. Every required document must
    /// be attached to this request; a missing or invalid file is rejected before the
    /// market is added.</para>
    ///
    /// <para>**`area_codes` puts the sender somewhere specific**, in your order of
    /// preference, for a `LOCAL` sender in any country or a US `TEN_DLC` sender — a
    /// 10DLC number is an ordinary local long code bound to a registered campaign, so
    /// both take the same codes out of the same inventory. It is honoured exactly: you
    /// get a number in one of the codes you named or you get none, never one in a code
    /// you left out.</para>
    ///
    /// <para>## Several numbers</para>
    ///
    /// <para>**`numbers` lists the numbers you want, one entry per area code**, e.g.
    /// `[{"area_code": "212", "quantity": 2}, {"quantity": 1}]` for two numbers in 212
    /// and one in any area code. `quantity` defaults to 1, and an entry without
    /// `area_code` means any area code. Omit `numbers` for one number. It is for
    /// `LOCAL` and `TEN_DLC` only and cannot be combined with `area_codes`. A market
    /// holds at most 49 numbers, counting the ones it already has.</para>
    ///
    /// <para>**On a `LOCAL` market you already hold, `numbers` adds those numbers to
    /// it** instead of `409`. US `TEN_DLC` numbers belong to the market's campaign and
    /// are assigned when the campaign is approved, not at request time. Until then they
    /// read as `PROVISIONING` in the response's `numbers`, each with the area code it
    /// was asked for. A profile inheriting your organization's campaign cannot request
    /// `numbers` (`400`). `numbers` on a `TEN_DLC` market you already hold is `409`:
    /// change its campaign's numbers with `PATCH /v3/channels/sms/{country}/{type}`,
    /// add numbers to one of its campaigns with `POST
    /// /v3/channels/sms/numbers/US/TEN_DLC`, or add a new campaign with `POST
    /// /v3/channels/sms/compliances/US/TEN_DLC/campaigns`.</para>
    ///
    /// <para>**A market you already send in is `409`**: adding what is already there is
    /// a mistake worth reporting rather than a silent no-op. A market is a `(country,
    /// sender_type)` pair, so a **second sender type in a country you already send in
    /// is fine** — `US TOLL_FREE` alongside `US TEN_DLC` is the ordinary case. Two of
    /// the same type is not.</para>
    ///
    /// <para>**A market you hold that has no sender yet is not a duplicate**, and
    /// re-sending it re-asks for a sender rather than being refused. That is the way
    /// out of an area-code request nothing could fill: send the call again to name
    /// different codes, or no codes at all to take a number anywhere in the country. It
    /// answers `201` with the sender when the pool has one, otherwise `202` with the
    /// codes recorded — and changes nothing else; compliance on a market you hold is
    /// `PATCH /v3/channels/sms/{country}/{type}`.</para>
    ///
    /// <para>One exception: while a market's sender type is still unassigned, adding
    /// any type to that country is `409` once it has a sender, because the market you
    /// have may be about to become the one you asked for.</para>
    ///
    /// <para>Returns **the market**, in the shape `GET` and `PATCH` on
    /// `/v3/channels/sms/{country}/{type}` use — so what this answers can be read back
    /// and written back without reshaping. Not every channel you have: adding a market
    /// cannot change an RCS agent or a WhatsApp account, and `GET /v3/channels` is the
    /// whole picture. `201` when the market is ready; `202` while a sender or a
    /// registration is still outstanding.</para>
    ///
    /// <para>Send `x-profile-id` with an organization key to add a market to one of
    /// your profiles.</para>
    /// </summary>
    Task<ApiResponseOfSmsMarket> Create(
        SmsCreateParams parameters,
        CancellationToken cancellationToken = default
    );

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
    Task<ApiResponseOfSmsMarket> Retrieve(
        SmsRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SmsRetrieveParams, CancellationToken)"/>
    Task<ApiResponseOfSmsMarket> Retrieve(
        string type,
        SmsRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Supplies whatever this market is waiting on, and answers with the market as
    /// stored — the same shape `GET` on this path returns, so **what comes back can be
    /// sent back**.
    ///
    /// <para>**A market reporting `ACTION_NEEDED` is fixed here**, whatever it is
    /// waiting on:</para>
    ///
    /// <para>| Outstanding | Send | | --- | --- | | a `brand` or `campaign` value (US
    /// `TEN_DLC`) | `compliance`, as below | | a document, in any market | a multipart
    /// file named after the document's key | | a registration sent back for correction
    /// | `compliance.brand` and/or `compliance.campaign` — the identity is accepted
    /// even once filed, and the registration goes back for review | | different numbers
    /// | `numbers`, the list the market asks for from now on |</para>
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
    /// <para>That leaves the campaign untouched, along with every other field of the
    /// identity.</para>
    ///
    /// <para>## What a US `TEN_DLC` market holds</para>
    ///
    /// <para>Two halves, both singular: `brand`, the identity the registration is filed
    /// against, and `campaign`, the programme filed against it. Each carries `inherit`.</para>
    ///
    /// <para>| Body | Effect | | --- | --- | | `"brand": { … }` | supplies or corrects
    /// the identity, and takes one of your own | | `"brand": { "inherit": true }` |
    /// runs on your organization's, giving up your own | | `"brand": null` | the same
    /// thing, said the short way | | `"campaign": { … }` | supplies or corrects the
    /// programme, and takes one of your own | | `"campaign": { "inherit": true }` |
    /// runs on your organization's | | key omitted | left exactly as it is |</para>
    ///
    /// <para>**Nothing here creates a second anything.** One identity and one campaign
    /// per market, so a write is an upsert and a replayed request lands on the row it
    /// already wrote. Sending the campaign twice does not file two registrations.</para>
    ///
    /// <para>## Every other market</para>
    ///
    /// <para>Markets that register with no regime have neither half, so `compliance` is
    /// `400` there. Their compliance is documents, sent here as multipart.</para>
    ///
    /// <para>## Documents</para>
    ///
    /// <para>Send `multipart/form-data` with **each file named after the compliance key
    /// it satisfies** — the key the market's `requirements` names. A file that matches
    /// no document the market asks for is `400` naming the keys that would, and a file
    /// the upload rules refuse (empty, too large, an unsupported type) is `422`.
    /// `compliance` and `numbers` may ride in the same form as text parts holding their
    /// JSON.</para>
    ///
    /// <para>## Numbers</para>
    ///
    /// <para>`numbers` takes the list `POST /v3/channels/sms` takes, for a `LOCAL` or
    /// `TEN_DLC` market, and **replaces** what the market asks for — send the list you
    /// want, not a difference. Numbers already assigned stay; a list that leaves one of
    /// them out is `400`, because nothing here releases a number.</para>
    ///
    /// <para>```json { "numbers": [ { "area_code": "415", "quantity": 2 }, {
    /// "quantity": 1 } ] } ```</para>
    ///
    /// <para>A `LOCAL` market is claimed from inventory at once, and whatever inventory
    /// cannot cover stays pending. A `TEN_DLC` market's numbers are recorded on its
    /// campaign and assigned once the carriers elect it — on the next acquisition cycle
    /// when it already has been. They need a campaign of the profile's own: one
    /// inherited from the organization is `400`.</para>
    ///
    /// <para>## What it will refuse</para>
    ///
    /// <para>**A filed identity is `409`.** Once the registration has gone to The
    /// Campaign Registry they hold a copy, and a local change would diverge from it
    /// silently. The campaign is not frozen — omit `brand` and the same body is
    /// accepted. The exception is a registration sent back for correction: the identity
    /// is accepted, and a correction to either half sends the registration back for
    /// review. Refiling it with The Campaign Registry stays with Sent.</para>
    ///
    /// <para>**More than one campaign is `409`.** The schema permits several and an
    /// account built on the admin side may hold them; this surface writes one, and
    /// editing whichever sorted first would leave the others unmentioned and unedited.</para>
    ///
    /// <para>Nothing is submitted to a regime here. These are the rows a submission is
    /// later assembled from, which is what lets them be corrected without waiting on
    /// something externally rejectable.</para>
    ///
    /// <para>Send `x-profile-id` with an organization key to write one of your
    /// profiles' markets.</para>
    /// </summary>
    Task<ApiResponseOfSmsMarket> Update(
        SmsUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SmsUpdateParams, CancellationToken)"/>
    Task<ApiResponseOfSmsMarket> Update(
        string type,
        SmsUpdateParams parameters,
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
    Task<ApiResponseOfListOfSmsMarket> List(
        SmsListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISmsService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISmsServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISmsServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITenDlcServiceWithRawResponse TenDlc { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/channels/sms</c>, but is otherwise the
    /// same as <see cref="ISmsService.Create(SmsCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfSmsMarket>> Create(
        SmsCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/channels/sms/{country}/{type}</c>, but is otherwise the
    /// same as <see cref="ISmsService.Retrieve(SmsRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfSmsMarket>> Retrieve(
        SmsRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SmsRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfSmsMarket>> Retrieve(
        string type,
        SmsRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/channels/sms/{country}/{type}</c>, but is otherwise the
    /// same as <see cref="ISmsService.Update(SmsUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfSmsMarket>> Update(
        SmsUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SmsUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfSmsMarket>> Update(
        string type,
        SmsUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/channels/sms</c>, but is otherwise the
    /// same as <see cref="ISmsService.List(SmsListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfListOfSmsMarket>> List(
        SmsListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
