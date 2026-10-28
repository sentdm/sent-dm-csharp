using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<WebhookResponse, WebhookResponseFromRaw>))]
public sealed record class WebhookResponse : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Failed attempts since the last success. Version 1 only: always 0 on a version
    /// 2 webhook, whose deliveries are in its events (GET /v3/webhooks/{id}/events).
    /// </summary>
    public int? ConsecutiveFailures
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("consecutive_failures");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consecutive_failures", value);
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Which customer owns this — the key's own, or the profile named in x-profile-id.
    /// Says whose resource this is, which the resource's own id does not.
    /// </summary>
    public string? CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customer_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("customer_id", value);
        }
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

    public string? EndpointUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("endpoint_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("endpoint_url", value);
        }
    }

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

    /// <summary>
    /// Whether the webhook also receives its organization's sender profiles' events,
    /// and each profile sees it and reads the events about itself. Always false on
    /// a version 1 webhook.
    /// </summary>
    public bool? IsInheritable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_inheritable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_inheritable", value);
        }
    }

    /// <summary>
    /// When the webhook was last attempted. Version 1 only: always null on a version
    /// 2 webhook.
    /// </summary>
    public DateTimeOffset? LastDeliveryAttemptAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_delivery_attempt_at");
        }
        init { this._rawData.Set("last_delivery_attempt_at", value); }
    }

    /// <summary>
    /// When the webhook last received an event. Version 1 only: always null on a
    /// version 2 webhook.
    /// </summary>
    public DateTimeOffset? LastSuccessfulDeliveryAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_successful_delivery_at");
        }
        init { this._rawData.Set("last_successful_delivery_at", value); }
    }

    public int? RetryCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("retry_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("retry_count", value);
        }
    }

    /// <summary>
    /// The events a version 1 webhook's sender profile clones receive, as a response
    /// reports them.              Its own type, field for field the same as the request's
    /// sender_profile. A response is not a request, whatever it carries.
    /// </summary>
    public WebhookResponseSenderProfile? SenderProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookResponseSenderProfile>("sender_profile");
        }
        init { this._rawData.Set("sender_profile", value); }
    }

    public string? SigningSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("signing_secret");
        }
        init { this._rawData.Set("signing_secret", value); }
    }

    public int? TimeoutSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("timeout_seconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timeout_seconds", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Who delivers the webhook: 1 the older delivery, which will be retired, or
    /// 2 Svix. A webhook is created as version 2 unless the request asks for 1.
    /// </summary>
    public long? WebhookVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("webhook_version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("webhook_version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ConsecutiveFailures;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        _ = this.DisplayName;
        _ = this.EndpointUrl;
        _ = this.EventFilters;
        _ = this.EventTypes;
        _ = this.IsActive;
        _ = this.IsInheritable;
        _ = this.LastDeliveryAttemptAt;
        _ = this.LastSuccessfulDeliveryAt;
        _ = this.RetryCount;
        this.SenderProfile?.Validate();
        _ = this.SigningSecret;
        _ = this.TimeoutSeconds;
        _ = this.UpdatedAt;
        _ = this.WebhookVersion;
    }

    public WebhookResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookResponse(WebhookResponse webhookResponse)
        : base(webhookResponse) { }
#pragma warning restore CS8618

    public WebhookResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookResponseFromRaw.FromRawUnchecked"/>
    public static WebhookResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookResponseFromRaw : IFromRawJson<WebhookResponse>
{
    /// <inheritdoc/>
    public WebhookResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The events a version 1 webhook's sender profile clones receive, as a response
/// reports them.              Its own type, field for field the same as the request's
/// sender_profile. A response is not a request, whatever it carries.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WebhookResponseSenderProfile, WebhookResponseSenderProfileFromRaw>)
)]
public sealed record class WebhookResponseSenderProfile : JsonModel
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

    public WebhookResponseSenderProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookResponseSenderProfile(WebhookResponseSenderProfile webhookResponseSenderProfile)
        : base(webhookResponseSenderProfile) { }
#pragma warning restore CS8618

    public WebhookResponseSenderProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookResponseSenderProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookResponseSenderProfileFromRaw.FromRawUnchecked"/>
    public static WebhookResponseSenderProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookResponseSenderProfileFromRaw : IFromRawJson<WebhookResponseSenderProfile>
{
    /// <inheritdoc/>
    public WebhookResponseSenderProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookResponseSenderProfile.FromRawUnchecked(rawData);
}
