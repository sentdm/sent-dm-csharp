using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Brands;

namespace Sentdm.Models.Profiles;

/// <summary>
/// Updates a profile's configuration and settings. Requires admin role in the organization.
/// Only provided fields will be updated (partial update).
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
    /// Billing contact for this profile. Required when billing_model is "profile"
    /// or "profile_and_organization" and no billing contact has been configured yet.
    /// Identifies who receives invoices and who is responsible for payment.
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
    /// Brand and KYC information for this profile (optional). When provided, creates
    /// or updates the brand associated with this profile. Cannot be set when inherit_tcr_brand
    /// is true. Once a brand has been submitted to TCR it cannot be modified.
    /// </summary>
    public BrandData? Brand
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BrandData>("brand");
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

/// <summary>
/// Billing contact for this profile. Required when billing_model is "profile" or
/// "profile_and_organization" and no billing contact has been configured yet. Identifies
/// who receives invoices and who is responsible for payment.
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
