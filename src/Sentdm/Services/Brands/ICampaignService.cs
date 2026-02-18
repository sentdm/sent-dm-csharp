using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Brands.Campaigns;

namespace Sentdm.Services.Brands;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
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
    /// Creates a new campaign scoped under a specific brand. The campaign is linked
    /// to the specified brand. Each campaign must include at least one use case
    /// with sample messages.
    /// </summary>
    Task<ApiResponseTcrCampaignWithUseCases> Create(
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(CampaignCreateParams, CancellationToken)"/>
    Task<ApiResponseTcrCampaignWithUseCases> Create(
        string brandID,
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing campaign scoped under a specific brand. Cannot update
    /// campaigns that have already been submitted to TCR.
    /// </summary>
    Task<ApiResponseTcrCampaignWithUseCases> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CampaignUpdateParams, CancellationToken)"/>
    Task<ApiResponseTcrCampaignWithUseCases> Update(
        string campaignID,
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves all campaigns linked to a specific brand, including their use cases
    /// and sample messages.
    /// </summary>
    Task<CampaignListResponse> List(
        CampaignListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CampaignListParams, CancellationToken)"/>
    Task<CampaignListResponse> List(
        string brandID,
        CampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a campaign by ID within a specific brand. The brand must belong to
    /// the authenticated customer.
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
    /// Returns a raw HTTP response for `post /v3/brands/{brandId}/campaigns`, but is otherwise the
    /// same as <see cref="ICampaignService.Create(CampaignCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseTcrCampaignWithUseCases>> Create(
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(CampaignCreateParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseTcrCampaignWithUseCases>> Create(
        string brandID,
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /v3/brands/{brandId}/campaigns/{campaignId}`, but is otherwise the
    /// same as <see cref="ICampaignService.Update(CampaignUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseTcrCampaignWithUseCases>> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CampaignUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseTcrCampaignWithUseCases>> Update(
        string campaignID,
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/brands/{brandId}/campaigns`, but is otherwise the
    /// same as <see cref="ICampaignService.List(CampaignListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CampaignListResponse>> List(
        CampaignListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CampaignListParams, CancellationToken)"/>
    Task<HttpResponse<CampaignListResponse>> List(
        string brandID,
        CampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /v3/brands/{brandId}/campaigns/{campaignId}`, but is otherwise the
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
