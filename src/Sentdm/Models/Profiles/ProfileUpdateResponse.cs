using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;

namespace Sentdm.Models.Profiles;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileUpdateResponse, ProfileUpdateResponseFromRaw>))]
public sealed record class ProfileUpdateResponse : JsonModel
{
    /// <summary>
    /// Detailed profile response for v3 API
    /// </summary>
    public ProfileUpdateResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public ProfileUpdateResponseError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateResponseError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public ProfileUpdateResponseMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateResponseMeta>("meta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data?.Validate();
        this.Error?.Validate();
        this.Meta?.Validate();
        _ = this.Success;
    }

    public ProfileUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateResponse(ProfileUpdateResponse profileUpdateResponse)
        : base(profileUpdateResponse) { }
#pragma warning restore CS8618

    public ProfileUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateResponseFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateResponseFromRaw : IFromRawJson<ProfileUpdateResponse>
{
    /// <inheritdoc/>
    public ProfileUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Detailed profile response for v3 API
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProfileUpdateResponseData, ProfileUpdateResponseDataFromRaw>)
)]
public sealed record class ProfileUpdateResponseData : JsonModel
{
    /// <summary>
    /// Profile unique identifier
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Whether contacts are shared across profiles in the organization
    /// </summary>
    public bool? AllowContactSharing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_contact_sharing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_contact_sharing", value);
        }
    }

    /// <summary>
    /// Whether number changes are allowed during onboarding
    /// </summary>
    public bool? AllowNumberChangeDuringOnboarding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_number_change_during_onboarding");
        }
        init { this._rawData.Set("allow_number_change_during_onboarding", value); }
    }

    /// <summary>
    /// Whether templates are shared across profiles in the organization
    /// </summary>
    public bool? AllowTemplateSharing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_template_sharing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_template_sharing", value);
        }
    }

    /// <summary>
    /// Billing contact info returned in profile responses
    /// </summary>
    public ProfileUpdateResponseDataBillingContact? BillingContact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateResponseDataBillingContact>(
                "billing_contact"
            );
        }
        init { this._rawData.Set("billing_contact", value); }
    }

    /// <summary>
    /// Billing model: profile, organization, or profile_and_organization
    /// </summary>
    public string? BillingModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billing_model", value);
        }
    }

    /// <summary>
    /// Brand response with nested contact, business, and compliance sections — mirrors
    /// the request structure.
    /// </summary>
    public ProfileUpdateResponseDataBrand? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateResponseDataBrand>("brand");
        }
        init { this._rawData.Set("brand", value); }
    }

    /// <summary>
    /// When the profile was created
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Profile description
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Profile email (inherited from organization)
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
    /// Profile icon URL
    /// </summary>
    public string? Icon
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("icon");
        }
        init { this._rawData.Set("icon", value); }
    }

    /// <summary>
    /// Whether this profile inherits contacts from the organization
    /// </summary>
    public bool? InheritContacts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inherit_contacts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inherit_contacts", value);
        }
    }

    /// <summary>
    /// Whether this profile inherits TCR brand from the organization
    /// </summary>
    public bool? InheritTcrBrand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inherit_tcr_brand");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inherit_tcr_brand", value);
        }
    }

    /// <summary>
    /// Whether this profile inherits TCR campaign from the organization
    /// </summary>
    public bool? InheritTcrCampaign
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inherit_tcr_campaign");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inherit_tcr_campaign", value);
        }
    }

    /// <summary>
    /// Whether this profile inherits templates from the organization
    /// </summary>
    public bool? InheritTemplates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inherit_templates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inherit_templates", value);
        }
    }

    /// <summary>
    /// Profile name
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Parent organization ID
    /// </summary>
    public string? OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
    }

    /// <summary>
    /// Direct SMS phone number
    /// </summary>
    public string? SendingPhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sending_phone_number");
        }
        init { this._rawData.Set("sending_phone_number", value); }
    }

    /// <summary>
    /// Reference to another profile for SMS/Telnyx configuration
    /// </summary>
    public string? SendingPhoneNumberProfileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sending_phone_number_profile_id");
        }
        init { this._rawData.Set("sending_phone_number_profile_id", value); }
    }

    /// <summary>
    /// Reference to another profile for WhatsApp configuration
    /// </summary>
    public string? SendingWhatsappNumberProfileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sending_whatsapp_number_profile_id");
        }
        init { this._rawData.Set("sending_whatsapp_number_profile_id", value); }
    }

    /// <summary>
    /// Profile short name/abbreviation. 3–11 characters: letters, numbers, and spaces
    /// only, with at least one letter.
    /// </summary>
    public string? ShortName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("short_name");
        }
        init { this._rawData.Set("short_name", value); }
    }

    /// <summary>
    /// Profile setup status: incomplete, pending_review, approved, rejected
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// When the profile was last updated
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// WhatsApp Business Account ID associated with this profile. Present whether
    /// the WABA is inherited from the organization or configured directly.
    /// </summary>
    public string? WabaID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("waba_id");
        }
        init { this._rawData.Set("waba_id", value); }
    }

    /// <summary>
    /// Direct WhatsApp phone number
    /// </summary>
    public string? WhatsappPhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("whatsapp_phone_number");
        }
        init { this._rawData.Set("whatsapp_phone_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AllowContactSharing;
        _ = this.AllowNumberChangeDuringOnboarding;
        _ = this.AllowTemplateSharing;
        this.BillingContact?.Validate();
        _ = this.BillingModel;
        this.Brand?.Validate();
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Email;
        _ = this.Icon;
        _ = this.InheritContacts;
        _ = this.InheritTcrBrand;
        _ = this.InheritTcrCampaign;
        _ = this.InheritTemplates;
        _ = this.Name;
        _ = this.OrganizationID;
        _ = this.SendingPhoneNumber;
        _ = this.SendingPhoneNumberProfileID;
        _ = this.SendingWhatsappNumberProfileID;
        _ = this.ShortName;
        _ = this.Status;
        _ = this.UpdatedAt;
        _ = this.WabaID;
        _ = this.WhatsappPhoneNumber;
    }

    public ProfileUpdateResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateResponseData(ProfileUpdateResponseData profileUpdateResponseData)
        : base(profileUpdateResponseData) { }
#pragma warning restore CS8618

    public ProfileUpdateResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateResponseDataFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateResponseDataFromRaw : IFromRawJson<ProfileUpdateResponseData>
{
    /// <inheritdoc/>
    public ProfileUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing contact info returned in profile responses
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileUpdateResponseDataBillingContact,
        ProfileUpdateResponseDataBillingContactFromRaw
    >)
)]
public sealed record class ProfileUpdateResponseDataBillingContact : JsonModel
{
    public string? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

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
        _ = this.Address;
        _ = this.Email;
        _ = this.Name;
        _ = this.Phone;
    }

    public ProfileUpdateResponseDataBillingContact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateResponseDataBillingContact(
        ProfileUpdateResponseDataBillingContact profileUpdateResponseDataBillingContact
    )
        : base(profileUpdateResponseDataBillingContact) { }
