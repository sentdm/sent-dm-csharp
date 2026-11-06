using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Channels.Rcs;
using Sentdm.Models.Channels.Sms;
using Sentdm.Models.Channels.Voice;
using Sentdm.Models.Channels.Whatsapp;

namespace Sentdm.Models.Channels;

/// <summary>
/// The channels a profile sends on. SMS is a list because a profile can send in
/// several markets; WhatsApp and RCS are single, because a profile has one business
/// account and one agent.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChannelsState, ChannelsStateFromRaw>))]
public sealed record class ChannelsState : JsonModel
{
    /// <summary>
    /// Which customer these channels belong to — the key's own, or the profile named
    /// in x-profile-id.              Same reason the brand carries one: as the response
    /// to /v3/channels there is no other id in the document, and under x-profile-id
    /// this is the profile the call resolved to rather than the caller. Absent when
    /// nested inside a sender profile, whose own id already says whose they are.
    /// </summary>
    public string? CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    /// <summary>
    /// The markets this profile can send MMS in, one entry per country, or empty
    /// when none.              Appears alongside sms rather than replacing an entry
    /// in it: the two are separate senders on the same number and a caller needs
    /// to see both — a market can be live for SMS while its MMS row is still provisioning,
    /// or MMS-incapable entirely because the market's sender-type SKU does not carry it.
    /// </summary>
    public IReadOnlyList<MmsMarket>? Mms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MmsMarket>>("mms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<MmsMarket>?>(
                "mms",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// An RCS agent as its owner sees it: the order form back, plus where the submission
    /// stands.              Not RcsSenderResponse. That one is the admin projection
    /// and carries the pipeline we track about a customer's request — internalStatus,
    /// statusReason, isLaunched — and the S3 keys behind the assets. None of that
    /// is the customer's to read: an internal status is a note to ourselves, and
    /// an S3 key is a storage detail that would become a contract the moment it was
    /// published.              What is here is what the caller sent, in the names
    /// it sent them under, plus the three things only we can answer: the record's
    /// id, its status, and the number it sends from. So a read after a write shows
    /// the form as stored rather than as echoed.
    /// </summary>
    public RcsAgent? Rcs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RcsAgent>("rcs");
        }
        init { this._rawData.Set("rcs", value); }
    }

    public IReadOnlyList<SmsMarket>? Sms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SmsMarket>>("sms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SmsMarket>?>(
                "sms",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The numbers this profile carries phone calls on, one entry per number, or
    /// empty when none. Voice is per number like an SMS market is per country: each
    /// number is its own channel row, turned on and off on its own, and one of them
    /// is the line app-originated calls fall back to.
    /// </summary>
    public IReadOnlyList<VoiceNumber>? Voice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<VoiceNumber>>("voice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<VoiceNumber>?>(
                "voice",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The profile's WhatsApp account. Its status is Meta's verification state.
    /// </summary>
    public WhatsappChannel? Whatsapp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappChannel>("whatsapp");
        }
        init { this._rawData.Set("whatsapp", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CustomerID;
        foreach (var item in this.Mms ?? [])
        {
            item.Validate();
        }
        this.Rcs?.Validate();
        foreach (var item in this.Sms ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Voice ?? [])
        {
            item.Validate();
        }
        this.Whatsapp?.Validate();
    }

    public ChannelsState() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelsState(ChannelsState channelsState)
        : base(channelsState) { }
#pragma warning restore CS8618

    public ChannelsState(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelsState(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelsStateFromRaw.FromRawUnchecked"/>
    public static ChannelsState FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelsStateFromRaw : IFromRawJson<ChannelsState>
{
    /// <inheritdoc/>
    public ChannelsState FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelsState.FromRawUnchecked(rawData);
}
