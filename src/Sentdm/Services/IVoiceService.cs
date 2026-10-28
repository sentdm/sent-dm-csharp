using System;
using Sentdm.Core;
using Voice = Sentdm.Services.Voice;

namespace Sentdm.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IVoiceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVoiceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Voice::ICallService Calls { get; }

    Voice::ITokenService Tokens { get; }

    Voice::IAgentService Agents { get; }

    Voice::IVoiceService Voices { get; }
}

/// <summary>
/// A view of <see cref="IVoiceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVoiceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoiceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Voice::ICallServiceWithRawResponse Calls { get; }

    Voice::ITokenServiceWithRawResponse Tokens { get; }

    Voice::IAgentServiceWithRawResponse Agents { get; }

    Voice::IVoiceServiceWithRawResponse Voices { get; }
}
