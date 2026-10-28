using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Agents;

[JsonConverter(
    typeof(JsonModelConverter<VoiceAgentTranscriptsSpec, VoiceAgentTranscriptsSpecFromRaw>)
)]
public sealed record class VoiceAgentTranscriptsSpec : JsonModel
{
    /// <summary>
    /// How long a stored transcript is kept, 1 to 365 days. Default 30.
    /// </summary>
    public int? RetentionDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("retention_days");
        }
        init { this._rawData.Set("retention_days", value); }
    }

    /// <summary>
    /// Whether Sent keeps the call's transcript. Default false. Stored now, applied
    /// when transcripts land.
    /// </summary>
    public bool? Store
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("store");
        }
        init { this._rawData.Set("store", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RetentionDays;
        _ = this.Store;
    }

    public VoiceAgentTranscriptsSpec() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceAgentTranscriptsSpec(VoiceAgentTranscriptsSpec voiceAgentTranscriptsSpec)
        : base(voiceAgentTranscriptsSpec) { }
#pragma warning restore CS8618

    public VoiceAgentTranscriptsSpec(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceAgentTranscriptsSpec(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceAgentTranscriptsSpecFromRaw.FromRawUnchecked"/>
    public static VoiceAgentTranscriptsSpec FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceAgentTranscriptsSpecFromRaw : IFromRawJson<VoiceAgentTranscriptsSpec>
{
    /// <inheritdoc/>
    public VoiceAgentTranscriptsSpec FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VoiceAgentTranscriptsSpec.FromRawUnchecked(rawData);
}
