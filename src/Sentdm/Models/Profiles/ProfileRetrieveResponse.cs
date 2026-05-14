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
[JsonConverter(typeof(JsonModelConverter<ProfileRetrieveResponse, ProfileRetrieveResponseFromRaw>))]
public sealed record class ProfileRetrieveResponse : JsonModel
{
    /// <summary>
    /// Detailed profile response for v3 API
    /// </summary>
    public ProfileRetrieveResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileRetrieveResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public ProfileRetrieveResponseError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileRetrieveResponseError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public ProfileRetrieveResponseMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileRetrieveResponseMeta>("meta");
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

    public ProfileRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRetrieveResponse(ProfileRetrieveResponse profileRetrieveResponse)
        : base(profileRetrieveResponse) { }
#pragma warning restore CS8618

    public ProfileRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ProfileRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileRetrieveResponseFromRaw : IFromRawJson<ProfileRetrieveResponse>
{
    /// <inheritdoc/>
    public ProfileRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Detailed profile response for v3 API
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProfileRetrieveResponseData, ProfileRetrieveResponseDataFromRaw>)
)]
public sealed record class ProfileRetrieveResponseData : JsonModel
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
    public ProfileRetrieveResponseDataBillingContact? BillingContact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileRetrieveResponseDataBillingContact>(
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
    public ProfileRetrieveResponseDataBrand? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileRetrieveResponseDataBrand>("brand");
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

    public ProfileRetrieveResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRetrieveResponseData(ProfileRetrieveResponseData profileRetrieveResponseData)
        : base(profileRetrieveResponseData) { }
#pragma warning restore CS8618

    public ProfileRetrieveResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRetrieveResponseDataFromRaw.FromRawUnchecked"/>
    public static ProfileRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileRetrieveResponseDataFromRaw : IFromRawJson<ProfileRetrieveResponseData>
{
    /// <inheritdoc/>
    public ProfileRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileRetrieveResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing contact info returned in profile responses
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileRetrieveResponseDataBillingContact,
        ProfileRetrieveResponseDataBillingContactFromRaw
    >)
)]
public sealed record class ProfileRetrieveResponseDataBillingContact : JsonModel
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

    public ProfileRetrieveResponseDataBillingContact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRetrieveResponseDataBillingContact(
        ProfileRetrieveResponseDataBillingContact profileRetrieveResponseDataBillingContact
    )
        : base(profileRetrieveResponseDataBillingContact) { }
#pragma warning restore CS8618

    public ProfileRetrieveResponseDataBillingContact(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveResponseDataBillingContact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRetrieveResponseDataBillingContactFromRaw.FromRawUnchecked"/>
    public static ProfileRetrieveResponseDataBillingContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileRetrieveResponseDataBillingContactFromRaw
    : IFromRawJson<ProfileRetrieveResponseDataBillingContact>
{
    /// <inheritdoc/>
    public ProfileRetrieveResponseDataBillingContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileRetrieveResponseDataBillingContact.FromRawUnchecked(rawData);
}

/// <summary>
/// Brand response with nested contact, business, and compliance sections — mirrors
/// the request structure.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileRetrieveResponseDataBrand,
        ProfileRetrieveResponseDataBrandFromRaw
    >)
)]
public sealed record class ProfileRetrieveResponseDataBrand : JsonModel
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
    public ProfileRetrieveResponseDataBrandBusiness? Business
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileRetrieveResponseDataBrandBusiness>(
                "business"
            );
        }
        init { this._rawData.Set("business", value); }
    }

    /// <summary>
    /// Compliance and TCR-related information
    /// </summary>
    public ProfileRetrieveResponseDataBrandCompliance? Compliance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileRetrieveResponseDataBrandCompliance>(
                "compliance"
            );
        }
        init { this._rawData.Set("compliance", value); }
    }

    /// <summary>
    /// Contact information for the brand
    /// </summary>
    public ProfileRetrieveResponseDataBrandContact? Contact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileRetrieveResponseDataBrandContact>(
                "contact"
            );
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

    public ApiEnum<string, ProfileRetrieveResponseDataBrandIdentityStatus>? IdentityStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProfileRetrieveResponseDataBrandIdentityStatus>
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

    public ApiEnum<string, ProfileRetrieveResponseDataBrandStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProfileRetrieveResponseDataBrandStatus>
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

    public ProfileRetrieveResponseDataBrand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRetrieveResponseDataBrand(
        ProfileRetrieveResponseDataBrand profileRetrieveResponseDataBrand
    )
        : base(profileRetrieveResponseDataBrand) { }
