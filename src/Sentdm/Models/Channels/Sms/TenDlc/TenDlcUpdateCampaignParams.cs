using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Sms.TenDlc;

/// <summary>
/// Changes **one campaign of your own** on the US `TEN_DLC` market, named by its
/// `id` in the market's `compliance.campaigns`.
///
/// <para>## What to send</para>
///
/// <para>The fields to change, at the top level of the body, under the `compliance.campaign.*`
/// keys `GET /v3/compliance/requirements?country=US&amp;type=TEN_DLC` lists, without
/// that prefix. A field you leave out keeps its value, and a rejected one is keyed
/// by its name. `id` and `"inherit": false` are ignored, so an entry of `compliance.campaigns`
/// can be sent as read; `"inherit": true` is `400`, because this call changes a campaign's
/// fields, not whose campaign you run on. The campaign only: add numbers with `POST
/// /v3/channels/sms/numbers/US/TEN_DLC`, and change the brand or documents with
/// `PATCH /v3/channels/sms/US/TEN_DLC`.</para>
///
/// <para>## When it can be changed</para>
///
/// <para>Until it is filed with The Campaign Registry, and again when we ask you
/// to correct it. That correction sends it back for review. A filed campaign is
/// otherwise `409`, and so is a change between low and high volume once it is registered.
/// A campaign you run on from your organization is `409` too: it is the organization's
/// to change. So is one out of service: expired, deactivated or released.</para>
///
/// <para>Returns **the market**, in the shape `GET /v3/channels/sms/US/TEN_DLC` returns.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TenDlcUpdateCampaignParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CampaignID { get; init; }

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

    public TenDlcUpdateCampaignParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TenDlcUpdateCampaignParams(TenDlcUpdateCampaignParams tenDlcUpdateCampaignParams)
        : base(tenDlcUpdateCampaignParams)
    {
        this.CampaignID = tenDlcUpdateCampaignParams.CampaignID;

        this._rawBodyData = new(tenDlcUpdateCampaignParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TenDlcUpdateCampaignParams(
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
    TenDlcUpdateCampaignParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string campaignID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CampaignID = campaignID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TenDlcUpdateCampaignParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string campaignID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            campaignID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CampaignID"] = JsonSerializer.SerializeToElement(this.CampaignID),
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

    public virtual bool Equals(TenDlcUpdateCampaignParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CampaignID?.Equals(other.CampaignID) ?? other.CampaignID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v3/channels/sms/compliances/US/TEN_DLC/campaigns/{0}",
                    this.CampaignID
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
