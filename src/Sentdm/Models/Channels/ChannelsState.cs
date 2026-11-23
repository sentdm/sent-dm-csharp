using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Channels.Rcs;
using Sentdm.Models.Channels.Sms;
using Sentdm.Models.Channels.Voice;
using Sentdm.Models.Channels.Whatsapp;

namespace Sentdm.Models.Channels;

/// <summary>
/// The channels a profile sends on. SMS is a list because a profile can send in
/// several markets; WhatsApp and RCS are single, because a profile has one business
/// account and one agent.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChannelsState, ChannelsStateFromRaw>))]
public sealed record class ChannelsState : JsonModel
{
    /// <summary>
    /// Which customer these channels belong to — the key's own, or the profile named
    /// in x-profile-id.              Same reason the brand carries one: as the response
    /// to /v3/channels there is no other id in the document, and under x-profile-id
    /// this is the profile the call resolved to rather than the caller. Absent when
    /// nested inside a sender profile, whose own id already says whose they are.
    /// </summary>
    public string? CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    /// <summary>
    /// The markets this profile can send MMS in, one entry per country, or empty
    /// when none.              Appears alongside sms rather than replacing an entry
    /// in it: the two are separate senders on the same number and a caller needs
    /// to see both — a market can be live for SMS while its MMS row is still provisioning,
    /// or MMS-incapable entirely because the market's sender-type SKU does not carry it.
    /// </summary>
    public IReadOnlyList<MmsMarket>? Mms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MmsMarket>>("mms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<MmsMarket>?>(
                "mms",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// An RCS agent as its owner sees it: the order form back, plus where the submission
    /// stands.              Not RcsSenderResponse. That one is the admin projection
    /// and carries the pipeline we track about a customer's request — internalStatus,
    /// statusReason, isLaunched — and the S3 keys behind the assets. None of that
    /// is the customer's to read: an internal status is a note to ourselves, and
    /// an S3 key is a storage detail that would become a contract the moment it was
    /// published.              What is here is what the caller sent, in the names
    /// it sent them under, plus the three things only we can answer: the record's
    /// id, its status, and the number it sends from. So a read after a write shows
    /// the form as stored rather than as echoed.
    /// </summary>
    public RcsAgent? Rcs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RcsAgent>("rcs");
        }
        init { this._rawData.Set("rcs", value); }
    }

    public IReadOnlyList<ChannelsStateSms>? Sms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ChannelsStateSms>>("sms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ChannelsStateSms>?>(
                "sms",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The numbers this profile carries phone calls on, one entry per number, or
    /// empty when none. Voice is per number like an SMS market is per country: each
    /// number is its own channel row, turned on and off on its own, and one of them
    /// is the line app-originated calls fall back to.
    /// </summary>
    public IReadOnlyList<VoiceNumber>? Voice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<VoiceNumber>>("voice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<VoiceNumber>?>(
                "voice",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The profile's WhatsApp account. Its status is Meta's verification state.
    /// </summary>
    public WhatsappChannel? Whatsapp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappChannel>("whatsapp");
        }
        init { this._rawData.Set("whatsapp", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CustomerID;
        foreach (var item in this.Mms ?? [])
        {
            item.Validate();
        }
        this.Rcs?.Validate();
        foreach (var item in this.Sms ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Voice ?? [])
        {
            item.Validate();
        }
        this.Whatsapp?.Validate();
    }

    public ChannelsState() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelsState(ChannelsState channelsState)
        : base(channelsState) { }
#pragma warning restore CS8618

    public ChannelsState(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelsState(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelsStateFromRaw.FromRawUnchecked"/>
    public static ChannelsState FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelsStateFromRaw : IFromRawJson<ChannelsState>
{
    /// <inheritdoc/>
    public ChannelsState FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelsState.FromRawUnchecked(rawData);
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
[JsonConverter(typeof(JsonModelConverter<ChannelsStateSms, ChannelsStateSmsFromRaw>))]
public sealed record class ChannelsStateSms : JsonModel
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
    public ApiEnum<string, global::Sentdm.Models.Channels.Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::Sentdm.Models.Channels.Status>
            >("status");
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

    public ChannelsStateSms() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelsStateSms(ChannelsStateSms channelsStateSms)
        : base(channelsStateSms) { }
#pragma warning restore CS8618

    public ChannelsStateSms(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelsStateSms(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelsStateSmsFromRaw.FromRawUnchecked"/>
    public static ChannelsStateSms FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelsStateSmsFromRaw : IFromRawJson<ChannelsStateSms>
{
    /// <inheritdoc/>
    public ChannelsStateSms FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelsStateSms.FromRawUnchecked(rawData);
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
[JsonConverter(typeof(global::Sentdm.Models.Channels.StatusConverter))]
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

sealed class StatusConverter : JsonConverter<global::Sentdm.Models.Channels.Status>
{
    public override global::Sentdm.Models.Channels.Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PROVISIONING" => global::Sentdm.Models.Channels.Status.Provisioning,
            "ACTION_NEEDED" => global::Sentdm.Models.Channels.Status.ActionNeeded,
            "PENDING_REVIEW" => global::Sentdm.Models.Channels.Status.PendingReview,
            "ACTIVE" => global::Sentdm.Models.Channels.Status.Active,
            "INACTIVE" => global::Sentdm.Models.Channels.Status.Inactive,
            _ => (global::Sentdm.Models.Channels.Status)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Sentdm.Models.Channels.Status value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Sentdm.Models.Channels.Status.Provisioning => "PROVISIONING",
                global::Sentdm.Models.Channels.Status.ActionNeeded => "ACTION_NEEDED",
                global::Sentdm.Models.Channels.Status.PendingReview => "PENDING_REVIEW",
                global::Sentdm.Models.Channels.Status.Active => "ACTIVE",
                global::Sentdm.Models.Channels.Status.Inactive => "INACTIVE",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
