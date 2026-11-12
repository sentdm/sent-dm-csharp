using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Channels;
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
        _sms = new(() => new Channels::SmsService(client));
        _rcs = new(() => new Channels::RcService(client));
        _whatsapp = new(() => new Channels::WhatsappService(client));
        _voice = new(() => new Channels::VoiceService(client));
    }

    readonly Lazy<Channels::ISmsService> _sms;
    public Channels::ISmsService Sms
    {
        get { return _sms.Value; }
    }

    readonly Lazy<Channels::IRcService> _rcs;
    public Channels::IRcService Rcs
    {
        get { return _rcs.Value; }
    }

    readonly Lazy<Channels::IWhatsappService> _whatsapp;
    public Channels::IWhatsappService Whatsapp
    {
        get { return _whatsapp.Value; }
    }

    readonly Lazy<Channels::IVoiceService> _voice;
    public Channels::IVoiceService Voice
    {
        get { return _voice.Value; }
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfChannelsState> List(
        ChannelListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
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

        _sms = new(() => new Channels::SmsServiceWithRawResponse(client));
        _rcs = new(() => new Channels::RcServiceWithRawResponse(client));
        _whatsapp = new(() => new Channels::WhatsappServiceWithRawResponse(client));
        _voice = new(() => new Channels::VoiceServiceWithRawResponse(client));
    }

    readonly Lazy<Channels::ISmsServiceWithRawResponse> _sms;
    public Channels::ISmsServiceWithRawResponse Sms
    {
        get { return _sms.Value; }
    }

    readonly Lazy<Channels::IRcServiceWithRawResponse> _rcs;
    public Channels::IRcServiceWithRawResponse Rcs
    {
        get { return _rcs.Value; }
    }

    readonly Lazy<Channels::IWhatsappServiceWithRawResponse> _whatsapp;
    public Channels::IWhatsappServiceWithRawResponse Whatsapp
    {
        get { return _whatsapp.Value; }
    }

    readonly Lazy<Channels::IVoiceServiceWithRawResponse> _voice;
    public Channels::IVoiceServiceWithRawResponse Voice
    {
        get { return _voice.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfChannelsState>> List(
        ChannelListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ChannelListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfChannelsState = await response
                    .Deserialize<ApiResponseOfChannelsState>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfChannelsState.Validate();
                }
                return apiResponseOfChannelsState;
            }
        );
    }
}
