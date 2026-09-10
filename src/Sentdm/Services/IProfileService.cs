using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Profiles;
using Sentdm.Services.Profiles;

namespace Sentdm.Services;

/// <summary>
/// **Deprecated — use Sender Profiles.**
///
/// <para>The original profile resource, kept because it has live callers. It still
/// works, and its replacement is `/v3/sender-profiles`, which takes the identity
/// and the campaign in one call instead of across three.</para>
///
/// <para>New integrations should not start here.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProfileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICampaignService Campaigns { get; }

    /// <summary>
    /// **Deprecated.** This endpoint is replaced by `/v3/sender-profiles` and will be
    /// removed in a future release. It still behaves exactly as before, so nothing
    /// needs to change today — but new integrations should use `/v3/sender-profiles`,
    /// which models a profile's markets, compliance, brand, campaigns and billing
    /// explicitly.
    ///
    /// <para>Creates a new sender profile within an organization. Profiles represent
    /// different brands, departments, or use cases, each with their own messaging
    /// configuration and settings. Requires admin role in the organization.</para>
    ///
    /// <para>## WhatsApp Business Account</para>
    ///
    /// <para>Every profile owns its own WhatsApp Business Account — accounts are never
    /// shared between profiles or inherited from the organization. Provide a
    /// `whatsapp_business_account` object with `waba_id`, `phone_number_id`, and
    /// `access_token`. Obtain these from Meta Business Manager by creating a System
    /// User with `whatsapp_business_messaging` and `whatsapp_business_management`
    /// permissions.</para>
    ///
    /// <para>Omit the field and the profile is created without WhatsApp, staying
    /// incomplete until it has an account of its own.</para>
    ///
    /// <para>## Brand</para>
    ///
    /// <para>Include the optional `brand` field to create the brand for this profile at
    /// the same time. Cannot be used when `inherit_tcr_brand` is `true`.</para>
    ///
    /// <para>## Payment Details</para>
    ///
    /// <para>When `billing_model` is `"profile"` or `"profile_and_organization"` you
    /// may include a `payment_details` object containing the card number, expiry
    /// (MM/YY), CVC, and billing ZIP code. Payment details are **never stored** on our
    /// servers and are forwarded directly to the payment processor. Providing
    /// `payment_details` when `billing_model` is `"organization"` is not allowed.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<ApiResponseOfProfileDetail> Create(
        ProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Deprecated.** This endpoint is replaced by `/v3/sender-profiles` and will be
    /// removed in a future release. It still behaves exactly as before, so nothing
    /// needs to change today — but new integrations should use `/v3/sender-profiles`,
    /// which models a profile's markets, compliance, brand, campaigns and billing
    /// explicitly.
    ///
    /// <para>Retrieves detailed information about a specific sender profile within an
    /// organization, including brand and KYC information if a brand has been
    /// configured.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<ApiResponseOfProfileDetail> Retrieve(
        ProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProfileRetrieveParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<ApiResponseOfProfileDetail> Retrieve(
        string profileID,
        ProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Deprecated.** This endpoint is replaced by `/v3/sender-profiles` and will be
    /// removed in a future release. It still behaves exactly as before, so nothing
    /// needs to change today — but new integrations should use `/v3/sender-profiles`,
    /// which models a profile's markets, compliance, brand, campaigns and billing
    /// explicitly.
    ///
    /// <para>Updates a profile's configuration and settings. Requires admin role in the
    /// organization. Only provided fields will be updated (partial update).</para>
    ///
    /// <para>## Brand Management</para>
    ///
    /// <para>Include the optional `brand` field to create or update the brand
    /// associated with this profile. The brand holds KYC and TCR compliance data (legal
    /// business info, contact details, messaging vertical). Once a brand has been
    /// submitted to TCR it cannot be modified. Setting `inherit_tcr_brand: true` and
    /// providing `brand` in the same request is not allowed.</para>
    ///
    /// <para>## Payment Details</para>
    ///
    /// <para>When `billing_model` is `"profile"` or `"profile_and_organization"` you
    /// may include a `payment_details` object containing the card number, expiry
    /// (MM/YY), CVC, and billing ZIP code. Payment details are **never stored** on our
    /// servers and are forwarded directly to the payment processor. Providing
    /// `payment_details` when `billing_model` is `"organization"` is not allowed.</para>
    ///
    /// <para>## Deprecated fields</para>
    ///
    /// <para>`sending_phone_number_profile_id` and `sending_whatsapp_number_profile_id`
    /// are **accepted and ignored**. Sender borrowing is gone: a profile cannot send
    /// from another profile's number, because two profiles behind one sender makes an
    /// inbound reply and a delivery receipt ambiguous about whose they are.</para>
    ///
    /// <para>Sending either **changes nothing and still returns `200`** — they are kept
    /// on the contract so an existing integration keeps working. Reads carry both keys
    /// too and always answer `null`, which is how you can confirm the value did not
    /// take.</para>
    ///
    /// <para>Give the profile a sender of its own instead — `POST /v3/channels/sms` or
    /// `POST /v3/channels/whatsapp`, sent with the `x-profile-id` header naming it.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<ApiResponseOfProfileDetail> Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ProfileUpdateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<ApiResponseOfProfileDetail> Update(
        string profileID,
        ProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Deprecated.** This endpoint is replaced by `/v3/sender-profiles` and will be
    /// removed in a future release. It still behaves exactly as before, so nothing
    /// needs to change today — but new integrations should use `/v3/sender-profiles`,
    /// which models a profile's markets, compliance, brand, campaigns and billing
    /// explicitly.
    ///
    /// <para>Retrieves all sender profiles within an organization, including brand
    /// information for each profile. Profiles represent different brands, departments,
    /// or use cases within an organization, each with their own messaging
    /// configuration.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<ProfileListResponse> List(
        ProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Deprecated.** This endpoint is replaced by `/v3/sender-profiles` and will be
    /// removed in a future release. It still behaves exactly as before, so nothing
    /// needs to change today — but new integrations should use `/v3/sender-profiles`,
    /// which models a profile's markets, compliance, brand, campaigns and billing
    /// explicitly.
    ///
    /// <para>Soft deletes a sender profile. The profile will be marked as deleted but
    /// data is retained. Anything it still held is released first: phone numbers return
    /// to our inventory and can go to whoever asks next, its own WhatsApp account is
    /// deregistered, and its routing rules stop being used. Requires admin role in the
    /// organization.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task Delete(ProfileDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ProfileDeleteParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task Delete(
        string profileID,
        ProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Deprecated.** This endpoint is replaced by `/v3/sender-profiles` and will be
    /// removed in a future release. It still behaves exactly as before, so nothing
    /// needs to change today — but new integrations should use `/v3/sender-profiles`,
    /// which models a profile's markets, compliance, brand, campaigns and billing
    /// explicitly.
    ///
    /// <para>Final step in the profile compliance workflow. Validates all prerequisites
    /// (KYC, brand, campaigns, required documents), connects the profile to the SMS and
    /// WhatsApp channels, and marks it onboarded. Prerequisites are always validated
    /// first: if any fail the call returns 400 naming every unmet one, and nothing is
    /// started. If they pass and the profile is already onboarded, the call returns 200
    /// and does nothing. Otherwise it returns 202 and calls the provided webhook URL
    /// when background processing finishes.</para>
    ///
    /// <para>Callable with the organization's API key or the profile's own key. The
    /// key's user must be an admin or owner of the profile, or of the organization it
    /// belongs to.</para>
    ///
    /// <para>Prerequisites (all but the last are checked before the already-onboarded
    /// short-circuit, matching the previous contract; the last is checked after it, so
    /// a profile that is already onboarded is never rejected by it): - Profile must
    /// have a name, short name, and description (short name max 50 characters,
    /// description max 5000) - webHookUrl must be supplied on the request - A KYC form
    /// submission is required - A brand is required, either on the profile or inherited
    /// from the parent organization - TCR applications must have at least one campaign,
    /// own or inherited - Destination countries marked as main must have their required
    /// compliance documents uploaded - TCR applications must state whether they inherit
    /// the organization's TCR brand and campaign</para>
    ///
    /// <para>Outcome: - Once the prerequisites pass and background processing succeeds,
    /// the profile's conversionFlowStatus becomes ONBOARDED and its public status reads
    /// `approved` - A profile with no WhatsApp channel, or one still awaiting TCR
    /// registration or country documents, is onboarded like any other. Those are
    /// answered by the brand and campaign records, not by a status on the profile - If
    /// background processing fails, the profile keeps the status it already had and the
    /// webhook reports the reason</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<ProfileCompleteResponse> Complete(
        ProfileCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(ProfileCompleteParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<ProfileCompleteResponse> Complete(
        string profileID,
        ProfileCompleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProfileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICampaignServiceWithRawResponse Campaigns { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/profiles</c>, but is otherwise the
    /// same as <see cref="IProfileService.Create(ProfileCreateParams?, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<ApiResponseOfProfileDetail>> Create(
        ProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/profiles/{profileId}</c>, but is otherwise the
    /// same as <see cref="IProfileService.Retrieve(ProfileRetrieveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<ApiResponseOfProfileDetail>> Retrieve(
        ProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProfileRetrieveParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<ApiResponseOfProfileDetail>> Retrieve(
        string profileID,
        ProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/profiles/{profileId}</c>, but is otherwise the
    /// same as <see cref="IProfileService.Update(ProfileUpdateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<ApiResponseOfProfileDetail>> Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ProfileUpdateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<ApiResponseOfProfileDetail>> Update(
        string profileID,
        ProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/profiles</c>, but is otherwise the
    /// same as <see cref="IProfileService.List(ProfileListParams?, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<ProfileListResponse>> List(
        ProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/profiles/{profileId}</c>, but is otherwise the
    /// same as <see cref="IProfileService.Delete(ProfileDeleteParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse> Delete(
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ProfileDeleteParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse> Delete(
        string profileID,
        ProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/profiles/{profileId}/complete</c>, but is otherwise the
    /// same as <see cref="IProfileService.Complete(ProfileCompleteParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<ProfileCompleteResponse>> Complete(
        ProfileCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(ProfileCompleteParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<ProfileCompleteResponse>> Complete(
        string profileID,
        ProfileCompleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