#pragma warning restore CS8618

    public ProfileRetrieveResponseDataBrand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveResponseDataBrand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRetrieveResponseDataBrandFromRaw.FromRawUnchecked"/>
    public static ProfileRetrieveResponseDataBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileRetrieveResponseDataBrandFromRaw : IFromRawJson<ProfileRetrieveResponseDataBrand>
{
    /// <inheritdoc/>
    public ProfileRetrieveResponseDataBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileRetrieveResponseDataBrand.FromRawUnchecked(rawData);
}

/// <summary>
/// Business details and address information
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileRetrieveResponseDataBrandBusiness,
        ProfileRetrieveResponseDataBrandBusinessFromRaw
    >)
)]
public sealed record class ProfileRetrieveResponseDataBrandBusiness : JsonModel
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

    public ProfileRetrieveResponseDataBrandBusiness() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRetrieveResponseDataBrandBusiness(
        ProfileRetrieveResponseDataBrandBusiness profileRetrieveResponseDataBrandBusiness
    )
        : base(profileRetrieveResponseDataBrandBusiness) { }
#pragma warning restore CS8618

    public ProfileRetrieveResponseDataBrandBusiness(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveResponseDataBrandBusiness(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRetrieveResponseDataBrandBusinessFromRaw.FromRawUnchecked"/>
    public static ProfileRetrieveResponseDataBrandBusiness FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileRetrieveResponseDataBrandBusinessFromRaw
    : IFromRawJson<ProfileRetrieveResponseDataBrandBusiness>
{
    /// <inheritdoc/>
    public ProfileRetrieveResponseDataBrandBusiness FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileRetrieveResponseDataBrandBusiness.FromRawUnchecked(rawData);
}

/// <summary>
/// Compliance and TCR-related information
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileRetrieveResponseDataBrandCompliance,
        ProfileRetrieveResponseDataBrandComplianceFromRaw
    >)
)]
public sealed record class ProfileRetrieveResponseDataBrandCompliance : JsonModel
{
    public ApiEnum<
        string,
        ProfileRetrieveResponseDataBrandComplianceBrandRelationship
    >? BrandRelationship
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProfileRetrieveResponseDataBrandComplianceBrandRelationship>
            >("brand_relationship");
        }
        init { this._rawData.Set("brand_relationship", value); }
    }

    /// <summary>
    /// List of destination countries for messaging
    /// </summary>
    public IReadOnlyList<ProfileRetrieveResponseDataBrandComplianceDestinationCountry>? DestinationCountries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ProfileRetrieveResponseDataBrandComplianceDestinationCountry>
            >("destination_countries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ProfileRetrieveResponseDataBrandComplianceDestinationCountry>?>(
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

    public ApiEnum<string, ProfileRetrieveResponseDataBrandComplianceVertical>? Vertical
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProfileRetrieveResponseDataBrandComplianceVertical>
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

    public ProfileRetrieveResponseDataBrandCompliance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRetrieveResponseDataBrandCompliance(
        ProfileRetrieveResponseDataBrandCompliance profileRetrieveResponseDataBrandCompliance
    )
        : base(profileRetrieveResponseDataBrandCompliance) { }
#pragma warning restore CS8618

    public ProfileRetrieveResponseDataBrandCompliance(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveResponseDataBrandCompliance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRetrieveResponseDataBrandComplianceFromRaw.FromRawUnchecked"/>
    public static ProfileRetrieveResponseDataBrandCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileRetrieveResponseDataBrandComplianceFromRaw
    : IFromRawJson<ProfileRetrieveResponseDataBrandCompliance>
{
    /// <inheritdoc/>
    public ProfileRetrieveResponseDataBrandCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileRetrieveResponseDataBrandCompliance.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileRetrieveResponseDataBrandComplianceBrandRelationshipConverter))]
public enum ProfileRetrieveResponseDataBrandComplianceBrandRelationship
{
    BasicAccount,
    MediumAccount,
    LargeAccount,
    SmallAccount,
    KeyAccount,
}

