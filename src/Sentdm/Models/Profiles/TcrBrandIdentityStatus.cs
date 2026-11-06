using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Exceptions;

namespace Sentdm.Models.Profiles;

[JsonConverter(typeof(TcrBrandIdentityStatusConverter))]
public enum TcrBrandIdentityStatus
{
    SelfDeclared,
    Unverified,
    Verified,
    VettedVerified,
}

sealed class TcrBrandIdentityStatusConverter : JsonConverter<TcrBrandIdentityStatus>
{
    public override TcrBrandIdentityStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SELF_DECLARED" => TcrBrandIdentityStatus.SelfDeclared,
            "UNVERIFIED" => TcrBrandIdentityStatus.Unverified,
            "VERIFIED" => TcrBrandIdentityStatus.Verified,
            "VETTED_VERIFIED" => TcrBrandIdentityStatus.VettedVerified,
            _ => (TcrBrandIdentityStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TcrBrandIdentityStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TcrBrandIdentityStatus.SelfDeclared => "SELF_DECLARED",
                TcrBrandIdentityStatus.Unverified => "UNVERIFIED",
                TcrBrandIdentityStatus.Verified => "VERIFIED",
                TcrBrandIdentityStatus.VettedVerified => "VETTED_VERIFIED",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
