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
[JsonConverter(typeof(JsonModelConverter<ProfileListResponse, ProfileListResponseFromRaw>))]
public sealed record class ProfileListResponse : JsonModel
{
    /// <summary>
    /// List of profiles response
    /// </summary>
    public ProfileListResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileListResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public ProfileListResponseError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileListResponseError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public ProfileListResponseMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileListResponseMeta>("meta");
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

    public ProfileListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileListResponse(ProfileListResponse profileListResponse)
        : base(profileListResponse) { }
#pragma warning restore CS8618

    public ProfileListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileListResponseFromRaw.FromRawUnchecked"/>
    public static ProfileListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileListResponseFromRaw : IFromRawJson<ProfileListResponse>
{
    /// <inheritdoc/>
    public ProfileListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProfileListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// List of profiles response
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileListResponseData, ProfileListResponseDataFromRaw>))]
public sealed record class ProfileListResponseData : JsonModel
{
    /// <summary>
    /// List of profiles in the organization
    /// </summary>
    public IReadOnlyList<Profile>? Profiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Profile>>("profiles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Profile>?>(
                "profiles",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Profiles ?? [])
        {
            item.Validate();
        }
    }

    public ProfileListResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileListResponseData(ProfileListResponseData profileListResponseData)
        : base(profileListResponseData) { }
#pragma warning restore CS8618

    public ProfileListResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileListResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileListResponseDataFromRaw.FromRawUnchecked"/>
    public static ProfileListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileListResponseDataFromRaw : IFromRawJson<ProfileListResponseData>
{
    /// <inheritdoc/>
    public ProfileListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileListResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Detailed profile response for v3 API
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Profile, ProfileFromRaw>))]
public sealed record class Profile : JsonModel
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
    public ProfileBillingContact? BillingContact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileBillingContact>("billing_contact");
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
    public ProfileBrand? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileBrand>("brand");
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

    public Profile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Profile(Profile profile)
        : base(profile) { }
#pragma warning restore CS8618

    public Profile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Profile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileFromRaw.FromRawUnchecked"/>
    public static Profile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileFromRaw : IFromRawJson<Profile>
{
    /// <inheritdoc/>
    public Profile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Profile.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing contact info returned in profile responses
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileBillingContact, ProfileBillingContactFromRaw>))]
public sealed record class ProfileBillingContact : JsonModel
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

    public ProfileBillingContact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileBillingContact(ProfileBillingContact profileBillingContact)
        : base(profileBillingContact) { }
#pragma warning restore CS8618

    public ProfileBillingContact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileBillingContact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileBillingContactFromRaw.FromRawUnchecked"/>
    public static ProfileBillingContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileBillingContactFromRaw : IFromRawJson<ProfileBillingContact>
{
    /// <inheritdoc/>
    public ProfileBillingContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileBillingContact.FromRawUnchecked(rawData);
}

/// <summary>
/// Brand response with nested contact, business, and compliance sections — mirrors
/// the request structure.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileBrand, ProfileBrandFromRaw>))]
public sealed record class ProfileBrand : JsonModel
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
    public ProfileBrandBusiness? Business
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileBrandBusiness>("business");
        }
        init { this._rawData.Set("business", value); }
    }

    /// <summary>
    /// Compliance and TCR-related information
    /// </summary>
    public ProfileBrandCompliance? Compliance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileBrandCompliance>("compliance");
        }
        init { this._rawData.Set("compliance", value); }
    }

    /// <summary>
    /// Contact information for the brand
    /// </summary>
    public ProfileBrandContact? Contact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileBrandContact>("contact");
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

    public ApiEnum<string, ProfileBrandIdentityStatus>? IdentityStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ProfileBrandIdentityStatus>>(
                "identity_status"
            );
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

    public ApiEnum<string, ProfileBrandStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ProfileBrandStatus>>("status");
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

    public ProfileBrand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileBrand(ProfileBrand profileBrand)
        : base(profileBrand) { }
#pragma warning restore CS8618

    public ProfileBrand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileBrand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileBrandFromRaw.FromRawUnchecked"/>
    public static ProfileBrand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileBrandFromRaw : IFromRawJson<ProfileBrand>
{
    /// <inheritdoc/>
    public ProfileBrand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProfileBrand.FromRawUnchecked(rawData);
}

