using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Sms;

/// <summary>
/// Supplies whatever this market is waiting on, and answers with the market as stored
/// — the same shape `GET` on this path returns, so **what comes back can be sent back**.
///
/// <para>**A market reporting `ACTION_NEEDED` is fixed here**, whatever it is waiting on:</para>
///
/// <para>| Outstanding | Send | | --- | --- | | a `brand` or `campaign` value (US
/// `TEN_DLC`) | `compliance`, as below | | a document, in any market | a multipart
/// file named after the document's key | | a registration sent back for correction
/// | `compliance.brand` and/or `compliance.campaign` — the identity is accepted even
/// once filed, and the registration goes back for review | | different numbers |
/// `numbers`, the list the market asks for from now on |</para>
///
/// <para>## Partial, at every level</para>
///
/// <para>**An omitted key is left alone. An explicit `null` clears it.** Those are
/// different requests, so `{}` changes nothing and is refused rather than silently
/// accepted, and correcting one field does not blank the others.</para>
///
/// <para>```json { "compliance": { "brand": { "contact_phone": "+12125550123" } }
/// } ```</para>
///
/// <para>That leaves the campaign untouched, along with every other field of the identity.</para>
///
/// <para>## What a US `TEN_DLC` market holds</para>
///
/// <para>Two halves, both singular: `brand`, the identity the registration is filed
/// against, and `campaign`, the programme filed against it. Each carries `inherit`.</para>
///
/// <para>| Body | Effect | | --- | --- | | `"brand": { … }` | supplies or corrects
/// the identity, and takes one of your own | | `"brand": { "inherit": true }` | runs
/// on your organization's, giving up your own | | `"brand": null` | the same thing,
/// said the short way | | `"campaign": { … }` | supplies or corrects the programme,
/// and takes one of your own | | `"campaign": { "inherit": true }` | runs on your
/// organization's | | key omitted | left exactly as it is |</para>
///
/// <para>**Nothing here creates a second anything.** One identity and one campaign
/// per market, so a write is an upsert and a replayed request lands on the row it
/// already wrote. Sending the campaign twice does not file two registrations.</para>
///
/// <para>## Every other market</para>
///
/// <para>Markets that register with no regime have neither half, so `compliance`
/// is `400` there. Their compliance is documents, sent here as multipart.</para>
///
/// <para>## Documents</para>
///
/// <para>Send `multipart/form-data` with **each file named after the compliance key
/// it satisfies** — the key the market's `requirements` names. A file that matches
/// no document the market asks for is `400` naming the keys that would, and a file
/// the upload rules refuse (empty, too large, an unsupported type) is `422`. `compliance`
/// and `numbers` may ride in the same form as text parts holding their JSON.</para>
///
/// <para>## Numbers</para>
///
/// <para>`numbers` takes the list `POST /v3/channels/sms` takes, for a `LOCAL` or
/// `TEN_DLC` market, and **replaces** what the market asks for — send the list you
/// want, not a difference. Numbers already assigned stay; a list that leaves one
/// of them out is `400`, because nothing here releases a number.</para>
///
/// <para>```json { "numbers": [ { "area_code": "415", "quantity": 2 }, { "quantity":
/// 1 } ] } ```</para>
///
/// <para>A `LOCAL` market is claimed from inventory at once, and whatever inventory
/// cannot cover stays pending. A `TEN_DLC` market's numbers are recorded on its
/// campaign and assigned once the carriers elect it — on the next acquisition cycle
/// when it already has been. They need a campaign of the profile's own: one inherited
/// from the organization is `400`.</para>
///
/// <para>## What it will refuse</para>
///
/// <para>**A filed identity is `409`.** Once the registration has gone to The Campaign
/// Registry they hold a copy, and a local change would diverge from it silently.
/// The campaign is not frozen — omit `brand` and the same body is accepted. The
/// exception is a registration sent back for correction: the identity is accepted,
/// and a correction to either half sends the registration back for review. Refiling
/// it with The Campaign Registry stays with Sent.</para>
///
/// <para>**More than one campaign is `409`.** The schema permits several and an
/// account built on the admin side may hold them; this surface writes one, and editing
/// whichever sorted first would leave the others unmentioned and unedited.</para>
///
/// <para>Nothing is submitted to a regime here. These are the rows a submission is
/// later assembled from, which is what lets them be corrected without waiting on
/// something externally rejectable.</para>
///
/// <para>Send `x-profile-id` with an organization key to write one of your profiles' markets.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SmsUpdateParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string Country { get; init; }

    public string? Type { get; init; }

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

    public SmsUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SmsUpdateParams(SmsUpdateParams smsUpdateParams)
        : base(smsUpdateParams)
    {
        this.Country = smsUpdateParams.Country;
        this.Type = smsUpdateParams.Type;

        this._rawBodyData = new(smsUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SmsUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SmsUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData,
        string country,
        string type
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.Country = country;
        this.Type = type;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SmsUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData,
        string country,
        string type
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            country,
            type
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, MultipartJsonElement>()
                {
                    ["Country"] = JsonSerializer.SerializeToElement(this.Country),
                    ["Type"] = JsonSerializer.SerializeToElement(this.Type),
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

    public virtual bool Equals(SmsUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.Country.Equals(other.Country)
            && (this.Type?.Equals(other.Type) ?? other.Type == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/channels/sms/{0}/{1}", this.Country, this.Type)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return MultipartJsonSerializer.Serialize(RawBodyData);
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
