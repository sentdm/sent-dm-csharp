using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Channels.Voice;

namespace Sentdm.Services.Channels;

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
    public async Task<ApiResponseOfVoiceNumberCreated> Create(
        VoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfVoiceNumber> Retrieve(
        VoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfVoiceNumber> Retrieve(
        string number,
        VoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { Number = number }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfVoiceNumber> Update(
        VoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfVoiceNumber> Update(
        string number,
        VoiceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { Number = number }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfListOfVoiceNumber> List(
        VoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfVoiceToken> CreateToken(
        VoiceCreateTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateToken(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfVoiceSecret> RotateSecret(
        VoiceRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RotateSecret(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfVoiceSecret> RotateSecret(
        string number,
        VoiceRotateSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RotateSecret(parameters with { Number = number }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfVoiceCallbackTest> Test(
        VoiceTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Test(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfVoiceCallbackTest> Test(
        string number,
        VoiceTestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Test(parameters with { Number = number }, cancellationToken);
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
    public async Task<HttpResponse<ApiResponseOfVoiceNumberCreated>> Create(
        VoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VoiceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfVoiceNumberCreated = await response
                    .Deserialize<ApiResponseOfVoiceNumberCreated>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfVoiceNumberCreated.Validate();
                }
                return apiResponseOfVoiceNumberCreated;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfVoiceNumber>> Retrieve(
        VoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Number == null)
        {
            throw new SentInvalidDataException("'parameters.Number' cannot be null");
        }

        HttpRequest<VoiceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfVoiceNumber = await response
                    .Deserialize<ApiResponseOfVoiceNumber>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfVoiceNumber.Validate();
                }
                return apiResponseOfVoiceNumber;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfVoiceNumber>> Retrieve(
        string number,
        VoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { Number = number }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfVoiceNumber>> Update(
        VoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Number == null)
        {
            throw new SentInvalidDataException("'parameters.Number' cannot be null");
        }

        HttpRequest<VoiceUpdateParams> request = new()
        {
            Method = SentClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfVoiceNumber = await response
                    .Deserialize<ApiResponseOfVoiceNumber>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfVoiceNumber.Validate();
                }
                return apiResponseOfVoiceNumber;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfVoiceNumber>> Update(
        string number,
        VoiceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { Number = number }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfListOfVoiceNumber>> List(
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
                var apiResponseOfListOfVoiceNumber = await response
                    .Deserialize<ApiResponseOfListOfVoiceNumber>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfListOfVoiceNumber.Validate();
                }
                return apiResponseOfListOfVoiceNumber;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfVoiceToken>> CreateToken(
        VoiceCreateTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<VoiceCreateTokenParams> request = new()
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

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfVoiceSecret>> RotateSecret(
        VoiceRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Number == null)
        {
            throw new SentInvalidDataException("'parameters.Number' cannot be null");
        }

        HttpRequest<VoiceRotateSecretParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfVoiceSecret = await response
                    .Deserialize<ApiResponseOfVoiceSecret>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfVoiceSecret.Validate();
                }
                return apiResponseOfVoiceSecret;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfVoiceSecret>> RotateSecret(
        string number,
        VoiceRotateSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RotateSecret(parameters with { Number = number }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfVoiceCallbackTest>> Test(
        VoiceTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Number == null)
        {
            throw new SentInvalidDataException("'parameters.Number' cannot be null");
        }

        HttpRequest<VoiceTestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfVoiceCallbackTest = await response
                    .Deserialize<ApiResponseOfVoiceCallbackTest>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfVoiceCallbackTest.Validate();
                }
                return apiResponseOfVoiceCallbackTest;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfVoiceCallbackTest>> Test(
        string number,
        VoiceTestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Test(parameters with { Number = number }, cancellationToken);
    }
}
