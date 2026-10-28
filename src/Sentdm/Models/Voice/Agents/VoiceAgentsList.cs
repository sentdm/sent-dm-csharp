using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Voice.Agents;

/// <summary>
/// A page of the account's agents. The agent itself is VoiceAgentResponse, shared
/// with the admin API.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceAgentsList, VoiceAgentsListFromRaw>))]
public sealed record class VoiceAgentsList : JsonModel
{
    public IReadOnlyList<VoiceAgent>? Agents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<VoiceAgent>>("agents");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<VoiceAgent>?>(
                "agents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata for list responses
    /// </summary>
    public PaginationMeta? Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>("pagination");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pagination", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Agents ?? [])
        {
            item.Validate();
        }
        this.Pagination?.Validate();
    }

    public VoiceAgentsList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceAgentsList(VoiceAgentsList voiceAgentsList)
        : base(voiceAgentsList) { }
#pragma warning restore CS8618

    public VoiceAgentsList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceAgentsList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceAgentsListFromRaw.FromRawUnchecked"/>
    public static VoiceAgentsList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceAgentsListFromRaw : IFromRawJson<VoiceAgentsList>
{
    /// <inheritdoc/>
    public VoiceAgentsList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceAgentsList.FromRawUnchecked(rawData);
}
