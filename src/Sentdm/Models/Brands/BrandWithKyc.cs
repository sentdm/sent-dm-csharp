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
/// Flattened brand response with embedded KYC information
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
    /// Brand relationship level with TCR
    /// </summary>
    public ApiEnum<string, TcrBrandRelationship>? BrandRelationship
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TcrBrandRelationship>>(
                "brandRelationship"
            );
        }
        init { this._rawData.Set("brandRelationship", value); }
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
    /// Primary contact name
    /// </summary>
    public string? ContactName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contactName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contactName", value);
        }
    }

    /// <summary>
    /// Contact phone number
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
    /// Contact phone country code
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
    /// Country code
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
    /// When the brand was created
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
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
            return this._rawData.GetNullableClass<string>("cspId");
        }
        init { this._rawData.Set("cspId", value); }
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
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DestinationCountry>?>(
                "destinationCountries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Business entity type
    /// </summary>
    public string? EntityType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("entityType");
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
    /// TCR brand identity verification status
    /// </summary>
    public ApiEnum<string, IdentityStatus>? IdentityStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, IdentityStatus>>(
                "identityStatus"
            );
        }
        init { this._rawData.Set("identityStatus", value); }
    }

    /// <summary>
    /// Whether this brand is inherited from parent organization
    /// </summary>
    public bool? IsInherited
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isInherited");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isInherited", value);
        }
    }

    /// <summary>
    /// Whether this is a TCR application
    /// </summary>
    public bool? IsTcrApplication
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isTcrApplication");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isTcrApplication", value);
        }
    }

    /// <summary>
    /// Additional notes
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
    /// Phone number prefix for messaging
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
    /// When the brand was submitted to TCR
    /// </summary>
    public DateTimeOffset? SubmittedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("submittedAt");
        }
        init { this._rawData.Set("submittedAt", value); }
    }

    /// <summary>
    /// Whether this brand was submitted to TCR
    /// </summary>
    public bool? SubmittedToTcr
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("submittedToTCR");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("submittedToTCR", value);
        }
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
    /// Type of tax ID
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
    /// TCR brand ID (populated after TCR submission)
    /// </summary>
    public string? TcrBrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tcrBrandId");
        }
        init { this._rawData.Set("tcrBrandId", value); }
    }

    /// <summary>
    /// Universal EIN from TCR
    /// </summary>
    public string? UniversalEin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("universalEin");
        }
        init { this._rawData.Set("universalEin", value); }
    }

    /// <summary>
    /// When the brand was last updated
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
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
        _ = this.ID;
        this.BrandRelationship?.Validate();
        _ = this.BusinessLegalName;
        _ = this.BusinessName;
        _ = this.BusinessRole;
        _ = this.BusinessUrl;
        _ = this.City;
        _ = this.ContactEmail;
        _ = this.ContactName;
        _ = this.ContactPhone;
        _ = this.ContactPhoneCountryCode;
        _ = this.Country;
        _ = this.CountryOfRegistration;
        _ = this.CreatedAt;
        _ = this.CspID;
        foreach (var item in this.DestinationCountries ?? [])
        {
            item.Validate();
        }
        _ = this.EntityType;
        _ = this.ExpectedMessagingVolume;
        this.IdentityStatus?.Validate();
        _ = this.IsInherited;
        _ = this.IsTcrApplication;
        _ = this.Notes;
        _ = this.PhoneNumberPrefix;
        _ = this.PostalCode;
        _ = this.PrimaryUseCase;
        _ = this.State;
        this.Status?.Validate();
        _ = this.Street;
        _ = this.SubmittedAt;
        _ = this.SubmittedToTcr;
        _ = this.TaxID;
        _ = this.TaxIDType;
        _ = this.TcrBrandID;
        _ = this.UniversalEin;
        _ = this.UpdatedAt;
        this.Vertical?.Validate();
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
