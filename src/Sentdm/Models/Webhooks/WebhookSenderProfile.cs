using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// The events a version 1 webhook's sender profile clones receive, as a response
/// reports them.              Its own type, field for field the same as the request's
/// sender_profile. A response is not a request, whatever it carries.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookSenderProfile, WebhookSenderProfileFromRaw>))]
public sealed record class WebhookSenderProfile : JsonModel
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

    public WebhookSenderProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookSenderProfile(WebhookSenderProfile webhookSenderProfile)
        : base(webhookSenderProfile) { }
#pragma warning restore CS8618

    public WebhookSenderProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookSenderProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookSenderProfileFromRaw.FromRawUnchecked"/>
    public static WebhookSenderProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookSenderProfileFromRaw : IFromRawJson<WebhookSenderProfile>
{
    /// <inheritdoc/>
    public WebhookSenderProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookSenderProfile.FromRawUnchecked(rawData);
}
