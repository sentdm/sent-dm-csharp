using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SentDm.Core;
using SentDm.Exceptions;
using SentDm.Models.Messages;

namespace SentDm.Services;

/// <inheritdoc/>
public sealed class MessageService : IMessageService
{
    readonly Lazy<IMessageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessageServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentDmClient _client;

    /// <inheritdoc/>
    public IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MessageService(this._client.WithOptions(modifier));
    }

    public MessageService(ISentDmClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MessageServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<MessageRetrieveActivitiesResponse> RetrieveActivities(
        MessageRetrieveActivitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveActivities(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MessageRetrieveActivitiesResponse> RetrieveActivities(
        string id,
        MessageRetrieveActivitiesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveActivities(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessageRetrieveStatusResponse> RetrieveStatus(
        MessageRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveStatus(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MessageRetrieveStatusResponse> RetrieveStatus(
        string id,
        MessageRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveStatus(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessageSendResponse> Send(
        MessageSendParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Send(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MessageServiceWithRawResponse : IMessageServiceWithRawResponse
{
    readonly ISentDmClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MessageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MessageServiceWithRawResponse(ISentDmClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageRetrieveActivitiesResponse>> RetrieveActivities(
        MessageRetrieveActivitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentDmInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<MessageRetrieveActivitiesParams> request = new()
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
                    .Deserialize<MessageRetrieveActivitiesResponse>(token)
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
    public Task<HttpResponse<MessageRetrieveActivitiesResponse>> RetrieveActivities(
        string id,
        MessageRetrieveActivitiesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveActivities(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageRetrieveStatusResponse>> RetrieveStatus(
        MessageRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentDmInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<MessageRetrieveStatusParams> request = new()
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
                    .Deserialize<MessageRetrieveStatusResponse>(token)
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
    public Task<HttpResponse<MessageRetrieveStatusResponse>> RetrieveStatus(
        string id,
        MessageRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveStatus(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageSendResponse>> Send(
        MessageSendParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MessageSendParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<MessageSendResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
