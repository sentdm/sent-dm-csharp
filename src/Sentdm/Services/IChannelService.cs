using System;
using Sentdm.Core;
using Sentdm.Services.Channels;

namespace Sentdm.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IChannelService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IChannelServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChannelService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IVoiceService Voice { get; }
}

/// <summary>
/// A view of <see cref="IChannelService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IChannelServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChannelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IVoiceServiceWithRawResponse Voice { get; }
}
