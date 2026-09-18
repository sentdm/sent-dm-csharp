using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

[JsonConverter(typeof(JsonModelConverter<TemplateBodyContent, TemplateBodyContentFromRaw>))]
public sealed record class TemplateBodyContent : JsonModel
{
    /// <summary>
    /// The body copy, with variables written as {{index:variable}}.
    ///  Length cap depends on which channel this body belongs to: TemplateContentLimits.MaxBodyLength
    /// (1024) for multiChannel, sms and whatsapp — Meta's BODY limit, which a multiChannel
    /// body may be delivered under — and TemplateContentLimits.MaxRcsBodyLength
    /// (3072) for an rcs body, which never reaches Meta. The maxLength advertised
    /// on this schema is the 1024 one, because all four channel bodies share this
    /// single schema — an rcs body between the two is accepted.              Meta
    /// requires every variable to carry surrounding context, so a body is refused
    /// unless it also satisfies all of the following (enforced by TemplateDefinitionValidator):
    /// At least one letter before the first variable and after the last — trailing
    /// punctuation such as "... {{1:variable}}." does not count. At least (2 × variable
    /// count) + 1 words once the placeholders are removed. No two variables adjacent
    /// with only whitespace between them. No leading or trailing newline, no more
    /// than two consecutive line breaks, and no more than four consecutive spaces.
    ///              Example: "Hello {{0:variable}}! Welcome to {{1:variable}}. We
    /// are glad to have you on board." — two variables, so at least five words are
    /// required, and the copy after the final variable contains letters.
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
    /// The type of body content — send "text". It is dropped from the stored definition
    /// when null, so a body posted without it is saved with no type key at all and
    /// the template editor has nothing to render the block from.
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
    /// The variables referenced by the body copy, one entry per {{index:variable}} placeholder.
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

    [SetsRequiredMembers]
    public TemplateBodyContent(string template)
        : this()
    {
        this.Template = template;
    }
}

class TemplateBodyContentFromRaw : IFromRawJson<TemplateBodyContent>
{
    /// <inheritdoc/>
    public TemplateBodyContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateBodyContent.FromRawUnchecked(rawData);
}
