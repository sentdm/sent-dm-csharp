using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Conversations;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ConversationListResponse, ConversationListResponseFromRaw>)
)]
public sealed record class ConversationListResponse : JsonModel
{
    /// <summary>
    /// A paginated list of messages — used by both conversation read endpoints.
    /// </summary>
    public Data? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public Error? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Error>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public Meta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Meta>("meta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data?.Validate();
        this.Error?.Validate();
        this.Meta?.Validate();
        _ = this.Success;
    }

    public ConversationListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListResponse(ConversationListResponse conversationListResponse)
        : base(conversationListResponse) { }
#pragma warning restore CS8618

    public ConversationListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListResponseFromRaw.FromRawUnchecked"/>
    public static ConversationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationListResponseFromRaw : IFromRawJson<ConversationListResponse>
{
    /// <inheritdoc/>
    public ConversationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A paginated list of messages — used by both conversation read endpoints.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
    public Pagination? Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Pagination>("pagination");
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

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

/// <summary>
/// Message response for v3 API — same shape as v2 with snake_case JSON conventions
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
    /// components (header, body, footer, buttons).
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
/// components (header, body, footer, buttons).
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
/// Pagination metadata for list responses
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pagination, PaginationFromRaw>))]
public sealed record class Pagination : JsonModel
{
    /// <summary>
    /// Cursor-based pagination. Never populated — see Cursors.
    /// </summary>
    [Obsolete("deprecated")]
    public Cursors? Cursors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cursors>("cursors");
        }
        init { this._rawData.Set("cursors", value); }
    }

    /// <summary>
    /// Whether there are more pages after this one
    /// </summary>
    public bool? HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("has_more");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("has_more", value);
        }
    }

    /// <summary>
    /// Current page number (1-indexed)
    /// </summary>
    public int? Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("page");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("page", value);
        }
    }

    /// <summary>
    /// Number of items per page
    /// </summary>
    public int? PageSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("page_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("page_size", value);
        }
    }

    /// <summary>
    /// Total number of items across all pages
    /// </summary>
    public int? TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("total_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_count", value);
        }
    }

    /// <summary>
    /// Total number of pages
    /// </summary>
    public int? TotalPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("total_pages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_pages", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cursors?.Validate();
        _ = this.HasMore;
        _ = this.Page;
        _ = this.PageSize;
        _ = this.TotalCount;
        _ = this.TotalPages;
    }

    public Pagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pagination(Pagination pagination)
        : base(pagination) { }
#pragma warning restore CS8618

    public Pagination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationFromRaw.FromRawUnchecked"/>
    public static Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginationFromRaw : IFromRawJson<Pagination>
{
    /// <inheritdoc/>
    public Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pagination.FromRawUnchecked(rawData);
}

/// <summary>
/// Cursor-based pagination. Never populated — see Cursors.
/// </summary>
[Obsolete("deprecated")]
[JsonConverter(typeof(JsonModelConverter<Cursors, CursorsFromRaw>))]
public sealed record class Cursors : JsonModel
{
    /// <summary>
    /// Cursor to fetch the next page.
    /// </summary>
    public string? After
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("after");
        }
        init { this._rawData.Set("after", value); }
    }

    /// <summary>
    /// Cursor to fetch the previous page.
    /// </summary>
    public string? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("before");
        }
        init { this._rawData.Set("before", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
    }

    public Cursors() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cursors(Cursors cursors)
        : base(cursors) { }
#pragma warning restore CS8618

    public Cursors(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cursors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CursorsFromRaw.FromRawUnchecked"/>
    public static Cursors FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CursorsFromRaw : IFromRawJson<Cursors>
{
    /// <inheritdoc/>
    public Cursors FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Cursors.FromRawUnchecked(rawData);
}

/// <summary>
/// Error information
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Error, ErrorFromRaw>))]
public sealed record class Error : JsonModel
{
    /// <summary>
    /// Machine-readable error code (e.g., "RESOURCE_001")
    /// </summary>
    public string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    /// <summary>
    /// Additional validation error details (field-level errors)
    /// </summary>
    public IReadOnlyDictionary<string, IReadOnlyList<string>>? Details
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableClass<
                FrozenDictionary<string, ImmutableArray<string>>
            >("details");
            if (value == null)
            {
                return null;
            }

            return FrozenDictionary.ToFrozenDictionary(
                value,
                entry => entry.Key,
                (entry) => (IReadOnlyList<string>)entry.Value
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, ImmutableArray<string>>?>(
                "details",
                value == null
                    ? null
                    : FrozenDictionary.ToFrozenDictionary(
                        value,
                        entry => entry.Key,
                        (entry) => ImmutableArray.ToImmutableArray(entry.Value)
                    )
            );
        }
    }

    /// <summary>
    /// URL to documentation about this error
    /// </summary>
    public string? DocUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("doc_url");
        }
        init { this._rawData.Set("doc_url", value); }
    }

    /// <summary>
    /// Human-readable error message
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Details;
        _ = this.DocUrl;
        _ = this.Message;
    }

    public Error() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Error(Error error)
        : base(error) { }
#pragma warning restore CS8618

    public Error(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Error(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ErrorFromRaw.FromRawUnchecked"/>
    public static Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ErrorFromRaw : IFromRawJson<Error>
{
    /// <inheritdoc/>
    public Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Error.FromRawUnchecked(rawData);
}

/// <summary>
/// Request and response metadata
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    /// <summary>
    /// Unique identifier for this request (for tracing and support)
    /// </summary>
    public string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("request_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("request_id", value);
        }
    }

    /// <summary>
    /// Server timestamp when the response was generated
    /// </summary>
    public DateTimeOffset? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("timestamp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    /// <summary>
    /// API version used for this request
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RequestID;
        _ = this.Timestamp;
        _ = this.Version;
    }

    public Meta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta(Meta meta)
        : base(meta) { }
#pragma warning restore CS8618

    public Meta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Meta.FromRawUnchecked(rawData);
}
