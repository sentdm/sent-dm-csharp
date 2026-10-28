using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Agents;

[JsonConverter(typeof(JsonModelConverter<VoiceAgentAudioSpec, VoiceAgentAudioSpecFromRaw>))]
public sealed record class VoiceAgentAudioSpec : JsonModel
{
    /// <summary>
    /// Samples per second of the audio exchanged: 8000, 16000 or 24000. Default 16000.
    /// </summary>
    public int? SampleRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("sample_rate");
        }
        init { this._rawData.Set("sample_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SampleRate;
    }

    public VoiceAgentAudioSpec() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceAgentAudioSpec(VoiceAgentAudioSpec voiceAgentAudioSpec)
        : base(voiceAgentAudioSpec) { }
#pragma warning restore CS8618

    public VoiceAgentAudioSpec(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceAgentAudioSpec(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceAgentAudioSpecFromRaw.FromRawUnchecked"/>
    public static VoiceAgentAudioSpec FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceAgentAudioSpecFromRaw : IFromRawJson<VoiceAgentAudioSpec>
{
    /// <inheritdoc/>
    public VoiceAgentAudioSpec FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceAgentAudioSpec.FromRawUnchecked(rawData);
}
