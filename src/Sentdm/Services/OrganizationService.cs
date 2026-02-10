using System;
using Sentdm.Core;
using Sentdm.Services.Organizations;

namespace Sentdm.Services;

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
}
