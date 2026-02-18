using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Lookup;

namespace Sentdm.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ILookupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILookupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILookupService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Validates a phone number and retrieves formatting, country, and timezone
    /// information from the internal index. Provider-agnostic and works for all customers.
    /// </summary>
    Task<LookupRetrievePhoneInfoResponse> RetrievePhoneInfo(
        LookupRetrievePhoneInfoParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrievePhoneInfo(LookupRetrievePhoneInfoParams, CancellationToken)"/>
    Task<LookupRetrievePhoneInfoResponse> RetrievePhoneInfo(
        string phoneNumber,
        LookupRetrievePhoneInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILookupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILookupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILookupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/lookup/number/{phoneNumber}`, but is otherwise the
    /// same as <see cref="ILookupService.RetrievePhoneInfo(LookupRetrievePhoneInfoParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LookupRetrievePhoneInfoResponse>> RetrievePhoneInfo(
        LookupRetrievePhoneInfoParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrievePhoneInfo(LookupRetrievePhoneInfoParams, CancellationToken)"/>
    Task<HttpResponse<LookupRetrievePhoneInfoResponse>> RetrievePhoneInfo(
        string phoneNumber,
        LookupRetrievePhoneInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