#pragma warning restore CS8618

    public ProfileUpdateResponseDataBillingContact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateResponseDataBillingContact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateResponseDataBillingContactFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateResponseDataBillingContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateResponseDataBillingContactFromRaw
    : IFromRawJson<ProfileUpdateResponseDataBillingContact>
{
    /// <inheritdoc/>
    public ProfileUpdateResponseDataBillingContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateResponseDataBillingContact.FromRawUnchecked(rawData);
}

/// <summary>
/// Brand response with nested contact, business, and compliance sections — mirrors
/// the request structure.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileUpdateResponseDataBrand,
        ProfileUpdateResponseDataBrandFromRaw
    >)
)]
public sealed record class ProfileUpdateResponseDataBrand : JsonModel
{
    /// <summary>
    /// Unique identifier for the brand
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Business details and address information
    /// </summary>
    public ProfileUpdateResponseDataBrandBusiness? Business
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateResponseDataBrandBusiness>(
                "business"
            );
        }
        init { this._rawData.Set("business", value); }
    }

    /// <summary>
    /// Compliance and TCR-related information
    /// </summary>
    public ProfileUpdateResponseDataBrandCompliance? Compliance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateResponseDataBrandCompliance>(
                "compliance"
            );
        }
        init { this._rawData.Set("compliance", value); }
    }

    /// <summary>
    /// Contact information for the brand
    /// </summary>
    public ProfileUpdateResponseDataBrandContact? Contact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateResponseDataBrandContact>("contact");
        }
        init { this._rawData.Set("contact", value); }
    }

    /// <summary>
    /// When the brand was created
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// CSP (Campaign Service Provider) ID
    /// </summary>
    public string? CspID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("csp_id");
        }
        init { this._rawData.Set("csp_id", value); }
    }

    public ApiEnum<string, ProfileUpdateResponseDataBrandIdentityStatus>? IdentityStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProfileUpdateResponseDataBrandIdentityStatus>
            >("identity_status");
        }
        init { this._rawData.Set("identity_status", value); }
    }

    /// <summary>
    /// Whether this brand is inherited from the parent organization
    /// </summary>
    public bool? IsInherited
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_inherited");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_inherited", value);
        }
    }

    public ApiEnum<string, ProfileUpdateResponseDataBrandStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProfileUpdateResponseDataBrandStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// When the brand was submitted to TCR
    /// </summary>
    public DateTimeOffset? SubmittedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("submitted_at");
        }
        init { this._rawData.Set("submitted_at", value); }
    }

    /// <summary>
    /// Whether this brand has been submitted to TCR
    /// </summary>
    public bool? SubmittedToTcr
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("submitted_to_tcr");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("submitted_to_tcr", value);
        }
    }

    /// <summary>
    /// TCR brand ID (populated after TCR submission)
    /// </summary>
    public string? TcrBrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tcr_brand_id");
        }
        init { this._rawData.Set("tcr_brand_id", value); }
    }

    /// <summary>
    /// Universal EIN from TCR
    /// </summary>
    public string? UniversalEin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("universal_ein");
        }
        init { this._rawData.Set("universal_ein", value); }
    }

    /// <summary>
    /// When the brand was last updated
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Business?.Validate();
        this.Compliance?.Validate();
        this.Contact?.Validate();
        _ = this.CreatedAt;
        _ = this.CspID;
        this.IdentityStatus?.Validate();
        _ = this.IsInherited;
        this.Status?.Validate();
        _ = this.SubmittedAt;
        _ = this.SubmittedToTcr;
        _ = this.TcrBrandID;
        _ = this.UniversalEin;
        _ = this.UpdatedAt;
    }

    public ProfileUpdateResponseDataBrand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateResponseDataBrand(
        ProfileUpdateResponseDataBrand profileUpdateResponseDataBrand
    )
        : base(profileUpdateResponseDataBrand) { }
