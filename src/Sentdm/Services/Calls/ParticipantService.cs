using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Calls;
using Sentdm.Models.Calls.Participants;

namespace Sentdm.Services.Calls;

/// <inheritdoc/>
public sealed class ParticipantService : IParticipantService
{
    readonly Lazy<IParticipantServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IParticipantServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public IParticipantService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ParticipantService(this._client.WithOptions(modifier));
    }

    public ParticipantService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ParticipantServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Update(
        ParticipantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string participantID,
        ParticipantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { ParticipantID = participantID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfListOfCallParticipant> List(
        ParticipantListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfListOfCallParticipant> List(
        string id,
        ParticipantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfCall> Add(
        ParticipantAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfCall> Add(
        string id,
        ParticipantAddParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Add(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Remove(
        ParticipantRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Remove(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Remove(
        string participantID,
        ParticipantRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Remove(parameters with { ParticipantID = participantID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task RemoveAll(
        ParticipantRemoveAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RemoveAll(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task RemoveAll(
        string id,
        ParticipantRemoveAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.RemoveAll(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ParticipantServiceWithRawResponse : IParticipantServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public IParticipantServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ParticipantServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ParticipantServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        ParticipantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ParticipantID == null)
        {
            throw new SentInvalidDataException("'parameters.ParticipantID' cannot be null");
        }

        HttpRequest<ParticipantUpdateParams> request = new()
        {
            Method = SentClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string participantID,
        ParticipantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ParticipantID = participantID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfListOfCallParticipant>> List(
        ParticipantListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ParticipantListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfListOfCallParticipant = await response
                    .Deserialize<ApiResponseOfListOfCallParticipant>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfListOfCallParticipant.Validate();
                }
                return apiResponseOfListOfCallParticipant;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfListOfCallParticipant>> List(
        string id,
        ParticipantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfCall>> Add(
        ParticipantAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ParticipantAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfCall = await response
                    .Deserialize<ApiResponseOfCall>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfCall.Validate();
                }
                return apiResponseOfCall;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfCall>> Add(
        string id,
        ParticipantAddParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Add(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Remove(
        ParticipantRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ParticipantID == null)
        {
            throw new SentInvalidDataException("'parameters.ParticipantID' cannot be null");
        }

        HttpRequest<ParticipantRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Remove(
        string participantID,
        ParticipantRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { ParticipantID = participantID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RemoveAll(
        ParticipantRemoveAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ParticipantRemoveAllParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RemoveAll(
        string id,
        ParticipantRemoveAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RemoveAll(parameters with { ID = id }, cancellationToken);
    }
}
