using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Brands;
using Sentdm.Services.Brands;

namespace Sentdm.Services;

/// <inheritdoc/>
public sealed class BrandService : IBrandService
{
    readonly Lazy<IBrandServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBrandServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentDmClient _client;

    /// <inheritdoc/>
    public IBrandService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BrandService(this._client.WithOptions(modifier));
    }

    public BrandService(ISentDmClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BrandServiceWithRawResponse(client.WithRawResponse));
        _campaigns = new(() => new CampaignService(client));
    }

    readonly Lazy<ICampaignService> _campaigns;
    public ICampaignService Campaigns
    {
        get { return _campaigns.Value; }
    }

    /// <inheritdoc/>
    public async Task<ApiResponseBrandWithKyc> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseBrandWithKyc> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseBrandWithKyc> Update(
        string brandID,
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { BrandID = brandID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BrandListResponse> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(BrandDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string brandID,
        BrandDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { BrandID = brandID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BrandServiceWithRawResponse : IBrandServiceWithRawResponse
{
    readonly ISentDmClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBrandServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BrandServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BrandServiceWithRawResponse(ISentDmClientWithRawResponse client)
    {
        _client = client;

        _campaigns = new(() => new CampaignServiceWithRawResponse(client));
    }

    readonly Lazy<ICampaignServiceWithRawResponse> _campaigns;
    public ICampaignServiceWithRawResponse Campaigns
    {
        get { return _campaigns.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseBrandWithKyc>> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BrandCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseBrandWithKyc = await response
                    .Deserialize<ApiResponseBrandWithKyc>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseBrandWithKyc.Validate();
                }
                return apiResponseBrandWithKyc;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseBrandWithKyc>> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new SentDmInvalidDataException("'parameters.BrandID' cannot be null");
        }

        HttpRequest<BrandUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseBrandWithKyc = await response
                    .Deserialize<ApiResponseBrandWithKyc>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseBrandWithKyc.Validate();
                }
                return apiResponseBrandWithKyc;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseBrandWithKyc>> Update(
        string brandID,
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { BrandID = brandID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BrandListResponse>> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BrandListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var brands = await response
                    .Deserialize<BrandListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    brands.Validate();
                }
                return brands;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        BrandDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new SentDmInvalidDataException("'parameters.BrandID' cannot be null");
        }

        HttpRequest<BrandDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string brandID,
        BrandDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { BrandID = brandID }, cancellationToken);
    }
}
