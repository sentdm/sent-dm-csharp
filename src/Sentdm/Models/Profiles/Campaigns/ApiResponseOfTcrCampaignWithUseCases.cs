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
    typeof(JsonModelConverter<
        ApiResponseOfTcrCampaignWithUseCases,
        ApiResponseOfTcrCampaignWithUseCasesFromRaw
    >)
)]
public sealed record class ApiResponseOfTcrCampaignWithUseCases : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public TcrCampaignWithUseCases? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TcrCampaignWithUseCases>("data");
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

    public ApiResponseOfTcrCampaignWithUseCases() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfTcrCampaignWithUseCases(
        ApiResponseOfTcrCampaignWithUseCases apiResponseOfTcrCampaignWithUseCases
    )
        : base(apiResponseOfTcrCampaignWithUseCases) { }
#pragma warning restore CS8618

    public ApiResponseOfTcrCampaignWithUseCases(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfTcrCampaignWithUseCases(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfTcrCampaignWithUseCasesFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfTcrCampaignWithUseCases FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfTcrCampaignWithUseCasesFromRaw
    : IFromRawJson<ApiResponseOfTcrCampaignWithUseCases>
{
    /// <inheritdoc/>
    public ApiResponseOfTcrCampaignWithUseCases FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfTcrCampaignWithUseCases.FromRawUnchecked(rawData);
}
