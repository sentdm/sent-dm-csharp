using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;

namespace Sentdm.Models.Profiles;

/// <summary>
/// **Deprecated.** This endpoint is replaced by `/v3/sender-profiles` and will be
/// removed in a future release. It still behaves exactly as before, so nothing needs
/// to change today — but new integrations should use `/v3/sender-profiles`, which
/// models a profile's markets, compliance, brand, campaigns and billing explicitly.
///
/// <para>Updates a profile's configuration and settings. Requires admin role in
/// the organization. Only provided fields will be updated (partial update).</para>
///
/// <para>## Brand Management</para>
///
/// <para>Include the optional `brand` field to create or update the brand associated
/// with this profile. The brand holds KYC and TCR compliance data (legal business
/// info, contact details, messaging vertical). Once a brand has been submitted to
/// TCR it cannot be modified. Setting `inherit_tcr_brand: true` and providing `brand`
/// in the same request is not allowed.</para>
///
/// <para>## Payment Details</para>
///
/// <para>When `billing_model` is `"profile"` or `"profile_and_organization"` you
/// may include a `payment_details` object containing the card number, expiry (MM/YY),
/// CVC, and billing ZIP code. Payment details are **never stored** on our servers
/// and are forwarded directly to the payment processor. Providing `payment_details`
/// when `billing_model` is `"organization"` is not allowed.</para>
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
/// too and always answer `null`, which is how you can confirm the value did not take.</para>
///
/// <para>Give the profile a sender of its own instead — `POST /v3/channels/sms`
/// or `POST /v3/channels/whatsapp`, sent with the `x-profile-id` header naming it.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
[Obsolete("deprecated")]
public record class ProfileUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ProfileID { get; init; }

    /// <summary>
    /// Deprecated. Accepted and ignored. Contact and template sharing between sender
    /// profiles is gone — a profile sees only what it owns, and the organization
    /// still sees all of its profiles' contacts and templates through read-time widening.
    /// The four columns behind these flags were dropped by M260720120000.
    ///        Retired the same way as SendingPhoneNumberProfileId, and for the same
    /// reason: the properties stay bound so an SDK that assigns them keeps compiling,
    /// and a 400 would break a working integration over a capability that is gone
    /// regardless. Every profile reports all four as false, so a caller that checks
    /// its own write can see it did not take.
    /// </summary>
    [Obsolete("deprecated")]
    public bool? AllowContactSharing
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("allow_contact_sharing");
        }
        init { this._rawBodyData.Set("allow_contact_sharing", value); }
    }

    /// <summary>
    /// Whether number changes are allowed during onboarding (optional)
    /// </summary>
    public bool? AllowNumberChangeDuringOnboarding
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "allow_number_change_during_onboarding"
            );
        }
        init { this._rawBodyData.Set("allow_number_change_during_onboarding", value); }
    }

    [Obsolete("deprecated")]
    public bool? AllowTemplateSharing
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("allow_template_sharing");
        }
        init { this._rawBodyData.Set("allow_template_sharing", value); }
    }

    /// <summary>
    /// Billing contact information for a profile. Required when billing_model is
    /// "profile" or "profile_and_organization".
    /// </summary>
    public ProfileUpdateParamsBillingContact? BillingContact
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ProfileUpdateParamsBillingContact>(
                "billing_contact"
            );
        }
        init { this._rawBodyData.Set("billing_contact", value); }
    }

    /// <summary>
    /// Billing model: profile, organization, or profile_and_organization (optional).
    /// - "organization": the organization's billing details are used; no profile-level
    /// billing info needed. - "profile": the profile is billed independently; billing_contact
    /// is required. - "profile_and_organization": the profile is billed first with
    /// the organization as fallback; billing_contact is required.
    /// </summary>
    public string? BillingModel
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("billing_model");
        }
        init { this._rawBodyData.Set("billing_model", value); }
    }

    /// <summary>
    /// Brand and KYC data grouped into contact, business, and compliance sections
    /// </summary>
    public ProfileUpdateParamsBrand? Brand
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ProfileUpdateParamsBrand>("brand");
        }
        init { this._rawBodyData.Set("brand", value); }
    }

    /// <summary>
    /// Profile description (optional)
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// Profile icon URL (optional)
    /// </summary>
    public string? Icon
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("icon");
        }
        init { this._rawBodyData.Set("icon", value); }
    }

    [Obsolete("deprecated")]
    public bool? InheritContacts
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("inherit_contacts");
        }
        init { this._rawBodyData.Set("inherit_contacts", value); }
    }

    /// <summary>
    /// Whether this profile inherits TCR brand from organization (optional)
    /// </summary>
    public bool? InheritTcrBrand
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("inherit_tcr_brand");
        }
        init { this._rawBodyData.Set("inherit_tcr_brand", value); }
    }

    /// <summary>
    /// Whether this profile inherits TCR campaign from organization (optional)
    /// </summary>
    public bool? InheritTcrCampaign
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("inherit_tcr_campaign");
        }
        init { this._rawBodyData.Set("inherit_tcr_campaign", value); }
    }

    [Obsolete("deprecated")]
    public bool? InheritTemplates
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("inherit_templates");
        }
        init { this._rawBodyData.Set("inherit_templates", value); }
    }

    /// <summary>
    /// Profile name (optional)
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Payment card details for this profile (optional). Accepted when billing_model
    /// is "profile" or "profile_and_organization". Not persisted on our servers —
    /// forwarded to the payment processor.
    /// </summary>
    public ProfileUpdateParamsPaymentDetails? PaymentDetails
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ProfileUpdateParamsPaymentDetails>(
                "payment_details"
            );
        }
        init { this._rawBodyData.Set("payment_details", value); }
    }

    /// <summary>
    /// Sandbox flag - when true, the operation is simulated without side effects
    /// Useful for testing integrations without actual execution
    /// </summary>
    public bool? Sandbox
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("sandbox");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sandbox", value);
        }
    }

    /// <summary>
    /// Direct phone number for SMS sending (optional)
    /// </summary>
    public string? SendingPhoneNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("sending_phone_number");
        }
        init { this._rawBodyData.Set("sending_phone_number", value); }
    }

    /// <summary>
    /// Deprecated. Accepted and ignored. Sender borrowing is gone: a profile cannot
    /// send from another profile's SMS number. Supplying this changes nothing and
    /// the request still succeeds.              Bound rather than dropped so the
    /// property survives on the wire and in a generated client — an SDK that assigns
    /// it keeps compiling, which is the compatibility this exists for. It is deliberately
    /// not refused: a 400 here would break an integration that is otherwise working,
    /// and the capability it asks for is gone either way.              The trade-off,
    /// stated plainly. A caller asking for borrowing is told it succeeded when nothing
    /// happened. What makes that survivable is the read: sending_phone_number_profile_id
    /// comes back null on every profile, so a caller that checks its own write can
    /// see it did not take. Every request that carries one is logged, so we can tell
    /// when nobody is sending it any more and the field can go for real.
    ///       Give the profile a sender of its own instead: POST /v3/channels/sms
    /// with the x-profile-id header naming it.
    /// </summary>
    [Obsolete("deprecated")]
    public string? SendingPhoneNumberProfileID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("sending_phone_number_profile_id");
        }
        init { this._rawBodyData.Set("sending_phone_number_profile_id", value); }
    }

    [Obsolete("deprecated")]
    public string? SendingWhatsappNumberProfileID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("sending_whatsapp_number_profile_id");
        }
        init { this._rawBodyData.Set("sending_whatsapp_number_profile_id", value); }
    }

    /// <summary>
    /// Profile short name/abbreviation (optional). Must be 3–11 characters, contain
    /// only letters, numbers, and spaces, and include at least one letter. Example:
    /// "SALES", "Mkt 2", "Support1".
    /// </summary>
    public string? ShortName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("short_name");
        }
        init { this._rawBodyData.Set("short_name", value); }
    }

    /// <summary>
    /// Direct phone number for WhatsApp sending (optional)
    /// </summary>
    public string? WhatsappPhoneNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("whatsapp_phone_number");
        }
        init { this._rawBodyData.Set("whatsapp_phone_number", value); }
    }

    public string? IdempotencyKey
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("Idempotency-Key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
        }
    }

    public string? XProfileID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("x-profile-id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("x-profile-id", value);
        }
    }

    public ProfileUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateParams(ProfileUpdateParams profileUpdateParams)
        : base(profileUpdateParams)
    {
        this.ProfileID = profileUpdateParams.ProfileID;

        this._rawBodyData = new(profileUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ProfileUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string profileID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ProfileID = profileID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ProfileUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string profileID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            profileID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ProfileID"] = JsonSerializer.SerializeToElement(this.ProfileID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ProfileUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ProfileID?.Equals(other.ProfileID) ?? other.ProfileID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/profiles/{0}", this.ProfileID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Billing contact information for a profile. Required when billing_model is "profile"
/// or "profile_and_organization".
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileUpdateParamsBillingContact,
        ProfileUpdateParamsBillingContactFromRaw
    >)
)]
public sealed record class ProfileUpdateParamsBillingContact : JsonModel
{
    /// <summary>
    /// Email address where invoices will be sent (required)
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Full name of the billing contact or company (required)
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Billing address (optional). Free-form text including street, city, state,
    /// postal code, and country.
    /// </summary>
    public string? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// Phone number for the billing contact (optional)
    /// </summary>
    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.Name;
        _ = this.Address;
        _ = this.Phone;
    }

    public ProfileUpdateParamsBillingContact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateParamsBillingContact(
        ProfileUpdateParamsBillingContact profileUpdateParamsBillingContact
    )
        : base(profileUpdateParamsBillingContact) { }
