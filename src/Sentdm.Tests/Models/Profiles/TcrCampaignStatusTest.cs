using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class TcrCampaignStatusTest : TestBase
{
    [Theory]
    [InlineData(TcrCampaignStatus.SentCreated)]
    [InlineData(TcrCampaignStatus.Active)]
    [InlineData(TcrCampaignStatus.Expired)]
    public void Validation_Works(TcrCampaignStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TcrCampaignStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TcrCampaignStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TcrCampaignStatus.SentCreated)]
    [InlineData(TcrCampaignStatus.Active)]
    [InlineData(TcrCampaignStatus.Expired)]
    public void SerializationRoundtrip_Works(TcrCampaignStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TcrCampaignStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TcrCampaignStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TcrCampaignStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TcrCampaignStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
