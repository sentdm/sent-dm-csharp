using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

[JsonConverter(typeof(JsonModelConverter<TemplateVariableProps, TemplateVariablePropsFromRaw>))]
public sealed record class TemplateVariableProps : JsonModel
{
    public required string MediaType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mediaType");
        }
        init { this._rawData.Set("mediaType", value); }
    }

    /// <summary>
    /// Example value substituted into the template when previewing it and when submitting
    /// it to Meta for review. Free text by nature, so the converter accepts a JSON
    /// number or boolean here and normalizes it — see JsonScalarToStringConverter
    /// for why — and guarantees it is always serialized back out as a JSON string.
    /// </summary>
    public required string Sample
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sample");
        }
        init { this._rawData.Set("sample", value); }
    }

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    public required string VariableType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("variableType");
        }
        init { this._rawData.Set("variableType", value); }
    }

    public string? Alt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("alt");
        }
        init { this._rawData.Set("alt", value); }
    }

    public string? Regex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("regex");
        }
        init { this._rawData.Set("regex", value); }
    }

    public string? ShortUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shortUrl");
        }
        init { this._rawData.Set("shortUrl", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MediaType;
        _ = this.Sample;
        _ = this.Url;
        _ = this.VariableType;
        _ = this.Alt;
        _ = this.Regex;
        _ = this.ShortUrl;
    }

    public TemplateVariableProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateVariableProps(TemplateVariableProps templateVariableProps)
        : base(templateVariableProps) { }
#pragma warning restore CS8618

    public TemplateVariableProps(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateVariableProps(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateVariablePropsFromRaw.FromRawUnchecked"/>
    public static TemplateVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateVariablePropsFromRaw : IFromRawJson<TemplateVariableProps>
{
    /// <inheritdoc/>
    public TemplateVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateVariableProps.FromRawUnchecked(rawData);
}
