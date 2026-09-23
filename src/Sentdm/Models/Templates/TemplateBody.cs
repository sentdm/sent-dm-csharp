using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

/// <summary>
/// Body section of a message template.              A body picks one of two authoring
/// strategies, and mixing them is refused (TemplateDefinitionValidator.HaveValidChannelConfiguration):
/// a shared multiChannel body on its own, or an explicit sms + whatsapp pair, both
/// present.              multiChannel together with sms or whatsapp is rejected,
/// and so is sms or whatsapp on its own — every template is expected to be deliverable
/// on every channel. rcs is the one true override: it may accompany either strategy
/// to vary the copy, but cannot stand alone.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TemplateBody, TemplateBodyFromRaw>))]
public sealed record class TemplateBody : JsonModel
{
    /// <summary>
    /// MMS-specific content — subject, text and attachments.              Like Rcs,
    /// an override that cannot stand on its own: a template still needs a MultiChannel
    /// body or the Sms + Whatsapp pair to be deliverable at all. Unlike Rcs, it
    /// has no fallback at send time — MMS with no media is a more expensive SMS,
    /// so a template without this slot is deliberately not MMS-capable and never
    /// produces an MMS route candidate.
    /// </summary>
    public Mms? Mms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Mms>("mms");
        }
        init { this._rawData.Set("mms", value); }
    }

    /// <summary>
    /// The shared body, used for every channel. One half of the choice described above.
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
    /// RCS-specific copy that overrides the chosen strategy for RCS only. The one
    /// true override: optional on top of either strategy, but it cannot be the only
    /// body present. Its length cap is the higher one described on Template.
    /// </summary>
    public TemplateBodyContent? Rcs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateBodyContent>("rcs");
        }
        init { this._rawData.Set("rcs", value); }
    }

    /// <summary>
    /// The SMS body. It does not override multiChannel, it replaces it.
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
    /// The WhatsApp body. It does not override multiChannel, it replaces it.
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
        this.Mms?.Validate();
        this.MultiChannel?.Validate();
        this.Rcs?.Validate();
        this.Sms?.Validate();
        this.Whatsapp?.Validate();
    }

    public TemplateBody() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateBody(TemplateBody templateBody)
        : base(templateBody) { }
