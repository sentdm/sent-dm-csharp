using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;

namespace SentDm.Models.Webhooks;

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

    public DateTimeOffset? LastDeliveryAttemptAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_delivery_attempt_at");
        }
        init { this._rawData.Set("last_delivery_attempt_at", value); }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ConsecutiveFailures;
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.EndpointUrl;
        _ = this.EventTypes;
        _ = this.IsActive;
        _ = this.LastDeliveryAttemptAt;
        _ = this.LastSuccessfulDeliveryAt;
        _ = this.RetryCount;
        _ = this.SigningSecret;
        _ = this.TimeoutSeconds;
        _ = this.UpdatedAt;
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