sealed class ProfileRetrieveResponseDataBrandComplianceBrandRelationshipConverter
    : JsonConverter<ProfileRetrieveResponseDataBrandComplianceBrandRelationship>
{
    public override ProfileRetrieveResponseDataBrandComplianceBrandRelationship Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BASIC_ACCOUNT" =>
                ProfileRetrieveResponseDataBrandComplianceBrandRelationship.BasicAccount,
            "MEDIUM_ACCOUNT" =>
                ProfileRetrieveResponseDataBrandComplianceBrandRelationship.MediumAccount,
            "LARGE_ACCOUNT" =>
                ProfileRetrieveResponseDataBrandComplianceBrandRelationship.LargeAccount,
            "SMALL_ACCOUNT" =>
                ProfileRetrieveResponseDataBrandComplianceBrandRelationship.SmallAccount,
            "KEY_ACCOUNT" => ProfileRetrieveResponseDataBrandComplianceBrandRelationship.KeyAccount,
            _ => (ProfileRetrieveResponseDataBrandComplianceBrandRelationship)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileRetrieveResponseDataBrandComplianceBrandRelationship value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileRetrieveResponseDataBrandComplianceBrandRelationship.BasicAccount =>
                    "BASIC_ACCOUNT",
                ProfileRetrieveResponseDataBrandComplianceBrandRelationship.MediumAccount =>
                    "MEDIUM_ACCOUNT",
                ProfileRetrieveResponseDataBrandComplianceBrandRelationship.LargeAccount =>
                    "LARGE_ACCOUNT",
                ProfileRetrieveResponseDataBrandComplianceBrandRelationship.SmallAccount =>
                    "SMALL_ACCOUNT",
                ProfileRetrieveResponseDataBrandComplianceBrandRelationship.KeyAccount =>
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
        ProfileRetrieveResponseDataBrandComplianceDestinationCountry,
        ProfileRetrieveResponseDataBrandComplianceDestinationCountryFromRaw
    >)
)]
public sealed record class ProfileRetrieveResponseDataBrandComplianceDestinationCountry : JsonModel
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

    public ProfileRetrieveResponseDataBrandComplianceDestinationCountry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRetrieveResponseDataBrandComplianceDestinationCountry(
        ProfileRetrieveResponseDataBrandComplianceDestinationCountry profileRetrieveResponseDataBrandComplianceDestinationCountry
    )
        : base(profileRetrieveResponseDataBrandComplianceDestinationCountry) { }
#pragma warning restore CS8618

    public ProfileRetrieveResponseDataBrandComplianceDestinationCountry(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveResponseDataBrandComplianceDestinationCountry(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRetrieveResponseDataBrandComplianceDestinationCountryFromRaw.FromRawUnchecked"/>
    public static ProfileRetrieveResponseDataBrandComplianceDestinationCountry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileRetrieveResponseDataBrandComplianceDestinationCountryFromRaw
    : IFromRawJson<ProfileRetrieveResponseDataBrandComplianceDestinationCountry>
{
    /// <inheritdoc/>
    public ProfileRetrieveResponseDataBrandComplianceDestinationCountry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileRetrieveResponseDataBrandComplianceDestinationCountry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileRetrieveResponseDataBrandComplianceVerticalConverter))]
public enum ProfileRetrieveResponseDataBrandComplianceVertical
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