#pragma warning restore CS8618

    public ProfileUpdateResponseDataBrand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateResponseDataBrand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateResponseDataBrandFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateResponseDataBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateResponseDataBrandFromRaw : IFromRawJson<ProfileUpdateResponseDataBrand>
{
    /// <inheritdoc/>
    public ProfileUpdateResponseDataBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateResponseDataBrand.FromRawUnchecked(rawData);
}

/// <summary>
/// Business details and address information
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileUpdateResponseDataBrandBusiness,
        ProfileUpdateResponseDataBrandBusinessFromRaw
    >)
)]
public sealed record class ProfileUpdateResponseDataBrandBusiness : JsonModel
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
            return this._rawData.GetNullableClass<string>("country_of_registration");
        }
        init { this._rawData.Set("country_of_registration", value); }
    }

    /// <summary>
    /// Business entity type
    /// </summary>
    public string? EntityType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("entity_type");
        }
        init { this._rawData.Set("entity_type", value); }
    }

    /// <summary>
    /// Legal business name
    /// </summary>
    public string? LegalName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("legal_name");
        }
        init { this._rawData.Set("legal_name", value); }
    }

    /// <summary>
    /// Postal/ZIP code
    /// </summary>
    public string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
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
            return this._rawData.GetNullableClass<string>("tax_id");
        }
        init { this._rawData.Set("tax_id", value); }
    }

    /// <summary>
    /// Type of tax ID (e.g., us_ein, ca_bn)
    /// </summary>
    public string? TaxIDType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_id_type");
        }
        init { this._rawData.Set("tax_id_type", value); }
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
        _ = this.EntityType;
        _ = this.LegalName;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.Street;
        _ = this.TaxID;
        _ = this.TaxIDType;
        _ = this.Url;
    }

    public ProfileUpdateResponseDataBrandBusiness() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateResponseDataBrandBusiness(
        ProfileUpdateResponseDataBrandBusiness profileUpdateResponseDataBrandBusiness
    )
        : base(profileUpdateResponseDataBrandBusiness) { }
