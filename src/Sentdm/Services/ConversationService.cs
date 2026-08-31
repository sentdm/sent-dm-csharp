using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Conversations;

namespace Sentdm.Services;

/// <inheritdoc/>
public sealed class ConversationService : IConversationService
{
    readonly Lazy<IConversationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IConversationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public IConversationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ConversationService(this._client.WithOptions(modifier));
    }

    public ConversationService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ConversationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<ConversationListResponse> List(
        ConversationListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ConversationListMessagesResponse> ListMessages(
        ConversationListMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListMessages(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ConversationListMessagesResponse> ListMessages(
        string id,
        ConversationListMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListMessages(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ConversationServiceWithRawResponse : IConversationServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public IConversationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ConversationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ConversationServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConversationListResponse>> List(
        ConversationListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ConversationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var conversations = await response
                    .Deserialize<ConversationListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    conversations.Validate();
                }
                return conversations;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConversationListMessagesResponse>> ListMessages(
        ConversationListMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ConversationListMessagesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ConversationListMessagesResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ConversationListMessagesResponse>> ListMessages(
        string id,
        ConversationListMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListMessages(parameters with { ID = id }, cancellationToken);
    }
}