sealed class ProfileRetrieveResponseDataBrandComplianceVerticalConverter
    : JsonConverter<ProfileRetrieveResponseDataBrandComplianceVertical>
{
    public override ProfileRetrieveResponseDataBrandComplianceVertical Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PROFESSIONAL" => ProfileRetrieveResponseDataBrandComplianceVertical.Professional,
            "REAL_ESTATE" => ProfileRetrieveResponseDataBrandComplianceVertical.RealEstate,
            "HEALTHCARE" => ProfileRetrieveResponseDataBrandComplianceVertical.Healthcare,
            "HUMAN_RESOURCES" => ProfileRetrieveResponseDataBrandComplianceVertical.HumanResources,
            "ENERGY" => ProfileRetrieveResponseDataBrandComplianceVertical.Energy,
            "ENTERTAINMENT" => ProfileRetrieveResponseDataBrandComplianceVertical.Entertainment,
            "RETAIL" => ProfileRetrieveResponseDataBrandComplianceVertical.Retail,
            "TRANSPORTATION" => ProfileRetrieveResponseDataBrandComplianceVertical.Transportation,
            "AGRICULTURE" => ProfileRetrieveResponseDataBrandComplianceVertical.Agriculture,
            "INSURANCE" => ProfileRetrieveResponseDataBrandComplianceVertical.Insurance,
            "POSTAL" => ProfileRetrieveResponseDataBrandComplianceVertical.Postal,
            "EDUCATION" => ProfileRetrieveResponseDataBrandComplianceVertical.Education,
            "HOSPITALITY" => ProfileRetrieveResponseDataBrandComplianceVertical.Hospitality,
            "FINANCIAL" => ProfileRetrieveResponseDataBrandComplianceVertical.Financial,
            "POLITICAL" => ProfileRetrieveResponseDataBrandComplianceVertical.Political,
            "GAMBLING" => ProfileRetrieveResponseDataBrandComplianceVertical.Gambling,
            "LEGAL" => ProfileRetrieveResponseDataBrandComplianceVertical.Legal,
            "CONSTRUCTION" => ProfileRetrieveResponseDataBrandComplianceVertical.Construction,
            "NGO" => ProfileRetrieveResponseDataBrandComplianceVertical.Ngo,
            "MANUFACTURING" => ProfileRetrieveResponseDataBrandComplianceVertical.Manufacturing,
            "GOVERNMENT" => ProfileRetrieveResponseDataBrandComplianceVertical.Government,
            "TECHNOLOGY" => ProfileRetrieveResponseDataBrandComplianceVertical.Technology,
            "COMMUNICATION" => ProfileRetrieveResponseDataBrandComplianceVertical.Communication,
            _ => (ProfileRetrieveResponseDataBrandComplianceVertical)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileRetrieveResponseDataBrandComplianceVertical value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileRetrieveResponseDataBrandComplianceVertical.Professional => "PROFESSIONAL",
                ProfileRetrieveResponseDataBrandComplianceVertical.RealEstate => "REAL_ESTATE",
                ProfileRetrieveResponseDataBrandComplianceVertical.Healthcare => "HEALTHCARE",
                ProfileRetrieveResponseDataBrandComplianceVertical.HumanResources =>
                    "HUMAN_RESOURCES",
                ProfileRetrieveResponseDataBrandComplianceVertical.Energy => "ENERGY",
                ProfileRetrieveResponseDataBrandComplianceVertical.Entertainment => "ENTERTAINMENT",
                ProfileRetrieveResponseDataBrandComplianceVertical.Retail => "RETAIL",
                ProfileRetrieveResponseDataBrandComplianceVertical.Transportation =>
                    "TRANSPORTATION",
                ProfileRetrieveResponseDataBrandComplianceVertical.Agriculture => "AGRICULTURE",
                ProfileRetrieveResponseDataBrandComplianceVertical.Insurance => "INSURANCE",
                ProfileRetrieveResponseDataBrandComplianceVertical.Postal => "POSTAL",
                ProfileRetrieveResponseDataBrandComplianceVertical.Education => "EDUCATION",
                ProfileRetrieveResponseDataBrandComplianceVertical.Hospitality => "HOSPITALITY",
                ProfileRetrieveResponseDataBrandComplianceVertical.Financial => "FINANCIAL",
                ProfileRetrieveResponseDataBrandComplianceVertical.Political => "POLITICAL",
                ProfileRetrieveResponseDataBrandComplianceVertical.Gambling => "GAMBLING",
                ProfileRetrieveResponseDataBrandComplianceVertical.Legal => "LEGAL",
                ProfileRetrieveResponseDataBrandComplianceVertical.Construction => "CONSTRUCTION",
                ProfileRetrieveResponseDataBrandComplianceVertical.Ngo => "NGO",
                ProfileRetrieveResponseDataBrandComplianceVertical.Manufacturing => "MANUFACTURING",
                ProfileRetrieveResponseDataBrandComplianceVertical.Government => "GOVERNMENT",
                ProfileRetrieveResponseDataBrandComplianceVertical.Technology => "TECHNOLOGY",
                ProfileRetrieveResponseDataBrandComplianceVertical.Communication => "COMMUNICATION",
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
        ProfileRetrieveResponseDataBrandContact,
        ProfileRetrieveResponseDataBrandContactFromRaw
    >)
)]
public sealed record class ProfileRetrieveResponseDataBrandContact : JsonModel
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

    public ProfileRetrieveResponseDataBrandContact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRetrieveResponseDataBrandContact(
        ProfileRetrieveResponseDataBrandContact profileRetrieveResponseDataBrandContact
    )
        : base(profileRetrieveResponseDataBrandContact) { }
