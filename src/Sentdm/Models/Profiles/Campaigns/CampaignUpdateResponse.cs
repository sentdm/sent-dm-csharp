using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;

namespace Sentdm.Models.Profiles.Campaigns;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CampaignUpdateResponse, CampaignUpdateResponseFromRaw>))]
public sealed record class CampaignUpdateResponse : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public CampaignUpdateResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CampaignUpdateResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public CampaignUpdateResponseError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CampaignUpdateResponseError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public CampaignUpdateResponseMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CampaignUpdateResponseMeta>("meta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data?.Validate();
        this.Error?.Validate();
        this.Meta?.Validate();
        _ = this.Success;
    }

    public CampaignUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignUpdateResponse(CampaignUpdateResponse campaignUpdateResponse)
        : base(campaignUpdateResponse) { }
#pragma warning restore CS8618

    public CampaignUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignUpdateResponseFromRaw.FromRawUnchecked"/>
    public static CampaignUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignUpdateResponseFromRaw : IFromRawJson<CampaignUpdateResponse>
{
    /// <inheritdoc/>
    public CampaignUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The response data (null if error)
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CampaignUpdateResponseData, CampaignUpdateResponseDataFromRaw>)
)]
public sealed record class CampaignUpdateResponseData : JsonModel
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public DateTimeOffset? BilledDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("billedDate");
        }
        init { this._rawData.Set("billedDate", value); }
    }

    public string? BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("brandId");
        }
        init { this._rawData.Set("brandId", value); }
    }

    public double? Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("cost");
        }
        init { this._rawData.Set("cost", value); }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public string? CspID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cspId");
        }
        init { this._rawData.Set("cspId", value); }
    }

    public string? CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customerId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("customerId", value);
        }
    }

    public bool? DcaElectionsComplete
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("dcaElectionsComplete");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("dcaElectionsComplete", value);
        }
    }

    public DateTimeOffset? DcaElectionsCompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("dcaElectionsCompletedAt");
        }
        init { this._rawData.Set("dcaElectionsCompletedAt", value); }
    }

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

    public string? HelpKeywords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("helpKeywords");
        }
        init { this._rawData.Set("helpKeywords", value); }
    }

    public string? HelpMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("helpMessage");
        }
        init { this._rawData.Set("helpMessage", value); }
    }

    public string? KycSubmissionFormID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("kycSubmissionFormId");
        }
        init { this._rawData.Set("kycSubmissionFormId", value); }
    }

    public string? MessageFlow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("messageFlow");
        }
        init { this._rawData.Set("messageFlow", value); }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public string? OptinKeywords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("optinKeywords");
        }
        init { this._rawData.Set("optinKeywords", value); }
    }

    public string? OptinMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("optinMessage");
        }
        init { this._rawData.Set("optinMessage", value); }
    }

    public string? OptoutKeywords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("optoutKeywords");
        }
        init { this._rawData.Set("optoutKeywords", value); }
    }

    public string? OptoutMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("optoutMessage");
        }
        init { this._rawData.Set("optoutMessage", value); }
    }

    public string? PrivacyPolicyLink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("privacyPolicyLink");
        }
        init { this._rawData.Set("privacyPolicyLink", value); }
    }

    public string? ResellerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("resellerId");
        }
        init { this._rawData.Set("resellerId", value); }
    }

    public ApiEnum<string, CampaignUpdateResponseDataSharingStatus>? SharingStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CampaignUpdateResponseDataSharingStatus>
            >("sharingStatus");
        }
        init { this._rawData.Set("sharingStatus", value); }
    }

    public ApiEnum<string, CampaignUpdateResponseDataStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CampaignUpdateResponseDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public DateTimeOffset? SubmittedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("submittedAt");
        }
        init { this._rawData.Set("submittedAt", value); }
    }

    public bool? SubmittedToTcr
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("submittedToTCR");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("submittedToTCR", value);
        }
    }

    public string? TcrCampaignID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tcrCampaignId");
        }
        init { this._rawData.Set("tcrCampaignId", value); }
    }

    public string? TcrSyncError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tcrSyncError");
        }
        init { this._rawData.Set("tcrSyncError", value); }
    }

    public string? TelnyxCampaignID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("telnyxCampaignId");
        }
        init { this._rawData.Set("telnyxCampaignId", value); }
    }

    public string? TermsAndConditionsLink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("termsAndConditionsLink");
        }
        init { this._rawData.Set("termsAndConditionsLink", value); }
    }

    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    public string? UpstreamCnpID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("upstreamCnpId");
        }
        init { this._rawData.Set("upstreamCnpId", value); }
    }

    public IReadOnlyList<CampaignUpdateResponseDataUseCase>? UseCases
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CampaignUpdateResponseDataUseCase>
            >("useCases");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CampaignUpdateResponseDataUseCase>?>(
                "useCases",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BilledDate;
        _ = this.BrandID;
        _ = this.Cost;
        _ = this.CreatedAt;
        _ = this.CspID;
        _ = this.CustomerID;
        _ = this.DcaElectionsComplete;
        _ = this.DcaElectionsCompletedAt;
        _ = this.Description;
        _ = this.HelpKeywords;
        _ = this.HelpMessage;
        _ = this.KycSubmissionFormID;
        _ = this.MessageFlow;
        _ = this.Name;
        _ = this.OptinKeywords;
        _ = this.OptinMessage;
        _ = this.OptoutKeywords;
        _ = this.OptoutMessage;
        _ = this.PrivacyPolicyLink;
        _ = this.ResellerID;
        this.SharingStatus?.Validate();
        this.Status?.Validate();
        _ = this.SubmittedAt;
        _ = this.SubmittedToTcr;
        _ = this.TcrCampaignID;
        _ = this.TcrSyncError;
        _ = this.TelnyxCampaignID;
        _ = this.TermsAndConditionsLink;
        _ = this.Type;
        _ = this.UpdatedAt;
        _ = this.UpstreamCnpID;
        foreach (var item in this.UseCases ?? [])
        {
            item.Validate();
        }
    }

    public CampaignUpdateResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignUpdateResponseData(CampaignUpdateResponseData campaignUpdateResponseData)
        : base(campaignUpdateResponseData) { }
