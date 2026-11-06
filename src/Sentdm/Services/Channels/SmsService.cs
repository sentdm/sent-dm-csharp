using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Channels.Sms;

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
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfSmsMarket> Create(
        SmsCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfSmsMarket> Retrieve(
        SmsRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfSmsMarket> Retrieve(
        string type,
        SmsRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { Type = type }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfSmsMarket> Update(
        SmsUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfSmsMarket> Update(
        string type,
        SmsUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { Type = type }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfListOfSmsMarket> List(
        SmsListParams? parameters = null,
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
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfSmsMarket>> Create(
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
                var apiResponseOfSmsMarket = await response
                    .Deserialize<ApiResponseOfSmsMarket>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfSmsMarket.Validate();
                }
                return apiResponseOfSmsMarket;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfSmsMarket>> Retrieve(
        SmsRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Type == null)
        {
            throw new SentInvalidDataException("'parameters.Type' cannot be null");
        }

        HttpRequest<SmsRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfSmsMarket = await response
                    .Deserialize<ApiResponseOfSmsMarket>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfSmsMarket.Validate();
                }
                return apiResponseOfSmsMarket;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfSmsMarket>> Retrieve(
        string type,
        SmsRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { Type = type }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfSmsMarket>> Update(
        SmsUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Type == null)
        {
            throw new SentInvalidDataException("'parameters.Type' cannot be null");
        }

        HttpRequest<SmsUpdateParams> request = new()
        {
            Method = SentClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfSmsMarket = await response
                    .Deserialize<ApiResponseOfSmsMarket>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfSmsMarket.Validate();
                }
                return apiResponseOfSmsMarket;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfSmsMarket>> Update(
        string type,
        SmsUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { Type = type }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfListOfSmsMarket>> List(
        SmsListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SmsListParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfListOfSmsMarket = await response
                    .Deserialize<ApiResponseOfListOfSmsMarket>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfListOfSmsMarket.Validate();
                }
                return apiResponseOfListOfSmsMarket;
            }
        );
    }
}
