using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Voice.Tokens;

namespace Sentdm.Services.Voice;

/// <inheritdoc/>
public sealed class TokenService : ITokenService
{
    readonly Lazy<ITokenServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITokenServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public ITokenService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TokenService(this._client.WithOptions(modifier));
    }

    public TokenService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TokenServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfVoiceToken> Create(
        TokenCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TokenServiceWithRawResponse : ITokenServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITokenServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TokenServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TokenServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfVoiceToken>> Create(
        TokenCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TokenCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfVoiceToken = await response
                    .Deserialize<ApiResponseOfVoiceToken>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfVoiceToken.Validate();
                }
                return apiResponseOfVoiceToken;
            }
        );
    }
}
