using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Messages;

namespace Sentdm.Services;

/// <summary>
/// Send a message and follow what happened to it.
///
/// <para>One endpoint sends on any channel: pass `channel: "sent"` and we pick between
/// SMS, WhatsApp and RCS per recipient using your routing rules, or name a channel
/// to pin it. A send is accepted asynchronously — `POST /v3/messages` returns an
/// id, and delivery is reported through `GET /v3/messages/{id}`, its activities,
/// or a webhook.</para>
///
/// <para>**A message needs a sender.** What you can send, where, and at what cost
/// is decided by the markets under **Channels** — so a recipient in a country you
/// hold no sender for is refused here rather than queued.</para>
///
/// <para>**A message can be resent on its id.** `POST /v3/messages/{id}/resend`
/// puts a finished message — typically one BLOCKED for insufficient balance — back
/// through the send pipeline. It is a new attempt, not a free retry: every policy
/// runs again, the message is billed again, and its status webhooks fire again. A
/// FILTERED message is never resendable.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
    /// lifecycle including acceptance, processing, sending, delivery, and any errors. A
    /// SCHEDULED entry carries scheduled_at, the release instant in UTC as it stood at
    /// that moment. Other entries have no scheduled_at key.
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
    /// status, timestamps, and error information if applicable. A message that is or
    /// was held for a later time (a send you scheduled with scheduled_at, or a
    /// quiet-hours hold) is returned as a ScheduledMessageResponse: the same fields
    /// plus scheduled_at, the release instant in UTC. A message sent immediately has no
    /// scheduled_at key.
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
    /// Sends a message to one or more recipients using a template. Supports
    /// multi-channel broadcast — when multiple channels are specified (e.g. ["sms",
    /// "whatsapp"]), a separate message is created for each (recipient, channel) pair.
    /// Returns immediately with per-recipient message IDs for async tracking via
    /// webhooks or the GET /messages/{id} endpoint. Sends gated before any delivery
    /// attempt do not reject the request — an account-level precondition such as
    /// insufficient balance, a template not approved for sending, or free-form content
    /// with no open conversation with the contact. The send is accepted with 202 and
    /// the affected messages are reported as BLOCKED on GET /messages/{id} and the
    /// message.blocked webhook. To send later, set scheduled_at (ISO-8601 with an
    /// explicit UTC offset; a value without one is rejected) between 1 minute and 30
    /// days ahead: the response is a ScheduledSendMessageResponse (the same fields plus
    /// scheduled_at; status is still QUEUED), each message then moves to SCHEDULED, is
    /// held and released at that time (within a few minutes), and a message.scheduled
    /// webhook fires once it is held. Balance and template approval are evaluated at
    /// release, not at acceptance. Quiet hours are not checked when the request is
    /// accepted: if the time falls inside a legally protected quiet-hours window for a
    /// recipient, that message is moved to the next allowed time at release and a
    /// second message.scheduled webhook reports the new scheduled_at. An account may
    /// hold at most 1,000,000 scheduled messages at once (429 LIMIT_001).
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
    /// Returns a raw HTTP response for <c>get /v3/messages/{id}/activities</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>get /v3/messages/{id}</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>post /v3/messages</c>, but is otherwise the
    /// same as <see cref="IMessageService.Send(MessageSendParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageSendResponse>> Send(
        MessageSendParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
