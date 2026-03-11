using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

/// <summary>
/// Footer section of a message template
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SentDmServicesCommonContractsPocOsTemplateFooter,
        SentDmServicesCommonContractsPocOsTemplateFooterFromRaw
    >)
)]
public sealed record class SentDmServicesCommonContractsPocOsTemplateFooter : JsonModel
{
    /// <summary>
    /// The footer template text with optional variable placeholders
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
    /// The type of footer (typically "text")
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
    /// List of variables used in the footer template
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

    public SentDmServicesCommonContractsPocOsTemplateFooter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentDmServicesCommonContractsPocOsTemplateFooter(
        SentDmServicesCommonContractsPocOsTemplateFooter sentDmServicesCommonContractsPocOsTemplateFooter
    )
        : base(sentDmServicesCommonContractsPocOsTemplateFooter) { }
#pragma warning restore CS8618

    public SentDmServicesCommonContractsPocOsTemplateFooter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentDmServicesCommonContractsPocOsTemplateFooter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentDmServicesCommonContractsPocOsTemplateFooterFromRaw.FromRawUnchecked"/>
    public static SentDmServicesCommonContractsPocOsTemplateFooter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SentDmServicesCommonContractsPocOsTemplateFooterFromRaw
    : IFromRawJson<SentDmServicesCommonContractsPocOsTemplateFooter>
{
    /// <inheritdoc/>
    public SentDmServicesCommonContractsPocOsTemplateFooter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SentDmServicesCommonContractsPocOsTemplateFooter.FromRawUnchecked(rawData);
}
