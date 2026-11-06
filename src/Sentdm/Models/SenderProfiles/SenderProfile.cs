using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Channels;
using Sentdm.Models.Channels.Sms;

namespace Sentdm.Models.SenderProfiles;

/// <summary>
/// A sender profile as the API reports it — the same document the create call accepts,
/// plus the read-only facts it cannot: each market's status and what it still owes.
///              No status at the profile, brand or campaign level. Brand and campaign
/// are identity, and identity has no lifecycle. What has one is the registration
/// of a sender in a market, and the approval of a channel — so status lives there,
/// where it says which specific thing is blocked rather than flattening several
/// answers into one.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SenderProfile, SenderProfileFromRaw>))]
public sealed record class SenderProfile : JsonModel
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
    /// The API key for this profile.              Returned by create and by nothing
    /// else. It is shown once; a read that repeated it would turn every profile
    /// list into a credential dump and put the key into any log or cache that keeps
    /// a response body.              Omitted rather than null on a read. A key field
    /// that is always present and always empty suggests it could be populated, which
    /// is an invitation to populate it; absent says there is nothing to look for.
    /// Doing it with a serializer condition rather than a second response type keeps
    /// create and read on one shape, which is what stops them drifting.
    /// </summary>
    public string? ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("api_key");
        }
        init { this._rawData.Set("api_key", value); }
    }

    /// <summary>
    /// Who pays for a sender profile's traffic, as a read reports it.
    ///    Its own type, field for field the same as BillingRequest. Same reason
    /// as the brand: a response is not a request, whatever it carries.
    /// </summary>
    public SenderProfileBilling? Billing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SenderProfileBilling>("billing");
        }
        init { this._rawData.Set("billing", value); }
    }

    /// <summary>
    /// The channels a profile sends on. SMS is a list because a profile can send
    /// in several markets; WhatsApp and RCS are single, because a profile has one
    /// business account and one agent.
    /// </summary>
    public ChannelsState? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChannelsState>("channels");
        }
        init { this._rawData.Set("channels", value); }
    }

    /// <summary>
    /// What a market has been given: the identity it registers under, its programme,
    /// and any documents attached.              What it does not carry is what the
    /// market asks for. That is the subject of GET /v3/compliance/requirements, and
    /// it is the same answer for every caller — a description of what a compliance
    /// regime wants, not a record of one customer's progress through it. It was
    /// reported here as well for a while, which put the same array in six response
    /// shapes and left a caller deciding which of two sources to believe.
    ///       Present on a list read for markets that register (carrying brand and
    /// campaign), but with documents absent — documents are not fetched for a list,
    /// because a catalog lookup and a document read per market would multiply across
    /// a page. Absent documents is distinct from an empty list: absent says they
    /// were not fetched; empty says the market has been given none. The parent object
    /// is null only when the market registers with nobody and compliance was not
    /// computed — nothing to show at all.
    /// </summary>
    public SuppliedCompliance? Compliance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SuppliedCompliance>("compliance");
        }
        init { this._rawData.Set("compliance", value); }
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

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
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

    /// <summary>
    /// Who is notified about this profile's events: ORGANIZATION, SENDER_PROFILE,
    /// or ORGANIZATION_AND_SENDER_PROFILE. Always present — a profile that never
    /// chose reports as ORGANIZATION, the value a create would send to get the default behaviour.
    /// </summary>
    public string? Notifications
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("notifications");
        }
        init { this._rawData.Set("notifications", value); }
    }

    public string? OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
    }

    public string? ShortName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("short_name");
        }
        init { this._rawData.Set("short_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ApiKey;
        this.Billing?.Validate();
        this.Channels?.Validate();
        this.Compliance?.Validate();
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Name;
        _ = this.Notifications;
        _ = this.OrganizationID;
        _ = this.ShortName;
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
