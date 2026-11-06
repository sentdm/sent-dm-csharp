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
using Sentdm.Exceptions;

namespace Sentdm.Models.Channels.Sms;

/// <summary>
/// Gives the customer a sender in one country — the first market it sends in, and
/// the fifth.
///
/// <para>## What to have in place first</para>
///
/// <para>**Call `GET /v3/compliance/requirements?country=US&amp;type=TEN_DLC` first.**
/// It returns this request's body ready to fill in, plus the brand and campaign
/// calls to make before it, in order. You never have to track forty countries' rules yourself.</para>
///
/// <para>**A market that registers with a compliance regime needs an identity, and
/// this call takes one.** US `TEN_DLC` registers with The Campaign Registry and
/// files that registration against a business identity. Send it in `compliance.brand`
/// and it is recorded here, before the registration that attaches to it — so a customer
/// with no identity reaches a first 10DLC market in one call.</para>
///
/// <para>`{ "inherit": true }` runs on your organization's instead. A market with
/// neither — none stored, none sent — is `400`, because accepting it would write
/// a channel that could never register and leave it provisioning for ever with nothing
/// saying why.</para>
///
/// <para>**Everything the regime wants arrives in this request's `compliance`**,
/// as two declared objects: `brand` — the identity the registration is filed against
/// — and `campaign`, with the use case, the consent narrative, the volume, the sample
/// messages and the keywords. There is nothing to set up first. Nothing is submitted
/// here either: the rows are what a submission is later assembled from, and filing
/// is externally rejectable so it happens on its own path.</para>
///
/// <para>**A half you run yourself has to be complete here.** Whichever of `brand`
/// and `campaign` is your own rather than your organization's must carry every field
/// the regime asks of it, counting what you already hold — send the rest in this
/// request. A missing one is `400` naming each field, rather than a `202` for a market
/// that could never be filed. A half you inherit is asked for nothing.</para>
///
/// <para>A market that registers with nobody — an alphanumeric sender in most countries
/// — needs neither, and may need documents instead.</para>
///
/// <para>## Sending it</para>
///
/// <para>Takes the same fields `channels.sms` takes on `POST /v3/sender-profiles`,
/// because it is the same work, and both run one provisioning path. `compliance`
/// is top-level and answers for the market in this request, carrying `brand` and
/// `campaign` where the market registers.</para>
///
/// <para>**Accepts multipart as well as JSON**, with each file named after the compliance
/// key it satisfies — a market that pre-registers its sender needs its documents
/// at the same moment it needs the sender. Every required document must be attached
/// to this request; a missing or invalid file is rejected before the market is added.</para>
///
/// <para>**`area_codes` puts the sender somewhere specific**, in your order of preference,
/// for a `LOCAL` sender in any country or a US `TEN_DLC` sender — a 10DLC number
/// is an ordinary local long code bound to a registered campaign, so both take the
/// same codes out of the same inventory. It is honoured exactly: you get a number
/// in one of the codes you named or you get none, never one in a code you left out.</para>
///
/// <para>## Several numbers</para>
///
/// <para>**`numbers` lists the numbers you want, one entry per area code**, e.g.
/// `[{"area_code": "212", "quantity": 2}, {"quantity": 1}]` for two numbers in 212
/// and one in any area code. `quantity` defaults to 1, and an entry without `area_code`
/// means any area code. Omit `numbers` for one number. It is for `LOCAL` and `TEN_DLC`
/// only and cannot be combined with `area_codes`. A market holds at most 49 numbers,
/// counting the ones it already has.</para>
///
/// <para>**On a `LOCAL` market you already hold, `numbers` adds those numbers to
/// it** instead of `409`. US `TEN_DLC` numbers belong to the market's campaign and
/// are assigned when the campaign is approved, not at request time. Until then they
/// read as `PROVISIONING` in the response's `numbers`, each with the area code it
/// was asked for. A profile inheriting your organization's campaign cannot request
/// `numbers` (`400`). `numbers` on a `TEN_DLC` market you already hold is `409`:
/// its numbers belong to its one campaign and are set when the market is created.</para>
///
/// <para>**A market you already send in is `409`**: adding what is already there
/// is a mistake worth reporting rather than a silent no-op. A market is a `(country,
/// sender_type)` pair, so a **second sender type in a country you already send in
/// is fine** — `US TOLL_FREE` alongside `US TEN_DLC` is the ordinary case. Two of
/// the same type is not.</para>
///
/// <para>**A market you hold that has no sender yet is not a duplicate**, and re-sending
/// it re-asks for a sender rather than being refused. That is the way out of an area-code
/// request nothing could fill: send the call again to name different codes, or no
/// codes at all to take a number anywhere in the country. It answers `201` with the
/// sender when the pool has one, otherwise `202` with the codes recorded — and changes
/// nothing else; compliance on a market you hold is `PATCH /v3/channels/sms/{country}/{type}`.</para>
///
/// <para>One exception: while a market's sender type is still unassigned, adding
/// any type to that country is `409` once it has a sender, because the market you
/// have may be about to become the one you asked for.</para>
///
/// <para>Returns **the market**, in the shape `GET` and `PATCH` on `/v3/channels/sms/{country}/{type}`
/// use — so what this answers can be read back and written back without reshaping.
/// Not every channel you have: adding a market cannot change an RCS agent or a WhatsApp
/// account, and `GET /v3/channels` is the whole picture. `201` when the market is
/// ready; `202` while a sender or a registration is still outstanding.</para>
///
/// <para>Send `x-profile-id` with an organization key to add a market to one of your profiles.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SmsCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Sender type. Decides the provisioning flow and what compliance is asked for.
    ///              [Required] so the published document says so. The validator has
    /// always demanded it, but requiredness reached the schema by matching a rule
    /// to a property name — which works for country, whose wire name is its camel-cased
    /// C# name, and silently does not for number_type. A client generating a request
    /// from our OpenAPI therefore sent what the document called sufficient and was
    /// answered 400.
    /// </summary>
    public required ApiEnum<string, NumberType> NumberType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, NumberType>>("number_type");
        }
        init { this._rawBodyData.Set("number_type", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("area_codes");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "area_codes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The compliance values a market registers with. `brand` and `campaign` apply
    /// to US `TEN_DLC`; other markets fill this map with the document keys their
    /// own requirements name.
    /// </summary>
    public MarketCompliance? Compliance
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<MarketCompliance>("compliance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("compliance", value);
        }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country the sender operates in.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("country", value);
        }
    }

    /// <summary>
    /// The numbers to assign, one entry per area code, e.g. [{"area_code": "212",
    /// "quantity": 2}, {"area_code": "415"}, {"quantity": 1}]: two numbers in 212,
    /// one in 415 and one in any area code. quantity defaults to 1, and an entry
    /// without area_code means any area code. Omit numbers for one number.
    ///        Only with LOCAL or TEN_DLC, and not together with area_codes. Each
    /// area code is validated against country the same way area_codes is and may
    /// appear once, and at most one entry may leave area_code out. On a LOCAL market
    /// you already hold, this adds the numbers to it. US TEN_DLC numbers are assigned
    /// when the campaign is approved, not at request time. Not available when the
    /// profile inherits the organization's campaign.
    /// </summary>
    public IReadOnlyList<SmsNumberRequest>? Numbers
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<SmsNumberRequest>>("numbers");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<SmsNumberRequest>?>(
                "numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
    /// The sender's identity where the caller chooses it. Required when number_type
    /// is ALPHANUMERIC; optional for carrier-assigned types, which are procured afterwards.
    /// </summary>
    public string? SenderValue
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("sender_value");
        }
        init { this._rawBodyData.Set("sender_value", value); }
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

    public SmsCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SmsCreateParams(SmsCreateParams smsCreateParams)
        : base(smsCreateParams)
    {
        this._rawBodyData = new(smsCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SmsCreateParams(
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
    SmsCreateParams(
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
    public static SmsCreateParams FromRawUnchecked(
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

    public virtual bool Equals(SmsCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/channels/sms")
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
/// Sender type. Decides the provisioning flow and what compliance is asked for.
///              [Required] so the published document says so. The validator has
/// always demanded it, but requiredness reached the schema by matching a rule to
/// a property name — which works for country, whose wire name is its camel-cased
/// C# name, and silently does not for number_type. A client generating a request
/// from our OpenAPI therefore sent what the document called sufficient and was answered 400.
/// </summary>
[JsonConverter(typeof(NumberTypeConverter))]
public enum NumberType
{
    /// <summary>
    /// A geographic number for the country. The ordinary choice: recognisable to
    /// recipients, and available almost everywhere.
    /// </summary>
    Local,

    /// <summary>
    /// A toll-free number. High throughput and no per-country registration, but
    /// US toll-free traffic goes through its own verification.
    /// </summary>
    TollFree,

    /// <summary>
    /// A short code — five or six digits, leased rather than provisioned. Highest
    /// throughput, longest lead time, and the most expensive.
    /// </summary>
    ShortCode,

    /// <summary>
    /// A sender name rather than a number, up to 11 characters. Recipients cannot
    /// reply. Not available in every country, and several require it to be pre-registered
    /// with documents.
    /// </summary>
    Alphanumeric,

    /// <summary>
    /// A US 10-digit long code registered with The Campaign Registry. The only sender
    /// type that registers with a compliance regime, so it is the only one whose
    /// market declares `compliance.brand` and `compliance.campaign`.
    /// </summary>
    TenDlc,

    /// <summary>
    /// A mobile number. Where a country distinguishes it from a landline, some carriers
    /// treat mobile traffic differently.
    /// </summary>
    Mobile,

    /// <summary>
    /// The industry's spelling of `TEN_DLC`, accepted so an integrator can send the
    /// term it knows. Resolves to the same market.
    /// </summary>
    V10Dlc,
}

sealed class NumberTypeConverter : JsonConverter<NumberType>
{
    public override NumberType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "LOCAL" => NumberType.Local,
            "TOLL_FREE" => NumberType.TollFree,
            "SHORT_CODE" => NumberType.ShortCode,
            "ALPHANUMERIC" => NumberType.Alphanumeric,
            "TEN_DLC" => NumberType.TenDlc,
            "MOBILE" => NumberType.Mobile,
            "10DLC" => NumberType.V10Dlc,
            _ => (NumberType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NumberType.Local => "LOCAL",
                NumberType.TollFree => "TOLL_FREE",
                NumberType.ShortCode => "SHORT_CODE",
                NumberType.Alphanumeric => "ALPHANUMERIC",
                NumberType.TenDlc => "TEN_DLC",
                NumberType.Mobile => "MOBILE",
                NumberType.V10Dlc => "10DLC",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
