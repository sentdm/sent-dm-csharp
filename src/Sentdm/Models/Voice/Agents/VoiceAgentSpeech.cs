using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Agents;

[JsonConverter(typeof(JsonModelConverter<VoiceAgentSpeech, VoiceAgentSpeechFromRaw>))]
public sealed record class VoiceAgentSpeech : JsonModel
{
    public string? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("language", value);
        }
    }

    public string? Setting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("setting");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("setting", value);
        }
    }

    public string? Voice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("voice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("voice", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Language;
        _ = this.Setting;
        _ = this.Voice;
    }

    public VoiceAgentSpeech() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceAgentSpeech(VoiceAgentSpeech voiceAgentSpeech)
        : base(voiceAgentSpeech) { }
#pragma warning restore CS8618

    public VoiceAgentSpeech(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceAgentSpeech(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceAgentSpeechFromRaw.FromRawUnchecked"/>
    public static VoiceAgentSpeech FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceAgentSpeechFromRaw : IFromRawJson<VoiceAgentSpeech>
{
    /// <inheritdoc/>
    public VoiceAgentSpeech FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceAgentSpeech.FromRawUnchecked(rawData);
}
