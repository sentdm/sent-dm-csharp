using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Calls;
using Sentdm.Services.Calls;

namespace Sentdm.Services;

/// <inheritdoc/>
public sealed class CallService : ICallService
{
    readonly Lazy<ICallServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICallServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public ICallService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CallService(this._client.WithOptions(modifier));
    }

    public CallService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CallServiceWithRawResponse(client.WithRawResponse));
        _participants = new(() => new ParticipantService(client));
    }

    readonly Lazy<IParticipantService> _participants;
    public IParticipantService Participants
    {
        get { return _participants.Value; }
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfCall> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfCall> Retrieve(
        string id,
        CallRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CallListPage> List(
        CallListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Hangup(CallHangupParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Hangup(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Hangup(
        string id,
        CallHangupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Hangup(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfCallRecordings> ListRecordings(
        CallListRecordingsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListRecordings(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfCallRecordings> ListRecordings(
        string id,
        CallListRecordingsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListRecordings(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Record(CallRecordParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Record(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Record(
        string id,
        CallRecordParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Record(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CallServiceWithRawResponse : ICallServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICallServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CallServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CallServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;

        _participants = new(() => new ParticipantServiceWithRawResponse(client));
    }

    readonly Lazy<IParticipantServiceWithRawResponse> _participants;
    public IParticipantServiceWithRawResponse Participants
    {
        get { return _participants.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfCall>> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CallRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
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
    public Task<HttpResponse<ApiResponseOfCall>> Retrieve(
        string id,
        CallRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallListPage>> List(
        CallListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CallListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<ApiResponseOfCallsList>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CallListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Hangup(
        CallHangupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CallHangupParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Hangup(
        string id,
        CallHangupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Hangup(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfCallRecordings>> ListRecordings(
        CallListRecordingsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CallListRecordingsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfCallRecordings = await response
                    .Deserialize<ApiResponseOfCallRecordings>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfCallRecordings.Validate();
                }
                return apiResponseOfCallRecordings;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfCallRecordings>> ListRecordings(
        string id,
        CallListRecordingsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListRecordings(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Record(
        CallRecordParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SentInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CallRecordParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Record(
        string id,
        CallRecordParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Record(parameters with { ID = id }, cancellationToken);
    }
}
