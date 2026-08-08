using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Contacts;

[JsonConverter(typeof(JsonModelConverter<ContactMessageSummary, ContactMessageSummaryFromRaw>))]
public sealed record class ContactMessageSummary : JsonModel
{
    public IReadOnlyList<ChannelScore>? ChannelScores
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ChannelScore>>("channel_scores");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ChannelScore>?>(
                "channel_scores",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? ChannelsUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels_used");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "channels_used",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? ContactID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contact_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contact_id", value);
        }
    }

    public DateTimeOffset? FirstMessageAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("first_message_at");
        }
        init { this._rawData.Set("first_message_at", value); }
    }

    public DateTimeOffset? LastMessageAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_message_at");
        }
        init { this._rawData.Set("last_message_at", value); }
    }

    public int? MessageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("message_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message_count", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ChannelScores ?? [])
        {
            item.Validate();
        }
        _ = this.ChannelsUsed;
        _ = this.ContactID;
        _ = this.FirstMessageAt;
        _ = this.LastMessageAt;
        _ = this.MessageCount;
    }

    public ContactMessageSummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactMessageSummary(ContactMessageSummary contactMessageSummary)
        : base(contactMessageSummary) { }
#pragma warning restore CS8618

    public ContactMessageSummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactMessageSummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactMessageSummaryFromRaw.FromRawUnchecked"/>
    public static ContactMessageSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactMessageSummaryFromRaw : IFromRawJson<ContactMessageSummary>
{
    /// <inheritdoc/>
    public ContactMessageSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContactMessageSummary.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ChannelScore, ChannelScoreFromRaw>))]
public sealed record class ChannelScore : JsonModel
{
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
    /// Percentage (0-100) of messages on this channel that ended in FAILED.
    /// </summary>
    public int? FailScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("fail_score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fail_score", value);
        }
    }

    /// <summary>
    /// Percentage (0-100) of messages on this channel that reached a successful terminal
    /// state: SENT/DELIVERED/READ for outbound, RECEIVED for inbound.
    /// </summary>
    public int? SuccessScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("success_score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success_score", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channel;
        _ = this.FailScore;
        _ = this.SuccessScore;
    }

    public ChannelScore() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelScore(ChannelScore channelScore)
        : base(channelScore) { }
#pragma warning restore CS8618

    public ChannelScore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelScore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelScoreFromRaw.FromRawUnchecked"/>
    public static ChannelScore FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelScoreFromRaw : IFromRawJson<ChannelScore>
{
    /// <inheritdoc/>
    public ChannelScore FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelScore.FromRawUnchecked(rawData);
}
