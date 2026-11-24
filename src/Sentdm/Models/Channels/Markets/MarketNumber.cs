using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Markets;

/// <summary>
/// One number the customer holds, or is still owed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MarketNumber, MarketNumberFromRaw>))]
public sealed record class MarketNumber : JsonModel
{
    public string? AreaCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("area_code");
        }
        init { this._rawData.Set("area_code", value); }
    }

    /// <summary>
    /// The campaign the number belongs to (US TEN_DLC); null otherwise.
    /// </summary>
    public string? CampaignID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("campaign_id");
        }
        init { this._rawData.Set("campaign_id", value); }
    }

    /// <summary>
    /// The number, or the sender id; null until it is assigned.
    /// </summary>
    public string? SenderValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sender_value");
        }
        init { this._rawData.Set("sender_value", value); }
    }

    /// <summary>
    /// ACTIVE, PROVISIONING or INACTIVE.
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The market's sender type, e.g. TEN_DLC, LOCAL.
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AreaCode;
        _ = this.CampaignID;
        _ = this.SenderValue;
        _ = this.Status;
        _ = this.Type;
    }

    public MarketNumber() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MarketNumber(MarketNumber marketNumber)
        : base(marketNumber) { }
#pragma warning restore CS8618

    public MarketNumber(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MarketNumber(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MarketNumberFromRaw.FromRawUnchecked"/>
    public static MarketNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MarketNumberFromRaw : IFromRawJson<MarketNumber>
{
    /// <inheritdoc/>
    public MarketNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MarketNumber.FromRawUnchecked(rawData);
}
