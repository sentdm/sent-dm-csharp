using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Calls;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ApiResponseOfCallsList, ApiResponseOfCallsListFromRaw>))]
public sealed record class ApiResponseOfCallsList : JsonModel
{
    /// <summary>
    /// Paginated list of calls
    /// </summary>
    public ApiResponseOfCallsListData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiResponseOfCallsListData>("data");
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

    public ApiResponseOfCallsList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfCallsList(ApiResponseOfCallsList apiResponseOfCallsList)
        : base(apiResponseOfCallsList) { }
#pragma warning restore CS8618

    public ApiResponseOfCallsList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfCallsList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfCallsListFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfCallsList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfCallsListFromRaw : IFromRawJson<ApiResponseOfCallsList>
{
    /// <inheritdoc/>
    public ApiResponseOfCallsList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfCallsList.FromRawUnchecked(rawData);
}

/// <summary>
/// Paginated list of calls
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ApiResponseOfCallsListData, ApiResponseOfCallsListDataFromRaw>)
)]
public sealed record class ApiResponseOfCallsListData : JsonModel
{
    /// <summary>
    /// The calls on this page, most recent first
    /// </summary>
    public IReadOnlyList<Call>? Calls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Call>>("calls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Call>?>(
                "calls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata for list responses
    /// </summary>
    public PaginationMeta? Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>("pagination");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pagination", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Calls ?? [])
        {
            item.Validate();
        }
        this.Pagination?.Validate();
    }

    public ApiResponseOfCallsListData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfCallsListData(ApiResponseOfCallsListData apiResponseOfCallsListData)
        : base(apiResponseOfCallsListData) { }
#pragma warning restore CS8618

    public ApiResponseOfCallsListData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfCallsListData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfCallsListDataFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfCallsListData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfCallsListDataFromRaw : IFromRawJson<ApiResponseOfCallsListData>
{
    /// <inheritdoc/>
    public ApiResponseOfCallsListData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfCallsListData.FromRawUnchecked(rawData);
}

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
    public CallFrom? From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallFrom>("from");
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
    public IReadOnlyList<CallTimeline>? Timeline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CallTimeline>>("timeline");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CallTimeline>?>(
                "timeline",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// One end of a call
    /// </summary>
    public CallTo? To
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallTo>("to");
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
/// One end of a call
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallFrom, CallFromFromRaw>))]
public sealed record class CallFrom : JsonModel
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

    public CallFrom() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallFrom(CallFrom callFrom)
        : base(callFrom) { }
#pragma warning restore CS8618

    public CallFrom(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallFrom(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallFromFromRaw.FromRawUnchecked"/>
    public static CallFrom FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallFromFromRaw : IFromRawJson<CallFrom>
{
    /// <inheritdoc/>
    public CallFrom FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CallFrom.FromRawUnchecked(rawData);
}

/// <summary>
/// When a call entered a status
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallTimeline, CallTimelineFromRaw>))]
public sealed record class CallTimeline : JsonModel
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

    public CallTimeline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallTimeline(CallTimeline callTimeline)
        : base(callTimeline) { }
#pragma warning restore CS8618

    public CallTimeline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallTimeline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallTimelineFromRaw.FromRawUnchecked"/>
    public static CallTimeline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallTimelineFromRaw : IFromRawJson<CallTimeline>
{
    /// <inheritdoc/>
    public CallTimeline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CallTimeline.FromRawUnchecked(rawData);
}

/// <summary>
/// One end of a call
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallTo, CallToFromRaw>))]
public sealed record class CallTo : JsonModel
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

    public CallTo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallTo(CallTo callTo)
        : base(callTo) { }
#pragma warning restore CS8618

    public CallTo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallTo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallToFromRaw.FromRawUnchecked"/>
    public static CallTo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallToFromRaw : IFromRawJson<CallTo>
{
    /// <inheritdoc/>
    public CallTo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CallTo.FromRawUnchecked(rawData);
}
