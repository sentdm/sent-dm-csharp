using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Rcs;

/// <summary>
/// The registered address of the company behind the agent.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RcsAddress, RcsAddressFromRaw>))]
public sealed record class RcsAddress : JsonModel
{
    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    public string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    public string? Street
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("street");
        }
        init { this._rawData.Set("street", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.Street;
    }

    public RcsAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcsAddress(RcsAddress rcsAddress)
        : base(rcsAddress) { }
#pragma warning restore CS8618

    public RcsAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RcsAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RcsAddressFromRaw.FromRawUnchecked"/>
    public static RcsAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RcsAddressFromRaw : IFromRawJson<RcsAddress>
{
    /// <inheritdoc/>
    public RcsAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RcsAddress.FromRawUnchecked(rawData);
}
