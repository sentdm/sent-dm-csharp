using System;
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
    /// Error information
    /// </summary>
    public WebhookRotateSecretResponseError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookRotateSecretResponseError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public WebhookRotateSecretResponseMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookRotateSecretResponseMeta>("meta");
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

/// <summary>
/// Error information
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WebhookRotateSecretResponseError,
        WebhookRotateSecretResponseErrorFromRaw
    >)
)]
public sealed record class WebhookRotateSecretResponseError : JsonModel
{
    /// <summary>
    /// Machine-readable error code (e.g., "RESOURCE_001")
    /// </summary>
    public string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    /// <summary>
    /// Additional validation error details (field-level errors)
    /// </summary>
    public IReadOnlyDictionary<string, IReadOnlyList<string>>? Details
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableClass<
                FrozenDictionary<string, ImmutableArray<string>>
            >("details");
            if (value == null)
            {
                return null;
            }

            return FrozenDictionary.ToFrozenDictionary(
                value,
                entry => entry.Key,
                (entry) => (IReadOnlyList<string>)entry.Value
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, ImmutableArray<string>>?>(
                "details",
                value == null
                    ? null
                    : FrozenDictionary.ToFrozenDictionary(
                        value,
                        entry => entry.Key,
                        (entry) => ImmutableArray.ToImmutableArray(entry.Value)
                    )
            );
        }
    }

    /// <summary>
    /// URL to documentation about this error
    /// </summary>
    public string? DocUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("doc_url");
        }
        init { this._rawData.Set("doc_url", value); }
    }

    /// <summary>
    /// Human-readable error message
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Details;
        _ = this.DocUrl;
        _ = this.Message;
    }

    public WebhookRotateSecretResponseError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookRotateSecretResponseError(
        WebhookRotateSecretResponseError webhookRotateSecretResponseError
    )
        : base(webhookRotateSecretResponseError) { }
#pragma warning restore CS8618

    public WebhookRotateSecretResponseError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookRotateSecretResponseError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookRotateSecretResponseErrorFromRaw.FromRawUnchecked"/>
    public static WebhookRotateSecretResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookRotateSecretResponseErrorFromRaw : IFromRawJson<WebhookRotateSecretResponseError>
{
    /// <inheritdoc/>
    public WebhookRotateSecretResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookRotateSecretResponseError.FromRawUnchecked(rawData);
}

/// <summary>
/// Request and response metadata
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WebhookRotateSecretResponseMeta,
        WebhookRotateSecretResponseMetaFromRaw
    >)
)]
public sealed record class WebhookRotateSecretResponseMeta : JsonModel
{
    /// <summary>
    /// Unique identifier for this request (for tracing and support)
    /// </summary>
    public string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("request_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("request_id", value);
        }
    }

    /// <summary>
    /// Server timestamp when the response was generated
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

    /// <summary>
    /// API version used for this request
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RequestID;
        _ = this.Timestamp;
        _ = this.Version;
    }

    public WebhookRotateSecretResponseMeta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookRotateSecretResponseMeta(
        WebhookRotateSecretResponseMeta webhookRotateSecretResponseMeta
    )
        : base(webhookRotateSecretResponseMeta) { }
#pragma warning restore CS8618

    public WebhookRotateSecretResponseMeta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookRotateSecretResponseMeta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookRotateSecretResponseMetaFromRaw.FromRawUnchecked"/>
    public static WebhookRotateSecretResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookRotateSecretResponseMetaFromRaw : IFromRawJson<WebhookRotateSecretResponseMeta>
{
    /// <inheritdoc/>
    public WebhookRotateSecretResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookRotateSecretResponseMeta.FromRawUnchecked(rawData);
}