/// <summary>
/// Business details and address information
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileBrandBusiness, ProfileBrandBusinessFromRaw>))]
public sealed record class ProfileBrandBusiness : JsonModel
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

    public ProfileBrandBusiness() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileBrandBusiness(ProfileBrandBusiness profileBrandBusiness)
        : base(profileBrandBusiness) { }
#pragma warning restore CS8618

    public ProfileBrandBusiness(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileBrandBusiness(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileBrandBusinessFromRaw.FromRawUnchecked"/>
    public static ProfileBrandBusiness FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileBrandBusinessFromRaw : IFromRawJson<ProfileBrandBusiness>
{
    /// <inheritdoc/>
    public ProfileBrandBusiness FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileBrandBusiness.FromRawUnchecked(rawData);
}

/// <summary>
/// Compliance and TCR-related information
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileBrandCompliance, ProfileBrandComplianceFromRaw>))]
public sealed record class ProfileBrandCompliance : JsonModel
{
    public ApiEnum<string, ProfileBrandComplianceBrandRelationship>? BrandRelationship
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProfileBrandComplianceBrandRelationship>
            >("brand_relationship");
        }
        init { this._rawData.Set("brand_relationship", value); }
    }

    /// <summary>
    /// List of destination countries for messaging
    /// </summary>
    public IReadOnlyList<ProfileBrandComplianceDestinationCountry>? DestinationCountries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ProfileBrandComplianceDestinationCountry>
            >("destination_countries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ProfileBrandComplianceDestinationCountry>?>(
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

    public ApiEnum<string, ProfileBrandComplianceVertical>? Vertical
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ProfileBrandComplianceVertical>>(
                "vertical"
            );
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

    public ProfileBrandCompliance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileBrandCompliance(ProfileBrandCompliance profileBrandCompliance)
        : base(profileBrandCompliance) { }
#pragma warning restore CS8618

    public ProfileBrandCompliance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileBrandCompliance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileBrandComplianceFromRaw.FromRawUnchecked"/>
    public static ProfileBrandCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileBrandComplianceFromRaw : IFromRawJson<ProfileBrandCompliance>
{
    /// <inheritdoc/>
    public ProfileBrandCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileBrandCompliance.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileBrandComplianceBrandRelationshipConverter))]
public enum ProfileBrandComplianceBrandRelationship
{
    BasicAccount,
    MediumAccount,
    LargeAccount,
    SmallAccount,
    KeyAccount,
}

sealed class ProfileBrandComplianceBrandRelationshipConverter
    : JsonConverter<ProfileBrandComplianceBrandRelationship>
{
    public override ProfileBrandComplianceBrandRelationship Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BASIC_ACCOUNT" => ProfileBrandComplianceBrandRelationship.BasicAccount,
            "MEDIUM_ACCOUNT" => ProfileBrandComplianceBrandRelationship.MediumAccount,
            "LARGE_ACCOUNT" => ProfileBrandComplianceBrandRelationship.LargeAccount,
            "SMALL_ACCOUNT" => ProfileBrandComplianceBrandRelationship.SmallAccount,
            "KEY_ACCOUNT" => ProfileBrandComplianceBrandRelationship.KeyAccount,
            _ => (ProfileBrandComplianceBrandRelationship)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileBrandComplianceBrandRelationship value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileBrandComplianceBrandRelationship.BasicAccount => "BASIC_ACCOUNT",
                ProfileBrandComplianceBrandRelationship.MediumAccount => "MEDIUM_ACCOUNT",
                ProfileBrandComplianceBrandRelationship.LargeAccount => "LARGE_ACCOUNT",
                ProfileBrandComplianceBrandRelationship.SmallAccount => "SMALL_ACCOUNT",
                ProfileBrandComplianceBrandRelationship.KeyAccount => "KEY_ACCOUNT",
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
        ProfileBrandComplianceDestinationCountry,
        ProfileBrandComplianceDestinationCountryFromRaw
    >)
)]
public sealed record class ProfileBrandComplianceDestinationCountry : JsonModel
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

    public ProfileBrandComplianceDestinationCountry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileBrandComplianceDestinationCountry(
        ProfileBrandComplianceDestinationCountry profileBrandComplianceDestinationCountry
    )
        : base(profileBrandComplianceDestinationCountry) { }
