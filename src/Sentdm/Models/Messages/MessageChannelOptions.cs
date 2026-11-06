using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Messages;

/// <summary>
/// One entry of a channel's list in Channels, e.g. {"country": "US", "from": ["+15559990002",
/// "+15559990003"], "strategy": "sticky"}.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageChannelOptions, MessageChannelOptionsFromRaw>))]
public sealed record class MessageChannelOptions : JsonModel
{
    /// <summary>
    /// Recipient country this entry is meant for (ISO 3166-1 alpha-2, e.g. US).
    /// Optional. Accepted and stored, not acted on yet.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// Sender numbers in E.164. Each must be an active sender on your account for
    /// this channel. That is account state rather than request shape, so it is decided
    /// per message: the request is accepted with 202 and a message naming an unusable
    /// number is recorded BLOCKED with error code BUSINESS_029.
    /// </summary>
    public IReadOnlyList<string>? From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("from");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "from",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// How to pick a number from From, e.g. sticky or geo. Optional. Accepted and
    /// stored, not acted on yet.
    /// </summary>
    public string? Strategy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("strategy");
        }
        init { this._rawData.Set("strategy", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.From;
        _ = this.Strategy;
    }

    public MessageChannelOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageChannelOptions(MessageChannelOptions messageChannelOptions)
        : base(messageChannelOptions) { }
#pragma warning restore CS8618

    public MessageChannelOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageChannelOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageChannelOptionsFromRaw.FromRawUnchecked"/>
    public static MessageChannelOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageChannelOptionsFromRaw : IFromRawJson<MessageChannelOptions>
{
    /// <inheritdoc/>
    public MessageChannelOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageChannelOptions.FromRawUnchecked(rawData);
}
