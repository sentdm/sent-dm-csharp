using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Templates;

/// <summary>
/// A paginated list of templates.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TemplatesList, TemplatesListFromRaw>))]
public sealed record class TemplatesList : JsonModel
{
    /// <summary>
    /// Pagination metadata for list responses
    /// </summary>
    public PaginationMeta? Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>("pagination");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pagination", value);
        }
    }

    /// <summary>
    /// The templates on this page.
    /// </summary>
    public IReadOnlyList<Template>? Templates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Template>>("templates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Template>?>(
                "templates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Pagination?.Validate();
        foreach (var item in this.Templates ?? [])
        {
            item.Validate();
        }
    }

    public TemplatesList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplatesList(TemplatesList templatesList)
        : base(templatesList) { }
#pragma warning restore CS8618

    public TemplatesList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplatesList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplatesListFromRaw.FromRawUnchecked"/>
    public static TemplatesList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplatesListFromRaw : IFromRawJson<TemplatesList>
{
    /// <inheritdoc/>
    public TemplatesList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplatesList.FromRawUnchecked(rawData);
}
