using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Creates a new webhook endpoint for the authenticated customer. A webhook is version
/// 2 unless the request sets webhook_version to 1: Svix delivers it, signed with
/// the webhook-id, webhook-timestamp and webhook-signature headers, and retries
/// it on its own schedule, so retry_count and timeout_seconds apply to version 1
/// only. sender_profile applies to version 1 only and is ignored on version 2; is_inheritable
/// applies to version 2 only. A version 1 webhook's response returns its sender_profile
/// selection, with an empty event_types when it is not cloned onto sender profiles;
/// a version 2 webhook's response leaves sender_profile out.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WebhookCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("display_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("display_name", value);
        }
    }

    public string? EndpointUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("endpoint_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("endpoint_url", value);
        }
    }

    public IReadOnlyDictionary<string, IReadOnlyList<string>>? EventFilters
    {
        get
        {
            this._rawBodyData.Freeze();
            var value = this._rawBodyData.GetNullableClass<
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
            this._rawBodyData.Set<FrozenDictionary<string, ImmutableArray<string>>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("event_types");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "event_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Also delivers every sender profile's events to this webhook, at the same
    /// URL and with the same signing secret, and lets each profile see the webhook
    /// and read the events about itself. Off by default: the organization's own
    /// events only. Only an organization's version 2 webhook can set it.
    /// </summary>
    public bool? IsInheritable
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("is_inheritable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("is_inheritable", value);
        }
    }

    /// <summary>
    /// Delivery retries. Applies to version 1 only: Svix retries a version 2 webhook
    /// on its own schedule.
    /// </summary>
    public int? RetryCount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("retry_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("retry_count", value);
        }
    }

    /// <summary>
    /// Sandbox flag - when true, the operation is simulated without side effects
    /// Useful for testing integrations without actual execution
    /// </summary>
    public bool? Sandbox
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("sandbox");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sandbox", value);
        }
    }

    /// <summary>
    /// Request-only: the events an organization webhook's sender profile clones receive,
    /// one clone per existing and future profile. A version 1 webhook's responses
    /// report it as WebhookSenderProfileV3Response.
    /// </summary>
    public SenderProfile? SenderProfile
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SenderProfile>("sender_profile");
        }
        init { this._rawBodyData.Set("sender_profile", value); }
    }

    /// <summary>
    /// Delivery timeout. Applies to version 1 only.
    /// </summary>
    public int? TimeoutSeconds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("timeout_seconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("timeout_seconds", value);
        }
    }

    /// <summary>
    /// Who delivers the webhook: 2, the default, is delivered by Svix and signed
    /// with the webhook-id, webhook-timestamp and webhook-signature headers; 1 is
    /// the older delivery, signed with the X-Webhook-* headers, which will be retired.
    /// </summary>
    public long? WebhookVersion
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("webhook_version");
        }
        init { this._rawBodyData.Set("webhook_version", value); }
    }

    public string? IdempotencyKey
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("Idempotency-Key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
        }
    }

    public string? XProfileID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("x-profile-id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("x-profile-id", value);
        }
    }

    public WebhookCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookCreateParams(WebhookCreateParams webhookCreateParams)
        : base(webhookCreateParams)
    {
        this._rawBodyData = new(webhookCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WebhookCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WebhookCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(WebhookCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/webhooks")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Request-only: the events an organization webhook's sender profile clones receive,
/// one clone per existing and future profile. A version 1 webhook's responses report
/// it as WebhookSenderProfileV3Response.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SenderProfile, SenderProfileFromRaw>))]
public sealed record class SenderProfile : JsonModel
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

    public SenderProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderProfile(SenderProfile senderProfile)
        : base(senderProfile) { }
#pragma warning restore CS8618

    public SenderProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SenderProfileFromRaw.FromRawUnchecked"/>
    public static SenderProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SenderProfileFromRaw : IFromRawJson<SenderProfile>
{
    /// <inheritdoc/>
    public SenderProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SenderProfile.FromRawUnchecked(rawData);
}
