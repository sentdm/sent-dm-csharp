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
[JsonConverter(typeof(JsonModelConverter<CallEvent, CallEventFromRaw>))]
public sealed record class CallEvent : JsonModel
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
    /// Body of a call.initiated, call.answered, call.completed, call.failed or call.recording_ready
    /// event. Which of them occurred is the envelope's event.              Shaped
    /// like the message, inbound, template and channel payloads: account_id names
    /// the account the event is about, channel names the channel, and updated_at
    /// is when the change happened on the call, in the same yyyy-MM-ddTHH:mm:ssZ
    /// form. duration_seconds and price are added on call.completed, reason on call.failed
    /// and recording_id on call.recording_ready; each is omitted rather than sent
    /// as null when it does not apply.              Casing is snake_case because
    /// these ride the same webhook stream customers already parse message_id from;
    /// the question/answer contract is a separate surface and stays camelCase. Nothing
    /// here is provider-shaped: no provider call id, no namespaced identity.
    /// </summary>
    public CallEventPayload? Payload
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallEventPayload>("payload");
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

    public CallEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallEvent(CallEvent callEvent)
        : base(callEvent) { }
#pragma warning restore CS8618

    public CallEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallEventFromRaw.FromRawUnchecked"/>
    public static CallEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallEventFromRaw : IFromRawJson<CallEvent>
{
    /// <inheritdoc/>
    public CallEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CallEvent.FromRawUnchecked(rawData);
}
