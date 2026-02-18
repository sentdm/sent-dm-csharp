using System;
using System.Threading;
using System.Threading.Tasks;
using SentDm.Core;
using SentDm.Models.Contacts;

namespace SentDm.Services;

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
    /// Creates a new contact by phone number and associates it with the authenticated customer.
    /// </summary>
    Task<ApiResponseContact> Create(
        ContactCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a specific contact by their unique identifier. Returns detailed
    /// contact information including phone formats, available channels, and opt-out status.
    /// </summary>
    Task<ApiResponseContact> Retrieve(
        ContactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ContactRetrieveParams, CancellationToken)"/>
    Task<ApiResponseContact> Retrieve(
        string id,
        ContactRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a contact's default channel and/or opt-out status. Inherited contacts
    /// cannot be updated.
    /// </summary>
    Task<ApiResponseContact> Update(
        ContactUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ContactUpdateParams, CancellationToken)"/>
    Task<ApiResponseContact> Update(
        string id,
        ContactUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of contacts for the authenticated customer. Supports
    /// filtering by search term, channel, or phone number.
    /// </summary>
    Task<ContactListResponse> List(
        ContactListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Dissociates a contact from the authenticated customer. Inherited contacts
    /// cannot be deleted.
    /// </summary>
    Task Delete(ContactDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ContactDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        ContactDeleteParams parameters,
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
    /// Returns a raw HTTP response for `post /v3/contacts`, but is otherwise the
    /// same as <see cref="IContactService.Create(ContactCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseContact>> Create(
        ContactCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/contacts/{id}`, but is otherwise the
    /// same as <see cref="IContactService.Retrieve(ContactRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseContact>> Retrieve(
        ContactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ContactRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseContact>> Retrieve(
        string id,
        ContactRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /v3/contacts/{id}`, but is otherwise the
    /// same as <see cref="IContactService.Update(ContactUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseContact>> Update(
        ContactUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ContactUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseContact>> Update(
        string id,
        ContactUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v3/contacts`, but is otherwise the
    /// same as <see cref="IContactService.List(ContactListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ContactListResponse>> List(
        ContactListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /v3/contacts/{id}`, but is otherwise the
    /// same as <see cref="IContactService.Delete(ContactDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ContactDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ContactDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        ContactDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
