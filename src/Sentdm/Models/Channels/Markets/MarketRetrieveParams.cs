using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Markets;

/// <summary>
/// Reads one market you send in — its sender, where that sender stands, and everything
/// its compliance holds.
///
/// <para>## What `compliance` carries</para>
///
/// <para>A market that registers with a compliance regime reports `brand` — the
/// identity the registration is filed against — and `campaign`, the programme filed
/// against it. Each carries `inherit`, saying whether it is yours or your organization's.</para>
///
/// <para>`compliance.brand.vetting` is the brand's external vetting at The Campaign
/// Registry, read-only: `score` (0-100, the figure US carriers set 10DLC throughput
/// by), `status` (`PENDING`, `UNSCORE`, `ACTIVE`, `FAILED` or `EXPIRED`; carriers
/// read the score of an `ACTIVE` vet only), `vetted_at` and `expires_at`. It is
/// `null` while no vetting record is held for the brand, and `score` is `null` for
/// a vet that has none yet. A profile on your organization's brand reads your organization's vetting.</para>
///
/// <para>A market that registers with nobody has neither, so **both keys are absent**
/// rather than null: absent says this market does not ask, where null would say it
/// asks and you supplied nothing. It reports `documents` instead.</para>
///
/// <para>`GET /v3/compliance/requirements` says what a market demands of any new
/// customer; this says what you gave it.</para>
///
/// <para>## Writing it back</para>
///
/// <para>**`PATCH` this same path**, with the `compliance` object from this response:</para>
///
/// <para>```json { "compliance": { "brand": { "tax_id": "12-3456789" } } } ```</para>
///
/// <para>Nothing else to learn — what comes back can be sent back, an omitted key
/// is left alone. There is no sub-resource for either half: both are singletons
/// of the market, so both are written here.</para>
///
/// <para>`GET /v3/compliance/requirements` says what a market demands of anybody;
/// this says what you gave it.</para>
///
/// <para>Send `x-profile-id` with an organization key to read one of your profiles' markets.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MarketRetrieveParams : ParamsBase
{
    public required string Channel { get; init; }

    public required string Country { get; init; }

    public string? Type { get; init; }

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

    public MarketRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MarketRetrieveParams(MarketRetrieveParams marketRetrieveParams)
        : base(marketRetrieveParams)
    {
        this.Channel = marketRetrieveParams.Channel;
        this.Country = marketRetrieveParams.Country;
        this.Type = marketRetrieveParams.Type;
    }
#pragma warning restore CS8618

    public MarketRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MarketRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string channel,
        string country,
        string type
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.Channel = channel;
        this.Country = country;
        this.Type = type;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MarketRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string channel,
        string country,
        string type
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(MarketRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.Channel.Equals(other.Channel)
            && this.Country.Equals(other.Country)
            && (this.Type?.Equals(other.Type) ?? other.Type == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
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
