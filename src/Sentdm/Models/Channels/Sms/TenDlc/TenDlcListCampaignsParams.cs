using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Sms.TenDlc;

/// <summary>
/// Every campaign your US `TEN_DLC` market registers, oldest first, each with its
/// `id`, where it stands and `inherit` (`true` for your organization's) beside its
/// fields — the list `GET /v3/channels/sms/US/TEN_DLC` reports under `compliance.campaigns`.
/// Add one with `POST` on this path, and change one of your own with `PATCH /v3/channels/sms/US/TEN_DLC/campaigns/{id}`.
///
/// <para>Each campaign has a `status` of its own, so a market on several says which
/// is approved: `ACTIVE` once the carriers have elected it, `PENDING_REVIEW` until
/// then, `ACTION_NEEDED` when it came back for correction, `DECLINED` when the carriers
/// refused it, `INACTIVE` once it has ended. Why the market is held up is the market's
/// own `reason`, which names the campaign concerned. `status` is read-only and ignored
/// when the entry is sent back.</para>
///
/// <para>A customer without a US `TEN_DLC` market is `404`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TenDlcListCampaignsParams : ParamsBase
{
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

    public TenDlcListCampaignsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TenDlcListCampaignsParams(TenDlcListCampaignsParams tenDlcListCampaignsParams)
        : base(tenDlcListCampaignsParams) { }
#pragma warning restore CS8618

    public TenDlcListCampaignsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenDlcListCampaignsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TenDlcListCampaignsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TenDlcListCampaignsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v3/channels/sms/US/TEN_DLC/campaigns"
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
