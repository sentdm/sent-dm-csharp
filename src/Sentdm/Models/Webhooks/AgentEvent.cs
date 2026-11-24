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
[JsonConverter(typeof(JsonModelConverter<AgentEvent, AgentEventFromRaw>))]
public sealed record class AgentEvent : JsonModel
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
    /// Body of an agent.* webhook (Sent Agents). The event is the agent service's
    /// own record, forwarded without renaming: EventId is its id, so a subscriber
    /// can dedupe a redelivery.
    /// </summary>
    public AgentEventPayload? Payload
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentEventPayload>("payload");
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

    public AgentEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentEvent(AgentEvent agentEvent)
        : base(agentEvent) { }
#pragma warning restore CS8618

    public AgentEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentEventFromRaw.FromRawUnchecked"/>
    public static AgentEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentEventFromRaw : IFromRawJson<AgentEvent>
{
    /// <inheritdoc/>
    public AgentEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentEvent.FromRawUnchecked(rawData);
}