#pragma warning restore CS8618

    public ProfileUpdateParamsBillingContact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateParamsBillingContact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateParamsBillingContactFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateParamsBillingContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateParamsBillingContactFromRaw : IFromRawJson<ProfileUpdateParamsBillingContact>
{
    /// <inheritdoc/>
    public ProfileUpdateParamsBillingContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateParamsBillingContact.FromRawUnchecked(rawData);
}

/// <summary>
/// Brand and KYC data grouped into contact, business, and compliance sections
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProfileUpdateParamsBrand, ProfileUpdateParamsBrandFromRaw>)
)]
public sealed record class ProfileUpdateParamsBrand : JsonModel
{
    /// <summary>
    /// Compliance and TCR information for brand registration
    /// </summary>
    public required ProfileUpdateParamsBrandCompliance Compliance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ProfileUpdateParamsBrandCompliance>("compliance");
        }
        init { this._rawData.Set("compliance", value); }
    }

    /// <summary>
    /// Contact information for brand KYC
    /// </summary>
    public required ProfileUpdateParamsBrandContact Contact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ProfileUpdateParamsBrandContact>("contact");
        }
        init { this._rawData.Set("contact", value); }
    }

    /// <summary>
    /// Business details and address for brand KYC
    /// </summary>
    public ProfileUpdateParamsBrandBusiness? Business
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateParamsBrandBusiness>("business");
        }
        init { this._rawData.Set("business", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Compliance.Validate();
        this.Contact.Validate();
        this.Business?.Validate();
    }

    public ProfileUpdateParamsBrand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateParamsBrand(ProfileUpdateParamsBrand profileUpdateParamsBrand)
        : base(profileUpdateParamsBrand) { }
#pragma warning restore CS8618

    public ProfileUpdateParamsBrand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateParamsBrand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateParamsBrandFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateParamsBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateParamsBrandFromRaw : IFromRawJson<ProfileUpdateParamsBrand>
{
    /// <inheritdoc/>
    public ProfileUpdateParamsBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateParamsBrand.FromRawUnchecked(rawData);
}

/// <summary>
/// Compliance and TCR information for brand registration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileUpdateParamsBrandCompliance,
        ProfileUpdateParamsBrandComplianceFromRaw
    >)
)]
public sealed record class ProfileUpdateParamsBrandCompliance : JsonModel
{
    public required ApiEnum<string, TcrBrandRelationship> BrandRelationship
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TcrBrandRelationship>>(
                "brandRelationship"
            );
        }
        init { this._rawData.Set("brandRelationship", value); }
    }

    public required ApiEnum<string, TcrVertical> Vertical
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TcrVertical>>("vertical");
        }
        init { this._rawData.Set("vertical", value); }
    }

    /// <summary>
    /// List of destination countries for messaging
    /// </summary>
    public IReadOnlyList<DestinationCountry>? DestinationCountries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DestinationCountry>>(
                "destinationCountries"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<DestinationCountry>?>(
                "destinationCountries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether this is a TCR (Campaign Registry) application
    /// </summary>
    public bool? IsTcrApplication
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isTcrApplication");
        }
        init { this._rawData.Set("isTcrApplication", value); }
    }

    /// <summary>
    /// Additional notes about the business or use case
    /// </summary>
    public string? Notes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("notes");
        }
        init { this._rawData.Set("notes", value); }
    }

    /// <summary>
    /// Phone number prefix for messaging (e.g., "+1")
    /// </summary>
    public string? PhoneNumberPrefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phoneNumberPrefix");
        }
        init { this._rawData.Set("phoneNumberPrefix", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BrandRelationship.Validate();
        this.Vertical.Validate();
        foreach (var item in this.DestinationCountries ?? [])
        {
            item.Validate();
        }
        _ = this.IsTcrApplication;
        _ = this.Notes;
        _ = this.PhoneNumberPrefix;
    }

    public ProfileUpdateParamsBrandCompliance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateParamsBrandCompliance(
        ProfileUpdateParamsBrandCompliance profileUpdateParamsBrandCompliance
    )
        : base(profileUpdateParamsBrandCompliance) { }
#pragma warning restore CS8618

    public ProfileUpdateParamsBrandCompliance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateParamsBrandCompliance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateParamsBrandComplianceFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateParamsBrandCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateParamsBrandComplianceFromRaw : IFromRawJson<ProfileUpdateParamsBrandCompliance>
{
    /// <inheritdoc/>
    public ProfileUpdateParamsBrandCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateParamsBrandCompliance.FromRawUnchecked(rawData);
}

/// <summary>
/// Contact information for brand KYC
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileUpdateParamsBrandContact,
        ProfileUpdateParamsBrandContactFromRaw
    >)
)]
public sealed record class ProfileUpdateParamsBrandContact : JsonModel
{
    /// <summary>
    /// Primary contact name (required)
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Business/brand name
    /// </summary>
    public string? BusinessName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("businessName");
        }
        init { this._rawData.Set("businessName", value); }
    }

    /// <summary>
    /// Contact email address
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Contact phone number in E.164 format
    /// </summary>
    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    /// <summary>
    /// Contact phone country code (e.g., "1" for US)
    /// </summary>
    public string? PhoneCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phoneCountryCode");
        }
        init { this._rawData.Set("phoneCountryCode", value); }
    }

    /// <summary>
    /// Contact's role in the business
    /// </summary>
    public string? Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.BusinessName;
        _ = this.Email;
        _ = this.Phone;
        _ = this.PhoneCountryCode;
        _ = this.Role;
    }

    public ProfileUpdateParamsBrandContact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateParamsBrandContact(
        ProfileUpdateParamsBrandContact profileUpdateParamsBrandContact
    )
        : base(profileUpdateParamsBrandContact) { }
