using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Messages;

/// <summary>
/// Response for GET /messages/{id}/activities
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageActivities, MessageActivitiesFromRaw>))]
public sealed record class MessageActivities : JsonModel
{
    /// <summary>
    /// List of activity events ordered by most recent first
    /// </summary>
    public IReadOnlyList<MessageActivity>? Activities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessageActivity>>("activities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<MessageActivity>?>(
                "activities",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The message ID these activities belong to
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
    /// Pagination metadata for list responses
    /// </summary>
    public PaginationMeta? Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>("pagination");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pagination", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Activities ?? [])
        {
            item.Validate();
        }
        _ = this.MessageID;
        this.Pagination?.Validate();
    }

    public MessageActivities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageActivities(MessageActivities messageActivities)
        : base(messageActivities) { }
#pragma warning restore CS8618

    public MessageActivities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageActivities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageActivitiesFromRaw.FromRawUnchecked"/>
    public static MessageActivities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageActivitiesFromRaw : IFromRawJson<MessageActivities>
{
    /// <inheritdoc/>
    public MessageActivities FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageActivities.FromRawUnchecked(rawData);
}
