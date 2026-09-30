using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    /// The contact's number in E.164 format, meaning the number the message came from.
    /// </summary>
    public required string InboundNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("inbound_number");
        }
        init { this._rawData.Set("inbound_number", value); }
    }

    /// <summary>
    /// When the message was received, in UTC (yyyy-MM-ddTHH:mm:ssZ).
    /// </summary>
    public required string ReceivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("received_at");
        }
        init { this._rawData.Set("received_at", value); }
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
    /// The channel the message arrived on, for example sms or mms.
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
    /// Attachments the contact sent, present only on channels that carry them (mms
    /// today) and omitted entirely otherwise.              Each url points at the
    /// carrier's own copy of the file — sent.dm records where the attachment is,
    /// not the attachment itself. The link is unauthenticated and expires on the
    /// carrier's schedule, which differs between them: assume days, not months. Download
    /// what you need on receipt; re-reading the message through GET /v3/messages/{id}
    /// returns the same stored link, not a fresh one, so once it lapses the entry
    /// remains with whatever the carrier declared about the file but the file is
    /// no longer reachable.
    /// </summary>
    public IReadOnlyList<Media>? Media
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Media>>("media");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Media>?>(
                "media",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
        _ = this.InboundNumber;
        _ = this.ReceivedAt;
        _ = this.AccountID;
        _ = this.Channel;
        foreach (var item in this.Media ?? [])
        {
            item.Validate();
        }
        _ = this.MessageID;
        _ = this.OutboundNumber;
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

/// <summary>
/// One attachment on an inbound message.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Media, MediaFromRaw>))]
public sealed record class Media : JsonModel
{
    /// <summary>
    /// SHA-256 of the file as the carrier declared it, when it declares one. Verify
    /// what you download against this — sent.dm never reads the bytes, so it is
    /// the only integrity signal available.
    /// </summary>
    public string? HashSha256
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("hash_sha256");
        }
        init { this._rawData.Set("hash_sha256", value); }
    }

    /// <summary>
    /// Content type as the carrier reported it, for example image/jpeg.
    /// </summary>
    public string? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mime_type");
        }
        init { this._rawData.Set("mime_type", value); }
    }

    /// <summary>
    /// Size in bytes as the carrier declared it. Absent when it declared none.
    /// </summary>
    public long? SizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("size_bytes");
        }
        init { this._rawData.Set("size_bytes", value); }
    }

    /// <summary>
    /// Where the carrier hosts the attachment.              This link expires and
    /// is not authenticated. sent.dm relays it rather than copying the file, so
    /// how long it stays fetchable is the carrier's decision and differs between
    /// them — assume days, not months. Anyone holding the URL can fetch it until
    /// it lapses. Copy the file on receipt if you need it to outlive that window;
    /// do not store this URL as a permanent reference.
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HashSha256;
        _ = this.MimeType;
        _ = this.SizeBytes;
        _ = this.Url;
    }

    public Media() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Media(Media media)
        : base(media) { }
#pragma warning restore CS8618

    public Media(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Media(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MediaFromRaw.FromRawUnchecked"/>
    public static Media FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MediaFromRaw : IFromRawJson<Media>
{
    /// <inheritdoc/>
    public Media FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Media.FromRawUnchecked(rawData);
}
