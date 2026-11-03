using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Messages;

/// <summary>
/// The result of a multi-recipient send.              Declared here rather than
/// in the service layer. POST /v3/messages used to publish MessageSendResult — a
/// type in Common.Services.Messaging.Contracts — so the public contract was whatever
/// the send service happened to return, and changing that service for an internal
/// reason changed the API. The service keeps its result; this is what a caller sees,
/// and the mapping between them is a decision the endpoint makes.              The
/// shape of an immediate send: it never has a scheduled_at key. A send that carried
/// scheduled_at is a ScheduledSendMessageResponse, and the endpoint decides which
/// of the two to answer with. From always returns this type.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<MessageResendResponseData, MessageResendResponseDataFromRaw>)
)]
public sealed record class MessageResendResponseData : JsonModel
{
    public IReadOnlyList<Recipient>? Recipients
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Recipient>>("recipients");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Recipient>?>(
                "recipients",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// QUEUED: the batch is accepted. A request that carried scheduled_at is QUEUED
    ///             here too; each message moves to SCHEDULED once it is held, as
    /// GET /v3/messages/{id} and the             message.scheduled webhook report.
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public string? TemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("template_id", value);
        }
    }

    public string? TemplateName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("template_name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Recipients ?? [])
        {
            item.Validate();
        }
        _ = this.Status;
        _ = this.TemplateID;
        _ = this.TemplateName;
    }

    public MessageResendResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageResendResponseData(MessageResendResponseData messageResendResponseData)
        : base(messageResendResponseData) { }
#pragma warning restore CS8618

    public MessageResendResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageResendResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageResendResponseDataFromRaw.FromRawUnchecked"/>
    public static MessageResendResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageResendResponseDataFromRaw : IFromRawJson<MessageResendResponseData>
{
    /// <inheritdoc/>
    public MessageResendResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageResendResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// What one recipient of a send got, as the API reports it.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Recipient, RecipientFromRaw>))]
public sealed record class Recipient : JsonModel
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

    public Recipient() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Recipient(Recipient recipient)
        : base(recipient) { }
#pragma warning restore CS8618

    public Recipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Recipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecipientFromRaw.FromRawUnchecked"/>
    public static Recipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecipientFromRaw : IFromRawJson<Recipient>
{
    /// <inheritdoc/>
    public Recipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Recipient.FromRawUnchecked(rawData);
}
