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
    /// The type of header (e.g., "text", "image", "video", "document")
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
