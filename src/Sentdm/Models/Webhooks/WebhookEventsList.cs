using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// A paginated list of webhook delivery records.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookEventsList, WebhookEventsListFromRaw>))]
public sealed record class WebhookEventsList : JsonModel
{
    /// <summary>
    /// The events on this page.
    /// </summary>
    public IReadOnlyList<WebhookDelivery>? Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WebhookDelivery>>("events");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WebhookDelivery>?>(
                "events",
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
        foreach (var item in this.Events ?? [])
        {
            item.Validate();
        }
        this.Pagination?.Validate();
    }

    public WebhookEventsList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookEventsList(WebhookEventsList webhookEventsList)
        : base(webhookEventsList) { }
#pragma warning restore CS8618

    public WebhookEventsList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookEventsList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookEventsListFromRaw.FromRawUnchecked"/>
    public static WebhookEventsList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookEventsListFromRaw : IFromRawJson<WebhookEventsList>
{
    /// <inheritdoc/>
    public WebhookEventsList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookEventsList.FromRawUnchecked(rawData);
}
