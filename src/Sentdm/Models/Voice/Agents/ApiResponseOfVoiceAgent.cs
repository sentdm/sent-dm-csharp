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
[JsonConverter(typeof(JsonModelConverter<ApiResponseOfVoiceAgent, ApiResponseOfVoiceAgentFromRaw>))]
public sealed record class ApiResponseOfVoiceAgent : JsonModel
{
    /// <summary>
    /// A voice agent as stored: what was written with every default filled in, plus
    /// the signing secret the one time it is shown (on create, and on rotate). The
    /// one shape every read of an agent answers with, on /v3/voice/agents and on
    /// the admin API the dashboard uses, so the two cannot drift.
    /// </summary>
    public VoiceAgent? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceAgent>("data");
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

    public ApiResponseOfVoiceAgent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfVoiceAgent(ApiResponseOfVoiceAgent apiResponseOfVoiceAgent)
        : base(apiResponseOfVoiceAgent) { }
#pragma warning restore CS8618

    public ApiResponseOfVoiceAgent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfVoiceAgent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfVoiceAgentFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfVoiceAgent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfVoiceAgentFromRaw : IFromRawJson<ApiResponseOfVoiceAgent>
{
    /// <inheritdoc/>
    public ApiResponseOfVoiceAgent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfVoiceAgent.FromRawUnchecked(rawData);
}
