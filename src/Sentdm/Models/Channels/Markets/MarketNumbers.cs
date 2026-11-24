using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Markets;

/// <summary>
/// The numbers a customer holds in one market: GET /v3/channels/{channel}/{country}/{type}/numbers.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MarketNumbers, MarketNumbersFromRaw>))]
public sealed record class MarketNumbers : JsonModel
{
    public string? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channel", value);
        }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2, uppercase.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country", value);
        }
    }

    /// <summary>
    /// Empty, never null, when the customer holds nothing there.
    /// </summary>
    public IReadOnlyList<MarketNumber>? Numbers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MarketNumber>>("numbers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<MarketNumber>?>(
                "numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channel;
        _ = this.Country;
        foreach (var item in this.Numbers ?? [])
        {
            item.Validate();
        }
    }

    public MarketNumbers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MarketNumbers(MarketNumbers marketNumbers)
        : base(marketNumbers) { }
#pragma warning restore CS8618

    public MarketNumbers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MarketNumbers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MarketNumbersFromRaw.FromRawUnchecked"/>
    public static MarketNumbers FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MarketNumbersFromRaw : IFromRawJson<MarketNumbers>
{
    /// <inheritdoc/>
    public MarketNumbers FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MarketNumbers.FromRawUnchecked(rawData);
}
