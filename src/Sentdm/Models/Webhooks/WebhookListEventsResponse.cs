using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WebhookListEventsResponse, WebhookListEventsResponseFromRaw>)
)]
public sealed record class WebhookListEventsResponse : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public WebhookListEventsResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookListEventsResponseData>("data");
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

    public WebhookListEventsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookListEventsResponse(WebhookListEventsResponse webhookListEventsResponse)
        : base(webhookListEventsResponse) { }
#pragma warning restore CS8618

    public WebhookListEventsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListEventsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookListEventsResponseFromRaw.FromRawUnchecked"/>
    public static WebhookListEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookListEventsResponseFromRaw : IFromRawJson<WebhookListEventsResponse>
{
    /// <inheritdoc/>
    public WebhookListEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookListEventsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The response data (null if error)
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WebhookListEventsResponseData, WebhookListEventsResponseDataFromRaw>)
)]
public sealed record class WebhookListEventsResponseData : JsonModel
{
    public IReadOnlyList<Event>? Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Event>>("events");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Event>?>(
                "events",
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
        foreach (var item in this.Events ?? [])
        {
            item.Validate();
        }
        this.Pagination?.Validate();
    }

    public WebhookListEventsResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookListEventsResponseData(
        WebhookListEventsResponseData webhookListEventsResponseData
    )
        : base(webhookListEventsResponseData) { }
#pragma warning restore CS8618

    public WebhookListEventsResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListEventsResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookListEventsResponseDataFromRaw.FromRawUnchecked"/>
    public static WebhookListEventsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookListEventsResponseDataFromRaw : IFromRawJson<WebhookListEventsResponseData>
{
    /// <inheritdoc/>
    public WebhookListEventsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookListEventsResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Event, EventFromRaw>))]
public sealed record class Event : JsonModel
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

    public int? DeliveryAttempts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("delivery_attempts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("delivery_attempts", value);
        }
    }

    public string? DeliveryStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("delivery_status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("delivery_status", value);
        }
    }

    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init { this._rawData.Set("error_message", value); }
    }

    /// <summary>
    /// The exact event body that was delivered, or attempted, for this record. One
    /// of the three webhook envelopes: a message status change, an inbound message,
    /// or a template status change. Read field and event to tell which, the same
    /// way your endpoint does.
    /// </summary>
    public EventData? EventData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EventData>("event_data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("event_data", value);
        }
    }

    public string? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("event_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("event_type", value);
        }
    }

    public int? HttpStatusCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("http_status_code");
        }
        init { this._rawData.Set("http_status_code", value); }
    }

    public DateTimeOffset? ProcessingCompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("processing_completed_at");
        }
        init { this._rawData.Set("processing_completed_at", value); }
    }

    public DateTimeOffset? ProcessingStartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("processing_started_at");
        }
        init { this._rawData.Set("processing_started_at", value); }
    }

    public string? ResponseBody
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("response_body");
        }
        init { this._rawData.Set("response_body", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DeliveryAttempts;
        _ = this.DeliveryStatus;
        _ = this.ErrorMessage;
        this.EventData?.Validate();
        _ = this.EventType;
        _ = this.HttpStatusCode;
        _ = this.ProcessingCompletedAt;
        _ = this.ProcessingStartedAt;
        _ = this.ResponseBody;
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
/// The exact event body that was delivered, or attempted, for this record. One of
/// the three webhook envelopes: a message status change, an inbound message, or
/// a template status change. Read field and event to tell which, the same way your
/// endpoint does.
/// </summary>
[JsonConverter(typeof(EventDataConverter))]
public record class EventData : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Event
    {
        get
        {
            return Match<string?>(
                messageEvent: (x) => x.Event,
                inboundMessageEvent: (x) => x.Event,
                templateEvent: (x) => x.Event
            );
        }
    }

    public string? Field
    {
        get
        {
            return Match<string?>(
                messageEvent: (x) => x.Field,
                inboundMessageEvent: (x) => x.Field,
                templateEvent: (x) => x.Field
            );
        }
    }

    public string? Timestamp
    {
        get
        {
            return Match<string?>(
                messageEvent: (x) => x.Timestamp,
                inboundMessageEvent: (x) => x.Timestamp,
                templateEvent: (x) => x.Timestamp
            );
        }
    }

    public EventData(MessageEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EventData(InboundMessageEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EventData(TemplateEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EventData(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MessageEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMessageEvent(out var value)) {
    ///     // `value` is of type `MessageEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMessageEvent([NotNullWhen(true)] out MessageEvent? value)
    {
        value = this.Value as MessageEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InboundMessageEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickInboundMessageEvent(out var value)) {
    ///     // `value` is of type `InboundMessageEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickInboundMessageEvent([NotNullWhen(true)] out InboundMessageEvent? value)
    {
        value = this.Value as InboundMessageEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TemplateEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTemplateEvent(out var value)) {
    ///     // `value` is of type `TemplateEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTemplateEvent([NotNullWhen(true)] out TemplateEvent? value)
    {
        value = this.Value as TemplateEvent;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="SentInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (MessageEvent value) =&gt; {...},
    ///     (InboundMessageEvent value) =&gt; {...},
    ///     (TemplateEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<MessageEvent> messageEvent,
        Action<InboundMessageEvent> inboundMessageEvent,
        Action<TemplateEvent> templateEvent
    )
    {
        switch (this.Value)
        {
            case MessageEvent value:
                messageEvent(value);
                break;
            case InboundMessageEvent value:
                inboundMessageEvent(value);
                break;
            case TemplateEvent value:
                templateEvent(value);
                break;
            default:
                throw new SentInvalidDataException("Data did not match any variant of EventData");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="SentInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (MessageEvent value) =&gt; {...},
    ///     (InboundMessageEvent value) =&gt; {...},
    ///     (TemplateEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<MessageEvent, T> messageEvent,
        Func<InboundMessageEvent, T> inboundMessageEvent,
        Func<TemplateEvent, T> templateEvent
    )
    {
        return this.Value switch
        {
            MessageEvent value => messageEvent(value),
            InboundMessageEvent value => inboundMessageEvent(value),
            TemplateEvent value => templateEvent(value),
            _ => throw new SentInvalidDataException("Data did not match any variant of EventData"),
        };
    }

    public static implicit operator EventData(MessageEvent value) => new(value);

    public static implicit operator EventData(InboundMessageEvent value) => new(value);

    public static implicit operator EventData(TemplateEvent value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="SentInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new SentInvalidDataException("Data did not match any variant of EventData");
        }
        this.Switch(
            (messageEvent) => messageEvent.Validate(),
            (inboundMessageEvent) => inboundMessageEvent.Validate(),
            (templateEvent) => templateEvent.Validate()
        );
    }

    public virtual bool Equals(EventData? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            MessageEvent _ => 0,
            InboundMessageEvent _ => 1,
            TemplateEvent _ => 2,
            _ => -1,
        };
    }
}

sealed class EventDataConverter : JsonConverter<EventData>
{
    public override EventData? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<MessageEvent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is SentInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<InboundMessageEvent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is SentInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<TemplateEvent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is SentInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventData value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
