using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Sms.TenDlc;

/// <summary>
/// Adds numbers to **one campaign of your own** on the US `TEN_DLC` market you hold,
/// named by `campaign_id` — the `id` of an entry in the market's `compliance.campaigns`.
///
/// <para>## What to send</para>
///
/// <para>- `campaign_id` — the campaign. One you inherit from your organization is
/// `400`: its numbers are the organization's. One out of service — expired, deactivated
/// or released — is `409`. - `numbers` — the list `POST /v3/channels/sms` takes,
/// one entry per area code.</para>
///
/// <para>## What happens</para>
///
/// <para>The entries are **added** to what the campaign already asks for. With everything
/// it asks for, a campaign holds at most 49 numbers, counting one for each sender
/// profile inheriting it. A campaign the carriers have not approved yet gets its
/// numbers when they do; an approved one gets them now. Until a number is assigned
/// it reads as `PROVISIONING` in the market's `numbers`, with the area code it was
/// asked for.</para>
///
/// <para>Returns **the market**, in the shape `GET /v3/channels/sms/US/TEN_DLC`
/// returns, with `202`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TenDlcAddNumbersParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The campaign to add the numbers to, as compliance.campaigns[].id reports
    /// it. Required.
    /// </summary>
    public required string CampaignID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("campaign_id");
        }
        init { this._rawBodyData.Set("campaign_id", value); }
    }

    /// <summary>
    /// The numbers to add, one entry per area code, e.g. [{"area_code": "415", "quantity":
    /// 2}, {"quantity": 1}]. quantity defaults to 1, and an entry without area_code
    /// means any area code. Required.              Added to what the campaign already
    /// asks for, never replacing it.
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

    public TenDlcAddNumbersParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TenDlcAddNumbersParams(TenDlcAddNumbersParams tenDlcAddNumbersParams)
        : base(tenDlcAddNumbersParams)
    {
        this._rawBodyData = new(tenDlcAddNumbersParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TenDlcAddNumbersParams(
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
    TenDlcAddNumbersParams(
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
    public static TenDlcAddNumbersParams FromRawUnchecked(
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

    public virtual bool Equals(TenDlcAddNumbersParams? other)
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v3/channels/sms/numbers/US/TEN_DLC"
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
