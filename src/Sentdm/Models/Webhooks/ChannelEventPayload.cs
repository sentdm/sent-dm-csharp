using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Body of a channel event: where one of the customer's channels stands in provisioning
/// and compliance. Delivered when a milestone moves — a registration filed, a verdict
/// returned, a resubmission asked for, a sender gone live — so a customer's own onboarding
/// UI does not have to poll GET /v3/channels.              The subject is one item,
/// never the account. A customer's "SMS channel" has no status; a market does. Country,
/// NumberType and SenderValue name which one, so a customer terminating only to Kosovo
/// never receives an event about US 10DLC.              Status is the stable half
/// of the contract. It is the same four-value set GET /v3/channels publishes, computed
/// through the same code, so an event and a read of the same market cannot disagree.
/// A subscriber that reads nothing but the status and the subject fields is a correct
/// subscriber. The sub-type on the envelope names the specific milestone and is
/// additive — that vocabulary comes from registries and carriers, which are parties
/// Sent does not control.              Status means provisioning and compliance are
/// complete, not that a send will succeed right now. An account can be suspended,
/// or a destination blocked by a routing rule, without either showing up here. Those
/// are separate surfaces and deliberately not modelled on this payload.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChannelEventPayload, ChannelEventPayloadFromRaw>))]
public sealed record class ChannelEventPayload : JsonModel
{
    /// <summary>
    /// The market's destination country as an ISO 3166-1 alpha-2 code, for example
    /// XK. Always present, and the property that identifies this payload among the
    /// delivered envelopes — see DeliveredWebhookEvents. Every event in this family
    /// reports one market, and a market has a country.
    /// </summary>
    public required string Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// The account whose market this is, named as on every other family. When an
    /// organization receives an event for one of its sender profiles this is the
    /// profile, so a reseller compares it with its own id and anything different
    /// is one of its profiles. Matches customer_id on GET /v3/channels and the sender
    /// profile's id. Together with channel, country, and number_type, it identifies
    /// the market.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_id", value);
        }
    }

    /// <summary>
    /// The channel this market belongs to: sms, whatsapp, or rcs. Never sent — that
    /// value belongs to message events, where it names the smart-routing brand rather
    /// than a channel that can be provisioned.
    /// </summary>
    public string? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channel", value);
        }
    }

    /// <summary>
    /// What a market has been given: the identity it registers under, its programme,
    /// and any documents attached.              What it does not carry is what the
    /// market asks for. That is the subject of GET /v3/compliance/requirements, and
    /// it is the same answer for every caller — a description of what a compliance
    /// regime wants, not a record of one customer's progress through it. It was
    /// reported here as well for a while, which put the same array in six response
    /// shapes and left a caller deciding which of two sources to believe.
    ///       Present on a list read for markets that register (carrying brand and
    /// campaign), but with documents absent — documents are not fetched for a list,
    /// because a catalog lookup and a document read per market would multiply across
    /// a page. Absent documents is distinct from an empty list: absent says they
    /// were not fetched; empty says the market has been given none. The parent object
    /// is null only when the market registers with nobody and compliance was not
    /// computed — nothing to show at all.
    /// </summary>
    public Compliance? Compliance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Compliance>("compliance");
        }
        init { this._rawData.Set("compliance", value); }
    }

    /// <summary>
    /// The kind of sender the market uses, for example TEN_DLC, LOCAL, or ALPHANUMERIC.
    /// Omitted when the subject has no sender type of its own.
    /// </summary>
    public string? NumberType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("number_type");
        }
        init { this._rawData.Set("number_type", value); }
    }

    /// <summary>
    /// Why the market reached this state, when a reason was given — a correction
    /// explained, or a campaign lapse. Free text, passed through from the registry
    /// or carrier that wrote it, so treat it as a message to show a human rather
    /// than a value to branch on.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The sender itself — a number in E.164, or an alphanumeric sender ID.
    ///         Always present, and null until a sender exists. The key is on every
    /// delivery so a subscriber reads one shape rather than branching on whether
    /// the field arrived — the same choice template_id makes on the message payload.
    ///              It can carry a value at any point in the lifecycle, not only
    /// once the market is live: a number ordered and not yet active at the carrier
    /// is already known during PROVISIONING, and an alphanumeric sender the customer
    /// chose themselves is known before anything is filed. It is null while the market
    /// is still waiting on a number, which for a US 10DLC registration is every
    /// event up to channel.activated.
    /// </summary>
    public string? SenderValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sender_value");
        }
        init { this._rawData.Set("sender_value", value); }
    }

    /// <summary>
    /// Where the market stands: PENDING_REVIEW, ACTION_NEEDED, PROVISIONING, ACTIVE
    /// or INACTIVE. PENDING_REVIEW means a registry or a carrier holds it and the
    /// wait is theirs; ACTION_NEEDED means it is yours; PROVISIONING means the verdict
    /// is in and Sent is acquiring the sender; INACTIVE means it had a working sender
    /// and no longer does.              Each event name is the transition into one
    /// of these, but the two are separate fields and may legitimately differ. A resubmission
    /// filed against a market whose sender is already live is channel.submitted carrying
    /// ACTIVE: a correction is with the registry and the sender keeps working. Read both.
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// When the transition happened, in UTC (yyyy-MM-ddTHH:mm:ssZ).
    /// </summary>
    public string? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.AccountID;
        _ = this.Channel;
        this.Compliance?.Validate();
        _ = this.NumberType;
        _ = this.Reason;
        _ = this.SenderValue;
        _ = this.Status;
        _ = this.UpdatedAt;
    }

    public ChannelEventPayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelEventPayload(ChannelEventPayload channelEventPayload)
        : base(channelEventPayload) { }
