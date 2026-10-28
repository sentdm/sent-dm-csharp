using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Agents;

[JsonConverter(typeof(JsonModelConverter<VoiceAgentSpeechSpec, VoiceAgentSpeechSpecFromRaw>))]
public sealed record class VoiceAgentSpeechSpec : JsonModel
{
    /// <summary>
    /// The language spoken and listened for, a BCP 47 tag from GET /v3/voice/voices.
    /// Default en-US.
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init { this._rawData.Set("language", value); }
    }

    /// <summary>
    /// standard, Sent's speech. Other settings are not available yet.
    /// </summary>
    public string? Setting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("setting");
        }
        init { this._rawData.Set("setting", value); }
    }

    /// <summary>
    /// A voice name from GET /v3/voice/voices. Default: the catalogue's default voice.
    /// </summary>
    public string? Voice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("voice");
        }
        init { this._rawData.Set("voice", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Language;
        _ = this.Setting;
        _ = this.Voice;
    }

    public VoiceAgentSpeechSpec() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceAgentSpeechSpec(VoiceAgentSpeechSpec voiceAgentSpeechSpec)
        : base(voiceAgentSpeechSpec) { }
#pragma warning restore CS8618

    public VoiceAgentSpeechSpec(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceAgentSpeechSpec(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceAgentSpeechSpecFromRaw.FromRawUnchecked"/>
    public static VoiceAgentSpeechSpec FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceAgentSpeechSpecFromRaw : IFromRawJson<VoiceAgentSpeechSpec>
{
    /// <inheritdoc/>
    public VoiceAgentSpeechSpec FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VoiceAgentSpeechSpec.FromRawUnchecked(rawData);
}
