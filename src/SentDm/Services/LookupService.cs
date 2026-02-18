using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SentDm.Core;
using SentDm.Exceptions;
using SentDm.Models.Lookup;

namespace SentDm.Services;

/// <inheritdoc/>
public sealed class LookupService : ILookupService
{
    readonly Lazy<ILookupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILookupServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentDmClient _client;

    /// <inheritdoc/>
    public ILookupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LookupService(this._client.WithOptions(modifier));
    }

    public LookupService(ISentDmClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LookupServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<LookupRetrievePhoneInfoResponse> RetrievePhoneInfo(
        LookupRetrievePhoneInfoParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrievePhoneInfo(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LookupRetrievePhoneInfoResponse> RetrievePhoneInfo(
        string phoneNumber,
        LookupRetrievePhoneInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrievePhoneInfo(
            parameters with
            {
                PhoneNumber = phoneNumber,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class LookupServiceWithRawResponse : ILookupServiceWithRawResponse
{
    readonly ISentDmClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILookupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LookupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LookupServiceWithRawResponse(ISentDmClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LookupRetrievePhoneInfoResponse>> RetrievePhoneInfo(
        LookupRetrievePhoneInfoParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new SentDmInvalidDataException("'parameters.PhoneNumber' cannot be null");
        }

        HttpRequest<LookupRetrievePhoneInfoParams> request = new()
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
                    .Deserialize<LookupRetrievePhoneInfoResponse>(token)
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
    public Task<HttpResponse<LookupRetrievePhoneInfoResponse>> RetrievePhoneInfo(
        string phoneNumber,
        LookupRetrievePhoneInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrievePhoneInfo(
            parameters with
            {
                PhoneNumber = phoneNumber,
            },
            cancellationToken
        );
    }
}