#pragma warning restore CS8618

    public ChannelEventPayload(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelEventPayload(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelEventPayloadFromRaw.FromRawUnchecked"/>
    public static ChannelEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChannelEventPayload(string country)
        : this()
    {
        this.Country = country;
    }
}

class ChannelEventPayloadFromRaw : IFromRawJson<ChannelEventPayload>
{
    /// <inheritdoc/>
    public ChannelEventPayload FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelEventPayload.FromRawUnchecked(rawData);
}

/// <summary>
/// What a market has been given: the identity it registers under, its programme,
/// and any documents attached.              What it does not carry is what the market
/// asks for. That is the subject of GET /v3/compliance/requirements, and it is the
/// same answer for every caller — a description of what a compliance regime wants,
/// not a record of one customer's progress through it. It was reported here as well
/// for a while, which put the same array in six response shapes and left a caller
/// deciding which of two sources to believe.              Present on a list read
/// for markets that register (carrying brand and campaign), but with documents absent
/// — documents are not fetched for a list, because a catalog lookup and a document
/// read per market would multiply across a page. Absent documents is distinct from
/// an empty list: absent says they were not fetched; empty says the market has been
/// given none. The parent object is null only when the market registers with nobody
/// and compliance was not computed — nothing to show at all.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Compliance, ComplianceFromRaw>))]
public sealed record class Compliance : JsonModel
{
    /// <summary>
    /// The identity this market registers under, with inherit saying whose it is.
    ///              Reported here rather than on the profile because it belongs
    /// to the registration this market files, and only one market files one. It was
    /// a top-level block for a while, which put a per-registration value beside
    /// a list of markets and left a caller to work out which market it belonged to.
    ///              Absent for a market that registers with nobody — such a market
    /// asks for no identity, so there is none to report. Absent and null mean different
    /// things: absent says this market does not ask, null would say it asks and nothing
    /// was supplied.              Untyped, like the request side, because its members
    /// are declared by the market's own schema rather than by a C# class. A typed
    /// pair here would be a second definition of what a market wants, free to drift
    /// from the one that validates.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("brand");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "brand",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The programme this market registers, with inherit saying whose it is.
    ///
    ///
    /// <para>             One, not a list. TcrCampaigns permits several and an account
    /// built on the admin side may hold them, but this surface offers one — which
    /// is what lets the market's PATCH be an upsert rather than a collection with
    /// an addressable create behind it. An account holding several is reported as
    /// its first and refused on write, rather than half-edited.              Carries
    /// no id. Nothing addresses a campaign, and an undeclared key would be refused
    /// if the caller sent this object back — which it is meant to be able to do.</para>
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Campaign
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "campaign"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "campaign",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// What has been supplied for this market.              Files, not values — the
    /// declared halves above carry the values. A document cannot be a JSON value,
    /// so it is sent as multipart on the channel call and reported here as a reference.
    ///              Absent on a list read, which fetches identity but does not compute
    /// compliance documents per market. Absent and empty mean different things: absent
    /// says the documents were not fetched; empty says the market has been given none.
    /// </summary>
    public IReadOnlyList<Document>? Documents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Document>>("documents");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Document>?>(
                "documents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Brand;
        _ = this.Campaign;
        foreach (var item in this.Documents ?? [])
        {
            item.Validate();
        }
    }

    public Compliance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Compliance(Compliance compliance)
        : base(compliance) { }
#pragma warning restore CS8618

    public Compliance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Compliance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComplianceFromRaw.FromRawUnchecked"/>
    public static Compliance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComplianceFromRaw : IFromRawJson<Compliance>
{
    /// <inheritdoc/>
    public Compliance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Compliance.FromRawUnchecked(rawData);
}

/// <summary>
/// A document a market asked for and has been given.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Document, DocumentFromRaw>))]
public sealed record class Document : JsonModel
{
    /// <summary>
    /// Identifier of the upload, for fetching it back through the documents endpoints.
    /// </summary>
    public string? DocumentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("document_id");
        }
        init { this._rawData.Set("document_id", value); }
    }

    public string? FileName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("file_name");
        }
        init { this._rawData.Set("file_name", value); }
    }

    /// <summary>
    /// The catalog's name for this document, matching the requirement it satisfies.
    /// </summary>
    public string? Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("key", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DocumentID;
        _ = this.FileName;
        _ = this.Key;
    }

    public Document() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Document(Document document)
        : base(document) { }
#pragma warning restore CS8618

    public Document(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Document(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentFromRaw.FromRawUnchecked"/>
    public static Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocumentFromRaw : IFromRawJson<Document>
{
    /// <inheritdoc/>
    public Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Document.FromRawUnchecked(rawData);
}
