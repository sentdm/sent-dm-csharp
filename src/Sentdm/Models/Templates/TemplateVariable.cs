using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

[JsonConverter(typeof(JsonModelConverter<TemplateVariable, TemplateVariableFromRaw>))]
public sealed record class TemplateVariable : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required Props Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Props>("props");
        }
        init { this._rawData.Set("props", value); }
    }

    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public int? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        this.Props.Validate();
        _ = this.Type;
        _ = this.ID;
    }

    public TemplateVariable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateVariable(TemplateVariable templateVariable)
        : base(templateVariable) { }
#pragma warning restore CS8618

    public TemplateVariable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateVariable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateVariableFromRaw.FromRawUnchecked"/>
    public static TemplateVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateVariableFromRaw : IFromRawJson<TemplateVariable>
{
    /// <inheritdoc/>
    public TemplateVariable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateVariable.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Props, PropsFromRaw>))]
public sealed record class Props : JsonModel
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

    public Props() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Props(Props props)
        : base(props) { }
#pragma warning restore CS8618

    public Props(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Props(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PropsFromRaw.FromRawUnchecked"/>
    public static Props FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PropsFromRaw : IFromRawJson<Props>
{
    /// <inheritdoc/>
    public Props FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Props.FromRawUnchecked(rawData);
}
