using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Messages;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<MessageRetrieveStatusResponse, MessageRetrieveStatusResponseFromRaw>)
)]
public sealed record class MessageRetrieveStatusResponse : JsonModel
{
    /// <summary>
    /// Message response for v3 API — same shape as v2 with snake_case JSON conventions.
    ///              The shape of a message that was sent immediately: it never has
    /// a scheduled_at key. A message that is or was held for a later instant is a
    /// ScheduledMessageResponse, and the endpoint decides which of the two to answer
    /// with. From always returns this type.
    /// </summary>
    public MessageRetrieveStatusResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageRetrieveStatusResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public ErrorDetail? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ErrorDetail>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public ApiMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiMeta>("meta");
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

    public MessageRetrieveStatusResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageRetrieveStatusResponse(
        MessageRetrieveStatusResponse messageRetrieveStatusResponse
    )
        : base(messageRetrieveStatusResponse) { }
#pragma warning restore CS8618

    public MessageRetrieveStatusResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRetrieveStatusResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageRetrieveStatusResponseFromRaw.FromRawUnchecked"/>
    public static MessageRetrieveStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageRetrieveStatusResponseFromRaw : IFromRawJson<MessageRetrieveStatusResponse>
{
    /// <inheritdoc/>
    public MessageRetrieveStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageRetrieveStatusResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Message response for v3 API — same shape as v2 with snake_case JSON conventions.
///              The shape of a message that was sent immediately: it never has a
/// scheduled_at key. A message that is or was held for a later instant is a ScheduledMessageResponse,
/// and the endpoint decides which of the two to answer with. From always returns
/// this type.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MessageRetrieveStatusResponseData,
        MessageRetrieveStatusResponseDataFromRaw
    >)
)]
public sealed record class MessageRetrieveStatusResponseData : JsonModel
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

    public IReadOnlyList<MessageRetrieveStatusResponseDataEvent>? Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<MessageRetrieveStatusResponseDataEvent>
            >("events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MessageRetrieveStatusResponseDataEvent>?>(
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
    public MessageRetrieveStatusResponseDataMessageBody? MessageBody
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageRetrieveStatusResponseDataMessageBody>(
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

    /// <summary>
    /// A human-readable sentence for reason_code, for example "Insufficient balance".
    /// Omitted whenever reason_code is.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Why the message is at its current status, as a stable platform code such
    /// as DELIVERY_007, BUSINESS_003 or DELIVERY_003. Present when the current status
    /// is FAILED, FILTERED or BLOCKED and the lifecycle was loaded; omitted otherwise.
    /// Switch on this rather than on reason: the code is stable, the wording may
    /// be improved. It is the platform's classification of the outcome, never a
    /// carrier or vendor code.
    /// </summary>
    public string? ReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason_code");
        }
        init { this._rawData.Set("reason_code", value); }
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
        _ = this.Reason;
        _ = this.ReasonCode;
        _ = this.RegionCode;
        _ = this.Status;
        _ = this.TemplateCategory;
        _ = this.TemplateID;
        _ = this.TemplateName;
    }

    public MessageRetrieveStatusResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageRetrieveStatusResponseData(
        MessageRetrieveStatusResponseData messageRetrieveStatusResponseData
    )
        : base(messageRetrieveStatusResponseData) { }
