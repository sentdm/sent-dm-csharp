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
    /// of the four webhook envelopes: a message status change, an inbound message,
    /// a template status change, or a contact consent signal. Read field and event
    /// to tell which, the same way your endpoint does.
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
/// the four webhook envelopes: a message status change, an inbound message, a template
/// status change, or a contact consent signal. Read field and event to tell which,
/// the same way your endpoint does.
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
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload: (
                    x
                ) => x.Event,
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload: (
                    x
                ) => x.Event
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
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload: (
                    x
                ) => x.Field,
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload: (
                    x
                ) => x.Field
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
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload: (
                    x
                ) => x.RequestID,
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload: (
                    x
                ) => x.RequestID
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
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload: (
                    x
                ) => x.Timestamp,
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload: (
                    x
                ) => x.Timestamp
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

    public EventData(
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EventData(
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload value,
        JsonElement? element = null
    )
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
    /// type <see cref="SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload(out var value)) {
    ///     // `value` is of type `SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload(
        [NotNullWhen(true)]
            out SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload? value
    )
    {
        value =
            this.Value
            as SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload(out var value)) {
    ///     // `value` is of type `SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload(
        [NotNullWhen(true)]
            out SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload? value
    )
    {
        value =
            this.Value
            as SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload;
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
    ///     (SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload value) =&gt; {...},
    ///     (SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<MessageEvent> messageEvent,
        Action<InboundMessageEvent> inboundMessageEvent,
        Action<TemplateEvent> templateEvent,
        Action<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload> sentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload,
        Action<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload> sentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
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
            case SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload value:
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload(
                    value
                );
                break;
            case SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload value:
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload(
                    value
                );
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
    ///     (SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload value) =&gt; {...},
    ///     (SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<MessageEvent, T> messageEvent,
        Func<InboundMessageEvent, T> inboundMessageEvent,
        Func<TemplateEvent, T> templateEvent,
        Func<
            SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload,
            T
        > sentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload,
        Func<
            SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload,
            T
        > sentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
    )
    {
        return this.Value switch
        {
            MessageEvent value => messageEvent(value),
            InboundMessageEvent value => inboundMessageEvent(value),
            TemplateEvent value => templateEvent(value),
            SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload value =>
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload(
                    value
                ),
            SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload value =>
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload(
                    value
                ),
            _ => throw new SentInvalidDataException("Data did not match any variant of EventData"),
        };
    }

    public static implicit operator EventData(MessageEvent value) => new(value);

    public static implicit operator EventData(InboundMessageEvent value) => new(value);

    public static implicit operator EventData(TemplateEvent value) => new(value);

    public static implicit operator EventData(
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload value
    ) => new(value);

    public static implicit operator EventData(
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload value
    ) => new(value);

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
            (sentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload) =>
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload.Validate(),
            (sentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload) =>
                sentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload.Validate()
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
            SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload _ => 3,
            SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload _ => 4,
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
            var deserialized =
                JsonSerializer.Deserialize<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload>(
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
            var deserialized =
                JsonSerializer.Deserialize<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload>(
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
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload,
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayloadFromRaw
    >)
)]
public sealed record class SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload
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
    /// Body of a channel event: where one of the customer's channels stands in provisioning
    /// and compliance. Delivered when a milestone moves — a registration filed, a
    /// verdict returned, a resubmission asked for, a sender gone live — so a customer's
    /// own onboarding UI does not have to poll GET /v3/channels.              The
    /// subject is one item, never the account. A customer's "SMS channel" has no
    /// status; a market does. Country, NumberType and SenderValue name which one,
    /// so a customer terminating only to Kosovo never receives an event about US
    /// 10DLC.              Status is the stable half of the contract. It is the
    /// same four-value set GET /v3/channels publishes, computed through the same
    /// code, so an event and a read of the same market cannot disagree. A subscriber
    /// that reads nothing but the status and the subject fields is a correct subscriber.
    /// The sub-type on the envelope names the specific milestone and is additive
    /// — that vocabulary comes from registries and carriers, which are parties Sent
    /// does not control.              Status means provisioning and compliance are
    /// complete, not that a send will succeed right now. An account can be suspended,
    /// or a destination blocked by a routing rule, without either showing up here.
    /// Those are separate surfaces and deliberately not modelled on this payload.
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

    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload(
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload sentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload
    )
        : base(sentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload) { }
