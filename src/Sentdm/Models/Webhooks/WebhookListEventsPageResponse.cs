using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WebhookListEventsPageResponse, WebhookListEventsPageResponseFromRaw>)
)]
public sealed record class WebhookListEventsPageResponse : JsonModel
{
    /// <summary>
    /// A paginated list of webhook delivery records.
    /// </summary>
    public WebhookListEventsPageResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookListEventsPageResponseData>("data");
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

    public WebhookListEventsPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookListEventsPageResponse(
        WebhookListEventsPageResponse webhookListEventsPageResponse
    )
        : base(webhookListEventsPageResponse) { }
#pragma warning restore CS8618

    public WebhookListEventsPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListEventsPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookListEventsPageResponseFromRaw.FromRawUnchecked"/>
    public static WebhookListEventsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookListEventsPageResponseFromRaw : IFromRawJson<WebhookListEventsPageResponse>
{
    /// <inheritdoc/>
    public WebhookListEventsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookListEventsPageResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A paginated list of webhook delivery records.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WebhookListEventsPageResponseData,
        WebhookListEventsPageResponseDataFromRaw
    >)
)]
public sealed record class WebhookListEventsPageResponseData : JsonModel
{
    /// <summary>
    /// The events on this page.
    /// </summary>
    public IReadOnlyList<WebhookListEventsResponse>? Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WebhookListEventsResponse>>(
                "events"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WebhookListEventsResponse>?>(
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

    public WebhookListEventsPageResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookListEventsPageResponseData(
        WebhookListEventsPageResponseData webhookListEventsPageResponseData
    )
        : base(webhookListEventsPageResponseData) { }
#pragma warning restore CS8618

    public WebhookListEventsPageResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListEventsPageResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookListEventsPageResponseDataFromRaw.FromRawUnchecked"/>
    public static WebhookListEventsPageResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookListEventsPageResponseDataFromRaw : IFromRawJson<WebhookListEventsPageResponseData>
{
    /// <inheritdoc/>
    public WebhookListEventsPageResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookListEventsPageResponseData.FromRawUnchecked(rawData);
}
