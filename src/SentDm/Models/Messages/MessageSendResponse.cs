using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;
using SentDm.Models.Webhooks;

namespace SentDm.Models.Messages;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageSendResponse, MessageSendResponseFromRaw>))]
public sealed record class MessageSendResponse : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public MessageSendResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageSendResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error details (null if successful)
    /// </summary>
    public ApiError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Metadata about the request and response
    /// </summary>
    public ApiMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiMeta>("meta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data?.Validate();
        this.Error?.Validate();
        this.Meta?.Validate();
        _ = this.Success;
    }

    public MessageSendResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageSendResponse(MessageSendResponse messageSendResponse)
        : base(messageSendResponse) { }
#pragma warning restore CS8618

    public MessageSendResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageSendResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageSendResponseFromRaw.FromRawUnchecked"/>
    public static MessageSendResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageSendResponseFromRaw : IFromRawJson<MessageSendResponse>
{
    /// <inheritdoc/>
    public MessageSendResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageSendResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The response data (null if error)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageSendResponseData, MessageSendResponseDataFromRaw>))]
public sealed record class MessageSendResponseData : JsonModel
{
    /// <summary>
    /// Resolved template body text
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
    /// Per-recipient message results
    /// </summary>
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
    /// Overall request status (e.g. "accepted")
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

    /// <summary>
    /// Template ID that was used
    /// </summary>
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

    /// <summary>
    /// Template display name
    /// </summary>
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
        _ = this.Body;
        foreach (var item in this.Recipients ?? [])
        {
            item.Validate();
        }
        _ = this.Status;
        _ = this.TemplateID;
        _ = this.TemplateName;
    }

    public MessageSendResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageSendResponseData(MessageSendResponseData messageSendResponseData)
        : base(messageSendResponseData) { }
#pragma warning restore CS8618

    public MessageSendResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageSendResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageSendResponseDataFromRaw.FromRawUnchecked"/>
    public static MessageSendResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageSendResponseDataFromRaw : IFromRawJson<MessageSendResponseData>
{
    /// <inheritdoc/>
    public MessageSendResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageSendResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Per-recipient result in the send message response
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Recipient, RecipientFromRaw>))]
public sealed record class Recipient : JsonModel
{
    /// <summary>
    /// Channel this message will be sent on (e.g. "sms", "whatsapp"), or null for auto-detect
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
    /// Unique message identifier for tracking this recipient's message
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
    /// Phone number in E.164 format
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