#pragma warning restore CS8618

    public ProfileBrandComplianceDestinationCountry(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileBrandComplianceDestinationCountry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileBrandComplianceDestinationCountryFromRaw.FromRawUnchecked"/>
    public static ProfileBrandComplianceDestinationCountry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileBrandComplianceDestinationCountryFromRaw
    : IFromRawJson<ProfileBrandComplianceDestinationCountry>
{
    /// <inheritdoc/>
    public ProfileBrandComplianceDestinationCountry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileBrandComplianceDestinationCountry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileBrandComplianceVerticalConverter))]
public enum ProfileBrandComplianceVertical
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

sealed class ProfileBrandComplianceVerticalConverter : JsonConverter<ProfileBrandComplianceVertical>
{
    public override ProfileBrandComplianceVertical Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PROFESSIONAL" => ProfileBrandComplianceVertical.Professional,
            "REAL_ESTATE" => ProfileBrandComplianceVertical.RealEstate,
            "HEALTHCARE" => ProfileBrandComplianceVertical.Healthcare,
            "HUMAN_RESOURCES" => ProfileBrandComplianceVertical.HumanResources,
            "ENERGY" => ProfileBrandComplianceVertical.Energy,
            "ENTERTAINMENT" => ProfileBrandComplianceVertical.Entertainment,
            "RETAIL" => ProfileBrandComplianceVertical.Retail,
            "TRANSPORTATION" => ProfileBrandComplianceVertical.Transportation,
            "AGRICULTURE" => ProfileBrandComplianceVertical.Agriculture,
            "INSURANCE" => ProfileBrandComplianceVertical.Insurance,
            "POSTAL" => ProfileBrandComplianceVertical.Postal,
            "EDUCATION" => ProfileBrandComplianceVertical.Education,
            "HOSPITALITY" => ProfileBrandComplianceVertical.Hospitality,
            "FINANCIAL" => ProfileBrandComplianceVertical.Financial,
            "POLITICAL" => ProfileBrandComplianceVertical.Political,
            "GAMBLING" => ProfileBrandComplianceVertical.Gambling,
            "LEGAL" => ProfileBrandComplianceVertical.Legal,
            "CONSTRUCTION" => ProfileBrandComplianceVertical.Construction,
            "NGO" => ProfileBrandComplianceVertical.Ngo,
            "MANUFACTURING" => ProfileBrandComplianceVertical.Manufacturing,
            "GOVERNMENT" => ProfileBrandComplianceVertical.Government,
            "TECHNOLOGY" => ProfileBrandComplianceVertical.Technology,
            "COMMUNICATION" => ProfileBrandComplianceVertical.Communication,
            _ => (ProfileBrandComplianceVertical)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileBrandComplianceVertical value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileBrandComplianceVertical.Professional => "PROFESSIONAL",
                ProfileBrandComplianceVertical.RealEstate => "REAL_ESTATE",
                ProfileBrandComplianceVertical.Healthcare => "HEALTHCARE",
                ProfileBrandComplianceVertical.HumanResources => "HUMAN_RESOURCES",
                ProfileBrandComplianceVertical.Energy => "ENERGY",
                ProfileBrandComplianceVertical.Entertainment => "ENTERTAINMENT",
                ProfileBrandComplianceVertical.Retail => "RETAIL",
                ProfileBrandComplianceVertical.Transportation => "TRANSPORTATION",
                ProfileBrandComplianceVertical.Agriculture => "AGRICULTURE",
                ProfileBrandComplianceVertical.Insurance => "INSURANCE",
                ProfileBrandComplianceVertical.Postal => "POSTAL",
                ProfileBrandComplianceVertical.Education => "EDUCATION",
                ProfileBrandComplianceVertical.Hospitality => "HOSPITALITY",
                ProfileBrandComplianceVertical.Financial => "FINANCIAL",
                ProfileBrandComplianceVertical.Political => "POLITICAL",
                ProfileBrandComplianceVertical.Gambling => "GAMBLING",
                ProfileBrandComplianceVertical.Legal => "LEGAL",
                ProfileBrandComplianceVertical.Construction => "CONSTRUCTION",
                ProfileBrandComplianceVertical.Ngo => "NGO",
                ProfileBrandComplianceVertical.Manufacturing => "MANUFACTURING",
                ProfileBrandComplianceVertical.Government => "GOVERNMENT",
                ProfileBrandComplianceVertical.Technology => "TECHNOLOGY",
                ProfileBrandComplianceVertical.Communication => "COMMUNICATION",
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
[JsonConverter(typeof(JsonModelConverter<ProfileBrandContact, ProfileBrandContactFromRaw>))]
public sealed record class ProfileBrandContact : JsonModel
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

