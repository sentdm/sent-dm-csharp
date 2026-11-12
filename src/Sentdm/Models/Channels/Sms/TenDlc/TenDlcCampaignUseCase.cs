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
    public required ApiEnum<string, UseCase> UseCase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UseCase>>("use_case");
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
[JsonConverter(typeof(UseCaseConverter))]
public enum UseCase
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

sealed class UseCaseConverter : JsonConverter<UseCase>
{
    public override UseCase Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MARKETING" => UseCase.Marketing,
            "ACCOUNT_NOTIFICATION" => UseCase.AccountNotification,
            "CUSTOMER_CARE" => UseCase.CustomerCare,
            "FRAUD_ALERT" => UseCase.FraudAlert,
            "2FA" => UseCase.V2Fa,
            "DELIVERY_NOTIFICATION" => UseCase.DeliveryNotification,
            "SECURITY_ALERT" => UseCase.SecurityAlert,
            "M2M" => UseCase.M2M,
            "HIGHER_EDUCATION" => UseCase.HigherEducation,
            "POLLING_VOTING" => UseCase.PollingVoting,
            "PUBLIC_SERVICE_ANNOUNCEMENT" => UseCase.PublicServiceAnnouncement,
            _ => (UseCase)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, UseCase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UseCase.Marketing => "MARKETING",
                UseCase.AccountNotification => "ACCOUNT_NOTIFICATION",
                UseCase.CustomerCare => "CUSTOMER_CARE",
                UseCase.FraudAlert => "FRAUD_ALERT",
                UseCase.V2Fa => "2FA",
                UseCase.DeliveryNotification => "DELIVERY_NOTIFICATION",
                UseCase.SecurityAlert => "SECURITY_ALERT",
                UseCase.M2M => "M2M",
                UseCase.HigherEducation => "HIGHER_EDUCATION",
                UseCase.PollingVoting => "POLLING_VOTING",
                UseCase.PublicServiceAnnouncement => "PUBLIC_SERVICE_ANNOUNCEMENT",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
