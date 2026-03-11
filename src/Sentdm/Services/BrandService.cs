using System;
using Sentdm.Core;
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
}
