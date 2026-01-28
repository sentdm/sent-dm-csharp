using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Organizations;
using Sentdm.Services.Organizations;

namespace Sentdm.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IOrganizationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOrganizationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOrganizationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IUserService Users { get; }

    /// <summary>
    /// Retrieves all organizations that the authenticated user has access to, including
    /// the sender profiles within each organization that the user can access. Returns
    /// organization details with nested profiles filtered by user permissions.
    /// </summary>
    Task<OrganizationListResponse> List(
        OrganizationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves all sender profiles within an organization that the authenticated
    /// user has access to. Returns filtered list based on user's permissions.
    /// </summary>
    Task<OrganizationRetrieveProfilesResponse> RetrieveProfiles(
        OrganizationRetrieveProfilesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveProfiles(OrganizationRetrieveProfilesParams, CancellationToken)"/>
    Task<OrganizationRetrieveProfilesResponse> RetrieveProfiles(
        string orgID,
        OrganizationRetrieveProfilesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IOrganizationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOrganizationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOrganizationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IUserServiceWithRawResponse Users { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /v2/organizations`, but is otherwise the
    /// same as <see cref="IOrganizationService.List(OrganizationListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OrganizationListResponse>> List(
        OrganizationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v2/organizations/{orgId}/profiles`, but is otherwise the
    /// same as <see cref="IOrganizationService.RetrieveProfiles(OrganizationRetrieveProfilesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OrganizationRetrieveProfilesResponse>> RetrieveProfiles(
        OrganizationRetrieveProfilesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveProfiles(OrganizationRetrieveProfilesParams, CancellationToken)"/>
    Task<HttpResponse<OrganizationRetrieveProfilesResponse>> RetrieveProfiles(
        string orgID,
        OrganizationRetrieveProfilesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
