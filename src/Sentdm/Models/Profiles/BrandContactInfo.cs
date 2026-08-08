using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Profiles;

/// <summary>
/// Contact information for brand KYC
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrandContactInfo, BrandContactInfoFromRaw>))]
public sealed record class BrandContactInfo : JsonModel
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

    public BrandContactInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandContactInfo(BrandContactInfo brandContactInfo)
        : base(brandContactInfo) { }
#pragma warning restore CS8618

    public BrandContactInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandContactInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandContactInfoFromRaw.FromRawUnchecked"/>
    public static BrandContactInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrandContactInfo(string name)
        : this()
    {
        this.Name = name;
    }
}

class BrandContactInfoFromRaw : IFromRawJson<BrandContactInfo>
{
    /// <inheritdoc/>
    public BrandContactInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandContactInfo.FromRawUnchecked(rawData);
}
