using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Voice.Voices;

namespace Sentdm.Services.Voice;

/// <inheritdoc/>
public sealed class VoiceService : IVoiceService
{
    readonly Lazy<IVoiceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVoiceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public IVoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VoiceService(this._client.WithOptions(modifier));
    }

    public VoiceService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new VoiceServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfVoiceCatalogue> List(
        VoiceListParams? parameters = null,
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
public sealed class VoiceServiceWithRawResponse : IVoiceServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVoiceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VoiceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VoiceServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfVoiceCatalogue>> List(
        VoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<VoiceListParams> request = new()
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
