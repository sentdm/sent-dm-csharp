using System.Text.Json;
using SentDm.Core;
using SentDm.Exceptions;
using SentDm.Models.Brands;

namespace SentDm.Tests.Models.Brands;

public class TcrBrandRelationshipTest : TestBase
{
    [Theory]
    [InlineData(TcrBrandRelationship.BasicAccount)]
    [InlineData(TcrBrandRelationship.MediumAccount)]
    [InlineData(TcrBrandRelationship.LargeAccount)]
    [InlineData(TcrBrandRelationship.SmallAccount)]
    [InlineData(TcrBrandRelationship.KeyAccount)]
    public void Validation_Works(TcrBrandRelationship rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TcrBrandRelationship> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TcrBrandRelationship>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentDmInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TcrBrandRelationship.BasicAccount)]
    [InlineData(TcrBrandRelationship.MediumAccount)]
    [InlineData(TcrBrandRelationship.LargeAccount)]
    [InlineData(TcrBrandRelationship.SmallAccount)]
    [InlineData(TcrBrandRelationship.KeyAccount)]
    public void SerializationRoundtrip_Works(TcrBrandRelationship rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TcrBrandRelationship> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TcrBrandRelationship>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TcrBrandRelationship>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TcrBrandRelationship>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
