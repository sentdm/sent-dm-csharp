using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Request-only: the events an organization webhook's sender profile clones receive,
/// one clone per existing and future profile. A version 1 webhook's responses report
/// it as WebhookSenderProfileV3Response.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WebhookSenderProfileConfig, WebhookSenderProfileConfigFromRaw>)
)]
public sealed record class WebhookSenderProfileConfig : JsonModel
{
    public IReadOnlyDictionary<string, IReadOnlyList<string>>? EventFilters
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableClass<
                FrozenDictionary<string, ImmutableArray<string>>
            >("event_filters");
            if (value == null)
            {
                return null;
            }

            return FrozenDictionary.ToFrozenDictionary(
                value,
                entry => entry.Key,
                (entry) => (IReadOnlyList<string>)entry.Value
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, ImmutableArray<string>>?>(
                "event_filters",
                value == null
                    ? null
                    : FrozenDictionary.ToFrozenDictionary(
                        value,
                        entry => entry.Key,
                        (entry) => ImmutableArray.ToImmutableArray(entry.Value)
                    )
            );
        }
    }

    public IReadOnlyList<string>? EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("event_types");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "event_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EventFilters;
        _ = this.EventTypes;
    }

    public WebhookSenderProfileConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookSenderProfileConfig(WebhookSenderProfileConfig webhookSenderProfileConfig)
        : base(webhookSenderProfileConfig) { }
#pragma warning restore CS8618

    public WebhookSenderProfileConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookSenderProfileConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookSenderProfileConfigFromRaw.FromRawUnchecked"/>
    public static WebhookSenderProfileConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookSenderProfileConfigFromRaw : IFromRawJson<WebhookSenderProfileConfig>
{
    /// <inheritdoc/>
    public WebhookSenderProfileConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookSenderProfileConfig.FromRawUnchecked(rawData);
}
