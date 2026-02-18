using System;
using System.Threading;
using System.Threading.Tasks;
using SentDm.Core;
using SentDm.Models.Brands;
using SentDm.Services.Brands;

namespace SentDm.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBrandService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBrandServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBrandService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICampaignService Campaigns { get; }

    /// <summary>
    /// Creates a new brand and associated information. This endpoint automatically
    /// sets inheritTcrBrand=false when a brand is created.
    /// </summary>
    Task<ApiResponseBrandWithKyc> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing brand and its associated information. Cannot update brands
    /// that have already been submitted to TCR or inherited brands.
    /// </summary>
    Task<ApiResponseBrandWithKyc> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BrandUpdateParams, CancellationToken)"/>
    Task<ApiResponseBrandWithKyc> Update(
        string brandID,
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves all brands for the authenticated customer with information in a
    /// flattened structure. Includes inherited brands if inheritTcrBrand=true.
    /// </summary>
    Task<BrandListResponse> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a brand by ID. The brand must belong to the authenticated customer.
    /// </summary>
    Task Delete(BrandDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(BrandDeleteParams, CancellationToken)"/>
    Task Delete(
        string brandID,
        BrandDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBrandService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBrandServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBrandServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICampaignServiceWithRawResponse Campaigns { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /v3/brands`, but is otherwise the
    /// same as <see cref="IBrandService.Create(BrandCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseBrandWithKyc>> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /v3/brands/{brandId}`, but is otherwise the
    /// same as <see cref="IBrandService.Update(BrandUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseBrandWithKyc>> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BrandUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseBrandWithKyc>> Update(
        string brandID,
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/brands`, but is otherwise the
    /// same as <see cref="IBrandService.List(BrandListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BrandListResponse>> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /v3/brands/{brandId}`, but is otherwise the
    /// same as <see cref="IBrandService.Delete(BrandDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        BrandDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(BrandDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string brandID,
        BrandDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