#pragma warning restore CS8618

    public CampaignUpdateResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignUpdateResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignUpdateResponseDataFromRaw.FromRawUnchecked"/>
    public static CampaignUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignUpdateResponseDataFromRaw : IFromRawJson<CampaignUpdateResponseData>
{
    /// <inheritdoc/>
    public CampaignUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignUpdateResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CampaignUpdateResponseDataSharingStatusConverter))]
public enum CampaignUpdateResponseDataSharingStatus
{
    Pending,
    Accepted,
    Declined,
}

sealed class CampaignUpdateResponseDataSharingStatusConverter
    : JsonConverter<CampaignUpdateResponseDataSharingStatus>
{
    public override CampaignUpdateResponseDataSharingStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PENDING" => CampaignUpdateResponseDataSharingStatus.Pending,
            "ACCEPTED" => CampaignUpdateResponseDataSharingStatus.Accepted,
            "DECLINED" => CampaignUpdateResponseDataSharingStatus.Declined,
            _ => (CampaignUpdateResponseDataSharingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CampaignUpdateResponseDataSharingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CampaignUpdateResponseDataSharingStatus.Pending => "PENDING",
                CampaignUpdateResponseDataSharingStatus.Accepted => "ACCEPTED",
                CampaignUpdateResponseDataSharingStatus.Declined => "DECLINED",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(CampaignUpdateResponseDataStatusConverter))]
public enum CampaignUpdateResponseDataStatus
{
    SentCreated,
    Active,
    Expired,
}

