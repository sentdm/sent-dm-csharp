using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;

namespace SentDm.Models.Templates;

[JsonConverter(typeof(JsonModelConverter<TemplateBodyContent, TemplateBodyContentFromRaw>))]
public sealed record class TemplateBodyContent : JsonModel
{
    public string? Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("template", value);
        }
    }

    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

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

    public TemplateBodyContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateBodyContent(TemplateBodyContent templateBodyContent)
        : base(templateBodyContent) { }
#pragma warning restore CS8618

    public TemplateBodyContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateBodyContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateBodyContentFromRaw.FromRawUnchecked"/>
    public static TemplateBodyContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateBodyContentFromRaw : IFromRawJson<TemplateBodyContent>
{
    /// <inheritdoc/>
    public TemplateBodyContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateBodyContent.FromRawUnchecked(rawData);
}
