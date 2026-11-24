using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;

namespace Sentdm.Models.Channels.Sms.TenDlc;

[JsonConverter(typeof(JsonModelConverter<TenDlcCampaignUseCase, TenDlcCampaignUseCaseFromRaw>))]
public sealed record class TenDlcCampaignUseCase : JsonModel
{
    /// <summary>
    /// Sample messages. TCR sample1..sample5 for this use case. One to five, each
    /// 20 to 1024 characters and carrying the brand name and an opt-out instruction.
    /// At most five across the campaign, and at least two when a high-volume campaign
    /// has a single use case.
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
    public required ApiEnum<string, TenDlcCampaignUseCaseUseCase> UseCase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TenDlcCampaignUseCaseUseCase>>(
                "use_case"
            );
        }
        init { this._rawData.Set("use_case", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SampleMessages;
        this.UseCase.Validate();
    }

    public TenDlcCampaignUseCase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TenDlcCampaignUseCase(TenDlcCampaignUseCase tenDlcCampaignUseCase)
        : base(tenDlcCampaignUseCase) { }
#pragma warning restore CS8618

    public TenDlcCampaignUseCase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenDlcCampaignUseCase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TenDlcCampaignUseCaseFromRaw.FromRawUnchecked"/>
    public static TenDlcCampaignUseCase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TenDlcCampaignUseCaseFromRaw : IFromRawJson<TenDlcCampaignUseCase>
{
    /// <inheritdoc/>
    public TenDlcCampaignUseCase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TenDlcCampaignUseCase.FromRawUnchecked(rawData);
}

/// <summary>
/// Use case. What this entry sends. MIXED and LOW_VOLUME are refused — volume decides those.
/// </summary>
[JsonConverter(typeof(TenDlcCampaignUseCaseUseCaseConverter))]
public enum TenDlcCampaignUseCaseUseCase
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

sealed class TenDlcCampaignUseCaseUseCaseConverter : JsonConverter<TenDlcCampaignUseCaseUseCase>
{
    public override TenDlcCampaignUseCaseUseCase Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MARKETING" => TenDlcCampaignUseCaseUseCase.Marketing,
            "ACCOUNT_NOTIFICATION" => TenDlcCampaignUseCaseUseCase.AccountNotification,
            "CUSTOMER_CARE" => TenDlcCampaignUseCaseUseCase.CustomerCare,
            "FRAUD_ALERT" => TenDlcCampaignUseCaseUseCase.FraudAlert,
            "2FA" => TenDlcCampaignUseCaseUseCase.V2Fa,
            "DELIVERY_NOTIFICATION" => TenDlcCampaignUseCaseUseCase.DeliveryNotification,
            "SECURITY_ALERT" => TenDlcCampaignUseCaseUseCase.SecurityAlert,
            "M2M" => TenDlcCampaignUseCaseUseCase.M2M,
            "HIGHER_EDUCATION" => TenDlcCampaignUseCaseUseCase.HigherEducation,
            "POLLING_VOTING" => TenDlcCampaignUseCaseUseCase.PollingVoting,
            "PUBLIC_SERVICE_ANNOUNCEMENT" => TenDlcCampaignUseCaseUseCase.PublicServiceAnnouncement,
            _ => (TenDlcCampaignUseCaseUseCase)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TenDlcCampaignUseCaseUseCase value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TenDlcCampaignUseCaseUseCase.Marketing => "MARKETING",
                TenDlcCampaignUseCaseUseCase.AccountNotification => "ACCOUNT_NOTIFICATION",
                TenDlcCampaignUseCaseUseCase.CustomerCare => "CUSTOMER_CARE",
                TenDlcCampaignUseCaseUseCase.FraudAlert => "FRAUD_ALERT",
                TenDlcCampaignUseCaseUseCase.V2Fa => "2FA",
                TenDlcCampaignUseCaseUseCase.DeliveryNotification => "DELIVERY_NOTIFICATION",
                TenDlcCampaignUseCaseUseCase.SecurityAlert => "SECURITY_ALERT",
                TenDlcCampaignUseCaseUseCase.M2M => "M2M",
                TenDlcCampaignUseCaseUseCase.HigherEducation => "HIGHER_EDUCATION",
                TenDlcCampaignUseCaseUseCase.PollingVoting => "POLLING_VOTING",
                TenDlcCampaignUseCaseUseCase.PublicServiceAnnouncement =>
                    "PUBLIC_SERVICE_ANNOUNCEMENT",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
