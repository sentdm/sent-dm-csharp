using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SentDm.Core;
using SentDm.Models.NumberLookup;

namespace SentDm.Services;

/// <inheritdoc/>
public sealed class NumberLookupService : INumberLookupService
{
    readonly Lazy<INumberLookupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INumberLookupServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentDmClient _client;

    /// <inheritdoc/>
    public INumberLookupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NumberLookupService(this._client.WithOptions(modifier));
    }

    public NumberLookupService(ISentDmClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new NumberLookupServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<NumberLookupRetrieveResponse> Retrieve(
        NumberLookupRetrieveParams parameters,
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
public sealed class NumberLookupServiceWithRawResponse : INumberLookupServiceWithRawResponse
{
    readonly ISentDmClientWithRawResponse _client;

    /// <inheritdoc/>
    public INumberLookupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NumberLookupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NumberLookupServiceWithRawResponse(ISentDmClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberLookupRetrieveResponse>> Retrieve(
        NumberLookupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<NumberLookupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var numberLookup = await response
                    .Deserialize<NumberLookupRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    numberLookup.Validate();
                }
                return numberLookup;
            }
        );
    }
}
