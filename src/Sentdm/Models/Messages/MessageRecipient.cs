using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Messages;

/// <summary>
/// What one recipient of a send got, as the API reports it.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageRecipient, MessageRecipientFromRaw>))]
public sealed record class MessageRecipient : JsonModel
{
    /// <summary>
    /// Resolved template body for this recipient's channel, or null when the channel
    /// is auto-detected.
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
    /// Channel this message will be sent on — sms, whatsapp — or null to auto-detect.
    /// </summary>
    public string? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// Identifier for tracking this recipient's message.
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
    /// Phone number in E.164 format.
    /// </summary>
    public string? To
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("to");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Body;
        _ = this.Channel;
        _ = this.MessageID;
        _ = this.To;
    }

    public MessageRecipient() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageRecipient(MessageRecipient messageRecipient)
        : base(messageRecipient) { }
#pragma warning restore CS8618

    public MessageRecipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageRecipientFromRaw.FromRawUnchecked"/>
    public static MessageRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageRecipientFromRaw : IFromRawJson<MessageRecipient>
{
    /// <inheritdoc/>
    public MessageRecipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageRecipient.FromRawUnchecked(rawData);
}
