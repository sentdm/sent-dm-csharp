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
            UseCase = TenDlcCampaignUseCaseUseCase.Marketing,
        };

        List<JsonElement> expectedSampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")];
        ApiEnum<string, TenDlcCampaignUseCaseUseCase> expectedUseCase =
            TenDlcCampaignUseCaseUseCase.Marketing;

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
            UseCase = TenDlcCampaignUseCaseUseCase.Marketing,
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
            UseCase = TenDlcCampaignUseCaseUseCase.Marketing,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TenDlcCampaignUseCase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<JsonElement> expectedSampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")];
        ApiEnum<string, TenDlcCampaignUseCaseUseCase> expectedUseCase =
            TenDlcCampaignUseCaseUseCase.Marketing;

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
            UseCase = TenDlcCampaignUseCaseUseCase.Marketing,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TenDlcCampaignUseCase
        {
            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
            UseCase = TenDlcCampaignUseCaseUseCase.Marketing,
        };

        TenDlcCampaignUseCase copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TenDlcCampaignUseCaseUseCaseTest : TestBase
{
    [Theory]
    [InlineData(TenDlcCampaignUseCaseUseCase.Marketing)]
    [InlineData(TenDlcCampaignUseCaseUseCase.AccountNotification)]
    [InlineData(TenDlcCampaignUseCaseUseCase.CustomerCare)]
    [InlineData(TenDlcCampaignUseCaseUseCase.FraudAlert)]
    [InlineData(TenDlcCampaignUseCaseUseCase.V2Fa)]
    [InlineData(TenDlcCampaignUseCaseUseCase.DeliveryNotification)]
    [InlineData(TenDlcCampaignUseCaseUseCase.SecurityAlert)]
    [InlineData(TenDlcCampaignUseCaseUseCase.M2M)]
    [InlineData(TenDlcCampaignUseCaseUseCase.HigherEducation)]
    [InlineData(TenDlcCampaignUseCaseUseCase.PollingVoting)]
    [InlineData(TenDlcCampaignUseCaseUseCase.PublicServiceAnnouncement)]
    public void Validation_Works(TenDlcCampaignUseCaseUseCase rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TenDlcCampaignUseCaseUseCase> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TenDlcCampaignUseCaseUseCase>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TenDlcCampaignUseCaseUseCase.Marketing)]
    [InlineData(TenDlcCampaignUseCaseUseCase.AccountNotification)]
    [InlineData(TenDlcCampaignUseCaseUseCase.CustomerCare)]
    [InlineData(TenDlcCampaignUseCaseUseCase.FraudAlert)]
    [InlineData(TenDlcCampaignUseCaseUseCase.V2Fa)]
    [InlineData(TenDlcCampaignUseCaseUseCase.DeliveryNotification)]
    [InlineData(TenDlcCampaignUseCaseUseCase.SecurityAlert)]
    [InlineData(TenDlcCampaignUseCaseUseCase.M2M)]
    [InlineData(TenDlcCampaignUseCaseUseCase.HigherEducation)]
    [InlineData(TenDlcCampaignUseCaseUseCase.PollingVoting)]
    [InlineData(TenDlcCampaignUseCaseUseCase.PublicServiceAnnouncement)]
    public void SerializationRoundtrip_Works(TenDlcCampaignUseCaseUseCase rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TenDlcCampaignUseCaseUseCase> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TenDlcCampaignUseCaseUseCase>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TenDlcCampaignUseCaseUseCase>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TenDlcCampaignUseCaseUseCase>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
