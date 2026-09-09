using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Profiles.Campaigns;

/// <summary>
/// Campaign use case with sample messages
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CampaignUseCaseData, CampaignUseCaseDataFromRaw>))]
public sealed record class CampaignUseCaseData : JsonModel
{
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

    public CampaignUseCaseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignUseCaseData(CampaignUseCaseData campaignUseCaseData)
        : base(campaignUseCaseData) { }
#pragma warning restore CS8618

    public CampaignUseCaseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignUseCaseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignUseCaseDataFromRaw.FromRawUnchecked"/>
    public static CampaignUseCaseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignUseCaseDataFromRaw : IFromRawJson<CampaignUseCaseData>
{
    /// <inheritdoc/>
    public CampaignUseCaseData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CampaignUseCaseData.FromRawUnchecked(rawData);
}
