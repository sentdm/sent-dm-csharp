using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Channels;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ApiResponseOfChannelsState, ApiResponseOfChannelsStateFromRaw>)
)]
public sealed record class ApiResponseOfChannelsState : JsonModel
{
    /// <summary>
    /// The channels a profile sends on. SMS is a list because a profile can send
    /// in several markets; WhatsApp and RCS are single, because a profile has one
    /// business account and one agent.
    /// </summary>
    public ChannelsState? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChannelsState>("data");
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

    public ApiResponseOfChannelsState() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfChannelsState(ApiResponseOfChannelsState apiResponseOfChannelsState)
        : base(apiResponseOfChannelsState) { }
#pragma warning restore CS8618

    public ApiResponseOfChannelsState(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfChannelsState(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfChannelsStateFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfChannelsState FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfChannelsStateFromRaw : IFromRawJson<ApiResponseOfChannelsState>
{
    /// <inheritdoc/>
    public ApiResponseOfChannelsState FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfChannelsState.FromRawUnchecked(rawData);
}
