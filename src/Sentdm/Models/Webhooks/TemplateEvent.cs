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
[JsonConverter(typeof(JsonModelConverter<TemplateEvent, TemplateEventFromRaw>))]
public sealed record class TemplateEvent : JsonModel
{
    /// <summary>
    /// The specific event within the family, for example message.delivered or message.received.
    /// Absent on events that have no subtype, so treat it as optional.
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
    /// The event family, for example message or templates. Route on this first,
    /// then on event for the specific change.
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
    /// Body of a template status event. Delivered when a template's review outcome
    /// changes, so you can react without polling.
    /// </summary>
    public TemplateEventPayload? Payload
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateEventPayload>("payload");
        }
        init { this._rawData.Set("payload", value); }
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
        _ = this.Timestamp;
    }

    public TemplateEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateEvent(TemplateEvent templateEvent)
        : base(templateEvent) { }
#pragma warning restore CS8618

    public TemplateEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateEventFromRaw.FromRawUnchecked"/>
    public static TemplateEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateEventFromRaw : IFromRawJson<TemplateEvent>
{
    /// <inheritdoc/>
    public TemplateEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateEvent.FromRawUnchecked(rawData);
}
