using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Profiles.Campaigns;

namespace Sentdm.Services.Profiles;

/// <inheritdoc/>
public sealed class CampaignService : ICampaignService
{
    readonly Lazy<ICampaignServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICampaignServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public ICampaignService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CampaignService(this._client.WithOptions(modifier));
    }

    public CampaignService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CampaignServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CampaignCreateResponse> Create(
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CampaignCreateResponse> Create(
        string profileID,
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ProfileID = profileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CampaignUpdateResponse> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CampaignUpdateResponse> Update(
        string campaignID,
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { CampaignID = campaignID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CampaignListResponse> List(
        CampaignListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CampaignListResponse> List(
        string profileID,
        CampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ProfileID = profileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        CampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string campaignID,
        CampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { CampaignID = campaignID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CampaignServiceWithRawResponse : ICampaignServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICampaignServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CampaignServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CampaignServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CampaignCreateResponse>> Create(
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProfileID == null)
        {
            throw new SentInvalidDataException("'parameters.ProfileID' cannot be null");
        }

        HttpRequest<CampaignCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var campaign = await response
                    .Deserialize<CampaignCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    campaign.Validate();
                }
                return campaign;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CampaignCreateResponse>> Create(
        string profileID,
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ProfileID = profileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CampaignUpdateResponse>> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new SentInvalidDataException("'parameters.CampaignID' cannot be null");
        }

        HttpRequest<CampaignUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var campaign = await response
                    .Deserialize<CampaignUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    campaign.Validate();
                }
                return campaign;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CampaignUpdateResponse>> Update(
        string campaignID,
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { CampaignID = campaignID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CampaignListResponse>> List(
        CampaignListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProfileID == null)
        {
            throw new SentInvalidDataException("'parameters.ProfileID' cannot be null");
        }

        HttpRequest<CampaignListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var campaigns = await response
                    .Deserialize<CampaignListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    campaigns.Validate();
                }
                return campaigns;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CampaignListResponse>> List(
        string profileID,
        CampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ProfileID = profileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        CampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new SentInvalidDataException("'parameters.CampaignID' cannot be null");
        }

        HttpRequest<CampaignDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string campaignID,
        CampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { CampaignID = campaignID }, cancellationToken);
    }
}
