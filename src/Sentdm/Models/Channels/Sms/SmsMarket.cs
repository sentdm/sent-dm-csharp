using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;

namespace Sentdm.Models.Channels.Sms;

/// <summary>
/// One SMS market the profile sends in — its sender, where that sender stands, and
/// what the market wants.              A profile may send in several: it is a tenant,
/// not a market. Each carries its own status, because a profile can be live in one
/// country and mid-registration in another — and each carries what it still owes,
/// rather than that being reported in a separate array a caller has to join on.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SmsMarket, SmsMarketFromRaw>))]
public sealed record class SmsMarket : JsonModel
{
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
    public SmsMarketCompliance? Compliance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SmsMarketCompliance>("compliance");
        }
        init { this._rawData.Set("compliance", value); }
    }

    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

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
    /// Every number this market holds or is still owed, each with its area code
    /// and its own status (ACTIVE once it can send, PROVISIONING while it is still
    /// to be assigned, INACTIVE once it could send and no longer can). One entry
    /// for a market holding one number. US 10DLC numbers are assigned when the campaign
    /// is approved, so they read as owed until then. Read-only.
    /// </summary>
    public IReadOnlyList<SmsNumber>? Numbers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SmsNumber>>("numbers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SmsNumber>?>(
                "numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A sentence for reason_code: this market's own explanation, naming what is
    /// outstanding where that is you. Omitted while ACTIVE.
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
    /// Why the market is not ACTIVE, as a stable code: an ErrorCodes CHANNEL_xxx
    /// value such as CHANNEL_001 (something you owe) or CHANNEL_009 (under review).
    /// Switch on this rather than on reason. Omitted while ACTIVE. Read-only; when
    /// nothing more specific is known it is the generic reason for the status.
    /// </summary>
    public string? ReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason_code");
        }
        init { this._rawData.Set("reason_code", value); }
    }

    /// <summary>
    /// The sender itself. Null until a carrier-assigned number is procured. For a
    /// market holding several numbers, the first active one (the first assigned while
    /// none is active) — every number is in numbers.
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
    /// Where this market's sender stands, in terms of who is holding it up — PROVISIONING,
    /// ACTION_NEEDED, PENDING_REVIEW or ACTIVE. Read-only.              Resolved
    /// rather than reported raw: a live sender reads ACTIVE whatever it still owes,
    /// a market with outstanding requirements or an open resubmission request reads
    /// ACTION_NEEDED, and a market that registers with a regime reads PENDING_REVIEW
    /// once its brand exists — filing to The Campaign Registry is ours to do and
    /// need not have happened yet, so a dedicated brand created through this API
    /// reads PENDING_REVIEW from the moment it is stored.              Describes
    /// whether the market can send, not each number: a market holding several numbers
    /// reads ACTIVE as soon as one of them is, whatever the others are doing. Each
    /// number's own status is in numbers.
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Compliance?.Validate();
        _ = this.Country;
        _ = this.NumberType;
        foreach (var item in this.Numbers ?? [])
        {
            item.Validate();
        }
        _ = this.Reason;
        _ = this.ReasonCode;
        _ = this.SenderValue;
        this.Status?.Validate();
    }

    public SmsMarket() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SmsMarket(SmsMarket smsMarket)
        : base(smsMarket) { }
#pragma warning restore CS8618

    public SmsMarket(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SmsMarket(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SmsMarketFromRaw.FromRawUnchecked"/>
    public static SmsMarket FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SmsMarketFromRaw : IFromRawJson<SmsMarket>
{
    /// <inheritdoc/>
    public SmsMarket FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SmsMarket.FromRawUnchecked(rawData);
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
[JsonConverter(typeof(JsonModelConverter<SmsMarketCompliance, SmsMarketComplianceFromRaw>))]
public sealed record class SmsMarketCompliance : JsonModel
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

    public SmsMarketCompliance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SmsMarketCompliance(SmsMarketCompliance smsMarketCompliance)
        : base(smsMarketCompliance) { }
#pragma warning restore CS8618

    public SmsMarketCompliance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SmsMarketCompliance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SmsMarketComplianceFromRaw.FromRawUnchecked"/>
    public static SmsMarketCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SmsMarketComplianceFromRaw : IFromRawJson<SmsMarketCompliance>
{
    /// <inheritdoc/>
    public SmsMarketCompliance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SmsMarketCompliance.FromRawUnchecked(rawData);
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

/// <summary>
/// Where this market's sender stands, in terms of who is holding it up — PROVISIONING,
/// ACTION_NEEDED, PENDING_REVIEW or ACTIVE. Read-only.              Resolved rather
/// than reported raw: a live sender reads ACTIVE whatever it still owes, a market
/// with outstanding requirements or an open resubmission request reads ACTION_NEEDED,
/// and a market that registers with a regime reads PENDING_REVIEW once its brand
/// exists — filing to The Campaign Registry is ours to do and need not have happened
/// yet, so a dedicated brand created through this API reads PENDING_REVIEW from the
/// moment it is stored.              Describes whether the market can send, not each
/// number: a market holding several numbers reads ACTIVE as soon as one of them
/// is, whatever the others are doing. Each number's own status is in numbers.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Provisioning,
    ActionNeeded,
    PendingReview,
    Active,
    Inactive,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PROVISIONING" => Status.Provisioning,
            "ACTION_NEEDED" => Status.ActionNeeded,
            "PENDING_REVIEW" => Status.PendingReview,
            "ACTIVE" => Status.Active,
            "INACTIVE" => Status.Inactive,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Provisioning => "PROVISIONING",
                Status.ActionNeeded => "ACTION_NEEDED",
                Status.PendingReview => "PENDING_REVIEW",
                Status.Active => "ACTIVE",
                Status.Inactive => "INACTIVE",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
