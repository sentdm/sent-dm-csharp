using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Profiles.Campaigns;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ApiResponseOfListOfBrandCampaign,
        ApiResponseOfListOfBrandCampaignFromRaw
    >)
)]
public sealed record class ApiResponseOfListOfBrandCampaign : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public IReadOnlyList<BrandCampaign>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BrandCampaign>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BrandCampaign>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public ErrorDetail? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ErrorDetail>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
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

    public ApiResponseOfListOfBrandCampaign() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfListOfBrandCampaign(
        ApiResponseOfListOfBrandCampaign apiResponseOfListOfBrandCampaign
    )
        : base(apiResponseOfListOfBrandCampaign) { }
#pragma warning restore CS8618

    public ApiResponseOfListOfBrandCampaign(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfListOfBrandCampaign(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfListOfBrandCampaignFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfListOfBrandCampaign FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfListOfBrandCampaignFromRaw : IFromRawJson<ApiResponseOfListOfBrandCampaign>
{
    /// <inheritdoc/>
    public ApiResponseOfListOfBrandCampaign FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfListOfBrandCampaign.FromRawUnchecked(rawData);
}
