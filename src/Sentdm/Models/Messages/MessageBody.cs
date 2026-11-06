using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Messages;

/// <summary>
/// Structured message body format for database storage. Preserves channel-specific
/// components (header, header media, body, footer, buttons, MMS subject and media).
///              Persisted as the messageBody jsonb column on Messages. Every write
/// path goes through MessageUtils.MessageBodyJsonOptions, which writes nulls, so
/// the envelope shape is stable regardless of channel or status. Anything that rebuilds
/// this object field by field — the four IMessageBodyStrategy implementations and
/// MessageUtils.BuildSegmentBody — has to carry every member, or that member is silently
/// dropped on whichever path forgot it.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageBody, MessageBodyFromRaw>))]
public sealed record class MessageBody : JsonModel
{
    public IReadOnlyList<MessageButton>? Buttons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessageButton>>("buttons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MessageButton>?>(
                "buttons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    public string? Footer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("footer");
        }
        init { this._rawData.Set("footer", value); }
    }

    public string? Header
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("header");
        }
        init { this._rawData.Set("header", value); }
    }

    /// <summary>
    /// The media asset that rode a message's header, recorded as sent.
    /// </summary>
    public MessageHeaderMedia? HeaderMedia
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageHeaderMedia>("headerMedia");
        }
        init { this._rawData.Set("headerMedia", value); }
    }

    /// <summary>
    /// MMS attachments, as the publicly fetchable URLs handed to the carrier. Null
    /// on every other channel.              Persisted rather than derived because
    /// a resend and a curfew release rebuild the send from the stored row — MessageReplayCommandBuilder
    /// reads templateId and templateVariables and nothing else — so media that lives
    /// only on the original request would silently turn a replayed MMS into a text message.
    /// </summary>
    public IReadOnlyList<MessageMedia>? Media
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessageMedia>>("media");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MessageMedia>?>(
                "media",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// MMS subject line. Null on every other channel.
    /// </summary>
    public string? Subject
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subject");
        }
        init { this._rawData.Set("subject", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Buttons ?? [])
        {
            item.Validate();
        }
        _ = this.Content;
        _ = this.Footer;
        _ = this.Header;
        this.HeaderMedia?.Validate();
        foreach (var item in this.Media ?? [])
        {
            item.Validate();
        }
        _ = this.Subject;
    }

    public MessageBody() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageBody(MessageBody messageBody)
        : base(messageBody) { }
#pragma warning restore CS8618

    public MessageBody(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBody(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageBodyFromRaw.FromRawUnchecked"/>
    public static MessageBody FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageBodyFromRaw : IFromRawJson<MessageBody>
{
    /// <inheritdoc/>
    public MessageBody FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageBody.FromRawUnchecked(rawData);
}
