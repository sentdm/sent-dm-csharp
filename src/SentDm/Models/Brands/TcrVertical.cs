using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Exceptions;

namespace SentDm.Models.Brands;

[JsonConverter(typeof(TcrVerticalConverter))]
public enum TcrVertical
{
    Professional,
    RealEstate,
    Healthcare,
    HumanResources,
    Energy,
    Entertainment,
    Retail,
    Transportation,
    Agriculture,
    Insurance,
    Postal,
    Education,
    Hospitality,
    Financial,
    Political,
    Gambling,
    Legal,
    Construction,
    Ngo,
    Manufacturing,
    Government,
    Technology,
    Communication,
}

sealed class TcrVerticalConverter : JsonConverter<TcrVertical>
{
    public override TcrVertical Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PROFESSIONAL" => TcrVertical.Professional,
            "REAL_ESTATE" => TcrVertical.RealEstate,
            "HEALTHCARE" => TcrVertical.Healthcare,
            "HUMAN_RESOURCES" => TcrVertical.HumanResources,
            "ENERGY" => TcrVertical.Energy,
            "ENTERTAINMENT" => TcrVertical.Entertainment,
            "RETAIL" => TcrVertical.Retail,
            "TRANSPORTATION" => TcrVertical.Transportation,
            "AGRICULTURE" => TcrVertical.Agriculture,
            "INSURANCE" => TcrVertical.Insurance,
            "POSTAL" => TcrVertical.Postal,
            "EDUCATION" => TcrVertical.Education,
            "HOSPITALITY" => TcrVertical.Hospitality,
            "FINANCIAL" => TcrVertical.Financial,
            "POLITICAL" => TcrVertical.Political,
            "GAMBLING" => TcrVertical.Gambling,
            "LEGAL" => TcrVertical.Legal,
            "CONSTRUCTION" => TcrVertical.Construction,
            "NGO" => TcrVertical.Ngo,
            "MANUFACTURING" => TcrVertical.Manufacturing,
            "GOVERNMENT" => TcrVertical.Government,
            "TECHNOLOGY" => TcrVertical.Technology,
            "COMMUNICATION" => TcrVertical.Communication,
            _ => (TcrVertical)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TcrVertical value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TcrVertical.Professional => "PROFESSIONAL",
                TcrVertical.RealEstate => "REAL_ESTATE",
                TcrVertical.Healthcare => "HEALTHCARE",
                TcrVertical.HumanResources => "HUMAN_RESOURCES",
                TcrVertical.Energy => "ENERGY",
                TcrVertical.Entertainment => "ENTERTAINMENT",
                TcrVertical.Retail => "RETAIL",
                TcrVertical.Transportation => "TRANSPORTATION",
                TcrVertical.Agriculture => "AGRICULTURE",
                TcrVertical.Insurance => "INSURANCE",
                TcrVertical.Postal => "POSTAL",
                TcrVertical.Education => "EDUCATION",
                TcrVertical.Hospitality => "HOSPITALITY",
                TcrVertical.Financial => "FINANCIAL",
                TcrVertical.Political => "POLITICAL",
                TcrVertical.Gambling => "GAMBLING",
                TcrVertical.Legal => "LEGAL",
                TcrVertical.Construction => "CONSTRUCTION",
                TcrVertical.Ngo => "NGO",
                TcrVertical.Manufacturing => "MANUFACTURING",
                TcrVertical.Government => "GOVERNMENT",
                TcrVertical.Technology => "TECHNOLOGY",
                TcrVertical.Communication => "COMMUNICATION",
                _ => throw new SentDmInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
