using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Users;

namespace Sentdm.Services;

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
    /// Retrieves detailed information about a specific user in an organization or
    /// profile. Requires developer role or higher.
    /// </summary>
    Task<ApiResponseOfUser> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<ApiResponseOfUser> Retrieve(
        string userID,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves all users who have access to the organization or profile identified
    /// by the API key, including their roles and status. Shows invited users (pending
    /// acceptance) and active users. Requires developer role or higher.
    /// </summary>
    Task<UserListResponse> List(
        UserListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends an invitation to a user to join the organization or profile with a
    /// specific role. Requires admin role. The user will receive an invitation email
    /// with a token to accept. Invitation tokens expire after 7 days.
    /// </summary>
    Task<ApiResponseOfUser> Invite(
        UserInviteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a user's access to an organization or profile. Requires admin role.
    /// You cannot remove yourself or remove the last admin.
    /// </summary>
    Task Remove(UserRemoveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Remove(UserRemoveParams, CancellationToken)"/>
    Task Remove(
        string userID,
        UserRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a user's role in the organization or profile. Requires admin role.
    /// You cannot change your own role or demote the last admin.
    /// </summary>
    Task<ApiResponseOfUser> UpdateRole(
        UserUpdateRoleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateRole(UserUpdateRoleParams, CancellationToken)"/>
    Task<ApiResponseOfUser> UpdateRole(
        string userID,
        UserUpdateRoleParams? parameters = null,
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
    /// Returns a raw HTTP response for `get /v3/users/{userId}`, but is otherwise the
    /// same as <see cref="IUserService.Retrieve(UserRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfUser>> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfUser>> Retrieve(
        string userID,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/users`, but is otherwise the
    /// same as <see cref="IUserService.List(UserListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserListResponse>> List(
        UserListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v3/users`, but is otherwise the
    /// same as <see cref="IUserService.Invite(UserInviteParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfUser>> Invite(
        UserInviteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /v3/users/{userId}`, but is otherwise the
    /// same as <see cref="IUserService.Remove(UserRemoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Remove(
        UserRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(UserRemoveParams, CancellationToken)"/>
    Task<HttpResponse> Remove(
        string userID,
        UserRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /v3/users/{userId}`, but is otherwise the
    /// same as <see cref="IUserService.UpdateRole(UserUpdateRoleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfUser>> UpdateRole(
        UserUpdateRoleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateRole(UserUpdateRoleParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfUser>> UpdateRole(
        string userID,
        UserUpdateRoleParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
