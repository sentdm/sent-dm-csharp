using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Contacts;

namespace Sentdm.Services;

/// <summary>
/// Create, update, and manage customer contact lists
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
    /// Creates a new contact by phone number and associates it with the authenticated
    /// customer.
    /// </summary>
    Task<ApiResponseOfContact> Create(
        ContactCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a specific contact by their unique identifier. Returns detailed
    /// contact information including phone formats, available channels, and opt-out
    /// status.
    /// </summary>
    Task<ApiResponseOfContact> Retrieve(
        ContactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ContactRetrieveParams, CancellationToken)"/>
    Task<ApiResponseOfContact> Retrieve(
        string id,
        ContactRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a contact's default channel and/or opt-out status. Inherited contacts
    /// cannot be updated.
    /// </summary>
    Task<ApiResponseOfContact> Update(
        ContactUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ContactUpdateParams, CancellationToken)"/>
    Task<ApiResponseOfContact> Update(
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
    /// Dissociates a contact from the authenticated customer. Inherited contacts cannot
    /// be deleted.
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
    /// Returns a raw HTTP response for <c>post /v3/contacts</c>, but is otherwise the
    /// same as <see cref="IContactService.Create(ContactCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfContact>> Create(
        ContactCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/contacts/{id}</c>, but is otherwise the
    /// same as <see cref="IContactService.Retrieve(ContactRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfContact>> Retrieve(
        ContactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ContactRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfContact>> Retrieve(
        string id,
        ContactRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/contacts/{id}</c>, but is otherwise the
    /// same as <see cref="IContactService.Update(ContactUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfContact>> Update(
        ContactUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ContactUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfContact>> Update(
        string id,
        ContactUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/contacts</c>, but is otherwise the
    /// same as <see cref="IContactService.List(ContactListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ContactListResponse>> List(
        ContactListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/contacts/{id}</c>, but is otherwise the
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
