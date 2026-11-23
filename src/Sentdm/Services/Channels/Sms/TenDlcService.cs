using System;
using Sentdm.Core;

namespace Sentdm.Services.Channels.Sms;

/// <inheritdoc/>
public sealed class TenDlcService : ITenDlcService
{
    readonly Lazy<ITenDlcServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITenDlcServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public ITenDlcService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TenDlcService(this._client.WithOptions(modifier));
    }

    public TenDlcService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TenDlcServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class TenDlcServiceWithRawResponse : ITenDlcServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITenDlcServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TenDlcServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TenDlcServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;
    }
}
