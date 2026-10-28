using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Agents;

[JsonConverter(typeof(JsonModelConverter<VoiceAgentAudio, VoiceAgentAudioFromRaw>))]
public sealed record class VoiceAgentAudio : JsonModel
{
    public int? SampleRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("sample_rate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sample_rate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SampleRate;
    }

    public VoiceAgentAudio() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceAgentAudio(VoiceAgentAudio voiceAgentAudio)
        : base(voiceAgentAudio) { }
#pragma warning restore CS8618

    public VoiceAgentAudio(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceAgentAudio(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceAgentAudioFromRaw.FromRawUnchecked"/>
    public static VoiceAgentAudio FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceAgentAudioFromRaw : IFromRawJson<VoiceAgentAudio>
{
    /// <inheritdoc/>
    public VoiceAgentAudio FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceAgentAudio.FromRawUnchecked(rawData);
}
