using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class TcrBrandStatusTest : TestBase
{
    [Theory]
    [InlineData(TcrBrandStatus.Active)]
    [InlineData(TcrBrandStatus.Inactive)]
    [InlineData(TcrBrandStatus.Suspended)]
    public void Validation_Works(TcrBrandStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TcrBrandStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TcrBrandStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TcrBrandStatus.Active)]
    [InlineData(TcrBrandStatus.Inactive)]
    [InlineData(TcrBrandStatus.Suspended)]
    public void SerializationRoundtrip_Works(TcrBrandStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TcrBrandStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TcrBrandStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TcrBrandStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TcrBrandStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
