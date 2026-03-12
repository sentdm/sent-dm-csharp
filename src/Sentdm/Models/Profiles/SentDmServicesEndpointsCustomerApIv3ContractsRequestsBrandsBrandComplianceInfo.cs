using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Profiles;

/// <summary>
/// Compliance and TCR information for brand registration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo,
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfoFromRaw
    >)
)]
public sealed record class SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo
    : JsonModel
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

    public SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo(
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo sentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo
    )
        : base(sentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo) { }
#pragma warning restore CS8618

    public SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfoFromRaw.FromRawUnchecked"/>
    public static SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfoFromRaw
    : IFromRawJson<SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo>
{
    /// <inheritdoc/>
    public SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo.FromRawUnchecked(
            rawData
        );
}
