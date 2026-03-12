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
[JsonConverter(
    typeof(JsonModelConverter<
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo,
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfoFromRaw
    >)
)]
public sealed record class SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo
    : JsonModel
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

    public SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo(
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo sentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo
    )
        : base(sentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo) { }
#pragma warning restore CS8618

    public SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfoFromRaw.FromRawUnchecked"/>
    public static SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo(string name)
        : this()
    {
        this.Name = name;
    }
}

class SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfoFromRaw
    : IFromRawJson<SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo>
{
    /// <inheritdoc/>
    public SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo.FromRawUnchecked(
            rawData
        );
}
