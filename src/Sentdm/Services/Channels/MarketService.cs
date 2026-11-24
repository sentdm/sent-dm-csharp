using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Channels.Markets;

namespace Sentdm.Services.Channels;

/// <inheritdoc/>
public sealed class MarketService : IMarketService
{
    readonly Lazy<IMarketServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMarketServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public IMarketService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MarketService(this._client.WithOptions(modifier));
    }

    public MarketService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MarketServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfChannelMarket> Retrieve(
        MarketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfChannelMarket> Retrieve(
        string type,
        MarketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { Type = type }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfChannelMarket> Update(
        MarketUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfChannelMarket> Update(
        string type,
        MarketUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { Type = type }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfListOfChannelMarket> List(
        MarketListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfListOfChannelMarket> List(
        string channel,
        MarketListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { Channel = channel }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfChannelMarket> AddNumbers(
        MarketAddNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.AddNumbers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfChannelMarket> AddNumbers(
        string type,
        MarketAddNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.AddNumbers(parameters with { Type = type }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfMarketNumbers> ListNumbers(
        MarketListNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListNumbers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfMarketNumbers> ListNumbers(
        string type,
        MarketListNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListNumbers(parameters with { Type = type }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfChannelMarket> ReplaceNumbers(
        MarketReplaceNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ReplaceNumbers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfChannelMarket> ReplaceNumbers(
        string type,
        MarketReplaceNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ReplaceNumbers(parameters with { Type = type }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MarketServiceWithRawResponse : IMarketServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMarketServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MarketServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MarketServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfChannelMarket>> Retrieve(
        MarketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Type == null)
        {
            throw new SentInvalidDataException("'parameters.Type' cannot be null");
        }

        HttpRequest<MarketRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
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

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfChannelMarket>> Retrieve(
        string type,
        MarketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { Type = type }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfChannelMarket>> Update(
        MarketUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Type == null)
        {
            throw new SentInvalidDataException("'parameters.Type' cannot be null");
        }

        HttpRequest<MarketUpdateParams> request = new()
        {
            Method = SentClientWithRawResponse.PatchMethod,
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

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfChannelMarket>> Update(
        string type,
        MarketUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { Type = type }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfListOfChannelMarket>> List(
        MarketListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Channel == null)
        {
            throw new SentInvalidDataException("'parameters.Channel' cannot be null");
        }

        HttpRequest<MarketListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfListOfChannelMarket = await response
                    .Deserialize<ApiResponseOfListOfChannelMarket>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfListOfChannelMarket.Validate();
                }
                return apiResponseOfListOfChannelMarket;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfListOfChannelMarket>> List(
        string channel,
        MarketListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { Channel = channel }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfChannelMarket>> AddNumbers(
        MarketAddNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Type == null)
        {
            throw new SentInvalidDataException("'parameters.Type' cannot be null");
        }

        HttpRequest<MarketAddNumbersParams> request = new()
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

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfChannelMarket>> AddNumbers(
        string type,
        MarketAddNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.AddNumbers(parameters with { Type = type }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfMarketNumbers>> ListNumbers(
        MarketListNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Type == null)
        {
            throw new SentInvalidDataException("'parameters.Type' cannot be null");
        }

        HttpRequest<MarketListNumbersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfMarketNumbers = await response
                    .Deserialize<ApiResponseOfMarketNumbers>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfMarketNumbers.Validate();
                }
                return apiResponseOfMarketNumbers;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfMarketNumbers>> ListNumbers(
        string type,
        MarketListNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListNumbers(parameters with { Type = type }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfChannelMarket>> ReplaceNumbers(
        MarketReplaceNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Type == null)
        {
            throw new SentInvalidDataException("'parameters.Type' cannot be null");
        }

        HttpRequest<MarketReplaceNumbersParams> request = new()
        {
            Method = SentClientWithRawResponse.PatchMethod,
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

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfChannelMarket>> ReplaceNumbers(
        string type,
        MarketReplaceNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ReplaceNumbers(parameters with { Type = type }, cancellationToken);
    }
}
