using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.SenderProfiles;

namespace Sentdm.Services;

/// <summary>
/// Your customers, each sending as itself.
///
/// <para>A sender profile is a tenant of yours: it has its own API key, its own
/// balance, and can have its own identity and senders — so your customers send under
/// their own brand and never see Sent. Depth is one; a profile cannot create profiles.</para>
///
/// <para>**Everything is inherited unless the profile owns it.** `{ "name": "…" }`
/// alone gives you a usable profile immediately, running on your identity, your
/// inbox and your billing. Supply a capability's fields and the profile owns that
/// one instead.</para>
///
/// <para>**A sender is the exception.** A brand and a campaign can be inherited;
/// a number cannot. A profile either has a sender of its own or terminates through
/// your shared routes.</para>
///
/// <para>To act for a profile on any other resource, send `x-profile-id` with your
/// organization key rather than looking for a parallel set of endpoints.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISenderProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISenderProfileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISenderProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a sender profile under your organization. A profile is a customer of
    /// yours: it sends under its own or your identity, and your customers never see
    /// Sent.
    ///
    /// <para>## The minimum</para>
    ///
    /// <para>`{ "name": "Example Retail", "short_name": "Example" }`. `short_name` is
    /// the SMS sender id and is required. Inbox and opt-out list come from your
    /// organization. Its brand and campaign are your organization's only where
    /// `compliance` says `{ "inherit": true }` — omitted, the profile has neither.
    /// Billing defaults to the profile's own balance, with your organization covering
    /// what it cannot.</para>
    ///
    /// <para>**A sender is not one of them.** The brand and the campaign can be
    /// inherited; a number cannot. A profile either has a sender of its own —
    /// `channels.sms` — or it has none and terminates through the shared routes for
    /// that country.</para>
    ///
    /// <para>## Saying what a profile owns</para>
    ///
    /// <para>Every capability is one of three things, and there is no flag per state:</para>
    ///
    /// <para>- **Its own** — supply the capability's fields. Data is what owning looks
    /// like. - **The organization's** — `{ "inherit": true }`, with nothing else. -
    /// **None** — omit the block.</para>
    ///
    /// <para>There is no `"inherit": false` that also carries no data. A second way to
    /// say the same thing would let a request contradict itself.</para>
    ///
    /// <para>Inheriting needs no id. A customer has exactly one brand, so `brand`
    /// resolves without one.</para>
    ///
    /// <para>**The campaign has no block of its own.** It is only ever a registration,
    /// and every field of one is something a specific market demands — so it lives in
    /// `compliance`, alongside the rest of what that market asks for, and it says whose
    /// it is there too: `"compliance": { "campaign": { "inherit": true } }` runs the
    /// profile on your organization's campaign and brand, and stops this call asking
    /// for any campaign field. `"brand": { "inherit": true }` alone inherits the brand
    /// only: the campaign is then the profile's own. Inheriting takes *all* of your
    /// organization's, because inheritance resolves an owner rather than a single row.</para>
    ///
    /// <para>A profile with a `brand` of its own **cannot** inherit the campaign, and
    /// asking is refused with `400`: a campaign is filed against a brand registration,
    /// and your organization's campaign is filed against your organization's brand
    /// rather than this profile's. Inherit both, own both, or inherit the brand and own
    /// the campaign.</para>
    ///
    /// <para>`channels.sms` is the market the profile starts in — one `country` and
    /// `number_type`. It decides what else this call asks for: the compliance catalog
    /// is keyed on that pair, and it determines which fields `brand` accepts and what
    /// `compliance` answers for.</para>
    ///
    /// <para>**Several numbers in that market**: `channels.sms.numbers` lists them, one
    /// entry per area code, e.g. `[{"area_code": "212", "quantity": 2}, {"quantity":
    /// 1}]` for two in 212 and one in any area code. `quantity` defaults to 1, an entry
    /// without `area_code` means any area code, and the total is at most 49. The market
    /// is created with **one campaign**, the one in `compliance.campaign`, and a US
    /// `TEN_DLC` market's numbers are stored on it and assigned when it is approved. A
    /// profile inheriting your organization's campaign keeps one number. Every number
    /// is listed in `channels.sms[].numbers` with its area code and status.</para>
    ///
    /// <para>A profile is a tenant, not a market, so it can go on to send in several —
    /// but through `POST /v3/channels/sms` with the `x-profile-id` header, one market
    /// and its compliance at a time. Reads return every market as `channels.sms[]`, so
    /// the read shape is a list even where this one is not.</para>
    ///
    /// <para>`brand` is required when `number_type` is `TEN_DLC` — inherited or its
    /// own. A 10DLC registration has nothing to attach to without one, and no later
    /// call can supply it, so omitting it is refused with `400` rather than reported as
    /// outstanding.</para>
    ///
    /// <para>## Use cases and volume</para>
    ///
    /// <para>A TCR campaign declares one to five `use_cases`, each with its own
    /// `sample_messages` — TCR attributes samples to the use case they illustrate, so
    /// they travel together.</para>
    ///
    /// <para>How that set registers is derived from `volume` and never declared. Below
    /// the low-volume threshold the campaign registers as `LOW_VOLUME` with every entry
    /// as a sub-use-case; above it, one entry registers as that use case outright and
    /// several register as `MIXED` with sub-use-cases. `MIXED` and `LOW_VOLUME` are
    /// therefore refused as `use_case` values: they describe the shape of a set, which
    /// is ours to work out.</para>
    ///
    /// <para>**Leaving `volume` out is accepted and costs more.** An absent value
    /// registers the campaign at the standard tier, which carries the higher fee — so
    /// say so when a campaign is low volume. Sole proprietor brands are the exception:
    /// their fee is fixed by entity type, and volume only decides the use case.</para>
    ///
    /// <para>## Compliance</para>
    ///
    /// <para>`brand` is captured identically in every country. Everything a specific
    /// market demands on top of it — including every field of the campaign — goes in
    /// `compliance`, as key/value entries whose keys depend on the sender's country and
    /// type. US `TEN_DLC` registers with The Campaign Registry and asks for a
    /// substantial set; an alphanumeric sender may pre-register with documents, or need
    /// nothing at all.</para>
    ///
    /// <para>You do not have to know any of it. Omit `compliance` and the response
    /// lists exactly what is outstanding, with types and accepted values — or call `GET
    /// /v3/compliance/requirements` first. Anything Sent supplies on your behalf is
    /// never asked for, and is rejected if sent.</para>
    ///
    /// <para>Requirements can be conditional, and the condition is published as
    /// `required_when` so you can render a form from it rather than discover the rule
    /// by being rejected. Every US `TEN_DLC` campaign field carries `compliance.inherit
    /// != true` — send `"inherit": true` and none of them is asked for or accepted,
    /// because the profile is running on your organization's campaign.</para>
    ///
    /// <para>## Uploading documents</para>
    ///
    /// <para>Send `application/json` for everything except a market that pre-registers
    /// a sender with supporting documents. For those, send `multipart/form-data`
    /// instead: put this entire document — unchanged — in a single field named
    /// `profile`, and attach each file under a field named after the compliance key it
    /// satisfies. Individual form fields per property are not read; the payload is
    /// always the one `profile` field.</para>
    ///
    /// <para>A pre-registration market has no `brand` and no `campaign` — those are
    /// asked for only where a regime registers one — so its `compliance` carries
    /// nothing at all, and the documents are the request:</para>
    ///
    /// <para>```bash curl -X POST https://api.sent.dm/v3/sender-profiles \   -H
    /// 'x-api-key: YOUR_SECRET_TOKEN' \   -F 'profile={         "name": "Example
    /// Retail",         "short_name": "EXAMPLE",         "channels": {           "sms":
    /// {             "country": "XK",             "number_type": "ALPHANUMERIC",
    ///
    ///   "sender_value": "EXAMPLE"           }         }       }' \   -F
    /// 'business_registration=@registration.pdf' \   -F
    /// 'letter_of_authorization=@loa.pdf' ```</para>
    ///
    /// <para>`business_registration` and `letter_of_authorization` are illustrative.
    /// The real field names are whatever that market configures, so read them from `GET
    /// /v3/compliance/requirements`, which lists documents separately from the values —
    /// under `attachments`, each with the `field_name` to put the file under.</para>
    ///
    /// <para>A document has no JSON form, so naming one in `compliance` is refused with
    /// `400` rather than ignored: accepting it would report the requirement as
    /// satisfied while no file was ever stored.</para>
    ///
    /// <para>## WhatsApp and RCS</para>
    ///
    /// <para>Neither can be inherited, so neither takes an `inherit`: the profile's
    /// WhatsApp account and RCS agent are its own or it has none. Sharing your
    /// organization's would share its inbox and its throughput, which makes the two
    /// indistinguishable to a recipient.</para>
    ///
    /// <para>`channels.whatsapp` names one of the accounts shared into your
    /// organization, and takes the two identifiers nothing else can supply: `waba_id`,
    /// because your organization holds one account per client, and `phone_number_id`,
    /// because naming the account's number is what assigns it to the profile as the
    /// number it sends from.</para>
    ///
    /// <para>Everything else is resolved from your organization — the Multi-Partner
    /// Solution the account arrived through, the client business portfolio that owns
    /// it, the access token and that token's expiry. None of them is accepted here: the
    /// first two are Meta's answer about provenance, so a value you sent could assert a
    /// partnership Meta disagrees with, and the token is minted per client business and
    /// rotates roughly every sixty days.</para>
    ///
    /// <para>`phone_number_id` is optional. Omit it to connect the account now and
    /// settle the number later — the channel reads as `ACTION_NEEDED` with
    /// `reason_code` `CHANNEL_007`, and the profile's WhatsApp messages fail until a
    /// number is named. They do not fall back to your organization's account. `POST
    /// /v3/channels/whatsapp` connects an account to an existing profile and resolves
    /// the same fields the same way.</para>
    ///
    /// <para>An account of its own needs a sender of its own, so `channels.whatsapp`
    /// requires `channels.sms`. A profile sending SMS on your organization's sender
    /// shares that inbox and opt-out list, and is not a separate tenant to give an
    /// account to — asking is refused with `400`, before your organization is asked to
    /// resolve anything.</para>
    ///
    /// <para>`channels.rcs` records the RCS agent. RCS (Rich Communication Services) is
    /// the next-generation SMS standard built into Android — it lets you send branded
    /// messages with images, buttons and read receipts over the carrier network, with
    /// no app install required. Learn more in the [Google RCS
    /// documentation](https://developers.google.com/business-communications/rcs-business-messaging).</para>
    ///
    /// <para>All fields on the agent form are required except `opt_in_screenshot_url`.
    /// The full form must be submitted in one go so the carrier review has everything
    /// it needs. A carrier approval no API call can trigger is arranged offline, so the
    /// status reports `PROVISIONING` until it is.</para>
    ///
    /// <para>## Responses</para>
    ///
    /// <para>`201` when the profile is complete on return — the fully-inherited case,
    /// where nothing needs registering. `202` when something is still provisioning,
    /// with per-capability status and outstanding requirements. `409` when the WhatsApp
    /// account supplied is already recorded. `400` covers a wrong value as well as a
    /// missing one: a missing brand under `TEN_DLC`, a brand or campaign inherited
    /// under `TEN_DLC` that your organization does not have yet, an unknown compliance
    /// key, a bad type, a sender id the market does not allow, a `waba_id` that is not
    /// one of the accounts shared into your organization, or a WhatsApp account Meta
    /// rejects. `502` when Meta could not be reached to verify the WhatsApp account;
    /// nothing was created, so retry.</para>
    /// </summary>
    Task<ApiResponseOfSenderProfile> Create(
        SenderProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Reads one of your sender profiles.
    ///
    /// <para>The document mirrors `POST /v3/sender-profiles`, with three differences
    /// that follow from this being a read rather than a request.</para>
    ///
    /// <para>`channels.sms` is a **list**. Create takes the one market a profile starts
    /// in; a profile can go on to send in several, and this reports all of them, each
    /// with its own `status`.</para>
    ///
    /// <para>`compliance.brand` comes back **in full, with `inherit` saying whose it
    /// is**. On a request `{ "inherit": true }` carries no data because there is
    /// nothing to send; here it carries the data, because the point of a read is to say
    /// what the profile actually sends under.</para>
    ///
    /// <para>**There is no `campaigns` array.** Brand, campaign, and compliance
    /// documents are reported at the profile root in `compliance`. A profile running on
    /// your organization's campaign is asked for none of the campaign fields, so
    /// `compliance.campaign` carries `{ "inherit": true }` with no campaign data.</para>
    ///
    /// <para>`api_key` is **never** returned here. It is shown once, by create.</para>
    ///
    /// <para>A profile belonging to another organization reads as `404`, not `403`:
    /// saying which of the two it is would confirm the id exists.</para>
    /// </summary>
    Task<ApiResponseOfSenderProfile> Retrieve(
        SenderProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SenderProfileRetrieveParams, CancellationToken)"/>
    Task<ApiResponseOfSenderProfile> Retrieve(
        string id,
        SenderProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Changes a profile's own attributes: `name`, `short_name`, `description` and
    /// `notifications` (who is emailed about the profile's events — `ORGANIZATION`,
    /// `SENDER_PROFILE`, or `ORGANIZATION_AND_SENDER_PROFILE`).
    ///
    /// <para>**Only those.** A profile's identity, its markets and its compliance each
    /// have a sub-resource of their own, because each has its own validation and its
    /// own external consequences — a brand change may need re-registering, a market
    /// change provisions a sender. Folding them in here would give those fields two
    /// writers and no way to say which one wins.</para>
    ///
    /// <para>Omitting a field leaves it alone; sending `null` clears it. Those are
    /// different requests, so `{}` changes nothing and is refused rather than silently
    /// accepted — a caller who misspelt every field would otherwise get a `200` and an
    /// unchanged profile.</para>
    ///
    /// <para>`name` and `short_name` cannot be cleared: `short_name` is the SMS sender
    /// id, so a supplied value must be 3–11 characters of letters, numbers and spaces
    /// with at least one letter.</para>
    ///
    /// <para>Returns the profile as `GET /v3/sender-profiles/{id}` would, so the result
    /// of the change needs no second call to see.</para>
    /// </summary>
    Task<ApiResponseOfSenderProfile> Update(
        SenderProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SenderProfileUpdateParams, CancellationToken)"/>
    Task<ApiResponseOfSenderProfile> Update(
        string id,
        SenderProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists the sender profiles under your organization, newest first, paginated with
    /// `page` and `page_size`.
    ///
    /// <para>Each entry is the same document `GET /v3/sender-profiles/{id}` returns,
    /// with one difference: **`compliance.documents` at the profile root is absent**.
    /// Working out which documents a market holds means a catalog lookup and a document
    /// read per market, and doing that for every profile on a page would turn one
    /// request into dozens to answer a question you did not ask. Read a single profile
    /// for that. Brand and campaign are still included when they exist.</para>
    ///
    /// <para>`compliance.documents` being **absent** is not the same as it being an
    /// **empty list**. Absent means the documents were not fetched here; an empty list
    /// means the profile holds none.</para>
    ///
    /// <para>`api_key` is never returned. It is shown once, by create.</para>
    /// </summary>
    Task<SenderProfileListPage> List(
        SenderProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes one of your sender profiles and returns `204`.
    ///
    /// <para>The delete is **soft**: the profile stops being usable and stops appearing
    /// in reads, and its message history is kept, because deleting a profile must not
    /// delete the record of what it sent.</para>
    ///
    /// <para>## What it releases</para>
    ///
    /// <para>Anything the profile still held goes with it. A **phone number** returns
    /// to our inventory and can be given to whoever asks next — it does not stay
    /// reserved for you, and getting the same number back afterwards is not something
    /// we can promise. A **WhatsApp account of its own** is deregistered from Meta. Its
    /// routing rules stop being used, so nothing sends through the profile after this
    /// call.</para>
    ///
    /// <para>A profile that only inherits from its organization holds nothing of its
    /// own and releases nothing.</para>
    ///
    /// <para>## When it is refused</para>
    ///
    /// <para>A number the profile holds that your **WhatsApp Business Account still
    /// carries** refuses the delete with a `409 CONFLICT_012`, and nothing is deleted:
    /// it would return to our shared inventory while Meta still routes WhatsApp to it,
    /// and the next customer given it could not register it at all. Only you can take
    /// it off the account — deregister **and** delete it in WhatsApp Manager, then try
    /// again. A `409 CONFLICT_013` means we could not read the account, so we cannot
    /// tell either way.</para>
    /// </summary>
    Task Delete(
        SenderProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SenderProfileDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        SenderProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISenderProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISenderProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISenderProfileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/sender-profiles</c>, but is otherwise the
    /// same as <see cref="ISenderProfileService.Create(SenderProfileCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfSenderProfile>> Create(
        SenderProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/sender-profiles/{id}</c>, but is otherwise the
    /// same as <see cref="ISenderProfileService.Retrieve(SenderProfileRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfSenderProfile>> Retrieve(
        SenderProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SenderProfileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfSenderProfile>> Retrieve(
        string id,
        SenderProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/sender-profiles/{id}</c>, but is otherwise the
    /// same as <see cref="ISenderProfileService.Update(SenderProfileUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfSenderProfile>> Update(
        SenderProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SenderProfileUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfSenderProfile>> Update(
        string id,
        SenderProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/sender-profiles</c>, but is otherwise the
    /// same as <see cref="ISenderProfileService.List(SenderProfileListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SenderProfileListPage>> List(
        SenderProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/sender-profiles/{id}</c>, but is otherwise the
    /// same as <see cref="ISenderProfileService.Delete(SenderProfileDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        SenderProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SenderProfileDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        SenderProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
