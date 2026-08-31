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
    typeof(JsonModelConverter<
        ConversationListMessagesResponse,
        ConversationListMessagesResponseFromRaw
    >)
)]
public sealed record class ConversationListMessagesResponse : JsonModel
{
    /// <summary>
    /// A paginated list of messages — used by both conversation read endpoints.
    /// </summary>
    public ConversationListMessagesResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConversationListMessagesResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public ConversationListMessagesResponseError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConversationListMessagesResponseError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public ConversationListMessagesResponseMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConversationListMessagesResponseMeta>("meta");
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

    public ConversationListMessagesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListMessagesResponse(
        ConversationListMessagesResponse conversationListMessagesResponse
    )
        : base(conversationListMessagesResponse) { }
#pragma warning restore CS8618

    public ConversationListMessagesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListMessagesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListMessagesResponseFromRaw.FromRawUnchecked"/>
    public static ConversationListMessagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationListMessagesResponseFromRaw : IFromRawJson<ConversationListMessagesResponse>
{
    /// <inheritdoc/>
    public ConversationListMessagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListMessagesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A paginated list of messages — used by both conversation read endpoints.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConversationListMessagesResponseData,
        ConversationListMessagesResponseDataFromRaw
    >)
)]
public sealed record class ConversationListMessagesResponseData : JsonModel
{
    /// <summary>
    /// The messages on this page.
    /// </summary>
    public IReadOnlyList<ConversationListMessagesResponseDataMessage>? Messages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ConversationListMessagesResponseDataMessage>
            >("messages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ConversationListMessagesResponseDataMessage>?>(
                "messages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata for list responses
    /// </summary>
    public ConversationListMessagesResponseDataPagination? Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConversationListMessagesResponseDataPagination>(
                "pagination"
            );
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

    public ConversationListMessagesResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListMessagesResponseData(
        ConversationListMessagesResponseData conversationListMessagesResponseData
    )
        : base(conversationListMessagesResponseData) { }
#pragma warning restore CS8618

    public ConversationListMessagesResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListMessagesResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListMessagesResponseDataFromRaw.FromRawUnchecked"/>
    public static ConversationListMessagesResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationListMessagesResponseDataFromRaw
    : IFromRawJson<ConversationListMessagesResponseData>
{
    /// <inheritdoc/>
    public ConversationListMessagesResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListMessagesResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Message response for v3 API — same shape as v2 with snake_case JSON conventions
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConversationListMessagesResponseDataMessage,
        ConversationListMessagesResponseDataMessageFromRaw
    >)
)]
public sealed record class ConversationListMessagesResponseDataMessage : JsonModel
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

    public IReadOnlyList<ConversationListMessagesResponseDataMessageEvent>? Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ConversationListMessagesResponseDataMessageEvent>
            >("events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ConversationListMessagesResponseDataMessageEvent>?>(
                "events",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Structured message body format for database storage. Preserves channel-specific
    /// components (header, body, footer, buttons).
    /// </summary>
    public ConversationListMessagesResponseDataMessageMessageBody? MessageBody
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConversationListMessagesResponseDataMessageMessageBody>(
                "message_body"
            );
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

    public ConversationListMessagesResponseDataMessage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListMessagesResponseDataMessage(
        ConversationListMessagesResponseDataMessage conversationListMessagesResponseDataMessage
    )
        : base(conversationListMessagesResponseDataMessage) { }
#pragma warning restore CS8618

    public ConversationListMessagesResponseDataMessage(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListMessagesResponseDataMessage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListMessagesResponseDataMessageFromRaw.FromRawUnchecked"/>
    public static ConversationListMessagesResponseDataMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationListMessagesResponseDataMessageFromRaw
    : IFromRawJson<ConversationListMessagesResponseDataMessage>
{
    /// <inheritdoc/>
    public ConversationListMessagesResponseDataMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListMessagesResponseDataMessage.FromRawUnchecked(rawData);
}

/// <summary>
/// Represents a status change event in a message's lifecycle (v3)
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConversationListMessagesResponseDataMessageEvent,
        ConversationListMessagesResponseDataMessageEventFromRaw
    >)
)]
public sealed record class ConversationListMessagesResponseDataMessageEvent : JsonModel
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

    public ConversationListMessagesResponseDataMessageEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListMessagesResponseDataMessageEvent(
        ConversationListMessagesResponseDataMessageEvent conversationListMessagesResponseDataMessageEvent
    )
        : base(conversationListMessagesResponseDataMessageEvent) { }
