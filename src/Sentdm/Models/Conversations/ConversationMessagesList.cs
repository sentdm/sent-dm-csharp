using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Conversations;

/// <summary>
/// A paginated list of messages — used by both conversation read endpoints.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ConversationMessagesList, ConversationMessagesListFromRaw>)
)]
public sealed record class ConversationMessagesList : JsonModel
{
    /// <summary>
    /// The messages on this page.
    /// </summary>
    public IReadOnlyList<Message>? Messages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Message>>("messages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Message>?>(
                "messages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata for list responses
    /// </summary>
    public PaginationMeta? Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>("pagination");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pagination", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Messages ?? [])
        {
            item.Validate();
        }
        this.Pagination?.Validate();
    }

    public ConversationMessagesList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationMessagesList(ConversationMessagesList conversationMessagesList)
        : base(conversationMessagesList) { }
#pragma warning restore CS8618

    public ConversationMessagesList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationMessagesList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationMessagesListFromRaw.FromRawUnchecked"/>
    public static ConversationMessagesList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationMessagesListFromRaw : IFromRawJson<ConversationMessagesList>
{
    /// <inheritdoc/>
    public ConversationMessagesList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationMessagesList.FromRawUnchecked(rawData);
}

/// <summary>
/// Message response for v3 API — same shape as v2 with snake_case JSON conventions.
///              The shape of a message that was sent immediately: it never has a
/// scheduled_at key. A message that is or was held for a later instant is a ScheduledMessageResponse,
/// and the endpoint decides which of the two to answer with. From always returns
/// this type.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Message, MessageFromRaw>))]
public sealed record class Message : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
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

    public double? ActiveContactPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("active_contact_price");
        }
        init { this._rawData.Set("active_contact_price", value); }
    }

    public string? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channel", value);
        }
    }

    public string? ContactID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contact_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contact_id", value);
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public string? CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customer_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("customer_id", value);
        }
    }

    public string? Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("direction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("direction", value);
        }
    }

    public IReadOnlyList<Event>? Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Event>>("events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Event>?>(
                "events",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Structured message body format for database storage. Preserves channel-specific
    /// components (header, header media, body, footer, buttons, MMS subject and media).
    ///              Persisted as the messageBody jsonb column on Messages. Every
    /// write path goes through MessageUtils.MessageBodyJsonOptions, which writes
    /// nulls, so the envelope shape is stable regardless of channel or status. Anything
    /// that rebuilds this object field by field — the four IMessageBodyStrategy
    /// implementations and MessageUtils.BuildSegmentBody — has to carry every member,
    /// or that member is silently dropped on whichever path forgot it.
    /// </summary>
    public MessageBody? MessageBody
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageBody>("message_body");
        }
        init { this._rawData.Set("message_body", value); }
    }

    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    public string? PhoneInternational
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_international");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_international", value);
        }
    }

    public double? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    public string? RegionCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("region_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("region_code", value);
        }
    }

    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public string? TemplateCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template_category");
        }
        init { this._rawData.Set("template_category", value); }
    }

    public string? TemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template_id");
        }
        init { this._rawData.Set("template_id", value); }
    }

    public string? TemplateName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template_name");
        }
        init { this._rawData.Set("template_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ActiveContactPrice;
        _ = this.Channel;
        _ = this.ContactID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        _ = this.Direction;
        foreach (var item in this.Events ?? [])
        {
            item.Validate();
        }
        this.MessageBody?.Validate();
        _ = this.Phone;
        _ = this.PhoneInternational;
        _ = this.Price;
        _ = this.RegionCode;
        _ = this.Status;
        _ = this.TemplateCategory;
        _ = this.TemplateID;
        _ = this.TemplateName;
    }

    public Message() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Message(Message message)
        : base(message) { }
#pragma warning restore CS8618

    public Message(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Message(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageFromRaw.FromRawUnchecked"/>
    public static Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageFromRaw : IFromRawJson<Message>
{
    /// <inheritdoc/>
    public Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Message.FromRawUnchecked(rawData);
}

/// <summary>
/// Represents a status change event in a message's lifecycle (v3)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Event, EventFromRaw>))]
public sealed record class Event : JsonModel
{
    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Status;
        _ = this.Timestamp;
        _ = this.Description;
    }

    public Event() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Event(Event event_)
        : base(event_) { }
#pragma warning restore CS8618

    public Event(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Event(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventFromRaw.FromRawUnchecked"/>
    public static Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventFromRaw : IFromRawJson<Event>
{
    /// <inheritdoc/>
    public Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Event.FromRawUnchecked(rawData);
}

/// <summary>
/// Structured message body format for database storage. Preserves channel-specific
/// components (header, header media, body, footer, buttons, MMS subject and media).
///              Persisted as the messageBody jsonb column on Messages. Every write
/// path goes through MessageUtils.MessageBodyJsonOptions, which writes nulls, so
/// the envelope shape is stable regardless of channel or status. Anything that rebuilds
/// this object field by field — the four IMessageBodyStrategy implementations and
/// MessageUtils.BuildSegmentBody — has to carry every member, or that member is silently
/// dropped on whichever path forgot it.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageBody, MessageBodyFromRaw>))]
public sealed record class MessageBody : JsonModel
{
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

    public string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    public string? Footer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("footer");
        }
        init { this._rawData.Set("footer", value); }
    }

    public string? Header
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("header");
        }
        init { this._rawData.Set("header", value); }
    }

    /// <summary>
    /// The media asset that rode a message's header, recorded as sent.
    /// </summary>
    public HeaderMedia? HeaderMedia
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<HeaderMedia>("headerMedia");
        }
        init { this._rawData.Set("headerMedia", value); }
    }

    /// <summary>
    /// MMS attachments, as the publicly fetchable URLs handed to the carrier. Null
    /// on every other channel.              Persisted rather than derived because
    /// a resend and a curfew release rebuild the send from the stored row — MessageReplayCommandBuilder
    /// reads templateId and templateVariables and nothing else — so media that lives
    /// only on the original request would silently turn a replayed MMS into a text message.
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
    /// MMS subject line. Null on every other channel.
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
        foreach (var item in this.Buttons ?? [])
        {
            item.Validate();
        }
        _ = this.Content;
        _ = this.Footer;
        _ = this.Header;
        this.HeaderMedia?.Validate();
        foreach (var item in this.Media ?? [])
        {
            item.Validate();
        }
        _ = this.Subject;
    }

    public MessageBody() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageBody(MessageBody messageBody)
        : base(messageBody) { }
