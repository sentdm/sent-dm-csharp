using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Exceptions;

namespace Sentdm.Models.Brands.Campaigns;

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
                _ => throw new SentDmInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
