using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Numbers;

namespace Sentdm.Services;

/// <inheritdoc/>
public sealed class NumberService : INumberService
{
    readonly Lazy<INumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INumberServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentDmClient _client;

    /// <inheritdoc/>
    public INumberService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NumberService(this._client.WithOptions(modifier));
    }

    public NumberService(ISentDmClient client)
    {
        _client = client;

        _withRawResponse = new(() => new NumberServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<NumberLookupResponse> Lookup(
        NumberLookupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Lookup(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NumberLookupResponse> Lookup(
        string phoneNumber,
        NumberLookupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Lookup(parameters with { PhoneNumber = phoneNumber }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class NumberServiceWithRawResponse : INumberServiceWithRawResponse
{
    readonly ISentDmClientWithRawResponse _client;

    /// <inheritdoc/>
    public INumberServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NumberServiceWithRawResponse(ISentDmClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberLookupResponse>> Lookup(
        NumberLookupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new SentDmInvalidDataException("'parameters.PhoneNumber' cannot be null");
        }

        HttpRequest<NumberLookupParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<NumberLookupResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<NumberLookupResponse>> Lookup(
        string phoneNumber,
        NumberLookupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Lookup(parameters with { PhoneNumber = phoneNumber }, cancellationToken);
    }
}
