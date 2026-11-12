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
    /// What this programme sends. TCR description: what recipients will get and why,
    /// in a sentence. The only one of these TCR takes verbatim as a description
    /// of the programme, which is why it is asked for rather than derived from the
    /// customer's name. Required when `compliance.campaign.inherit != true`.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    /// <summary>
    /// Help keywords. TCR helpKeywords, comma separated, e.g. HELP,INFO. Required
    /// when `compliance.campaign.inherit != true`.
    /// </summary>
    public string? HelpKeywords
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("help_keywords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("help_keywords", value);
        }
    }

    /// <summary>
    /// Help reply. TCR helpMessage. Its presence is what sets subscriberHelp. Required
    /// when `compliance.campaign.inherit != true`.
    /// </summary>
    public string? HelpMessage
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("help_message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("help_message", value);
        }
    }

    /// <summary>
    /// Consent narrative. TCR messageFlow: how recipients opt in, in prose. Under
    /// 40 characters is refused, and carriers reject vague descriptions — say where
    /// opt-in happens, that the box is unchecked by default, and that consent is
    /// not a condition of purchase. Required when `compliance.campaign.inherit != true`.
    /// </summary>
    public string? MessageFlow
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("message_flow");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("message_flow", value);
        }
    }

    /// <summary>
    /// Opt-in keywords. TCR optinKeywords, comma separated, e.g. START,YES. Required
    /// when `compliance.campaign.inherit != true`.
    /// </summary>
    public string? OptInKeywords
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("opt_in_keywords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("opt_in_keywords", value);
        }
    }

    /// <summary>
    /// Opt-in confirmation. TCR optinMessage. Should state message frequency and
    /// that rates may apply. Its presence is what sets subscriberOptin. Required
    /// when `compliance.campaign.inherit != true`.
    /// </summary>
    public string? OptInMessage
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("opt_in_message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("opt_in_message", value);
        }
    }

    /// <summary>
    /// Opt-out keywords. TCR optoutKeywords, comma separated. STOP, END, CANCEL,
    /// UNSUBSCRIBE and QUIT are honoured regardless of what is declared. Required
    /// when `compliance.campaign.inherit != true`.
    /// </summary>
    public string? OptOutKeywords
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("opt_out_keywords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("opt_out_keywords", value);
        }
    }

    /// <summary>
    /// Opt-out confirmation. TCR optoutMessage. Its presence is what sets subscriberOptout.
    /// Required when `compliance.campaign.inherit != true`.
    /// </summary>
    public string? OptOutMessage
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("opt_out_message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("opt_out_message", value);
        }
    }

    /// <summary>
    /// Privacy policy URL. TCR privacyPolicyLink. Required when `compliance.campaign.inherit
    /// != true`.
    /// </summary>
    public string? PrivacyPolicyLink
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("privacy_policy_link");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("privacy_policy_link", value);
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
    /// Terms and conditions URL. TCR termsAndConditionsLink. Required when `compliance.campaign.inherit
    /// != true`.
    /// </summary>
    public string? TermsAndConditionsLink
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("terms_and_conditions_link");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("terms_and_conditions_link", value);
        }
    }

    /// <summary>
    /// Use cases. What the campaign sends, and an example of each. One to five entries;
    /// how they register is decided by volume, never declared. Required when `compliance.campaign.inherit
    /// != true`.
    /// </summary>
    public IReadOnlyList<TenDlcCampaignUseCase>? UseCases
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<TenDlcCampaignUseCase>>(
                "use_cases"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<TenDlcCampaignUseCase>?>(
                "use_cases",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Expected monthly volume. Decides how the campaign registers and which fee
    /// tier applies: below the low-volume threshold it registers as LOW_VOLUME with
    /// sub-use-cases, above it as a single use case or MIXED. Omitting it registers
    /// the campaign at the higher-fee standard tier.
    /// </summary>
    public string? Volume
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("volume");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("volume", value);
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
