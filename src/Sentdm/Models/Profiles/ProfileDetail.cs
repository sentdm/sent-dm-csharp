using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Brands;

namespace Sentdm.Models.Profiles;

/// <summary>
/// Detailed profile response for v3 API
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileDetail, ProfileDetailFromRaw>))]
public sealed record class ProfileDetail : JsonModel
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
    /// Billing contact for this profile. Present when billing_model is "profile"
    /// or "profile_and_organization".
    /// </summary>
    public ProfileDetailBillingContact? BillingContact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileDetailBillingContact>("billing_contact");
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
    /// Brand associated with this profile. Null if no brand has been configured
    /// yet. Includes KYC information and TCR registration status.
    /// </summary>
    public BrandWithKyc? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrandWithKyc>("brand");
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

    public ProfileDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileDetail(ProfileDetail profileDetail)
        : base(profileDetail) { }
#pragma warning restore CS8618

    public ProfileDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileDetailFromRaw.FromRawUnchecked"/>
    public static ProfileDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileDetailFromRaw : IFromRawJson<ProfileDetail>
{
    /// <inheritdoc/>
    public ProfileDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProfileDetail.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing contact for this profile. Present when billing_model is "profile" or "profile_and_organization".
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProfileDetailBillingContact, ProfileDetailBillingContactFromRaw>)
)]
public sealed record class ProfileDetailBillingContact : JsonModel
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

    public ProfileDetailBillingContact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileDetailBillingContact(ProfileDetailBillingContact profileDetailBillingContact)
        : base(profileDetailBillingContact) { }
#pragma warning restore CS8618

    public ProfileDetailBillingContact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileDetailBillingContact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileDetailBillingContactFromRaw.FromRawUnchecked"/>
    public static ProfileDetailBillingContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileDetailBillingContactFromRaw : IFromRawJson<ProfileDetailBillingContact>
{
    /// <inheritdoc/>
    public ProfileDetailBillingContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileDetailBillingContact.FromRawUnchecked(rawData);
}
