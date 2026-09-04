using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;

namespace Sentdm.Models.Me;

/// <summary>
/// Returns the account associated with the provided API key. The response includes
/// account identity, contact information, messaging channel configuration, and —
/// depending on the account type — either a list of child profiles or the profile's
/// own settings.
///
/// <para>**Account types:** - `organization` — Has child profiles. The `profiles`
/// array is populated. - `user` — Standalone account with no profiles. - `profile`
/// — Child of an organization. Includes `organization_id`, `short_name`, `status`,
/// and `settings`.</para>
///
/// <para>**Channels:** The `channels` object always includes `sms`, `whatsapp`,
/// and `rcs`. Each channel has a `configured` boolean. Configured channels expose
/// additional details such as `phone_number`.</para>
///
/// <para>**Sending number:** `sending_phone_number` is the account's US SMS sender.
/// It is intentionally the same value as `channels.sms.phone_number` — the two are
/// kept in step, and it is published under both names because `sending_phone_number`
/// is what this value is called on `GET /v3/profiles`. Read either. One difference:
/// `sending_phone_number` is always present, including as `null`, while `channels.sms.phone_number`
/// is omitted when there is no sender.</para>
///
/// <para>`sending_phone_number_profile_id` names the account that holds that number
/// in inventory — normally this account, and a different one where a number is shared.
/// Both are `null` when the account has no US SMS sender.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MeRetrieveParams : ParamsBase
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

    public MeRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeRetrieveParams(MeRetrieveParams meRetrieveParams)
        : base(meRetrieveParams) { }
#pragma warning restore CS8618

    public MeRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MeRetrieveParams FromRawUnchecked(
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

    public virtual bool Equals(MeRetrieveParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/me")
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
