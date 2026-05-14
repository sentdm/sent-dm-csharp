using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Profiles;
using Sentdm.Services.Profiles;

namespace Sentdm.Services;

/// <inheritdoc/>
public sealed class ProfileService : IProfileService
{
    readonly Lazy<IProfileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProfileServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public IProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProfileService(this._client.WithOptions(modifier));
    }

    public ProfileService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ProfileServiceWithRawResponse(client.WithRawResponse));
        _campaigns = new(() => new CampaignService(client));
    }

    readonly Lazy<ICampaignService> _campaigns;
    public ICampaignService Campaigns
    {
        get { return _campaigns.Value; }
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfProfileDetail> Create(
        ProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfProfileDetail> Retrieve(
        ProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfProfileDetail> Retrieve(
        string profileID,
        ProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ProfileID = profileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfProfileDetail> Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfProfileDetail> Update(
        string profileID,
        ProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ProfileID = profileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProfileListResponse> List(
        ProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string profileID,
        ProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ProfileID = profileID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ProfileCompleteResponse> Complete(
        ProfileCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Complete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ProfileCompleteResponse> Complete(
        string profileID,
        ProfileCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Complete(parameters with { ProfileID = profileID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ProfileServiceWithRawResponse : IProfileServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProfileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProfileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProfileServiceWithRawResponse(ISentClientWithRawResponse client)
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
    public async Task<HttpResponse<ApiResponseOfProfileDetail>> Create(
        ProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ProfileCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfProfileDetail = await response
                    .Deserialize<ApiResponseOfProfileDetail>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfProfileDetail.Validate();
                }
                return apiResponseOfProfileDetail;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfProfileDetail>> Retrieve(
        ProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProfileID == null)
        {
            throw new SentInvalidDataException("'parameters.ProfileID' cannot be null");
        }

        HttpRequest<ProfileRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfProfileDetail = await response
                    .Deserialize<ApiResponseOfProfileDetail>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfProfileDetail.Validate();
                }
                return apiResponseOfProfileDetail;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfProfileDetail>> Retrieve(
        string profileID,
        ProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ProfileID = profileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfProfileDetail>> Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProfileID == null)
        {
            throw new SentInvalidDataException("'parameters.ProfileID' cannot be null");
        }

        HttpRequest<ProfileUpdateParams> request = new()
        {
            Method = SentClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfProfileDetail = await response
                    .Deserialize<ApiResponseOfProfileDetail>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfProfileDetail.Validate();
                }
                return apiResponseOfProfileDetail;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfProfileDetail>> Update(
        string profileID,
        ProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ProfileID = profileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProfileListResponse>> List(
        ProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ProfileListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var profiles = await response
                    .Deserialize<ProfileListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    profiles.Validate();
                }
                return profiles;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProfileID == null)
        {
            throw new SentInvalidDataException("'parameters.ProfileID' cannot be null");
        }

        HttpRequest<ProfileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string profileID,
        ProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ProfileID = profileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProfileCompleteResponse>> Complete(
        ProfileCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProfileID == null)
        {
            throw new SentInvalidDataException("'parameters.ProfileID' cannot be null");
        }

        HttpRequest<ProfileCompleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ProfileCompleteResponse>(token)
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
    public Task<HttpResponse<ProfileCompleteResponse>> Complete(
        string profileID,
        ProfileCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Complete(parameters with { ProfileID = profileID }, cancellationToken);
    }
}
