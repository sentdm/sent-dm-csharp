using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Voice;

/// <summary>
/// What your endpoint answered
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<VoiceCallbackTestResponseInfo, VoiceCallbackTestResponseInfoFromRaw>)
)]
public sealed record class VoiceCallbackTestResponseInfo : JsonModel
{
    /// <summary>
    /// The start of the raw response body, capped at 2048 characters
    /// </summary>
    public string? Body
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("body");
        }
        init { this._rawData.Set("body", value); }
    }

    /// <summary>
    /// The HTTP status your endpoint returned
    /// </summary>
    public int? StatusCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("status_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status_code", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Body;
        _ = this.StatusCode;
    }

    public VoiceCallbackTestResponseInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceCallbackTestResponseInfo(
        VoiceCallbackTestResponseInfo voiceCallbackTestResponseInfo
    )
        : base(voiceCallbackTestResponseInfo) { }
#pragma warning restore CS8618

    public VoiceCallbackTestResponseInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceCallbackTestResponseInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceCallbackTestResponseInfoFromRaw.FromRawUnchecked"/>
    public static VoiceCallbackTestResponseInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceCallbackTestResponseInfoFromRaw : IFromRawJson<VoiceCallbackTestResponseInfo>
{
    /// <inheritdoc/>
    public VoiceCallbackTestResponseInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VoiceCallbackTestResponseInfo.FromRawUnchecked(rawData);
}
