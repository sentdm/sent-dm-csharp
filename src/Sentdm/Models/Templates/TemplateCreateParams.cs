using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

/// <summary>
/// Creates a new message template with header, body, footer, and buttons. The template
/// can be submitted for review immediately or saved as draft for later submission.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TemplateCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Template category: MARKETING, UTILITY, AUTHENTICATION (optional, auto-detected
    /// if not provided)
    /// </summary>
    public string? Category
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("category");
        }
        init { this._rawBodyData.Set("category", value); }
    }

    /// <summary>
    /// Source of template creation (default: from-api)
    /// </summary>
    public string? CreationSource
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("creation_source");
        }
        init { this._rawBodyData.Set("creation_source", value); }
    }

    /// <summary>
    /// Complete definition of a message template including header, body, footer,
    /// and buttons
    /// </summary>
    public Definition? Definition
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Definition>("definition");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("definition", value);
        }
    }

    /// <summary>
    /// Template language code (e.g., en_US) (optional, auto-detected if not provided)
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("language");
        }
        init { this._rawBodyData.Set("language", value); }
    }

    /// <summary>
    /// Sandbox flag - when true, the operation is simulated without side effects
    /// Useful for testing integrations without actual execution
    /// </summary>
    public bool? Sandbox
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("sandbox");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sandbox", value);
        }
    }

    /// <summary>
    /// Whether to submit the template for review after creation (default: false)
    /// </summary>
    public bool? SubmitForReview
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("submit_for_review");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("submit_for_review", value);
        }
    }

    public string? IdempotencyKey
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("Idempotency-Key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
        }
    }

    public string? XProfileID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("x-profile-id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("x-profile-id", value);
        }
    }

    public TemplateCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateCreateParams(TemplateCreateParams templateCreateParams)
        : base(templateCreateParams)
    {
        this._rawBodyData = new(templateCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TemplateCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TemplateCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TemplateCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/templates")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Complete definition of a message template including header, body, footer, and buttons
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Definition, DefinitionFromRaw>))]
public sealed record class Definition : JsonModel
{
    /// <summary>
    /// Body section of a message template with channel-specific content
    /// </summary>
    public required Body Body
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Body>("body");
        }
        init { this._rawData.Set("body", value); }
    }

    /// <summary>
    /// Configuration for AUTHENTICATION category templates
    /// </summary>
    public AuthenticationConfig? AuthenticationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AuthenticationConfig>("authenticationConfig");
        }
        init { this._rawData.Set("authenticationConfig", value); }
    }

    /// <summary>
    /// Optional list of interactive buttons (e.g., quick replies, URLs, phone numbers)
    /// </summary>
    public IReadOnlyList<Button>? Buttons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Button>>("buttons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Button>?>(
                "buttons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The version of the template definition format
    /// </summary>
    public string? DefinitionVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("definitionVersion");
        }
        init { this._rawData.Set("definitionVersion", value); }
    }

    /// <summary>
    /// Footer section of a message template
    /// </summary>
    public Footer? Footer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Footer>("footer");
        }
        init { this._rawData.Set("footer", value); }
    }

    /// <summary>
    /// Header section of a message template
    /// </summary>
    public Header? Header
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Header>("header");
        }
        init { this._rawData.Set("header", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Body.Validate();
        this.AuthenticationConfig?.Validate();
        foreach (var item in this.Buttons ?? [])
        {
            item.Validate();
        }
        _ = this.DefinitionVersion;
        this.Footer?.Validate();
        this.Header?.Validate();
    }

    public Definition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Definition(Definition definition)
        : base(definition) { }
#pragma warning restore CS8618

    public Definition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Definition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DefinitionFromRaw.FromRawUnchecked"/>
    public static Definition FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Definition(Body body)
        : this()
    {
        this.Body = body;
    }
}

class DefinitionFromRaw : IFromRawJson<Definition>
{
    /// <inheritdoc/>
    public Definition FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Definition.FromRawUnchecked(rawData);
}

