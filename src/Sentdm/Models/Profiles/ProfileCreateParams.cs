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
    /// Billing contact information for a profile. Required when billing_model is
    /// "profile" or "profile_and_organization".
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
    /// Brand and KYC data grouped into contact, business, and compliance sections
    /// </summary>
    public Brand? Brand
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Brand>("brand");
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
    /// Payment card details for a profile. Accepted when billing_model is "profile"
    /// or "profile_and_organization". These details are not stored on our servers
    /// and will be forwarded to the payment processor.
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
    /// Direct WhatsApp Business Account credentials for a profile. Use this when
    /// the profile should have its own WhatsApp Business Account instead of inheriting
    /// from the organization. Credentials must be obtained from Meta Business Manager
    /// by creating a System User with whatsapp_business_messaging and whatsapp_business_management scopes.
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

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
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
/// Billing contact information for a profile. Required when billing_model is "profile"
/// or "profile_and_organization".
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
/// Brand and KYC data grouped into contact, business, and compliance sections
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Brand, BrandFromRaw>))]
public sealed record class Brand : JsonModel
{
    /// <summary>
    /// Compliance and TCR information for brand registration
    /// </summary>
    public required Compliance Compliance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Compliance>("compliance");
        }
        init { this._rawData.Set("compliance", value); }
    }

    /// <summary>
    /// Contact information for brand KYC
    /// </summary>
    public required Contact Contact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Contact>("contact");
        }
        init { this._rawData.Set("contact", value); }
    }

    /// <summary>
    /// Business details and address for brand KYC
    /// </summary>
    public Business? Business
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Business>("business");
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

    public Brand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Brand(Brand brand)
        : base(brand) { }
#pragma warning restore CS8618

    public Brand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Brand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandFromRaw.FromRawUnchecked"/>
    public static Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandFromRaw : IFromRawJson<Brand>
{
    /// <inheritdoc/>
    public Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Brand.FromRawUnchecked(rawData);
}

/// <summary>
/// Compliance and TCR information for brand registration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Compliance, ComplianceFromRaw>))]
public sealed record class Compliance : JsonModel
{
    public required ApiEnum<string, BrandRelationship> BrandRelationship
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BrandRelationship>>(
                "brandRelationship"
            );
        }
        init { this._rawData.Set("brandRelationship", value); }
    }

    public required ApiEnum<string, Vertical> Vertical
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Vertical>>("vertical");
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
    /// Expected daily messaging volume
    /// </summary>
    public string? ExpectedMessagingVolume
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expectedMessagingVolume");
        }
        init { this._rawData.Set("expectedMessagingVolume", value); }
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

    /// <summary>
    /// Primary messaging use case description
    /// </summary>
    public string? PrimaryUseCase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primaryUseCase");
        }
        init { this._rawData.Set("primaryUseCase", value); }
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
        _ = this.ExpectedMessagingVolume;
        _ = this.IsTcrApplication;
        _ = this.Notes;
        _ = this.PhoneNumberPrefix;
        _ = this.PrimaryUseCase;
    }

    public Compliance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Compliance(Compliance compliance)
        : base(compliance) { }
#pragma warning restore CS8618

    public Compliance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Compliance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComplianceFromRaw.FromRawUnchecked"/>
    public static Compliance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComplianceFromRaw : IFromRawJson<Compliance>
{
    /// <inheritdoc/>
    public Compliance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Compliance.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BrandRelationshipConverter))]
public enum BrandRelationship
{
    BasicAccount,
    MediumAccount,
    LargeAccount,
    SmallAccount,
    KeyAccount,
}

sealed class BrandRelationshipConverter : JsonConverter<BrandRelationship>
{
    public override BrandRelationship Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BASIC_ACCOUNT" => BrandRelationship.BasicAccount,
            "MEDIUM_ACCOUNT" => BrandRelationship.MediumAccount,
            "LARGE_ACCOUNT" => BrandRelationship.LargeAccount,
            "SMALL_ACCOUNT" => BrandRelationship.SmallAccount,
            "KEY_ACCOUNT" => BrandRelationship.KeyAccount,
            _ => (BrandRelationship)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BrandRelationship value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BrandRelationship.BasicAccount => "BASIC_ACCOUNT",
                BrandRelationship.MediumAccount => "MEDIUM_ACCOUNT",
                BrandRelationship.LargeAccount => "LARGE_ACCOUNT",
                BrandRelationship.SmallAccount => "SMALL_ACCOUNT",
                BrandRelationship.KeyAccount => "KEY_ACCOUNT",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(VerticalConverter))]
public enum Vertical
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

