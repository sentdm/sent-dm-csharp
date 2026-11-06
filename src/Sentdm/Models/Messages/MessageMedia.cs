using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Messages;

/// <summary>
/// One attachment on a message, in either direction — and in both, a URL somebody
/// else hosts.              Outbound: the customer supplied a public URL and we
/// handed it to the carrier. Inbound: the carrier hosts the file and we record where.
/// sent.dm never holds the bytes, so there is no key, no expiry bookkeeping and nothing
/// minted per read — what is stored is what is served.              An inbound link
/// expires on the carrier's own schedule and is unauthenticated. That is the customer's
/// to manage, and it is documented where they will see it rather than only here
/// — a recipient who needs an attachment to outlive that window copies it on receipt.
///              Storing a presigned URL is the specific mistake this shape still
/// avoids: M260826130000 and M260826140000 exist because RCS assets were stored
/// as signed URLs and went stale. Nothing here is signed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageMedia, MessageMediaFromRaw>))]
public sealed record class MessageMedia : JsonModel
{
    /// <summary>
    /// One of MmsMediaTypes when the content type is known. Advisory — a reader should
    ///             trust the fetched object's own Content-Type.
    /// </summary>
    public string? MediaType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaType");
        }
        init { this._rawData.Set("mediaType", value); }
    }

    /// <summary>
    /// Content type as the provider declared it. Null when it declared none.
    /// </summary>
    public string? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mimeType");
        }
        init { this._rawData.Set("mimeType", value); }
    }

    /// <summary>
    /// Size as the provider declared it. Never measured here — nothing downloads
    /// the file.
    /// </summary>
    public long? SizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sizeBytes");
        }
        init { this._rawData.Set("sizeBytes", value); }
    }

    /// <summary>
    /// Inbound only: the SHA-256 the provider declared alongside the attachment,
    /// when it declared one. Relayed to the customer so they can verify what they
    /// fetch matches what the carrier said it sent. It is the only integrity signal
    /// available on an attachment nobody here has read.
    /// </summary>
    public string? SourceHashSha256
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sourceHashSha256");
        }
        init { this._rawData.Set("sourceHashSha256", value); }
    }

    /// <summary>
    /// Where the file lives. Outbound: the URL the customer gave us and the carrier
    /// fetched. Inbound: the URL the carrier hosts it at, relayed unchanged.
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
        _ = this.MediaType;
        _ = this.MimeType;
        _ = this.SizeBytes;
        _ = this.SourceHashSha256;
        _ = this.Url;
    }

    public MessageMedia() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageMedia(MessageMedia messageMedia)
        : base(messageMedia) { }
#pragma warning restore CS8618

    public MessageMedia(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageMedia(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageMediaFromRaw.FromRawUnchecked"/>
    public static MessageMedia FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageMediaFromRaw : IFromRawJson<MessageMedia>
{
    /// <inheritdoc/>
    public MessageMedia FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageMedia.FromRawUnchecked(rawData);
}
