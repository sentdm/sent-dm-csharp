using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Profiles.Campaigns;

namespace Sentdm.Tests.Models.Profiles.Campaigns;

public class BrandCampaignTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandCampaign
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            HasSubmissionTransaction = true,
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            Name = "name",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TermsAndConditionsLink = "termsAndConditionsLink",
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Volume = "volume",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedBilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedCost = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedDcaElectionsComplete = true;
        DateTimeOffset expectedDcaElectionsCompletedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedDescription = "description";
        bool expectedHasSubmissionTransaction = true;
        string expectedHelpKeywords = "helpKeywords";
        string expectedHelpMessage = "helpMessage";
        string expectedMessageFlow = "messageFlow";
        string expectedName = "name";
        string expectedOptinKeywords = "optinKeywords";
        string expectedOptinMessage = "optinMessage";
        string expectedOptoutKeywords = "optoutKeywords";
        string expectedOptoutMessage = "optoutMessage";
        string expectedPrivacyPolicyLink = "privacyPolicyLink";
        ApiEnum<string, Status> expectedStatus = Status.SentCreated;
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedSubmittedToTcr = true;
        string expectedTcrCampaignID = "tcrCampaignId";
        string expectedTcrSyncError = "tcrSyncError";
        string expectedTermsAndConditionsLink = "termsAndConditionsLink";
        string expectedType = "type";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<CampaignUseCase> expectedUseCases =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                SampleMessages = ["string"],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedVolume = "volume";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBilledDate, model.BilledDate);
        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedDcaElectionsComplete, model.DcaElectionsComplete);
        Assert.Equal(expectedDcaElectionsCompletedAt, model.DcaElectionsCompletedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedHasSubmissionTransaction, model.HasSubmissionTransaction);
        Assert.Equal(expectedHelpKeywords, model.HelpKeywords);
        Assert.Equal(expectedHelpMessage, model.HelpMessage);
        Assert.Equal(expectedMessageFlow, model.MessageFlow);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOptinKeywords, model.OptinKeywords);
        Assert.Equal(expectedOptinMessage, model.OptinMessage);
        Assert.Equal(expectedOptoutKeywords, model.OptoutKeywords);
        Assert.Equal(expectedOptoutMessage, model.OptoutMessage);
        Assert.Equal(expectedPrivacyPolicyLink, model.PrivacyPolicyLink);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
        Assert.Equal(expectedSubmittedToTcr, model.SubmittedToTcr);
        Assert.Equal(expectedTcrCampaignID, model.TcrCampaignID);
        Assert.Equal(expectedTcrSyncError, model.TcrSyncError);
        Assert.Equal(expectedTermsAndConditionsLink, model.TermsAndConditionsLink);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.NotNull(model.UseCases);
        Assert.Equal(expectedUseCases.Count, model.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], model.UseCases[i]);
        }
        Assert.Equal(expectedVolume, model.Volume);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandCampaign
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            HasSubmissionTransaction = true,
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            Name = "name",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TermsAndConditionsLink = "termsAndConditionsLink",
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Volume = "volume",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandCampaign>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandCampaign
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            HasSubmissionTransaction = true,
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            Name = "name",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TermsAndConditionsLink = "termsAndConditionsLink",
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Volume = "volume",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandCampaign>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedBilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedCost = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedDcaElectionsComplete = true;
        DateTimeOffset expectedDcaElectionsCompletedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedDescription = "description";
        bool expectedHasSubmissionTransaction = true;
        string expectedHelpKeywords = "helpKeywords";
        string expectedHelpMessage = "helpMessage";
        string expectedMessageFlow = "messageFlow";
        string expectedName = "name";
        string expectedOptinKeywords = "optinKeywords";
        string expectedOptinMessage = "optinMessage";
        string expectedOptoutKeywords = "optoutKeywords";
        string expectedOptoutMessage = "optoutMessage";
        string expectedPrivacyPolicyLink = "privacyPolicyLink";
        ApiEnum<string, Status> expectedStatus = Status.SentCreated;
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedSubmittedToTcr = true;
        string expectedTcrCampaignID = "tcrCampaignId";
        string expectedTcrSyncError = "tcrSyncError";
        string expectedTermsAndConditionsLink = "termsAndConditionsLink";
        string expectedType = "type";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<CampaignUseCase> expectedUseCases =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                SampleMessages = ["string"],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedVolume = "volume";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBilledDate, deserialized.BilledDate);
        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedDcaElectionsComplete, deserialized.DcaElectionsComplete);
        Assert.Equal(expectedDcaElectionsCompletedAt, deserialized.DcaElectionsCompletedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedHasSubmissionTransaction, deserialized.HasSubmissionTransaction);
        Assert.Equal(expectedHelpKeywords, deserialized.HelpKeywords);
        Assert.Equal(expectedHelpMessage, deserialized.HelpMessage);
        Assert.Equal(expectedMessageFlow, deserialized.MessageFlow);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOptinKeywords, deserialized.OptinKeywords);
        Assert.Equal(expectedOptinMessage, deserialized.OptinMessage);
        Assert.Equal(expectedOptoutKeywords, deserialized.OptoutKeywords);
        Assert.Equal(expectedOptoutMessage, deserialized.OptoutMessage);
        Assert.Equal(expectedPrivacyPolicyLink, deserialized.PrivacyPolicyLink);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
        Assert.Equal(expectedSubmittedToTcr, deserialized.SubmittedToTcr);
        Assert.Equal(expectedTcrCampaignID, deserialized.TcrCampaignID);
        Assert.Equal(expectedTcrSyncError, deserialized.TcrSyncError);
        Assert.Equal(expectedTermsAndConditionsLink, deserialized.TermsAndConditionsLink);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.NotNull(deserialized.UseCases);
        Assert.Equal(expectedUseCases.Count, deserialized.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], deserialized.UseCases[i]);
        }
        Assert.Equal(expectedVolume, deserialized.Volume);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandCampaign
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            HasSubmissionTransaction = true,
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            Name = "name",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TermsAndConditionsLink = "termsAndConditionsLink",
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Volume = "volume",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandCampaign
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TermsAndConditionsLink = "termsAndConditionsLink",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Volume = "volume",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customerId"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.HasSubmissionTransaction);
        Assert.False(model.RawData.ContainsKey("hasSubmissionTransaction"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.SubmittedToTcr);
        Assert.False(model.RawData.ContainsKey("submittedToTCR"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UseCases);
        Assert.False(model.RawData.ContainsKey("useCases"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandCampaign
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TermsAndConditionsLink = "termsAndConditionsLink",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Volume = "volume",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BrandCampaign
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TermsAndConditionsLink = "termsAndConditionsLink",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Volume = "volume",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CustomerID = null,
            Description = null,
            HasSubmissionTransaction = null,
            Name = null,
            SubmittedToTcr = null,
            Type = null,
            UseCases = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customerId"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.HasSubmissionTransaction);
        Assert.False(model.RawData.ContainsKey("hasSubmissionTransaction"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.SubmittedToTcr);
        Assert.False(model.RawData.ContainsKey("submittedToTCR"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UseCases);
        Assert.False(model.RawData.ContainsKey("useCases"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandCampaign
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TermsAndConditionsLink = "termsAndConditionsLink",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Volume = "volume",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CustomerID = null,
            Description = null,
            HasSubmissionTransaction = null,
            Name = null,
            SubmittedToTcr = null,
            Type = null,
            UseCases = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandCampaign
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            HasSubmissionTransaction = true,
            Name = "name",
            SubmittedToTcr = true,
            Type = "type",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        Assert.Null(model.BilledDate);
        Assert.False(model.RawData.ContainsKey("billedDate"));
        Assert.Null(model.BrandID);
        Assert.False(model.RawData.ContainsKey("brandId"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.DcaElectionsComplete);
        Assert.False(model.RawData.ContainsKey("dcaElectionsComplete"));
        Assert.Null(model.DcaElectionsCompletedAt);
        Assert.False(model.RawData.ContainsKey("dcaElectionsCompletedAt"));
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
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.SubmittedAt);
        Assert.False(model.RawData.ContainsKey("submittedAt"));
        Assert.Null(model.TcrCampaignID);
        Assert.False(model.RawData.ContainsKey("tcrCampaignId"));
        Assert.Null(model.TcrSyncError);
        Assert.False(model.RawData.ContainsKey("tcrSyncError"));
        Assert.Null(model.TermsAndConditionsLink);
        Assert.False(model.RawData.ContainsKey("termsAndConditionsLink"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.Volume);
        Assert.False(model.RawData.ContainsKey("volume"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandCampaign
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            HasSubmissionTransaction = true,
            Name = "name",
            SubmittedToTcr = true,
            Type = "type",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrandCampaign
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            HasSubmissionTransaction = true,
            Name = "name",
            SubmittedToTcr = true,
            Type = "type",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],

            BilledDate = null,
            BrandID = null,
            Cost = null,
            DcaElectionsComplete = null,
            DcaElectionsCompletedAt = null,
            HelpKeywords = null,
            HelpMessage = null,
            MessageFlow = null,
            OptinKeywords = null,
            OptinMessage = null,
            OptoutKeywords = null,
            OptoutMessage = null,
            PrivacyPolicyLink = null,
            Status = null,
            SubmittedAt = null,
            TcrCampaignID = null,
            TcrSyncError = null,
            TermsAndConditionsLink = null,
            UpdatedAt = null,
            Volume = null,
        };

        Assert.Null(model.BilledDate);
        Assert.True(model.RawData.ContainsKey("billedDate"));
        Assert.Null(model.BrandID);
        Assert.True(model.RawData.ContainsKey("brandId"));
        Assert.Null(model.Cost);
        Assert.True(model.RawData.ContainsKey("cost"));
        Assert.Null(model.DcaElectionsComplete);
        Assert.True(model.RawData.ContainsKey("dcaElectionsComplete"));
        Assert.Null(model.DcaElectionsCompletedAt);
        Assert.True(model.RawData.ContainsKey("dcaElectionsCompletedAt"));
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
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.SubmittedAt);
        Assert.True(model.RawData.ContainsKey("submittedAt"));
        Assert.Null(model.TcrCampaignID);
        Assert.True(model.RawData.ContainsKey("tcrCampaignId"));
        Assert.Null(model.TcrSyncError);
        Assert.True(model.RawData.ContainsKey("tcrSyncError"));
        Assert.Null(model.TermsAndConditionsLink);
        Assert.True(model.RawData.ContainsKey("termsAndConditionsLink"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.Volume);
        Assert.True(model.RawData.ContainsKey("volume"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandCampaign
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            HasSubmissionTransaction = true,
            Name = "name",
            SubmittedToTcr = true,
            Type = "type",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],

            BilledDate = null,
            BrandID = null,
            Cost = null,
            DcaElectionsComplete = null,
            DcaElectionsCompletedAt = null,
            HelpKeywords = null,
            HelpMessage = null,
            MessageFlow = null,
            OptinKeywords = null,
            OptinMessage = null,
            OptoutKeywords = null,
            OptoutMessage = null,
            PrivacyPolicyLink = null,
            Status = null,
            SubmittedAt = null,
            TcrCampaignID = null,
            TcrSyncError = null,
            TermsAndConditionsLink = null,
            UpdatedAt = null,
            Volume = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrandCampaign
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            HasSubmissionTransaction = true,
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            Name = "name",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TermsAndConditionsLink = "termsAndConditionsLink",
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Volume = "volume",
        };

        BrandCampaign copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.SentCreated)]
    [InlineData(Status.Active)]
    [InlineData(Status.Expired)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.SentCreated)]
    [InlineData(Status.Active)]
    [InlineData(Status.Expired)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
