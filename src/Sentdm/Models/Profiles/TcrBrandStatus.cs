using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Exceptions;

namespace Sentdm.Models.Profiles;

[JsonConverter(typeof(TcrBrandStatusConverter))]
public enum TcrBrandStatus
{
    Active,
    Inactive,
    Suspended,
}

sealed class TcrBrandStatusConverter : JsonConverter<TcrBrandStatus>
{
    public override TcrBrandStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACTIVE" => TcrBrandStatus.Active,
            "INACTIVE" => TcrBrandStatus.Inactive,
            "SUSPENDED" => TcrBrandStatus.Suspended,
            _ => (TcrBrandStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TcrBrandStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TcrBrandStatus.Active => "ACTIVE",
                TcrBrandStatus.Inactive => "INACTIVE",
                TcrBrandStatus.Suspended => "SUSPENDED",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
