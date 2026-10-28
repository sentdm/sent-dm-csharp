using System;
using Sentdm.Core;
using Sentdm.Services.Voice;

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
        _calls = new(() => new CallService(client));
        _tokens = new(() => new TokenService(client));
        _agents = new(() => new AgentService(client));
        _catalogue = new(() => new CatalogueService(client));
    }

    readonly Lazy<ICallService> _calls;
    public ICallService Calls
    {
        get { return _calls.Value; }
    }

    readonly Lazy<ITokenService> _tokens;
    public ITokenService Tokens
    {
        get { return _tokens.Value; }
    }

    readonly Lazy<IAgentService> _agents;
    public IAgentService Agents
    {
        get { return _agents.Value; }
    }

    readonly Lazy<ICatalogueService> _catalogue;
    public ICatalogueService Catalogue
    {
        get { return _catalogue.Value; }
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

        _calls = new(() => new CallServiceWithRawResponse(client));
        _tokens = new(() => new TokenServiceWithRawResponse(client));
        _agents = new(() => new AgentServiceWithRawResponse(client));
        _catalogue = new(() => new CatalogueServiceWithRawResponse(client));
    }

    readonly Lazy<ICallServiceWithRawResponse> _calls;
    public ICallServiceWithRawResponse Calls
    {
        get { return _calls.Value; }
    }

    readonly Lazy<ITokenServiceWithRawResponse> _tokens;
    public ITokenServiceWithRawResponse Tokens
    {
        get { return _tokens.Value; }
    }

    readonly Lazy<IAgentServiceWithRawResponse> _agents;
    public IAgentServiceWithRawResponse Agents
    {
        get { return _agents.Value; }
    }

    readonly Lazy<ICatalogueServiceWithRawResponse> _catalogue;
    public ICatalogueServiceWithRawResponse Catalogue
    {
        get { return _catalogue.Value; }
    }
}
