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
[JsonConverter(
    typeof(JsonModelConverter<
        SentDmServicesCommonContractsPocOsTemplateHeader,
        SentDmServicesCommonContractsPocOsTemplateHeaderFromRaw
    >)
)]
public sealed record class SentDmServicesCommonContractsPocOsTemplateHeader : JsonModel
{
    /// <summary>
    /// The header template text with optional variable placeholders (e.g., "Welcome
    /// to {{0:variable}}")
    /// </summary>
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

    public SentDmServicesCommonContractsPocOsTemplateHeader() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentDmServicesCommonContractsPocOsTemplateHeader(
        SentDmServicesCommonContractsPocOsTemplateHeader sentDmServicesCommonContractsPocOsTemplateHeader
    )
        : base(sentDmServicesCommonContractsPocOsTemplateHeader) { }
#pragma warning restore CS8618

    public SentDmServicesCommonContractsPocOsTemplateHeader(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentDmServicesCommonContractsPocOsTemplateHeader(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentDmServicesCommonContractsPocOsTemplateHeaderFromRaw.FromRawUnchecked"/>
    public static SentDmServicesCommonContractsPocOsTemplateHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SentDmServicesCommonContractsPocOsTemplateHeaderFromRaw
    : IFromRawJson<SentDmServicesCommonContractsPocOsTemplateHeader>
{
    /// <inheritdoc/>
    public SentDmServicesCommonContractsPocOsTemplateHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SentDmServicesCommonContractsPocOsTemplateHeader.FromRawUnchecked(rawData);
}
