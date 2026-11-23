using System;
using Sentdm.Core;

namespace Sentdm.Services.Channels.Sms;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITenDlcService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITenDlcServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITenDlcService WithOptions(Func<ClientOptions, ClientOptions> modifier);
}

/// <summary>
/// A view of <see cref="ITenDlcService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITenDlcServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITenDlcServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);
}
