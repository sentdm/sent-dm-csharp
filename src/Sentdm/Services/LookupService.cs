using System;
using Sentdm.Core;

namespace Sentdm.Services;

/// <inheritdoc/>
public sealed class LookupService : ILookupService
{
    readonly Lazy<ILookupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILookupServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentDmClient _client;

    /// <inheritdoc/>
    public ILookupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LookupService(this._client.WithOptions(modifier));
    }

    public LookupService(ISentDmClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LookupServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class LookupServiceWithRawResponse : ILookupServiceWithRawResponse
{
    readonly ISentDmClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILookupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LookupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LookupServiceWithRawResponse(ISentDmClientWithRawResponse client)
    {
        _client = client;
    }
}
