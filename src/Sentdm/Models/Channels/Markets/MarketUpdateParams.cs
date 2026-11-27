using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Sms;

namespace Sentdm.Models.Channels.Markets;

/// <summary>
/// Supplies the market's identity and documents, and answers with the market as
/// stored — the same shape `GET` on this path returns.
///
/// <para>| To change | Send | | --- | --- | | a `brand` value (US `TEN_DLC`) | `compliance.brand`,
/// as below | | a registration sent back for correction | `compliance.brand` — the
/// identity is accepted even once filed, and the registration goes back for review
/// | | a document, in any market | a multipart file named after the document's key
/// | | a campaign | `PATCH /v3/channels/sms/US/TEN_DLC/campaigns/{id}` — `compliance.campaign`
/// here is `400` | | the numbers | `POST /v3/channels/{channel}/{country}/{type}/numbers`
/// — `numbers` here is `400` |</para>
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
/// <para>| Body | Effect | | --- | --- | | `"brand": { … }` | supplies or corrects
/// the identity, and takes one of your own | | `"brand": { "inherit": true }` | runs
/// on your organization's, giving up your own | | `"brand": null` | the same thing,
/// said the short way | | key omitted | left exactly as it is |</para>
///
/// <para>The brand read on this path, its `id` and `vetting` included, can be sent
/// back unchanged: both are read-only and ignored.</para>
///
/// <para>## Every other market</para>
///
/// <para>Markets that register with no regime have no brand, so `compliance` is
/// `400` there. Their compliance is documents, sent here as multipart.</para>
///
/// <para>## Documents</para>
///
/// <para>Send `multipart/form-data` with **each file named after the compliance key
/// it satisfies** — the key `GET /v3/channels/{channel}/{country}/compliance` lists.
/// A file that matches no document the market asks for is `400` naming the keys that
/// would, and a file the upload rules refuse (empty, too large, an unsupported type)
/// is `422`. `compliance` may ride in the same form as a text part holding its JSON.</para>
///
/// <para>## What it will refuse</para>
///
/// <para>**A filed identity is `409`.** Once the registration has gone to The Campaign
/// Registry they hold a copy, and a local change would diverge from it silently.
/// The exception is a registration sent back for correction: the identity is accepted,
/// and the registration goes back for review. Refiling it with The Campaign Registry
/// stays with Sent.</para>
///
/// <para>Nothing is submitted to a regime here. Send `x-profile-id` with an organization
/// key to write one of your profiles' markets.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MarketUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string Channel { get; init; }

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

    public MarketUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MarketUpdateParams(MarketUpdateParams marketUpdateParams)
        : base(marketUpdateParams)
    {
        this.Channel = marketUpdateParams.Channel;
        this.Country = marketUpdateParams.Country;
        this.Type = marketUpdateParams.Type;

        this._rawBodyData = new(marketUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public MarketUpdateParams(
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
    MarketUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string channel,
        string country,
        string type
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.Channel = channel;
        this.Country = country;
        this.Type = type;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MarketUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string channel,
        string country,
        string type
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            channel,
            country,
            type
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["Channel"] = JsonSerializer.SerializeToElement(this.Channel),
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

    public virtual bool Equals(MarketUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.Channel.Equals(other.Channel)
            && this.Country.Equals(other.Country)
            && (this.Type?.Equals(other.Type) ?? other.Type == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/channels/{0}/{1}/{2}", this.Channel, this.Country, this.Type)
        )
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