#pragma warning restore CS8618

    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayloadFromRaw.FromRawUnchecked"/>
    public static SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayloadFromRaw
    : IFromRawJson<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload>
{
    /// <inheritdoc/>
    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Body of a channel event: where one of the customer's channels stands in provisioning
/// and compliance. Delivered when a milestone moves — a registration filed, a verdict
/// returned, a resubmission asked for, a sender gone live — so a customer's own onboarding
/// UI does not have to poll GET /v3/channels.              The subject is one item,
/// never the account. A customer's "SMS channel" has no status; a market does. Country,
/// NumberType and SenderValue name which one, so a customer terminating only to Kosovo
/// never receives an event about US 10DLC.              Status is the stable half
/// of the contract. It is the same four-value set GET /v3/channels publishes, computed
/// through the same code, so an event and a read of the same market cannot disagree.
/// A subscriber that reads nothing but the status and the subject fields is a correct
/// subscriber. The sub-type on the envelope names the specific milestone and is
/// additive — that vocabulary comes from registries and carriers, which are parties
/// Sent does not control.              Status means provisioning and compliance are
/// complete, not that a send will succeed right now. An account can be suspended,
/// or a destination blocked by a routing rule, without either showing up here. Those
/// are separate surfaces and deliberately not modelled on this payload.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Payload, PayloadFromRaw>))]
public sealed record class Payload : JsonModel
{
    /// <summary>
    /// The market's destination country as an ISO 3166-1 alpha-2 code, for example
    /// XK. Always present, and the property that identifies this payload among the
    /// delivered envelopes — see DeliveredWebhookEvents. Every event in this family
    /// reports one market, and a market has a country.
    /// </summary>
    public required string Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// The account whose market this is, named as on every other family. When an
    /// organization receives an event for one of its sender profiles this is the
    /// profile, so a reseller compares it with its own id and anything different
    /// is one of its profiles.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_id", value);
        }
    }

    /// <summary>
    /// The channel this market belongs to: sms, whatsapp, or rcs. Never sent — that
    /// value belongs to message events, where it names the smart-routing brand rather
    /// than a channel that can be provisioned.
    /// </summary>
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

    /// <summary>
    /// The kind of sender the market uses, for example TEN_DLC, LOCAL, or ALPHANUMERIC.
    /// Omitted when the subject has no sender type of its own.
    /// </summary>
    public string? NumberType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("number_type");
        }
        init { this._rawData.Set("number_type", value); }
    }

    /// <summary>
    /// Why the market reached this state, when a reason was given — a correction
    /// explained, or a campaign lapse. Free text, passed through from the registry
    /// or carrier that wrote it, so treat it as a message to show a human rather
    /// than a value to branch on.
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
    /// The sender itself — a number in E.164, or an alphanumeric sender ID.
    ///         Always present, and null until a sender exists. The key is on every
    /// delivery so a subscriber reads one shape rather than branching on whether
    /// the field arrived — the same choice template_id makes on the message payload.
    ///              It can carry a value at any point in the lifecycle, not only
    /// once the market is live: a number ordered and not yet active at the carrier
    /// is already known during PROVISIONING, and an alphanumeric sender the customer
    /// chose themselves is known before anything is filed. It is null while the market
    /// is still waiting on a number, which for a US 10DLC registration is every
    /// event up to channel.activated.
    /// </summary>
    public string? SenderValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sender_value");
        }
        init { this._rawData.Set("sender_value", value); }
    }

    /// <summary>
    /// Where the market stands: PENDING_REVIEW, ACTION_NEEDED, PROVISIONING, ACTIVE
    /// or INACTIVE. PENDING_REVIEW means a registry or a carrier holds it and the
    /// wait is theirs; ACTION_NEEDED means it is yours; PROVISIONING means the verdict
    /// is in and Sent is acquiring the sender; INACTIVE means it had a working sender
    /// and no longer does.              Each event name is the transition into one
    /// of these, but the two are separate fields and may legitimately differ. A resubmission
    /// filed against a market whose sender is already live is channel.submitted carrying
    /// ACTIVE: a correction is with the registry and the sender keeps working. Read both.
    /// </summary>
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

    /// <summary>
    /// When the transition happened, in UTC (yyyy-MM-ddTHH:mm:ssZ).
    /// </summary>
    public string? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.AccountID;
        _ = this.Channel;
        _ = this.NumberType;
        _ = this.Reason;
        _ = this.SenderValue;
        _ = this.Status;
        _ = this.UpdatedAt;
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
    public Payload(string country)
        : this()
    {
        this.Country = country;
    }
}

class PayloadFromRaw : IFromRawJson<Payload>
{
    /// <inheritdoc/>
    public Payload FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Payload.FromRawUnchecked(rawData);
}