#pragma warning restore CS8618

    public ProfileUpdateParamsBrandContact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateParamsBrandContact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateParamsBrandContactFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateParamsBrandContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProfileUpdateParamsBrandContact(string name)
        : this()
    {
        this.Name = name;
    }
}

class ProfileUpdateParamsBrandContactFromRaw : IFromRawJson<ProfileUpdateParamsBrandContact>
{
    /// <inheritdoc/>
    public ProfileUpdateParamsBrandContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateParamsBrandContact.FromRawUnchecked(rawData);
}

/// <summary>
/// Business details and address for brand KYC
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileUpdateParamsBrandBusiness,
        ProfileUpdateParamsBrandBusinessFromRaw
    >)
)]
public sealed record class ProfileUpdateParamsBrandBusiness : JsonModel
{
    /// <summary>
    /// City
    /// </summary>
    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// Country code (e.g., US, CA)
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// Country where the business is registered
    /// </summary>
    public string? CountryOfRegistration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("countryOfRegistration");
        }
        init { this._rawData.Set("countryOfRegistration", value); }
    }

    public ApiEnum<string, ProfileUpdateParamsBrandBusinessEntityType>? EntityType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProfileUpdateParamsBrandBusinessEntityType>
            >("entityType");
        }
        init { this._rawData.Set("entityType", value); }
    }

    /// <summary>
    /// Legal business name
    /// </summary>
    public string? LegalName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("legalName");
        }
        init { this._rawData.Set("legalName", value); }
    }

    /// <summary>
    /// Postal/ZIP code
    /// </summary>
    public string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postalCode");
        }
        init { this._rawData.Set("postalCode", value); }
    }

    /// <summary>
    /// State/province code
    /// </summary>
    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// Street address
    /// </summary>
    public string? Street
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("street");
        }
        init { this._rawData.Set("street", value); }
    }

    /// <summary>
    /// Tax ID/EIN number
    /// </summary>
    public string? TaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("taxId");
        }
        init { this._rawData.Set("taxId", value); }
    }

    /// <summary>
    /// Type of tax ID (e.g., us_ein, ca_bn)
    /// </summary>
    public string? TaxIDType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("taxIdType");
        }
        init { this._rawData.Set("taxIdType", value); }
    }

    /// <summary>
    /// Business website URL
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.CountryOfRegistration;
        this.EntityType?.Validate();
        _ = this.LegalName;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.Street;
        _ = this.TaxID;
        _ = this.TaxIDType;
        _ = this.Url;
    }

    public ProfileUpdateParamsBrandBusiness() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateParamsBrandBusiness(
        ProfileUpdateParamsBrandBusiness profileUpdateParamsBrandBusiness
    )
        : base(profileUpdateParamsBrandBusiness) { }