#pragma warning restore CS8618

    public ProfileUpdateResponseDataBrandBusiness(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateResponseDataBrandBusiness(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateResponseDataBrandBusinessFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateResponseDataBrandBusiness FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateResponseDataBrandBusinessFromRaw
    : IFromRawJson<ProfileUpdateResponseDataBrandBusiness>
{
    /// <inheritdoc/>
    public ProfileUpdateResponseDataBrandBusiness FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateResponseDataBrandBusiness.FromRawUnchecked(rawData);
}

/// <summary>
/// Compliance and TCR-related information
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileUpdateResponseDataBrandCompliance,
        ProfileUpdateResponseDataBrandComplianceFromRaw
    >)
)]
public sealed record class ProfileUpdateResponseDataBrandCompliance : JsonModel
{
    public ApiEnum<
        string,
        ProfileUpdateResponseDataBrandComplianceBrandRelationship
    >? BrandRelationship
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProfileUpdateResponseDataBrandComplianceBrandRelationship>
            >("brand_relationship");
        }
        init { this._rawData.Set("brand_relationship", value); }
    }

    /// <summary>
    /// List of destination countries for messaging
    /// </summary>
    public IReadOnlyList<ProfileUpdateResponseDataBrandComplianceDestinationCountry>? DestinationCountries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ProfileUpdateResponseDataBrandComplianceDestinationCountry>
            >("destination_countries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ProfileUpdateResponseDataBrandComplianceDestinationCountry>?>(
                "destination_countries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Expected daily messaging volume
    /// </summary>
    public string? ExpectedMessagingVolume
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expected_messaging_volume");
        }
        init { this._rawData.Set("expected_messaging_volume", value); }
    }

    /// <summary>
    /// Whether this is a TCR (Campaign Registry) application
    /// </summary>
    public bool? IsTcrApplication
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_tcr_application");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_tcr_application", value);
        }
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
            return this._rawData.GetNullableClass<string>("phone_number_prefix");
        }
        init { this._rawData.Set("phone_number_prefix", value); }
    }

    /// <summary>
    /// Primary messaging use case description
    /// </summary>
    public string? PrimaryUseCase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primary_use_case");
        }
        init { this._rawData.Set("primary_use_case", value); }
    }

    public ApiEnum<string, ProfileUpdateResponseDataBrandComplianceVertical>? Vertical
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProfileUpdateResponseDataBrandComplianceVertical>
            >("vertical");
        }
        init { this._rawData.Set("vertical", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BrandRelationship?.Validate();
        foreach (var item in this.DestinationCountries ?? [])
        {
            item.Validate();
        }
        _ = this.ExpectedMessagingVolume;
        _ = this.IsTcrApplication;
        _ = this.Notes;
        _ = this.PhoneNumberPrefix;
        _ = this.PrimaryUseCase;
        this.Vertical?.Validate();
    }

    public ProfileUpdateResponseDataBrandCompliance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateResponseDataBrandCompliance(
        ProfileUpdateResponseDataBrandCompliance profileUpdateResponseDataBrandCompliance
    )
        : base(profileUpdateResponseDataBrandCompliance) { }
#pragma warning restore CS8618

    public ProfileUpdateResponseDataBrandCompliance(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateResponseDataBrandCompliance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateResponseDataBrandComplianceFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateResponseDataBrandCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateResponseDataBrandComplianceFromRaw
    : IFromRawJson<ProfileUpdateResponseDataBrandCompliance>
{
    /// <inheritdoc/>
    public ProfileUpdateResponseDataBrandCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateResponseDataBrandCompliance.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileUpdateResponseDataBrandComplianceBrandRelationshipConverter))]
