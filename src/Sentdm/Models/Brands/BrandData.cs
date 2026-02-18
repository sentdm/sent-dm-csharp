using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;

namespace Sentdm.Models.Brands;

/// <summary>
/// Brand and KYC data
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrandData, BrandDataFromRaw>))]
public sealed record class BrandData : JsonModel
{
    /// <summary>
    /// Brand relationship level with TCR (required for TCR)
    /// </summary>
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

    /// <summary>
    /// Primary contact name (required)
    /// </summary>
    public required string ContactName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("contactName");
        }
        init { this._rawData.Set("contactName", value); }
    }

    /// <summary>
    /// Business vertical/industry category (required for TCR)
    /// </summary>
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
    /// Brand name for KYC submission
    /// </summary>
    public string? BrandName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("brandName");
        }
        init { this._rawData.Set("brandName", value); }
    }

    /// <summary>
    /// Legal business name
    /// </summary>
    public string? BusinessLegalName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("businessLegalName");
        }
        init { this._rawData.Set("businessLegalName", value); }
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
    /// Contact's role in the business
    /// </summary>
    public string? BusinessRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("businessRole");
        }
        init { this._rawData.Set("businessRole", value); }
    }

    /// <summary>
    /// Business website URL
    /// </summary>
    public string? BusinessUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("businessUrl");
        }
        init { this._rawData.Set("businessUrl", value); }
    }

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
    /// Contact email address
    /// </summary>
    public string? ContactEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contactEmail");
        }
        init { this._rawData.Set("contactEmail", value); }
    }

    /// <summary>
    /// Contact phone number in E.164 format
    /// </summary>
    public string? ContactPhone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contactPhone");
        }
        init { this._rawData.Set("contactPhone", value); }
    }

    /// <summary>
    /// Contact phone country code (e.g., "1" for US)
    /// </summary>
    public string? ContactPhoneCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contactPhoneCountryCode");
        }
        init { this._rawData.Set("contactPhoneCountryCode", value); }
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
    /// Business entity type
    /// </summary>
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BrandRelationship.Validate();
        _ = this.ContactName;
        this.Vertical.Validate();
        _ = this.BrandName;
        _ = this.BusinessLegalName;
        _ = this.BusinessName;
        _ = this.BusinessRole;
        _ = this.BusinessUrl;
        _ = this.City;
        _ = this.ContactEmail;
        _ = this.ContactPhone;
        _ = this.ContactPhoneCountryCode;
        _ = this.Country;
        _ = this.CountryOfRegistration;
        foreach (var item in this.DestinationCountries ?? [])
        {
            item.Validate();
        }
        this.EntityType?.Validate();
        _ = this.ExpectedMessagingVolume;
        _ = this.IsTcrApplication;
        _ = this.Notes;
        _ = this.PhoneNumberPrefix;
        _ = this.PostalCode;
        _ = this.PrimaryUseCase;
        _ = this.State;
        _ = this.Street;
        _ = this.TaxID;
        _ = this.TaxIDType;
    }

    public BrandData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandData(BrandData brandData)
        : base(brandData) { }
#pragma warning restore CS8618

    public BrandData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandDataFromRaw.FromRawUnchecked"/>
    public static BrandData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandDataFromRaw : IFromRawJson<BrandData>
{
    /// <inheritdoc/>
    public BrandData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandData.FromRawUnchecked(rawData);
}

/// <summary>
/// Business entity type
/// </summary>
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