#pragma warning restore CS8618

    public MessageRetrieveStatusResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRetrieveStatusResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageRetrieveStatusResponseDataFromRaw.FromRawUnchecked"/>
    public static MessageRetrieveStatusResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageRetrieveStatusResponseDataFromRaw : IFromRawJson<MessageRetrieveStatusResponseData>
{
    /// <inheritdoc/>
    public MessageRetrieveStatusResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageRetrieveStatusResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Represents a status change event in a message's lifecycle (v3)
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MessageRetrieveStatusResponseDataEvent,
        MessageRetrieveStatusResponseDataEventFromRaw
    >)
)]
public sealed record class MessageRetrieveStatusResponseDataEvent : JsonModel
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

    /// <summary>
    /// A human-readable sentence for reason_code. Omitted whenever reason_code is.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Why the message reached this status, as a stable platform code such as DELIVERY_007.
    /// Present on FAILED, FILTERED and BLOCKED events; omitted on every status that
    /// needs no explanation. Same wire name and vocabulary as on the activities
    /// list and the webhook.
    /// </summary>
    public string? ReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason_code");
        }
        init { this._rawData.Set("reason_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Status;
        _ = this.Timestamp;
        _ = this.Description;
        _ = this.Reason;
        _ = this.ReasonCode;
    }

    public MessageRetrieveStatusResponseDataEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageRetrieveStatusResponseDataEvent(
        MessageRetrieveStatusResponseDataEvent messageRetrieveStatusResponseDataEvent
    )
        : base(messageRetrieveStatusResponseDataEvent) { }
#pragma warning restore CS8618

    public MessageRetrieveStatusResponseDataEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRetrieveStatusResponseDataEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageRetrieveStatusResponseDataEventFromRaw.FromRawUnchecked"/>
    public static MessageRetrieveStatusResponseDataEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageRetrieveStatusResponseDataEventFromRaw
    : IFromRawJson<MessageRetrieveStatusResponseDataEvent>
{
    /// <inheritdoc/>
    public MessageRetrieveStatusResponseDataEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageRetrieveStatusResponseDataEvent.FromRawUnchecked(rawData);
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
[JsonConverter(
    typeof(JsonModelConverter<
        MessageRetrieveStatusResponseDataMessageBody,
        MessageRetrieveStatusResponseDataMessageBodyFromRaw
    >)
)]
public sealed record class MessageRetrieveStatusResponseDataMessageBody : JsonModel
{
    public IReadOnlyList<MessageRetrieveStatusResponseDataMessageBodyButton>? Buttons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<MessageRetrieveStatusResponseDataMessageBodyButton>
            >("buttons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MessageRetrieveStatusResponseDataMessageBodyButton>?>(
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
    public MessageRetrieveStatusResponseDataMessageBodyHeaderMedia? HeaderMedia
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageRetrieveStatusResponseDataMessageBodyHeaderMedia>(
                "headerMedia"
            );
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
    public IReadOnlyList<MessageRetrieveStatusResponseDataMessageBodyMedia>? Media
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<MessageRetrieveStatusResponseDataMessageBodyMedia>
            >("media");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MessageRetrieveStatusResponseDataMessageBodyMedia>?>(
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

    public MessageRetrieveStatusResponseDataMessageBody() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageRetrieveStatusResponseDataMessageBody(
        MessageRetrieveStatusResponseDataMessageBody messageRetrieveStatusResponseDataMessageBody
    )
        : base(messageRetrieveStatusResponseDataMessageBody) { }
#pragma warning restore CS8618

    public MessageRetrieveStatusResponseDataMessageBody(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRetrieveStatusResponseDataMessageBody(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageRetrieveStatusResponseDataMessageBodyFromRaw.FromRawUnchecked"/>
    public static MessageRetrieveStatusResponseDataMessageBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageRetrieveStatusResponseDataMessageBodyFromRaw
    : IFromRawJson<MessageRetrieveStatusResponseDataMessageBody>
{
    /// <inheritdoc/>
    public MessageRetrieveStatusResponseDataMessageBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageRetrieveStatusResponseDataMessageBody.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        MessageRetrieveStatusResponseDataMessageBodyButton,
        MessageRetrieveStatusResponseDataMessageBodyButtonFromRaw
    >)
)]
public sealed record class MessageRetrieveStatusResponseDataMessageBodyButton : JsonModel
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

    public MessageRetrieveStatusResponseDataMessageBodyButton() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageRetrieveStatusResponseDataMessageBodyButton(
        MessageRetrieveStatusResponseDataMessageBodyButton messageRetrieveStatusResponseDataMessageBodyButton
    )
        : base(messageRetrieveStatusResponseDataMessageBodyButton) { }
#pragma warning restore CS8618

    public MessageRetrieveStatusResponseDataMessageBodyButton(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRetrieveStatusResponseDataMessageBodyButton(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageRetrieveStatusResponseDataMessageBodyButtonFromRaw.FromRawUnchecked"/>
    public static MessageRetrieveStatusResponseDataMessageBodyButton FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageRetrieveStatusResponseDataMessageBodyButtonFromRaw
    : IFromRawJson<MessageRetrieveStatusResponseDataMessageBodyButton>
{
    /// <inheritdoc/>
    public MessageRetrieveStatusResponseDataMessageBodyButton FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageRetrieveStatusResponseDataMessageBodyButton.FromRawUnchecked(rawData);
}

/// <summary>
/// The media asset that rode a message's header, recorded as sent.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MessageRetrieveStatusResponseDataMessageBodyHeaderMedia,
        MessageRetrieveStatusResponseDataMessageBodyHeaderMediaFromRaw
    >)
)]
public sealed record class MessageRetrieveStatusResponseDataMessageBodyHeaderMedia : JsonModel
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

    public MessageRetrieveStatusResponseDataMessageBodyHeaderMedia() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageRetrieveStatusResponseDataMessageBodyHeaderMedia(
        MessageRetrieveStatusResponseDataMessageBodyHeaderMedia messageRetrieveStatusResponseDataMessageBodyHeaderMedia
    )
        : base(messageRetrieveStatusResponseDataMessageBodyHeaderMedia) { }
#pragma warning restore CS8618

    public MessageRetrieveStatusResponseDataMessageBodyHeaderMedia(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRetrieveStatusResponseDataMessageBodyHeaderMedia(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageRetrieveStatusResponseDataMessageBodyHeaderMediaFromRaw.FromRawUnchecked"/>
    public static MessageRetrieveStatusResponseDataMessageBodyHeaderMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageRetrieveStatusResponseDataMessageBodyHeaderMediaFromRaw
    : IFromRawJson<MessageRetrieveStatusResponseDataMessageBodyHeaderMedia>
{
    /// <inheritdoc/>
    public MessageRetrieveStatusResponseDataMessageBodyHeaderMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageRetrieveStatusResponseDataMessageBodyHeaderMedia.FromRawUnchecked(rawData);
}

/// <summary>
/// One attachment on a message, in either direction — and in both, a URL somebody
/// else hosts.              Outbound: the customer supplied a public URL and we
/// handed it to the carrier. Inbound: the carrier hosts the file and we record where.
/// sent.dm never holds the bytes, so there is no key, no expiry bookkeeping and nothing
/// minted per read — what is stored is what is served.              An inbound link
/// expires on the carrier's own schedule and is unauthenticated. That is the customer's
/// to manage, and it is documented where they will see it rather than only here
/// — a recipient who needs an attachment to outlive that window copies it on receipt.
///              Storing a presigned URL is the specific mistake this shape still
/// avoids: M260826130000 and M260826140000 exist because RCS assets were stored
/// as signed URLs and went stale. Nothing here is signed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MessageRetrieveStatusResponseDataMessageBodyMedia,
        MessageRetrieveStatusResponseDataMessageBodyMediaFromRaw
    >)
)]
public sealed record class MessageRetrieveStatusResponseDataMessageBodyMedia : JsonModel
{
    /// <summary>
    /// One of MmsMediaTypes when the content type is known. Advisory — a reader should
    ///             trust the fetched object's own Content-Type.
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
    /// Content type as the provider declared it. Null when it declared none.
    /// </summary>
    public string? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mimeType");
        }
        init { this._rawData.Set("mimeType", value); }
    }

    /// <summary>
    /// Size as the provider declared it. Never measured here — nothing downloads
    /// the file.
    /// </summary>
    public long? SizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sizeBytes");
        }
        init { this._rawData.Set("sizeBytes", value); }
    }

    /// <summary>
    /// Inbound only: the SHA-256 the provider declared alongside the attachment,
    /// when it declared one. Relayed to the customer so they can verify what they
    /// fetch matches what the carrier said it sent. It is the only integrity signal
    /// available on an attachment nobody here has read.
    /// </summary>
    public string? SourceHashSha256
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sourceHashSha256");
        }
        init { this._rawData.Set("sourceHashSha256", value); }
    }

    /// <summary>
    /// Where the file lives. Outbound: the URL the customer gave us and the carrier
    /// fetched. Inbound: the URL the carrier hosts it at, relayed unchanged.
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MediaType;
        _ = this.MimeType;
        _ = this.SizeBytes;
        _ = this.SourceHashSha256;
        _ = this.Url;
    }

    public MessageRetrieveStatusResponseDataMessageBodyMedia() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageRetrieveStatusResponseDataMessageBodyMedia(
        MessageRetrieveStatusResponseDataMessageBodyMedia messageRetrieveStatusResponseDataMessageBodyMedia
    )
        : base(messageRetrieveStatusResponseDataMessageBodyMedia) { }
#pragma warning restore CS8618

    public MessageRetrieveStatusResponseDataMessageBodyMedia(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRetrieveStatusResponseDataMessageBodyMedia(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageRetrieveStatusResponseDataMessageBodyMediaFromRaw.FromRawUnchecked"/>
    public static MessageRetrieveStatusResponseDataMessageBodyMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageRetrieveStatusResponseDataMessageBodyMediaFromRaw
    : IFromRawJson<MessageRetrieveStatusResponseDataMessageBodyMedia>
{
    /// <inheritdoc/>
    public MessageRetrieveStatusResponseDataMessageBodyMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageRetrieveStatusResponseDataMessageBodyMedia.FromRawUnchecked(rawData);
}