sealed class CampaignUpdateResponseDataStatusConverter
    : JsonConverter<CampaignUpdateResponseDataStatus>
{
    public override CampaignUpdateResponseDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SENT_CREATED" => CampaignUpdateResponseDataStatus.SentCreated,
            "ACTIVE" => CampaignUpdateResponseDataStatus.Active,
            "EXPIRED" => CampaignUpdateResponseDataStatus.Expired,
            _ => (CampaignUpdateResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CampaignUpdateResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CampaignUpdateResponseDataStatus.SentCreated => "SENT_CREATED",
                CampaignUpdateResponseDataStatus.Active => "ACTIVE",
                CampaignUpdateResponseDataStatus.Expired => "EXPIRED",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        CampaignUpdateResponseDataUseCase,
        CampaignUpdateResponseDataUseCaseFromRaw
    >)
)]
public sealed record class CampaignUpdateResponseDataUseCase : JsonModel
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? CampaignID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("campaignId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("campaignId", value);
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public string? CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customerId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("customerId", value);
        }
    }

    public ApiEnum<string, CampaignUpdateResponseDataUseCaseMessagingUseCaseUs>? MessagingUseCaseUs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CampaignUpdateResponseDataUseCaseMessagingUseCaseUs>
            >("messagingUseCaseUs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("messagingUseCaseUs", value);
        }
    }

    public IReadOnlyList<string>? SampleMessages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("sampleMessages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "sampleMessages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CampaignID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        this.MessagingUseCaseUs?.Validate();
        _ = this.SampleMessages;
        _ = this.UpdatedAt;
    }

    public CampaignUpdateResponseDataUseCase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignUpdateResponseDataUseCase(
        CampaignUpdateResponseDataUseCase campaignUpdateResponseDataUseCase
    )
        : base(campaignUpdateResponseDataUseCase) { }
#pragma warning restore CS8618

    public CampaignUpdateResponseDataUseCase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignUpdateResponseDataUseCase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignUpdateResponseDataUseCaseFromRaw.FromRawUnchecked"/>
    public static CampaignUpdateResponseDataUseCase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignUpdateResponseDataUseCaseFromRaw : IFromRawJson<CampaignUpdateResponseDataUseCase>
{
    /// <inheritdoc/>
    public CampaignUpdateResponseDataUseCase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignUpdateResponseDataUseCase.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CampaignUpdateResponseDataUseCaseMessagingUseCaseUsConverter))]
public enum CampaignUpdateResponseDataUseCaseMessagingUseCaseUs
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

sealed class CampaignUpdateResponseDataUseCaseMessagingUseCaseUsConverter
    : JsonConverter<CampaignUpdateResponseDataUseCaseMessagingUseCaseUs>
{
    public override CampaignUpdateResponseDataUseCaseMessagingUseCaseUs Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MARKETING" => CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.Marketing,
            "ACCOUNT_NOTIFICATION" =>
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.AccountNotification,
            "CUSTOMER_CARE" => CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.CustomerCare,
            "FRAUD_ALERT" => CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.FraudAlert,
            "TWO_FA" => CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.TwoFa,
            "DELIVERY_NOTIFICATION" =>
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.DeliveryNotification,
            "SECURITY_ALERT" => CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.SecurityAlert,
            "M2M" => CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.M2M,
            "MIXED" => CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.Mixed,
            "HIGHER_EDUCATION" =>
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.HigherEducation,
            "POLLING_VOTING" => CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.PollingVoting,
            "PUBLIC_SERVICE_ANNOUNCEMENT" =>
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.PublicServiceAnnouncement,
            "LOW_VOLUME" => CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.LowVolume,
            _ => (CampaignUpdateResponseDataUseCaseMessagingUseCaseUs)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CampaignUpdateResponseDataUseCaseMessagingUseCaseUs value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.Marketing => "MARKETING",
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.AccountNotification =>
                    "ACCOUNT_NOTIFICATION",
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.CustomerCare => "CUSTOMER_CARE",
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.FraudAlert => "FRAUD_ALERT",
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.TwoFa => "TWO_FA",
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.DeliveryNotification =>
                    "DELIVERY_NOTIFICATION",
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.SecurityAlert =>
                    "SECURITY_ALERT",
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.M2M => "M2M",
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.Mixed => "MIXED",
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.HigherEducation =>
                    "HIGHER_EDUCATION",
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.PollingVoting =>
                    "POLLING_VOTING",
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.PublicServiceAnnouncement =>
                    "PUBLIC_SERVICE_ANNOUNCEMENT",
                CampaignUpdateResponseDataUseCaseMessagingUseCaseUs.LowVolume => "LOW_VOLUME",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Error information
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CampaignUpdateResponseError, CampaignUpdateResponseErrorFromRaw>)
)]
public sealed record class CampaignUpdateResponseError : JsonModel
{
    /// <summary>
    /// Machine-readable error code (e.g., "RESOURCE_001")
    /// </summary>
    public string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    /// <summary>
    /// Additional validation error details (field-level errors)
    /// </summary>
    public IReadOnlyDictionary<string, IReadOnlyList<string>>? Details
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableClass<
                FrozenDictionary<string, ImmutableArray<string>>
            >("details");
            if (value == null)
            {
                return null;
            }

