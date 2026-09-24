using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

/// <summary>
/// Header section of a message template
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TemplateHeader, TemplateHeaderFromRaw>))]
public sealed record class TemplateHeader : JsonModel
{
    /// <summary>
    /// The header template text with optional variable placeholders (e.g., "Welcome
    /// to {{0:variable}}")
    /// </summary>
    public required string Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("template");
        }
        init { this._rawData.Set("template", value); }
    }

    /// <summary>
    /// Request-only. The s.dm URL of the asset Meta's reviewers see — https://s.dm/s/{ID},
    /// eight uppercase characters, uploaded to s.dm out of band. NormalizeRichHeader
    /// folds it into the synthesized media variable's Props.Sample and clears it,
    /// so it never persists and a stored definition is indistinguishable from an
    /// imported one.              Stricter than the send path on purpose: TemplateUtils.ValidateMediaVariableValues
    /// accepts any absolute https URL for the per-send asset, because that one is
    /// the customer's and may live behind a signed CDN link. This one is the review
    /// sample, has to outlive every resubmission, and so must be ours. Do not "fix"
    /// one to match the other.
    /// </summary>
    public string? ExampleUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("example_url");
        }
        init { this._rawData.Set("example_url", value); }
    }

    /// <summary>
    /// The map pin a location header drops. Meta wants none of this at creation
    /// — the component is just {"type":"header","format":"location"} — so these values
    /// exist for Sent: a preview, and the default a StaticResource header falls
    /// back to at send.
    /// </summary>
    public Location? Location
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Location>("location");
        }
        init { this._rawData.Set("location", value); }
    }

    /// <summary>
    /// Whether the asset registered at creation is reused when a caller omits the
    /// header's variable at send time. Default false — the caller must supply it
    /// per message, which is the behaviour every existing template has. Written only
    /// when true, so a default-valued header serializes byte-identically to one
    /// imported from Meta.              Stored and validated but not yet honoured
    /// at send: that lands with the Resumable Upload work, alongside the code that
    /// lets such a template be approved in the first place.
    /// </summary>
    public bool? StaticResource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("static_resource");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("static_resource", value);
        }
    }

    /// <summary>
    /// The kind of header. One of:              text — up to 60 characters, at most
    /// one variable. image — png, jpg or jpeg. Needs ExampleUrl. video — mp4. Needs
    /// ExampleUrl. gif — mp4, max 3.5MB. WhatsApp renders larger files as an ordinary
    /// video. Needs ExampleUrl. document — pdf or docx; only the first page is shown
    /// as a thumbnail, so pdf is the practical choice. Needs ExampleUrl. location
    /// — a map pin, supplied through Location.              Kept lowercase because
    /// MetaToTemplateConverter writes Meta's format through ToLowerInvariant() into
    /// this field on import, and the two are compared directly.
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// List of variables used in the header template
    /// </summary>
    public IReadOnlyList<TemplateVariable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TemplateVariable>>("variables");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TemplateVariable>?>(
                "variables",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Template;
        _ = this.ExampleUrl;
        this.Location?.Validate();
        _ = this.StaticResource;
        _ = this.Type;
        foreach (var item in this.Variables ?? [])
        {
            item.Validate();
        }
    }

    public TemplateHeader() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateHeader(TemplateHeader templateHeader)
        : base(templateHeader) { }
#pragma warning restore CS8618

    public TemplateHeader(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateHeader(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateHeaderFromRaw.FromRawUnchecked"/>
    public static TemplateHeader FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TemplateHeader(string template)
        : this()
    {
        this.Template = template;
    }
}

class TemplateHeaderFromRaw : IFromRawJson<TemplateHeader>
{
    /// <inheritdoc/>
    public TemplateHeader FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateHeader.FromRawUnchecked(rawData);
}

/// <summary>
/// The map pin a location header drops. Meta wants none of this at creation — the
/// component is just {"type":"header","format":"location"} — so these values exist
/// for Sent: a preview, and the default a StaticResource header falls back to at send.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Location, LocationFromRaw>))]
public sealed record class Location : JsonModel
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

    public Location() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Location(Location location)
        : base(location) { }
#pragma warning restore CS8618

    public Location(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Location(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LocationFromRaw.FromRawUnchecked"/>
    public static Location FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LocationFromRaw : IFromRawJson<Location>
{
    /// <inheritdoc/>
    public Location FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Location.FromRawUnchecked(rawData);
}
