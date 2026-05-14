using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Profiles.Campaigns;

namespace Sentdm.Services.Profiles;

/// <summary>
/// Manage organization profiles
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICampaignService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICampaignServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICampaignService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new campaign scoped under the brand of the specified profile. Each
    /// campaign must include at least one use case with sample messages.
    /// </summary>
    Task<ApiResponseOfTcrCampaignWithUseCases> Create(
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(CampaignCreateParams, CancellationToken)"/>
    Task<ApiResponseOfTcrCampaignWithUseCases> Create(
        string profileID,
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing campaign under the brand of the specified profile. Cannot
    /// update campaigns that have already been submitted to TCR.
    /// </summary>
    Task<ApiResponseOfTcrCampaignWithUseCases> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CampaignUpdateParams, CancellationToken)"/>
    Task<ApiResponseOfTcrCampaignWithUseCases> Update(
        string campaignID,
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves all campaigns linked to the profile's brand, including use cases and
    /// sample messages. Returns inherited campaigns if inherit_tcr_campaign=true.
    /// </summary>
    Task<CampaignListResponse> List(
        CampaignListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CampaignListParams, CancellationToken)"/>
    Task<CampaignListResponse> List(
        string profileID,
        CampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a campaign by ID from the brand of the specified profile. The profile
    /// must belong to the authenticated organization.
    /// </summary>
    Task Delete(CampaignDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(CampaignDeleteParams, CancellationToken)"/>
    Task Delete(
        string campaignID,
        CampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICampaignService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICampaignServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICampaignServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/profiles/{profileId}/campaigns</c>, but is otherwise the
    /// same as <see cref="ICampaignService.Create(CampaignCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfTcrCampaignWithUseCases>> Create(
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(CampaignCreateParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfTcrCampaignWithUseCases>> Create(
        string profileID,
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v3/profiles/{profileId}/campaigns/{campaignId}</c>, but is otherwise the
    /// same as <see cref="ICampaignService.Update(CampaignUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfTcrCampaignWithUseCases>> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CampaignUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfTcrCampaignWithUseCases>> Update(
        string campaignID,
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/profiles/{profileId}/campaigns</c>, but is otherwise the
    /// same as <see cref="ICampaignService.List(CampaignListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CampaignListResponse>> List(
        CampaignListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CampaignListParams, CancellationToken)"/>
    Task<HttpResponse<CampaignListResponse>> List(
        string profileID,
        CampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/profiles/{profileId}/campaigns/{campaignId}</c>, but is otherwise the
    /// same as <see cref="ICampaignService.Delete(CampaignDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        CampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CampaignDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string campaignID,
        CampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
