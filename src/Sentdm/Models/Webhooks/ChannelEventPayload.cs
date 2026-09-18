using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Body of a channel event: where one of the customer's channels stands in provisioning
/// and compliance. Delivered when a milestone moves — a registration filed, a verdict
/// returned, a resubmission asked for, a sender gone live — so a customer's own onboarding
/// UI does not have to poll GET /v3/channels.              The subject is one item,
/// never the account. A customer's "SMS channel" has no status; a market does. Country,
/// NumberType and SenderValue name which one, so a customer terminating only to Kosovo
/// never receives an event about US 10DLC.              Status is the stable half
/// of the contract. It is the same four-value set GET /v3/channels publishes, computed
/// through the same code, so an event and a read of the same market cannot disagree.
/// A subscriber that reads nothing but the status and the subject fields is a correct
/// subscriber. The sub-type on the envelope names the specific milestone and is
/// additive — that vocabulary comes from registries and carriers, which are parties
/// Sent does not control.              Status means provisioning and compliance are
/// complete, not that a send will succeed right now. An account can be suspended,
/// or a destination blocked by a routing rule, without either showing up here. Those
/// are separate surfaces and deliberately not modelled on this payload.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChannelEventPayload, ChannelEventPayloadFromRaw>))]
public sealed record class ChannelEventPayload : JsonModel
{
    /// <summary>
    /// The market's destination country as an ISO 3166-1 alpha-2 code, for example
    /// XK. Always present, and the property that identifies this payload among the
    /// delivered envelopes — see DeliveredWebhookEvents. Every event in this family
    /// reports one market, and a market has a country.
    /// </summary>
    public required string Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// The account whose market this is, named as on every other family. When an
    /// organization receives an event for one of its sender profiles this is the
    /// profile, so a reseller compares it with its own id and anything different
    /// is one of its profiles.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_id", value);
        }
    }

    /// <summary>
    /// The channel this market belongs to: sms, whatsapp, or rcs. Never sent — that
    /// value belongs to message events, where it names the smart-routing brand rather
    /// than a channel that can be provisioned.
    /// </summary>
    public string? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channel", value);
        }
    }

    /// <summary>
    /// The kind of sender the market uses, for example TEN_DLC, LOCAL, or ALPHANUMERIC.
    /// Omitted when the subject has no sender type of its own.
    /// </summary>
    public string? NumberType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("number_type");
        }
        init { this._rawData.Set("number_type", value); }
    }

    /// <summary>
    /// Why the market reached this state, when a reason was given — a correction
    /// explained, or a campaign lapse. Free text, passed through from the registry
    /// or carrier that wrote it, so treat it as a message to show a human rather
    /// than a value to branch on.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The sender itself — a number in E.164, or an alphanumeric sender ID.
    ///         Always present, and null until a sender exists. The key is on every
    /// delivery so a subscriber reads one shape rather than branching on whether
    /// the field arrived — the same choice template_id makes on the message payload.
    ///              It can carry a value at any point in the lifecycle, not only
    /// once the market is live: a number ordered and not yet active at the carrier
    /// is already known during PROVISIONING, and an alphanumeric sender the customer
    /// chose themselves is known before anything is filed. It is null while the market
    /// is still waiting on a number, which for a US 10DLC registration is every
    /// event up to channel.activated.
    /// </summary>
    public string? SenderValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sender_value");
        }
        init { this._rawData.Set("sender_value", value); }
    }

    /// <summary>
    /// Where the market stands: PENDING_REVIEW, ACTION_NEEDED, PROVISIONING, ACTIVE
    /// or INACTIVE. PENDING_REVIEW means a registry or a carrier holds it and the
    /// wait is theirs; ACTION_NEEDED means it is yours; PROVISIONING means the verdict
    /// is in and Sent is acquiring the sender; INACTIVE means it had a working sender
    /// and no longer does.              Each event name is the transition into one
    /// of these, but the two are separate fields and may legitimately differ. A resubmission
    /// filed against a market whose sender is already live is channel.submitted carrying
    /// ACTIVE: a correction is with the registry and the sender keeps working. Read both.
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// When the transition happened, in UTC (yyyy-MM-ddTHH:mm:ssZ).
    /// </summary>
    public string? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.AccountID;
        _ = this.Channel;
        _ = this.NumberType;
        _ = this.Reason;
        _ = this.SenderValue;
        _ = this.Status;
        _ = this.UpdatedAt;
    }

    public ChannelEventPayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelEventPayload(ChannelEventPayload channelEventPayload)
        : base(channelEventPayload) { }
#pragma warning restore CS8618

    public ChannelEventPayload(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelEventPayload(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelEventPayloadFromRaw.FromRawUnchecked"/>
    public static ChannelEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChannelEventPayload(string country)
        : this()
    {
        this.Country = country;
    }
}

class ChannelEventPayloadFromRaw : IFromRawJson<ChannelEventPayload>
{
    /// <inheritdoc/>
    public ChannelEventPayload FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelEventPayload.FromRawUnchecked(rawData);
}
