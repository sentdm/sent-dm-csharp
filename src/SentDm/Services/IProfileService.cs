using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using SentDm.Core;
using SentDm.Models.Profiles;

namespace SentDm.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProfileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new sender profile within an organization. Profiles represent different
    /// brands, departments, or use cases, each with their own messaging configuration
    /// and settings. Requires admin role in the organization.
    /// </summary>
    Task<ApiResponseOfProfileDetail> Create(
        ProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves detailed information about a specific sender profile within an organization.
    /// </summary>
    Task<ApiResponseOfProfileDetail> Retrieve(
        ProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProfileRetrieveParams, CancellationToken)"/>
    Task<ApiResponseOfProfileDetail> Retrieve(
        string profileID,
        ProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a profile's configuration and settings. Requires admin role in the
    /// organization. Only provided fields will be updated (partial update).
    /// </summary>
    Task<ApiResponseOfProfileDetail> Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ProfileUpdateParams, CancellationToken)"/>
    Task<ApiResponseOfProfileDetail> Update(
        string profileID,
        ProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves all sender profiles within an organization. Profiles represent different
    /// brands, departments, or use cases within an organization, each with their
    /// own messaging configuration.
    /// </summary>
    Task<ProfileListResponse> List(
        ProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Soft deletes a sender profile. The profile will be marked as deleted but data
    /// is retained. Requires admin role in the organization.
    /// </summary>
    Task Delete(ProfileDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ProfileDeleteParams, CancellationToken)"/>
    Task Delete(
        string profileID,
        ProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Final step in profile compliance workflow. Validates all prerequisites (general
    /// data, brand, campaigns), connects profile to Telnyx/WhatsApp, and sets status
    /// based on configuration. The process runs in the background and calls the
    /// provided webhook URL when finished.
    ///
    /// <para>                Prerequisites:                 - Profile must be completed
    ///                 - If inheritTcrBrand=false: Profile must have existing brand
    ///                 - If inheritTcrBrand=true: Parent must have existing brand
    ///                 - If TCR application: Must have at least one campaign (own
    /// or inherited)                 - If inheritTcrCampaign=false: Profile should
    /// have campaigns                 - If inheritTcrCampaign=true: Parent must have campaigns</para>
    ///
    /// <para>                Status Logic:                 - If both SMS and WhatsApp
    /// channels are missing → SUBMITTED                 - If TCR application and
    /// not inheriting brand/campaigns → SUBMITTED                 - If non-TCR with
    /// destination country (IsMain=true) → SUBMITTED                 - Otherwise
    /// → COMPLETED</para>
    /// </summary>
    Task<JsonElement> Complete(
        ProfileCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(ProfileCompleteParams, CancellationToken)"/>
    Task<JsonElement> Complete(
        string profileID,
        ProfileCompleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProfileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /v3/profiles`, but is otherwise the
    /// same as <see cref="IProfileService.Create(ProfileCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfProfileDetail>> Create(
        ProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/profiles/{profileId}`, but is otherwise the
    /// same as <see cref="IProfileService.Retrieve(ProfileRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfProfileDetail>> Retrieve(
        ProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProfileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfProfileDetail>> Retrieve(
        string profileID,
        ProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /v3/profiles/{profileId}`, but is otherwise the
    /// same as <see cref="IProfileService.Update(ProfileUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfProfileDetail>> Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ProfileUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfProfileDetail>> Update(
        string profileID,
        ProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/profiles`, but is otherwise the
    /// same as <see cref="IProfileService.List(ProfileListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProfileListResponse>> List(
        ProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /v3/profiles/{profileId}`, but is otherwise the
    /// same as <see cref="IProfileService.Delete(ProfileDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ProfileDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string profileID,
        ProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v3/profiles/{profileId}/complete`, but is otherwise the
    /// same as <see cref="IProfileService.Complete(ProfileCompleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JsonElement>> Complete(
        ProfileCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(ProfileCompleteParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> Complete(
        string profileID,
        ProfileCompleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
