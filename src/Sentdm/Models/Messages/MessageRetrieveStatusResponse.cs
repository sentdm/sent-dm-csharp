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
    /// The response data (null if error)
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
    /// Error details (null if successful)
    /// </summary>
    public ApiError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Metadata about the request and response
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
/// The response data (null if error)
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

    public IReadOnlyList<global::Sentdm.Models.Messages.Event>? Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::Sentdm.Models.Messages.Event>
            >("events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::Sentdm.Models.Messages.Event>?>(
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("template_category", value);
        }
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("template_name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Channel;
        _ = this.ContactID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
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
        global::Sentdm.Models.Messages.Event,
        global::Sentdm.Models.Messages.EventFromRaw
    >)
)]
public sealed record class Event : JsonModel
{
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Status;
        _ = this.Timestamp;
    }

    public Event() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Event(global::Sentdm.Models.Messages.Event event_)
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

    /// <inheritdoc cref="global::Sentdm.Models.Messages.EventFromRaw.FromRawUnchecked"/>
    public static global::Sentdm.Models.Messages.Event FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventFromRaw : IFromRawJson<global::Sentdm.Models.Messages.Event>
{
    /// <inheritdoc/>
    public global::Sentdm.Models.Messages.Event FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Sentdm.Models.Messages.Event.FromRawUnchecked(rawData);
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
