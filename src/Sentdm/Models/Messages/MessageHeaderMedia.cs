using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Messages;

/// <summary>
/// The media asset that rode a message's header, recorded as sent.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageHeaderMedia, MessageHeaderMediaFromRaw>))]
public sealed record class MessageHeaderMedia : JsonModel
{
    /// <summary>
    /// "image", "video" or "document" — taken from the header's media variable.
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// The https URL the caller supplied for this send. Never the template's stored
    /// props.sample, which is Meta's expiring header_handle rather than what was delivered.
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
        _ = this.Url;
    }

    public MessageHeaderMedia() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageHeaderMedia(MessageHeaderMedia messageHeaderMedia)
        : base(messageHeaderMedia) { }
#pragma warning restore CS8618

    public MessageHeaderMedia(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageHeaderMedia(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageHeaderMediaFromRaw.FromRawUnchecked"/>
    public static MessageHeaderMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageHeaderMediaFromRaw : IFromRawJson<MessageHeaderMedia>
{
    /// <inheritdoc/>
    public MessageHeaderMedia FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageHeaderMedia.FromRawUnchecked(rawData);
}
