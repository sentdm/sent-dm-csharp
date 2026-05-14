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
[JsonConverter(typeof(JsonModelConverter<CampaignListResponse, CampaignListResponseFromRaw>))]
public sealed record class CampaignListResponse : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public IReadOnlyList<CampaignListResponseData>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CampaignListResponseData>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CampaignListResponseData>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public CampaignListResponseError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CampaignListResponseError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public CampaignListResponseMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CampaignListResponseMeta>("meta");
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
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Error?.Validate();
        this.Meta?.Validate();
        _ = this.Success;
    }

    public CampaignListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignListResponse(CampaignListResponse campaignListResponse)
        : base(campaignListResponse) { }
#pragma warning restore CS8618

    public CampaignListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignListResponseFromRaw.FromRawUnchecked"/>
    public static CampaignListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignListResponseFromRaw : IFromRawJson<CampaignListResponse>
{
    /// <inheritdoc/>
    public CampaignListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<CampaignListResponseData, CampaignListResponseDataFromRaw>)
)]
public sealed record class CampaignListResponseData : JsonModel
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

    public ApiEnum<string, CampaignListResponseDataSharingStatus>? SharingStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CampaignListResponseDataSharingStatus>
            >("sharingStatus");
        }
        init { this._rawData.Set("sharingStatus", value); }
    }

    public ApiEnum<string, CampaignListResponseDataStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CampaignListResponseDataStatus>>(
                "status"
            );
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

    public IReadOnlyList<CampaignListResponseDataUseCase>? UseCases
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CampaignListResponseDataUseCase>>(
                "useCases"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CampaignListResponseDataUseCase>?>(
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

    public CampaignListResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignListResponseData(CampaignListResponseData campaignListResponseData)
        : base(campaignListResponseData) { }
#pragma warning restore CS8618

    public CampaignListResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignListResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignListResponseDataFromRaw.FromRawUnchecked"/>
    public static CampaignListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignListResponseDataFromRaw : IFromRawJson<CampaignListResponseData>
{
    /// <inheritdoc/>
    public CampaignListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignListResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CampaignListResponseDataSharingStatusConverter))]
public enum CampaignListResponseDataSharingStatus
{
    Pending,
    Accepted,
    Declined,
}

sealed class CampaignListResponseDataSharingStatusConverter
    : JsonConverter<CampaignListResponseDataSharingStatus>
{
    public override CampaignListResponseDataSharingStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PENDING" => CampaignListResponseDataSharingStatus.Pending,
            "ACCEPTED" => CampaignListResponseDataSharingStatus.Accepted,
            "DECLINED" => CampaignListResponseDataSharingStatus.Declined,
            _ => (CampaignListResponseDataSharingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CampaignListResponseDataSharingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CampaignListResponseDataSharingStatus.Pending => "PENDING",
                CampaignListResponseDataSharingStatus.Accepted => "ACCEPTED",
                CampaignListResponseDataSharingStatus.Declined => "DECLINED",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(CampaignListResponseDataStatusConverter))]
public enum CampaignListResponseDataStatus
{
    SentCreated,
    Active,
    Expired,
}

sealed class CampaignListResponseDataStatusConverter : JsonConverter<CampaignListResponseDataStatus>
{
    public override CampaignListResponseDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SENT_CREATED" => CampaignListResponseDataStatus.SentCreated,
            "ACTIVE" => CampaignListResponseDataStatus.Active,
            "EXPIRED" => CampaignListResponseDataStatus.Expired,
            _ => (CampaignListResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CampaignListResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CampaignListResponseDataStatus.SentCreated => "SENT_CREATED",
                CampaignListResponseDataStatus.Active => "ACTIVE",
                CampaignListResponseDataStatus.Expired => "EXPIRED",
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
        CampaignListResponseDataUseCase,
        CampaignListResponseDataUseCaseFromRaw
    >)
)]
public sealed record class CampaignListResponseDataUseCase : JsonModel
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

    public ApiEnum<string, CampaignListResponseDataUseCaseMessagingUseCaseUs>? MessagingUseCaseUs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CampaignListResponseDataUseCaseMessagingUseCaseUs>
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

    public CampaignListResponseDataUseCase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignListResponseDataUseCase(
        CampaignListResponseDataUseCase campaignListResponseDataUseCase
    )
        : base(campaignListResponseDataUseCase) { }
#pragma warning restore CS8618

    public CampaignListResponseDataUseCase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignListResponseDataUseCase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignListResponseDataUseCaseFromRaw.FromRawUnchecked"/>
    public static CampaignListResponseDataUseCase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignListResponseDataUseCaseFromRaw : IFromRawJson<CampaignListResponseDataUseCase>
{
    /// <inheritdoc/>
    public CampaignListResponseDataUseCase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignListResponseDataUseCase.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CampaignListResponseDataUseCaseMessagingUseCaseUsConverter))]
public enum CampaignListResponseDataUseCaseMessagingUseCaseUs
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

