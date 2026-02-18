using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;

namespace SentDm.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<DestinationCountry, DestinationCountryFromRaw>))]
public sealed record class DestinationCountry : JsonModel
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

    public bool? IsMain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isMain");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isMain", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.IsMain;
    }

    public DestinationCountry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DestinationCountry(DestinationCountry destinationCountry)
        : base(destinationCountry) { }
#pragma warning restore CS8618

    public DestinationCountry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DestinationCountry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationCountryFromRaw.FromRawUnchecked"/>
    public static DestinationCountry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DestinationCountryFromRaw : IFromRawJson<DestinationCountry>
{
    /// <inheritdoc/>
    public DestinationCountry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DestinationCountry.FromRawUnchecked(rawData);
}
