using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Numbers;

namespace Sentdm.Services;

/// <summary>
/// What a phone number actually is, before you send to it.
///
/// <para>A lookup returns the number's country, line type and carrier, which is
/// what decides whether it is reachable on a channel and what it costs. Worth doing
/// on import rather than on send: a landline in a contact list is a message that
/// can never be delivered.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieves detailed information about a phone number including carrier, line
    /// type, porting status, and VoIP detection. Uses the customer's messaging provider
    /// for rich data, with fallback to the internal index.
    /// </summary>
    Task<NumberLookupResponse> Lookup(
        NumberLookupParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Lookup(NumberLookupParams, CancellationToken)"/>
    Task<NumberLookupResponse> Lookup(
        string phoneNumber,
        NumberLookupParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="INumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/numbers/lookup/{phoneNumber}</c>, but is otherwise the
    /// same as <see cref="INumberService.Lookup(NumberLookupParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NumberLookupResponse>> Lookup(
        NumberLookupParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Lookup(NumberLookupParams, CancellationToken)"/>
    Task<HttpResponse<NumberLookupResponse>> Lookup(
        string phoneNumber,
        NumberLookupParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
