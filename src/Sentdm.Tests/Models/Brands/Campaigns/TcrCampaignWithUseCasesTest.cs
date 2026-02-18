using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Brands.Campaigns;

namespace Sentdm.Tests.Models.Brands.Campaigns;

public class TcrCampaignWithUseCasesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TcrCampaignWithUseCases
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            Name = "name",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            Type = "type",
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedCost = 0;
        string expectedCspID = "cspId";
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDescription = "description";
        string expectedHelpKeywords = "helpKeywords";
        string expectedHelpMessage = "helpMessage";
        string expectedKycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedMessageFlow = "messageFlow";
        string expectedName = "name";
        string expectedOptinKeywords = "optinKeywords";
        string expectedOptinMessage = "optinMessage";
        string expectedOptoutKeywords = "optoutKeywords";
        string expectedOptoutMessage = "optoutMessage";
        string expectedPrivacyPolicyLink = "privacyPolicyLink";
        string expectedResellerID = "resellerId";
        ApiEnum<string, SharingStatus> expectedSharingStatus = SharingStatus.Pending;
        ApiEnum<string, Status> expectedStatus = Status.SentCreated;
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedSubmittedToTcr = true;
        string expectedTcrCampaignID = "tcrCampaignId";
        string expectedTcrSyncError = "tcrSyncError";
        string expectedTelnyxCampaignID = "telnyxCampaignId";
        string expectedTermsAndConditionsLink = "termsAndConditionsLink";
        string expectedType = "type";
        string expectedUpstreamCnpID = "upstreamCnpId";
        List<UseCase> expectedUseCases =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                SampleMessages = ["string"],
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedBilledDate, model.BilledDate);
        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedCspID, model.CspID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedHelpKeywords, model.HelpKeywords);
        Assert.Equal(expectedHelpMessage, model.HelpMessage);
        Assert.Equal(expectedKycSubmissionFormID, model.KycSubmissionFormID);
        Assert.Equal(expectedMessageFlow, model.MessageFlow);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOptinKeywords, model.OptinKeywords);
        Assert.Equal(expectedOptinMessage, model.OptinMessage);
        Assert.Equal(expectedOptoutKeywords, model.OptoutKeywords);
        Assert.Equal(expectedOptoutMessage, model.OptoutMessage);
        Assert.Equal(expectedPrivacyPolicyLink, model.PrivacyPolicyLink);
        Assert.Equal(expectedResellerID, model.ResellerID);
        Assert.Equal(expectedSharingStatus, model.SharingStatus);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
        Assert.Equal(expectedSubmittedToTcr, model.SubmittedToTcr);
        Assert.Equal(expectedTcrCampaignID, model.TcrCampaignID);
        Assert.Equal(expectedTcrSyncError, model.TcrSyncError);
        Assert.Equal(expectedTelnyxCampaignID, model.TelnyxCampaignID);
        Assert.Equal(expectedTermsAndConditionsLink, model.TermsAndConditionsLink);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpstreamCnpID, model.UpstreamCnpID);
        Assert.NotNull(model.UseCases);
        Assert.Equal(expectedUseCases.Count, model.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], model.UseCases[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TcrCampaignWithUseCases
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            Name = "name",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            Type = "type",
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TcrCampaignWithUseCases>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TcrCampaignWithUseCases
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            Name = "name",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            Type = "type",
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TcrCampaignWithUseCases>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedCost = 0;
        string expectedCspID = "cspId";
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDescription = "description";
        string expectedHelpKeywords = "helpKeywords";
        string expectedHelpMessage = "helpMessage";
        string expectedKycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedMessageFlow = "messageFlow";
        string expectedName = "name";
        string expectedOptinKeywords = "optinKeywords";
        string expectedOptinMessage = "optinMessage";
        string expectedOptoutKeywords = "optoutKeywords";
        string expectedOptoutMessage = "optoutMessage";
        string expectedPrivacyPolicyLink = "privacyPolicyLink";
        string expectedResellerID = "resellerId";
        ApiEnum<string, SharingStatus> expectedSharingStatus = SharingStatus.Pending;
        ApiEnum<string, Status> expectedStatus = Status.SentCreated;
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedSubmittedToTcr = true;
        string expectedTcrCampaignID = "tcrCampaignId";
        string expectedTcrSyncError = "tcrSyncError";
        string expectedTelnyxCampaignID = "telnyxCampaignId";
        string expectedTermsAndConditionsLink = "termsAndConditionsLink";
        string expectedType = "type";
        string expectedUpstreamCnpID = "upstreamCnpId";
        List<UseCase> expectedUseCases =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                SampleMessages = ["string"],
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedBilledDate, deserialized.BilledDate);
        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedCspID, deserialized.CspID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedHelpKeywords, deserialized.HelpKeywords);
        Assert.Equal(expectedHelpMessage, deserialized.HelpMessage);
        Assert.Equal(expectedKycSubmissionFormID, deserialized.KycSubmissionFormID);
        Assert.Equal(expectedMessageFlow, deserialized.MessageFlow);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOptinKeywords, deserialized.OptinKeywords);
        Assert.Equal(expectedOptinMessage, deserialized.OptinMessage);
        Assert.Equal(expectedOptoutKeywords, deserialized.OptoutKeywords);
        Assert.Equal(expectedOptoutMessage, deserialized.OptoutMessage);
        Assert.Equal(expectedPrivacyPolicyLink, deserialized.PrivacyPolicyLink);
        Assert.Equal(expectedResellerID, deserialized.ResellerID);
        Assert.Equal(expectedSharingStatus, deserialized.SharingStatus);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
        Assert.Equal(expectedSubmittedToTcr, deserialized.SubmittedToTcr);
        Assert.Equal(expectedTcrCampaignID, deserialized.TcrCampaignID);
        Assert.Equal(expectedTcrSyncError, deserialized.TcrSyncError);
        Assert.Equal(expectedTelnyxCampaignID, deserialized.TelnyxCampaignID);
        Assert.Equal(expectedTermsAndConditionsLink, deserialized.TermsAndConditionsLink);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpstreamCnpID, deserialized.UpstreamCnpID);
        Assert.NotNull(deserialized.UseCases);
        Assert.Equal(expectedUseCases.Count, deserialized.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], deserialized.UseCases[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TcrCampaignWithUseCases
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            Name = "name",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            Type = "type",
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TcrCampaignWithUseCases
        {
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            UpstreamCnpID = "upstreamCnpId",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customerId"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
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
        var model = new TcrCampaignWithUseCases
        {
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            UpstreamCnpID = "upstreamCnpId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TcrCampaignWithUseCases
        {
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            UpstreamCnpID = "upstreamCnpId",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CustomerID = null,
            Description = null,
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
        var model = new TcrCampaignWithUseCases
        {
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            UpstreamCnpID = "upstreamCnpId",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CustomerID = null,
            Description = null,
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
        var model = new TcrCampaignWithUseCases
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            Name = "name",
            SubmittedToTcr = true,
            Type = "type",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
        };

        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.BilledDate);
        Assert.False(model.RawData.ContainsKey("billedDate"));
        Assert.Null(model.BrandID);
        Assert.False(model.RawData.ContainsKey("brandId"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.CspID);
        Assert.False(model.RawData.ContainsKey("cspId"));
        Assert.Null(model.HelpKeywords);
        Assert.False(model.RawData.ContainsKey("helpKeywords"));
        Assert.Null(model.HelpMessage);
        Assert.False(model.RawData.ContainsKey("helpMessage"));
        Assert.Null(model.KycSubmissionFormID);
        Assert.False(model.RawData.ContainsKey("kycSubmissionFormId"));
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
        Assert.Null(model.ResellerID);
        Assert.False(model.RawData.ContainsKey("resellerId"));
        Assert.Null(model.SharingStatus);
        Assert.False(model.RawData.ContainsKey("sharingStatus"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.SubmittedAt);
        Assert.False(model.RawData.ContainsKey("submittedAt"));
        Assert.Null(model.TcrCampaignID);
        Assert.False(model.RawData.ContainsKey("tcrCampaignId"));
        Assert.Null(model.TcrSyncError);
        Assert.False(model.RawData.ContainsKey("tcrSyncError"));
        Assert.Null(model.TelnyxCampaignID);
        Assert.False(model.RawData.ContainsKey("telnyxCampaignId"));
        Assert.Null(model.TermsAndConditionsLink);
        Assert.False(model.RawData.ContainsKey("termsAndConditionsLink"));
        Assert.Null(model.UpstreamCnpID);
        Assert.False(model.RawData.ContainsKey("upstreamCnpId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TcrCampaignWithUseCases
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            Name = "name",
            SubmittedToTcr = true,
            Type = "type",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
        var model = new TcrCampaignWithUseCases
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            Name = "name",
            SubmittedToTcr = true,
            Type = "type",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],

            UpdatedAt = null,
            BilledDate = null,
            BrandID = null,
            Cost = null,
            CspID = null,
            HelpKeywords = null,
            HelpMessage = null,
            KycSubmissionFormID = null,
            MessageFlow = null,
            OptinKeywords = null,
            OptinMessage = null,
            OptoutKeywords = null,
            OptoutMessage = null,
            PrivacyPolicyLink = null,
            ResellerID = null,
            SharingStatus = null,
            Status = null,
            SubmittedAt = null,
            TcrCampaignID = null,
            TcrSyncError = null,
            TelnyxCampaignID = null,
            TermsAndConditionsLink = null,
            UpstreamCnpID = null,
        };

        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.BilledDate);
        Assert.True(model.RawData.ContainsKey("billedDate"));
        Assert.Null(model.BrandID);
        Assert.True(model.RawData.ContainsKey("brandId"));
        Assert.Null(model.Cost);
        Assert.True(model.RawData.ContainsKey("cost"));
        Assert.Null(model.CspID);
        Assert.True(model.RawData.ContainsKey("cspId"));
        Assert.Null(model.HelpKeywords);
        Assert.True(model.RawData.ContainsKey("helpKeywords"));
        Assert.Null(model.HelpMessage);
        Assert.True(model.RawData.ContainsKey("helpMessage"));
        Assert.Null(model.KycSubmissionFormID);
        Assert.True(model.RawData.ContainsKey("kycSubmissionFormId"));
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
        Assert.Null(model.ResellerID);
        Assert.True(model.RawData.ContainsKey("resellerId"));
        Assert.Null(model.SharingStatus);
        Assert.True(model.RawData.ContainsKey("sharingStatus"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.SubmittedAt);
        Assert.True(model.RawData.ContainsKey("submittedAt"));
        Assert.Null(model.TcrCampaignID);
        Assert.True(model.RawData.ContainsKey("tcrCampaignId"));
        Assert.Null(model.TcrSyncError);
        Assert.True(model.RawData.ContainsKey("tcrSyncError"));
        Assert.Null(model.TelnyxCampaignID);
        Assert.True(model.RawData.ContainsKey("telnyxCampaignId"));
        Assert.Null(model.TermsAndConditionsLink);
        Assert.True(model.RawData.ContainsKey("termsAndConditionsLink"));
        Assert.Null(model.UpstreamCnpID);
        Assert.True(model.RawData.ContainsKey("upstreamCnpId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TcrCampaignWithUseCases
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            Name = "name",
            SubmittedToTcr = true,
            Type = "type",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],

            UpdatedAt = null,
            BilledDate = null,
            BrandID = null,
            Cost = null,
            CspID = null,
            HelpKeywords = null,
            HelpMessage = null,
            KycSubmissionFormID = null,
            MessageFlow = null,
            OptinKeywords = null,
            OptinMessage = null,
            OptoutKeywords = null,
            OptoutMessage = null,
            PrivacyPolicyLink = null,
            ResellerID = null,
            SharingStatus = null,
            Status = null,
            SubmittedAt = null,
            TcrCampaignID = null,
            TcrSyncError = null,
            TelnyxCampaignID = null,
            TermsAndConditionsLink = null,
            UpstreamCnpID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TcrCampaignWithUseCases
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            Name = "name",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            Type = "type",
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
        };

        TcrCampaignWithUseCases copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            Name = "name",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            Type = "type",
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
        };

        DateTimeOffset expectedBilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedCost = 0;
        string expectedCspID = "cspId";
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDescription = "description";
        string expectedHelpKeywords = "helpKeywords";
        string expectedHelpMessage = "helpMessage";
        string expectedKycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedMessageFlow = "messageFlow";
        string expectedName = "name";
        string expectedOptinKeywords = "optinKeywords";
        string expectedOptinMessage = "optinMessage";
        string expectedOptoutKeywords = "optoutKeywords";
        string expectedOptoutMessage = "optoutMessage";
        string expectedPrivacyPolicyLink = "privacyPolicyLink";
        string expectedResellerID = "resellerId";
        ApiEnum<string, SharingStatus> expectedSharingStatus = SharingStatus.Pending;
        ApiEnum<string, Status> expectedStatus = Status.SentCreated;
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedSubmittedToTcr = true;
        string expectedTcrCampaignID = "tcrCampaignId";
        string expectedTcrSyncError = "tcrSyncError";
        string expectedTelnyxCampaignID = "telnyxCampaignId";
        string expectedTermsAndConditionsLink = "termsAndConditionsLink";
        string expectedType = "type";
        string expectedUpstreamCnpID = "upstreamCnpId";
        List<UseCase> expectedUseCases =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                SampleMessages = ["string"],
            },
        ];

        Assert.Equal(expectedBilledDate, model.BilledDate);
        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedCspID, model.CspID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedHelpKeywords, model.HelpKeywords);
        Assert.Equal(expectedHelpMessage, model.HelpMessage);
        Assert.Equal(expectedKycSubmissionFormID, model.KycSubmissionFormID);
        Assert.Equal(expectedMessageFlow, model.MessageFlow);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOptinKeywords, model.OptinKeywords);
        Assert.Equal(expectedOptinMessage, model.OptinMessage);
        Assert.Equal(expectedOptoutKeywords, model.OptoutKeywords);
        Assert.Equal(expectedOptoutMessage, model.OptoutMessage);
        Assert.Equal(expectedPrivacyPolicyLink, model.PrivacyPolicyLink);
        Assert.Equal(expectedResellerID, model.ResellerID);
        Assert.Equal(expectedSharingStatus, model.SharingStatus);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
        Assert.Equal(expectedSubmittedToTcr, model.SubmittedToTcr);
        Assert.Equal(expectedTcrCampaignID, model.TcrCampaignID);
        Assert.Equal(expectedTcrSyncError, model.TcrSyncError);
        Assert.Equal(expectedTelnyxCampaignID, model.TelnyxCampaignID);
        Assert.Equal(expectedTermsAndConditionsLink, model.TermsAndConditionsLink);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpstreamCnpID, model.UpstreamCnpID);
        Assert.NotNull(model.UseCases);
        Assert.Equal(expectedUseCases.Count, model.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], model.UseCases[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntersectionMember1
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            Name = "name",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            Type = "type",
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntersectionMember1
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            Name = "name",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            Type = "type",
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedBilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedCost = 0;
        string expectedCspID = "cspId";
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDescription = "description";
        string expectedHelpKeywords = "helpKeywords";
        string expectedHelpMessage = "helpMessage";
        string expectedKycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedMessageFlow = "messageFlow";
        string expectedName = "name";
        string expectedOptinKeywords = "optinKeywords";
        string expectedOptinMessage = "optinMessage";
        string expectedOptoutKeywords = "optoutKeywords";
        string expectedOptoutMessage = "optoutMessage";
        string expectedPrivacyPolicyLink = "privacyPolicyLink";
        string expectedResellerID = "resellerId";
        ApiEnum<string, SharingStatus> expectedSharingStatus = SharingStatus.Pending;
        ApiEnum<string, Status> expectedStatus = Status.SentCreated;
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedSubmittedToTcr = true;
        string expectedTcrCampaignID = "tcrCampaignId";
        string expectedTcrSyncError = "tcrSyncError";
        string expectedTelnyxCampaignID = "telnyxCampaignId";
        string expectedTermsAndConditionsLink = "termsAndConditionsLink";
        string expectedType = "type";
        string expectedUpstreamCnpID = "upstreamCnpId";
        List<UseCase> expectedUseCases =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                SampleMessages = ["string"],
            },
        ];

        Assert.Equal(expectedBilledDate, deserialized.BilledDate);
        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedCspID, deserialized.CspID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedHelpKeywords, deserialized.HelpKeywords);
        Assert.Equal(expectedHelpMessage, deserialized.HelpMessage);
        Assert.Equal(expectedKycSubmissionFormID, deserialized.KycSubmissionFormID);
        Assert.Equal(expectedMessageFlow, deserialized.MessageFlow);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOptinKeywords, deserialized.OptinKeywords);
        Assert.Equal(expectedOptinMessage, deserialized.OptinMessage);
        Assert.Equal(expectedOptoutKeywords, deserialized.OptoutKeywords);
        Assert.Equal(expectedOptoutMessage, deserialized.OptoutMessage);
        Assert.Equal(expectedPrivacyPolicyLink, deserialized.PrivacyPolicyLink);
        Assert.Equal(expectedResellerID, deserialized.ResellerID);
        Assert.Equal(expectedSharingStatus, deserialized.SharingStatus);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
        Assert.Equal(expectedSubmittedToTcr, deserialized.SubmittedToTcr);
        Assert.Equal(expectedTcrCampaignID, deserialized.TcrCampaignID);
        Assert.Equal(expectedTcrSyncError, deserialized.TcrSyncError);
        Assert.Equal(expectedTelnyxCampaignID, deserialized.TelnyxCampaignID);
        Assert.Equal(expectedTermsAndConditionsLink, deserialized.TermsAndConditionsLink);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpstreamCnpID, deserialized.UpstreamCnpID);
        Assert.NotNull(deserialized.UseCases);
        Assert.Equal(expectedUseCases.Count, deserialized.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], deserialized.UseCases[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntersectionMember1
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            Name = "name",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            Type = "type",
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IntersectionMember1
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            UpstreamCnpID = "upstreamCnpId",
        };

        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customerId"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
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
        var model = new IntersectionMember1
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            UpstreamCnpID = "upstreamCnpId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new IntersectionMember1
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            UpstreamCnpID = "upstreamCnpId",

            // Null should be interpreted as omitted for these properties
            CustomerID = null,
            Description = null,
            Name = null,
            SubmittedToTcr = null,
            Type = null,
            UseCases = null,
        };

        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customerId"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
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
        var model = new IntersectionMember1
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            UpstreamCnpID = "upstreamCnpId",

            // Null should be interpreted as omitted for these properties
            CustomerID = null,
            Description = null,
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
        var model = new IntersectionMember1
        {
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            Name = "name",
            SubmittedToTcr = true,
            Type = "type",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
        };

        Assert.Null(model.BilledDate);
        Assert.False(model.RawData.ContainsKey("billedDate"));
        Assert.Null(model.BrandID);
        Assert.False(model.RawData.ContainsKey("brandId"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.CspID);
        Assert.False(model.RawData.ContainsKey("cspId"));
        Assert.Null(model.HelpKeywords);
        Assert.False(model.RawData.ContainsKey("helpKeywords"));
        Assert.Null(model.HelpMessage);
        Assert.False(model.RawData.ContainsKey("helpMessage"));
        Assert.Null(model.KycSubmissionFormID);
        Assert.False(model.RawData.ContainsKey("kycSubmissionFormId"));
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
        Assert.Null(model.ResellerID);
        Assert.False(model.RawData.ContainsKey("resellerId"));
        Assert.Null(model.SharingStatus);
        Assert.False(model.RawData.ContainsKey("sharingStatus"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.SubmittedAt);
        Assert.False(model.RawData.ContainsKey("submittedAt"));
        Assert.Null(model.TcrCampaignID);
        Assert.False(model.RawData.ContainsKey("tcrCampaignId"));
        Assert.Null(model.TcrSyncError);
        Assert.False(model.RawData.ContainsKey("tcrSyncError"));
        Assert.Null(model.TelnyxCampaignID);
        Assert.False(model.RawData.ContainsKey("telnyxCampaignId"));
        Assert.Null(model.TermsAndConditionsLink);
        Assert.False(model.RawData.ContainsKey("termsAndConditionsLink"));
        Assert.Null(model.UpstreamCnpID);
        Assert.False(model.RawData.ContainsKey("upstreamCnpId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new IntersectionMember1
        {
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            Name = "name",
            SubmittedToTcr = true,
            Type = "type",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
        var model = new IntersectionMember1
        {
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            Name = "name",
            SubmittedToTcr = true,
            Type = "type",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],

            BilledDate = null,
            BrandID = null,
            Cost = null,
            CspID = null,
            HelpKeywords = null,
            HelpMessage = null,
            KycSubmissionFormID = null,
            MessageFlow = null,
            OptinKeywords = null,
            OptinMessage = null,
            OptoutKeywords = null,
            OptoutMessage = null,
            PrivacyPolicyLink = null,
            ResellerID = null,
            SharingStatus = null,
            Status = null,
            SubmittedAt = null,
            TcrCampaignID = null,
            TcrSyncError = null,
            TelnyxCampaignID = null,
            TermsAndConditionsLink = null,
            UpstreamCnpID = null,
        };

        Assert.Null(model.BilledDate);
        Assert.True(model.RawData.ContainsKey("billedDate"));
        Assert.Null(model.BrandID);
        Assert.True(model.RawData.ContainsKey("brandId"));
        Assert.Null(model.Cost);
        Assert.True(model.RawData.ContainsKey("cost"));
        Assert.Null(model.CspID);
        Assert.True(model.RawData.ContainsKey("cspId"));
        Assert.Null(model.HelpKeywords);
        Assert.True(model.RawData.ContainsKey("helpKeywords"));
        Assert.Null(model.HelpMessage);
        Assert.True(model.RawData.ContainsKey("helpMessage"));
        Assert.Null(model.KycSubmissionFormID);
        Assert.True(model.RawData.ContainsKey("kycSubmissionFormId"));
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
        Assert.Null(model.ResellerID);
        Assert.True(model.RawData.ContainsKey("resellerId"));
        Assert.Null(model.SharingStatus);
        Assert.True(model.RawData.ContainsKey("sharingStatus"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.SubmittedAt);
        Assert.True(model.RawData.ContainsKey("submittedAt"));
        Assert.Null(model.TcrCampaignID);
        Assert.True(model.RawData.ContainsKey("tcrCampaignId"));
        Assert.Null(model.TcrSyncError);
        Assert.True(model.RawData.ContainsKey("tcrSyncError"));
        Assert.Null(model.TelnyxCampaignID);
        Assert.True(model.RawData.ContainsKey("telnyxCampaignId"));
        Assert.Null(model.TermsAndConditionsLink);
        Assert.True(model.RawData.ContainsKey("termsAndConditionsLink"));
        Assert.Null(model.UpstreamCnpID);
        Assert.True(model.RawData.ContainsKey("upstreamCnpId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IntersectionMember1
        {
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            Name = "name",
            SubmittedToTcr = true,
            Type = "type",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],

            BilledDate = null,
            BrandID = null,
            Cost = null,
            CspID = null,
            HelpKeywords = null,
            HelpMessage = null,
            KycSubmissionFormID = null,
            MessageFlow = null,
            OptinKeywords = null,
            OptinMessage = null,
            OptoutKeywords = null,
            OptoutMessage = null,
            PrivacyPolicyLink = null,
            ResellerID = null,
            SharingStatus = null,
            Status = null,
            SubmittedAt = null,
            TcrCampaignID = null,
            TcrSyncError = null,
            TelnyxCampaignID = null,
            TermsAndConditionsLink = null,
            UpstreamCnpID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntersectionMember1
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            HelpKeywords = "helpKeywords",
            HelpMessage = "helpMessage",
            KycSubmissionFormID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageFlow = "messageFlow",
            Name = "name",
            OptinKeywords = "optinKeywords",
            OptinMessage = "optinMessage",
            OptoutKeywords = "optoutKeywords",
            OptoutMessage = "optoutMessage",
            PrivacyPolicyLink = "privacyPolicyLink",
            ResellerID = "resellerId",
            SharingStatus = SharingStatus.Pending,
            Status = Status.SentCreated,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrCampaignID = "tcrCampaignId",
            TcrSyncError = "tcrSyncError",
            TelnyxCampaignID = "telnyxCampaignId",
            TermsAndConditionsLink = "termsAndConditionsLink",
            Type = "type",
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                },
            ],
        };

        IntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SharingStatusTest : TestBase
{
    [Theory]
    [InlineData(SharingStatus.Pending)]
    [InlineData(SharingStatus.Accepted)]
    [InlineData(SharingStatus.Declined)]
    public void Validation_Works(SharingStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SharingStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SharingStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentDmInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SharingStatus.Pending)]
    [InlineData(SharingStatus.Accepted)]
    [InlineData(SharingStatus.Declined)]
    public void SerializationRoundtrip_Works(SharingStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SharingStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SharingStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SharingStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SharingStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
        Assert.Throws<SentDmInvalidDataException>(() => value.Validate());
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

public class UseCaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, MessagingUseCaseUs> expectedMessagingUseCaseUs =
            MessagingUseCaseUs.Marketing;
        List<string> expectedSampleMessages = ["string"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedCampaignID, model.CampaignID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedMessagingUseCaseUs, model.MessagingUseCaseUs);
        Assert.NotNull(model.SampleMessages);
        Assert.Equal(expectedSampleMessages.Count, model.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], model.SampleMessages[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UseCase>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UseCase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, MessagingUseCaseUs> expectedMessagingUseCaseUs =
            MessagingUseCaseUs.Marketing;
        List<string> expectedSampleMessages = ["string"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedCampaignID, deserialized.CampaignID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedMessagingUseCaseUs, deserialized.MessagingUseCaseUs);
        Assert.NotNull(deserialized.SampleMessages);
        Assert.Equal(expectedSampleMessages.Count, deserialized.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], deserialized.SampleMessages[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UseCase { UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CampaignID);
        Assert.False(model.RawData.ContainsKey("campaignId"));
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
        var model = new UseCase { UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UseCase
        {
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CampaignID = null,
            CustomerID = null,
            MessagingUseCaseUs = null,
            SampleMessages = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CampaignID);
        Assert.False(model.RawData.ContainsKey("campaignId"));
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
        var model = new UseCase
        {
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CampaignID = null,
            CustomerID = null,
            MessagingUseCaseUs = null,
            SampleMessages = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
        var model = new UseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
        var model = new UseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
        var model = new UseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        UseCase copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UseCaseIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UseCaseIntersectionMember1
        {
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        string expectedCampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, MessagingUseCaseUs> expectedMessagingUseCaseUs =
            MessagingUseCaseUs.Marketing;
        List<string> expectedSampleMessages = ["string"];

        Assert.Equal(expectedCampaignID, model.CampaignID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedMessagingUseCaseUs, model.MessagingUseCaseUs);
        Assert.NotNull(model.SampleMessages);
        Assert.Equal(expectedSampleMessages.Count, model.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], model.SampleMessages[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UseCaseIntersectionMember1
        {
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UseCaseIntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UseCaseIntersectionMember1
        {
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UseCaseIntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, MessagingUseCaseUs> expectedMessagingUseCaseUs =
            MessagingUseCaseUs.Marketing;
        List<string> expectedSampleMessages = ["string"];

        Assert.Equal(expectedCampaignID, deserialized.CampaignID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedMessagingUseCaseUs, deserialized.MessagingUseCaseUs);
        Assert.NotNull(deserialized.SampleMessages);
        Assert.Equal(expectedSampleMessages.Count, deserialized.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], deserialized.SampleMessages[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UseCaseIntersectionMember1
        {
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UseCaseIntersectionMember1 { };

        Assert.Null(model.CampaignID);
        Assert.False(model.RawData.ContainsKey("campaignId"));
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
        var model = new UseCaseIntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UseCaseIntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            CampaignID = null,
            CustomerID = null,
            MessagingUseCaseUs = null,
            SampleMessages = null,
        };

        Assert.Null(model.CampaignID);
        Assert.False(model.RawData.ContainsKey("campaignId"));
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
        var model = new UseCaseIntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            CampaignID = null,
            CustomerID = null,
            MessagingUseCaseUs = null,
            SampleMessages = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UseCaseIntersectionMember1
        {
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        UseCaseIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}
