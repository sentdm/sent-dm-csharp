using System;
using Sentdm.Core;

namespace Sentdm.Services.Brands;

/// <inheritdoc/>
public sealed class CampaignService : ICampaignService
{
    readonly Lazy<ICampaignServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICampaignServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentDmClient _client;

    /// <inheritdoc/>
    public ICampaignService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CampaignService(this._client.WithOptions(modifier));
    }

    public CampaignService(ISentDmClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CampaignServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class CampaignServiceWithRawResponse : ICampaignServiceWithRawResponse
{
    readonly ISentDmClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICampaignServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CampaignServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CampaignServiceWithRawResponse(ISentDmClientWithRawResponse client)
    {
        _client = client;
    }
}
