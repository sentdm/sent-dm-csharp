using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITemplateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITemplateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new message template with header, body, footer, and buttons. The
    /// template can be submitted for review immediately or saved as draft for later submission.
    /// </summary>
    Task<ApiResponseTemplate> Create(
        TemplateCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a specific template by its ID. Returns template details including
    /// name, category, language, status, and definition.
    /// </summary>
    Task<ApiResponseTemplate> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TemplateRetrieveParams, CancellationToken)"/>
    Task<ApiResponseTemplate> Retrieve(
        string id,
        TemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing template's name, category, language, definition, or submits
    /// it for review.
    /// </summary>
    Task<ApiResponseTemplate> Update(
        TemplateUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TemplateUpdateParams, CancellationToken)"/>
    Task<ApiResponseTemplate> Update(
        string id,
        TemplateUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of message templates for the authenticated customer.
    /// Supports filtering by status, category, and search term.
    /// </summary>
    Task<TemplateListResponse> List(
        TemplateListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a template by ID. Optionally, you can also delete the template from
    /// WhatsApp/Meta by setting delete_from_meta=true.
    /// </summary>
    Task Delete(TemplateDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(TemplateDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        TemplateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITemplateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITemplateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITemplateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /v3/templates`, but is otherwise the
    /// same as <see cref="ITemplateService.Create(TemplateCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseTemplate>> Create(
        TemplateCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/templates/{id}`, but is otherwise the
    /// same as <see cref="ITemplateService.Retrieve(TemplateRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseTemplate>> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TemplateRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseTemplate>> Retrieve(
        string id,
        TemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /v3/templates/{id}`, but is otherwise the
    /// same as <see cref="ITemplateService.Update(TemplateUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseTemplate>> Update(
        TemplateUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TemplateUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseTemplate>> Update(
        string id,
        TemplateUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/templates`, but is otherwise the
    /// same as <see cref="ITemplateService.List(TemplateListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TemplateListResponse>> List(
        TemplateListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /v3/templates/{id}`, but is otherwise the
    /// same as <see cref="ITemplateService.Delete(TemplateDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        TemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TemplateDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        TemplateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
