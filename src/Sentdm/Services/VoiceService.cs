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
}
