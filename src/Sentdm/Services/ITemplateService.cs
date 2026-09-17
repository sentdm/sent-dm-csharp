using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Services;

/// <summary>
/// Reusable message bodies with named variables.
///
/// <para>A template is substituted at send time from the values you pass, so the
/// copy lives here rather than in your application. WhatsApp templates additionally
/// need Meta's approval before they can be sent, and a template's channel status
/// reports where that stands — an approved SMS template and an unapproved WhatsApp
/// one are the same template in two states.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
    /// template can be submitted for review immediately or saved as draft for later
    /// submission. There is no `name` field on create — the display name is derived
    /// from the template's content and can be changed afterwards with `PUT
    /// /v3/templates/{id}`.
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
    /// it for review. While the template is in review (status PENDING, or any channel
    /// awaiting a verdict) its definition, category and language are frozen and a
    /// resubmission is refused — those requests answer 409 CONFLICT_006. The display
    /// name stays editable throughout.
    ///
    /// <para>`definition`, `category` and `language` are editable only from status
    /// DRAFT, REJECTED or APPROVED. An edit to any of them on a template in another
    /// state (PAUSED, DISABLED or REVOKED) is refused with 400 VALIDATION_001 and the
    /// detail "Template (except display name) cannot be updated unless it is in draft
    /// or rejected status"; `name` stays editable in every state. `submit_for_review`
    /// on a PAUSED, DISABLED or REVOKED template is accepted and answers 200, but opens
    /// no review and does not move the status — only the reviewer can reinstate it.</para>
    ///
    /// <para>Editing an APPROVED template is a live edit: the new content is stored
    /// immediately, and sending `submit_for_review: true` re-opens review, which
    /// returns the affected channels to PENDING so they stop sending until they are
    /// approved again. The previously approved content is never sent during re-review.
    /// Watch the per-channel `templates` webhook events rather than assuming the
    /// template-level status.</para>
    ///
    /// <para>Templates provisioned by Sent (light-onboarding templates, whose names
    /// carry the reserved `sent_` prefix) are read-only: every field is refused with
    /// 400 VALIDATION_001 and the detail "This template is read-only. Only 'submit for
    /// review' is allowed.", and only `submit_for_review` is accepted. A `name`
    /// starting with `sent_` is refused for the same reason — the prefix is reserved.</para>
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
    Task<TemplateListPage> List(
        TemplateListParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /v3/templates</c>, but is otherwise the
    /// same as <see cref="ITemplateService.Create(TemplateCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseTemplate>> Create(
        TemplateCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/templates/{id}</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>put /v3/templates/{id}</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>get /v3/templates</c>, but is otherwise the
    /// same as <see cref="ITemplateService.List(TemplateListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TemplateListPage>> List(
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/templates/{id}</c>, but is otherwise the
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
