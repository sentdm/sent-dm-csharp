using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;

namespace Sentdm.Models.Channels.Sms;

/// <summary>
/// The compliance values a market registers with. `brand` and `campaign` apply to
/// US `TEN_DLC`; other markets fill this map with the document keys their own requirements name.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MarketCompliance, MarketComplianceFromRaw>))]
public sealed record class MarketCompliance : JsonModel
{
    /// <summary>
    /// Business identity. The identity the registration is filed against. Omit to
    /// have none; { "inherit": true } to register under your organization's.
    /// </summary>
    public Brand? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Brand>("brand");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("brand", value);
        }
    }

    /// <summary>
    /// Messaging campaign. What the programme sends and how recipients consented.
    /// Omit to run on your organization's; supplying it takes one of your own. {
    /// "inherit": true } says so outright. Required when `compliance.campaign.inherit
    /// != true`.
    /// </summary>
    public Campaign? Campaign
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Campaign>("campaign");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("campaign", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Brand?.Validate();
        this.Campaign?.Validate();
    }

    public MarketCompliance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MarketCompliance(MarketCompliance marketCompliance)
        : base(marketCompliance) { }
#pragma warning restore CS8618

    public MarketCompliance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MarketCompliance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MarketComplianceFromRaw.FromRawUnchecked"/>
    public static MarketCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MarketComplianceFromRaw : IFromRawJson<MarketCompliance>
{
    /// <inheritdoc/>
    public MarketCompliance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MarketCompliance.FromRawUnchecked(rawData);
}

/// <summary>
/// Business identity. The identity the registration is filed against. Omit to have
/// none; { "inherit": true } to register under your organization's.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Brand, BrandFromRaw>))]
public sealed record class Brand : JsonModel
{
    /// <summary>
    /// Public-facing name. TCR displayName — the name recipients would recognise.
    /// Named for what it holds rather than for TCR's field, which is why it is not
    /// `display_name`. Required when `compliance.brand.inherit != true`.
    /// </summary>
    public string? BusinessName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("business_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("business_name", value);
        }
    }

    /// <summary>
    /// City. Required when `compliance.brand.inherit != true`.
    /// </summary>
    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("city", value);
        }
    }

    /// <summary>
    /// Contact email. TCR email. Required when `compliance.brand.inherit != true`.
    /// </summary>
    public string? ContactEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contact_email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contact_email", value);
        }
    }

    /// <summary>
    /// Responsible contact. Split into TCR's firstName/lastName on submission. BrandService
    /// refuses a blank one, so a missing name is reported here rather than thrown
    /// after the profile was written. Required when `compliance.brand.inherit != true`.
    /// </summary>
    public string? ContactName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contact_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contact_name", value);
        }
    }

    /// <summary>
    /// Contact phone. TCR sends it as both phone and mobilePhone, so it is asked
    /// for once. Named for the contact it belongs to rather than as a bare `phone`
    /// on a block that also carries an address. Required when `compliance.brand.inherit
    /// != true`.
    /// </summary>
    public string? ContactPhone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contact_phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contact_phone", value);
        }
    }

    /// <summary>
    /// Country of registration. Two letters — US. The country spelled out in full
    /// is accepted too and stored as its code, which is what a read answers with
    /// and what is filed. Required when `compliance.brand.inherit != true`.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country", value);
        }
    }

    /// <summary>
    /// Country that issued the tax id. TCR einIssuingCountry — where the tax id was
    /// issued, which is not always where the business trades. Defaults to `country`
    /// when omitted, which is right for most. Takes the code or the country spelled
    /// out, as `country` does.
    /// </summary>
    public string? EinIssuingCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ein_issuing_country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ein_issuing_country", value);
        }
    }

    /// <summary>
    /// Entity type. TCR entityType. Decides which vetting TCR applies and, for SOLE_PROPRIETOR,
    /// fixes the campaign fee regardless of volume. Also refused at submission if
    /// absent. Required when `compliance.brand.inherit != true`.
    /// </summary>
    public ApiEnum<string, EntityType>? EntityType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EntityType>>("entity_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("entity_type", value);
        }
    }

    /// <summary>
    /// Run on the organization's brand. True to register under the parent organization's
    /// identity rather than one of this profile's own; every field below is then
    /// neither asked for nor accepted. Omitted, the brand is the organization's
    /// unless this block supplies identity fields, which says plainly enough that
    /// it wants one of its own.
    /// </summary>
    public bool? Inherit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inherit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inherit", value);
        }
    }

    /// <summary>
    /// Registered legal name. TCR companyName — the name on the incorporation documents,
    /// which is often not the name recipients would recognise. Required when `compliance.brand.inherit
    /// != true`.
    /// </summary>
    public string? LegalName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("legal_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("legal_name", value);
        }
    }

    /// <summary>
    /// Postal code. Required when `compliance.brand.inherit != true`.
    /// </summary>
    public string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postal_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("postal_code", value);
        }
    }

    /// <summary>
    /// State or region. TCR state. Two letters for a US registration. Required when
    /// `compliance.brand.inherit != true`.
    /// </summary>
    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <summary>
    /// Street address. Required when `compliance.brand.inherit != true`.
    /// </summary>
    public string? Street
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("street");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("street", value);
        }
    }

    /// <summary>
    /// Tax identifier. TCR ein. TcrBrandSubmissionValidator refuses a submission
    /// without one, so it is wanted here rather than discovered at filing time. Required
    /// when `compliance.brand.inherit != true`.
    /// </summary>
    public string? TaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tax_id", value);
        }
    }

    /// <summary>
    /// Kind of tax identifier. Which kind of identifier `tax_id` is, e.g. us_ein.
    /// Derived onto the brand form, and not itself sent to TCR. Required when `compliance.brand.inherit
    /// != true`.
    /// </summary>
    public string? TaxIDType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_id_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tax_id_type", value);
        }
    }

    /// <summary>
    /// Website. TCR website. Optional, and worth sending: carriers weigh it when
    /// vetting, so a brand that has one and omits it is vetted on less than it could be.
    /// </summary>
    public string? Website
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("website");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("website", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessName;
        _ = this.City;
        _ = this.ContactEmail;
        _ = this.ContactName;
        _ = this.ContactPhone;
        _ = this.Country;
        _ = this.EinIssuingCountry;
        this.EntityType?.Validate();
        _ = this.Inherit;
        _ = this.LegalName;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.Street;
        _ = this.TaxID;
        _ = this.TaxIDType;
        _ = this.Website;
    }

    public Brand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Brand(Brand brand)
        : base(brand) { }
