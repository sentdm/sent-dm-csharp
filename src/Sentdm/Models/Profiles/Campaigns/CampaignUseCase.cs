using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Profiles.Campaigns;

/// <summary>
/// Customer-facing use-case representation for the public v3 campaign contract. Exists
/// for the same reason as BrandCampaignV3Response: nesting the TcrCampaignUseCase
/// database entity in a public response means any column added to that table silently
/// becomes part of the customer-facing contract. This DTO is an explicit allowlist,
/// so a new column stays invisible until it is added here on purpose. This mirrors
/// exactly the fields the entity already serialized, so it removes nothing from
/// the current response shape. It only closes the future-leak path.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CampaignUseCase, CampaignUseCaseFromRaw>))]
public sealed record class CampaignUseCase : JsonModel
{
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

    public string? CampaignID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("campaignId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("campaignId", value);
        }
    }

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

    public string? CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customerId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("customerId", value);
        }
    }

    public ApiEnum<string, MessagingUseCaseUs>? MessagingUseCaseUs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingUseCaseUs>>(
                "messagingUseCaseUs"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("messagingUseCaseUs", value);
        }
    }

    /// <summary>
    /// Sample messages submitted to the registry for this use case.
    /// </summary>
    public IReadOnlyList<string>? SampleMessages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("sampleMessages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "sampleMessages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CampaignID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        this.MessagingUseCaseUs?.Validate();
        _ = this.SampleMessages;
        _ = this.UpdatedAt;
    }

    public CampaignUseCase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignUseCase(CampaignUseCase campaignUseCase)
        : base(campaignUseCase) { }
#pragma warning restore CS8618

    public CampaignUseCase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignUseCase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignUseCaseFromRaw.FromRawUnchecked"/>
    public static CampaignUseCase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignUseCaseFromRaw : IFromRawJson<CampaignUseCase>
{
    /// <inheritdoc/>
    public CampaignUseCase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CampaignUseCase.FromRawUnchecked(rawData);
}
