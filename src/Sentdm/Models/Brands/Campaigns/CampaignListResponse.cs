using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Brands.Campaigns;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CampaignListResponse, CampaignListResponseFromRaw>))]
public sealed record class CampaignListResponse : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public IReadOnlyList<TcrCampaignWithUseCases>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TcrCampaignWithUseCases>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TcrCampaignWithUseCases>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Error details (null if successful)
    /// </summary>
    public ApiError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Metadata about the request and response
    /// </summary>
    public ApiMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiMeta>("meta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Error?.Validate();
        this.Meta?.Validate();
        _ = this.Success;
    }

    public CampaignListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignListResponse(CampaignListResponse campaignListResponse)
        : base(campaignListResponse) { }
#pragma warning restore CS8618

    public CampaignListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignListResponseFromRaw.FromRawUnchecked"/>
    public static CampaignListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignListResponseFromRaw : IFromRawJson<CampaignListResponse>
{
    /// <inheritdoc/>
    public CampaignListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignListResponse.FromRawUnchecked(rawData);
}
