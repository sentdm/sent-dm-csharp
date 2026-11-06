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
[JsonConverter(typeof(JsonModelConverter<MessageSendResult, MessageSendResultFromRaw>))]
public sealed record class MessageSendResult : JsonModel
{
    public IReadOnlyList<MessageRecipient>? Recipients
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessageRecipient>>("recipients");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<MessageRecipient>?>(
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

    public MessageSendResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageSendResult(MessageSendResult messageSendResult)
        : base(messageSendResult) { }
#pragma warning restore CS8618

    public MessageSendResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageSendResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageSendResultFromRaw.FromRawUnchecked"/>
    public static MessageSendResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageSendResultFromRaw : IFromRawJson<MessageSendResult>
{
    /// <inheritdoc/>
    public MessageSendResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageSendResult.FromRawUnchecked(rawData);
}
