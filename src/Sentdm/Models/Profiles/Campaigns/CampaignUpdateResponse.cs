using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Profiles.Campaigns;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CampaignUpdateResponse, CampaignUpdateResponseFromRaw>))]
public sealed record class CampaignUpdateResponse : JsonModel
{
    /// <summary>
    /// A 10DLC campaign registered for a brand.
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
    public ErrorDetail? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ErrorDetail>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public ApiMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiMeta>("meta");
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
/// A 10DLC campaign registered for a brand.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CampaignUpdateResponseData, CampaignUpdateResponseDataFromRaw>)
)]
public sealed record class CampaignUpdateResponseData : JsonModel
{
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

    /// <summary>
    /// True once every carrier has completed its DCA election and the campaign is
    /// operationally ready for traffic.
    /// </summary>
    public bool? DcaElectionsComplete
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("dcaElectionsComplete");
        }
        init { this._rawData.Set("dcaElectionsComplete", value); }
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

    /// <summary>
    /// True when the one-time campaign submission fee has already been charged.
    /// </summary>
    public bool? HasSubmissionTransaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasSubmissionTransaction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasSubmissionTransaction", value);
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

    /// <summary>
    /// The Campaign Registry identifier, once the campaign has been accepted.
    /// </summary>
    public string? TcrCampaignID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tcrCampaignId");
        }
        init { this._rawData.Set("tcrCampaignId", value); }
    }

    /// <summary>
    /// Surfaced so customers can see why a submission did not reach the registry.
    /// </summary>
    public string? TcrSyncError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tcrSyncError");
        }
        init { this._rawData.Set("tcrSyncError", value); }
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

    /// <summary>
    /// Campaign type (for example KYC or App).
    /// </summary>
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

    /// <summary>
    /// Expected messaging volume for this campaign — customer-supplied on create/update,
    /// and the             input to both the TCR usecase classification (LOW_VOLUME
    /// vs MIXED/specific) and the campaign fee             tier. Surfaced so customers
    /// can read back the value they set.
    /// </summary>
    public string? Volume
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("volume");
        }
        init { this._rawData.Set("volume", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BilledDate;
        _ = this.BrandID;
        _ = this.Cost;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        _ = this.DcaElectionsComplete;
        _ = this.DcaElectionsCompletedAt;
        _ = this.Description;
        _ = this.HasSubmissionTransaction;
        _ = this.HelpKeywords;
        _ = this.HelpMessage;
        _ = this.MessageFlow;
        _ = this.Name;
        _ = this.OptinKeywords;
        _ = this.OptinMessage;
        _ = this.OptoutKeywords;
        _ = this.OptoutMessage;
        _ = this.PrivacyPolicyLink;
        this.Status?.Validate();
        _ = this.SubmittedAt;
        _ = this.SubmittedToTcr;
        _ = this.TcrCampaignID;
        _ = this.TcrSyncError;
        _ = this.TermsAndConditionsLink;
        _ = this.Type;
        _ = this.UpdatedAt;
        foreach (var item in this.UseCases ?? [])
        {
            item.Validate();
        }
        _ = this.Volume;
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

/// <summary>
/// Customer-facing use-case representation for the public v3 campaign contract. Exists
/// for the same reason as BrandCampaignV3Response: nesting the TcrCampaignUseCase
/// database entity in a public response means any column added to that table silently
/// becomes part of the customer-facing contract. This DTO is an explicit allowlist,
/// so a new column stays invisible until it is added here on purpose. This mirrors
/// exactly the fields the entity already serialized, so it removes nothing from
/// the current response shape. It only closes the future-leak path.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CampaignUpdateResponseDataUseCase,
        CampaignUpdateResponseDataUseCaseFromRaw
    >)
)]
public sealed record class CampaignUpdateResponseDataUseCase : JsonModel
{
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

    public ApiEnum<string, MessagingUseCaseUs>? MessagingUseCaseUs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingUseCaseUs>>(
                "messagingUseCaseUs"
            );
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

    /// <summary>
    /// Sample messages submitted to the registry for this use case.
    /// </summary>
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
