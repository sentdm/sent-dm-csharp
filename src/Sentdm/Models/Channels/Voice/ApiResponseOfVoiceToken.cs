using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Channels.Voice;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ApiResponseOfVoiceToken, ApiResponseOfVoiceTokenFromRaw>))]
public sealed record class ApiResponseOfVoiceToken : JsonModel
{
    /// <summary>
    /// A short-lived token your app passes to the voice client SDK to register
    /// </summary>
    public VoiceToken? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceToken>("data");
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

    public ApiResponseOfVoiceToken() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfVoiceToken(ApiResponseOfVoiceToken apiResponseOfVoiceToken)
        : base(apiResponseOfVoiceToken) { }
#pragma warning restore CS8618

    public ApiResponseOfVoiceToken(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfVoiceToken(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfVoiceTokenFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfVoiceToken FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfVoiceTokenFromRaw : IFromRawJson<ApiResponseOfVoiceToken>
{
    /// <inheritdoc/>
    public ApiResponseOfVoiceToken FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfVoiceToken.FromRawUnchecked(rawData);
}
