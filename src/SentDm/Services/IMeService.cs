using System;
using System.Threading;
using System.Threading.Tasks;
using SentDm.Core;
using SentDm.Models.Me;

namespace SentDm.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns the account associated with the API key. For organization API keys,
    /// returns the organization with its profiles. For profile API keys, returns
    /// the profile with its settings.
    /// </summary>
    Task<MeRetrieveResponse> Retrieve(
        MeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/me`, but is otherwise the
    /// same as <see cref="IMeService.Retrieve(MeRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MeRetrieveResponse>> Retrieve(
        MeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
