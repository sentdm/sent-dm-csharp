using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

/// <summary>
/// SDK-style template reference: resolve by ID or by name, with optional parameters.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TemplateRef, TemplateRefFromRaw>))]
public sealed record class TemplateRef : JsonModel
{
    /// <summary>
    /// Template ID (mutually exclusive with name)
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Template name (mutually exclusive with id)
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Template variable parameters for personalization, keyed by variable name.
    ///              Every variable the template declares is required; GET /v3/templates/{id}
    /// lists them. Supplying a key the template does not declare is ignored.
    ///           Media headers. A template whose header is an image (designed in
    /// WhatsApp Manager and imported into Sent) declares a reserved header_image
    /// key. Its value is a publicly reachable https URL that Meta fetches at send
    /// time — Sent does not host the asset, and the sample approved with the template
    /// is not reused. The key is derived from the header's media type, so header_video
    /// and header_document follow the same shape when those formats ship.
    ///        "parameters": {   "header_image": "https://cdn.example.com/banner.jpg",
    ///   "name": "John Doe" }
    /// </summary>
    public IReadOnlyDictionary<string, string>? Parameters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("parameters");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "parameters",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.Parameters;
    }

    public TemplateRef() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateRef(TemplateRef templateRef)
        : base(templateRef) { }
#pragma warning restore CS8618

    public TemplateRef(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateRef(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateRefFromRaw.FromRawUnchecked"/>
    public static TemplateRef FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateRefFromRaw : IFromRawJson<TemplateRef>
{
    /// <inheritdoc/>
    public TemplateRef FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateRef.FromRawUnchecked(rawData);
}