public enum ProfileUpdateResponseDataBrandComplianceBrandRelationship
{
    BasicAccount,
    MediumAccount,
    LargeAccount,
    SmallAccount,
    KeyAccount,
}

sealed class ProfileUpdateResponseDataBrandComplianceBrandRelationshipConverter
    : JsonConverter<ProfileUpdateResponseDataBrandComplianceBrandRelationship>
{
    public override ProfileUpdateResponseDataBrandComplianceBrandRelationship Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BASIC_ACCOUNT" =>
                ProfileUpdateResponseDataBrandComplianceBrandRelationship.BasicAccount,
            "MEDIUM_ACCOUNT" =>
                ProfileUpdateResponseDataBrandComplianceBrandRelationship.MediumAccount,
            "LARGE_ACCOUNT" =>
                ProfileUpdateResponseDataBrandComplianceBrandRelationship.LargeAccount,
            "SMALL_ACCOUNT" =>
                ProfileUpdateResponseDataBrandComplianceBrandRelationship.SmallAccount,
            "KEY_ACCOUNT" => ProfileUpdateResponseDataBrandComplianceBrandRelationship.KeyAccount,
            _ => (ProfileUpdateResponseDataBrandComplianceBrandRelationship)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateResponseDataBrandComplianceBrandRelationship value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateResponseDataBrandComplianceBrandRelationship.BasicAccount =>
                    "BASIC_ACCOUNT",
                ProfileUpdateResponseDataBrandComplianceBrandRelationship.MediumAccount =>
                    "MEDIUM_ACCOUNT",
                ProfileUpdateResponseDataBrandComplianceBrandRelationship.LargeAccount =>
                    "LARGE_ACCOUNT",
                ProfileUpdateResponseDataBrandComplianceBrandRelationship.SmallAccount =>
                    "SMALL_ACCOUNT",
                ProfileUpdateResponseDataBrandComplianceBrandRelationship.KeyAccount =>
                    "KEY_ACCOUNT",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ProfileUpdateResponseDataBrandComplianceDestinationCountry,
        ProfileUpdateResponseDataBrandComplianceDestinationCountryFromRaw
    >)
)]
public sealed record class ProfileUpdateResponseDataBrandComplianceDestinationCountry : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public bool? IsMain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isMain");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isMain", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.IsMain;
    }

    public ProfileUpdateResponseDataBrandComplianceDestinationCountry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateResponseDataBrandComplianceDestinationCountry(
        ProfileUpdateResponseDataBrandComplianceDestinationCountry profileUpdateResponseDataBrandComplianceDestinationCountry
    )
        : base(profileUpdateResponseDataBrandComplianceDestinationCountry) { }
#pragma warning restore CS8618

    public ProfileUpdateResponseDataBrandComplianceDestinationCountry(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateResponseDataBrandComplianceDestinationCountry(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateResponseDataBrandComplianceDestinationCountryFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateResponseDataBrandComplianceDestinationCountry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateResponseDataBrandComplianceDestinationCountryFromRaw
    : IFromRawJson<ProfileUpdateResponseDataBrandComplianceDestinationCountry>
{
    /// <inheritdoc/>
    public ProfileUpdateResponseDataBrandComplianceDestinationCountry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateResponseDataBrandComplianceDestinationCountry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileUpdateResponseDataBrandComplianceVerticalConverter))]
