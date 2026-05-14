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
/// Updates an existing template's name, category, language, definition, or submits
/// it for review.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TemplateUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Template category: MARKETING, UTILITY, AUTHENTICATION
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
    /// Complete definition of a message template including header, body, footer,
    /// and buttons
    /// </summary>
    public TemplateUpdateParamsDefinition? Definition
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TemplateUpdateParamsDefinition>("definition");
        }
        init { this._rawBodyData.Set("definition", value); }
    }

    /// <summary>
    /// Template language code (e.g., en_US)
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
    /// Template display name
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
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
    /// Whether to submit the template for review after updating (default: false)
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

    public TemplateUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParams(TemplateUpdateParams templateUpdateParams)
        : base(templateUpdateParams)
    {
        this.ID = templateUpdateParams.ID;

        this._rawBodyData = new(templateUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TemplateUpdateParams(
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
    TemplateUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TemplateUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
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

    public virtual bool Equals(TemplateUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v3/templates/{0}", this.ID)
        )
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
[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinition,
        TemplateUpdateParamsDefinitionFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinition : JsonModel
{
    /// <summary>
    /// Body section of a message template with channel-specific content
    /// </summary>
    public required TemplateUpdateParamsDefinitionBody Body
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TemplateUpdateParamsDefinitionBody>("body");
        }
        init { this._rawData.Set("body", value); }
    }

    /// <summary>
    /// Configuration for AUTHENTICATION category templates
    /// </summary>
    public TemplateUpdateParamsDefinitionAuthenticationConfig? AuthenticationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateUpdateParamsDefinitionAuthenticationConfig>(
                "authenticationConfig"
            );
        }
        init { this._rawData.Set("authenticationConfig", value); }
    }

    /// <summary>
    /// Optional list of interactive buttons (e.g., quick replies, URLs, phone numbers)
    /// </summary>
    public IReadOnlyList<TemplateUpdateParamsDefinitionButton>? Buttons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<TemplateUpdateParamsDefinitionButton>
            >("buttons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TemplateUpdateParamsDefinitionButton>?>(
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
    public TemplateUpdateParamsDefinitionFooter? Footer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateUpdateParamsDefinitionFooter>("footer");
        }
        init { this._rawData.Set("footer", value); }
    }

    /// <summary>
    /// Header section of a message template
    /// </summary>
    public TemplateUpdateParamsDefinitionHeader? Header
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateUpdateParamsDefinitionHeader>("header");
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

    public TemplateUpdateParamsDefinition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinition(
        TemplateUpdateParamsDefinition templateUpdateParamsDefinition
    )
        : base(templateUpdateParamsDefinition) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinition(TemplateUpdateParamsDefinitionBody body)
        : this()
    {
        this.Body = body;
    }
}

class TemplateUpdateParamsDefinitionFromRaw : IFromRawJson<TemplateUpdateParamsDefinition>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinition.FromRawUnchecked(rawData);
}