sealed class CampaignListResponseDataUseCaseMessagingUseCaseUsConverter
    : JsonConverter<CampaignListResponseDataUseCaseMessagingUseCaseUs>
{
    public override CampaignListResponseDataUseCaseMessagingUseCaseUs Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MARKETING" => CampaignListResponseDataUseCaseMessagingUseCaseUs.Marketing,
            "ACCOUNT_NOTIFICATION" =>
                CampaignListResponseDataUseCaseMessagingUseCaseUs.AccountNotification,
            "CUSTOMER_CARE" => CampaignListResponseDataUseCaseMessagingUseCaseUs.CustomerCare,
            "FRAUD_ALERT" => CampaignListResponseDataUseCaseMessagingUseCaseUs.FraudAlert,
            "TWO_FA" => CampaignListResponseDataUseCaseMessagingUseCaseUs.TwoFa,
            "DELIVERY_NOTIFICATION" =>
                CampaignListResponseDataUseCaseMessagingUseCaseUs.DeliveryNotification,
            "SECURITY_ALERT" => CampaignListResponseDataUseCaseMessagingUseCaseUs.SecurityAlert,
            "M2M" => CampaignListResponseDataUseCaseMessagingUseCaseUs.M2M,
            "MIXED" => CampaignListResponseDataUseCaseMessagingUseCaseUs.Mixed,
            "HIGHER_EDUCATION" => CampaignListResponseDataUseCaseMessagingUseCaseUs.HigherEducation,
            "POLLING_VOTING" => CampaignListResponseDataUseCaseMessagingUseCaseUs.PollingVoting,
            "PUBLIC_SERVICE_ANNOUNCEMENT" =>
                CampaignListResponseDataUseCaseMessagingUseCaseUs.PublicServiceAnnouncement,
            "LOW_VOLUME" => CampaignListResponseDataUseCaseMessagingUseCaseUs.LowVolume,
            _ => (CampaignListResponseDataUseCaseMessagingUseCaseUs)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CampaignListResponseDataUseCaseMessagingUseCaseUs value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CampaignListResponseDataUseCaseMessagingUseCaseUs.Marketing => "MARKETING",
                CampaignListResponseDataUseCaseMessagingUseCaseUs.AccountNotification =>
                    "ACCOUNT_NOTIFICATION",
                CampaignListResponseDataUseCaseMessagingUseCaseUs.CustomerCare => "CUSTOMER_CARE",
                CampaignListResponseDataUseCaseMessagingUseCaseUs.FraudAlert => "FRAUD_ALERT",
                CampaignListResponseDataUseCaseMessagingUseCaseUs.TwoFa => "TWO_FA",
                CampaignListResponseDataUseCaseMessagingUseCaseUs.DeliveryNotification =>
                    "DELIVERY_NOTIFICATION",
                CampaignListResponseDataUseCaseMessagingUseCaseUs.SecurityAlert => "SECURITY_ALERT",
                CampaignListResponseDataUseCaseMessagingUseCaseUs.M2M => "M2M",
                CampaignListResponseDataUseCaseMessagingUseCaseUs.Mixed => "MIXED",
                CampaignListResponseDataUseCaseMessagingUseCaseUs.HigherEducation =>
                    "HIGHER_EDUCATION",
                CampaignListResponseDataUseCaseMessagingUseCaseUs.PollingVoting => "POLLING_VOTING",
                CampaignListResponseDataUseCaseMessagingUseCaseUs.PublicServiceAnnouncement =>
                    "PUBLIC_SERVICE_ANNOUNCEMENT",
                CampaignListResponseDataUseCaseMessagingUseCaseUs.LowVolume => "LOW_VOLUME",
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
    typeof(JsonModelConverter<CampaignListResponseError, CampaignListResponseErrorFromRaw>)
)]
public sealed record class CampaignListResponseError : JsonModel
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

    public CampaignListResponseError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignListResponseError(CampaignListResponseError campaignListResponseError)
        : base(campaignListResponseError) { }
#pragma warning restore CS8618

    public CampaignListResponseError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignListResponseError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignListResponseErrorFromRaw.FromRawUnchecked"/>
    public static CampaignListResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignListResponseErrorFromRaw : IFromRawJson<CampaignListResponseError>
{
    /// <inheritdoc/>
    public CampaignListResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignListResponseError.FromRawUnchecked(rawData);
}

/// <summary>
/// Request and response metadata
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CampaignListResponseMeta, CampaignListResponseMetaFromRaw>)
)]
public sealed record class CampaignListResponseMeta : JsonModel
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

    public CampaignListResponseMeta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignListResponseMeta(CampaignListResponseMeta campaignListResponseMeta)
        : base(campaignListResponseMeta) { }
#pragma warning restore CS8618

    public CampaignListResponseMeta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignListResponseMeta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignListResponseMetaFromRaw.FromRawUnchecked"/>
    public static CampaignListResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignListResponseMetaFromRaw : IFromRawJson<CampaignListResponseMeta>
{
    /// <inheritdoc/>
    public CampaignListResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignListResponseMeta.FromRawUnchecked(rawData);
}
