using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Agents;

[JsonConverter(typeof(JsonModelConverter<VoiceAgentLimitsSpec, VoiceAgentLimitsSpecFromRaw>))]
public sealed record class VoiceAgentLimitsSpec : JsonModel
{
    /// <summary>
    /// ISO 3166-1 alpha-2 codes of the countries the agent may call or transfer to.
    /// Omit it to allow every country. Stored now, applied when the agent places calls.
    /// </summary>
    public IReadOnlyList<string>? AllowedCountries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("allowed_countries");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "allowed_countries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The longest a call may last, 60 to 14,400 seconds. Default 3,600.
    /// </summary>
    public int? MaxCallSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("max_call_seconds");
        }
        init { this._rawData.Set("max_call_seconds", value); }
    }

    /// <summary>
    /// How many calls the agent may have going at once, from 1. Default 10.
    /// </summary>
    public int? MaxConcurrentCalls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("max_concurrent_calls");
        }
        init { this._rawData.Set("max_concurrent_calls", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowedCountries;
        _ = this.MaxCallSeconds;
        _ = this.MaxConcurrentCalls;
    }

    public VoiceAgentLimitsSpec() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceAgentLimitsSpec(VoiceAgentLimitsSpec voiceAgentLimitsSpec)
        : base(voiceAgentLimitsSpec) { }
#pragma warning restore CS8618

    public VoiceAgentLimitsSpec(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceAgentLimitsSpec(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceAgentLimitsSpecFromRaw.FromRawUnchecked"/>
    public static VoiceAgentLimitsSpec FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceAgentLimitsSpecFromRaw : IFromRawJson<VoiceAgentLimitsSpec>
{
    /// <inheritdoc/>
    public VoiceAgentLimitsSpec FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VoiceAgentLimitsSpec.FromRawUnchecked(rawData);
}
