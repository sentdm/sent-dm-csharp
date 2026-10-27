using System;
using Sentdm.Core;

namespace Sentdm.Services.Voice;

/// <inheritdoc/>
public sealed class AgentService : IAgentService
{
    readonly Lazy<IAgentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAgentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public IAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AgentService(this._client.WithOptions(modifier));
    }

    public AgentService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AgentServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class AgentServiceWithRawResponse : IAgentServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAgentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AgentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AgentServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;
    }
}
