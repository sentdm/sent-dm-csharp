using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Calls;

/// <summary>
/// A call record
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Call, CallFromRaw>))]
public sealed record class Call : JsonModel
{
    /// <summary>
    /// The call id, the same one carried by the call.request question and every call webhook
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// The voice agent that answered the call, such as agent_9f2ab000-0000-4000-8000-000000000001.
    /// Null for an inapp call
    /// </summary>
    public string? AgentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("agent_id");
        }
        init { this._rawData.Set("agent_id", value); }
    }

    /// <summary>
    /// When the call was answered (UTC). Null until then, and always null for a
    /// call between two of your app users
    /// </summary>
    public DateTimeOffset? AnsweredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("answered_at");
        }
        init { this._rawData.Set("answered_at", value); }
    }

    /// <summary>
    /// The caller id shown on the phone leg, in E.164 format: the one your answer
    /// chose, or the owning number when it chose none. Null for a call with no phone leg
    /// </summary>
    public string? CallerIDUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("caller_id_used");
        }
        init { this._rawData.Set("caller_id_used", value); }
    }

    /// <summary>
    /// The phone number the call was connected to, in E.164 format: the number your
    /// answer dialed, or the fallback number a call to one of your voice agents
    /// reached. Null when the call was not connected to a phone number
    /// </summary>
    public string? ConnectedNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("connected_number");
        }
        init { this._rawData.Set("connected_number", value); }
    }

    /// <summary>
    /// outbound for a call placed from your app, inbound for a call to one of your numbers
    /// </summary>
    public string? Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("direction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("direction", value);
        }
    }

    /// <summary>
    /// Billable duration in seconds. Null while the call is live
    /// </summary>
    public int? DurationSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("duration_seconds");
        }
        init { this._rawData.Set("duration_seconds", value); }
    }

    /// <summary>
    /// When the call ended (UTC). Null while the call is live
    /// </summary>
    public DateTimeOffset? EndedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("ended_at");
        }
        init { this._rawData.Set("ended_at", value); }
    }

    /// <summary>
    /// Why the call did not complete: callback_timeout, invalid_answer, insufficient_balance,
    /// destination_blocked, callback_not_configured, rejected, no_answer, or for
    /// an agent call agent_busy or agent_unreachable. Null while the call is live,
    /// when it completed, and when it failed without a recorded reason
    /// </summary>
    public string? FailureReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("failure_reason");
        }
        init { this._rawData.Set("failure_reason", value); }
    }

    /// <summary>
    /// One end of a call
    /// </summary>
    public CallParty? From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallParty>("from");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// The legs the price covers, one entry per billed leg, each with its own cost:
    /// a call your answer connected to a phone number ran the caller's leg to your
    /// number and the leg to the connected number at once, and both are billed.
    /// Null until the call has been priced
    /// </summary>
    public IReadOnlyList<Leg>? Legs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Leg>>("legs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Leg>?>(
                "legs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The calling mode: inapp for a call between people in your app and phone numbers,
    /// routed by your number's callback URL; agent for a call one of your voice agents answered
    /// </summary>
    public string? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <summary>
    /// Your number that owns the call, in E.164 format: the dialed number for an
    /// inbound call, the caller's bound number for a call placed from your app
    /// </summary>
    public string? Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("number", value);
        }
    }

    /// <summary>
    /// What the call cost. Null until it has been priced
    /// </summary>
    public double? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// True once a recording of the call is available
    /// </summary>
    public bool? RecordingAvailable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("recording_available");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("recording_available", value);
        }
    }

    /// <summary>
    /// When the call was placed (UTC)
    /// </summary>
    public DateTimeOffset? StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("started_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("started_at", value);
        }
    }

    /// <summary>
    /// INITIATED, RINGING, ANSWERED, COMPLETED, FAILED, NO_ANSWER or REJECTED
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
    /// When the call entered each status, oldest first. Only returned when reading
    /// one call
    /// </summary>
    public IReadOnlyList<CallTimelineEntry>? Timeline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CallTimelineEntry>>("timeline");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CallTimelineEntry>?>(
                "timeline",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// One end of a call
    /// </summary>
    public CallParty? To
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallParty>("to");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AgentID;
        _ = this.AnsweredAt;
        _ = this.CallerIDUsed;
        _ = this.ConnectedNumber;
        _ = this.Direction;
        _ = this.DurationSeconds;
        _ = this.EndedAt;
        _ = this.FailureReason;
        this.From?.Validate();
        foreach (var item in this.Legs ?? [])
        {
            item.Validate();
        }
        _ = this.Mode;
        _ = this.Number;
        _ = this.Price;
        _ = this.RecordingAvailable;
        _ = this.StartedAt;
        _ = this.Status;
        foreach (var item in this.Timeline ?? [])
        {
            item.Validate();
        }
        this.To?.Validate();
    }

    public Call() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Call(Call call)
        : base(call) { }
#pragma warning restore CS8618

    public Call(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Call(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallFromRaw.FromRawUnchecked"/>
    public static Call FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallFromRaw : IFromRawJson<Call>
{
    /// <inheritdoc/>
    public Call FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Call.FromRawUnchecked(rawData);
}

/// <summary>
/// One leg of a call the price covers
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Leg, LegFromRaw>))]
public sealed record class Leg : JsonModel
{
    /// <summary>
    /// The whole minutes the leg was billed for
    /// </summary>
    public int? BilledMinutes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("billed_minutes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billed_minutes", value);
        }
    }

    /// <summary>
    /// What the leg cost, in the same unit as the call's price
    /// </summary>
    public double? Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("cost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cost", value);
        }
    }

    /// <summary>
    /// The currency of the cost: USD
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// inbound for the caller's leg to your number, outbound for a leg placed on
    /// your behalf
    /// </summary>
    public string? Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("direction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("direction", value);
        }
    }

    /// <summary>
    /// The phone number the leg reached, in E.164 format: your number for the inbound
    /// leg, the number dialed for an outbound one. Null for a leg to one of your
    /// app users or a room
    /// </summary>
    public string? Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("number");
        }
        init { this._rawData.Set("number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BilledMinutes;
        _ = this.Cost;
        _ = this.Currency;
        _ = this.Direction;
        _ = this.Number;
    }

    public Leg() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Leg(Leg leg)
        : base(leg) { }
#pragma warning restore CS8618

    public Leg(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Leg(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LegFromRaw.FromRawUnchecked"/>
    public static Leg FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LegFromRaw : IFromRawJson<Leg>
{
    /// <inheritdoc/>
    public Leg FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Leg.FromRawUnchecked(rawData);
}
