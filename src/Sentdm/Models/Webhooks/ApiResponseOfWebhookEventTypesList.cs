using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ApiResponseOfWebhookEventTypesList,
        ApiResponseOfWebhookEventTypesListFromRaw
    >)
)]
public sealed record class ApiResponseOfWebhookEventTypesList : JsonModel
{
    /// <summary>
    /// The webhook event types a customer can subscribe to.
    /// </summary>
    public WebhookEventTypesList? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookEventTypesList>("data");
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

    public ApiResponseOfWebhookEventTypesList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfWebhookEventTypesList(
        ApiResponseOfWebhookEventTypesList apiResponseOfWebhookEventTypesList
    )
        : base(apiResponseOfWebhookEventTypesList) { }
#pragma warning restore CS8618

    public ApiResponseOfWebhookEventTypesList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfWebhookEventTypesList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfWebhookEventTypesListFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfWebhookEventTypesList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfWebhookEventTypesListFromRaw : IFromRawJson<ApiResponseOfWebhookEventTypesList>
{
    /// <inheritdoc/>
    public ApiResponseOfWebhookEventTypesList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfWebhookEventTypesList.FromRawUnchecked(rawData);
}
