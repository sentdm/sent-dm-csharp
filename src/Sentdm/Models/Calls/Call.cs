using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Calls;

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
    /// destination_blocked, callback_not_configured, rejected or no_answer. Null
    /// while the call is live, when it completed, and when it failed without a recorded reason
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
        _ = this.AnsweredAt;
        _ = this.Direction;
        _ = this.DurationSeconds;
        _ = this.EndedAt;
        _ = this.FailureReason;
        this.From?.Validate();
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
