using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// A paginated list of webhooks.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhooksList, WebhooksListFromRaw>))]
public sealed record class WebhooksList : JsonModel
{
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

    /// <summary>
    /// The webhooks on this page.
    /// </summary>
    public IReadOnlyList<WebhookResponse>? Webhooks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WebhookResponse>>("webhooks");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<WebhookResponse>?>(
                "webhooks",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Pagination?.Validate();
        foreach (var item in this.Webhooks ?? [])
        {
            item.Validate();
        }
    }

    public WebhooksList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhooksList(WebhooksList webhooksList)
        : base(webhooksList) { }
#pragma warning restore CS8618

    public WebhooksList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhooksList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhooksListFromRaw.FromRawUnchecked"/>
    public static WebhooksList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhooksListFromRaw : IFromRawJson<WebhooksList>
{
    /// <inheritdoc/>
    public WebhooksList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhooksList.FromRawUnchecked(rawData);
}
