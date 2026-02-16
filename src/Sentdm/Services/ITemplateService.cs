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
    /// Creates a new message template for the authenticated customer with comprehensive
    /// template definitions including headers, body, footer, and interactive buttons.
    /// Supports automatic metadata generation using AI (display name, language, category).
    /// Optionally submits the template for WhatsApp review. The customer ID is extracted
    /// from the authentication token.
    /// </summary>
    Task<TemplateResponseV2> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a specific message template by its unique identifier for the authenticated
    /// customer with comprehensive template definitions including headers, body,
    /// footer, and interactive buttons. The customer ID is extracted from the authentication token.
    /// </summary>
    Task<TemplateResponseV2> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TemplateRetrieveParams, CancellationToken)"/>
    Task<TemplateResponseV2> Retrieve(
        string id,
        TemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves all message templates available for the authenticated customer with
    /// comprehensive template definitions including headers, body, footer, and interactive
    /// buttons. Supports advanced filtering by search term, status, and category,
    /// plus pagination. The customer ID is extracted from the authentication token.
    /// </summary>
    Task<TemplateListResponse> List(
        TemplateListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a specific message template by its unique identifier for the authenticated
    /// customer with smart deletion strategy. Deletion behavior: - If template has
    /// NO messages: Permanently deleted from database (hard delete). - If template
    /// has messages: Marked as deleted but preserved for message history (soft delete
    /// with snapshot). The template must exist and belong to the authenticated customer
    /// to be deleted successfully. The customer ID is extracted from the authentication token.
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
    /// Returns a raw HTTP response for `post /v2/templates`, but is otherwise the
    /// same as <see cref="ITemplateService.Create(TemplateCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TemplateResponseV2>> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v2/templates/{id}`, but is otherwise the
    /// same as <see cref="ITemplateService.Retrieve(TemplateRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TemplateResponseV2>> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TemplateRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TemplateResponseV2>> Retrieve(
        string id,
        TemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v2/templates`, but is otherwise the
    /// same as <see cref="ITemplateService.List(TemplateListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TemplateListResponse>> List(
        TemplateListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /v2/templates/{id}`, but is otherwise the
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
