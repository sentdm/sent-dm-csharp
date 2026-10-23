using System;
using Sentdm.Core;
using Sentdm.Services.Calls;

namespace Sentdm.Services;

/// <inheritdoc/>
public sealed class CallService : ICallService
{
    readonly Lazy<ICallServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICallServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public ICallService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CallService(this._client.WithOptions(modifier));
    }

    public CallService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CallServiceWithRawResponse(client.WithRawResponse));
        _participants = new(() => new ParticipantService(client));
    }

    readonly Lazy<IParticipantService> _participants;
    public IParticipantService Participants
    {
        get { return _participants.Value; }
    }
}

/// <inheritdoc/>
public sealed class CallServiceWithRawResponse : ICallServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICallServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CallServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CallServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;

        _participants = new(() => new ParticipantServiceWithRawResponse(client));
    }

    readonly Lazy<IParticipantServiceWithRawResponse> _participants;
    public IParticipantServiceWithRawResponse Participants
    {
        get { return _participants.Value; }
    }
}
