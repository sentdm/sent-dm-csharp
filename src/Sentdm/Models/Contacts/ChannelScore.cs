using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Contacts;

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
