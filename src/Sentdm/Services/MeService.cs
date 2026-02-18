using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Me;

namespace Sentdm.Services;

/// <inheritdoc/>
public sealed class MeService : IMeService
{
    readonly Lazy<IMeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentDmClient _client;

    /// <inheritdoc/>
    public IMeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MeService(this._client.WithOptions(modifier));
    }

    public MeService(ISentDmClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<MeRetrieveResponse> Retrieve(
        MeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MeServiceWithRawResponse : IMeServiceWithRawResponse
{
    readonly ISentDmClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MeServiceWithRawResponse(ISentDmClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MeRetrieveResponse>> Retrieve(
        MeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var me = await response
                    .Deserialize<MeRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    me.Validate();
                }
                return me;
            }
        );
    }
}
