using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Body of a message.received event. Delivered when a contact messages one of your numbers.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<InboundMessageEventPayload, InboundMessageEventPayloadFromRaw>)
)]
public sealed record class InboundMessageEventPayload : JsonModel
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
    /// The channel the message arrived on, for example sms or whatsapp.
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
    /// The contact's number in E.164 format, meaning the number the message came from.
    /// </summary>
    public string? InboundNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inbound_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inbound_number", value);
        }
    }

    /// <summary>
    /// The inbound message.
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
    /// Your number in E.164 format, meaning the number the message was addressed to.
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
    /// When the message was received, in UTC (yyyy-MM-ddTHH:mm:ssZ).
    /// </summary>
    public string? ReceivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("received_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("received_at", value);
        }
    }

    /// <summary>
    /// The message body. Sent as null when the inbound message carried no text, for
    /// example a media-only message. The field is always present, so read it and
    /// check for null rather than checking whether the key exists.
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

    /// <summary>
    /// When the message was received, in UTC (yyyy-MM-ddTHH:mm:ssZ). Same value
    /// as ReceivedAt, kept for envelope consistency with outbound events.
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
        _ = this.Channel;
        _ = this.InboundNumber;
        _ = this.MessageID;
        _ = this.OutboundNumber;
        _ = this.ReceivedAt;
        _ = this.Text;
        _ = this.UpdatedAt;
    }

    public InboundMessageEventPayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundMessageEventPayload(InboundMessageEventPayload inboundMessageEventPayload)
        : base(inboundMessageEventPayload) { }
#pragma warning restore CS8618

    public InboundMessageEventPayload(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundMessageEventPayload(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundMessageEventPayloadFromRaw.FromRawUnchecked"/>
    public static InboundMessageEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundMessageEventPayloadFromRaw : IFromRawJson<InboundMessageEventPayload>
{
    /// <inheritdoc/>
    public InboundMessageEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundMessageEventPayload.FromRawUnchecked(rawData);
}
