using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Channels.Sms;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SmsCreateResponse, SmsCreateResponseFromRaw>))]
public sealed record class SmsCreateResponse : JsonModel
{
    /// <summary>
    /// One market the profile sends in on a channel — its sender, where that sender
    /// stands, and what the market wants. Named for no one channel, as the routes
    /// it answers are not (/v3/channels/{channel}/{country}/{type}); SMS is the channel
    /// with markets today.              A profile may send in several: it is a tenant,
    /// not a market. Each carries its own status, because a profile can be live in
    /// one country and mid-registration in another — and each carries what it still
    /// owes, rather than that being reported in a separate array a caller has to
    /// join on.
    /// </summary>
    public Data? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public ErrorDetail? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ErrorDetail>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public ApiMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiMeta>("meta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data?.Validate();
        this.Error?.Validate();
        this.Meta?.Validate();
        _ = this.Success;
    }

    public SmsCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SmsCreateResponse(SmsCreateResponse smsCreateResponse)
        : base(smsCreateResponse) { }
#pragma warning restore CS8618

    public SmsCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SmsCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SmsCreateResponseFromRaw.FromRawUnchecked"/>
    public static SmsCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SmsCreateResponseFromRaw : IFromRawJson<SmsCreateResponse>
{
    /// <inheritdoc/>
    public SmsCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SmsCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// One market the profile sends in on a channel — its sender, where that sender stands,
/// and what the market wants. Named for no one channel, as the routes it answers
/// are not (/v3/channels/{channel}/{country}/{type}); SMS is the channel with markets
/// today.              A profile may send in several: it is a tenant, not a market.
/// Each carries its own status, because a profile can be live in one country and
/// mid-registration in another — and each carries what it still owes, rather than
/// that being reported in a separate array a caller has to join on.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
    public SuppliedCompliance? Compliance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SuppliedCompliance>("compliance");
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
        this.Status?.Validate();
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
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
    /// <summary>
    /// We are working on it and there is nothing for you to do — a number is being
    /// procured, or a registration is being assembled. Minutes to hours.
    /// </summary>
    Provisioning,

    /// <summary>
    /// **Waiting on you.** Something the market asks for has not been supplied,
    /// a regulator rejected what was, or we have asked you to correct and resubmit
    /// your identity data. Nothing progresses until you act. For an SMS market,
    /// `GET /v3/channels/sms/{country}/{type}` names what it wants and `PATCH` on
    /// the same path supplies it — compliance values, documents and numbers alike.
    /// </summary>
    ActionNeeded,

    /// <summary>
    /// With a regulator or carrier — filed, or assembled and queued for us to file
    /// — and their answer is what moves it, to `ACTIVE` or back to `ACTION_NEEDED`.
    /// Nothing on your side changes it. Days for SMS, weeks for RCS.
    /// </summary>
    PendingReview,

    /// <summary>
    /// Can carry traffic now. A channel a sender profile runs on its organization's
    /// reads `ACTIVE` too — it sends, which is what the field is about.
    /// </summary>
    Active,

    /// <summary>
    /// **It had a working sender and no longer does** — the number was released,
    /// or the campaign it carried lapsed. Distinct from `PROVISIONING`, which means
    /// it has never sent yet: the same absence of a sender, opposite news. Sends
    /// will fail until it returns to `ACTIVE`.
    /// </summary>
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
