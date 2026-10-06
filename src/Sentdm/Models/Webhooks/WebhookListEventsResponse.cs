using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;

namespace Sentdm.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<WebhookListEventsResponse, WebhookListEventsResponseFromRaw>)
)]
public sealed record class WebhookListEventsResponse : JsonModel
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
    /// of the six webhook envelopes:              message — an outbound message changed
    /// status. message with event: message.received — someone replied to you. templates
    /// — a template was approved, rejected, paused or similar. channel — one of
    /// your markets moved in provisioning or compliance. contact — a consent signal:
    /// opt-in, opt-out or help. link — a tracked short link was clicked or a hosted
    /// file downloaded, or one   expired or was revoked.              Read field
    /// and event to tell which, the same way your endpoint does. The two message
    /// envelopes are the reason that is two fields and not one: they share a field
    /// and differ by event.              Treat the list as open. It has grown twice
    /// — channel and then link — and a handler that rejects an envelope it does
    /// not recognise will break on the next addition rather than ignore it.
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
/// The exact event body that was delivered, or attempted, for this record. One of
/// the six webhook envelopes:              message — an outbound message changed
/// status. message with event: message.received — someone replied to you. templates
/// — a template was approved, rejected, paused or similar. channel — one of your
/// markets moved in provisioning or compliance. contact — a consent signal: opt-in,
/// opt-out or help. link — a tracked short link was clicked or a hosted file downloaded,
/// or one   expired or was revoked.              Read field and event to tell which,
/// the same way your endpoint does. The two message envelopes are the reason that
/// is two fields and not one: they share a field and differ by event.
///    Treat the list as open. It has grown twice — channel and then link — and a
/// handler that rejects an envelope it does not recognise will break on the next
/// addition rather than ignore it.
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
                templateEvent: (x) => x.Event,
                channelEvent: (x) => x.Event,
                contactEvent: (x) => x.Event,
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload: (
                    x
                ) => x.Event,
                callEvent: (x) => x.Event
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
                templateEvent: (x) => x.Field,
                channelEvent: (x) => x.Field,
                contactEvent: (x) => x.Field,
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload: (
                    x
                ) => x.Field,
                callEvent: (x) => x.Field
            );
        }
    }

    public string? RequestID
    {
        get
        {
            return Match<string?>(
                messageEvent: (x) => x.RequestID,
                inboundMessageEvent: (x) => x.RequestID,
                templateEvent: (x) => x.RequestID,
                channelEvent: (x) => x.RequestID,
                contactEvent: (x) => x.RequestID,
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload: (
                    x
                ) => x.RequestID,
                callEvent: (x) => x.RequestID
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
                templateEvent: (x) => x.Timestamp,
                channelEvent: (x) => x.Timestamp,
                contactEvent: (x) => x.Timestamp,
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload: (
                    x
                ) => x.Timestamp,
                callEvent: (x) => x.Timestamp
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

    public EventData(ChannelEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EventData(ContactEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EventData(
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EventData(CallEvent value, JsonElement? element = null)
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
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ChannelEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChannelEvent(out var value)) {
    ///     // `value` is of type `ChannelEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChannelEvent([NotNullWhen(true)] out ChannelEvent? value)
    {
        value = this.Value as ChannelEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ContactEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickContactEvent(out var value)) {
    ///     // `value` is of type `ContactEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContactEvent([NotNullWhen(true)] out ContactEvent? value)
    {
        value = this.Value as ContactEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload(out var value)) {
    ///     // `value` is of type `SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload(
        [NotNullWhen(true)]
            out SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload? value
    )
    {
        value =
            this.Value
            as SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CallEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCallEvent(out var value)) {
    ///     // `value` is of type `CallEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCallEvent([NotNullWhen(true)] out CallEvent? value)
    {
        value = this.Value as CallEvent;
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
    ///     (TemplateEvent value) =&gt; {...},
    ///     (ChannelEvent value) =&gt; {...},
    ///     (ContactEvent value) =&gt; {...},
    ///     (SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload value) =&gt; {...},
    ///     (CallEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<MessageEvent> messageEvent,
        Action<InboundMessageEvent> inboundMessageEvent,
        Action<TemplateEvent> templateEvent,
        Action<ChannelEvent> channelEvent,
        Action<ContactEvent> contactEvent,
        Action<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload> sentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload,
        Action<CallEvent> callEvent
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
            case ChannelEvent value:
                channelEvent(value);
                break;
            case ContactEvent value:
                contactEvent(value);
                break;
            case SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload value:
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload(
                    value
                );
                break;
            case CallEvent value:
                callEvent(value);
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
    ///     (TemplateEvent value) =&gt; {...},
    ///     (ChannelEvent value) =&gt; {...},
    ///     (ContactEvent value) =&gt; {...},
    ///     (SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload value) =&gt; {...},
    ///     (CallEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<MessageEvent, T> messageEvent,
        Func<InboundMessageEvent, T> inboundMessageEvent,
        Func<TemplateEvent, T> templateEvent,
        Func<ChannelEvent, T> channelEvent,
        Func<ContactEvent, T> contactEvent,
        Func<
            SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload,
            T
        > sentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload,
        Func<CallEvent, T> callEvent
    )
    {
        return this.Value switch
        {
            MessageEvent value => messageEvent(value),
            InboundMessageEvent value => inboundMessageEvent(value),
            TemplateEvent value => templateEvent(value),
            ChannelEvent value => channelEvent(value),
            ContactEvent value => contactEvent(value),
            SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload value =>
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload(
                    value
                ),
            CallEvent value => callEvent(value),
            _ => throw new SentInvalidDataException("Data did not match any variant of EventData"),
        };
    }

    public static implicit operator EventData(MessageEvent value) => new(value);

    public static implicit operator EventData(InboundMessageEvent value) => new(value);

    public static implicit operator EventData(TemplateEvent value) => new(value);

    public static implicit operator EventData(ChannelEvent value) => new(value);

    public static implicit operator EventData(ContactEvent value) => new(value);

    public static implicit operator EventData(
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload value
    ) => new(value);

    public static implicit operator EventData(CallEvent value) => new(value);

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
            (templateEvent) => templateEvent.Validate(),
            (channelEvent) => channelEvent.Validate(),
            (contactEvent) => contactEvent.Validate(),
            (sentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload) =>
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload.Validate(),
            (callEvent) => callEvent.Validate()
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
            ChannelEvent _ => 3,
            ContactEvent _ => 4,
            SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload _ => 5,
            CallEvent _ => 6,
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<ChannelEvent>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<ContactEvent>(element, options);
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
            var deserialized =
                JsonSerializer.Deserialize<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload>(
                    element,
                    options
                );
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
            var deserialized = JsonSerializer.Deserialize<CallEvent>(element, options);
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

/// <summary>
/// The envelope Sent POSTs to a subscribed webhook endpoint. Every event shares
/// this shape and varies only in Payload.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload,
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayloadFromRaw
    >)
)]
public sealed record class SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload
    : JsonModel
{
    /// <summary>
    /// The specific event within the family, for example message.delivered, message.received
    /// or contact.opt_out. Absent on events that have no subtype, so treat it as optional.
    /// </summary>
    public string? Event
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("event");
        }
        init { this._rawData.Set("event", value); }
    }

    /// <summary>
    /// The event family, for example message, templates or contact. Route on this
    /// first, then on event for the specific change.
    /// </summary>
    public string? Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("field");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("field", value);
        }
    }

    /// <summary>
    /// Body of a link event: something happened to a tracked link Sent published
    /// on the customer's behalf. A link points either at a URL the customer supplied
    /// or at a file Sent hosts for them; LinkKind says which. Delivered when an eligible
    /// request is served, or when a published link reaches the end of its life.
    ///              A click is a request, not a read receipt. link.clicked means
    /// the redirect was served; link.downloaded means bytes went out. Neither proves
    /// a person saw anything — messaging providers and link scanners fetch URLs
    /// on their own, which is what TrafficClass exists to tell apart. Filter on it
    /// before reporting a click-through rate; treat likely_human as a hint, never
    /// as delivery confirmation.              RecordId identifies the link; the X-Webhook-Event-ID
    /// header identifies the delivery. One link is hit many times, so those are the
    /// two keys a subscriber needs: group by the first, deduplicate on the second
    /// — exactly as on every other family. The payload carries no event identifier
    /// of its own, for the same reason none of the others do.              Nothing
    /// here identifies the visitor. No IP address and no visitor token crosses this
    /// boundary. Country, Device and Browser are coarse buckets derived at the edge
    /// and are absent whenever the request did not supply enough to derive them.
    /// </summary>
    public Payload? Payload
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Payload>("payload");
        }
        init { this._rawData.Set("payload", value); }
    }

    /// <summary>
    /// The event-specific body.
    /// </summary>
    public string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("request_id");
        }
        init { this._rawData.Set("request_id", value); }
    }

    /// <summary>
    /// When Sent emitted the event, in UTC (yyyy-MM-ddTHH:mm:ssZ). This is the emission
    /// time, not the time the underlying change happened. Use the timestamp inside
    /// the payload for the latter.
    /// </summary>
    public string? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("timestamp");
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
        _ = this.Event;
        _ = this.Field;
        this.Payload?.Validate();
        _ = this.RequestID;
        _ = this.Timestamp;
    }

    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload(
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload sentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload
    )
        : base(sentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload) { }
