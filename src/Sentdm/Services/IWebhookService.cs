using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWebhookService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWebhookServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new webhook endpoint for the authenticated customer.
    /// </summary>
    Task<ApiResponseWebhook> Create(
        WebhookCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a single webhook by ID for the authenticated customer.
    /// </summary>
    Task<ApiResponseWebhook> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WebhookRetrieveParams, CancellationToken)"/>
    Task<ApiResponseWebhook> Retrieve(
        string id,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing webhook for the authenticated customer.
    /// </summary>
    Task<ApiResponseWebhook> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WebhookUpdateParams, CancellationToken)"/>
    Task<ApiResponseWebhook> Update(
        string id,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of webhooks for the authenticated customer.
    /// </summary>
    Task<WebhookListResponse> List(
        WebhookListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a webhook for the authenticated customer.
    /// </summary>
    Task Delete(WebhookDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(WebhookDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves all available webhook event types that can be subscribed to.
    /// </summary>
    Task<WebhookListEventTypesResponse> ListEventTypes(
        WebhookListEventTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of delivery events for the specified webhook.
    /// </summary>
    Task<WebhookListEventsResponse> ListEvents(
        WebhookListEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListEvents(WebhookListEventsParams, CancellationToken)"/>
    Task<WebhookListEventsResponse> ListEvents(
        string id,
        WebhookListEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generates a new signing secret for the specified webhook. The old secret
    /// is immediately invalidated.
    /// </summary>
    Task<WebhookRotateSecretResponse> RotateSecret(
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RotateSecret(WebhookRotateSecretParams, CancellationToken)"/>
    Task<WebhookRotateSecretResponse> RotateSecret(
        string id,
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a test event to the specified webhook endpoint to verify connectivity.
    /// </summary>
    Task<WebhookTestResponse> Test(
        WebhookTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(WebhookTestParams, CancellationToken)"/>
    Task<WebhookTestResponse> Test(
        string id,
        WebhookTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Activates or deactivates a webhook for the authenticated customer.
    /// </summary>
    Task<ApiResponseWebhook> ToggleStatus(
        WebhookToggleStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ToggleStatus(WebhookToggleStatusParams, CancellationToken)"/>
    Task<ApiResponseWebhook> ToggleStatus(
        string id,
        WebhookToggleStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWebhookService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWebhookServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /v3/webhooks`, but is otherwise the
    /// same as <see cref="IWebhookService.Create(WebhookCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseWebhook>> Create(
        WebhookCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/webhooks/{id}`, but is otherwise the
    /// same as <see cref="IWebhookService.Retrieve(WebhookRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseWebhook>> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WebhookRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseWebhook>> Retrieve(
        string id,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /v3/webhooks/{id}`, but is otherwise the
    /// same as <see cref="IWebhookService.Update(WebhookUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseWebhook>> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WebhookUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseWebhook>> Update(
        string id,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/webhooks`, but is otherwise the
    /// same as <see cref="IWebhookService.List(WebhookListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookListResponse>> List(
        WebhookListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /v3/webhooks/{id}`, but is otherwise the
    /// same as <see cref="IWebhookService.Delete(WebhookDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(WebhookDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/webhooks/event-types`, but is otherwise the
    /// same as <see cref="IWebhookService.ListEventTypes(WebhookListEventTypesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookListEventTypesResponse>> ListEventTypes(
        WebhookListEventTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/webhooks/{id}/events`, but is otherwise the
    /// same as <see cref="IWebhookService.ListEvents(WebhookListEventsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookListEventsResponse>> ListEvents(
        WebhookListEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListEvents(WebhookListEventsParams, CancellationToken)"/>
    Task<HttpResponse<WebhookListEventsResponse>> ListEvents(
        string id,
        WebhookListEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v3/webhooks/{id}/rotate-secret`, but is otherwise the
    /// same as <see cref="IWebhookService.RotateSecret(WebhookRotateSecretParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookRotateSecretResponse>> RotateSecret(
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RotateSecret(WebhookRotateSecretParams, CancellationToken)"/>
    Task<HttpResponse<WebhookRotateSecretResponse>> RotateSecret(
        string id,
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v3/webhooks/{id}/test`, but is otherwise the
    /// same as <see cref="IWebhookService.Test(WebhookTestParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookTestResponse>> Test(
        WebhookTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(WebhookTestParams, CancellationToken)"/>
    Task<HttpResponse<WebhookTestResponse>> Test(
        string id,
        WebhookTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /v3/webhooks/{id}/toggle-status`, but is otherwise the
    /// same as <see cref="IWebhookService.ToggleStatus(WebhookToggleStatusParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseWebhook>> ToggleStatus(
        WebhookToggleStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ToggleStatus(WebhookToggleStatusParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseWebhook>> ToggleStatus(
        string id,
        WebhookToggleStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
