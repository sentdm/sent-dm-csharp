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
/// Changes the fields you name and answers with the agent as stored, the same shape
/// `GET` returns.
///
/// <para>A key left out is left alone. A key sent as `null` clears an optional field
/// (`websocket_url` makes the agent dial in, `greeting` and `fallback` go, `speech`,
/// `audio`, `tools`, `limits` and `transcripts` return to their defaults). A key
/// sent with a value replaces that field whole: send the whole `limits` object, not
/// one of its keys. Changing `session_type` drops `speech`, `audio` and `greeting`
/// unless the body sends them, since the other type cannot carry them. The result
/// is checked like a new agent, and a body that changes nothing is `400`.</para>
///
/// <para>With `sandbox: true` nothing is written: the request is validated against
/// the stored agent and the agent is reported with `200` as it would read after
/// the change.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AgentUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Audio sessions: { sample_rate }; null restores the default.
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
    /// A new fallback party, or null for none.
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
    /// A new greeting, or null for none.
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

    /// <summary>
    /// The whole limits object; null restores the defaults.
    /// </summary>
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
    /// A new name, 1 to 100 characters.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
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
    /// text or audio. Changing it drops the settings the other type cannot have (speech,
    /// audio, greeting) unless the body sends them.
    /// </summary>
    public string? SessionType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("session_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("session_type", value);
        }
    }

    /// <summary>
    /// Text sessions: { setting, voice, language }, replaced whole; null restores
    /// the defaults.
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
    /// The whole list of tools; null restores the default.
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

    /// <summary>
    /// The whole transcripts object; null restores the defaults.
    /// </summary>
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
    /// The whole list of parties; null clears it.
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
    /// A new wss:// URL, or null for an agent that dials in.
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

    public AgentUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentUpdateParams(AgentUpdateParams agentUpdateParams)
        : base(agentUpdateParams)
    {
        this.ID = agentUpdateParams.ID;

        this._rawBodyData = new(agentUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AgentUpdateParams(
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
    AgentUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AgentUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
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

    public virtual bool Equals(AgentUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v3/voice/agents/{0}", this.ID)
        )
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