#pragma warning restore CS8618

    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayloadFromRaw.FromRawUnchecked"/>
    public static SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayloadFromRaw
    : IFromRawJson<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload>
{
    /// <inheritdoc/>
    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Body of a link event: something happened to a tracked link Sent published on
/// the customer's behalf. A link points either at a URL the customer supplied or
/// at a file Sent hosts for them; LinkKind says which. Delivered when an eligible
/// request is served, or when a published link reaches the end of its life.
///          A click is a request, not a read receipt. link.clicked means the redirect
/// was served; link.downloaded means bytes went out. Neither proves a person saw
/// anything — messaging providers and link scanners fetch URLs on their own, which
/// is what TrafficClass exists to tell apart. Filter on it before reporting a click-through
/// rate; treat likely_human as a hint, never as delivery confirmation.
///     RecordId identifies the link; the X-Webhook-Event-ID header identifies the
/// delivery. One link is hit many times, so those are the two keys a subscriber
/// needs: group by the first, deduplicate on the second — exactly as on every other
/// family. The payload carries no event identifier of its own, for the same reason
/// none of the others do.              Nothing here identifies the visitor. No IP
/// address and no visitor token crosses this boundary. Country, Device and Browser
/// are coarse buckets derived at the edge and are absent whenever the request did
/// not supply enough to derive them.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Payload, PayloadFromRaw>))]
public sealed record class Payload : JsonModel
{
    /// <summary>
    /// The link's public identifier — the eight-character code in the short URL,
    /// for example A78B2BU0. Unique across both kinds, and never reused, so it is
    /// the stable key to group one link's events by.
    /// </summary>
    public required string RecordID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("record_id");
        }
        init { this._rawData.Set("record_id", value); }
    }

    /// <summary>
    /// Where the request appeared to come from, as an ISO 3166-1 alpha-2 code. Named
    /// separately from the country on a channel event, which is a destination market
    /// the customer registered for — this one is a property of a single visitor and
    /// is absent when the edge could not resolve it.
    /// </summary>
    public string? AccessCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("access_country");
        }
        init { this._rawData.Set("access_country", value); }
    }

    /// <summary>
    /// How the request was served, when the edge recorded it. Free text describing
    /// the outcome — show it to a human rather than branching on it.
    /// </summary>
    public string? AccessOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("access_outcome");
        }
        init { this._rawData.Set("access_outcome", value); }
    }

    /// <summary>
    /// The requesting browser family, for example chrome or safari, or unknown. Derived
    /// from the user agent.
    /// </summary>
    public string? Browser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("browser");
        }
        init { this._rawData.Set("browser", value); }
    }

    /// <summary>
    /// How many bytes were served, for a file access. A ranged request reports the
    /// bytes in that range, not the size of the file, so several accesses of one
    /// file can each report a part.
    /// </summary>
    public long? BytesServed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("bytes_served");
        }
        init { this._rawData.Set("bytes_served", value); }
    }

    /// <summary>
    /// The channel the message carrying this link went out on: sms, whatsapp, or rcs.
    /// </summary>
    public string? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// The organization the link belongs to. Always the parent account, never a
    /// sender profile — read SenderProfileId for that.              This family publishes
    /// the owner as an explicit pair rather than the single account_id the other
    /// families use. The pair says which organization and which profile without
    /// the subscriber deriving either, which is the trade: one more key against
    /// not having to know that account_id silently becomes the profile when one exists.
    /// </summary>
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

    /// <summary>
    /// The requesting device class: mobile, tablet, desktop or unknown. Derived
    /// from the user agent.
    /// </summary>
    public string? Device
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("device");
        }
        init { this._rawData.Set("device", value); }
    }

    /// <summary>
    /// What the link points at: url for a destination the customer supplied, file
    /// for media Sent hosts. Always present, and implied by the event — link.clicked
    /// is always url and link.downloaded always file — but published as its own field
    /// so a subscriber can branch on the kind without parsing the event name, the
    /// same separation the channel family keeps between its event and its status.
    /// </summary>
    public string? LinkKind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("link_kind");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("link_kind", value);
        }
    }

    /// <summary>
    /// The message the link was published in.              The event can arrive before
    /// the message is readable through GET /v3/messages: a provider may fetch a
    /// link within milliseconds of the send, and nothing here waits for the message
    /// row. Retry the read rather than treating an unknown id as an error.
    /// </summary>
    public string? MessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message_id");
        }
        init { this._rawData.Set("message_id", value); }
    }

    /// <summary>
    /// When the access or lifecycle change actually happened, in UTC (yyyy-MM-ddTHH:mm:ssZ).
    /// The envelope's timestamp is when Sent emitted the event; this is when the
    /// thing occurred, and the two differ by the ingest delay.
    /// </summary>
    public string? OccurredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("occurred_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("occurred_at", value);
        }
    }

    /// <summary>
    /// The caller-supplied label tying this link back to a position in the message,
    /// for example body:0 for the first link in the body. Present when the link was
    /// created with one.
    /// </summary>
    public string? ReferenceKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_key");
        }
        init { this._rawData.Set("reference_key", value); }
    }

    /// <summary>
    /// The host of the page that linked here, when the request supplied one. The
    /// host only — never a full referring URL.
    /// </summary>
    public string? ReferrerHost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("referrer_host");
        }
        init { this._rawData.Set("referrer_host", value); }
    }

    /// <summary>
    /// The HTTP method of the request that was served, for an access event. Omitted
    /// on link.expired and link.revoked, which describe no request.
    /// </summary>
    public string? RequestMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("request_method");
        }
        init { this._rawData.Set("request_method", value); }
    }

    /// <summary>
    /// The sender profile that owns the link, or null when the organization owns
    /// it directly. Always on the wire so a handler reads one shape rather than branching
    /// on whether the key arrived.              sender_profile_id, not profile_id:
    /// the API already publishes messaging_profile_id and sending_phone_number_profile_id
    /// for provider-side profiles, which are a different thing entirely. The unqualified
    /// name would read as one of those.
    /// </summary>
    public string? SenderProfileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sender_profile_id");
        }
        init { this._rawData.Set("sender_profile_id", value); }
    }

    /// <summary>
    /// The HTTP status Sent answered the request with: 302 for a link, 200 or 206
    /// for a file. Omitted on lifecycle events.
    /// </summary>
    public int? StatusCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("status_code");
        }
        init { this._rawData.Set("status_code", value); }
    }

    /// <summary>
    /// A coarse guess at what made the request: likely_human, provider (a messaging
    /// platform prefetching the link), bot, or unknown. Derived from the user agent,
    /// so it is a hint for filtering noise rather than a fact to bill or report on.
    /// </summary>
    public string? TrafficClass
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("traffic_class");
        }
        init { this._rawData.Set("traffic_class", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecordID;
        _ = this.AccessCountry;
        _ = this.AccessOutcome;
        _ = this.Browser;
        _ = this.BytesServed;
        _ = this.Channel;
        _ = this.CustomerID;
        _ = this.Device;
        _ = this.LinkKind;
        _ = this.MessageID;
        _ = this.OccurredAt;
        _ = this.ReferenceKey;
        _ = this.ReferrerHost;
        _ = this.RequestMethod;
        _ = this.SenderProfileID;
        _ = this.StatusCode;
        _ = this.TrafficClass;
    }

    public Payload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Payload(Payload payload)
        : base(payload) { }
#pragma warning restore CS8618

    public Payload(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Payload(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayloadFromRaw.FromRawUnchecked"/>
    public static Payload FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Payload(string recordID)
        : this()
    {
        this.RecordID = recordID;
    }
}

class PayloadFromRaw : IFromRawJson<Payload>
{
    /// <inheritdoc/>
    public Payload FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Payload.FromRawUnchecked(rawData);
}
