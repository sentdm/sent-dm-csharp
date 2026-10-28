using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Agents;

/// <summary>
/// Creates an agent that answers phone calls through the Sent Voice Gateway. `session_type`
/// says whether Sent carries the call as text (the caller's speech recognised for
/// the agent, the agent's text spoken) or as audio. With `websocket_url` the gateway
/// dials your agent for each call and signs the handshake with the `signing_secret`
/// this response returns; without it, your agent dials in with your API key and
/// this agent's `id`.
///
/// <para>`tools`, `transfer_targets`, `fallback` and `limits` say what the agent
/// may do on a call. Voices and languages for text sessions come from `GET /v3/voice/voices`.
/// Calls reach the agent once a number is bound to it on `/v3/channels/voice`.</para>
///
/// <para>`signing_secret` is shown here and on `POST /v3/voice/agents/{id}/rotate-secret`
/// only; store it now. With `sandbox: true` the request is validated and the agent
/// reported with `202`; nothing is written.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AgentCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Audio sessions only: the sound format.
    /// </summary>
    public VoiceAgentAudioSpec? Audio
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<VoiceAgentAudioSpec>("audio");
        }
        init { this._rawBodyData.Set("audio", value); }
    }

    /// <summary>
    /// Who takes the call when the agent cannot: a phone number (kind: number). Omit
    /// it and such a call hangs up.
    /// </summary>
    public VoiceAgentPartySpec? Fallback
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<VoiceAgentPartySpec>("fallback");
        }
        init { this._rawBodyData.Set("fallback", value); }
    }

    /// <summary>
    /// Text sessions only: what the caller hears as soon as the call is answered,
    /// before the agent's first turn. 1 to 4,096 characters. Omit it and the agent
    /// speaks first.
    /// </summary>
    public string? Greeting
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("greeting");
        }
        init { this._rawBodyData.Set("greeting", value); }
    }

    public VoiceAgentLimitsSpec? Limits
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<VoiceAgentLimitsSpec>("limits");
        }
        init { this._rawBodyData.Set("limits", value); }
    }

    /// <summary>
    /// A name for your own reference, 1 to 100 characters.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Sandbox flag - when true, the operation is simulated without side effects
    /// Useful for testing integrations without actual execution
    /// </summary>
    public bool? Sandbox
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("sandbox");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sandbox", value);
        }
    }

    /// <summary>
    /// text: Sent turns the caller's speech into text and the agent's text into speech,
    /// so the agent exchanges text frames. audio: the agent receives and sends the
    /// sound itself.
    /// </summary>
    public string? SessionType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("session_type");
        }
        init { this._rawBodyData.Set("session_type", value); }
    }

    /// <summary>
    /// Text sessions only: how the caller is spoken to and listened to.
    /// </summary>
    public VoiceAgentSpeechSpec? Speech
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<VoiceAgentSpeechSpec>("speech");
        }
        init { this._rawBodyData.Set("speech", value); }
    }

    /// <summary>
    /// What the agent may do to the call: any of transfer, hangup, send_dtmf and
    /// hold. Default ["hangup"]. transfer needs at least one transfer_targets entry.
    /// </summary>
    public IReadOnlyList<string>? Tools
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("tools");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public VoiceAgentTranscriptsSpec? Transcripts
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<VoiceAgentTranscriptsSpec>("transcripts");
        }
        init { this._rawBodyData.Set("transcripts", value); }
    }

    /// <summary>
    /// Where the agent may transfer a call to, up to 20 parties: a phone number (kind:
    /// number, E.164), one of your app users (kind: user, the identity) or another
    /// of your agents (kind: agent, its id). The agent can only transfer to a party
    /// listed here.
    /// </summary>
    public IReadOnlyList<VoiceAgentPartySpec>? TransferTargets
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<VoiceAgentPartySpec>>(
                "transfer_targets"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<VoiceAgentPartySpec>?>(
                "transfer_targets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Where the gateway connects to the agent for each call: an absolute wss://
    /// URL on a public host, at most 2,048 characters. The handshake is signed with
    /// the agent's signing_secret. Leave it out and the agent dials in instead, connecting
    /// to the gateway with your API key.
    /// </summary>
    public string? WebsocketUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("websocket_url");
        }
        init { this._rawBodyData.Set("websocket_url", value); }
    }

    public string? IdempotencyKey
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("Idempotency-Key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
        }
    }

    public string? XProfileID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("x-profile-id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("x-profile-id", value);
        }
    }

    public AgentCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentCreateParams(AgentCreateParams agentCreateParams)
        : base(agentCreateParams)
    {
        this._rawBodyData = new(agentCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AgentCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AgentCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(AgentCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/voice/agents")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
