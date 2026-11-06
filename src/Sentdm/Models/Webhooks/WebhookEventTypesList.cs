using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// The webhook event types a customer can subscribe to.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookEventTypesList, WebhookEventTypesListFromRaw>))]
public sealed record class WebhookEventTypesList : JsonModel
{
    /// <summary>
    /// The event_types on this page.
    /// </summary>
    public IReadOnlyList<WebhookEventType>? EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WebhookEventType>>("event_types");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WebhookEventType>?>(
                "event_types",
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
        foreach (var item in this.EventTypes ?? [])
        {
            item.Validate();
        }
        this.Pagination?.Validate();
    }

    public WebhookEventTypesList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookEventTypesList(WebhookEventTypesList webhookEventTypesList)
        : base(webhookEventTypesList) { }
#pragma warning restore CS8618

    public WebhookEventTypesList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookEventTypesList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookEventTypesListFromRaw.FromRawUnchecked"/>
    public static WebhookEventTypesList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookEventTypesListFromRaw : IFromRawJson<WebhookEventTypesList>
{
    /// <inheritdoc/>
    public WebhookEventTypesList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookEventTypesList.FromRawUnchecked(rawData);
}
