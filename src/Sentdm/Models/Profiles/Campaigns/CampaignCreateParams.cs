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

namespace Sentdm.Models.Profiles.Campaigns;

/// <summary>
/// Creates a new campaign scoped under the brand of the specified profile. Each campaign
/// must include at least one use case with sample messages.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CampaignCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ProfileID { get; init; }

    /// <summary>
    /// Campaign data for create or update operation
    /// </summary>
    public required Campaign Campaign
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Campaign>("campaign");
        }
        init { this._rawBodyData.Set("campaign", value); }
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

    public CampaignCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignCreateParams(CampaignCreateParams campaignCreateParams)
        : base(campaignCreateParams)
    {
        this.ProfileID = campaignCreateParams.ProfileID;

        this._rawBodyData = new(campaignCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CampaignCreateParams(
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
    CampaignCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string profileID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ProfileID = profileID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CampaignCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string profileID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            profileID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ProfileID"] = JsonSerializer.SerializeToElement(this.ProfileID),
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

    public virtual bool Equals(CampaignCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ProfileID?.Equals(other.ProfileID) ?? other.ProfileID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/profiles/{0}/campaigns", this.ProfileID)
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

/// <summary>
/// Campaign data for create or update operation
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Campaign, CampaignFromRaw>))]
public sealed record class Campaign : JsonModel
{
    /// <summary>
    /// Campaign description
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Campaign name
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Campaign type (e.g., "KYC", "App")
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// List of use cases with sample messages
    /// </summary>
    public required IReadOnlyList<UseCase> UseCases
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UseCase>>("useCases");
        }
        init
        {
            this._rawData.Set<ImmutableArray<UseCase>>(
                "useCases",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Comma-separated keywords that trigger help message (e.g., "HELP, INFO, SUPPORT")
    /// </summary>
    public string? HelpKeywords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("helpKeywords");
        }
        init { this._rawData.Set("helpKeywords", value); }
    }

    /// <summary>
    /// Message sent when user requests help
    /// </summary>
    public string? HelpMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("helpMessage");
        }
        init { this._rawData.Set("helpMessage", value); }
    }

    /// <summary>
    /// Description of how messages flow in the campaign
    /// </summary>
    public string? MessageFlow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("messageFlow");
        }
        init { this._rawData.Set("messageFlow", value); }
    }

    /// <summary>
    /// Comma-separated keywords that trigger opt-in (e.g., "YES, START, SUBSCRIBE")
    /// </summary>
    public string? OptinKeywords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("optinKeywords");
        }
        init { this._rawData.Set("optinKeywords", value); }
    }

    /// <summary>
    /// Message sent when user opts in
    /// </summary>
    public string? OptinMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("optinMessage");
        }
        init { this._rawData.Set("optinMessage", value); }
    }

    /// <summary>
    /// Comma-separated keywords that trigger opt-out (e.g., "STOP, UNSUBSCRIBE, END")
    /// </summary>
    public string? OptoutKeywords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("optoutKeywords");
        }
        init { this._rawData.Set("optoutKeywords", value); }
    }

    /// <summary>
    /// Message sent when user opts out
    /// </summary>
    public string? OptoutMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("optoutMessage");
        }
        init { this._rawData.Set("optoutMessage", value); }
    }

    /// <summary>
    /// URL to privacy policy
    /// </summary>
    public string? PrivacyPolicyLink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("privacyPolicyLink");
        }
        init { this._rawData.Set("privacyPolicyLink", value); }
    }

    /// <summary>
    /// URL to terms and conditions
    /// </summary>
    public string? TermsAndConditionsLink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("termsAndConditionsLink");
        }
        init { this._rawData.Set("termsAndConditionsLink", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Name;
        _ = this.Type;
        foreach (var item in this.UseCases)
        {
            item.Validate();
        }
        _ = this.HelpKeywords;
        _ = this.HelpMessage;
        _ = this.MessageFlow;
        _ = this.OptinKeywords;
        _ = this.OptinMessage;
        _ = this.OptoutKeywords;
        _ = this.OptoutMessage;
        _ = this.PrivacyPolicyLink;
        _ = this.TermsAndConditionsLink;
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

/// <summary>
/// Campaign use case with sample messages
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UseCase, UseCaseFromRaw>))]
public sealed record class UseCase : JsonModel
{
    public required ApiEnum<string, MessagingUseCaseUs> MessagingUseCaseUs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MessagingUseCaseUs>>(
                "messagingUseCaseUs"
            );
        }
        init { this._rawData.Set("messagingUseCaseUs", value); }
    }

    /// <summary>
    /// Sample messages for this use case (1-5 messages, max 1024 characters each)
    /// </summary>
    public required IReadOnlyList<string> SampleMessages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("sampleMessages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "sampleMessages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MessagingUseCaseUs.Validate();
        _ = this.SampleMessages;
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

[JsonConverter(typeof(MessagingUseCaseUsConverter))]
public enum MessagingUseCaseUs
{
    Marketing,
    AccountNotification,
    CustomerCare,
    FraudAlert,
    TwoFa,
    DeliveryNotification,
    SecurityAlert,
    M2M,
    Mixed,
    HigherEducation,
    PollingVoting,
    PublicServiceAnnouncement,
    LowVolume,
}

sealed class MessagingUseCaseUsConverter : JsonConverter<MessagingUseCaseUs>
{
    public override MessagingUseCaseUs Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MARKETING" => MessagingUseCaseUs.Marketing,
            "ACCOUNT_NOTIFICATION" => MessagingUseCaseUs.AccountNotification,
            "CUSTOMER_CARE" => MessagingUseCaseUs.CustomerCare,
            "FRAUD_ALERT" => MessagingUseCaseUs.FraudAlert,
            "TWO_FA" => MessagingUseCaseUs.TwoFa,
            "DELIVERY_NOTIFICATION" => MessagingUseCaseUs.DeliveryNotification,
            "SECURITY_ALERT" => MessagingUseCaseUs.SecurityAlert,
            "M2M" => MessagingUseCaseUs.M2M,
            "MIXED" => MessagingUseCaseUs.Mixed,
            "HIGHER_EDUCATION" => MessagingUseCaseUs.HigherEducation,
            "POLLING_VOTING" => MessagingUseCaseUs.PollingVoting,
            "PUBLIC_SERVICE_ANNOUNCEMENT" => MessagingUseCaseUs.PublicServiceAnnouncement,
            "LOW_VOLUME" => MessagingUseCaseUs.LowVolume,
            _ => (MessagingUseCaseUs)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingUseCaseUs value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MessagingUseCaseUs.Marketing => "MARKETING",
                MessagingUseCaseUs.AccountNotification => "ACCOUNT_NOTIFICATION",
                MessagingUseCaseUs.CustomerCare => "CUSTOMER_CARE",
                MessagingUseCaseUs.FraudAlert => "FRAUD_ALERT",
                MessagingUseCaseUs.TwoFa => "TWO_FA",
                MessagingUseCaseUs.DeliveryNotification => "DELIVERY_NOTIFICATION",
                MessagingUseCaseUs.SecurityAlert => "SECURITY_ALERT",
                MessagingUseCaseUs.M2M => "M2M",
                MessagingUseCaseUs.Mixed => "MIXED",
                MessagingUseCaseUs.HigherEducation => "HIGHER_EDUCATION",
                MessagingUseCaseUs.PollingVoting => "POLLING_VOTING",
                MessagingUseCaseUs.PublicServiceAnnouncement => "PUBLIC_SERVICE_ANNOUNCEMENT",
                MessagingUseCaseUs.LowVolume => "LOW_VOLUME",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
