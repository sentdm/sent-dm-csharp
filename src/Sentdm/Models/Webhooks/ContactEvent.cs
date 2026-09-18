using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// The envelope Sent POSTs to a subscribed webhook endpoint. Every event shares
/// this shape and varies only in Payload.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ContactEvent, ContactEventFromRaw>))]
public sealed record class ContactEvent : JsonModel
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
    public ContactEventPayload? Payload
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContactEventPayload>("payload");
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

    public ContactEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactEvent(ContactEvent contactEvent)
        : base(contactEvent) { }
#pragma warning restore CS8618

    public ContactEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactEventFromRaw.FromRawUnchecked"/>
    public static ContactEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactEventFromRaw : IFromRawJson<ContactEvent>
{
    /// <inheritdoc/>
    public ContactEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContactEvent.FromRawUnchecked(rawData);
}
