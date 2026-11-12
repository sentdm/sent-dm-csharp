using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Profiles;

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
    public BrandBusiness? Business
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrandBusiness>("business");
        }
        init { this._rawData.Set("business", value); }
    }

    /// <summary>
    /// Compliance and TCR-related information
    /// </summary>
    public BrandCompliance? Compliance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrandCompliance>("compliance");
        }
        init { this._rawData.Set("compliance", value); }
    }

    /// <summary>
    /// Contact information for the brand
    /// </summary>
    public BrandContact? Contact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrandContact>("contact");
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
    /// Deprecated and scheduled for removal. Identifies the Campaign Service Provider
    /// that registered the brand, which is Sent, so the value is the same for every
    /// brand and every account. Nothing on your side can act on it and there is
    /// no replacement. Stop reading it.
    /// </summary>
    [Obsolete("deprecated")]
    public string? CspID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("csp_id");
        }
        init { this._rawData.Set("csp_id", value); }
    }

    public ApiEnum<string, TcrBrandIdentityStatus>? IdentityStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TcrBrandIdentityStatus>>(
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

    public ApiEnum<string, TcrBrandStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TcrBrandStatus>>("status");
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