#pragma warning restore CS8618

    public ProfileRetrieveResponseDataBrandContact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveResponseDataBrandContact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRetrieveResponseDataBrandContactFromRaw.FromRawUnchecked"/>
    public static ProfileRetrieveResponseDataBrandContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileRetrieveResponseDataBrandContactFromRaw
    : IFromRawJson<ProfileRetrieveResponseDataBrandContact>
{
    /// <inheritdoc/>
    public ProfileRetrieveResponseDataBrandContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileRetrieveResponseDataBrandContact.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileRetrieveResponseDataBrandIdentityStatusConverter))]
public enum ProfileRetrieveResponseDataBrandIdentityStatus
{
    SelfDeclared,
    Unverified,
    Verified,
    VettedVerified,
}

sealed class ProfileRetrieveResponseDataBrandIdentityStatusConverter
    : JsonConverter<ProfileRetrieveResponseDataBrandIdentityStatus>
{
    public override ProfileRetrieveResponseDataBrandIdentityStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SELF_DECLARED" => ProfileRetrieveResponseDataBrandIdentityStatus.SelfDeclared,
            "UNVERIFIED" => ProfileRetrieveResponseDataBrandIdentityStatus.Unverified,
            "VERIFIED" => ProfileRetrieveResponseDataBrandIdentityStatus.Verified,
            "VETTED_VERIFIED" => ProfileRetrieveResponseDataBrandIdentityStatus.VettedVerified,
            _ => (ProfileRetrieveResponseDataBrandIdentityStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileRetrieveResponseDataBrandIdentityStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileRetrieveResponseDataBrandIdentityStatus.SelfDeclared => "SELF_DECLARED",
                ProfileRetrieveResponseDataBrandIdentityStatus.Unverified => "UNVERIFIED",
                ProfileRetrieveResponseDataBrandIdentityStatus.Verified => "VERIFIED",
                ProfileRetrieveResponseDataBrandIdentityStatus.VettedVerified => "VETTED_VERIFIED",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ProfileRetrieveResponseDataBrandStatusConverter))]
public enum ProfileRetrieveResponseDataBrandStatus
{
    Active,
    Inactive,
    Suspended,
}

sealed class ProfileRetrieveResponseDataBrandStatusConverter
    : JsonConverter<ProfileRetrieveResponseDataBrandStatus>
{
    public override ProfileRetrieveResponseDataBrandStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACTIVE" => ProfileRetrieveResponseDataBrandStatus.Active,
            "INACTIVE" => ProfileRetrieveResponseDataBrandStatus.Inactive,
            "SUSPENDED" => ProfileRetrieveResponseDataBrandStatus.Suspended,
            _ => (ProfileRetrieveResponseDataBrandStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileRetrieveResponseDataBrandStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileRetrieveResponseDataBrandStatus.Active => "ACTIVE",
                ProfileRetrieveResponseDataBrandStatus.Inactive => "INACTIVE",
                ProfileRetrieveResponseDataBrandStatus.Suspended => "SUSPENDED",
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
    typeof(JsonModelConverter<ProfileRetrieveResponseError, ProfileRetrieveResponseErrorFromRaw>)
)]
public sealed record class ProfileRetrieveResponseError : JsonModel
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

    public ProfileRetrieveResponseError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRetrieveResponseError(ProfileRetrieveResponseError profileRetrieveResponseError)
        : base(profileRetrieveResponseError) { }
#pragma warning restore CS8618

    public ProfileRetrieveResponseError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveResponseError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRetrieveResponseErrorFromRaw.FromRawUnchecked"/>
    public static ProfileRetrieveResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileRetrieveResponseErrorFromRaw : IFromRawJson<ProfileRetrieveResponseError>
{
    /// <inheritdoc/>
    public ProfileRetrieveResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileRetrieveResponseError.FromRawUnchecked(rawData);
}

/// <summary>
/// Request and response metadata
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProfileRetrieveResponseMeta, ProfileRetrieveResponseMetaFromRaw>)
)]
public sealed record class ProfileRetrieveResponseMeta : JsonModel
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

    public ProfileRetrieveResponseMeta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRetrieveResponseMeta(ProfileRetrieveResponseMeta profileRetrieveResponseMeta)
        : base(profileRetrieveResponseMeta) { }
#pragma warning restore CS8618

    public ProfileRetrieveResponseMeta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveResponseMeta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRetrieveResponseMetaFromRaw.FromRawUnchecked"/>
    public static ProfileRetrieveResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileRetrieveResponseMetaFromRaw : IFromRawJson<ProfileRetrieveResponseMeta>
{
    /// <inheritdoc/>
    public ProfileRetrieveResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileRetrieveResponseMeta.FromRawUnchecked(rawData);
}
