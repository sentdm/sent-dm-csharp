using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Voice.Agents;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ApiResponseOfVoiceAgentSecret, ApiResponseOfVoiceAgentSecretFromRaw>)
)]
public sealed record class ApiResponseOfVoiceAgentSecret : JsonModel
{
    /// <summary>
    /// A freshly rotated signing secret.
    /// </summary>
    public VoiceAgentSecret? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceAgentSecret>("data");
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

    public ApiResponseOfVoiceAgentSecret() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfVoiceAgentSecret(
        ApiResponseOfVoiceAgentSecret apiResponseOfVoiceAgentSecret
    )
        : base(apiResponseOfVoiceAgentSecret) { }
#pragma warning restore CS8618

    public ApiResponseOfVoiceAgentSecret(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfVoiceAgentSecret(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfVoiceAgentSecretFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfVoiceAgentSecret FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfVoiceAgentSecretFromRaw : IFromRawJson<ApiResponseOfVoiceAgentSecret>
{
    /// <inheritdoc/>
    public ApiResponseOfVoiceAgentSecret FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfVoiceAgentSecret.FromRawUnchecked(rawData);
}
