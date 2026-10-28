using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Voice.Catalogue;

namespace Sentdm.Services.Voice;

/// <inheritdoc/>
public sealed class CatalogueService : ICatalogueService
{
    readonly Lazy<ICatalogueServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICatalogueServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public ICatalogueService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CatalogueService(this._client.WithOptions(modifier));
    }

    public CatalogueService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CatalogueServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfVoiceCatalogue> List(
        CatalogueListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CatalogueServiceWithRawResponse : ICatalogueServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICatalogueServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CatalogueServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CatalogueServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfVoiceCatalogue>> List(
        CatalogueListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CatalogueListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfVoiceCatalogue = await response
                    .Deserialize<ApiResponseOfVoiceCatalogue>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfVoiceCatalogue.Validate();
                }
                return apiResponseOfVoiceCatalogue;
            }
        );
    }
}
