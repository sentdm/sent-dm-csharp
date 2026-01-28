using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Contacts;

namespace Sentdm.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IContactService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IContactServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IContactService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieves a paginated list of contacts for the authenticated customer. Supports
    /// server-side pagination with configurable page size. The customer ID is extracted
    /// from the authentication token.
    /// </summary>
    Task<ContactListResponse> List(
        ContactListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a contact by their phone number for the authenticated customer.
    /// Phone number should be in international format (e.g., +1234567890). The customer
    /// ID is extracted from the authentication token.
    /// </summary>
    Task<ContactListItem> RetrieveByPhone(
        ContactRetrieveByPhoneParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a specific contact by their unique identifier for the authenticated
    /// customer. The customer ID is extracted from the authentication token. Returns
    /// detailed contact information including phone number and creation timestamp.
    /// </summary>
    Task<ContactListItem> RetrieveID(
        ContactRetrieveIDParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IContactService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IContactServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IContactServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /v2/contacts`, but is otherwise the
    /// same as <see cref="IContactService.List(ContactListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ContactListResponse>> List(
        ContactListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v2/contacts/phone`, but is otherwise the
    /// same as <see cref="IContactService.RetrieveByPhone(ContactRetrieveByPhoneParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ContactListItem>> RetrieveByPhone(
        ContactRetrieveByPhoneParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v2/contacts/id`, but is otherwise the
    /// same as <see cref="IContactService.RetrieveID(ContactRetrieveIDParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ContactListItem>> RetrieveID(
        ContactRetrieveIDParams parameters,
        CancellationToken cancellationToken = default
    );
}
