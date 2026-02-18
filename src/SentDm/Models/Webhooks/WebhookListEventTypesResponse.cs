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
    typeof(JsonModelConverter<WebhookListEventTypesResponse, WebhookListEventTypesResponseFromRaw>)
)]
public sealed record class WebhookListEventTypesResponse : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public WebhookListEventTypesResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookListEventTypesResponseData>("data");
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

    public WebhookListEventTypesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookListEventTypesResponse(
        WebhookListEventTypesResponse webhookListEventTypesResponse
    )
        : base(webhookListEventTypesResponse) { }
#pragma warning restore CS8618

    public WebhookListEventTypesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListEventTypesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookListEventTypesResponseFromRaw.FromRawUnchecked"/>
    public static WebhookListEventTypesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookListEventTypesResponseFromRaw : IFromRawJson<WebhookListEventTypesResponse>
{
    /// <inheritdoc/>
    public WebhookListEventTypesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookListEventTypesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The response data (null if error)
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WebhookListEventTypesResponseData,
        WebhookListEventTypesResponseDataFromRaw
    >)
)]
public sealed record class WebhookListEventTypesResponseData : JsonModel
{
    public IReadOnlyList<EventType>? EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<EventType>>("event_types");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<EventType>?>(
                "event_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.EventTypes ?? [])
        {
            item.Validate();
        }
    }

    public WebhookListEventTypesResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookListEventTypesResponseData(
        WebhookListEventTypesResponseData webhookListEventTypesResponseData
    )
        : base(webhookListEventTypesResponseData) { }
#pragma warning restore CS8618

    public WebhookListEventTypesResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListEventTypesResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookListEventTypesResponseDataFromRaw.FromRawUnchecked"/>
    public static WebhookListEventTypesResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookListEventTypesResponseDataFromRaw : IFromRawJson<WebhookListEventTypesResponseData>
{
    /// <inheritdoc/>
    public WebhookListEventTypesResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookListEventTypesResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<EventType, EventTypeFromRaw>))]
public sealed record class EventType : JsonModel
{
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("display_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("display_name", value);
        }
    }

    public bool? IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_active", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.DisplayName;
        _ = this.IsActive;
        _ = this.Name;
    }

    public EventType() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventType(EventType eventType)
        : base(eventType) { }
#pragma warning restore CS8618

    public EventType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventTypeFromRaw.FromRawUnchecked"/>
    public static EventType FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventTypeFromRaw : IFromRawJson<EventType>
{
    /// <inheritdoc/>
    public EventType FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EventType.FromRawUnchecked(rawData);
}
