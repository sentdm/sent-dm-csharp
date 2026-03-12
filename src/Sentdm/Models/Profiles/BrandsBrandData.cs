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
/// Brand and KYC data grouped into contact, business, and compliance sections
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrandsBrandData, BrandsBrandDataFromRaw>))]
public sealed record class BrandsBrandData : JsonModel
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

    public BrandsBrandData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandsBrandData(BrandsBrandData brandsBrandData)
        : base(brandsBrandData) { }
#pragma warning restore CS8618

    public BrandsBrandData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandsBrandData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandsBrandDataFromRaw.FromRawUnchecked"/>
    public static BrandsBrandData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandsBrandDataFromRaw : IFromRawJson<BrandsBrandData>
{
    /// <inheritdoc/>
    public BrandsBrandData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandsBrandData.FromRawUnchecked(rawData);
}

/// <summary>
/// Compliance and TCR information for brand registration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Compliance, ComplianceFromRaw>))]
public sealed record class Compliance : JsonModel
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
                _ => throw new SentDmInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
