using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Channels.Sms.TenDlc;

namespace Sentdm.Tests.Models.Channels.Sms.TenDlc;

public class TenDlcCampaignUseCaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TenDlcCampaignUseCase
        {
            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
            UseCase = UseCase.Marketing,
        };

        List<JsonElement> expectedSampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")];
        ApiEnum<string, UseCase> expectedUseCase = UseCase.Marketing;

        Assert.Equal(expectedSampleMessages.Count, model.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSampleMessages[i], model.SampleMessages[i]));
        }
        Assert.Equal(expectedUseCase, model.UseCase);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TenDlcCampaignUseCase
        {
            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
            UseCase = UseCase.Marketing,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TenDlcCampaignUseCase>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TenDlcCampaignUseCase
        {
            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
            UseCase = UseCase.Marketing,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TenDlcCampaignUseCase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<JsonElement> expectedSampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")];
        ApiEnum<string, UseCase> expectedUseCase = UseCase.Marketing;

        Assert.Equal(expectedSampleMessages.Count, deserialized.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.True(
                JsonElement.DeepEquals(expectedSampleMessages[i], deserialized.SampleMessages[i])
            );
        }
        Assert.Equal(expectedUseCase, deserialized.UseCase);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TenDlcCampaignUseCase
        {
            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
            UseCase = UseCase.Marketing,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TenDlcCampaignUseCase
        {
            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
            UseCase = UseCase.Marketing,
        };

        TenDlcCampaignUseCase copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UseCaseTest : TestBase
{
    [Theory]
    [InlineData(UseCase.Marketing)]
    [InlineData(UseCase.AccountNotification)]
    [InlineData(UseCase.CustomerCare)]
    [InlineData(UseCase.FraudAlert)]
    [InlineData(UseCase.V2Fa)]
    [InlineData(UseCase.DeliveryNotification)]
    [InlineData(UseCase.SecurityAlert)]
    [InlineData(UseCase.M2M)]
    [InlineData(UseCase.HigherEducation)]
    [InlineData(UseCase.PollingVoting)]
    [InlineData(UseCase.PublicServiceAnnouncement)]
    public void Validation_Works(UseCase rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UseCase> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UseCase>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UseCase.Marketing)]
    [InlineData(UseCase.AccountNotification)]
    [InlineData(UseCase.CustomerCare)]
    [InlineData(UseCase.FraudAlert)]
    [InlineData(UseCase.V2Fa)]
    [InlineData(UseCase.DeliveryNotification)]
    [InlineData(UseCase.SecurityAlert)]
    [InlineData(UseCase.M2M)]
    [InlineData(UseCase.HigherEducation)]
    [InlineData(UseCase.PollingVoting)]
    [InlineData(UseCase.PublicServiceAnnouncement)]
    public void SerializationRoundtrip_Works(UseCase rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UseCase> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UseCase>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UseCase>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UseCase>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
