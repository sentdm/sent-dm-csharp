using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SentDm.Core;
using SentDm.Exceptions;
using SentDm.Models.Webhooks;

namespace SentDm.Services;

/// <inheritdoc/>
public sealed class WebhookService : IWebhookService
{
    readonly Lazy<IWebhookServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentDmClient _client;

    /// <inheritdoc/>
    public IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookService(this._client.WithOptions(modifier));
    }

    public WebhookService(ISentDmClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WebhookServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ApiResponseWebhook> Create(
        WebhookCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseWebhook> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseWebhook> Retrieve(
        string id,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseWebhook> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseWebhook> Update(
        string id,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhookListResponse> List(
        WebhookListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WebhookListEventTypesResponse> ListEventTypes(
        WebhookListEventTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListEventTypes(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WebhookListEventsResponse> ListEvents(
        WebhookListEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListEvents(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WebhookListEventsResponse> ListEvents(
        string id,
        WebhookListEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListEvents(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhookRotateSecretResponse> RotateSecret(
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RotateSecret(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WebhookRotateSecretResponse> RotateSecret(
        string id,
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RotateSecret(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhookTestResponse> Test(
        WebhookTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Test(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WebhookTestResponse> Test(
        string id,
        WebhookTestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Test(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseWebhook> ToggleStatus(
        WebhookToggleStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ToggleStatus(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseWebhook> ToggleStatus(
        string id,
        WebhookToggleStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ToggleStatus(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WebhookServiceWithRawResponse : IWebhookServiceWithRawResponse
{
    readonly ISentDmClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WebhookServiceWithRawResponse(ISentDmClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseWebhook>> Create(
        WebhookCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WebhookCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseWebhook = await response
                    .Deserialize<ApiResponseWebhook>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseWebhook.Validate();
                }
                return apiResponseWebhook;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseWebhook>> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentDmInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<WebhookRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseWebhook = await response
                    .Deserialize<ApiResponseWebhook>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseWebhook.Validate();
                }
                return apiResponseWebhook;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseWebhook>> Retrieve(
        string id,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseWebhook>> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentDmInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<WebhookUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseWebhook = await response
                    .Deserialize<ApiResponseWebhook>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseWebhook.Validate();
                }
                return apiResponseWebhook;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseWebhook>> Update(
        string id,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookListResponse>> List(
        WebhookListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WebhookListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhooks = await response
                    .Deserialize<WebhookListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    webhooks.Validate();
                }
                return webhooks;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentDmInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<WebhookDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookListEventTypesResponse>> ListEventTypes(
        WebhookListEventTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WebhookListEventTypesParams> request = new()
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
                    .Deserialize<WebhookListEventTypesResponse>(token)
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
    public async Task<HttpResponse<WebhookListEventsResponse>> ListEvents(
        WebhookListEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentDmInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<WebhookListEventsParams> request = new()
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
                    .Deserialize<WebhookListEventsResponse>(token)
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
    public Task<HttpResponse<WebhookListEventsResponse>> ListEvents(
        string id,
        WebhookListEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListEvents(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookRotateSecretResponse>> RotateSecret(
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentDmInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<WebhookRotateSecretParams> request = new()
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
                    .Deserialize<WebhookRotateSecretResponse>(token)
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
    public Task<HttpResponse<WebhookRotateSecretResponse>> RotateSecret(
        string id,
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RotateSecret(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookTestResponse>> Test(
        WebhookTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentDmInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<WebhookTestParams> request = new()
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
                    .Deserialize<WebhookTestResponse>(token)
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
    public Task<HttpResponse<WebhookTestResponse>> Test(
        string id,
        WebhookTestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Test(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseWebhook>> ToggleStatus(
        WebhookToggleStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentDmInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<WebhookToggleStatusParams> request = new()
        {
            Method = SentDmClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseWebhook = await response
                    .Deserialize<ApiResponseWebhook>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseWebhook.Validate();
                }
                return apiResponseWebhook;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseWebhook>> ToggleStatus(
        string id,
        WebhookToggleStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ToggleStatus(parameters with { ID = id }, cancellationToken);
    }
}