#pragma warning restore CS8618

    public ConversationListMessagesResponseDataMessageEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListMessagesResponseDataMessageEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListMessagesResponseDataMessageEventFromRaw.FromRawUnchecked"/>
    public static ConversationListMessagesResponseDataMessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationListMessagesResponseDataMessageEventFromRaw
    : IFromRawJson<ConversationListMessagesResponseDataMessageEvent>
{
    /// <inheritdoc/>
    public ConversationListMessagesResponseDataMessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListMessagesResponseDataMessageEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Structured message body format for database storage. Preserves channel-specific
/// components (header, body, footer, buttons).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConversationListMessagesResponseDataMessageMessageBody,
        ConversationListMessagesResponseDataMessageMessageBodyFromRaw
    >)
)]
public sealed record class ConversationListMessagesResponseDataMessageMessageBody : JsonModel
{
    public IReadOnlyList<ConversationListMessagesResponseDataMessageMessageBodyButton>? Buttons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ConversationListMessagesResponseDataMessageMessageBodyButton>
            >("buttons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ConversationListMessagesResponseDataMessageMessageBodyButton>?>(
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

    public ConversationListMessagesResponseDataMessageMessageBody() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListMessagesResponseDataMessageMessageBody(
        ConversationListMessagesResponseDataMessageMessageBody conversationListMessagesResponseDataMessageMessageBody
    )
        : base(conversationListMessagesResponseDataMessageMessageBody) { }
#pragma warning restore CS8618

    public ConversationListMessagesResponseDataMessageMessageBody(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListMessagesResponseDataMessageMessageBody(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListMessagesResponseDataMessageMessageBodyFromRaw.FromRawUnchecked"/>
    public static ConversationListMessagesResponseDataMessageMessageBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationListMessagesResponseDataMessageMessageBodyFromRaw
    : IFromRawJson<ConversationListMessagesResponseDataMessageMessageBody>
{
    /// <inheritdoc/>
    public ConversationListMessagesResponseDataMessageMessageBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListMessagesResponseDataMessageMessageBody.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ConversationListMessagesResponseDataMessageMessageBodyButton,
        ConversationListMessagesResponseDataMessageMessageBodyButtonFromRaw
    >)
)]
public sealed record class ConversationListMessagesResponseDataMessageMessageBodyButton : JsonModel
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

    public ConversationListMessagesResponseDataMessageMessageBodyButton() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListMessagesResponseDataMessageMessageBodyButton(
        ConversationListMessagesResponseDataMessageMessageBodyButton conversationListMessagesResponseDataMessageMessageBodyButton
    )
        : base(conversationListMessagesResponseDataMessageMessageBodyButton) { }
#pragma warning restore CS8618

    public ConversationListMessagesResponseDataMessageMessageBodyButton(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListMessagesResponseDataMessageMessageBodyButton(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListMessagesResponseDataMessageMessageBodyButtonFromRaw.FromRawUnchecked"/>
    public static ConversationListMessagesResponseDataMessageMessageBodyButton FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationListMessagesResponseDataMessageMessageBodyButtonFromRaw
    : IFromRawJson<ConversationListMessagesResponseDataMessageMessageBodyButton>
{
    /// <inheritdoc/>
    public ConversationListMessagesResponseDataMessageMessageBodyButton FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListMessagesResponseDataMessageMessageBodyButton.FromRawUnchecked(rawData);
}

/// <summary>
/// Pagination metadata for list responses
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConversationListMessagesResponseDataPagination,
        ConversationListMessagesResponseDataPaginationFromRaw
    >)
)]
public sealed record class ConversationListMessagesResponseDataPagination : JsonModel
{
    /// <summary>
    /// Cursor-based pagination. Never populated — see Cursors.
    /// </summary>
    [Obsolete("deprecated")]
    public ConversationListMessagesResponseDataPaginationCursors? Cursors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConversationListMessagesResponseDataPaginationCursors>(
                "cursors"
            );
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

    public ConversationListMessagesResponseDataPagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListMessagesResponseDataPagination(
        ConversationListMessagesResponseDataPagination conversationListMessagesResponseDataPagination
    )
        : base(conversationListMessagesResponseDataPagination) { }
#pragma warning restore CS8618

    public ConversationListMessagesResponseDataPagination(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListMessagesResponseDataPagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListMessagesResponseDataPaginationFromRaw.FromRawUnchecked"/>
    public static ConversationListMessagesResponseDataPagination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationListMessagesResponseDataPaginationFromRaw
    : IFromRawJson<ConversationListMessagesResponseDataPagination>
{
    /// <inheritdoc/>
    public ConversationListMessagesResponseDataPagination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListMessagesResponseDataPagination.FromRawUnchecked(rawData);
}

/// <summary>
/// Cursor-based pagination. Never populated — see Cursors.
/// </summary>
[Obsolete("deprecated")]
[JsonConverter(
    typeof(JsonModelConverter<
        ConversationListMessagesResponseDataPaginationCursors,
        ConversationListMessagesResponseDataPaginationCursorsFromRaw
    >)
)]
public sealed record class ConversationListMessagesResponseDataPaginationCursors : JsonModel
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

    public ConversationListMessagesResponseDataPaginationCursors() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListMessagesResponseDataPaginationCursors(
        ConversationListMessagesResponseDataPaginationCursors conversationListMessagesResponseDataPaginationCursors
    )
        : base(conversationListMessagesResponseDataPaginationCursors) { }
#pragma warning restore CS8618

    public ConversationListMessagesResponseDataPaginationCursors(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListMessagesResponseDataPaginationCursors(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListMessagesResponseDataPaginationCursorsFromRaw.FromRawUnchecked"/>
    public static ConversationListMessagesResponseDataPaginationCursors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationListMessagesResponseDataPaginationCursorsFromRaw
    : IFromRawJson<ConversationListMessagesResponseDataPaginationCursors>
{
    /// <inheritdoc/>
    public ConversationListMessagesResponseDataPaginationCursors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListMessagesResponseDataPaginationCursors.FromRawUnchecked(rawData);
}

/// <summary>
/// Error information
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConversationListMessagesResponseError,
        ConversationListMessagesResponseErrorFromRaw
    >)
)]
public sealed record class ConversationListMessagesResponseError : JsonModel
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

    public ConversationListMessagesResponseError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListMessagesResponseError(
        ConversationListMessagesResponseError conversationListMessagesResponseError
    )
        : base(conversationListMessagesResponseError) { }
#pragma warning restore CS8618

    public ConversationListMessagesResponseError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListMessagesResponseError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListMessagesResponseErrorFromRaw.FromRawUnchecked"/>
    public static ConversationListMessagesResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationListMessagesResponseErrorFromRaw
    : IFromRawJson<ConversationListMessagesResponseError>
{
    /// <inheritdoc/>
    public ConversationListMessagesResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListMessagesResponseError.FromRawUnchecked(rawData);
}

/// <summary>
/// Request and response metadata
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConversationListMessagesResponseMeta,
        ConversationListMessagesResponseMetaFromRaw
    >)
)]
public sealed record class ConversationListMessagesResponseMeta : JsonModel
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

    public ConversationListMessagesResponseMeta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListMessagesResponseMeta(
        ConversationListMessagesResponseMeta conversationListMessagesResponseMeta
    )
        : base(conversationListMessagesResponseMeta) { }
#pragma warning restore CS8618

    public ConversationListMessagesResponseMeta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListMessagesResponseMeta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListMessagesResponseMetaFromRaw.FromRawUnchecked"/>
    public static ConversationListMessagesResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationListMessagesResponseMetaFromRaw
    : IFromRawJson<ConversationListMessagesResponseMeta>
{
    /// <inheritdoc/>
    public ConversationListMessagesResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListMessagesResponseMeta.FromRawUnchecked(rawData);
}
