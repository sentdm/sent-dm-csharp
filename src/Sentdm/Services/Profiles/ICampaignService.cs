using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Profiles.Campaigns;

namespace Sentdm.Services.Profiles;

/// <summary>
/// **Deprecated — use Sender Profiles.**
///
/// <para>The original profile resource, kept because it has live callers. It still
/// works, and its replacement is `/v3/sender-profiles`, which takes the identity
/// and the campaign in one call instead of across three.</para>
///
/// <para>New integrations should not start here.</para>
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
    /// **Deprecated.** This endpoint is replaced by `/v3/sender-profiles` and will be
    /// removed in a future release. It still behaves exactly as before, so nothing
    /// needs to change today — but new integrations should use `/v3/sender-profiles`,
    /// which models a profile's markets, compliance, brand, campaigns and billing
    /// explicitly.
    ///
    /// <para>Creates a new campaign scoped under the brand of the specified profile.
    /// Each campaign must include at least one use case with sample messages.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<CampaignCreateResponse> Create(
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(CampaignCreateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<CampaignCreateResponse> Create(
        string profileID,
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Deprecated.** This endpoint is replaced by `/v3/sender-profiles` and will be
    /// removed in a future release. It still behaves exactly as before, so nothing
    /// needs to change today — but new integrations should use `/v3/sender-profiles`,
    /// which models a profile's markets, compliance, brand, campaigns and billing
    /// explicitly.
    ///
    /// <para>Updates an existing campaign under the brand of the specified profile.
    /// Cannot update campaigns that have already been submitted to TCR.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<CampaignUpdateResponse> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CampaignUpdateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<CampaignUpdateResponse> Update(
        string campaignID,
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Deprecated.** This endpoint is replaced by `/v3/sender-profiles` and will be
    /// removed in a future release. It still behaves exactly as before, so nothing
    /// needs to change today — but new integrations should use `/v3/sender-profiles`,
    /// which models a profile's markets, compliance, brand, campaigns and billing
    /// explicitly.
    ///
    /// <para>Retrieves all campaigns linked to the profile's brand, including use cases
    /// and sample messages. Returns inherited campaigns if inherit_tcr_campaign=true.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<CampaignListResponse> List(
        CampaignListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CampaignListParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<CampaignListResponse> List(
        string profileID,
        CampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Deprecated.** This endpoint is replaced by `/v3/sender-profiles` and will be
    /// removed in a future release. It still behaves exactly as before, so nothing
    /// needs to change today — but new integrations should use `/v3/sender-profiles`,
    /// which models a profile's markets, compliance, brand, campaigns and billing
    /// explicitly.
    ///
    /// <para>Deletes a campaign by ID from the brand of the specified profile. The
    /// profile must belong to the authenticated organization.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task Delete(CampaignDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(CampaignDeleteParams, CancellationToken)"/>
    [Obsolete("deprecated")]
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
    [Obsolete("deprecated")]
    Task<HttpResponse<CampaignCreateResponse>> Create(
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(CampaignCreateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<CampaignCreateResponse>> Create(
        string profileID,
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v3/profiles/{profileId}/campaigns/{campaignId}</c>, but is otherwise the
    /// same as <see cref="ICampaignService.Update(CampaignUpdateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<CampaignUpdateResponse>> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CampaignUpdateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<CampaignUpdateResponse>> Update(
        string campaignID,
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/profiles/{profileId}/campaigns</c>, but is otherwise the
    /// same as <see cref="ICampaignService.List(CampaignListParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<CampaignListResponse>> List(
        CampaignListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CampaignListParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<CampaignListResponse>> List(
        string profileID,
        CampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/profiles/{profileId}/campaigns/{campaignId}</c>, but is otherwise the
    /// same as <see cref="ICampaignService.Delete(CampaignDeleteParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse> Delete(
        CampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CampaignDeleteParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse> Delete(
        string campaignID,
        CampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
