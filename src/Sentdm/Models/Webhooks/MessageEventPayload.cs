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
    /// The status the message just reached, for example SENT, DELIVERED, or FAILED.
    /// Sent means dispatched and delivered means confirmed, so treat them as distinct outcomes.
    /// </summary>
    public string? MessageStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message_status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message_status", value);
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
        _ = this.AccountID;
        _ = this.AgentID;
        _ = this.Channel;
        _ = this.MessageID;
        _ = this.MessageStatus;
        _ = this.OutboundNumber;
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
}

class MessageEventPayloadFromRaw : IFromRawJson<MessageEventPayload>
{
    /// <inheritdoc/>
    public MessageEventPayload FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageEventPayload.FromRawUnchecked(rawData);
}
