using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Brands.Campaigns;

namespace Sentdm.Tests.Models.Brands.Campaigns;

public class SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseDataTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData
            {
                MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                SampleMessages = ["string"],
            };

        ApiEnum<string, MessagingUseCaseUs> expectedMessagingUseCaseUs =
            MessagingUseCaseUs.Marketing;
        List<string> expectedSampleMessages = ["string"];

        Assert.Equal(expectedMessagingUseCaseUs, model.MessagingUseCaseUs);
        Assert.Equal(expectedSampleMessages.Count, model.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], model.SampleMessages[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData
            {
                MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                SampleMessages = ["string"],
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData
            {
                MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                SampleMessages = ["string"],
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, MessagingUseCaseUs> expectedMessagingUseCaseUs =
            MessagingUseCaseUs.Marketing;
        List<string> expectedSampleMessages = ["string"];

        Assert.Equal(expectedMessagingUseCaseUs, deserialized.MessagingUseCaseUs);
        Assert.Equal(expectedSampleMessages.Count, deserialized.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], deserialized.SampleMessages[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData
            {
                MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                SampleMessages = ["string"],
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData
            {
                MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                SampleMessages = ["string"],
            };

        SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData copied =
            new(model);

        Assert.Equal(model, copied);
    }
}
