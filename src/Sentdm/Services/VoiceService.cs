using System;
using Sentdm.Core;
using Voice = Sentdm.Services.Voice;

namespace Sentdm.Services;

/// <inheritdoc/>
public sealed class VoiceService : IVoiceService
{
    readonly Lazy<IVoiceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVoiceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public IVoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VoiceService(this._client.WithOptions(modifier));
    }

    public VoiceService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new VoiceServiceWithRawResponse(client.WithRawResponse));
        _calls = new(() => new Voice::CallService(client));
        _tokens = new(() => new Voice::TokenService(client));
        _agents = new(() => new Voice::AgentService(client));
        _voices = new(() => new Voice::VoiceService(client));
    }

    readonly Lazy<Voice::ICallService> _calls;
    public Voice::ICallService Calls
    {
        get { return _calls.Value; }
    }

    readonly Lazy<Voice::ITokenService> _tokens;
    public Voice::ITokenService Tokens
    {
        get { return _tokens.Value; }
    }

    readonly Lazy<Voice::IAgentService> _agents;
    public Voice::IAgentService Agents
    {
        get { return _agents.Value; }
    }

    readonly Lazy<Voice::IVoiceService> _voices;
    public Voice::IVoiceService Voices
    {
        get { return _voices.Value; }
    }
}

/// <inheritdoc/>
public sealed class VoiceServiceWithRawResponse : IVoiceServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVoiceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VoiceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VoiceServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;

        _calls = new(() => new Voice::CallServiceWithRawResponse(client));
        _tokens = new(() => new Voice::TokenServiceWithRawResponse(client));
        _agents = new(() => new Voice::AgentServiceWithRawResponse(client));
        _voices = new(() => new Voice::VoiceServiceWithRawResponse(client));
    }

    readonly Lazy<Voice::ICallServiceWithRawResponse> _calls;
    public Voice::ICallServiceWithRawResponse Calls
    {
        get { return _calls.Value; }
    }

    readonly Lazy<Voice::ITokenServiceWithRawResponse> _tokens;
    public Voice::ITokenServiceWithRawResponse Tokens
    {
        get { return _tokens.Value; }
    }

    readonly Lazy<Voice::IAgentServiceWithRawResponse> _agents;
    public Voice::IAgentServiceWithRawResponse Agents
    {
        get { return _agents.Value; }
    }

    readonly Lazy<Voice::IVoiceServiceWithRawResponse> _voices;
    public Voice::IVoiceServiceWithRawResponse Voices
    {
        get { return _voices.Value; }
    }
}
