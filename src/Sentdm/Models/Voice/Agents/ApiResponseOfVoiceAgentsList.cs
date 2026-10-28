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
    typeof(JsonModelConverter<ApiResponseOfVoiceAgentsList, ApiResponseOfVoiceAgentsListFromRaw>)
)]
public sealed record class ApiResponseOfVoiceAgentsList : JsonModel
{
    /// <summary>
    /// A page of the account's agents. The agent itself is VoiceAgentResponse, shared
    /// with the admin API.
    /// </summary>
    public VoiceAgentsList? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceAgentsList>("data");
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

    public ApiResponseOfVoiceAgentsList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfVoiceAgentsList(ApiResponseOfVoiceAgentsList apiResponseOfVoiceAgentsList)
        : base(apiResponseOfVoiceAgentsList) { }
#pragma warning restore CS8618

    public ApiResponseOfVoiceAgentsList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfVoiceAgentsList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfVoiceAgentsListFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfVoiceAgentsList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfVoiceAgentsListFromRaw : IFromRawJson<ApiResponseOfVoiceAgentsList>
{
    /// <inheritdoc/>
    public ApiResponseOfVoiceAgentsList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfVoiceAgentsList.FromRawUnchecked(rawData);
}
