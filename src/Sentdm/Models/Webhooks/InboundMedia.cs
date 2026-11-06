using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// One attachment on an inbound message.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InboundMedia, InboundMediaFromRaw>))]
public sealed record class InboundMedia : JsonModel
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

    public InboundMedia() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundMedia(InboundMedia inboundMedia)
        : base(inboundMedia) { }
#pragma warning restore CS8618

    public InboundMedia(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundMedia(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundMediaFromRaw.FromRawUnchecked"/>
    public static InboundMedia FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundMediaFromRaw : IFromRawJson<InboundMedia>
{
    /// <inheritdoc/>
    public InboundMedia FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InboundMedia.FromRawUnchecked(rawData);
}
