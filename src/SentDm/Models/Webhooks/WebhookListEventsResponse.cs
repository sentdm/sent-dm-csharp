using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;

namespace SentDm.Models.Webhooks;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WebhookListEventsResponse, WebhookListEventsResponseFromRaw>)
)]
public sealed record class WebhookListEventsResponse : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public WebhookListEventsResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookListEventsResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error details (null if successful)
    /// </summary>
    public ApiError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Metadata about the request and response
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

    public WebhookListEventsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookListEventsResponse(WebhookListEventsResponse webhookListEventsResponse)
        : base(webhookListEventsResponse) { }
#pragma warning restore CS8618

    public WebhookListEventsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListEventsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookListEventsResponseFromRaw.FromRawUnchecked"/>
    public static WebhookListEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookListEventsResponseFromRaw : IFromRawJson<WebhookListEventsResponse>
{
    /// <inheritdoc/>
    public WebhookListEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookListEventsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The response data (null if error)
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WebhookListEventsResponseData, WebhookListEventsResponseDataFromRaw>)
)]
public sealed record class WebhookListEventsResponseData : JsonModel
{
    public IReadOnlyList<Event>? Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Event>>("events");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Event>?>(
                "events",
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
        foreach (var item in this.Events ?? [])
        {
            item.Validate();
        }
        this.Pagination?.Validate();
    }

    public WebhookListEventsResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookListEventsResponseData(
        WebhookListEventsResponseData webhookListEventsResponseData
    )
        : base(webhookListEventsResponseData) { }
#pragma warning restore CS8618

    public WebhookListEventsResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListEventsResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookListEventsResponseDataFromRaw.FromRawUnchecked"/>
    public static WebhookListEventsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookListEventsResponseDataFromRaw : IFromRawJson<WebhookListEventsResponseData>
{
    /// <inheritdoc/>
    public WebhookListEventsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookListEventsResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Event, EventFromRaw>))]
public sealed record class Event : JsonModel
{
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

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public int? DeliveryAttempts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("delivery_attempts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("delivery_attempts", value);
        }
    }

    public string? DeliveryStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("delivery_status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("delivery_status", value);
        }
    }

    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init { this._rawData.Set("error_message", value); }
    }

    public JsonElement? EventData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("event_data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("event_data", value);
        }
    }

    public string? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("event_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("event_type", value);
        }
    }

    public int? HttpStatusCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("http_status_code");
        }
        init { this._rawData.Set("http_status_code", value); }
    }

    public DateTimeOffset? ProcessingCompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("processing_completed_at");
        }
        init { this._rawData.Set("processing_completed_at", value); }
    }

    public DateTimeOffset? ProcessingStartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("processing_started_at");
        }
        init { this._rawData.Set("processing_started_at", value); }
    }

    public string? ResponseBody
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("response_body");
        }
        init { this._rawData.Set("response_body", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DeliveryAttempts;
        _ = this.DeliveryStatus;
        _ = this.ErrorMessage;
        _ = this.EventData;
        _ = this.EventType;
        _ = this.HttpStatusCode;
        _ = this.ProcessingCompletedAt;
        _ = this.ProcessingStartedAt;
        _ = this.ResponseBody;
    }

    public Event() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Event(Event event_)
        : base(event_) { }
#pragma warning restore CS8618

    public Event(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Event(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventFromRaw.FromRawUnchecked"/>
    public static Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventFromRaw : IFromRawJson<Event>
{
    /// <inheritdoc/>
    public Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Event.FromRawUnchecked(rawData);
}
