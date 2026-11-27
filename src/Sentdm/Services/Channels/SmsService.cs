using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Channels.Markets;
using Sentdm.Models.Channels.Sms;
using Sentdm.Services.Channels.Sms;

namespace Sentdm.Services.Channels;

/// <inheritdoc/>
public sealed class SmsService : ISmsService
{
    readonly Lazy<ISmsServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISmsServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public ISmsService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SmsService(this._client.WithOptions(modifier));
    }

    public SmsService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SmsServiceWithRawResponse(client.WithRawResponse));
        _tenDlc = new(() => new TenDlcService(client));
    }

    readonly Lazy<ITenDlcService> _tenDlc;
    public ITenDlcService TenDlc
    {
        get { return _tenDlc.Value; }
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfChannelMarket> Create(
        SmsCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SmsServiceWithRawResponse : ISmsServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISmsServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SmsServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SmsServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;

        _tenDlc = new(() => new TenDlcServiceWithRawResponse(client));
    }

    readonly Lazy<ITenDlcServiceWithRawResponse> _tenDlc;
    public ITenDlcServiceWithRawResponse TenDlc
    {
        get { return _tenDlc.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfChannelMarket>> Create(
        SmsCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SmsCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfChannelMarket = await response
                    .Deserialize<ApiResponseOfChannelMarket>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfChannelMarket.Validate();
                }
                return apiResponseOfChannelMarket;
            }
        );
    }
}
