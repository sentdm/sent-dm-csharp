using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Templates;

namespace Sentdm.Services;

/// <inheritdoc/>
public sealed class TemplateService : ITemplateService
{
    readonly Lazy<ITemplateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITemplateServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public ITemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TemplateService(this._client.WithOptions(modifier));
    }

    public TemplateService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TemplateServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<TemplateCreateResponse> Create(
        TemplateCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TemplateRetrieveResponse> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TemplateRetrieveResponse> Retrieve(
        string id,
        TemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TemplateUpdateResponse> Update(
        TemplateUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TemplateUpdateResponse> Update(
        string id,
        TemplateUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TemplateListResponse> List(
        TemplateListParams parameters,
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
        TemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        TemplateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TemplateServiceWithRawResponse : ITemplateServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITemplateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TemplateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TemplateServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TemplateCreateResponse>> Create(
        TemplateCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TemplateCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var template = await response
                    .Deserialize<TemplateCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    template.Validate();
                }
                return template;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TemplateRetrieveResponse>> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TemplateRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var template = await response
                    .Deserialize<TemplateRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    template.Validate();
                }
                return template;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TemplateRetrieveResponse>> Retrieve(
        string id,
        TemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TemplateUpdateResponse>> Update(
        TemplateUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TemplateUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var template = await response
                    .Deserialize<TemplateUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    template.Validate();
                }
                return template;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TemplateUpdateResponse>> Update(
        string id,
        TemplateUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TemplateListResponse>> List(
        TemplateListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TemplateListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var templates = await response
                    .Deserialize<TemplateListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    templates.Validate();
                }
                return templates;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        TemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TemplateDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        TemplateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }
}