#pragma warning restore CS8618

    public TemplateBody(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateBody(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateBodyFromRaw.FromRawUnchecked"/>
    public static TemplateBody FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateBodyFromRaw : IFromRawJson<TemplateBody>
{
    /// <inheritdoc/>
    public TemplateBody FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateBody.FromRawUnchecked(rawData);
}

/// <summary>
/// MMS-specific content — subject, text and attachments.              Like Rcs, an
/// override that cannot stand on its own: a template still needs a MultiChannel body
/// or the Sms + Whatsapp pair to be deliverable at all. Unlike Rcs, it has no fallback
/// at send time — MMS with no media is a more expensive SMS, so a template without
/// this slot is deliberately not MMS-capable and never produces an MMS route candidate.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Mms, MmsFromRaw>))]
public sealed record class Mms : JsonModel
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

    /// <summary>
    /// Attachments carried by every send on this template, in order. A per-send
    /// media_urls on the request replaces this list rather than adding to it, so
    /// a template can hold a default creative and a caller can still send something recipient-specific.
    /// </summary>
    public IReadOnlyList<Media>? Media
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Media>>("media");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Media>?>(
                "media",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// MMS subject line. Optional — most handsets render it above the body, some
    /// ignore it entirely. Deliberately its own field rather than riding TemplateHeader:
    /// the header is authored once and shared across every channel, and carries
    /// Meta's 60-character cap plus its no-newline, no-emoji text rules, none of
    /// which describe an MMS subject.
    /// </summary>
    public string? Subject
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subject");
        }
        init { this._rawData.Set("subject", value); }
    }

    public static implicit operator TemplateBodyContent(Mms mms) =>
        new()
        {
            Template = mms.Template,
            Type = mms.Type,
            Variables = mms.Variables,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Template;
        _ = this.Type;
        foreach (var item in this.Variables ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Media ?? [])
        {
            item.Validate();
        }
        _ = this.Subject;
    }

    public Mms() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Mms(Mms mms)
        : base(mms) { }
#pragma warning restore CS8618

    public Mms(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Mms(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MmsFromRaw.FromRawUnchecked"/>
    public static Mms FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Mms(string template)
        : this()
    {
        this.Template = template;
    }
}

class MmsFromRaw : IFromRawJson<Mms>
{
    /// <inheritdoc/>
    public Mms FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Mms.FromRawUnchecked(rawData);
}

/// <summary>
/// MMS-specific body content.              Why MMS needs its own type when the other
/// channels share one: it is the only channel with a subject line and the only one
/// with attachments. Every other channel's body is text and variables, which is
/// exactly what TemplateBodyContent already is. Putting Subject and Media on the
/// shared type instead would give sms, whatsapp and rcs two members none of them
/// can ever use.              Derives from TemplateBodyContent so that every existing
/// consumer of a body slot — MessageUtils.ConvertVariableToReadable, TemplateDefinition.GetRequiredVariables,
/// TemplateDefinitionValidator.ApplyBodyContentRules — reads it with no change.
/// The two extra members are what the MMS strategy and the provider request need
/// on top.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties,
        SentDmServicesCommonEntitiesTemplateMmsBodyContentPropertiesFromRaw
    >)
)]
public sealed record class SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties : JsonModel
{
    /// <summary>
    /// Attachments carried by every send on this template, in order. A per-send
    /// media_urls on the request replaces this list rather than adding to it, so
    /// a template can hold a default creative and a caller can still send something recipient-specific.
    /// </summary>
    public IReadOnlyList<Media>? Media
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Media>>("media");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Media>?>(
                "media",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// MMS subject line. Optional — most handsets render it above the body, some
    /// ignore it entirely. Deliberately its own field rather than riding TemplateHeader:
    /// the header is authored once and shared across every channel, and carries
    /// Meta's 60-character cap plus its no-newline, no-emoji text rules, none of
    /// which describe an MMS subject.
    /// </summary>
    public string? Subject
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subject");
        }
        init { this._rawData.Set("subject", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Media ?? [])
        {
            item.Validate();
        }
        _ = this.Subject;
    }

    public SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties(
        SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties sentDmServicesCommonEntitiesTemplateMmsBodyContentProperties
    )
        : base(sentDmServicesCommonEntitiesTemplateMmsBodyContentProperties) { }
#pragma warning restore CS8618

    public SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentDmServicesCommonEntitiesTemplateMmsBodyContentPropertiesFromRaw.FromRawUnchecked"/>
    public static SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SentDmServicesCommonEntitiesTemplateMmsBodyContentPropertiesFromRaw
    : IFromRawJson<SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties>
{
    /// <inheritdoc/>
    public SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties.FromRawUnchecked(rawData);
}

/// <summary>
/// One attachment on an MMS template body.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Media, MediaFromRaw>))]
public sealed record class Media : JsonModel
{
    /// <summary>
    /// One of MmsMediaTypes. Advisory: the carrier reads the Content-Type off the
    ///             fetched object, not this field. It exists so an authoring UI
    /// can render the right preview and so a             reviewer can see what was intended.
    /// </summary>
    public string? MediaType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaType");
        }
        init { this._rawData.Set("mediaType", value); }
    }

    /// <summary>
    /// Publicly fetchable https URL. The carrier's MMSC fetches this at send time,
    /// so it has to             stay reachable and unauthenticated for the life of
    /// the send — including retries and a DLQ             replay — which is why a
    /// presigned URL is not a valid value here.
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MediaType;
        _ = this.Url;
    }

    public Media() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Media(Media media)
        : base(media) { }
#pragma warning restore CS8618

    public Media(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Media(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MediaFromRaw.FromRawUnchecked"/>
    public static Media FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MediaFromRaw : IFromRawJson<Media>
{
    /// <inheritdoc/>
    public Media FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Media.FromRawUnchecked(rawData);
}
