using System.Collections.Frozen;
using System.Collections.Generic;
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
    typeof(JsonModelConverter<ApiResponseOfBrandCampaign, ApiResponseOfBrandCampaignFromRaw>)
)]
public sealed record class ApiResponseOfBrandCampaign : JsonModel
{
    /// <summary>
    /// A 10DLC campaign registered for a brand.
    /// </summary>
    public BrandCampaign? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrandCampaign>("data");
        }
        init { this._rawData.Set("data", value); }
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
        this.Data?.Validate();
        this.Error?.Validate();
        this.Meta?.Validate();
        _ = this.Success;
    }

    public ApiResponseOfBrandCampaign() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfBrandCampaign(ApiResponseOfBrandCampaign apiResponseOfBrandCampaign)
        : base(apiResponseOfBrandCampaign) { }
#pragma warning restore CS8618

    public ApiResponseOfBrandCampaign(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfBrandCampaign(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfBrandCampaignFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfBrandCampaign FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfBrandCampaignFromRaw : IFromRawJson<ApiResponseOfBrandCampaign>
{
    /// <inheritdoc/>
    public ApiResponseOfBrandCampaign FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfBrandCampaign.FromRawUnchecked(rawData);
}
