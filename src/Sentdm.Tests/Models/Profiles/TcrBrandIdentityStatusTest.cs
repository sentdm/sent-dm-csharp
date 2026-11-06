using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class TcrBrandIdentityStatusTest : TestBase
{
    [Theory]
    [InlineData(TcrBrandIdentityStatus.SelfDeclared)]
    [InlineData(TcrBrandIdentityStatus.Unverified)]
    [InlineData(TcrBrandIdentityStatus.Verified)]
    [InlineData(TcrBrandIdentityStatus.VettedVerified)]
    public void Validation_Works(TcrBrandIdentityStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TcrBrandIdentityStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TcrBrandIdentityStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TcrBrandIdentityStatus.SelfDeclared)]
    [InlineData(TcrBrandIdentityStatus.Unverified)]
    [InlineData(TcrBrandIdentityStatus.Verified)]
    [InlineData(TcrBrandIdentityStatus.VettedVerified)]
    public void SerializationRoundtrip_Works(TcrBrandIdentityStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TcrBrandIdentityStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TcrBrandIdentityStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TcrBrandIdentityStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TcrBrandIdentityStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
