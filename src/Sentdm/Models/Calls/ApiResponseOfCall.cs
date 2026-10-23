using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Webhooks = Sentdm.Models.Webhooks;

namespace Sentdm.Models.Calls;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ApiResponseOfCall, ApiResponseOfCallFromRaw>))]
public sealed record class ApiResponseOfCall : JsonModel
{
    /// <summary>
    /// A call record
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
    public Webhooks::ErrorDetail? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Webhooks::ErrorDetail>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public Webhooks::ApiMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Webhooks::ApiMeta>("meta");
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

    public ApiResponseOfCall() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfCall(ApiResponseOfCall apiResponseOfCall)
        : base(apiResponseOfCall) { }
#pragma warning restore CS8618

    public ApiResponseOfCall(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfCall(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfCallFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfCall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfCallFromRaw : IFromRawJson<ApiResponseOfCall>
{
    /// <inheritdoc/>
    public ApiResponseOfCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApiResponseOfCall.FromRawUnchecked(rawData);
}

/// <summary>
/// A call record
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
    public From? From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<From>("from");
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
    /// The calling mode: inapp for a call between people in your app and phone numbers,
    /// routed by your number's callback URL
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
    public IReadOnlyList<Timeline>? Timeline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Timeline>>("timeline");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Timeline>?>(
                "timeline",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// One end of a call
    /// </summary>
    public To? To
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<To>("to");
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
/// One end of a call
/// </summary>
[JsonConverter(typeof(JsonModelConverter<From, FromFromRaw>))]
public sealed record class From : JsonModel
{
    /// <summary>
    /// user for one of your app users, number for a phone number, conference for
    /// a room, anonymous for a caller who withheld their number
    /// </summary>
    public string? Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("kind");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("kind", value);
        }
    }

    /// <summary>
    /// The app user's identity, the phone number in E.164 format, or the room name.
    /// Null when the kind is anonymous
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Kind;
        _ = this.Value;
    }

    public From() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public From(From from)
        : base(from) { }
#pragma warning restore CS8618

    public From(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    From(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FromFromRaw.FromRawUnchecked"/>
    public static From FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FromFromRaw : IFromRawJson<From>
{
    /// <inheritdoc/>
    public From FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        From.FromRawUnchecked(rawData);
}

/// <summary>
/// When a call entered a status
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Timeline, TimelineFromRaw>))]
public sealed record class Timeline : JsonModel
{
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
    /// When the call entered this status (UTC)
    /// </summary>
    public DateTimeOffset? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("timestamp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Status;
        _ = this.Timestamp;
    }

    public Timeline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Timeline(Timeline timeline)
        : base(timeline) { }
#pragma warning restore CS8618

    public Timeline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timeline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimelineFromRaw.FromRawUnchecked"/>
    public static Timeline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimelineFromRaw : IFromRawJson<Timeline>
{
    /// <inheritdoc/>
    public Timeline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Timeline.FromRawUnchecked(rawData);
}

/// <summary>
/// One end of a call
/// </summary>
[JsonConverter(typeof(JsonModelConverter<To, ToFromRaw>))]
public sealed record class To : JsonModel
{
    /// <summary>
    /// user for one of your app users, number for a phone number, conference for
    /// a room, anonymous for a caller who withheld their number
    /// </summary>
    public string? Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("kind");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("kind", value);
        }
    }

    /// <summary>
    /// The app user's identity, the phone number in E.164 format, or the room name.
    /// Null when the kind is anonymous
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Kind;
        _ = this.Value;
    }

    public To() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public To(To to)
        : base(to) { }
#pragma warning restore CS8618

    public To(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    To(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToFromRaw.FromRawUnchecked"/>
    public static To FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToFromRaw : IFromRawJson<To>
{
    /// <inheritdoc/>
    public To FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        To.FromRawUnchecked(rawData);
}
