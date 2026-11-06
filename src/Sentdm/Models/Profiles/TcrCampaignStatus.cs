using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Exceptions;

namespace Sentdm.Models.Profiles;

[JsonConverter(typeof(TcrCampaignStatusConverter))]
public enum TcrCampaignStatus
{
    SentCreated,
    Active,
    Expired,
}

sealed class TcrCampaignStatusConverter : JsonConverter<TcrCampaignStatus>
{
    public override TcrCampaignStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SENT_CREATED" => TcrCampaignStatus.SentCreated,
            "ACTIVE" => TcrCampaignStatus.Active,
            "EXPIRED" => TcrCampaignStatus.Expired,
            _ => (TcrCampaignStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TcrCampaignStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TcrCampaignStatus.SentCreated => "SENT_CREATED",
                TcrCampaignStatus.Active => "ACTIVE",
                TcrCampaignStatus.Expired => "EXPIRED",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
