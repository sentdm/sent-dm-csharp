using System;
using Sentdm.Core;

namespace Sentdm.Services.Calls;

/// <inheritdoc/>
public sealed class ParticipantService : IParticipantService
{
    readonly Lazy<IParticipantServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IParticipantServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public IParticipantService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ParticipantService(this._client.WithOptions(modifier));
    }

    public ParticipantService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ParticipantServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class ParticipantServiceWithRawResponse : IParticipantServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public IParticipantServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ParticipantServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ParticipantServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;
    }
}