public enum ProfileUpdateResponseDataBrandComplianceVertical
{
    Professional,
    RealEstate,
    Healthcare,
    HumanResources,
    Energy,
    Entertainment,
    Retail,
    Transportation,
    Agriculture,
    Insurance,
    Postal,
    Education,
    Hospitality,
    Financial,
    Political,
    Gambling,
    Legal,
    Construction,
    Ngo,
    Manufacturing,
    Government,
    Technology,
    Communication,
}

sealed class ProfileUpdateResponseDataBrandComplianceVerticalConverter
    : JsonConverter<ProfileUpdateResponseDataBrandComplianceVertical>
{
    public override ProfileUpdateResponseDataBrandComplianceVertical Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PROFESSIONAL" => ProfileUpdateResponseDataBrandComplianceVertical.Professional,
            "REAL_ESTATE" => ProfileUpdateResponseDataBrandComplianceVertical.RealEstate,
            "HEALTHCARE" => ProfileUpdateResponseDataBrandComplianceVertical.Healthcare,
            "HUMAN_RESOURCES" => ProfileUpdateResponseDataBrandComplianceVertical.HumanResources,
            "ENERGY" => ProfileUpdateResponseDataBrandComplianceVertical.Energy,
            "ENTERTAINMENT" => ProfileUpdateResponseDataBrandComplianceVertical.Entertainment,
            "RETAIL" => ProfileUpdateResponseDataBrandComplianceVertical.Retail,
            "TRANSPORTATION" => ProfileUpdateResponseDataBrandComplianceVertical.Transportation,
            "AGRICULTURE" => ProfileUpdateResponseDataBrandComplianceVertical.Agriculture,
            "INSURANCE" => ProfileUpdateResponseDataBrandComplianceVertical.Insurance,
            "POSTAL" => ProfileUpdateResponseDataBrandComplianceVertical.Postal,
            "EDUCATION" => ProfileUpdateResponseDataBrandComplianceVertical.Education,
            "HOSPITALITY" => ProfileUpdateResponseDataBrandComplianceVertical.Hospitality,
            "FINANCIAL" => ProfileUpdateResponseDataBrandComplianceVertical.Financial,
            "POLITICAL" => ProfileUpdateResponseDataBrandComplianceVertical.Political,
            "GAMBLING" => ProfileUpdateResponseDataBrandComplianceVertical.Gambling,
            "LEGAL" => ProfileUpdateResponseDataBrandComplianceVertical.Legal,
            "CONSTRUCTION" => ProfileUpdateResponseDataBrandComplianceVertical.Construction,
            "NGO" => ProfileUpdateResponseDataBrandComplianceVertical.Ngo,
            "MANUFACTURING" => ProfileUpdateResponseDataBrandComplianceVertical.Manufacturing,
            "GOVERNMENT" => ProfileUpdateResponseDataBrandComplianceVertical.Government,
            "TECHNOLOGY" => ProfileUpdateResponseDataBrandComplianceVertical.Technology,
            "COMMUNICATION" => ProfileUpdateResponseDataBrandComplianceVertical.Communication,
            _ => (ProfileUpdateResponseDataBrandComplianceVertical)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateResponseDataBrandComplianceVertical value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateResponseDataBrandComplianceVertical.Professional => "PROFESSIONAL",
                ProfileUpdateResponseDataBrandComplianceVertical.RealEstate => "REAL_ESTATE",
                ProfileUpdateResponseDataBrandComplianceVertical.Healthcare => "HEALTHCARE",
                ProfileUpdateResponseDataBrandComplianceVertical.HumanResources =>
                    "HUMAN_RESOURCES",
                ProfileUpdateResponseDataBrandComplianceVertical.Energy => "ENERGY",
                ProfileUpdateResponseDataBrandComplianceVertical.Entertainment => "ENTERTAINMENT",
                ProfileUpdateResponseDataBrandComplianceVertical.Retail => "RETAIL",
                ProfileUpdateResponseDataBrandComplianceVertical.Transportation => "TRANSPORTATION",
                ProfileUpdateResponseDataBrandComplianceVertical.Agriculture => "AGRICULTURE",
                ProfileUpdateResponseDataBrandComplianceVertical.Insurance => "INSURANCE",
                ProfileUpdateResponseDataBrandComplianceVertical.Postal => "POSTAL",
                ProfileUpdateResponseDataBrandComplianceVertical.Education => "EDUCATION",
                ProfileUpdateResponseDataBrandComplianceVertical.Hospitality => "HOSPITALITY",
                ProfileUpdateResponseDataBrandComplianceVertical.Financial => "FINANCIAL",
                ProfileUpdateResponseDataBrandComplianceVertical.Political => "POLITICAL",
                ProfileUpdateResponseDataBrandComplianceVertical.Gambling => "GAMBLING",
                ProfileUpdateResponseDataBrandComplianceVertical.Legal => "LEGAL",
                ProfileUpdateResponseDataBrandComplianceVertical.Construction => "CONSTRUCTION",
                ProfileUpdateResponseDataBrandComplianceVertical.Ngo => "NGO",
                ProfileUpdateResponseDataBrandComplianceVertical.Manufacturing => "MANUFACTURING",
                ProfileUpdateResponseDataBrandComplianceVertical.Government => "GOVERNMENT",
                ProfileUpdateResponseDataBrandComplianceVertical.Technology => "TECHNOLOGY",
                ProfileUpdateResponseDataBrandComplianceVertical.Communication => "COMMUNICATION",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Contact information for the brand
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileUpdateResponseDataBrandContact,
        ProfileUpdateResponseDataBrandContactFromRaw
    >)
)]
public sealed record class ProfileUpdateResponseDataBrandContact : JsonModel
{
    /// <summary>
    /// Business/brand name
    /// </summary>
    public string? BusinessName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("business_name");
        }
        init { this._rawData.Set("business_name", value); }
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
    /// Primary contact name
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
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
            return this._rawData.GetNullableClass<string>("phone_country_code");
        }
        init { this._rawData.Set("phone_country_code", value); }
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
        _ = this.BusinessName;
        _ = this.Email;
        _ = this.Name;
        _ = this.Phone;
        _ = this.PhoneCountryCode;
        _ = this.Role;
    }

    public ProfileUpdateResponseDataBrandContact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateResponseDataBrandContact(
        ProfileUpdateResponseDataBrandContact profileUpdateResponseDataBrandContact
    )
        : base(profileUpdateResponseDataBrandContact) { }
