using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Messages;

/// <summary>
/// Represents a status change event in a message's lifecycle (v3)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageStatusEvent, MessageStatusEventFromRaw>))]
public sealed record class MessageStatusEvent : JsonModel
{
    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// A human-readable sentence for reason_code. Omitted whenever reason_code is.
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
    /// Why the message reached this status, as a stable platform code such as DELIVERY_007.
    /// Present on FAILED, FILTERED and BLOCKED events; omitted on every status that
    /// needs no explanation. Same wire name and vocabulary as on the activities
    /// list and the webhook.
    /// </summary>
    public string? ReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason_code");
        }
        init { this._rawData.Set("reason_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Status;
        _ = this.Timestamp;
        _ = this.Description;
        _ = this.Reason;
        _ = this.ReasonCode;
    }

    public MessageStatusEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageStatusEvent(MessageStatusEvent messageStatusEvent)
        : base(messageStatusEvent) { }
#pragma warning restore CS8618

    public MessageStatusEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageStatusEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageStatusEventFromRaw.FromRawUnchecked"/>
    public static MessageStatusEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageStatusEventFromRaw : IFromRawJson<MessageStatusEvent>
{
    /// <inheritdoc/>
    public MessageStatusEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageStatusEvent.FromRawUnchecked(rawData);
}