/// <summary>
/// Body section of a message template with channel-specific content
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Body, BodyFromRaw>))]
public sealed record class Body : JsonModel
{
    /// <summary>
    /// Content that will be used for all channels (SMS and WhatsApp) unless channel-specific
    /// content is provided
    /// </summary>
    public MultiChannel? MultiChannel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MultiChannel>("multiChannel");
        }
        init { this._rawData.Set("multiChannel", value); }
    }

    /// <summary>
    /// RCS-specific content that overrides multi-channel content for RCS messages
    /// </summary>
    public Rcs? Rcs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Rcs>("rcs");
        }
        init { this._rawData.Set("rcs", value); }
    }

    /// <summary>
    /// SMS-specific content that overrides multi-channel content for SMS messages
    /// </summary>
    public Sms? Sms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Sms>("sms");
        }
        init { this._rawData.Set("sms", value); }
    }

    /// <summary>
    /// WhatsApp-specific content that overrides multi-channel content for WhatsApp messages
    /// </summary>
    public Whatsapp? Whatsapp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Whatsapp>("whatsapp");
        }
        init { this._rawData.Set("whatsapp", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MultiChannel?.Validate();
        this.Rcs?.Validate();
        this.Sms?.Validate();
        this.Whatsapp?.Validate();
    }

    public Body() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Body(Body body)
        : base(body) { }
#pragma warning restore CS8618

    public Body(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Body(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BodyFromRaw.FromRawUnchecked"/>
    public static Body FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BodyFromRaw : IFromRawJson<Body>
{
    /// <inheritdoc/>
    public Body FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Body.FromRawUnchecked(rawData);
}

/// <summary>
/// Content that will be used for all channels (SMS and WhatsApp) unless channel-specific
/// content is provided
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MultiChannel, MultiChannelFromRaw>))]
public sealed record class MultiChannel : JsonModel
{
    public required string Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("template");
        }
        init { this._rawData.Set("template", value); }
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

    public IReadOnlyList<Variable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Variable>>("variables");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Variable>?>(
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

    public MultiChannel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MultiChannel(MultiChannel multiChannel)
        : base(multiChannel) { }
#pragma warning restore CS8618

    public MultiChannel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MultiChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MultiChannelFromRaw.FromRawUnchecked"/>
    public static MultiChannel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MultiChannel(string template)
        : this()
    {
        this.Template = template;
    }
}

class MultiChannelFromRaw : IFromRawJson<MultiChannel>
{
    /// <inheritdoc/>
    public MultiChannel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MultiChannel.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Variable, VariableFromRaw>))]
public sealed record class Variable : JsonModel
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

    public Variable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Variable(Variable variable)
        : base(variable) { }
#pragma warning restore CS8618

    public Variable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Variable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VariableFromRaw.FromRawUnchecked"/>
    public static Variable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VariableFromRaw : IFromRawJson<Variable>
{
    /// <inheritdoc/>
    public Variable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Variable.FromRawUnchecked(rawData);
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

/// <summary>
/// RCS-specific content that overrides multi-channel content for RCS messages
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Rcs, RcsFromRaw>))]
public sealed record class Rcs : JsonModel
{
    public required string Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("template");
        }
        init { this._rawData.Set("template", value); }
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

    public IReadOnlyList<RcsVariable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RcsVariable>>("variables");
        }
        init
        {
            this._rawData.Set<ImmutableArray<RcsVariable>?>(
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

    public Rcs() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Rcs(Rcs rcs)
        : base(rcs) { }
#pragma warning restore CS8618

    public Rcs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Rcs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RcsFromRaw.FromRawUnchecked"/>
    public static Rcs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Rcs(string template)
        : this()
    {
        this.Template = template;
    }
}

class RcsFromRaw : IFromRawJson<Rcs>
{
    /// <inheritdoc/>
    public Rcs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Rcs.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<RcsVariable, RcsVariableFromRaw>))]
public sealed record class RcsVariable : JsonModel
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

    public required RcsVariableProps Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RcsVariableProps>("props");
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

    public RcsVariable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcsVariable(RcsVariable rcsVariable)
        : base(rcsVariable) { }
#pragma warning restore CS8618

    public RcsVariable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RcsVariable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RcsVariableFromRaw.FromRawUnchecked"/>
    public static RcsVariable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RcsVariableFromRaw : IFromRawJson<RcsVariable>
{
    /// <inheritdoc/>
    public RcsVariable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RcsVariable.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<RcsVariableProps, RcsVariablePropsFromRaw>))]
public sealed record class RcsVariableProps : JsonModel
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

    public RcsVariableProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcsVariableProps(RcsVariableProps rcsVariableProps)
        : base(rcsVariableProps) { }
