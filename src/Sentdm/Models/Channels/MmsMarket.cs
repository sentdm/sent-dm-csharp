using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Channels;

/// <summary>
/// One market the profile can send MMS in.              Deliberately not SmsMarketState:
/// an MMS market carries no compliance of its own. It is the same number, carrier
/// and registration as the SMS market on it in that country — MMS files nothing separately
/// — so a compliance block here would always be null and would invite the question
/// of what an MMS market owes. It owes what the SMS market owes, reported there.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MmsMarket, MmsMarketFromRaw>))]
public sealed record class MmsMarket : JsonModel
{
    /// <summary>
    /// ISO-3166 alpha-2 of the market.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// The sender type the market sends from, mirroring the SMS sender.
    /// </summary>
    public string? NumberType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("number_type");
        }
        init { this._rawData.Set("number_type", value); }
    }

    /// <summary>
    /// The sending number. Null while the market is still being provisioned.
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
    /// Where this market's MMS sender stands. Read-only.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.NumberType;
        _ = this.SenderValue;
        _ = this.Status;
    }

    public MmsMarket() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MmsMarket(MmsMarket mmsMarket)
        : base(mmsMarket) { }
#pragma warning restore CS8618

    public MmsMarket(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MmsMarket(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MmsMarketFromRaw.FromRawUnchecked"/>
    public static MmsMarket FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MmsMarketFromRaw : IFromRawJson<MmsMarket>
{
    /// <inheritdoc/>
    public MmsMarket FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MmsMarket.FromRawUnchecked(rawData);
}
