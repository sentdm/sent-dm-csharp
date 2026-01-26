using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SentDm.Core;
using SentDm.Exceptions;
using SentDm.Models.Organizations;
using SentDm.Services.Organizations;

namespace SentDm.Services;

/// <inheritdoc/>
public sealed class OrganizationService : IOrganizationService
{
    readonly Lazy<IOrganizationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOrganizationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentDmClient _client;

    /// <inheritdoc/>
    public IOrganizationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OrganizationService(this._client.WithOptions(modifier));
    }

    public OrganizationService(ISentDmClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new OrganizationServiceWithRawResponse(client.WithRawResponse)
        );
        _users = new(() => new UserService(client));
    }

    readonly Lazy<IUserService> _users;
    public IUserService Users
    {
        get { return _users.Value; }
    }

    /// <inheritdoc/>
    public async Task<OrganizationListResponse> List(
        OrganizationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<OrganizationRetrieveProfilesResponse> RetrieveProfiles(
        OrganizationRetrieveProfilesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveProfiles(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<OrganizationRetrieveProfilesResponse> RetrieveProfiles(
        string orgID,
        OrganizationRetrieveProfilesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveProfiles(parameters with { OrgID = orgID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class OrganizationServiceWithRawResponse : IOrganizationServiceWithRawResponse
{
    readonly ISentDmClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOrganizationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new OrganizationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OrganizationServiceWithRawResponse(ISentDmClientWithRawResponse client)
    {
        _client = client;

        _users = new(() => new UserServiceWithRawResponse(client));
    }

    readonly Lazy<IUserServiceWithRawResponse> _users;
    public IUserServiceWithRawResponse Users
    {
        get { return _users.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OrganizationListResponse>> List(
        OrganizationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OrganizationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var organizations = await response
                    .Deserialize<OrganizationListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    organizations.Validate();
                }
                return organizations;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OrganizationRetrieveProfilesResponse>> RetrieveProfiles(
        OrganizationRetrieveProfilesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.OrgID == null)
        {
            throw new SentDmInvalidDataException("'parameters.OrgID' cannot be null");
        }

        HttpRequest<OrganizationRetrieveProfilesParams> request = new()
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
                    .Deserialize<OrganizationRetrieveProfilesResponse>(token)
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
    public Task<HttpResponse<OrganizationRetrieveProfilesResponse>> RetrieveProfiles(
        string orgID,
        OrganizationRetrieveProfilesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveProfiles(parameters with { OrgID = orgID }, cancellationToken);
    }
}
