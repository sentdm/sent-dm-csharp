using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Channels.Sms;

namespace Sentdm.Models.SenderProfiles;

/// <summary>
/// One SMS market a profile sends in — a country and a sender type.
///  A profile may have several. It is a tenant, not a market: a business sending
/// to two countries is one customer of yours, and forcing it into two profiles would
/// give it two API keys, two inboxes and two contact lists for one business. The
/// platform already assumes many — CustomerChannelProviders is unique on (customer,
/// channel, iso, number).              No mode: a sender is the profile's own or
/// it has none. Listing a market is the request for one.              Also the discriminator
/// for everything else: the compliance catalog is keyed on (country, number type),
/// and that pair decides which fields brand accepts and what compliance is asked for.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SenderProfileSms, SenderProfileSmsFromRaw>))]
public sealed record class SenderProfileSms : JsonModel
{
    /// <summary>
    /// ISO 3166-1 alpha-2 country the sender operates in, e.g. US.
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
    /// The area codes to put this sender in, in your own order of preference, e.g.
    /// ["415", "628"] for the US or ["20"] for London. Omit it and a number is claimed
    /// anywhere in the country.              Ordered, and the order is the request.
    /// The claim tries each code in turn and stops at the first that yields a number.
    /// Nothing sorts the list and a code listed twice is refused.              One
    /// to fifty entries, each the area code as digits: 415, with the trunk prefix
    /// as 020, or with the country's dialing prefix as +1415 (all are stored as
    /// the bare code). A dialing prefix from a different country than country is
    /// refused. Each code is checked against the country's numbering plan: it must
    /// start real local or mobile numbers there, so toll-free and premium ranges,
    /// service codes and another country's codes are refused with a reason.
    ///          LOCAL senders in any country, and US TEN_DLC senders. No other sender
    /// type has a geographic area code, and the list is refused with one rather
    /// than accepted and dropped.              Honoured exactly or not at all. Ask
    /// for 415 and you get a 415 number or you get none, never a neighbouring code
    /// you did not name. A miss leaves the market with no sender yet and the codes
    /// recorded on it, so it is filled when stock appears rather than filled now
    /// from somewhere else. Many countries outside North America require address
    /// or business documents before a local number can be bought, which can delay
    /// or prevent the fill.
    /// </summary>
    public IReadOnlyList<string>? AreaCodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("area_codes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "area_codes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Sender type: LOCAL, MOBILE, TEN_DLC, TOLL_FREE, SHORT_CODE or ALPHANUMERIC.
    /// 10DLC is accepted as a synonym of TEN_DLC. Availability varies by country.
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
    /// The numbers to assign, one entry per area code, e.g. [{"area_code": "212",
    /// "quantity": 2}, {"area_code": "415"}, {"quantity": 1}]: two numbers in 212,
    /// one in 415 and one in any area code. quantity defaults to 1, and an entry
    /// without area_code means any area code. Omit numbers for one number.
    ///        Only with LOCAL or TEN_DLC, and not together with area_codes. Each
    /// area code is validated against country the same way area_codes is and may
    /// appear once, and at most one entry may leave area_code out. US TEN_DLC numbers
    /// are assigned when the campaign is approved, not at request time. Not available
    /// when the profile inherits the organization's campaign.
    /// </summary>
    public IReadOnlyList<SmsNumberRequest>? Numbers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SmsNumberRequest>>("numbers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SmsNumberRequest>?>(
                "numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The sender's identity, where the caller chooses it rather than the carrier
    /// assigning it. Required when number_type is ALPHANUMERIC; omit for carrier-assigned
    /// types and one is provisioned.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.AreaCodes;
        _ = this.NumberType;
        foreach (var item in this.Numbers ?? [])
        {
            item.Validate();
        }
        _ = this.SenderValue;
    }

    public SenderProfileSms() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderProfileSms(SenderProfileSms senderProfileSms)
        : base(senderProfileSms) { }
#pragma warning restore CS8618

    public SenderProfileSms(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderProfileSms(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SenderProfileSmsFromRaw.FromRawUnchecked"/>
    public static SenderProfileSms FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SenderProfileSms(string country)
        : this()
    {
        this.Country = country;
    }
}

class SenderProfileSmsFromRaw : IFromRawJson<SenderProfileSms>
{
    /// <inheritdoc/>
    public SenderProfileSms FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SenderProfileSms.FromRawUnchecked(rawData);
}