#pragma warning restore CS8618

    public RcsVariableProps(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RcsVariableProps(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RcsVariablePropsFromRaw.FromRawUnchecked"/>
    public static RcsVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RcsVariablePropsFromRaw : IFromRawJson<RcsVariableProps>
{
    /// <inheritdoc/>
    public RcsVariableProps FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RcsVariableProps.FromRawUnchecked(rawData);
}

/// <summary>
/// SMS-specific content that overrides multi-channel content for SMS messages
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Sms, SmsFromRaw>))]
public sealed record class Sms : JsonModel
{
    public required string Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("template");
        }
        init { this._rawData.Set("template", value); }
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

    public IReadOnlyList<SmsVariable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SmsVariable>>("variables");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SmsVariable>?>(
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

    public Sms() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Sms(Sms sms)
        : base(sms) { }
#pragma warning restore CS8618

    public Sms(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Sms(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SmsFromRaw.FromRawUnchecked"/>
    public static Sms FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Sms(string template)
        : this()
    {
        this.Template = template;
    }
}

class SmsFromRaw : IFromRawJson<Sms>
{
    /// <inheritdoc/>
    public Sms FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Sms.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SmsVariable, SmsVariableFromRaw>))]
public sealed record class SmsVariable : JsonModel
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

    public required SmsVariableProps Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SmsVariableProps>("props");
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

    public SmsVariable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SmsVariable(SmsVariable smsVariable)
        : base(smsVariable) { }
#pragma warning restore CS8618

    public SmsVariable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SmsVariable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SmsVariableFromRaw.FromRawUnchecked"/>
    public static SmsVariable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SmsVariableFromRaw : IFromRawJson<SmsVariable>
{
    /// <inheritdoc/>
    public SmsVariable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SmsVariable.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SmsVariableProps, SmsVariablePropsFromRaw>))]
public sealed record class SmsVariableProps : JsonModel
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

    public SmsVariableProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SmsVariableProps(SmsVariableProps smsVariableProps)
        : base(smsVariableProps) { }
#pragma warning restore CS8618

    public SmsVariableProps(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SmsVariableProps(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SmsVariablePropsFromRaw.FromRawUnchecked"/>
    public static SmsVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SmsVariablePropsFromRaw : IFromRawJson<SmsVariableProps>
{
    /// <inheritdoc/>
    public SmsVariableProps FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SmsVariableProps.FromRawUnchecked(rawData);
}

/// <summary>
/// WhatsApp-specific content that overrides multi-channel content for WhatsApp messages
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Whatsapp, WhatsappFromRaw>))]
public sealed record class Whatsapp : JsonModel
{
    public required string Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("template");
        }
        init { this._rawData.Set("template", value); }
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

    public IReadOnlyList<WhatsappVariable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WhatsappVariable>>("variables");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WhatsappVariable>?>(
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

    public Whatsapp() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Whatsapp(Whatsapp whatsapp)
        : base(whatsapp) { }
#pragma warning restore CS8618

    public Whatsapp(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Whatsapp(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappFromRaw.FromRawUnchecked"/>
    public static Whatsapp FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Whatsapp(string template)
        : this()
    {
        this.Template = template;
    }
}

class WhatsappFromRaw : IFromRawJson<Whatsapp>
{
    /// <inheritdoc/>
    public Whatsapp FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Whatsapp.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<WhatsappVariable, WhatsappVariableFromRaw>))]
public sealed record class WhatsappVariable : JsonModel
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

    public required WhatsappVariableProps Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WhatsappVariableProps>("props");
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

    public WhatsappVariable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappVariable(WhatsappVariable whatsappVariable)
        : base(whatsappVariable) { }
#pragma warning restore CS8618

    public WhatsappVariable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappVariable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappVariableFromRaw.FromRawUnchecked"/>
    public static WhatsappVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WhatsappVariableFromRaw : IFromRawJson<WhatsappVariable>
{
    /// <inheritdoc/>
    public WhatsappVariable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WhatsappVariable.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<WhatsappVariableProps, WhatsappVariablePropsFromRaw>))]
public sealed record class WhatsappVariableProps : JsonModel
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

    public WhatsappVariableProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappVariableProps(WhatsappVariableProps whatsappVariableProps)
        : base(whatsappVariableProps) { }
