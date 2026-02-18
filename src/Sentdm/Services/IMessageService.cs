using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Messages;

namespace Sentdm.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieves the activity log for a specific message. Activities track the message
    /// lifecycle including acceptance, processing, sending, delivery, and any errors.
    /// </summary>
    Task<MessageRetrieveActivitiesResponse> RetrieveActivities(
        MessageRetrieveActivitiesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveActivities(MessageRetrieveActivitiesParams, CancellationToken)"/>
    Task<MessageRetrieveActivitiesResponse> RetrieveActivities(
        string id,
        MessageRetrieveActivitiesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the current status and details of a message by ID. Includes delivery
    /// status, timestamps, and error information if applicable.
    /// </summary>
    Task<MessageRetrieveStatusResponse> RetrieveStatus(
        MessageRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveStatus(MessageRetrieveStatusParams, CancellationToken)"/>
    Task<MessageRetrieveStatusResponse> RetrieveStatus(
        string id,
        MessageRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a message to one or more recipients using a template. Supports multi-channel
    /// broadcast — when multiple channels are specified (e.g. ["sms", "whatsapp"]),
    /// a separate message is created for each (recipient, channel) pair. Returns
    /// immediately with per-recipient message IDs for async tracking via webhooks
    /// or the GET /messages/{id} endpoint.
    /// </summary>
    Task<MessageSendResponse> Send(
        MessageSendParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMessageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/messages/{id}/activities`, but is otherwise the
    /// same as <see cref="IMessageService.RetrieveActivities(MessageRetrieveActivitiesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageRetrieveActivitiesResponse>> RetrieveActivities(
        MessageRetrieveActivitiesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveActivities(MessageRetrieveActivitiesParams, CancellationToken)"/>
    Task<HttpResponse<MessageRetrieveActivitiesResponse>> RetrieveActivities(
        string id,
        MessageRetrieveActivitiesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/messages/{id}`, but is otherwise the
    /// same as <see cref="IMessageService.RetrieveStatus(MessageRetrieveStatusParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageRetrieveStatusResponse>> RetrieveStatus(
        MessageRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveStatus(MessageRetrieveStatusParams, CancellationToken)"/>
    Task<HttpResponse<MessageRetrieveStatusResponse>> RetrieveStatus(
        string id,
        MessageRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v3/messages`, but is otherwise the
    /// same as <see cref="IMessageService.Send(MessageSendParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageSendResponse>> Send(
        MessageSendParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
