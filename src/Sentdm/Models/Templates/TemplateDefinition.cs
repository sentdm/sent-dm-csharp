using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

/// <summary>
/// Complete definition of a message template including header, body, footer, and buttons
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TemplateDefinition, TemplateDefinitionFromRaw>))]
public sealed record class TemplateDefinition : JsonModel
{
    /// <summary>
    /// Required template body with content for different channels (multi-channel,
    /// SMS-specific, or WhatsApp-specific)
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
    /// Configuration specific to AUTHENTICATION category templates (optional)
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
    /// Optional template footer with optional variables
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
    /// Optional template header with optional variables
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

    public TemplateDefinition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateDefinition(TemplateDefinition templateDefinition)
        : base(templateDefinition) { }
#pragma warning restore CS8618

    public TemplateDefinition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateDefinition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateDefinitionFromRaw.FromRawUnchecked"/>
    public static TemplateDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TemplateDefinition(Body body)
        : this()
    {
        this.Body = body;
    }
}

class TemplateDefinitionFromRaw : IFromRawJson<TemplateDefinition>
{
    /// <inheritdoc/>
    public TemplateDefinition FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateDefinition.FromRawUnchecked(rawData);
}

/// <summary>
/// Required template body with content for different channels (multi-channel, SMS-specific,
/// or WhatsApp-specific)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Body, BodyFromRaw>))]
public sealed record class Body : JsonModel
{
    /// <summary>
    /// Content that will be used for all channels (SMS and WhatsApp) unless channel-specific
    /// content is provided
    /// </summary>
    public TemplateBodyContent? MultiChannel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateBodyContent>("multiChannel");
        }
        init { this._rawData.Set("multiChannel", value); }
    }

    /// <summary>
    /// SMS-specific content that overrides multi-channel content for SMS messages
    /// </summary>
    public TemplateBodyContent? Sms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateBodyContent>("sms");
        }
        init { this._rawData.Set("sms", value); }
    }

    /// <summary>
    /// WhatsApp-specific content that overrides multi-channel content for WhatsApp messages
    /// </summary>
    public TemplateBodyContent? Whatsapp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateBodyContent>("whatsapp");
        }
        init { this._rawData.Set("whatsapp", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MultiChannel?.Validate();
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
/// Configuration specific to AUTHENTICATION category templates (optional)
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

    /// <summary>
    /// Properties specific to the button type
    /// </summary>
    public Props? Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Props>("props");
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

    /// <summary>
    /// The type of button (e.g., QUICK_REPLY, URL, PHONE_NUMBER, VOICE_CALL, COPY_CODE)
    /// </summary>
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
        this.Props?.Validate();
        _ = this.Type;
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
[JsonConverter(typeof(JsonModelConverter<Props, PropsFromRaw>))]
public sealed record class Props : JsonModel
{
    public int? ActiveFor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("activeFor");
        }
        init { this._rawData.Set("activeFor", value); }
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

    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("countryCode");
        }
        init { this._rawData.Set("countryCode", value); }
    }

    public string? OfferCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("offerCode");
        }
        init { this._rawData.Set("offerCode", value); }
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

    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phoneNumber");
        }
        init { this._rawData.Set("phoneNumber", value); }
    }

    public string? QuickReplyType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("quickReplyType");
        }
        init { this._rawData.Set("quickReplyType", value); }
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

    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
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

    public string? UrlType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("urlType");
        }
        init { this._rawData.Set("urlType", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActiveFor;
        _ = this.AutofillText;
        _ = this.CountryCode;
        _ = this.OfferCode;
        _ = this.OtpType;
        _ = this.PackageName;
        _ = this.PhoneNumber;
        _ = this.QuickReplyType;
        _ = this.SignatureHash;
        _ = this.Text;
        _ = this.Url;
        _ = this.UrlType;
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
/// Optional template footer with optional variables
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Footer, FooterFromRaw>))]
public sealed record class Footer : JsonModel
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
}

class FooterFromRaw : IFromRawJson<Footer>
{
    /// <inheritdoc/>
    public Footer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Footer.FromRawUnchecked(rawData);
}

/// <summary>
/// Optional template header with optional variables
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Header, HeaderFromRaw>))]
public sealed record class Header : JsonModel
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
}

class HeaderFromRaw : IFromRawJson<Header>
{
    /// <inheritdoc/>
    public Header FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Header.FromRawUnchecked(rawData);
}