#pragma warning restore CS8618

    public Brand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Brand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandFromRaw.FromRawUnchecked"/>
    public static Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandFromRaw : IFromRawJson<Brand>
{
    /// <inheritdoc/>
    public Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Brand.FromRawUnchecked(rawData);
}

/// <summary>
/// Entity type. TCR entityType. Decides which vetting TCR applies and, for SOLE_PROPRIETOR,
/// fixes the campaign fee regardless of volume. Also refused at submission if absent.
/// Required when `compliance.brand.inherit != true`.
/// </summary>
[JsonConverter(typeof(EntityTypeConverter))]
public enum EntityType
{
    PrivateProfit,
    PublicProfit,
    NonProfit,
    SoleProprietor,
    Government,
}

sealed class EntityTypeConverter : JsonConverter<EntityType>
{
    public override EntityType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PRIVATE_PROFIT" => EntityType.PrivateProfit,
            "PUBLIC_PROFIT" => EntityType.PublicProfit,
            "NON_PROFIT" => EntityType.NonProfit,
            "SOLE_PROPRIETOR" => EntityType.SoleProprietor,
            "GOVERNMENT" => EntityType.Government,
            _ => (EntityType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityType.PrivateProfit => "PRIVATE_PROFIT",
                EntityType.PublicProfit => "PUBLIC_PROFIT",
                EntityType.NonProfit => "NON_PROFIT",
                EntityType.SoleProprietor => "SOLE_PROPRIETOR",
                EntityType.Government => "GOVERNMENT",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Messaging campaign. What the programme sends and how recipients consented. Omit
/// to run on your organization's; supplying it takes one of your own. { "inherit":
/// true } says so outright. Required when `compliance.campaign.inherit != true`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Campaign, CampaignFromRaw>))]
public sealed record class Campaign : JsonModel
{
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("help_keywords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("help_keywords", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("help_message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("help_message", value);
        }
    }

    /// <summary>
    /// Run on the organization's campaign. True to register under the parent organization's
    /// programme rather than one of this profile's own; every field below is then
    /// neither asked for nor accepted. Owning the identity and inheriting the campaign
    /// is refused — a campaign is filed against an identity registration, and chk_tcr_inheritance
    /// forbids that pairing outright.
    /// </summary>
    public bool? Inherit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inherit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inherit", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message_flow");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message_flow", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("opt_in_keywords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("opt_in_keywords", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("opt_in_message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("opt_in_message", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("opt_out_keywords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("opt_out_keywords", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("opt_out_message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("opt_out_message", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("privacy_policy_link");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("privacy_policy_link", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("terms_and_conditions_link");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("terms_and_conditions_link", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<UseCase>>("use_cases");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<UseCase>?>(
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("volume");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("volume", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.HelpKeywords;
        _ = this.HelpMessage;
        _ = this.Inherit;
        _ = this.MessageFlow;
        _ = this.OptInKeywords;
        _ = this.OptInMessage;
        _ = this.OptOutKeywords;
        _ = this.OptOutMessage;
        _ = this.PrivacyPolicyLink;
        _ = this.TermsAndConditionsLink;
        foreach (var item in this.UseCases ?? [])
        {
            item.Validate();
        }
        _ = this.Volume;
    }

    public Campaign() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Campaign(Campaign campaign)
        : base(campaign) { }
#pragma warning restore CS8618

    public Campaign(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Campaign(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignFromRaw.FromRawUnchecked"/>
    public static Campaign FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignFromRaw : IFromRawJson<Campaign>
{
    /// <inheritdoc/>
    public Campaign FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Campaign.FromRawUnchecked(rawData);
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
