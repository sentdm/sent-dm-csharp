using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Agents;

[JsonConverter(typeof(JsonModelConverter<VoiceAgentTranscripts, VoiceAgentTranscriptsFromRaw>))]
public sealed record class VoiceAgentTranscripts : JsonModel
{
    public int? RetentionDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("retention_days");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("retention_days", value);
        }
    }

    public bool? Store
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("store");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("store", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RetentionDays;
        _ = this.Store;
    }

    public VoiceAgentTranscripts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceAgentTranscripts(VoiceAgentTranscripts voiceAgentTranscripts)
        : base(voiceAgentTranscripts) { }
#pragma warning restore CS8618

    public VoiceAgentTranscripts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceAgentTranscripts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceAgentTranscriptsFromRaw.FromRawUnchecked"/>
    public static VoiceAgentTranscripts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceAgentTranscriptsFromRaw : IFromRawJson<VoiceAgentTranscripts>
{
    /// <inheritdoc/>
    public VoiceAgentTranscripts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VoiceAgentTranscripts.FromRawUnchecked(rawData);
}
