using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Brands.Campaigns;

namespace Sentdm.Tests.Models.Brands.Campaigns;

public class MessagingUseCaseUsTest : TestBase
{
    [Theory]
    [InlineData(MessagingUseCaseUs.Marketing)]
    [InlineData(MessagingUseCaseUs.AccountNotification)]
    [InlineData(MessagingUseCaseUs.CustomerCare)]
    [InlineData(MessagingUseCaseUs.FraudAlert)]
    [InlineData(MessagingUseCaseUs.TwoFa)]
    [InlineData(MessagingUseCaseUs.DeliveryNotification)]
    [InlineData(MessagingUseCaseUs.SecurityAlert)]
    [InlineData(MessagingUseCaseUs.M2M)]
    [InlineData(MessagingUseCaseUs.Mixed)]
    [InlineData(MessagingUseCaseUs.HigherEducation)]
    [InlineData(MessagingUseCaseUs.PollingVoting)]
    [InlineData(MessagingUseCaseUs.PublicServiceAnnouncement)]
    [InlineData(MessagingUseCaseUs.LowVolume)]
    public void Validation_Works(MessagingUseCaseUs rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessagingUseCaseUs> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessagingUseCaseUs>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentDmInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MessagingUseCaseUs.Marketing)]
    [InlineData(MessagingUseCaseUs.AccountNotification)]
    [InlineData(MessagingUseCaseUs.CustomerCare)]
    [InlineData(MessagingUseCaseUs.FraudAlert)]
    [InlineData(MessagingUseCaseUs.TwoFa)]
    [InlineData(MessagingUseCaseUs.DeliveryNotification)]
    [InlineData(MessagingUseCaseUs.SecurityAlert)]
    [InlineData(MessagingUseCaseUs.M2M)]
    [InlineData(MessagingUseCaseUs.Mixed)]
    [InlineData(MessagingUseCaseUs.HigherEducation)]
    [InlineData(MessagingUseCaseUs.PollingVoting)]
    [InlineData(MessagingUseCaseUs.PublicServiceAnnouncement)]
    [InlineData(MessagingUseCaseUs.LowVolume)]
    public void SerializationRoundtrip_Works(MessagingUseCaseUs rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessagingUseCaseUs> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessagingUseCaseUs>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessagingUseCaseUs>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessagingUseCaseUs>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