/// <summary>
/// Body section of a message template with channel-specific content
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionBody,
        TemplateUpdateParamsDefinitionBodyFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionBody : JsonModel
{
    /// <summary>
    /// Content that will be used for all channels (SMS and WhatsApp) unless channel-specific
    /// content is provided
    /// </summary>
    public TemplateUpdateParamsDefinitionBodyMultiChannel? MultiChannel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateUpdateParamsDefinitionBodyMultiChannel>(
                "multiChannel"
            );
        }
        init { this._rawData.Set("multiChannel", value); }
    }

    /// <summary>
    /// RCS-specific content that overrides multi-channel content for RCS messages
    /// </summary>
    public TemplateUpdateParamsDefinitionBodyRcs? Rcs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateUpdateParamsDefinitionBodyRcs>("rcs");
        }
        init { this._rawData.Set("rcs", value); }
    }

    /// <summary>
    /// SMS-specific content that overrides multi-channel content for SMS messages
    /// </summary>
    public TemplateUpdateParamsDefinitionBodySms? Sms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateUpdateParamsDefinitionBodySms>("sms");
        }
        init { this._rawData.Set("sms", value); }
    }

    /// <summary>
    /// WhatsApp-specific content that overrides multi-channel content for WhatsApp messages
    /// </summary>
    public TemplateUpdateParamsDefinitionBodyWhatsapp? Whatsapp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateUpdateParamsDefinitionBodyWhatsapp>(
                "whatsapp"
            );
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

    public TemplateUpdateParamsDefinitionBody() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBody(
        TemplateUpdateParamsDefinitionBody templateUpdateParamsDefinitionBody
    )
        : base(templateUpdateParamsDefinitionBody) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionBody(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionBody(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionBodyFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionBodyFromRaw : IFromRawJson<TemplateUpdateParamsDefinitionBody>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionBody.FromRawUnchecked(rawData);
}

/// <summary>
/// Content that will be used for all channels (SMS and WhatsApp) unless channel-specific
/// content is provided
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionBodyMultiChannel,
        TemplateUpdateParamsDefinitionBodyMultiChannelFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionBodyMultiChannel : JsonModel
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

    public IReadOnlyList<TemplateUpdateParamsDefinitionBodyMultiChannelVariable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<TemplateUpdateParamsDefinitionBodyMultiChannelVariable>
            >("variables");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TemplateUpdateParamsDefinitionBodyMultiChannelVariable>?>(
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

    public TemplateUpdateParamsDefinitionBodyMultiChannel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodyMultiChannel(
        TemplateUpdateParamsDefinitionBodyMultiChannel templateUpdateParamsDefinitionBodyMultiChannel
    )
        : base(templateUpdateParamsDefinitionBodyMultiChannel) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionBodyMultiChannel(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionBodyMultiChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionBodyMultiChannelFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionBodyMultiChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodyMultiChannel(string template)
        : this()
    {
        this.Template = template;
    }
}

class TemplateUpdateParamsDefinitionBodyMultiChannelFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionBodyMultiChannel>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionBodyMultiChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionBodyMultiChannel.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionBodyMultiChannelVariable,
        TemplateUpdateParamsDefinitionBodyMultiChannelVariableFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionBodyMultiChannelVariable : JsonModel
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

    public required TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps>(
                "props"
            );
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

    public TemplateUpdateParamsDefinitionBodyMultiChannelVariable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodyMultiChannelVariable(
        TemplateUpdateParamsDefinitionBodyMultiChannelVariable templateUpdateParamsDefinitionBodyMultiChannelVariable
    )
        : base(templateUpdateParamsDefinitionBodyMultiChannelVariable) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionBodyMultiChannelVariable(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionBodyMultiChannelVariable(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionBodyMultiChannelVariableFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionBodyMultiChannelVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionBodyMultiChannelVariableFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionBodyMultiChannelVariable>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionBodyMultiChannelVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionBodyMultiChannelVariable.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps,
        TemplateUpdateParamsDefinitionBodyMultiChannelVariablePropsFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps : JsonModel
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

    public TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps(
        TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps templateUpdateParamsDefinitionBodyMultiChannelVariableProps
    )
        : base(templateUpdateParamsDefinitionBodyMultiChannelVariableProps) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionBodyMultiChannelVariablePropsFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionBodyMultiChannelVariablePropsFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps.FromRawUnchecked(rawData);
}

/// <summary>
/// RCS-specific content that overrides multi-channel content for RCS messages
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionBodyRcs,
        TemplateUpdateParamsDefinitionBodyRcsFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionBodyRcs : JsonModel
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

    public IReadOnlyList<TemplateUpdateParamsDefinitionBodyRcsVariable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<TemplateUpdateParamsDefinitionBodyRcsVariable>
            >("variables");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TemplateUpdateParamsDefinitionBodyRcsVariable>?>(
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

    public TemplateUpdateParamsDefinitionBodyRcs() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodyRcs(
        TemplateUpdateParamsDefinitionBodyRcs templateUpdateParamsDefinitionBodyRcs
    )
        : base(templateUpdateParamsDefinitionBodyRcs) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionBodyRcs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionBodyRcs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionBodyRcsFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionBodyRcs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodyRcs(string template)
        : this()
    {
        this.Template = template;
    }
}

class TemplateUpdateParamsDefinitionBodyRcsFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionBodyRcs>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionBodyRcs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionBodyRcs.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionBodyRcsVariable,
        TemplateUpdateParamsDefinitionBodyRcsVariableFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionBodyRcsVariable : JsonModel
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

    public required TemplateUpdateParamsDefinitionBodyRcsVariableProps Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TemplateUpdateParamsDefinitionBodyRcsVariableProps>(
                "props"
            );
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

    public TemplateUpdateParamsDefinitionBodyRcsVariable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodyRcsVariable(
        TemplateUpdateParamsDefinitionBodyRcsVariable templateUpdateParamsDefinitionBodyRcsVariable
    )
        : base(templateUpdateParamsDefinitionBodyRcsVariable) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionBodyRcsVariable(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionBodyRcsVariable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionBodyRcsVariableFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionBodyRcsVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionBodyRcsVariableFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionBodyRcsVariable>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionBodyRcsVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionBodyRcsVariable.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionBodyRcsVariableProps,
        TemplateUpdateParamsDefinitionBodyRcsVariablePropsFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionBodyRcsVariableProps : JsonModel
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

    public TemplateUpdateParamsDefinitionBodyRcsVariableProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodyRcsVariableProps(
        TemplateUpdateParamsDefinitionBodyRcsVariableProps templateUpdateParamsDefinitionBodyRcsVariableProps
    )
        : base(templateUpdateParamsDefinitionBodyRcsVariableProps) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionBodyRcsVariableProps(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionBodyRcsVariableProps(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionBodyRcsVariablePropsFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionBodyRcsVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionBodyRcsVariablePropsFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionBodyRcsVariableProps>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionBodyRcsVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionBodyRcsVariableProps.FromRawUnchecked(rawData);
}

/// <summary>
/// SMS-specific content that overrides multi-channel content for SMS messages
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionBodySms,
        TemplateUpdateParamsDefinitionBodySmsFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionBodySms : JsonModel
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

    public IReadOnlyList<TemplateUpdateParamsDefinitionBodySmsVariable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<TemplateUpdateParamsDefinitionBodySmsVariable>
            >("variables");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TemplateUpdateParamsDefinitionBodySmsVariable>?>(
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

    public TemplateUpdateParamsDefinitionBodySms() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodySms(
        TemplateUpdateParamsDefinitionBodySms templateUpdateParamsDefinitionBodySms
    )
        : base(templateUpdateParamsDefinitionBodySms) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionBodySms(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionBodySms(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionBodySmsFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionBodySms FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodySms(string template)
        : this()
    {
        this.Template = template;
    }
}

class TemplateUpdateParamsDefinitionBodySmsFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionBodySms>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionBodySms FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionBodySms.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionBodySmsVariable,
        TemplateUpdateParamsDefinitionBodySmsVariableFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionBodySmsVariable : JsonModel
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

    public required TemplateUpdateParamsDefinitionBodySmsVariableProps Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TemplateUpdateParamsDefinitionBodySmsVariableProps>(
                "props"
            );
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

    public TemplateUpdateParamsDefinitionBodySmsVariable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodySmsVariable(
        TemplateUpdateParamsDefinitionBodySmsVariable templateUpdateParamsDefinitionBodySmsVariable
    )
        : base(templateUpdateParamsDefinitionBodySmsVariable) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionBodySmsVariable(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionBodySmsVariable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionBodySmsVariableFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionBodySmsVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionBodySmsVariableFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionBodySmsVariable>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionBodySmsVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionBodySmsVariable.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionBodySmsVariableProps,
        TemplateUpdateParamsDefinitionBodySmsVariablePropsFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionBodySmsVariableProps : JsonModel
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

    public TemplateUpdateParamsDefinitionBodySmsVariableProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodySmsVariableProps(
        TemplateUpdateParamsDefinitionBodySmsVariableProps templateUpdateParamsDefinitionBodySmsVariableProps
    )
        : base(templateUpdateParamsDefinitionBodySmsVariableProps) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionBodySmsVariableProps(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionBodySmsVariableProps(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionBodySmsVariablePropsFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionBodySmsVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionBodySmsVariablePropsFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionBodySmsVariableProps>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionBodySmsVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionBodySmsVariableProps.FromRawUnchecked(rawData);
}

/// <summary>
/// WhatsApp-specific content that overrides multi-channel content for WhatsApp messages
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionBodyWhatsapp,
        TemplateUpdateParamsDefinitionBodyWhatsappFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionBodyWhatsapp : JsonModel
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

    public IReadOnlyList<TemplateUpdateParamsDefinitionBodyWhatsappVariable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<TemplateUpdateParamsDefinitionBodyWhatsappVariable>
            >("variables");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TemplateUpdateParamsDefinitionBodyWhatsappVariable>?>(
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

    public TemplateUpdateParamsDefinitionBodyWhatsapp() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodyWhatsapp(
        TemplateUpdateParamsDefinitionBodyWhatsapp templateUpdateParamsDefinitionBodyWhatsapp
    )
        : base(templateUpdateParamsDefinitionBodyWhatsapp) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionBodyWhatsapp(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionBodyWhatsapp(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionBodyWhatsappFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionBodyWhatsapp FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodyWhatsapp(string template)
        : this()
    {
        this.Template = template;
    }
}

class TemplateUpdateParamsDefinitionBodyWhatsappFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionBodyWhatsapp>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionBodyWhatsapp FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionBodyWhatsapp.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionBodyWhatsappVariable,
        TemplateUpdateParamsDefinitionBodyWhatsappVariableFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionBodyWhatsappVariable : JsonModel
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

    public required TemplateUpdateParamsDefinitionBodyWhatsappVariableProps Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TemplateUpdateParamsDefinitionBodyWhatsappVariableProps>(
                "props"
            );
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

    public TemplateUpdateParamsDefinitionBodyWhatsappVariable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodyWhatsappVariable(
        TemplateUpdateParamsDefinitionBodyWhatsappVariable templateUpdateParamsDefinitionBodyWhatsappVariable
    )
        : base(templateUpdateParamsDefinitionBodyWhatsappVariable) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionBodyWhatsappVariable(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionBodyWhatsappVariable(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionBodyWhatsappVariableFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionBodyWhatsappVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionBodyWhatsappVariableFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionBodyWhatsappVariable>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionBodyWhatsappVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionBodyWhatsappVariable.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionBodyWhatsappVariableProps,
        TemplateUpdateParamsDefinitionBodyWhatsappVariablePropsFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionBodyWhatsappVariableProps : JsonModel
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

    public TemplateUpdateParamsDefinitionBodyWhatsappVariableProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionBodyWhatsappVariableProps(
        TemplateUpdateParamsDefinitionBodyWhatsappVariableProps templateUpdateParamsDefinitionBodyWhatsappVariableProps
    )
        : base(templateUpdateParamsDefinitionBodyWhatsappVariableProps) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionBodyWhatsappVariableProps(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionBodyWhatsappVariableProps(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionBodyWhatsappVariablePropsFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionBodyWhatsappVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionBodyWhatsappVariablePropsFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionBodyWhatsappVariableProps>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionBodyWhatsappVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionBodyWhatsappVariableProps.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for AUTHENTICATION category templates
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionAuthenticationConfig,
        TemplateUpdateParamsDefinitionAuthenticationConfigFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionAuthenticationConfig : JsonModel
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

    public TemplateUpdateParamsDefinitionAuthenticationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionAuthenticationConfig(
        TemplateUpdateParamsDefinitionAuthenticationConfig templateUpdateParamsDefinitionAuthenticationConfig
    )
        : base(templateUpdateParamsDefinitionAuthenticationConfig) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionAuthenticationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionAuthenticationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionAuthenticationConfigFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionAuthenticationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionAuthenticationConfigFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionAuthenticationConfig>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionAuthenticationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionAuthenticationConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Interactive button in a message template
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionButton,
        TemplateUpdateParamsDefinitionButtonFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionButton : JsonModel
{
    /// <summary>
    /// Properties specific to the button type
    /// </summary>
    public required TemplateUpdateParamsDefinitionButtonProps Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TemplateUpdateParamsDefinitionButtonProps>(
                "props"
            );
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

    public TemplateUpdateParamsDefinitionButton() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionButton(
        TemplateUpdateParamsDefinitionButton templateUpdateParamsDefinitionButton
    )
        : base(templateUpdateParamsDefinitionButton) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionButton(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionButton(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionButtonFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionButton FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionButtonFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionButton>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionButton FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionButton.FromRawUnchecked(rawData);
}

/// <summary>
/// Properties specific to the button type
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionButtonProps,
        TemplateUpdateParamsDefinitionButtonPropsFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionButtonProps : JsonModel
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

    public TemplateUpdateParamsDefinitionButtonProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionButtonProps(
        TemplateUpdateParamsDefinitionButtonProps templateUpdateParamsDefinitionButtonProps
    )
        : base(templateUpdateParamsDefinitionButtonProps) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionButtonProps(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionButtonProps(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionButtonPropsFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionButtonProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionButtonPropsFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionButtonProps>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionButtonProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionButtonProps.FromRawUnchecked(rawData);
}

/// <summary>
/// Footer section of a message template
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionFooter,
        TemplateUpdateParamsDefinitionFooterFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionFooter : JsonModel
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
    public IReadOnlyList<TemplateUpdateParamsDefinitionFooterVariable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<TemplateUpdateParamsDefinitionFooterVariable>
            >("variables");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TemplateUpdateParamsDefinitionFooterVariable>?>(
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

    public TemplateUpdateParamsDefinitionFooter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionFooter(
        TemplateUpdateParamsDefinitionFooter templateUpdateParamsDefinitionFooter
    )
        : base(templateUpdateParamsDefinitionFooter) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionFooter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionFooter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionFooterFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionFooter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionFooter(string template)
        : this()
    {
        this.Template = template;
    }
}

class TemplateUpdateParamsDefinitionFooterFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionFooter>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionFooter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionFooter.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionFooterVariable,
        TemplateUpdateParamsDefinitionFooterVariableFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionFooterVariable : JsonModel
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

    public required TemplateUpdateParamsDefinitionFooterVariableProps Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TemplateUpdateParamsDefinitionFooterVariableProps>(
                "props"
            );
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

    public TemplateUpdateParamsDefinitionFooterVariable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionFooterVariable(
        TemplateUpdateParamsDefinitionFooterVariable templateUpdateParamsDefinitionFooterVariable
    )
        : base(templateUpdateParamsDefinitionFooterVariable) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionFooterVariable(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionFooterVariable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionFooterVariableFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionFooterVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionFooterVariableFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionFooterVariable>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionFooterVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionFooterVariable.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionFooterVariableProps,
        TemplateUpdateParamsDefinitionFooterVariablePropsFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionFooterVariableProps : JsonModel
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

    public TemplateUpdateParamsDefinitionFooterVariableProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionFooterVariableProps(
        TemplateUpdateParamsDefinitionFooterVariableProps templateUpdateParamsDefinitionFooterVariableProps
    )
        : base(templateUpdateParamsDefinitionFooterVariableProps) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionFooterVariableProps(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionFooterVariableProps(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionFooterVariablePropsFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionFooterVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionFooterVariablePropsFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionFooterVariableProps>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionFooterVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionFooterVariableProps.FromRawUnchecked(rawData);
}

/// <summary>
/// Header section of a message template
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionHeader,
        TemplateUpdateParamsDefinitionHeaderFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionHeader : JsonModel
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
    public IReadOnlyList<TemplateUpdateParamsDefinitionHeaderVariable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<TemplateUpdateParamsDefinitionHeaderVariable>
            >("variables");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TemplateUpdateParamsDefinitionHeaderVariable>?>(
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

    public TemplateUpdateParamsDefinitionHeader() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionHeader(
        TemplateUpdateParamsDefinitionHeader templateUpdateParamsDefinitionHeader
    )
        : base(templateUpdateParamsDefinitionHeader) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionHeader(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionHeader(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionHeaderFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionHeader(string template)
        : this()
    {
        this.Template = template;
    }
}

class TemplateUpdateParamsDefinitionHeaderFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionHeader>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionHeader.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionHeaderVariable,
        TemplateUpdateParamsDefinitionHeaderVariableFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionHeaderVariable : JsonModel
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

    public required TemplateUpdateParamsDefinitionHeaderVariableProps Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TemplateUpdateParamsDefinitionHeaderVariableProps>(
                "props"
            );
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

    public TemplateUpdateParamsDefinitionHeaderVariable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionHeaderVariable(
        TemplateUpdateParamsDefinitionHeaderVariable templateUpdateParamsDefinitionHeaderVariable
    )
        : base(templateUpdateParamsDefinitionHeaderVariable) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionHeaderVariable(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionHeaderVariable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionHeaderVariableFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionHeaderVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionHeaderVariableFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionHeaderVariable>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionHeaderVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionHeaderVariable.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateUpdateParamsDefinitionHeaderVariableProps,
        TemplateUpdateParamsDefinitionHeaderVariablePropsFromRaw
    >)
)]
public sealed record class TemplateUpdateParamsDefinitionHeaderVariableProps : JsonModel
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

    public TemplateUpdateParamsDefinitionHeaderVariableProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateUpdateParamsDefinitionHeaderVariableProps(
        TemplateUpdateParamsDefinitionHeaderVariableProps templateUpdateParamsDefinitionHeaderVariableProps
    )
        : base(templateUpdateParamsDefinitionHeaderVariableProps) { }
#pragma warning restore CS8618

    public TemplateUpdateParamsDefinitionHeaderVariableProps(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateUpdateParamsDefinitionHeaderVariableProps(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateUpdateParamsDefinitionHeaderVariablePropsFromRaw.FromRawUnchecked"/>
    public static TemplateUpdateParamsDefinitionHeaderVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateUpdateParamsDefinitionHeaderVariablePropsFromRaw
    : IFromRawJson<TemplateUpdateParamsDefinitionHeaderVariableProps>
{
    /// <inheritdoc/>
    public TemplateUpdateParamsDefinitionHeaderVariableProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateUpdateParamsDefinitionHeaderVariableProps.FromRawUnchecked(rawData);
}
