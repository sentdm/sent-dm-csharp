using System;
using System.Threading;
using System.Threading.Tasks;
using SentDm.Core;
using SentDm.Models.Organizations.Users;

namespace SentDm.Services.Organizations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieves a specific user by their ID. Requires appropriate permissions.
    /// The customerId can be either an organization ID or a profile ID.
    /// </summary>
    Task<CustomerUser> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<CustomerUser> Retrieve(
        string userID,
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves all users associated with an organization or sender profile. Requires
    /// appropriate permissions. Supports pagination.
    /// </summary>
    Task<UserListResponse> List(
        UserListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(UserListParams, CancellationToken)"/>
    Task<UserListResponse> List(
        string customerID,
        UserListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a user from an organization or sender profile. Requires admin permissions.
    /// This action permanently deletes the user association.
    /// </summary>
    Task Delete(UserDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(UserDeleteParams, CancellationToken)"/>
    Task Delete(
        string userID,
        UserDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Invites a user to an organization or sender profile with a specified role.
    /// Requires appropriate permissions. The customerId can be either an organization
    /// ID or a profile ID.
    /// </summary>
    Task<CustomerUser> Invite(
        UserInviteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Invite(UserInviteParams, CancellationToken)"/>
    Task<CustomerUser> Invite(
        string customerID,
        UserInviteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a user's role within an organization or sender profile. Requires admin
    /// permissions. Valid roles are: admin, billing, developer.
    /// </summary>
    Task<CustomerUser> UpdateRole(
        UserUpdateRoleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateRole(UserUpdateRoleParams, CancellationToken)"/>
    Task<CustomerUser> UpdateRole(
        string userID,
        UserUpdateRoleParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUserService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /v2/organizations/{customerId}/users/{userId}`, but is otherwise the
    /// same as <see cref="IUserService.Retrieve(UserRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerUser>> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CustomerUser>> Retrieve(
        string userID,
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v2/organizations/{customerId}/users`, but is otherwise the
    /// same as <see cref="IUserService.List(UserListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserListResponse>> List(
        UserListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(UserListParams, CancellationToken)"/>
    Task<HttpResponse<UserListResponse>> List(
        string customerID,
        UserListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /v2/organizations/{customerId}/users/{userId}`, but is otherwise the
    /// same as <see cref="IUserService.Delete(UserDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        UserDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(UserDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string userID,
        UserDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v2/organizations/{customerId}/users`, but is otherwise the
    /// same as <see cref="IUserService.Invite(UserInviteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerUser>> Invite(
        UserInviteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Invite(UserInviteParams, CancellationToken)"/>
    Task<HttpResponse<CustomerUser>> Invite(
        string customerID,
        UserInviteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /v2/organizations/{customerId}/users/{userId}`, but is otherwise the
    /// same as <see cref="IUserService.UpdateRole(UserUpdateRoleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerUser>> UpdateRole(
        UserUpdateRoleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateRole(UserUpdateRoleParams, CancellationToken)"/>
    Task<HttpResponse<CustomerUser>> UpdateRole(
        string userID,
        UserUpdateRoleParams parameters,
        CancellationToken cancellationToken = default
    );
}