            return FrozenDictionary.ToFrozenDictionary(
                value,
                entry => entry.Key,
                (entry) => (IReadOnlyList<string>)entry.Value
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, ImmutableArray<string>>?>(
                "details",
                value == null
                    ? null
                    : FrozenDictionary.ToFrozenDictionary(
                        value,
                        entry => entry.Key,
                        (entry) => ImmutableArray.ToImmutableArray(entry.Value)
                    )
            );
        }
    }

    /// <summary>
    /// URL to documentation about this error
    /// </summary>
    public string? DocUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("doc_url");
        }
        init { this._rawData.Set("doc_url", value); }
    }

    /// <summary>
    /// Human-readable error message
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Details;
        _ = this.DocUrl;
        _ = this.Message;
    }

    public CampaignUpdateResponseError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignUpdateResponseError(CampaignUpdateResponseError campaignUpdateResponseError)
        : base(campaignUpdateResponseError) { }
#pragma warning restore CS8618

    public CampaignUpdateResponseError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignUpdateResponseError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignUpdateResponseErrorFromRaw.FromRawUnchecked"/>
    public static CampaignUpdateResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignUpdateResponseErrorFromRaw : IFromRawJson<CampaignUpdateResponseError>
{
    /// <inheritdoc/>
    public CampaignUpdateResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignUpdateResponseError.FromRawUnchecked(rawData);
}

/// <summary>
/// Request and response metadata
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CampaignUpdateResponseMeta, CampaignUpdateResponseMetaFromRaw>)
)]
public sealed record class CampaignUpdateResponseMeta : JsonModel
{
    /// <summary>
    /// Unique identifier for this request (for tracing and support)
    /// </summary>
    public string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("request_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("request_id", value);
        }
    }

    /// <summary>
    /// Server timestamp when the response was generated
    /// </summary>
    public DateTimeOffset? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("timestamp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    /// <summary>
    /// API version used for this request
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RequestID;
        _ = this.Timestamp;
        _ = this.Version;
    }

    public CampaignUpdateResponseMeta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignUpdateResponseMeta(CampaignUpdateResponseMeta campaignUpdateResponseMeta)
        : base(campaignUpdateResponseMeta) { }
#pragma warning restore CS8618

    public CampaignUpdateResponseMeta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignUpdateResponseMeta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignUpdateResponseMetaFromRaw.FromRawUnchecked"/>
    public static CampaignUpdateResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignUpdateResponseMetaFromRaw : IFromRawJson<CampaignUpdateResponseMeta>
{
    /// <inheritdoc/>
    public CampaignUpdateResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignUpdateResponseMeta.FromRawUnchecked(rawData);
}
