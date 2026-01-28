using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;

namespace SentDm.Models.Templates;

[JsonConverter(typeof(JsonModelConverter<TemplateVariable, TemplateVariableFromRaw>))]
public sealed record class TemplateVariable : JsonModel
{
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

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public TemplateVariableProps? Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateVariableProps>("props");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("props", value);
        }
    }

    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        this.Props?.Validate();
        _ = this.Type;
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

[JsonConverter(typeof(JsonModelConverter<TemplateVariableProps, TemplateVariablePropsFromRaw>))]
public sealed record class TemplateVariableProps : JsonModel
{
    public string? Alt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("alt");
        }
        init { this._rawData.Set("alt", value); }
    }

    public string? MediaType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaType");
        }
        init { this._rawData.Set("mediaType", value); }
    }

    public string? Sample
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sample");
        }
        init { this._rawData.Set("sample", value); }
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

    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    public string? VariableType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("variableType");
        }
        init { this._rawData.Set("variableType", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Alt;
        _ = this.MediaType;
        _ = this.Sample;
        _ = this.ShortUrl;
        _ = this.Url;
        _ = this.VariableType;
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
