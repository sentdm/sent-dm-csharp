using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SentDm.Core;
using SentDm.Exceptions;
using SentDm.Models.Organizations.Users;

namespace SentDm.Services.Organizations;

/// <inheritdoc/>
public sealed class UserService : IUserService
{
    readonly Lazy<IUserServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUserServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentDmClient _client;

    /// <inheritdoc/>
    public IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserService(this._client.WithOptions(modifier));
    }

    public UserService(ISentDmClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UserServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CustomerUser> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomerUser> Retrieve(
        string userID,
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UserListResponse> List(
        UserListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UserListResponse> List(
        string customerID,
        UserListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(UserDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string userID,
        UserDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { UserID = userID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CustomerUser> Invite(
        UserInviteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Invite(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomerUser> Invite(
        string customerID,
        UserInviteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Invite(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerUser> UpdateRole(
        UserUpdateRoleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateRole(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomerUser> UpdateRole(
        string userID,
        UserUpdateRoleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateRole(parameters with { UserID = userID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class UserServiceWithRawResponse : IUserServiceWithRawResponse
{
    readonly ISentDmClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUserServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UserServiceWithRawResponse(ISentDmClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerUser>> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new SentDmInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<UserRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customerUser = await response
                    .Deserialize<CustomerUser>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customerUser.Validate();
                }
                return customerUser;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomerUser>> Retrieve(
        string userID,
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserListResponse>> List(
        UserListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new SentDmInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<UserListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var users = await response
                    .Deserialize<UserListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    users.Validate();
                }
                return users;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UserListResponse>> List(
        string customerID,
        UserListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        UserDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new SentDmInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<UserDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string userID,
        UserDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerUser>> Invite(
        UserInviteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new SentDmInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<UserInviteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customerUser = await response
                    .Deserialize<CustomerUser>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customerUser.Validate();
                }
                return customerUser;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomerUser>> Invite(
        string customerID,
        UserInviteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Invite(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerUser>> UpdateRole(
        UserUpdateRoleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new SentDmInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<UserUpdateRoleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customerUser = await response
                    .Deserialize<CustomerUser>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customerUser.Validate();
                }
                return customerUser;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomerUser>> UpdateRole(
        string userID,
        UserUpdateRoleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateRole(parameters with { UserID = userID }, cancellationToken);
    }
}
