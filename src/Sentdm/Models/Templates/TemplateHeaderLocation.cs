using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

/// <summary>
/// The map pin a location header drops. Meta wants none of this at creation — the
/// component is just {"type":"header","format":"location"} — so these values exist
/// for Sent: a preview, and the default a StaticResource header falls back to at send.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TemplateHeaderLocation, TemplateHeaderLocationFromRaw>))]
public sealed record class TemplateHeaderLocation : JsonModel
{
    public required string Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    public required string Latitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("latitude");
        }
        init { this._rawData.Set("latitude", value); }
    }

    public required string Longitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("longitude");
        }
        init { this._rawData.Set("longitude", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Address;
        _ = this.Latitude;
        _ = this.Longitude;
        _ = this.Name;
    }

    public TemplateHeaderLocation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateHeaderLocation(TemplateHeaderLocation templateHeaderLocation)
        : base(templateHeaderLocation) { }
#pragma warning restore CS8618

    public TemplateHeaderLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateHeaderLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateHeaderLocationFromRaw.FromRawUnchecked"/>
    public static TemplateHeaderLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateHeaderLocationFromRaw : IFromRawJson<TemplateHeaderLocation>
{
    /// <inheritdoc/>
    public TemplateHeaderLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateHeaderLocation.FromRawUnchecked(rawData);
}
