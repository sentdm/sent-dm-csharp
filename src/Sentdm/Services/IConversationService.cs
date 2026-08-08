using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Conversations;

namespace Sentdm.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IConversationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IConversationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConversationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieves a paginated list of the authenticated customer's messages across all
    /// conversations, ordered by created date (most recent first).
    /// </summary>
    Task<ApiResponseOfConversationMessagesList> List(
        ConversationListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of the messages in a single conversation (scoped to
    /// the authenticated customer), ordered by created date (most recent first).
    /// </summary>
    Task<ApiResponseOfConversationMessagesList> ListMessages(
        ConversationListMessagesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListMessages(ConversationListMessagesParams, CancellationToken)"/>
    Task<ApiResponseOfConversationMessagesList> ListMessages(
        string id,
        ConversationListMessagesParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IConversationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IConversationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConversationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/conversations</c>, but is otherwise the
    /// same as <see cref="IConversationService.List(ConversationListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfConversationMessagesList>> List(
        ConversationListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/conversations/{id}</c>, but is otherwise the
    /// same as <see cref="IConversationService.ListMessages(ConversationListMessagesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfConversationMessagesList>> ListMessages(
        ConversationListMessagesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListMessages(ConversationListMessagesParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfConversationMessagesList>> ListMessages(
        string id,
        ConversationListMessagesParams parameters,
        CancellationToken cancellationToken = default
    );
}