#pragma warning restore CS8618

    public WhatsappVariableProps(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappVariableProps(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappVariablePropsFromRaw.FromRawUnchecked"/>
    public static WhatsappVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WhatsappVariablePropsFromRaw : IFromRawJson<WhatsappVariableProps>
{
    /// <inheritdoc/>
    public WhatsappVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WhatsappVariableProps.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for AUTHENTICATION category templates
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AuthenticationConfig, AuthenticationConfigFromRaw>))]
public sealed record class AuthenticationConfig : JsonModel
{
    /// <summary>
    /// Whether to add the security recommendation text: "For your security, do not
    /// share this code."
    /// </summary>
    public bool? AddSecurityRecommendation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("addSecurityRecommendation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("addSecurityRecommendation", value);
        }
    }

    /// <summary>
    /// Code expiration time in minutes (1-90). If set, adds footer: "This code expires
    /// in X minutes."
    /// </summary>
    public int? CodeExpirationMinutes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("codeExpirationMinutes");
        }
        init { this._rawData.Set("codeExpirationMinutes", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddSecurityRecommendation;
        _ = this.CodeExpirationMinutes;
    }

    public AuthenticationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuthenticationConfig(AuthenticationConfig authenticationConfig)
        : base(authenticationConfig) { }
#pragma warning restore CS8618

    public AuthenticationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthenticationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuthenticationConfigFromRaw.FromRawUnchecked"/>
    public static AuthenticationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AuthenticationConfigFromRaw : IFromRawJson<AuthenticationConfig>
{
    /// <inheritdoc/>
    public AuthenticationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AuthenticationConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Interactive button in a message template
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Button, ButtonFromRaw>))]
public sealed record class Button : JsonModel
{
    /// <summary>
    /// Properties specific to the button type
    /// </summary>
    public required ButtonProps Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ButtonProps>("props");
        }
        init { this._rawData.Set("props", value); }
    }

    /// <summary>
    /// The type of button (e.g., QUICK_REPLY, URL, PHONE_NUMBER, VOICE_CALL, COPY_CODE)
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The unique identifier of the button (1-based index)
    /// </summary>
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
        this.Props.Validate();
        _ = this.Type;
        _ = this.ID;
    }

    public Button() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Button(Button button)
        : base(button) { }
#pragma warning restore CS8618

    public Button(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Button(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ButtonFromRaw.FromRawUnchecked"/>
    public static Button FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ButtonFromRaw : IFromRawJson<Button>
{
    /// <inheritdoc/>
    public Button FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Button.FromRawUnchecked(rawData);
}

/// <summary>
/// Properties specific to the button type
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ButtonProps, ButtonPropsFromRaw>))]
public sealed record class ButtonProps : JsonModel
{
    public required int ActiveFor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("activeFor");
        }
        init { this._rawData.Set("activeFor", value); }
    }

    public required string CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("countryCode");
        }
        init { this._rawData.Set("countryCode", value); }
    }

    public required string OfferCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("offerCode");
        }
        init { this._rawData.Set("offerCode", value); }
    }

    public required string PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("phoneNumber");
        }
        init { this._rawData.Set("phoneNumber", value); }
    }

    public required string QuickReplyType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("quickReplyType");
        }
        init { this._rawData.Set("quickReplyType", value); }
    }

    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
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

    public required string UrlType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("urlType");
        }
        init { this._rawData.Set("urlType", value); }
    }

    public string? AutofillText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("autofillText");
        }
        init { this._rawData.Set("autofillText", value); }
    }

    public string? OtpType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("otpType");
        }
        init { this._rawData.Set("otpType", value); }
    }

    public string? PackageName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("packageName");
        }
        init { this._rawData.Set("packageName", value); }
    }

    public string? SignatureHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("signatureHash");
        }
        init { this._rawData.Set("signatureHash", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActiveFor;
        _ = this.CountryCode;
        _ = this.OfferCode;
        _ = this.PhoneNumber;
        _ = this.QuickReplyType;
        _ = this.Text;
        _ = this.Url;
        _ = this.UrlType;
        _ = this.AutofillText;
        _ = this.OtpType;
        _ = this.PackageName;
        _ = this.SignatureHash;
    }

    public ButtonProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ButtonProps(ButtonProps buttonProps)
        : base(buttonProps) { }
#pragma warning restore CS8618

    public ButtonProps(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ButtonProps(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ButtonPropsFromRaw.FromRawUnchecked"/>
    public static ButtonProps FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ButtonPropsFromRaw : IFromRawJson<ButtonProps>
{
    /// <inheritdoc/>
    public ButtonProps FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ButtonProps.FromRawUnchecked(rawData);
}

/// <summary>
/// Footer section of a message template
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Footer, FooterFromRaw>))]
public sealed record class Footer : JsonModel
{
    /// <summary>
    /// The footer template text with optional variable placeholders
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
    public IReadOnlyList<FooterVariable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FooterVariable>>("variables");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FooterVariable>?>(
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

    public Footer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Footer(Footer footer)
        : base(footer) { }
#pragma warning restore CS8618

    public Footer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Footer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FooterFromRaw.FromRawUnchecked"/>
    public static Footer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Footer(string template)
        : this()
    {
        this.Template = template;
    }
}

class FooterFromRaw : IFromRawJson<Footer>
{
    /// <inheritdoc/>
    public Footer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Footer.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FooterVariable, FooterVariableFromRaw>))]