#pragma warning restore CS8618

    public MessageBody(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBody(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageBodyFromRaw.FromRawUnchecked"/>
    public static MessageBody FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageBodyFromRaw : IFromRawJson<MessageBody>
{
    /// <inheritdoc/>
    public MessageBody FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageBody.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Button, ButtonFromRaw>))]
public sealed record class Button : JsonModel
{
    public string? PostbackData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postbackData");
        }
        init { this._rawData.Set("postbackData", value); }
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

    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PostbackData;
        _ = this.Text;
        _ = this.Type;
        _ = this.Value;
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
/// The media asset that rode a message's header, recorded as sent.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<HeaderMedia, HeaderMediaFromRaw>))]
public sealed record class HeaderMedia : JsonModel
{
    /// <summary>
    /// "image", "video" or "document" — taken from the header's media variable.
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

    /// <summary>
    /// The https URL the caller supplied for this send. Never the template's stored
    /// props.sample, which is Meta's expiring header_handle rather than what was delivered.
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
        _ = this.Type;
        _ = this.Url;
    }

    public HeaderMedia() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HeaderMedia(HeaderMedia headerMedia)
        : base(headerMedia) { }
#pragma warning restore CS8618

    public HeaderMedia(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HeaderMedia(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HeaderMediaFromRaw.FromRawUnchecked"/>
    public static HeaderMedia FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HeaderMediaFromRaw : IFromRawJson<HeaderMedia>
{
    /// <inheritdoc/>
    public HeaderMedia FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        HeaderMedia.FromRawUnchecked(rawData);
}

/// <summary>
/// One attachment on a message: a customer-supplied public URL handed to the carrier
/// as-is.                           A URL and nothing else. sent.dm never takes
/// custody of MMS media — the customer hosts it and we              pass the link
/// through at send time — so there is no storage key, size or expiry to record.
/// If we ever              do host attachments, that belongs with the change that
/// introduces the hosting, not here.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Media, MediaFromRaw>))]
public sealed record class Media : JsonModel
{
    /// <summary>
    /// One of Constants.MmsMediaTypes when known. Advisory — the carrier reads the
    ///             fetched object's Content-Type, not this.
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
