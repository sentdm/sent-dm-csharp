using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Agents;

[JsonConverter(typeof(JsonModelConverter<VoiceAgentPartySpec, VoiceAgentPartySpecFromRaw>))]
public sealed record class VoiceAgentPartySpec : JsonModel
{
    /// <summary>
    /// number, user or agent.
    /// </summary>
    public string? Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("kind");
        }
        init { this._rawData.Set("kind", value); }
    }

    /// <summary>
    /// The E.164 number, the app user's identity, or the agent id (agent_…).
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Kind;
        _ = this.Value;
    }

    public VoiceAgentPartySpec() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceAgentPartySpec(VoiceAgentPartySpec voiceAgentPartySpec)
        : base(voiceAgentPartySpec) { }
#pragma warning restore CS8618

    public VoiceAgentPartySpec(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceAgentPartySpec(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceAgentPartySpecFromRaw.FromRawUnchecked"/>
    public static VoiceAgentPartySpec FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceAgentPartySpecFromRaw : IFromRawJson<VoiceAgentPartySpec>
{
    /// <inheritdoc/>
    public VoiceAgentPartySpec FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceAgentPartySpec.FromRawUnchecked(rawData);
}
