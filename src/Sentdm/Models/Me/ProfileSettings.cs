using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Me;

/// <summary>
/// Profile configuration settings
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileSettings, ProfileSettingsFromRaw>))]
public sealed record class ProfileSettings : JsonModel
{
    /// <summary>
    /// Always false. A profile no longer shares contacts with sibling profiles —
    /// it sees only what it owns. Retained so existing v3 clients reading allow_contact_sharing
    /// keep deserializing; it carries no information.
    /// </summary>
    [Obsolete("deprecated")]
    public bool? AllowContactSharing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_contact_sharing");
        }
        init { this._rawData.Set("allow_contact_sharing", value); }
    }

    /// <summary>
    /// Always false. A profile no longer shares templates with sibling profiles.
    /// Retained so existing v3 clients reading allow_template_sharing keep deserializing;
    /// it carries no information.
    /// </summary>
    [Obsolete("deprecated")]
    public bool? AllowTemplateSharing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_template_sharing");
        }
        init { this._rawData.Set("allow_template_sharing", value); }
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
        init { this._rawData.Set("billing_model", value); }
    }

    /// <summary>
    /// Always false. A profile no longer inherits its organization's contacts. Retained
    /// so existing v3 clients reading inherit_contacts keep deserializing; it carries
    /// no information.
    /// </summary>
    [Obsolete("deprecated")]
    public bool? InheritContacts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inherit_contacts");
        }
        init { this._rawData.Set("inherit_contacts", value); }
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
        init { this._rawData.Set("inherit_tcr_brand", value); }
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
        init { this._rawData.Set("inherit_tcr_campaign", value); }
    }

    /// <summary>
    /// Always false. A profile no longer inherits its organization's templates.
    /// Retained so existing v3 clients reading inherit_templates keep deserializing;
    /// it carries no information.
    /// </summary>
    [Obsolete("deprecated")]
    public bool? InheritTemplates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inherit_templates");
        }
        init { this._rawData.Set("inherit_templates", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowContactSharing;
        _ = this.AllowTemplateSharing;
        _ = this.BillingModel;
        _ = this.InheritContacts;
        _ = this.InheritTcrBrand;
        _ = this.InheritTcrCampaign;
        _ = this.InheritTemplates;
    }

    public ProfileSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileSettings(ProfileSettings profileSettings)
        : base(profileSettings) { }
#pragma warning restore CS8618

    public ProfileSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileSettingsFromRaw.FromRawUnchecked"/>
    public static ProfileSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileSettingsFromRaw : IFromRawJson<ProfileSettings>
{
    /// <inheritdoc/>
    public ProfileSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProfileSettings.FromRawUnchecked(rawData);
}
