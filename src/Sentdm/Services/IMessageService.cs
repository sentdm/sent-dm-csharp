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
    /// Retrieves comprehensive details about a specific message using the message
    /// ID. Returns complete message data including delivery status, channel information,
    /// template details, contact information, and pricing. The customer ID is extracted
    /// from the authentication token to ensure the message belongs to the authenticated customer.
    /// </summary>
    Task<MessageRetrieveResponse> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MessageRetrieveParams, CancellationToken)"/>
    Task<MessageRetrieveResponse> Retrieve(
        string id,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a message to a phone number using the default template. This endpoint
    /// is rate limited to 5 messages per customer per day. The customer ID is extracted
    /// from the authentication token.
    /// </summary>
    Task SendQuickMessage(
        MessageSendQuickMessageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a message to a specific contact using a template. The message can be
    /// sent via SMS or WhatsApp depending on the contact's capabilities. Optionally
    /// specify a webhook URL to receive delivery status updates. The customer ID
    /// is extracted from the authentication token.
    /// </summary>
    Task SendToContact(
        MessageSendToContactParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a message to a phone number using a template. The phone number doesn't
    /// need to be a pre-existing contact. The message can be sent via SMS or WhatsApp.
    /// Optionally specify a webhook URL to receive delivery status updates. The
    /// customer ID is extracted from the authentication token.
    /// </summary>
    Task SendToPhone(
        MessageSendToPhoneParams parameters,
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
    /// Returns a raw HTTP response for `get /v2/messages/{id}`, but is otherwise the
    /// same as <see cref="IMessageService.Retrieve(MessageRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageRetrieveResponse>> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MessageRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MessageRetrieveResponse>> Retrieve(
        string id,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v2/messages/quick-message`, but is otherwise the
    /// same as <see cref="IMessageService.SendQuickMessage(MessageSendQuickMessageParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> SendQuickMessage(
        MessageSendQuickMessageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v2/messages/contact`, but is otherwise the
    /// same as <see cref="IMessageService.SendToContact(MessageSendToContactParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> SendToContact(
        MessageSendToContactParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v2/messages/phone`, but is otherwise the
    /// same as <see cref="IMessageService.SendToPhone(MessageSendToPhoneParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> SendToPhone(
        MessageSendToPhoneParams parameters,
        CancellationToken cancellationToken = default
    );
}
