using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Exceptions;

namespace SentDm.Models.Brands;

[JsonConverter(typeof(TcrBrandRelationshipConverter))]
public enum TcrBrandRelationship
{
    BasicAccount,
    MediumAccount,
    LargeAccount,
    SmallAccount,
    KeyAccount,
}

sealed class TcrBrandRelationshipConverter : JsonConverter<TcrBrandRelationship>
{
    public override TcrBrandRelationship Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BASIC_ACCOUNT" => TcrBrandRelationship.BasicAccount,
            "MEDIUM_ACCOUNT" => TcrBrandRelationship.MediumAccount,
            "LARGE_ACCOUNT" => TcrBrandRelationship.LargeAccount,
            "SMALL_ACCOUNT" => TcrBrandRelationship.SmallAccount,
            "KEY_ACCOUNT" => TcrBrandRelationship.KeyAccount,
            _ => (TcrBrandRelationship)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TcrBrandRelationship value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TcrBrandRelationship.BasicAccount => "BASIC_ACCOUNT",
                TcrBrandRelationship.MediumAccount => "MEDIUM_ACCOUNT",
                TcrBrandRelationship.LargeAccount => "LARGE_ACCOUNT",
                TcrBrandRelationship.SmallAccount => "SMALL_ACCOUNT",
                TcrBrandRelationship.KeyAccount => "KEY_ACCOUNT",
                _ => throw new SentDmInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