    public ProfileBrandContact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileBrandContact(ProfileBrandContact profileBrandContact)
        : base(profileBrandContact) { }
#pragma warning restore CS8618

    public ProfileBrandContact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileBrandContact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileBrandContactFromRaw.FromRawUnchecked"/>
    public static ProfileBrandContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileBrandContactFromRaw : IFromRawJson<ProfileBrandContact>
{
    /// <inheritdoc/>
    public ProfileBrandContact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProfileBrandContact.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileBrandIdentityStatusConverter))]
public enum ProfileBrandIdentityStatus
{
    SelfDeclared,
    Unverified,
    Verified,
    VettedVerified,
}

sealed class ProfileBrandIdentityStatusConverter : JsonConverter<ProfileBrandIdentityStatus>
{
    public override ProfileBrandIdentityStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SELF_DECLARED" => ProfileBrandIdentityStatus.SelfDeclared,
            "UNVERIFIED" => ProfileBrandIdentityStatus.Unverified,
            "VERIFIED" => ProfileBrandIdentityStatus.Verified,
            "VETTED_VERIFIED" => ProfileBrandIdentityStatus.VettedVerified,
            _ => (ProfileBrandIdentityStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileBrandIdentityStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileBrandIdentityStatus.SelfDeclared => "SELF_DECLARED",
                ProfileBrandIdentityStatus.Unverified => "UNVERIFIED",
                ProfileBrandIdentityStatus.Verified => "VERIFIED",
                ProfileBrandIdentityStatus.VettedVerified => "VETTED_VERIFIED",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ProfileBrandStatusConverter))]
public enum ProfileBrandStatus
{
    Active,
    Inactive,
    Suspended,
}

sealed class ProfileBrandStatusConverter : JsonConverter<ProfileBrandStatus>
{
    public override ProfileBrandStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACTIVE" => ProfileBrandStatus.Active,
            "INACTIVE" => ProfileBrandStatus.Inactive,
            "SUSPENDED" => ProfileBrandStatus.Suspended,
            _ => (ProfileBrandStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileBrandStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileBrandStatus.Active => "ACTIVE",
                ProfileBrandStatus.Inactive => "INACTIVE",
                ProfileBrandStatus.Suspended => "SUSPENDED",
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
    typeof(JsonModelConverter<ProfileListResponseError, ProfileListResponseErrorFromRaw>)
)]
public sealed record class ProfileListResponseError : JsonModel
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

    public ProfileListResponseError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileListResponseError(ProfileListResponseError profileListResponseError)
        : base(profileListResponseError) { }
#pragma warning restore CS8618

    public ProfileListResponseError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileListResponseError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileListResponseErrorFromRaw.FromRawUnchecked"/>
    public static ProfileListResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileListResponseErrorFromRaw : IFromRawJson<ProfileListResponseError>
{
    /// <inheritdoc/>
    public ProfileListResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileListResponseError.FromRawUnchecked(rawData);
}

/// <summary>
/// Request and response metadata
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileListResponseMeta, ProfileListResponseMetaFromRaw>))]
public sealed record class ProfileListResponseMeta : JsonModel
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

    public ProfileListResponseMeta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileListResponseMeta(ProfileListResponseMeta profileListResponseMeta)
        : base(profileListResponseMeta) { }
#pragma warning restore CS8618

    public ProfileListResponseMeta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileListResponseMeta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileListResponseMetaFromRaw.FromRawUnchecked"/>
    public static ProfileListResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileListResponseMetaFromRaw : IFromRawJson<ProfileListResponseMeta>
{
    /// <inheritdoc/>
    public ProfileListResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileListResponseMeta.FromRawUnchecked(rawData);
}
