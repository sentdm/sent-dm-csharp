using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;

namespace Sentdm.Models.Brands.Campaigns;

[JsonConverter(typeof(JsonModelConverter<TcrCampaignWithUseCases, TcrCampaignWithUseCasesFromRaw>))]
public sealed record class TcrCampaignWithUseCases : JsonModel
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

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
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

    public ApiEnum<string, SharingStatus>? SharingStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SharingStatus>>("sharingStatus");
        }
        init { this._rawData.Set("sharingStatus", value); }
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

    public string? UpstreamCnpID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("upstreamCnpId");
        }
        init { this._rawData.Set("upstreamCnpId", value); }
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

    public static implicit operator BaseDto(TcrCampaignWithUseCases tcrCampaignWithUseCases) =>
        new()
        {
            ID = tcrCampaignWithUseCases.ID,
            CreatedAt = tcrCampaignWithUseCases.CreatedAt,
            UpdatedAt = tcrCampaignWithUseCases.UpdatedAt,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
        _ = this.BilledDate;
        _ = this.BrandID;
        _ = this.Cost;
        _ = this.CspID;
        _ = this.CustomerID;
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
        _ = this.UpstreamCnpID;
        foreach (var item in this.UseCases ?? [])
        {
            item.Validate();
        }
    }

    public TcrCampaignWithUseCases() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TcrCampaignWithUseCases(TcrCampaignWithUseCases tcrCampaignWithUseCases)
        : base(tcrCampaignWithUseCases) { }
#pragma warning restore CS8618

    public TcrCampaignWithUseCases(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TcrCampaignWithUseCases(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TcrCampaignWithUseCasesFromRaw.FromRawUnchecked"/>
    public static TcrCampaignWithUseCases FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TcrCampaignWithUseCasesFromRaw : IFromRawJson<TcrCampaignWithUseCases>
{
    /// <inheritdoc/>
    public TcrCampaignWithUseCases FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TcrCampaignWithUseCases.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
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

    public ApiEnum<string, SharingStatus>? SharingStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SharingStatus>>("sharingStatus");
        }
        init { this._rawData.Set("sharingStatus", value); }
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

    public string? UpstreamCnpID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("upstreamCnpId");
        }
        init { this._rawData.Set("upstreamCnpId", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BilledDate;
        _ = this.BrandID;
        _ = this.Cost;
        _ = this.CspID;
        _ = this.CustomerID;
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
        _ = this.UpstreamCnpID;
        foreach (var item in this.UseCases ?? [])
        {
            item.Validate();
        }
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1(IntersectionMember1 intersectionMember1)
        : base(intersectionMember1) { }
#pragma warning restore CS8618

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SharingStatusConverter))]
public enum SharingStatus
{
    Pending,
    Accepted,
    Declined,
}

sealed class SharingStatusConverter : JsonConverter<SharingStatus>
{
    public override SharingStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PENDING" => SharingStatus.Pending,
            "ACCEPTED" => SharingStatus.Accepted,
            "DECLINED" => SharingStatus.Declined,
            _ => (SharingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SharingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SharingStatus.Pending => "PENDING",
                SharingStatus.Accepted => "ACCEPTED",
                SharingStatus.Declined => "DECLINED",
                _ => throw new SentDmInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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
                _ => throw new SentDmInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<UseCase, UseCaseFromRaw>))]
public sealed record class UseCase : JsonModel
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

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
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

    public static implicit operator BaseDto(UseCase useCase) =>
        new()
        {
            ID = useCase.ID,
            CreatedAt = useCase.CreatedAt,
            UpdatedAt = useCase.UpdatedAt,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
        _ = this.CampaignID;
        _ = this.CustomerID;
        this.MessagingUseCaseUs?.Validate();
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

[JsonConverter(
    typeof(JsonModelConverter<UseCaseIntersectionMember1, UseCaseIntersectionMember1FromRaw>)
)]
public sealed record class UseCaseIntersectionMember1 : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CampaignID;
        _ = this.CustomerID;
        this.MessagingUseCaseUs?.Validate();
        _ = this.SampleMessages;
    }

    public UseCaseIntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UseCaseIntersectionMember1(UseCaseIntersectionMember1 useCaseIntersectionMember1)
        : base(useCaseIntersectionMember1) { }
#pragma warning restore CS8618

    public UseCaseIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UseCaseIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UseCaseIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static UseCaseIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UseCaseIntersectionMember1FromRaw : IFromRawJson<UseCaseIntersectionMember1>
{
    /// <inheritdoc/>
    public UseCaseIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UseCaseIntersectionMember1.FromRawUnchecked(rawData);
}
