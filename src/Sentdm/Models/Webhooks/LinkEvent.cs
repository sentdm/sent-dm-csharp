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
[JsonConverter(typeof(JsonModelConverter<LinkEvent, LinkEventFromRaw>))]
public sealed record class LinkEvent : JsonModel
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
    public LinkEventPayload? Payload
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LinkEventPayload>("payload");
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

    public LinkEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkEvent(LinkEvent linkEvent)
        : base(linkEvent) { }
#pragma warning restore CS8618

    public LinkEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkEventFromRaw.FromRawUnchecked"/>
    public static LinkEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkEventFromRaw : IFromRawJson<LinkEvent>
{
    /// <inheritdoc/>
    public LinkEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LinkEvent.FromRawUnchecked(rawData);
}
