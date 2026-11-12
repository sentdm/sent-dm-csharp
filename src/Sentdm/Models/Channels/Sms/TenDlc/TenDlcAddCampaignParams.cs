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
/// Registers **a new campaign** on the US `TEN_DLC` market you already hold — the
/// one market that registers campaigns. Use it when you want numbers for a different
/// use case than the market's existing campaign covers. The campaign is filed under
/// the brand the market files under — your organization's when you inherit its identity.
///
/// <para>## What to send</para>
///
/// <para>The new campaign's fields, at the top level of the body: use cases, consent
/// narrative, volume, sample messages and keywords, under the `compliance.campaign.*`
/// keys `GET /v3/compliance/requirements?country=US&amp;type=TEN_DLC` lists, without
/// that prefix. It has to be complete. A rejected field is keyed by its name (`description`).
/// `id` and `inherit` are ignored, so an entry of `compliance.campaigns` can be
/// sent as read.</para>
///
/// <para>The identity is the market's and is not sent here. A market whose identity
/// has no registration yet, or one not yet submitted for review, is `400`.</para>
///
/// <para>## What happens</para>
///
/// <para>The campaign is recorded and goes for review; it is not filed with The
/// Campaign Registry by this call. **It comes without numbers**: send its `id` from
/// `compliance.campaigns` to `POST /v3/channels/sms/numbers/US/TEN_DLC` to give it
/// some. **The campaign you already have, and its numbers, are not touched** — including
/// a campaign you run on from your organization.</para>
///
/// <para>**Each call files a new campaign**, which is charged when it is submitted.
/// Send an `Idempotency-Key` so a retried request does not file a second one.</para>
///
/// <para>To change the campaign a market already has, use `PATCH /v3/channels/sms/US/TEN_DLC`.
/// Once a market holds more than one campaign, that `PATCH` refuses a campaign or
/// numbers change (`409`) rather than guess which campaign is meant; numbers are
/// added to a named campaign with `POST /v3/channels/sms/numbers/US/TEN_DLC`.</para>
///
/// <para>Returns **the market**, in the shape `GET /v3/channels/sms/US/TEN_DLC`
/// returns, with `202`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TenDlcAddCampaignParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
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
    public IReadOnlyList<UseCase>? UseCases
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<UseCase>>("use_cases");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<UseCase>?>(
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

    public TenDlcAddCampaignParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TenDlcAddCampaignParams(TenDlcAddCampaignParams tenDlcAddCampaignParams)
        : base(tenDlcAddCampaignParams)
    {
        this._rawBodyData = new(tenDlcAddCampaignParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TenDlcAddCampaignParams(
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
    TenDlcAddCampaignParams(
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
    public static TenDlcAddCampaignParams FromRawUnchecked(
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

    public virtual bool Equals(TenDlcAddCampaignParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/')
                + "/v3/channels/sms/compliances/US/TEN_DLC/campaigns"
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

[JsonConverter(typeof(JsonModelConverter<UseCase, UseCaseFromRaw>))]
public sealed record class UseCase : JsonModel
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
    public required ApiEnum<string, UseCaseUseCase> UseCaseValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UseCaseUseCase>>("use_case");
        }
        init { this._rawData.Set("use_case", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SampleMessages;
        this.UseCaseValue.Validate();
    }

    public UseCase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UseCase(UseCase useCase)
        : base(useCase) { }
#pragma warning restore CS8618

    public UseCase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UseCase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UseCaseFromRaw.FromRawUnchecked"/>
    public static UseCase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UseCaseFromRaw : IFromRawJson<UseCase>
{
    /// <inheritdoc/>
    public UseCase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UseCase.FromRawUnchecked(rawData);
}

/// <summary>
/// Use case. What this entry sends. MIXED and LOW_VOLUME are refused — volume decides those.
/// </summary>
[JsonConverter(typeof(UseCaseUseCaseConverter))]
public enum UseCaseUseCase
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

sealed class UseCaseUseCaseConverter : JsonConverter<UseCaseUseCase>
{
    public override UseCaseUseCase Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MARKETING" => UseCaseUseCase.Marketing,
            "ACCOUNT_NOTIFICATION" => UseCaseUseCase.AccountNotification,
            "CUSTOMER_CARE" => UseCaseUseCase.CustomerCare,
            "FRAUD_ALERT" => UseCaseUseCase.FraudAlert,
            "2FA" => UseCaseUseCase.V2Fa,
            "DELIVERY_NOTIFICATION" => UseCaseUseCase.DeliveryNotification,
            "SECURITY_ALERT" => UseCaseUseCase.SecurityAlert,
            "M2M" => UseCaseUseCase.M2M,
            "HIGHER_EDUCATION" => UseCaseUseCase.HigherEducation,
            "POLLING_VOTING" => UseCaseUseCase.PollingVoting,
            "PUBLIC_SERVICE_ANNOUNCEMENT" => UseCaseUseCase.PublicServiceAnnouncement,
            _ => (UseCaseUseCase)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UseCaseUseCase value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UseCaseUseCase.Marketing => "MARKETING",
                UseCaseUseCase.AccountNotification => "ACCOUNT_NOTIFICATION",
                UseCaseUseCase.CustomerCare => "CUSTOMER_CARE",
                UseCaseUseCase.FraudAlert => "FRAUD_ALERT",
                UseCaseUseCase.V2Fa => "2FA",
                UseCaseUseCase.DeliveryNotification => "DELIVERY_NOTIFICATION",
                UseCaseUseCase.SecurityAlert => "SECURITY_ALERT",
                UseCaseUseCase.M2M => "M2M",
                UseCaseUseCase.HigherEducation => "HIGHER_EDUCATION",
                UseCaseUseCase.PollingVoting => "POLLING_VOTING",
                UseCaseUseCase.PublicServiceAnnouncement => "PUBLIC_SERVICE_ANNOUNCEMENT",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