public sealed record class FooterVariable : JsonModel
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

    public required FooterVariableProps Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FooterVariableProps>("props");
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

    public FooterVariable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FooterVariable(FooterVariable footerVariable)
        : base(footerVariable) { }
#pragma warning restore CS8618

    public FooterVariable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FooterVariable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FooterVariableFromRaw.FromRawUnchecked"/>
    public static FooterVariable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FooterVariableFromRaw : IFromRawJson<FooterVariable>
{
    /// <inheritdoc/>
    public FooterVariable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FooterVariable.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FooterVariableProps, FooterVariablePropsFromRaw>))]
public sealed record class FooterVariableProps : JsonModel
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

    public FooterVariableProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FooterVariableProps(FooterVariableProps footerVariableProps)
        : base(footerVariableProps) { }
#pragma warning restore CS8618

    public FooterVariableProps(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FooterVariableProps(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FooterVariablePropsFromRaw.FromRawUnchecked"/>
    public static FooterVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FooterVariablePropsFromRaw : IFromRawJson<FooterVariableProps>
{
    /// <inheritdoc/>
    public FooterVariableProps FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FooterVariableProps.FromRawUnchecked(rawData);
}

/// <summary>
/// Header section of a message template
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Header, HeaderFromRaw>))]
public sealed record class Header : JsonModel
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
    public IReadOnlyList<HeaderVariable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<HeaderVariable>>("variables");
        }
        init
        {
            this._rawData.Set<ImmutableArray<HeaderVariable>?>(
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

    public Header() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Header(Header header)
        : base(header) { }
#pragma warning restore CS8618

    public Header(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Header(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HeaderFromRaw.FromRawUnchecked"/>
    public static Header FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Header(string template)
        : this()
    {
        this.Template = template;
    }
}

class HeaderFromRaw : IFromRawJson<Header>
{
    /// <inheritdoc/>
    public Header FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Header.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<HeaderVariable, HeaderVariableFromRaw>))]
public sealed record class HeaderVariable : JsonModel
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

    public required HeaderVariableProps Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<HeaderVariableProps>("props");
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

    public HeaderVariable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HeaderVariable(HeaderVariable headerVariable)
        : base(headerVariable) { }
#pragma warning restore CS8618

    public HeaderVariable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HeaderVariable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HeaderVariableFromRaw.FromRawUnchecked"/>
    public static HeaderVariable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HeaderVariableFromRaw : IFromRawJson<HeaderVariable>
{
    /// <inheritdoc/>
    public HeaderVariable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        HeaderVariable.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<HeaderVariableProps, HeaderVariablePropsFromRaw>))]
public sealed record class HeaderVariableProps : JsonModel
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

    public HeaderVariableProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HeaderVariableProps(HeaderVariableProps headerVariableProps)
        : base(headerVariableProps) { }
#pragma warning restore CS8618

    public HeaderVariableProps(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HeaderVariableProps(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HeaderVariablePropsFromRaw.FromRawUnchecked"/>
    public static HeaderVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HeaderVariablePropsFromRaw : IFromRawJson<HeaderVariableProps>
{
    /// <inheritdoc/>
    public HeaderVariableProps FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        HeaderVariableProps.FromRawUnchecked(rawData);
}
