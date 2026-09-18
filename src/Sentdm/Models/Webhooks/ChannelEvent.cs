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
[JsonConverter(typeof(JsonModelConverter<ChannelEvent, ChannelEventFromRaw>))]
public sealed record class ChannelEvent : JsonModel
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
    public ChannelEventPayload? Payload
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChannelEventPayload>("payload");
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

    public ChannelEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelEvent(ChannelEvent channelEvent)
        : base(channelEvent) { }
#pragma warning restore CS8618

    public ChannelEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelEventFromRaw.FromRawUnchecked"/>
    public static ChannelEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelEventFromRaw : IFromRawJson<ChannelEvent>
{
    /// <inheritdoc/>
    public ChannelEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelEvent.FromRawUnchecked(rawData);
}
