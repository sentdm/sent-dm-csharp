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
/// Creates a new sender profile within an organization. Profiles represent different
/// brands, departments, or use cases, each with their own messaging configuration
/// and settings. Requires admin role in the organization.
///
/// <para>## WhatsApp Business Account</para>
///
/// <para>Every profile must be linked to a WhatsApp Business Account. There are
/// two ways to do this:</para>
///
/// <para>**1. Inherit from organization (default)** — Omit the `whatsapp_business_account`
/// field. The profile will share the organization's WhatsApp Business Account, which
/// must have been set up via WhatsApp Embedded Signup. This is the recommended path
/// for most use cases.</para>
///
/// <para>**2. Direct credentials** — Provide a `whatsapp_business_account` object
/// with `waba_id`, `phone_number_id`, and `access_token`. Use this when the profile
/// needs its own independent WhatsApp Business Account. Obtain these from Meta Business
/// Manager by creating a System User with `whatsapp_business_messaging` and `whatsapp_business_management` permissions.</para>
///
/// <para>If the `whatsapp_business_account` field is omitted and the organization
/// has no WhatsApp Business Account configured, the request will be rejected with
/// HTTP 422.</para>
///
/// <para>## Brand</para>
///
/// <para>Include the optional `brand` field to create the brand for this profile
/// at the same time. Cannot be used when `inherit_tcr_brand` is `true`.</para>
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
public record class ProfileCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Whether contacts are shared across profiles (default: false)
    /// </summary>
    public bool? AllowContactSharing
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("allow_contact_sharing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("allow_contact_sharing", value);
        }
    }

    /// <summary>
    /// Whether templates are shared across profiles (default: false)
    /// </summary>
    public bool? AllowTemplateSharing
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("allow_template_sharing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("allow_template_sharing", value);
        }
    }

    /// <summary>
    /// Billing contact for this profile. Required when billing_model is "profile"
    /// or "profile_and_organization". Identifies who receives invoices and who is
    /// responsible for payment.
    /// </summary>
    public BillingContact? BillingContact
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BillingContact>("billing_contact");
        }
        init { this._rawBodyData.Set("billing_contact", value); }
    }

    /// <summary>
    /// Billing model: profile, organization, or profile_and_organization (default:
    /// profile). - "organization": the organization's billing details are used;
    /// no profile-level billing info needed. - "profile": the profile is billed independently;
    /// billing_contact is required. - "profile_and_organization": the profile is
    /// billed first with the organization as fallback; billing_contact is required.
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
    /// the brand associated with this profile. Cannot be set when inherit_tcr_brand
    /// is true.
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
    /// Whether this profile inherits contacts from organization (default: true)
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
    /// Whether this profile inherits TCR brand from organization (default: true)
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
    /// Whether this profile inherits TCR campaign from organization (default: true)
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
    /// Whether this profile inherits templates from organization (default: true)
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
    /// Profile name (required)
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    /// <summary>
    /// Payment card details for this profile (optional). Accepted when billing_model
    /// is "profile" or "profile_and_organization". Not persisted on our servers —
    /// forwarded to the payment processor.
    /// </summary>
    public PaymentDetails? PaymentDetails
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PaymentDetails>("payment_details");
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
    /// Direct WhatsApp Business Account credentials for this profile. When provided,
    /// the profile uses its own WhatsApp Business Account instead of inheriting from
    /// the organization. When omitted, the profile inherits the organization's WhatsApp
    /// Business Account (requires the organization to have completed WhatsApp Embedded Signup).
    /// </summary>
    public WhatsappBusinessAccount? WhatsappBusinessAccount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<WhatsappBusinessAccount>(
                "whatsapp_business_account"
            );
        }
        init { this._rawBodyData.Set("whatsapp_business_account", value); }
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

    public ProfileCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileCreateParams(ProfileCreateParams profileCreateParams)
        : base(profileCreateParams)
    {
        this._rawBodyData = new(profileCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ProfileCreateParams(
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
    ProfileCreateParams(
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
    public static ProfileCreateParams FromRawUnchecked(
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

    public virtual bool Equals(ProfileCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/profiles")
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
/// "profile_and_organization". Identifies who receives invoices and who is responsible
/// for payment.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BillingContact, BillingContactFromRaw>))]
public sealed record class BillingContact : JsonModel
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

    public BillingContact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingContact(BillingContact billingContact)
        : base(billingContact) { }
#pragma warning restore CS8618

    public BillingContact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingContact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillingContactFromRaw.FromRawUnchecked"/>
    public static BillingContact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillingContactFromRaw : IFromRawJson<BillingContact>
{
    /// <inheritdoc/>
    public BillingContact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillingContact.FromRawUnchecked(rawData);
}

/// <summary>
/// Payment card details for this profile (optional). Accepted when billing_model
/// is "profile" or "profile_and_organization". Not persisted on our servers — forwarded
/// to the payment processor.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PaymentDetails, PaymentDetailsFromRaw>))]
public sealed record class PaymentDetails : JsonModel
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

    public PaymentDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentDetails(PaymentDetails paymentDetails)
        : base(paymentDetails) { }
#pragma warning restore CS8618

    public PaymentDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentDetailsFromRaw.FromRawUnchecked"/>
    public static PaymentDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentDetailsFromRaw : IFromRawJson<PaymentDetails>
{
    /// <inheritdoc/>
    public PaymentDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaymentDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// Direct WhatsApp Business Account credentials for this profile. When provided,
/// the profile uses its own WhatsApp Business Account instead of inheriting from
/// the organization. When omitted, the profile inherits the organization's WhatsApp
/// Business Account (requires the organization to have completed WhatsApp Embedded Signup).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WhatsappBusinessAccount, WhatsappBusinessAccountFromRaw>))]
public sealed record class WhatsappBusinessAccount : JsonModel
{
    /// <summary>
    /// System User access token with whatsapp_business_messaging and whatsapp_business_management
    /// permissions. This value is stored securely and never returned in API responses.
    /// </summary>
    public required string AccessToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("access_token");
        }
        init { this._rawData.Set("access_token", value); }
    }

    /// <summary>
    /// WhatsApp Business Account ID from Meta Business Manager
    /// </summary>
    public required string WabaID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("waba_id");
        }
        init { this._rawData.Set("waba_id", value); }
    }

    /// <summary>
    /// Phone Number ID of an existing number already registered under this WABA
    /// in Meta Business Manager. Optional — when omitted, a number will be provisioned
    /// from our pool and registered in the WABA during the onboarding flow. When
    /// provided, the number must already exist in the WABA.
    /// </summary>
    public string? PhoneNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number_id");
        }
        init { this._rawData.Set("phone_number_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessToken;
        _ = this.WabaID;
        _ = this.PhoneNumberID;
    }

    public WhatsappBusinessAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappBusinessAccount(WhatsappBusinessAccount whatsappBusinessAccount)
        : base(whatsappBusinessAccount) { }
#pragma warning restore CS8618

    public WhatsappBusinessAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappBusinessAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappBusinessAccountFromRaw.FromRawUnchecked"/>
    public static WhatsappBusinessAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WhatsappBusinessAccountFromRaw : IFromRawJson<WhatsappBusinessAccount>
{
    /// <inheritdoc/>
    public WhatsappBusinessAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WhatsappBusinessAccount.FromRawUnchecked(rawData);
}
