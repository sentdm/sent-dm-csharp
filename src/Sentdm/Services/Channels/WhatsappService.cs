using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Channels.Whatsapp;

namespace Sentdm.Services.Channels;

/// <inheritdoc/>
public sealed class WhatsappService : IWhatsappService
{
    readonly Lazy<IWhatsappServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWhatsappServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public IWhatsappService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WhatsappService(this._client.WithOptions(modifier));
    }

    public WhatsappService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WhatsappServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfWhatsappChannel> Create(
        WhatsappCreateParams? parameters = null,
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
public sealed class WhatsappServiceWithRawResponse : IWhatsappServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWhatsappServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WhatsappServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WhatsappServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfWhatsappChannel>> Create(
        WhatsappCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WhatsappCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfWhatsappChannel = await response
                    .Deserialize<ApiResponseOfWhatsappChannel>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfWhatsappChannel.Validate();
                }
                return apiResponseOfWhatsappChannel;
            }
        );
    }
}
