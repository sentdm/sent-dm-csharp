using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Agents;

[JsonConverter(typeof(JsonModelConverter<VoiceAgentParty, VoiceAgentPartyFromRaw>))]
public sealed record class VoiceAgentParty : JsonModel
{
    public string? Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("kind");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("kind", value);
        }
    }

    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Kind;
        _ = this.Value;
    }

    public VoiceAgentParty() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceAgentParty(VoiceAgentParty voiceAgentParty)
        : base(voiceAgentParty) { }
#pragma warning restore CS8618

    public VoiceAgentParty(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceAgentParty(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceAgentPartyFromRaw.FromRawUnchecked"/>
    public static VoiceAgentParty FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceAgentPartyFromRaw : IFromRawJson<VoiceAgentParty>
{
    /// <inheritdoc/>
    public VoiceAgentParty FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceAgentParty.FromRawUnchecked(rawData);
}
