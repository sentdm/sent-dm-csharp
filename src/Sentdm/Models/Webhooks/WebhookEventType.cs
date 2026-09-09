using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<WebhookEventType, WebhookEventTypeFromRaw>))]
public sealed record class WebhookEventType : JsonModel
{
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("display_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("display_name", value);
        }
    }

    public string? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("event_type");
        }
        init { this._rawData.Set("event_type", value); }
    }

    public bool? IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_active", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public IReadOnlyList<WebhookEventType>? SubTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WebhookEventType>>("sub_types");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WebhookEventType>?>(
                "sub_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.DisplayName;
        _ = this.EventType;
        _ = this.IsActive;
        _ = this.Name;
        foreach (var item in this.SubTypes ?? [])
        {
            item.Validate();
        }
    }

    public WebhookEventType() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookEventType(WebhookEventType webhookEventType)
        : base(webhookEventType) { }
#pragma warning restore CS8618

    public WebhookEventType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookEventType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookEventTypeFromRaw.FromRawUnchecked"/>
    public static WebhookEventType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookEventTypeFromRaw : IFromRawJson<WebhookEventType>
{
    /// <inheritdoc/>
    public WebhookEventType FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookEventType.FromRawUnchecked(rawData);
}
