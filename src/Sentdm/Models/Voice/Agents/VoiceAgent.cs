using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Agents;

/// <summary>
/// A voice agent as stored: what was written with every default filled in, plus
/// the signing secret the one time it is shown (on create, and on rotate). The one
/// shape every read of an agent answers with, on /v3/voice/agents and on the admin
/// API the dashboard uses, so the two cannot drift.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceAgent, VoiceAgentFromRaw>))]
public sealed record class VoiceAgent : JsonModel
{
    /// <summary>
    /// The agent's id, agent_ and a UUID. It is also what the agent connects to the
    /// gateway as.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Audio sessions: the sample rate in use.
    /// </summary>
    public VoiceAgentAudio? Audio
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceAgentAudio>("audio");
        }
        init { this._rawData.Set("audio", value); }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public VoiceAgentParty? Fallback
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceAgentParty>("fallback");
        }
        init { this._rawData.Set("fallback", value); }
    }

    public string? Greeting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("greeting");
        }
        init { this._rawData.Set("greeting", value); }
    }

    public VoiceAgentLimits? Limits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceAgentLimits>("limits");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("limits", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// text or audio.
    /// </summary>
    public string? SessionType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("session_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("session_type", value);
        }
    }

    /// <summary>
    /// The whsec_ secret the gateway signs its handshake to websocket_url with. Present
    /// on create and after a rotate-secret; absent on every other read. Store it now.
    /// </summary>
    public string? SigningSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("signing_secret");
        }
        init { this._rawData.Set("signing_secret", value); }
    }

    /// <summary>
    /// Text sessions: the speech setting, voice and language in use.
    /// </summary>
    public VoiceAgentSpeech? Speech
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceAgentSpeech>("speech");
        }
        init { this._rawData.Set("speech", value); }
    }

    public IReadOnlyList<string>? Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tools");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public VoiceAgentTranscripts? Transcripts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceAgentTranscripts>("transcripts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transcripts", value);
        }
    }

    public IReadOnlyList<VoiceAgentParty>? TransferTargets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<VoiceAgentParty>>(
                "transfer_targets"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<VoiceAgentParty>?>(
                "transfer_targets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Where the gateway dials the agent; null when the agent dials in with your
    /// API key.
    /// </summary>
    public string? WebsocketUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("websocket_url");
        }
        init { this._rawData.Set("websocket_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Audio?.Validate();
        _ = this.CreatedAt;
        this.Fallback?.Validate();
        _ = this.Greeting;
        this.Limits?.Validate();
        _ = this.Name;
        _ = this.SessionType;
        _ = this.SigningSecret;
        this.Speech?.Validate();
        _ = this.Tools;
        this.Transcripts?.Validate();
        foreach (var item in this.TransferTargets ?? [])
        {
            item.Validate();
        }
        _ = this.UpdatedAt;
        _ = this.WebsocketUrl;
    }

    public VoiceAgent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceAgent(VoiceAgent voiceAgent)
        : base(voiceAgent) { }
#pragma warning restore CS8618

    public VoiceAgent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceAgent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceAgentFromRaw.FromRawUnchecked"/>
    public static VoiceAgent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceAgentFromRaw : IFromRawJson<VoiceAgent>
{
    /// <inheritdoc/>
    public VoiceAgent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceAgent.FromRawUnchecked(rawData);
}
