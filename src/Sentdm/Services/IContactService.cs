using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Contacts;

namespace Sentdm.Services;

/// <summary>
/// The people you message, and their channel identities.
///
/// <para>A contact holds one identity per channel — a phone number, a WhatsApp number
/// — so routing can choose between them for the same person. Opt-out is recorded
/// against the contact and honoured on every send, whichever channel it came through.</para>
///
/// <para>`GET /v3/contacts/{id}/message-summary` is the per-contact view of what
/// you have sent and what happened to it.</para>
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
        ContactCreateParams parameters,
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
    /// Updates a contact's default channel and/or opt-out status.
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
    Task<ContactListPage> List(
        ContactListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Deprecated.** Use `PATCH /v3/contacts/{id}` with `{"opt_out": true}` instead,
    /// and expect this to be removed in a future release. It still behaves exactly as
    /// before, so nothing needs to change today.
    ///
    /// <para>Opting a contact out stops every send to them, which is what deleting one
    /// was mostly used for — and it keeps the record of who they were and that they
    /// asked. A delete discards the consent history along with the contact, which is
    /// the part you need if anyone ever asks why you stopped, or why you started again.</para>
    ///
    /// <para>Dissociates a contact from the authenticated customer.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task Delete(ContactDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ContactDeleteParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task Delete(
        string id,
        ContactDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns aggregate message counts, time bounds, channels used, and per-channel
    /// success/fail scores (each as a percentage 0-100 of messages on that channel) for
    /// one of your contacts. Successful terminal states: SENT/DELIVERED/READ for
    /// outbound, RECEIVED for inbound. Fail: FAILED.
    /// </summary>
    Task<ApiResponseOfContactMessageSummary> RetrieveMessageSummary(
        ContactRetrieveMessageSummaryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMessageSummary(ContactRetrieveMessageSummaryParams, CancellationToken)"/>
    Task<ApiResponseOfContactMessageSummary> RetrieveMessageSummary(
        string contactID,
        ContactRetrieveMessageSummaryParams? parameters = null,
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
    /// same as <see cref="IContactService.Create(ContactCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfContact>> Create(
        ContactCreateParams parameters,
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
    /// same as <see cref="IContactService.List(ContactListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ContactListPage>> List(
        ContactListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/contacts/{id}</c>, but is otherwise the
    /// same as <see cref="IContactService.Delete(ContactDeleteParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse> Delete(
        ContactDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ContactDeleteParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse> Delete(
        string id,
        ContactDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/contacts/{contactId}/message-summary</c>, but is otherwise the
    /// same as <see cref="IContactService.RetrieveMessageSummary(ContactRetrieveMessageSummaryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfContactMessageSummary>> RetrieveMessageSummary(
        ContactRetrieveMessageSummaryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMessageSummary(ContactRetrieveMessageSummaryParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfContactMessageSummary>> RetrieveMessageSummary(
        string contactID,
        ContactRetrieveMessageSummaryParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
