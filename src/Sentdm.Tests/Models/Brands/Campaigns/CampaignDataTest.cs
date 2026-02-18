using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Brands.Campaigns;

namespace Sentdm.Tests.Models.Brands.Campaigns;

public class CampaignDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CampaignData
        {
            Description = "x",
            Name = "x",
            Type = "x",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "https://example.com",
            TermsAndConditionsLink = "https://example.com",
        };

        string expectedDescription = "x";
        string expectedName = "x";
        string expectedType = "x";
        List<SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData> expectedUseCases =
        [
            new()
            {
                MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                SampleMessages = ["string"],
            },
        ];
        string expectedHelpKeywords = "helpKeywords";
        string expectedHelpMessage = "helpMessage";
        string expectedMessageFlow = "messageFlow";
        string expectedOptinKeywords = "optinKeywords";
        string expectedOptinMessage = "optinMessage";
        string expectedOptoutKeywords = "optoutKeywords";
        string expectedOptoutMessage = "optoutMessage";
        string expectedPrivacyPolicyLink = "https://example.com";
        string expectedTermsAndConditionsLink = "https://example.com";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUseCases.Count, model.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], model.UseCases[i]);
        }
        Assert.Equal(expectedHelpKeywords, model.HelpKeywords);
        Assert.Equal(expectedHelpMessage, model.HelpMessage);
        Assert.Equal(expectedMessageFlow, model.MessageFlow);
        Assert.Equal(expectedOptinKeywords, model.OptinKeywords);
        Assert.Equal(expectedOptinMessage, model.OptinMessage);
        Assert.Equal(expectedOptoutKeywords, model.OptoutKeywords);
        Assert.Equal(expectedOptoutMessage, model.OptoutMessage);
        Assert.Equal(expectedPrivacyPolicyLink, model.PrivacyPolicyLink);
        Assert.Equal(expectedTermsAndConditionsLink, model.TermsAndConditionsLink);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CampaignData
        {
            Description = "x",
            Name = "x",
            Type = "x",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "https://example.com",
            TermsAndConditionsLink = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CampaignData
        {
            Description = "x",
            Name = "x",
            Type = "x",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "https://example.com",
            TermsAndConditionsLink = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "x";
        string expectedName = "x";
        string expectedType = "x";
        List<SentDmServicesEndpointsCustomerApIv3ContractsRequestsCampaignsCampaignUseCaseData> expectedUseCases =
        [
            new()
            {
                MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                SampleMessages = ["string"],
            },
        ];
        string expectedHelpKeywords = "helpKeywords";
        string expectedHelpMessage = "helpMessage";
        string expectedMessageFlow = "messageFlow";
        string expectedOptinKeywords = "optinKeywords";
        string expectedOptinMessage = "optinMessage";
        string expectedOptoutKeywords = "optoutKeywords";
        string expectedOptoutMessage = "optoutMessage";
        string expectedPrivacyPolicyLink = "https://example.com";
        string expectedTermsAndConditionsLink = "https://example.com";

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUseCases.Count, deserialized.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], deserialized.UseCases[i]);
        }
        Assert.Equal(expectedHelpKeywords, deserialized.HelpKeywords);
        Assert.Equal(expectedHelpMessage, deserialized.HelpMessage);
        Assert.Equal(expectedMessageFlow, deserialized.MessageFlow);
        Assert.Equal(expectedOptinKeywords, deserialized.OptinKeywords);
        Assert.Equal(expectedOptinMessage, deserialized.OptinMessage);
        Assert.Equal(expectedOptoutKeywords, deserialized.OptoutKeywords);
        Assert.Equal(expectedOptoutMessage, deserialized.OptoutMessage);
        Assert.Equal(expectedPrivacyPolicyLink, deserialized.PrivacyPolicyLink);
        Assert.Equal(expectedTermsAndConditionsLink, deserialized.TermsAndConditionsLink);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CampaignData
        {
            Description = "x",
            Name = "x",
            Type = "x",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "https://example.com",
            TermsAndConditionsLink = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CampaignData
        {
            Description = "x",
            Name = "x",
            Type = "x",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
        };

        Assert.Null(model.HelpKeywords);
        Assert.False(model.RawData.ContainsKey("helpKeywords"));
        Assert.Null(model.HelpMessage);
        Assert.False(model.RawData.ContainsKey("helpMessage"));
        Assert.Null(model.MessageFlow);
        Assert.False(model.RawData.ContainsKey("messageFlow"));
        Assert.Null(model.OptinKeywords);
        Assert.False(model.RawData.ContainsKey("optinKeywords"));
        Assert.Null(model.OptinMessage);
        Assert.False(model.RawData.ContainsKey("optinMessage"));
        Assert.Null(model.OptoutKeywords);
        Assert.False(model.RawData.ContainsKey("optoutKeywords"));
        Assert.Null(model.OptoutMessage);
        Assert.False(model.RawData.ContainsKey("optoutMessage"));
        Assert.Null(model.PrivacyPolicyLink);
        Assert.False(model.RawData.ContainsKey("privacyPolicyLink"));
        Assert.Null(model.TermsAndConditionsLink);
        Assert.False(model.RawData.ContainsKey("termsAndConditionsLink"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CampaignData
        {
            Description = "x",
            Name = "x",
            Type = "x",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CampaignData
        {
            Description = "x",
            Name = "x",
            Type = "x",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],

            HelpKeywords = null,
            HelpMessage = null,
            MessageFlow = null,
            OptinKeywords = null,
            OptinMessage = null,
            OptoutKeywords = null,
            OptoutMessage = null,
            PrivacyPolicyLink = null,
            TermsAndConditionsLink = null,
        };

        Assert.Null(model.HelpKeywords);
        Assert.True(model.RawData.ContainsKey("helpKeywords"));
        Assert.Null(model.HelpMessage);
        Assert.True(model.RawData.ContainsKey("helpMessage"));
        Assert.Null(model.MessageFlow);
        Assert.True(model.RawData.ContainsKey("messageFlow"));
        Assert.Null(model.OptinKeywords);
        Assert.True(model.RawData.ContainsKey("optinKeywords"));
        Assert.Null(model.OptinMessage);
        Assert.True(model.RawData.ContainsKey("optinMessage"));
        Assert.Null(model.OptoutKeywords);
        Assert.True(model.RawData.ContainsKey("optoutKeywords"));
        Assert.Null(model.OptoutMessage);
        Assert.True(model.RawData.ContainsKey("optoutMessage"));
        Assert.Null(model.PrivacyPolicyLink);
        Assert.True(model.RawData.ContainsKey("privacyPolicyLink"));
        Assert.Null(model.TermsAndConditionsLink);
        Assert.True(model.RawData.ContainsKey("termsAndConditionsLink"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CampaignData
        {
            Description = "x",
            Name = "x",
            Type = "x",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],

            HelpKeywords = null,
            HelpMessage = null,
            MessageFlow = null,
            OptinKeywords = null,
            OptinMessage = null,
            OptoutKeywords = null,
            OptoutMessage = null,
            PrivacyPolicyLink = null,
            TermsAndConditionsLink = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CampaignData
        {
            Description = "x",
            Name = "x",
            Type = "x",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "https://example.com",
            TermsAndConditionsLink = "https://example.com",
        };

        CampaignData copied = new(model);

        Assert.Equal(model, copied);
    }
}
