using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Channels.Sms;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ApiResponseOfSmsMarket, ApiResponseOfSmsMarketFromRaw>))]
public sealed record class ApiResponseOfSmsMarket : JsonModel
{
    /// <summary>
    /// One SMS market the profile sends in — its sender, where that sender stands,
    /// and what the market wants.              A profile may send in several: it
    /// is a tenant, not a market. Each carries its own status, because a profile
    /// can be live in one country and mid-registration in another — and each carries
    /// what it still owes, rather than that being reported in a separate array a
    /// caller has to join on.
    /// </summary>
    public SmsMarket? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SmsMarket>("data");
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

    public ApiResponseOfSmsMarket() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfSmsMarket(ApiResponseOfSmsMarket apiResponseOfSmsMarket)
        : base(apiResponseOfSmsMarket) { }
#pragma warning restore CS8618

    public ApiResponseOfSmsMarket(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfSmsMarket(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfSmsMarketFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfSmsMarket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfSmsMarketFromRaw : IFromRawJson<ApiResponseOfSmsMarket>
{
    /// <inheritdoc/>
    public ApiResponseOfSmsMarket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfSmsMarket.FromRawUnchecked(rawData);
}