sealed class VerticalConverter : JsonConverter<Vertical>
{
    public override Vertical Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PROFESSIONAL" => Vertical.Professional,
            "REAL_ESTATE" => Vertical.RealEstate,
            "HEALTHCARE" => Vertical.Healthcare,
            "HUMAN_RESOURCES" => Vertical.HumanResources,
            "ENERGY" => Vertical.Energy,
            "ENTERTAINMENT" => Vertical.Entertainment,
            "RETAIL" => Vertical.Retail,
            "TRANSPORTATION" => Vertical.Transportation,
            "AGRICULTURE" => Vertical.Agriculture,
            "INSURANCE" => Vertical.Insurance,
            "POSTAL" => Vertical.Postal,
            "EDUCATION" => Vertical.Education,
            "HOSPITALITY" => Vertical.Hospitality,
            "FINANCIAL" => Vertical.Financial,
            "POLITICAL" => Vertical.Political,
            "GAMBLING" => Vertical.Gambling,
            "LEGAL" => Vertical.Legal,
            "CONSTRUCTION" => Vertical.Construction,
            "NGO" => Vertical.Ngo,
            "MANUFACTURING" => Vertical.Manufacturing,
            "GOVERNMENT" => Vertical.Government,
            "TECHNOLOGY" => Vertical.Technology,
            "COMMUNICATION" => Vertical.Communication,
            _ => (Vertical)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Vertical value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Vertical.Professional => "PROFESSIONAL",
                Vertical.RealEstate => "REAL_ESTATE",
                Vertical.Healthcare => "HEALTHCARE",
                Vertical.HumanResources => "HUMAN_RESOURCES",
                Vertical.Energy => "ENERGY",
                Vertical.Entertainment => "ENTERTAINMENT",
                Vertical.Retail => "RETAIL",
                Vertical.Transportation => "TRANSPORTATION",
                Vertical.Agriculture => "AGRICULTURE",
                Vertical.Insurance => "INSURANCE",
                Vertical.Postal => "POSTAL",
                Vertical.Education => "EDUCATION",
                Vertical.Hospitality => "HOSPITALITY",
                Vertical.Financial => "FINANCIAL",
                Vertical.Political => "POLITICAL",
                Vertical.Gambling => "GAMBLING",
                Vertical.Legal => "LEGAL",
                Vertical.Construction => "CONSTRUCTION",
                Vertical.Ngo => "NGO",
                Vertical.Manufacturing => "MANUFACTURING",
                Vertical.Government => "GOVERNMENT",
                Vertical.Technology => "TECHNOLOGY",
                Vertical.Communication => "COMMUNICATION",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<DestinationCountry, DestinationCountryFromRaw>))]
public sealed record class DestinationCountry : JsonModel
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

    public DestinationCountry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DestinationCountry(DestinationCountry destinationCountry)
        : base(destinationCountry) { }
#pragma warning restore CS8618

    public DestinationCountry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DestinationCountry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationCountryFromRaw.FromRawUnchecked"/>
    public static DestinationCountry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DestinationCountryFromRaw : IFromRawJson<DestinationCountry>
{
    /// <inheritdoc/>
    public DestinationCountry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DestinationCountry.FromRawUnchecked(rawData);
}

/// <summary>
/// Contact information for brand KYC
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Contact, ContactFromRaw>))]
public sealed record class Contact : JsonModel
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

    public Contact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Contact(Contact contact)
        : base(contact) { }
#pragma warning restore CS8618

    public Contact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Contact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactFromRaw.FromRawUnchecked"/>
    public static Contact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Contact(string name)
        : this()
    {
        this.Name = name;
    }
}

class ContactFromRaw : IFromRawJson<Contact>
{
    /// <inheritdoc/>
    public Contact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Contact.FromRawUnchecked(rawData);
}

/// <summary>
/// Business details and address for brand KYC
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Business, BusinessFromRaw>))]
public sealed record class Business : JsonModel
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

    public ApiEnum<string, EntityType>? EntityType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EntityType>>("entityType");
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

    public Business() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Business(Business business)
        : base(business) { }
#pragma warning restore CS8618

    public Business(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Business(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BusinessFromRaw.FromRawUnchecked"/>
    public static Business FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BusinessFromRaw : IFromRawJson<Business>
{
    /// <inheritdoc/>
    public Business FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Business.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EntityTypeConverter))]
public enum EntityType
{
    PrivateProfit,
    PublicProfit,
    NonProfit,
    SoleProprietor,
    Government,
}

sealed class EntityTypeConverter : JsonConverter<EntityType>
{
    public override EntityType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PRIVATE_PROFIT" => EntityType.PrivateProfit,
            "PUBLIC_PROFIT" => EntityType.PublicProfit,
            "NON_PROFIT" => EntityType.NonProfit,
            "SOLE_PROPRIETOR" => EntityType.SoleProprietor,
            "GOVERNMENT" => EntityType.Government,
            _ => (EntityType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityType.PrivateProfit => "PRIVATE_PROFIT",
                EntityType.PublicProfit => "PUBLIC_PROFIT",
                EntityType.NonProfit => "NON_PROFIT",
                EntityType.SoleProprietor => "SOLE_PROPRIETOR",
                EntityType.Government => "GOVERNMENT",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Payment card details for a profile. Accepted when billing_model is "profile" or
/// "profile_and_organization". These details are not stored on our servers and will
/// be forwarded to the payment processor.
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
/// Direct WhatsApp Business Account credentials for a profile. Use this when the
/// profile should have its own WhatsApp Business Account instead of inheriting from
/// the organization. Credentials must be obtained from Meta Business Manager by creating
/// a System User with whatsapp_business_messaging and whatsapp_business_management scopes.
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
