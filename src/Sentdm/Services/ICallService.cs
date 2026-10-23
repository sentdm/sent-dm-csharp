using System;
using Sentdm.Core;
using Sentdm.Services.Calls;

namespace Sentdm.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICallService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICallServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IParticipantService Participants { get; }
}

/// <summary>
/// A view of <see cref="ICallService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICallServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IParticipantServiceWithRawResponse Participants { get; }
}
