using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Voice;

/// <summary>
/// The test question exactly as it was sent
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<VoiceCallbackTestRequestInfo, VoiceCallbackTestRequestInfoFromRaw>)
)]
public sealed record class VoiceCallbackTestRequestInfo : JsonModel
{
    /// <summary>
    /// The request body byte for byte. This is what the signature covers.
    /// </summary>
    public string? Body
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("body");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("body", value);
        }
    }

    /// <summary>
    /// Every header Sent added, the signature included, so you can compare against
    /// what your endpoint verified. The signing secret itself is never included.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The callback URL that was called
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Body;
        _ = this.Headers;
        _ = this.Url;
    }

    public VoiceCallbackTestRequestInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceCallbackTestRequestInfo(VoiceCallbackTestRequestInfo voiceCallbackTestRequestInfo)
        : base(voiceCallbackTestRequestInfo) { }
#pragma warning restore CS8618

    public VoiceCallbackTestRequestInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceCallbackTestRequestInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceCallbackTestRequestInfoFromRaw.FromRawUnchecked"/>
    public static VoiceCallbackTestRequestInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceCallbackTestRequestInfoFromRaw : IFromRawJson<VoiceCallbackTestRequestInfo>
{
    /// <inheritdoc/>
    public VoiceCallbackTestRequestInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VoiceCallbackTestRequestInfo.FromRawUnchecked(rawData);
}
