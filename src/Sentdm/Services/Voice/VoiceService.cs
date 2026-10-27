using System;
using Sentdm.Core;

namespace Sentdm.Services.Voice;

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
    }
}
