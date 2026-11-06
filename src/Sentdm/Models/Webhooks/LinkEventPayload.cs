using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Body of a link event: something happened to a tracked link Sent published on
/// the customer's behalf. A link points either at a URL the customer supplied or
/// at a file Sent hosts for them; LinkKind says which. Delivered when an eligible
/// request is served, or when a published link reaches the end of its life.
///          A click is a request, not a read receipt. link.clicked means the redirect
/// was served; link.downloaded means bytes went out. Neither proves a person saw
/// anything — messaging providers and link scanners fetch URLs on their own, which
/// is what TrafficClass exists to tell apart. Filter on it before reporting a click-through
/// rate; treat likely_human as a hint, never as delivery confirmation.
///     RecordId identifies the link; the X-Webhook-Event-ID header identifies the
/// delivery. One link is hit many times, so those are the two keys a subscriber
/// needs: group by the first, deduplicate on the second — exactly as on every other
/// family. The payload carries no event identifier of its own, for the same reason
/// none of the others do.              Nothing here identifies the visitor. No IP
/// address and no visitor token crosses this boundary. Country, Device and Browser
/// are coarse buckets derived at the edge and are absent whenever the request did
/// not supply enough to derive them.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LinkEventPayload, LinkEventPayloadFromRaw>))]
public sealed record class LinkEventPayload : JsonModel
{
    /// <summary>
    /// The link's public identifier — the eight-character code in the short URL,
    /// for example A78B2BU0. Unique across both kinds, and never reused, so it is
    /// the stable key to group one link's events by.
    /// </summary>
    public required string RecordID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("record_id");
        }
        init { this._rawData.Set("record_id", value); }
    }

    /// <summary>
    /// Where the request appeared to come from, as an ISO 3166-1 alpha-2 code. Named
    /// separately from the country on a channel event, which is a destination market
    /// the customer registered for — this one is a property of a single visitor and
    /// is absent when the edge could not resolve it.
    /// </summary>
    public string? AccessCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("access_country");
        }
        init { this._rawData.Set("access_country", value); }
    }

    /// <summary>
    /// How the request was served, when the edge recorded it. Free text describing
    /// the outcome — show it to a human rather than branching on it.
    /// </summary>
    public string? AccessOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("access_outcome");
        }
        init { this._rawData.Set("access_outcome", value); }
    }

    /// <summary>
    /// The requesting browser family, for example chrome or safari, or unknown. Derived
    /// from the user agent.
    /// </summary>
    public string? Browser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("browser");
        }
        init { this._rawData.Set("browser", value); }
    }

    /// <summary>
    /// How many bytes were served, for a file access. A ranged request reports the
    /// bytes in that range, not the size of the file, so several accesses of one
    /// file can each report a part.
    /// </summary>
    public long? BytesServed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("bytes_served");
        }
        init { this._rawData.Set("bytes_served", value); }
    }

    /// <summary>
    /// The channel the message carrying this link went out on: sms, whatsapp, or rcs.
    /// </summary>
    public string? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// The organization the link belongs to. Always the parent account, never a
    /// sender profile — read SenderProfileId for that.              This family publishes
    /// the owner as an explicit pair rather than the single account_id the other
    /// families use. The pair says which organization and which profile without
    /// the subscriber deriving either, which is the trade: one more key against
    /// not having to know that account_id silently becomes the profile when one exists.
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

    /// <summary>
    /// The requesting device class: mobile, tablet, desktop or unknown. Derived
    /// from the user agent.
    /// </summary>
    public string? Device
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("device");
        }
        init { this._rawData.Set("device", value); }
    }

    /// <summary>
    /// What the link points at: url for a destination the customer supplied, file
    /// for media Sent hosts. Always present, and implied by the event — link.clicked
    /// is always url and link.downloaded always file — but published as its own field
    /// so a subscriber can branch on the kind without parsing the event name, the
    /// same separation the channel family keeps between its event and its status.
    /// </summary>
    public string? LinkKind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("link_kind");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("link_kind", value);
        }
    }

    /// <summary>
    /// The message the link was published in.              The event can arrive before
    /// the message is readable through GET /v3/messages: a provider may fetch a
    /// link within milliseconds of the send, and nothing here waits for the message
    /// row. Retry the read rather than treating an unknown id as an error.
    /// </summary>
    public string? MessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message_id");
        }
        init { this._rawData.Set("message_id", value); }
    }

    /// <summary>
    /// When the access or lifecycle change actually happened, in UTC (yyyy-MM-ddTHH:mm:ssZ).
    /// The envelope's timestamp is when Sent emitted the event; this is when the
    /// thing occurred, and the two differ by the ingest delay.
    /// </summary>
    public string? OccurredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("occurred_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("occurred_at", value);
        }
    }

    /// <summary>
    /// The caller-supplied label tying this link back to a position in the message,
    /// for example body:0 for the first link in the body. Present when the link was
    /// created with one.
    /// </summary>
    public string? ReferenceKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_key");
        }
        init { this._rawData.Set("reference_key", value); }
    }

    /// <summary>
    /// The host of the page that linked here, when the request supplied one. The
    /// host only — never a full referring URL.
    /// </summary>
    public string? ReferrerHost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("referrer_host");
        }
        init { this._rawData.Set("referrer_host", value); }
    }

    /// <summary>
    /// The HTTP method of the request that was served, for an access event. Omitted
    /// on link.expired and link.revoked, which describe no request.
    /// </summary>
    public string? RequestMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("request_method");
        }
        init { this._rawData.Set("request_method", value); }
    }

    /// <summary>
    /// The sender profile that owns the link, or null when the organization owns
    /// it directly. Always on the wire so a handler reads one shape rather than branching
    /// on whether the key arrived.              sender_profile_id, not profile_id:
    /// the API already publishes messaging_profile_id and sending_phone_number_profile_id
    /// for provider-side profiles, which are a different thing entirely. The unqualified
    /// name would read as one of those.
    /// </summary>
    public string? SenderProfileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sender_profile_id");
        }
        init { this._rawData.Set("sender_profile_id", value); }
    }

    /// <summary>
    /// The HTTP status Sent answered the request with: 302 for a link, 200 or 206
    /// for a file. Omitted on lifecycle events.
    /// </summary>
    public int? StatusCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("status_code");
        }
        init { this._rawData.Set("status_code", value); }
    }

    /// <summary>
    /// A coarse guess at what made the request: likely_human, provider (a messaging
    /// platform prefetching the link), bot, or unknown. Derived from the user agent,
    /// so it is a hint for filtering noise rather than a fact to bill or report on.
    /// </summary>
    public string? TrafficClass
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("traffic_class");
        }
        init { this._rawData.Set("traffic_class", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecordID;
        _ = this.AccessCountry;
        _ = this.AccessOutcome;
        _ = this.Browser;
        _ = this.BytesServed;
        _ = this.Channel;
        _ = this.CustomerID;
        _ = this.Device;
        _ = this.LinkKind;
        _ = this.MessageID;
        _ = this.OccurredAt;
        _ = this.ReferenceKey;
        _ = this.ReferrerHost;
        _ = this.RequestMethod;
        _ = this.SenderProfileID;
        _ = this.StatusCode;
        _ = this.TrafficClass;
    }

    public LinkEventPayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkEventPayload(LinkEventPayload linkEventPayload)
        : base(linkEventPayload) { }
#pragma warning restore CS8618

    public LinkEventPayload(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkEventPayload(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkEventPayloadFromRaw.FromRawUnchecked"/>
    public static LinkEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LinkEventPayload(string recordID)
        : this()
    {
        this.RecordID = recordID;
    }
}

class LinkEventPayloadFromRaw : IFromRawJson<LinkEventPayload>
{
    /// <inheritdoc/>
    public LinkEventPayload FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LinkEventPayload.FromRawUnchecked(rawData);
}
