using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Channels.Rcs;

namespace Sentdm.Services.Channels;

/// <inheritdoc/>
public sealed class RcService : IRcService
{
    readonly Lazy<IRcServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRcServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public IRcService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RcService(this._client.WithOptions(modifier));
    }

    public RcService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RcServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfRcsAgent> Create(
        RcCreateParams? parameters = null,
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
public sealed class RcServiceWithRawResponse : IRcServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRcServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RcServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RcServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfRcsAgent>> Create(
        RcCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RcCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfRcsAgent = await response
                    .Deserialize<ApiResponseOfRcsAgent>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfRcsAgent.Validate();
                }
                return apiResponseOfRcsAgent;
            }
        );
    }
}
