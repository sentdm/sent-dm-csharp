using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Brands.Campaigns;

/// <summary>
/// Campaign use case with sample messages
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData,
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseDataFromRaw
    >)
)]
public sealed record class SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData
    : JsonModel
{
    /// <summary>
    /// US messaging use case category
    /// </summary>
    public required ApiEnum<string, MessagingUseCaseUs> MessagingUseCaseUs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MessagingUseCaseUs>>(
                "messagingUseCaseUs"
            );
        }
        init { this._rawData.Set("messagingUseCaseUs", value); }
    }

    /// <summary>
    /// Sample messages for this use case (1-5 messages, max 1024 characters each)
    /// </summary>
    public required IReadOnlyList<string> SampleMessages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("sampleMessages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "sampleMessages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MessagingUseCaseUs.Validate();
        _ = this.SampleMessages;
    }

    public SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData(
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData sentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData
    )
        : base(sentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData)
    { }
#pragma warning restore CS8618

    public SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseDataFromRaw.FromRawUnchecked"/>
    public static SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseDataFromRaw
    : IFromRawJson<SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData>
{
    /// <inheritdoc/>
    public SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData.FromRawUnchecked(
            rawData
        );
}
