using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Brands;

namespace Sentdm.Tests.Models.Brands;

public class TcrVerticalTest : TestBase
{
    [Theory]
    [InlineData(TcrVertical.Professional)]
    [InlineData(TcrVertical.RealEstate)]
    [InlineData(TcrVertical.Healthcare)]
    [InlineData(TcrVertical.HumanResources)]
    [InlineData(TcrVertical.Energy)]
    [InlineData(TcrVertical.Entertainment)]
    [InlineData(TcrVertical.Retail)]
    [InlineData(TcrVertical.Transportation)]
    [InlineData(TcrVertical.Agriculture)]
    [InlineData(TcrVertical.Insurance)]
    [InlineData(TcrVertical.Postal)]
    [InlineData(TcrVertical.Education)]
    [InlineData(TcrVertical.Hospitality)]
    [InlineData(TcrVertical.Financial)]
    [InlineData(TcrVertical.Political)]
    [InlineData(TcrVertical.Gambling)]
    [InlineData(TcrVertical.Legal)]
    [InlineData(TcrVertical.Construction)]
    [InlineData(TcrVertical.Ngo)]
    [InlineData(TcrVertical.Manufacturing)]
    [InlineData(TcrVertical.Government)]
    [InlineData(TcrVertical.Technology)]
    [InlineData(TcrVertical.Communication)]
    public void Validation_Works(TcrVertical rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TcrVertical> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TcrVertical>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentDmInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TcrVertical.Professional)]
    [InlineData(TcrVertical.RealEstate)]
    [InlineData(TcrVertical.Healthcare)]
    [InlineData(TcrVertical.HumanResources)]
    [InlineData(TcrVertical.Energy)]
    [InlineData(TcrVertical.Entertainment)]
    [InlineData(TcrVertical.Retail)]
    [InlineData(TcrVertical.Transportation)]
    [InlineData(TcrVertical.Agriculture)]
    [InlineData(TcrVertical.Insurance)]
    [InlineData(TcrVertical.Postal)]
    [InlineData(TcrVertical.Education)]
    [InlineData(TcrVertical.Hospitality)]
    [InlineData(TcrVertical.Financial)]
    [InlineData(TcrVertical.Political)]
    [InlineData(TcrVertical.Gambling)]
    [InlineData(TcrVertical.Legal)]
    [InlineData(TcrVertical.Construction)]
    [InlineData(TcrVertical.Ngo)]
    [InlineData(TcrVertical.Manufacturing)]
    [InlineData(TcrVertical.Government)]
    [InlineData(TcrVertical.Technology)]
    [InlineData(TcrVertical.Communication)]
    public void SerializationRoundtrip_Works(TcrVertical rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TcrVertical> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TcrVertical>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TcrVertical>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TcrVertical>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
