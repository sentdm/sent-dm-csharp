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
/// Brand response with nested contact, business, and compliance sections — mirrors
/// the request structure.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrandWithKyc, BrandWithKycFromRaw>))]
public sealed record class BrandWithKyc : JsonModel
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
    public BrandWithKycBusiness? Business
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrandWithKycBusiness>("business");
        }
        init { this._rawData.Set("business", value); }
    }

    /// <summary>
    /// Compliance and TCR-related information
    /// </summary>
    public BrandWithKycCompliance? Compliance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrandWithKycCompliance>("compliance");
        }
        init { this._rawData.Set("compliance", value); }
    }

    /// <summary>
    /// Contact information for the brand
    /// </summary>
    public BrandWithKycContact? Contact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrandWithKycContact>("contact");
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

    /// <summary>
    /// TCR brand identity verification status
    /// </summary>
    public ApiEnum<string, IdentityStatus>? IdentityStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, IdentityStatus>>(
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

    /// <summary>
    /// TCR brand status
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
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

    public BrandWithKyc() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandWithKyc(BrandWithKyc brandWithKyc)
        : base(brandWithKyc) { }
#pragma warning restore CS8618

    public BrandWithKyc(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandWithKyc(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandWithKycFromRaw.FromRawUnchecked"/>
    public static BrandWithKyc FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandWithKycFromRaw : IFromRawJson<BrandWithKyc>
{
    /// <inheritdoc/>
    public BrandWithKyc FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandWithKyc.FromRawUnchecked(rawData);
}

/// <summary>
/// Business details and address information
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrandWithKycBusiness, BrandWithKycBusinessFromRaw>))]
public sealed record class BrandWithKycBusiness : JsonModel
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

    public BrandWithKycBusiness() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandWithKycBusiness(BrandWithKycBusiness brandWithKycBusiness)
        : base(brandWithKycBusiness) { }
#pragma warning restore CS8618

    public BrandWithKycBusiness(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandWithKycBusiness(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandWithKycBusinessFromRaw.FromRawUnchecked"/>
    public static BrandWithKycBusiness FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandWithKycBusinessFromRaw : IFromRawJson<BrandWithKycBusiness>
{
    /// <inheritdoc/>
    public BrandWithKycBusiness FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrandWithKycBusiness.FromRawUnchecked(rawData);
}

/// <summary>
/// Compliance and TCR-related information
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrandWithKycCompliance, BrandWithKycComplianceFromRaw>))]
public sealed record class BrandWithKycCompliance : JsonModel
{
    /// <summary>
    /// Brand relationship level with TCR
    /// </summary>
    public ApiEnum<string, TcrBrandRelationship>? BrandRelationship
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TcrBrandRelationship>>(
                "brand_relationship"
            );
        }
        init { this._rawData.Set("brand_relationship", value); }
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
                "destination_countries"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DestinationCountry>?>(
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

    /// <summary>
    /// Business vertical/industry category
    /// </summary>
    public ApiEnum<string, TcrVertical>? Vertical
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TcrVertical>>("vertical");
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

    public BrandWithKycCompliance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandWithKycCompliance(BrandWithKycCompliance brandWithKycCompliance)
        : base(brandWithKycCompliance) { }
#pragma warning restore CS8618

    public BrandWithKycCompliance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandWithKycCompliance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandWithKycComplianceFromRaw.FromRawUnchecked"/>
    public static BrandWithKycCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandWithKycComplianceFromRaw : IFromRawJson<BrandWithKycCompliance>
{
    /// <inheritdoc/>
    public BrandWithKycCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrandWithKycCompliance.FromRawUnchecked(rawData);
}

/// <summary>
/// Contact information for the brand
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrandWithKycContact, BrandWithKycContactFromRaw>))]
public sealed record class BrandWithKycContact : JsonModel
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

    public BrandWithKycContact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandWithKycContact(BrandWithKycContact brandWithKycContact)
        : base(brandWithKycContact) { }
#pragma warning restore CS8618

    public BrandWithKycContact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandWithKycContact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandWithKycContactFromRaw.FromRawUnchecked"/>
    public static BrandWithKycContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandWithKycContactFromRaw : IFromRawJson<BrandWithKycContact>
{
    /// <inheritdoc/>
    public BrandWithKycContact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandWithKycContact.FromRawUnchecked(rawData);
}

/// <summary>
/// TCR brand identity verification status
/// </summary>
[JsonConverter(typeof(IdentityStatusConverter))]
public enum IdentityStatus
{
    SelfDeclared,
    Unverified,
    Verified,
    VettedVerified,
}

sealed class IdentityStatusConverter : JsonConverter<IdentityStatus>
{
    public override IdentityStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SELF_DECLARED" => IdentityStatus.SelfDeclared,
            "UNVERIFIED" => IdentityStatus.Unverified,
            "VERIFIED" => IdentityStatus.Verified,
            "VETTED_VERIFIED" => IdentityStatus.VettedVerified,
            _ => (IdentityStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IdentityStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IdentityStatus.SelfDeclared => "SELF_DECLARED",
                IdentityStatus.Unverified => "UNVERIFIED",
                IdentityStatus.Verified => "VERIFIED",
                IdentityStatus.VettedVerified => "VETTED_VERIFIED",
                _ => throw new SentDmInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// TCR brand status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active,
    Inactive,
    Suspended,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACTIVE" => Status.Active,
            "INACTIVE" => Status.Inactive,
            "SUSPENDED" => Status.Suspended,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "ACTIVE",
                Status.Inactive => "INACTIVE",
                Status.Suspended => "SUSPENDED",
                _ => throw new SentDmInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
