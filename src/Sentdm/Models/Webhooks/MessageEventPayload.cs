using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Body of an outbound message lifecycle event. Delivered once per status change,
/// so a single message produces several of these as it moves toward a terminal status.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageEventPayload, MessageEventPayloadFromRaw>))]
public sealed record class MessageEventPayload : JsonModel
{
    /// <summary>
    /// The status the message just reached, for example SENT, DELIVERED, or FAILED.
    /// Sent means dispatched and delivered means confirmed, so treat them as distinct outcomes.
    /// </summary>
    public required string MessageStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message_status");
        }
        init { this._rawData.Set("message_status", value); }
    }

    /// <summary>
    /// The account the message belongs to.
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
    /// The agent attributed to the send, when the send was attributed to one.
    /// </summary>
    public string? AgentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("agent_id");
        }
        init { this._rawData.Set("agent_id", value); }
    }

    /// <summary>
    /// The rendered message body, as plain text. Sent as null when we aren't asserting
    /// a body for this event. The field is always present, so read it and check for
    /// null rather than checking whether the key exists. Truncated to 3072 characters.
    /// </summary>
    public string? Body
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("body");
        }
        init { this._rawData.Set("body", value); }
    }

    /// <summary>
    /// The channel the message went out on, for example sms or whatsapp. A message
    /// that falls back to another channel reports the channel actually used.
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
    /// The message this event describes. Stable across every event in the message's
    /// lifecycle, so use it to correlate them.
    /// </summary>
    public string? MessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message_id", value);
        }
    }

    /// <summary>
    /// The recipient's number in E.164 format.
    /// </summary>
    public string? OutboundNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("outbound_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("outbound_number", value);
        }
    }

    /// <summary>
    /// message.scheduled only: why the message is held, either because you scheduled
    /// it or because the recipient is inside a protected quiet-hours window. Omitted
    /// on every other event.
    /// </summary>
    public string? ScheduleReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("schedule_reason");
        }
        init { this._rawData.Set("schedule_reason", value); }
    }

    /// <summary>
    /// message.scheduled only: when the held message will be released for delivery,
    /// in UTC (yyyy-MM-ddTHH:mm:ssZ). Omitted on every other event.
    /// </summary>
    public string? ScheduledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("scheduled_at");
        }
        init { this._rawData.Set("scheduled_at", value); }
    }

    /// <summary>
    /// The template the message was sent from, when it was sent from one.
    /// </summary>
    public string? TemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template_id");
        }
        init { this._rawData.Set("template_id", value); }
    }

    /// <summary>
    /// Name of the template the message was sent from. Omitted when the message wasn't template-based.
    /// </summary>
    public string? TemplateName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template_name");
        }
        init { this._rawData.Set("template_name", value); }
    }

    /// <summary>
    /// When the message reached MessageStatus, in UTC (yyyy-MM-ddTHH:mm:ssZ).
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
        _ = this.MessageStatus;
        _ = this.AccountID;
        _ = this.AgentID;
        _ = this.Body;
        _ = this.Channel;
        _ = this.MessageID;
        _ = this.OutboundNumber;
        _ = this.ScheduleReason;
        _ = this.ScheduledAt;
        _ = this.TemplateID;
        _ = this.TemplateName;
        _ = this.UpdatedAt;
    }

    public MessageEventPayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageEventPayload(MessageEventPayload messageEventPayload)
        : base(messageEventPayload) { }
#pragma warning restore CS8618

    public MessageEventPayload(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageEventPayload(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageEventPayloadFromRaw.FromRawUnchecked"/>
    public static MessageEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MessageEventPayload(string messageStatus)
        : this()
    {
        this.MessageStatus = messageStatus;
    }
}

class MessageEventPayloadFromRaw : IFromRawJson<MessageEventPayload>
{
    /// <inheritdoc/>
    public MessageEventPayload FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageEventPayload.FromRawUnchecked(rawData);
}
