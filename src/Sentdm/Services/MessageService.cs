using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Messages;

namespace Sentdm.Services;

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
    public async Task<MessageRetrieveResponse> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MessageRetrieveResponse> Retrieve(
        string id,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task SendQuickMessage(
        MessageSendQuickMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.SendQuickMessage(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task SendToContact(
        MessageSendToContactParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.SendToContact(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task SendToPhone(
        MessageSendToPhoneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.SendToPhone(parameters, cancellationToken);
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
    public async Task<HttpResponse<MessageRetrieveResponse>> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentDmInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<MessageRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var message = await response
                    .Deserialize<MessageRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    message.Validate();
                }
                return message;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MessageRetrieveResponse>> Retrieve(
        string id,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SendQuickMessage(
        MessageSendQuickMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessageSendQuickMessageParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SendToContact(
        MessageSendToContactParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessageSendToContactParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SendToPhone(
        MessageSendToPhoneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessageSendToPhoneParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
