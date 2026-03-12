using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

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
    public required SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo Compliance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo>(
                "compliance"
            );
        }
        init { this._rawData.Set("compliance", value); }
    }

    /// <summary>
    /// Contact information for brand KYC
    /// </summary>
    public required SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo Contact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo>(
                "contact"
            );
        }
        init { this._rawData.Set("contact", value); }
    }

    /// <summary>
    /// Business details and address for brand KYC
    /// </summary>
    public SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo? Business
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo>(
                "business"
            );
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
