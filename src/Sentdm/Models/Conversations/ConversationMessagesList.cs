using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Messages;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Conversations;

/// <summary>
/// A paginated list of messages — used by both conversation read endpoints.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ConversationMessagesList, ConversationMessagesListFromRaw>)
)]
public sealed record class ConversationMessagesList : JsonModel
{
    /// <summary>
    /// The messages on this page.
    /// </summary>
    public IReadOnlyList<Message>? Messages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Message>>("messages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Message>?>(
                "messages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
        foreach (var item in this.Messages ?? [])
        {
            item.Validate();
        }
        this.Pagination?.Validate();
    }

    public ConversationMessagesList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationMessagesList(ConversationMessagesList conversationMessagesList)
        : base(conversationMessagesList) { }
#pragma warning restore CS8618

    public ConversationMessagesList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationMessagesList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationMessagesListFromRaw.FromRawUnchecked"/>
    public static ConversationMessagesList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationMessagesListFromRaw : IFromRawJson<ConversationMessagesList>
{
    /// <inheritdoc/>
    public ConversationMessagesList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationMessagesList.FromRawUnchecked(rawData);
}
