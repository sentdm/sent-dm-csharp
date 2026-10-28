using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Agents;

[JsonConverter(typeof(JsonModelConverter<VoiceAgentLimits, VoiceAgentLimitsFromRaw>))]
public sealed record class VoiceAgentLimits : JsonModel
{
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

    public int? MaxCallSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("max_call_seconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("max_call_seconds", value);
        }
    }

    public int? MaxConcurrentCalls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("max_concurrent_calls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("max_concurrent_calls", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowedCountries;
        _ = this.MaxCallSeconds;
        _ = this.MaxConcurrentCalls;
    }

    public VoiceAgentLimits() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceAgentLimits(VoiceAgentLimits voiceAgentLimits)
        : base(voiceAgentLimits) { }
#pragma warning restore CS8618

    public VoiceAgentLimits(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceAgentLimits(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceAgentLimitsFromRaw.FromRawUnchecked"/>
    public static VoiceAgentLimits FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceAgentLimitsFromRaw : IFromRawJson<VoiceAgentLimits>
{
    /// <inheritdoc/>
    public VoiceAgentLimits FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceAgentLimits.FromRawUnchecked(rawData);
}
