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
    public IReadOnlyList<TenDlcUpdateCampaignParamsUseCase>? UseCases
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<TenDlcUpdateCampaignParamsUseCase>
            >("use_cases");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<TenDlcUpdateCampaignParamsUseCase>?>(
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

[JsonConverter(
    typeof(JsonModelConverter<
        TenDlcUpdateCampaignParamsUseCase,
        TenDlcUpdateCampaignParamsUseCaseFromRaw
    >)
)]
public sealed record class TenDlcUpdateCampaignParamsUseCase : JsonModel
{
    /// <summary>
    /// Sample messages. TCR sample1..sample5 for this use case. One to five, each
    /// carrying the brand name and an opt-out instruction.
    /// </summary>
    public required IReadOnlyList<JsonElement> SampleMessages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JsonElement>>("sample_messages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JsonElement>>(
                "sample_messages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Use case. What this entry sends. MIXED and LOW_VOLUME are refused — volume
    /// decides those.
    /// </summary>
    public required ApiEnum<string, TenDlcUpdateCampaignParamsUseCaseUseCase> UseCase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TenDlcUpdateCampaignParamsUseCaseUseCase>
            >("use_case");
        }
        init { this._rawData.Set("use_case", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SampleMessages;
        this.UseCase.Validate();
    }

    public TenDlcUpdateCampaignParamsUseCase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TenDlcUpdateCampaignParamsUseCase(
        TenDlcUpdateCampaignParamsUseCase tenDlcUpdateCampaignParamsUseCase
    )
        : base(tenDlcUpdateCampaignParamsUseCase) { }
#pragma warning restore CS8618

    public TenDlcUpdateCampaignParamsUseCase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenDlcUpdateCampaignParamsUseCase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TenDlcUpdateCampaignParamsUseCaseFromRaw.FromRawUnchecked"/>
    public static TenDlcUpdateCampaignParamsUseCase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TenDlcUpdateCampaignParamsUseCaseFromRaw : IFromRawJson<TenDlcUpdateCampaignParamsUseCase>
{
    /// <inheritdoc/>
    public TenDlcUpdateCampaignParamsUseCase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TenDlcUpdateCampaignParamsUseCase.FromRawUnchecked(rawData);
}

/// <summary>
/// Use case. What this entry sends. MIXED and LOW_VOLUME are refused — volume decides those.
/// </summary>
[JsonConverter(typeof(TenDlcUpdateCampaignParamsUseCaseUseCaseConverter))]
public enum TenDlcUpdateCampaignParamsUseCaseUseCase
{
    Marketing,
    AccountNotification,
    CustomerCare,
    FraudAlert,
    V2Fa,
    DeliveryNotification,
    SecurityAlert,
    M2M,
    HigherEducation,
    PollingVoting,
    PublicServiceAnnouncement,
}

sealed class TenDlcUpdateCampaignParamsUseCaseUseCaseConverter
    : JsonConverter<TenDlcUpdateCampaignParamsUseCaseUseCase>
{
    public override TenDlcUpdateCampaignParamsUseCaseUseCase Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MARKETING" => TenDlcUpdateCampaignParamsUseCaseUseCase.Marketing,
            "ACCOUNT_NOTIFICATION" => TenDlcUpdateCampaignParamsUseCaseUseCase.AccountNotification,
            "CUSTOMER_CARE" => TenDlcUpdateCampaignParamsUseCaseUseCase.CustomerCare,
            "FRAUD_ALERT" => TenDlcUpdateCampaignParamsUseCaseUseCase.FraudAlert,
            "2FA" => TenDlcUpdateCampaignParamsUseCaseUseCase.V2Fa,
            "DELIVERY_NOTIFICATION" =>
                TenDlcUpdateCampaignParamsUseCaseUseCase.DeliveryNotification,
            "SECURITY_ALERT" => TenDlcUpdateCampaignParamsUseCaseUseCase.SecurityAlert,
            "M2M" => TenDlcUpdateCampaignParamsUseCaseUseCase.M2M,
            "HIGHER_EDUCATION" => TenDlcUpdateCampaignParamsUseCaseUseCase.HigherEducation,
            "POLLING_VOTING" => TenDlcUpdateCampaignParamsUseCaseUseCase.PollingVoting,
            "PUBLIC_SERVICE_ANNOUNCEMENT" =>
                TenDlcUpdateCampaignParamsUseCaseUseCase.PublicServiceAnnouncement,
            _ => (TenDlcUpdateCampaignParamsUseCaseUseCase)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TenDlcUpdateCampaignParamsUseCaseUseCase value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TenDlcUpdateCampaignParamsUseCaseUseCase.Marketing => "MARKETING",
                TenDlcUpdateCampaignParamsUseCaseUseCase.AccountNotification =>
                    "ACCOUNT_NOTIFICATION",
                TenDlcUpdateCampaignParamsUseCaseUseCase.CustomerCare => "CUSTOMER_CARE",
                TenDlcUpdateCampaignParamsUseCaseUseCase.FraudAlert => "FRAUD_ALERT",
                TenDlcUpdateCampaignParamsUseCaseUseCase.V2Fa => "2FA",
                TenDlcUpdateCampaignParamsUseCaseUseCase.DeliveryNotification =>
                    "DELIVERY_NOTIFICATION",
                TenDlcUpdateCampaignParamsUseCaseUseCase.SecurityAlert => "SECURITY_ALERT",
                TenDlcUpdateCampaignParamsUseCaseUseCase.M2M => "M2M",
                TenDlcUpdateCampaignParamsUseCaseUseCase.HigherEducation => "HIGHER_EDUCATION",
                TenDlcUpdateCampaignParamsUseCaseUseCase.PollingVoting => "POLLING_VOTING",
                TenDlcUpdateCampaignParamsUseCaseUseCase.PublicServiceAnnouncement =>
                    "PUBLIC_SERVICE_ANNOUNCEMENT",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
