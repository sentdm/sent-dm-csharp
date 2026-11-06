using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageButton, MessageButtonFromRaw>))]
public sealed record class MessageButton : JsonModel
{
    public string? PostbackData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postbackData");
        }
        init { this._rawData.Set("postbackData", value); }
    }

    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

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

    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PostbackData;
        _ = this.Text;
        _ = this.Type;
        _ = this.Value;
    }

    public MessageButton() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageButton(MessageButton messageButton)
        : base(messageButton) { }
#pragma warning restore CS8618

    public MessageButton(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageButton(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageButtonFromRaw.FromRawUnchecked"/>
    public static MessageButton FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageButtonFromRaw : IFromRawJson<MessageButton>
{
    /// <inheritdoc/>
    public MessageButton FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageButton.FromRawUnchecked(rawData);
}
