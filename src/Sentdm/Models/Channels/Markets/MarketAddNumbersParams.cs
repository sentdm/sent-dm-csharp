using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Sms;

namespace Sentdm.Models.Channels.Markets;

/// <summary>
/// Adds numbers to a market you hold. They are **added** to what it already asks
/// for, never replacing it — with one exception: a US `TEN_DLC` campaign opened
/// without `numbers` asks for one number in any area code by default, and while
/// it holds no number yet, the first numbers added replace that default. Once it
/// holds one, they are added beside it.
///
/// <para>## Where they go</para>
///
/// <para>- **SMS US `TEN_DLC`**: to **one campaign of your own**, named by `campaign_id`
/// — the `id` of an entry in the market's `compliance.campaigns` (`GET /v3/channels/sms/US/TEN_DLC`).
/// Required: left out it is `400` naming your campaigns in service. One you inherit
/// from your organization is `400`: its numbers are the organization's. One out of
/// service — expired, deactivated or released — is `409`. A campaign the carriers
/// have not approved yet gets its numbers when they do; an approved one gets them
/// now. With everything it asks for, a campaign holds at most 49 numbers, counting
/// one for each sender profile inheriting it. - **`LOCAL`**: to the market, claimed
/// from inventory now; what inventory cannot cover stays pending. No `campaign_id`.
/// A market holds at most 49 numbers. - **Any other sender type** takes no numbers: `400`.</para>
///
/// <para>## What to send</para>
///
/// <para>`numbers` — the list `POST /v3/channels/sms` takes, one entry per area code
/// — and, on US `TEN_DLC`, `campaign_id`, required.</para>
///
/// <para>Until a number is assigned it reads as `PROVISIONING` in the market's `numbers`,
/// with the area code it was asked for. Returns **the market**, in the shape `GET
/// /v3/channels/sms/{country}/{type}` returns, with `202`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MarketAddNumbersParams : ParamsBase
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
    /// The numbers, one entry per area code, e.g. [{"area_code": "415", "quantity":
    /// 2}, {"quantity": 1}]. quantity defaults to 1, and an entry without area_code
    /// means any area code. Required.              POST adds them to what the market
    /// or campaign already asks for; PATCH replaces that list with them, and has
    /// to cover every number already held, since none is ever released.
    /// </summary>
    public required IReadOnlyList<SmsNumberRequest?> Numbers
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<SmsNumberRequest?>>("numbers");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<SmsNumberRequest?>>(
                "numbers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string IdempotencyKey
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNotNullClass<string>("Idempotency-Key");
        }
        init { this._rawHeaderData.Set("Idempotency-Key", value); }
    }

    /// <summary>
    /// The campaign to add the numbers to, as campaigns[].id reports it. Required
    /// on SMS US TEN_DLC, where every number belongs to a campaign; refused on a
    /// market without campaigns.
    /// </summary>
    public string? CampaignID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("campaign_id");
        }
        init { this._rawBodyData.Set("campaign_id", value); }
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

    public MarketAddNumbersParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MarketAddNumbersParams(MarketAddNumbersParams marketAddNumbersParams)
        : base(marketAddNumbersParams)
    {
        this.Channel = marketAddNumbersParams.Channel;
        this.Country = marketAddNumbersParams.Country;
        this.Type = marketAddNumbersParams.Type;

        this._rawBodyData = new(marketAddNumbersParams._rawBodyData);
    }
#pragma warning restore CS8618

    public MarketAddNumbersParams(
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
    MarketAddNumbersParams(
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
    public static MarketAddNumbersParams FromRawUnchecked(
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

    public virtual bool Equals(MarketAddNumbersParams? other)
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
                + string.Format(
                    "/v3/channels/{0}/{1}/{2}/numbers",
                    this.Channel,
                    this.Country,
                    this.Type
                )
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