#pragma warning restore CS8618

    public ProfileUpdateParamsBrandBusiness(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateParamsBrandBusiness(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateParamsBrandBusinessFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateParamsBrandBusiness FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateParamsBrandBusinessFromRaw : IFromRawJson<ProfileUpdateParamsBrandBusiness>
{
    /// <inheritdoc/>
    public ProfileUpdateParamsBrandBusiness FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateParamsBrandBusiness.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileUpdateParamsBrandBusinessEntityTypeConverter))]
public enum ProfileUpdateParamsBrandBusinessEntityType
{
    PrivateProfit,
    PublicProfit,
    NonProfit,
    SoleProprietor,
    Government,
}

sealed class ProfileUpdateParamsBrandBusinessEntityTypeConverter
    : JsonConverter<ProfileUpdateParamsBrandBusinessEntityType>
{
    public override ProfileUpdateParamsBrandBusinessEntityType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PRIVATE_PROFIT" => ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
            "PUBLIC_PROFIT" => ProfileUpdateParamsBrandBusinessEntityType.PublicProfit,
            "NON_PROFIT" => ProfileUpdateParamsBrandBusinessEntityType.NonProfit,
            "SOLE_PROPRIETOR" => ProfileUpdateParamsBrandBusinessEntityType.SoleProprietor,
            "GOVERNMENT" => ProfileUpdateParamsBrandBusinessEntityType.Government,
            _ => (ProfileUpdateParamsBrandBusinessEntityType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateParamsBrandBusinessEntityType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit => "PRIVATE_PROFIT",
                ProfileUpdateParamsBrandBusinessEntityType.PublicProfit => "PUBLIC_PROFIT",
                ProfileUpdateParamsBrandBusinessEntityType.NonProfit => "NON_PROFIT",
                ProfileUpdateParamsBrandBusinessEntityType.SoleProprietor => "SOLE_PROPRIETOR",
                ProfileUpdateParamsBrandBusinessEntityType.Government => "GOVERNMENT",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Payment card details for this profile (optional). Accepted when billing_model
/// is "profile" or "profile_and_organization". Not persisted on our servers — forwarded
/// to the payment processor.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileUpdateParamsPaymentDetails,
        ProfileUpdateParamsPaymentDetailsFromRaw
    >)
)]
public sealed record class ProfileUpdateParamsPaymentDetails : JsonModel
{
    /// <summary>
    /// Card number (digits only, 13–19 characters)
    /// </summary>
    public required string CardNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("card_number");
        }
        init { this._rawData.Set("card_number", value); }
    }

    /// <summary>
    /// Card security code (3–4 digits)
    /// </summary>
    public required string Cvc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cvc");
        }
        init { this._rawData.Set("cvc", value); }
    }

    /// <summary>
    /// Card expiry date in MM/YY format (e.g. "09/27")
    /// </summary>
    public required string Expiry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expiry");
        }
        init { this._rawData.Set("expiry", value); }
    }

    /// <summary>
    /// Billing ZIP / postal code associated with the card
    /// </summary>
    public required string ZipCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("zip_code");
        }
        init { this._rawData.Set("zip_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CardNumber;
        _ = this.Cvc;
        _ = this.Expiry;
        _ = this.ZipCode;
    }

    public ProfileUpdateParamsPaymentDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateParamsPaymentDetails(
        ProfileUpdateParamsPaymentDetails profileUpdateParamsPaymentDetails
    )
        : base(profileUpdateParamsPaymentDetails) { }
#pragma warning restore CS8618

    public ProfileUpdateParamsPaymentDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateParamsPaymentDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateParamsPaymentDetailsFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateParamsPaymentDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateParamsPaymentDetailsFromRaw : IFromRawJson<ProfileUpdateParamsPaymentDetails>
{
    /// <inheritdoc/>
    public ProfileUpdateParamsPaymentDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateParamsPaymentDetails.FromRawUnchecked(rawData);
}
