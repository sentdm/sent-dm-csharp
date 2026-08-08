using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Profiles.Campaigns;

namespace Sentdm.Tests.Models.Profiles.Campaigns;

public class CampaignUseCaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CampaignUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, MessagingUseCaseUs> expectedMessagingUseCaseUs =
            MessagingUseCaseUs.Marketing;
        List<string> expectedSampleMessages = ["string"];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCampaignID, model.CampaignID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedMessagingUseCaseUs, model.MessagingUseCaseUs);
        Assert.NotNull(model.SampleMessages);
        Assert.Equal(expectedSampleMessages.Count, model.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], model.SampleMessages[i]);
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CampaignUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignUseCase>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CampaignUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignUseCase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, MessagingUseCaseUs> expectedMessagingUseCaseUs =
            MessagingUseCaseUs.Marketing;
        List<string> expectedSampleMessages = ["string"];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCampaignID, deserialized.CampaignID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedMessagingUseCaseUs, deserialized.MessagingUseCaseUs);
        Assert.NotNull(deserialized.SampleMessages);
        Assert.Equal(expectedSampleMessages.Count, deserialized.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], deserialized.SampleMessages[i]);
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CampaignUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CampaignUseCase
        {
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CampaignID);
        Assert.False(model.RawData.ContainsKey("campaignId"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customerId"));
        Assert.Null(model.MessagingUseCaseUs);
        Assert.False(model.RawData.ContainsKey("messagingUseCaseUs"));
        Assert.Null(model.SampleMessages);
        Assert.False(model.RawData.ContainsKey("sampleMessages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CampaignUseCase
        {
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CampaignUseCase
        {
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            CampaignID = null,
            CreatedAt = null,
            CustomerID = null,
            MessagingUseCaseUs = null,
            SampleMessages = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CampaignID);
        Assert.False(model.RawData.ContainsKey("campaignId"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customerId"));
        Assert.Null(model.MessagingUseCaseUs);
        Assert.False(model.RawData.ContainsKey("messagingUseCaseUs"));
        Assert.Null(model.SampleMessages);
        Assert.False(model.RawData.ContainsKey("sampleMessages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CampaignUseCase
        {
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            CampaignID = null,
            CreatedAt = null,
            CustomerID = null,
            MessagingUseCaseUs = null,
            SampleMessages = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CampaignUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CampaignUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CampaignUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],

            UpdatedAt = null,
        };

        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CampaignUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],

            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CampaignUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CampaignUseCase copied = new(model);

        Assert.Equal(model, copied);
    }
}