#pragma warning restore CS8618

    public ProfileUpdateResponseDataBrandContact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateResponseDataBrandContact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateResponseDataBrandContactFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateResponseDataBrandContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateResponseDataBrandContactFromRaw
    : IFromRawJson<ProfileUpdateResponseDataBrandContact>
{
    /// <inheritdoc/>
    public ProfileUpdateResponseDataBrandContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateResponseDataBrandContact.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileUpdateResponseDataBrandIdentityStatusConverter))]
public enum ProfileUpdateResponseDataBrandIdentityStatus
{
    SelfDeclared,
    Unverified,
    Verified,
    VettedVerified,
}

sealed class ProfileUpdateResponseDataBrandIdentityStatusConverter
    : JsonConverter<ProfileUpdateResponseDataBrandIdentityStatus>
{
    public override ProfileUpdateResponseDataBrandIdentityStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SELF_DECLARED" => ProfileUpdateResponseDataBrandIdentityStatus.SelfDeclared,
            "UNVERIFIED" => ProfileUpdateResponseDataBrandIdentityStatus.Unverified,
            "VERIFIED" => ProfileUpdateResponseDataBrandIdentityStatus.Verified,
            "VETTED_VERIFIED" => ProfileUpdateResponseDataBrandIdentityStatus.VettedVerified,
            _ => (ProfileUpdateResponseDataBrandIdentityStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateResponseDataBrandIdentityStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateResponseDataBrandIdentityStatus.SelfDeclared => "SELF_DECLARED",
                ProfileUpdateResponseDataBrandIdentityStatus.Unverified => "UNVERIFIED",
                ProfileUpdateResponseDataBrandIdentityStatus.Verified => "VERIFIED",
                ProfileUpdateResponseDataBrandIdentityStatus.VettedVerified => "VETTED_VERIFIED",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ProfileUpdateResponseDataBrandStatusConverter))]
