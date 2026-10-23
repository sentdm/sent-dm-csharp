using System;
using Sentdm.Core;
using Channels = Sentdm.Services.Channels;

namespace Sentdm.Services;

/// <inheritdoc/>
public sealed class ChannelService : IChannelService
{
    readonly Lazy<IChannelServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IChannelServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public IChannelService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChannelService(this._client.WithOptions(modifier));
    }

    public ChannelService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ChannelServiceWithRawResponse(client.WithRawResponse));
        _voice = new(() => new Channels::VoiceService(client));
    }

    readonly Lazy<Channels::IVoiceService> _voice;
    public Channels::IVoiceService Voice
    {
        get { return _voice.Value; }
    }
}

/// <inheritdoc/>
public sealed class ChannelServiceWithRawResponse : IChannelServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public IChannelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChannelServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ChannelServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;

        _voice = new(() => new Channels::VoiceServiceWithRawResponse(client));
    }

    readonly Lazy<Channels::IVoiceServiceWithRawResponse> _voice;
    public Channels::IVoiceServiceWithRawResponse Voice
    {
        get { return _voice.Value; }
    }
}