/// <summary>
/// The envelope Sent POSTs to a subscribed webhook endpoint. Every event shares
/// this shape and varies only in Payload.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload,
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadFromRaw
    >)
)]
public sealed record class SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
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
    /// Body of a contact.opt_in, contact.opt_out or contact.help event. Delivered
    /// when a contact signals a consent change or asks for help.              These
    /// events state the signal outright, so you do not have to recognise keywords
    /// in the text of a message.received event. They also cover cases that produce
    /// no inbound message at all, such as a network handling an opt-out on your behalf.
    ///              Fields are ordered identity → resulting state → provenance →
    /// join key. Nothing here restates the envelope: which of the three signals
    /// occurred is the envelope's event, and when it was emitted is its timestamp.
    /// Retries carry the same X-Webhook-Event-ID header, which is what to deduplicate on.
    /// </summary>
    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload? Payload
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload>(
                "payload"
            );
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

    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload(
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload sentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
    )
        : base(sentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload) { }
#pragma warning restore CS8618

    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadFromRaw.FromRawUnchecked"/>
    public static SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadFromRaw
    : IFromRawJson<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload>
{
    /// <inheritdoc/>
    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Body of a contact.opt_in, contact.opt_out or contact.help event. Delivered when
/// a contact signals a consent change or asks for help.              These events
/// state the signal outright, so you do not have to recognise keywords in the text
/// of a message.received event. They also cover cases that produce no inbound message
/// at all, such as a network handling an opt-out on your behalf.              Fields
/// are ordered identity → resulting state → provenance → join key. Nothing here
/// restates the envelope: which of the three signals occurred is the envelope's
/// event, and when it was emitted is its timestamp. Retries carry the same X-Webhook-Event-ID
/// header, which is what to deduplicate on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload,
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayloadFromRaw
    >)
)]
public sealed record class SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
    : JsonModel
{
    /// <summary>
    /// Whether the contact is opted out after this signal — the state to write to
    /// your own record. Same meaning as opt_out on the contact resource. On contact.help
    /// this reports the contact's existing state, which help does not change.
    ///           Two signals from the same contact can arrive out of order, because
    /// each one is queued on its own rather than against the contact. Compare the
    /// envelope's timestamp before you overwrite a newer state with an older one.
    /// That timestamp is second-precision, so treat two signals stamped in the same
    /// second as unordered and read the contact resource to settle them.
    /// </summary>
    public required bool OptOut
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("opt_out");
        }
        init { this._rawData.Set("opt_out", value); }
    }

    /// <summary>
    /// How the signal reached us. INBOUND_KEYWORD means the contact sent a message
    /// whose text matched one of the keywords; PROVIDER_SIGNAL means the network
    /// reported it. A provider signal usually carries no message_id or text, so read
    /// both for null rather than inferring them from this field.
    /// </summary>
    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// The account the contact belongs to. Present so one endpoint can serve several accounts.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_id", value);
        }
    }

    /// <summary>
    /// The channel the signal arrived on, for example sms or whatsapp.
    /// </summary>
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

    /// <summary>
    /// The contact who raised the signal. Always populated, including for contact.help
    /// from a number you have not messaged before — the contact is created if it
    /// does not exist yet, so this identifier is always resolvable against the contacts API.
    /// </summary>
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

    /// <summary>
    /// The inbound message that carried the signal, matching message_id on the corresponding
    /// message.received event so the two can be joined.              Sent as null
    /// when the signal did not arrive as a message — for example when a network
    /// processed an opt-out on your behalf — and also when the message belongs to
    /// a different account than this event, which can happen on a shared WhatsApp
    /// number. The field is always present, so read it and check for null rather
    /// than checking whether the key exists.
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
    /// The contact's number in E.164 format. Same value as phone_number on the contact resource.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// The text the contact sent, for example STOP or UNSUBSCRIBE. Sent as null when
    /// the signal did not arrive as text. The field is always present, so read it
    /// and check for null rather than checking whether the key exists.
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OptOut;
        _ = this.Source;
        _ = this.AccountID;
        _ = this.Channel;
        _ = this.ContactID;
        _ = this.MessageID;
        _ = this.PhoneNumber;
        _ = this.Text;
    }

    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload(
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload sentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
    )
        : base(
            sentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
        ) { }
#pragma warning restore CS8618

    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayloadFromRaw.FromRawUnchecked"/>
    public static SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayloadFromRaw
    : IFromRawJson<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload>
{
    /// <inheritdoc/>
    public SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload.FromRawUnchecked(
            rawData
        );
}