public enum ProfileUpdateResponseDataBrandStatus
{
    Active,
    Inactive,
    Suspended,
}

sealed class ProfileUpdateResponseDataBrandStatusConverter
    : JsonConverter<ProfileUpdateResponseDataBrandStatus>
{
    public override ProfileUpdateResponseDataBrandStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACTIVE" => ProfileUpdateResponseDataBrandStatus.Active,
            "INACTIVE" => ProfileUpdateResponseDataBrandStatus.Inactive,
            "SUSPENDED" => ProfileUpdateResponseDataBrandStatus.Suspended,
            _ => (ProfileUpdateResponseDataBrandStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateResponseDataBrandStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateResponseDataBrandStatus.Active => "ACTIVE",
                ProfileUpdateResponseDataBrandStatus.Inactive => "INACTIVE",
                ProfileUpdateResponseDataBrandStatus.Suspended => "SUSPENDED",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Error information
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProfileUpdateResponseError, ProfileUpdateResponseErrorFromRaw>)
)]
public sealed record class ProfileUpdateResponseError : JsonModel
{
    /// <summary>
    /// Machine-readable error code (e.g., "RESOURCE_001")
    /// </summary>
    public string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    /// <summary>
    /// Additional validation error details (field-level errors)
    /// </summary>
    public IReadOnlyDictionary<string, IReadOnlyList<string>>? Details
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableClass<
                FrozenDictionary<string, ImmutableArray<string>>
            >("details");
            if (value == null)
            {
                return null;
            }

            return FrozenDictionary.ToFrozenDictionary(
                value,
                entry => entry.Key,
                (entry) => (IReadOnlyList<string>)entry.Value
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, ImmutableArray<string>>?>(
                "details",
                value == null
                    ? null
                    : FrozenDictionary.ToFrozenDictionary(
                        value,
                        entry => entry.Key,
                        (entry) => ImmutableArray.ToImmutableArray(entry.Value)
                    )
            );
        }
    }

    /// <summary>
    /// URL to documentation about this error
    /// </summary>
    public string? DocUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("doc_url");
        }
        init { this._rawData.Set("doc_url", value); }
    }

    /// <summary>
    /// Human-readable error message
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Details;
        _ = this.DocUrl;
        _ = this.Message;
    }

    public ProfileUpdateResponseError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateResponseError(ProfileUpdateResponseError profileUpdateResponseError)
        : base(profileUpdateResponseError) { }
#pragma warning restore CS8618

    public ProfileUpdateResponseError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateResponseError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateResponseErrorFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateResponseErrorFromRaw : IFromRawJson<ProfileUpdateResponseError>
{
    /// <inheritdoc/>
    public ProfileUpdateResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateResponseError.FromRawUnchecked(rawData);
}

/// <summary>
/// Request and response metadata
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProfileUpdateResponseMeta, ProfileUpdateResponseMetaFromRaw>)
)]
public sealed record class ProfileUpdateResponseMeta : JsonModel
{
    /// <summary>
    /// Unique identifier for this request (for tracing and support)
    /// </summary>
    public string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("request_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("request_id", value);
        }
    }

    /// <summary>
    /// Server timestamp when the response was generated
    /// </summary>
    public DateTimeOffset? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("timestamp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    /// <summary>
    /// API version used for this request
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RequestID;
        _ = this.Timestamp;
        _ = this.Version;
    }

    public ProfileUpdateResponseMeta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateResponseMeta(ProfileUpdateResponseMeta profileUpdateResponseMeta)
        : base(profileUpdateResponseMeta) { }
#pragma warning restore CS8618

    public ProfileUpdateResponseMeta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateResponseMeta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateResponseMetaFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateResponseMetaFromRaw : IFromRawJson<ProfileUpdateResponseMeta>
{
    /// <inheritdoc/>
    public ProfileUpdateResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateResponseMeta.FromRawUnchecked(rawData);
}
