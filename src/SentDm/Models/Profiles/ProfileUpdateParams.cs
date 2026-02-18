using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using SentDm.Core;

namespace SentDm.Models.Profiles;

/// <summary>
/// Updates a profile's configuration and settings. Requires admin role in the organization.
/// Only provided fields will be updated (partial update).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ProfileUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ProfileID { get; init; }

    /// <summary>
    /// Whether contacts are shared across profiles (optional)
    /// </summary>
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

    /// <summary>
    /// Whether templates are shared across profiles (optional)
    /// </summary>
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
    /// Billing model: profile, organization, or profile_and_organization (optional)
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

    /// <summary>
    /// Whether this profile inherits contacts from organization (optional)
    /// </summary>
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

    /// <summary>
    /// Whether this profile inherits templates from organization (optional)
    /// </summary>
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
    /// Profile ID from route parameter
    /// </summary>
    public string? ProfileIDValue
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("profile_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("profile_id", value);
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
    /// Reference to another profile to use for SMS/Telnyx configuration (optional)
    /// </summary>
    public string? SendingPhoneNumberProfileID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("sending_phone_number_profile_id");
        }
        init { this._rawBodyData.Set("sending_phone_number_profile_id", value); }
    }

    /// <summary>
    /// Reference to another profile to use for WhatsApp configuration (optional)
    /// </summary>
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
    /// Profile short name/abbreviation (optional)
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
    /// Test mode flag - when true, the operation is simulated without side effects
    /// Useful for testing integrations without actual execution
    /// </summary>
    public bool? TestMode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("test_mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("test_mode", value);
        }
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
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ProfileUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
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
