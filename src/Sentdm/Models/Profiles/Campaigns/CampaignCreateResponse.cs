using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;
using Webhooks = Sentdm.Models.Webhooks;

namespace Sentdm.Models.Profiles.Campaigns;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CampaignCreateResponse, CampaignCreateResponseFromRaw>))]
public sealed record class CampaignCreateResponse : JsonModel
{
    /// <summary>
    /// A 10DLC campaign registered for a brand.
    /// </summary>
    public Data? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public Webhooks::ErrorDetail? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Webhooks::ErrorDetail>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public Webhooks::ApiMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Webhooks::ApiMeta>("meta");
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

    public CampaignCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignCreateResponse(CampaignCreateResponse campaignCreateResponse)
        : base(campaignCreateResponse) { }
#pragma warning restore CS8618

    public CampaignCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignCreateResponseFromRaw.FromRawUnchecked"/>
    public static CampaignCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignCreateResponseFromRaw : IFromRawJson<CampaignCreateResponse>
{
    /// <inheritdoc/>
    public CampaignCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A 10DLC campaign registered for a brand.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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

    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
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

    public IReadOnlyList<UseCase>? UseCases
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<UseCase>>("useCases");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<UseCase>?>(
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

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    SentCreated,
    Active,
    Expired,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SENT_CREATED" => Status.SentCreated,
            "ACTIVE" => Status.Active,
            "EXPIRED" => Status.Expired,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.SentCreated => "SENT_CREATED",
                Status.Active => "ACTIVE",
                Status.Expired => "EXPIRED",
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
[JsonConverter(typeof(JsonModelConverter<UseCase, UseCaseFromRaw>))]
public sealed record class UseCase : JsonModel
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
