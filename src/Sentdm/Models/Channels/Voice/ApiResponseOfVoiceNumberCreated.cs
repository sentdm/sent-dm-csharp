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
[JsonConverter(
    typeof(JsonModelConverter<
        ApiResponseOfVoiceNumberCreated,
        ApiResponseOfVoiceNumberCreatedFromRaw
    >)
)]
public sealed record class ApiResponseOfVoiceNumberCreated : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public VoiceNumberCreated? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceNumberCreated>("data");
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

    public ApiResponseOfVoiceNumberCreated() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfVoiceNumberCreated(
        ApiResponseOfVoiceNumberCreated apiResponseOfVoiceNumberCreated
    )
        : base(apiResponseOfVoiceNumberCreated) { }
#pragma warning restore CS8618

    public ApiResponseOfVoiceNumberCreated(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfVoiceNumberCreated(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfVoiceNumberCreatedFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfVoiceNumberCreated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfVoiceNumberCreatedFromRaw : IFromRawJson<ApiResponseOfVoiceNumberCreated>
{
    /// <inheritdoc/>
    public ApiResponseOfVoiceNumberCreated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfVoiceNumberCreated.FromRawUnchecked(rawData);
}
