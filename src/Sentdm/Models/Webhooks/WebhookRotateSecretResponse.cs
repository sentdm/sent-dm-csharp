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
    typeof(JsonModelConverter<WebhookRotateSecretResponse, WebhookRotateSecretResponseFromRaw>)
)]
public sealed record class WebhookRotateSecretResponse : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public WebhookRotateSecretResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookRotateSecretResponseData>("data");
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

    public WebhookRotateSecretResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookRotateSecretResponse(WebhookRotateSecretResponse webhookRotateSecretResponse)
        : base(webhookRotateSecretResponse) { }
#pragma warning restore CS8618

    public WebhookRotateSecretResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookRotateSecretResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookRotateSecretResponseFromRaw.FromRawUnchecked"/>
    public static WebhookRotateSecretResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookRotateSecretResponseFromRaw : IFromRawJson<WebhookRotateSecretResponse>
{
    /// <inheritdoc/>
    public WebhookRotateSecretResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookRotateSecretResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The response data (null if error)
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WebhookRotateSecretResponseData,
        WebhookRotateSecretResponseDataFromRaw
    >)
)]
public sealed record class WebhookRotateSecretResponseData : JsonModel
{
    public string? SigningSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("signing_secret");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signing_secret", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SigningSecret;
    }

    public WebhookRotateSecretResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookRotateSecretResponseData(
        WebhookRotateSecretResponseData webhookRotateSecretResponseData
    )
        : base(webhookRotateSecretResponseData) { }
#pragma warning restore CS8618

    public WebhookRotateSecretResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookRotateSecretResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookRotateSecretResponseDataFromRaw.FromRawUnchecked"/>
    public static WebhookRotateSecretResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookRotateSecretResponseDataFromRaw : IFromRawJson<WebhookRotateSecretResponseData>
{
    /// <inheritdoc/>
    public WebhookRotateSecretResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookRotateSecretResponseData.FromRawUnchecked(rawData);
}
