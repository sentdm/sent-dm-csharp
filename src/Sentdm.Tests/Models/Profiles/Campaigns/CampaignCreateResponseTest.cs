using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Profiles.Campaigns;

namespace Sentdm.Tests.Models.Profiles.Campaigns;

public class CampaignCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CampaignCreateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Cost = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CspID = "cspId",
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                DcaElectionsComplete = true,
                DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpstreamCnpID = "upstreamCnpId",
                UseCases =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                        SampleMessages = ["string"],
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        Data expectedData = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };
        Error expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        Meta expectedMeta = new()
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedMeta, model.Meta);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CampaignCreateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Cost = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CspID = "cspId",
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                DcaElectionsComplete = true,
                DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpstreamCnpID = "upstreamCnpId",
                UseCases =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                        SampleMessages = ["string"],
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CampaignCreateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Cost = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CspID = "cspId",
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                DcaElectionsComplete = true,
                DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpstreamCnpID = "upstreamCnpId",
                UseCases =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                        SampleMessages = ["string"],
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };
        Error expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        Meta expectedMeta = new()
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedMeta, deserialized.Meta);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CampaignCreateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Cost = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CspID = "cspId",
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                DcaElectionsComplete = true,
                DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpstreamCnpID = "upstreamCnpId",
                UseCases =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                        SampleMessages = ["string"],
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CampaignCreateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Cost = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CspID = "cspId",
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                DcaElectionsComplete = true,
                DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpstreamCnpID = "upstreamCnpId",
                UseCases =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                        SampleMessages = ["string"],
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
        };

        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CampaignCreateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Cost = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CspID = "cspId",
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                DcaElectionsComplete = true,
                DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpstreamCnpID = "upstreamCnpId",
                UseCases =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                        SampleMessages = ["string"],
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CampaignCreateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Cost = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CspID = "cspId",
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                DcaElectionsComplete = true,
                DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpstreamCnpID = "upstreamCnpId",
                UseCases =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                        SampleMessages = ["string"],
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },

            // Null should be interpreted as omitted for these properties
            Meta = null,
            Success = null,
        };

        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CampaignCreateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Cost = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CspID = "cspId",
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                DcaElectionsComplete = true,
                DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpstreamCnpID = "upstreamCnpId",
                UseCases =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                        SampleMessages = ["string"],
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },

            // Null should be interpreted as omitted for these properties
            Meta = null,
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CampaignCreateResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CampaignCreateResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CampaignCreateResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,

            Data = null,
            Error = null,
        };

        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CampaignCreateResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,

            Data = null,
            Error = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CampaignCreateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Cost = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CspID = "cspId",
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                DcaElectionsComplete = true,
                DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpstreamCnpID = "upstreamCnpId",
                UseCases =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                        SampleMessages = ["string"],
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        CampaignCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedBilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedCost = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCspID = "cspId";
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedDcaElectionsComplete = true;
        DateTimeOffset expectedDcaElectionsCompletedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
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
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUpstreamCnpID = "upstreamCnpId";
        List<DataUseCase> expectedUseCases =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                SampleMessages = ["string"],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBilledDate, model.BilledDate);
        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCspID, model.CspID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedDcaElectionsComplete, model.DcaElectionsComplete);
        Assert.Equal(expectedDcaElectionsCompletedAt, model.DcaElectionsCompletedAt);
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
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
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
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedBilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedCost = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCspID = "cspId";
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedDcaElectionsComplete = true;
        DateTimeOffset expectedDcaElectionsCompletedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
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
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUpstreamCnpID = "upstreamCnpId";
        List<DataUseCase> expectedUseCases =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                SampleMessages = ["string"],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBilledDate, deserialized.BilledDate);
        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCspID, deserialized.CspID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedDcaElectionsComplete, deserialized.DcaElectionsComplete);
        Assert.Equal(expectedDcaElectionsCompletedAt, deserialized.DcaElectionsCompletedAt);
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
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
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
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpstreamCnpID = "upstreamCnpId",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customerId"));
        Assert.Null(model.DcaElectionsComplete);
        Assert.False(model.RawData.ContainsKey("dcaElectionsComplete"));
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
        var model = new Data
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpstreamCnpID = "upstreamCnpId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpstreamCnpID = "upstreamCnpId",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CustomerID = null,
            DcaElectionsComplete = null,
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
        Assert.Null(model.DcaElectionsComplete);
        Assert.False(model.RawData.ContainsKey("dcaElectionsComplete"));
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
        var model = new Data
        {
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CspID = "cspId",
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpstreamCnpID = "upstreamCnpId",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CustomerID = null,
            DcaElectionsComplete = null,
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
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            Description = "description",
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
                    MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
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
        Assert.Null(model.CspID);
        Assert.False(model.RawData.ContainsKey("cspId"));
        Assert.Null(model.DcaElectionsCompletedAt);
        Assert.False(model.RawData.ContainsKey("dcaElectionsCompletedAt"));
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
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.UpstreamCnpID);
        Assert.False(model.RawData.ContainsKey("upstreamCnpId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            Description = "description",
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
                    MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
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
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            Description = "description",
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
                    MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],

            BilledDate = null,
            BrandID = null,
            Cost = null,
            CspID = null,
            DcaElectionsCompletedAt = null,
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
            UpdatedAt = null,
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
        Assert.Null(model.DcaElectionsCompletedAt);
        Assert.True(model.RawData.ContainsKey("dcaElectionsCompletedAt"));
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
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.UpstreamCnpID);
        Assert.True(model.RawData.ContainsKey("upstreamCnpId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            Description = "description",
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
                    MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],

            BilledDate = null,
            BrandID = null,
            Cost = null,
            CspID = null,
            DcaElectionsCompletedAt = null,
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
            UpdatedAt = null,
            UpstreamCnpID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BilledDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "cspId",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DcaElectionsComplete = true,
            DcaElectionsCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpstreamCnpID = "upstreamCnpId",
            UseCases =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
                    SampleMessages = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        Data copied = new(model);

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
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
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

public class DataUseCaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, DataUseCaseMessagingUseCaseUs> expectedMessagingUseCaseUs =
            DataUseCaseMessagingUseCaseUs.Marketing;
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
        var model = new DataUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataUseCase>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataUseCase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, DataUseCaseMessagingUseCaseUs> expectedMessagingUseCaseUs =
            DataUseCaseMessagingUseCaseUs.Marketing;
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
        var model = new DataUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataUseCase
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
        var model = new DataUseCase
        {
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DataUseCase
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
        var model = new DataUseCase
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
        var model = new DataUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DataUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DataUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],

            UpdatedAt = null,
        };

        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DataUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],

            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataUseCase
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessagingUseCaseUs = DataUseCaseMessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DataUseCase copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataUseCaseMessagingUseCaseUsTest : TestBase
{
    [Theory]
    [InlineData(DataUseCaseMessagingUseCaseUs.Marketing)]
    [InlineData(DataUseCaseMessagingUseCaseUs.AccountNotification)]
    [InlineData(DataUseCaseMessagingUseCaseUs.CustomerCare)]
    [InlineData(DataUseCaseMessagingUseCaseUs.FraudAlert)]
    [InlineData(DataUseCaseMessagingUseCaseUs.TwoFa)]
    [InlineData(DataUseCaseMessagingUseCaseUs.DeliveryNotification)]
    [InlineData(DataUseCaseMessagingUseCaseUs.SecurityAlert)]
    [InlineData(DataUseCaseMessagingUseCaseUs.M2M)]
    [InlineData(DataUseCaseMessagingUseCaseUs.Mixed)]
    [InlineData(DataUseCaseMessagingUseCaseUs.HigherEducation)]
    [InlineData(DataUseCaseMessagingUseCaseUs.PollingVoting)]
    [InlineData(DataUseCaseMessagingUseCaseUs.PublicServiceAnnouncement)]
    [InlineData(DataUseCaseMessagingUseCaseUs.LowVolume)]
    public void Validation_Works(DataUseCaseMessagingUseCaseUs rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataUseCaseMessagingUseCaseUs> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataUseCaseMessagingUseCaseUs>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataUseCaseMessagingUseCaseUs.Marketing)]
    [InlineData(DataUseCaseMessagingUseCaseUs.AccountNotification)]
    [InlineData(DataUseCaseMessagingUseCaseUs.CustomerCare)]
    [InlineData(DataUseCaseMessagingUseCaseUs.FraudAlert)]
    [InlineData(DataUseCaseMessagingUseCaseUs.TwoFa)]
    [InlineData(DataUseCaseMessagingUseCaseUs.DeliveryNotification)]
    [InlineData(DataUseCaseMessagingUseCaseUs.SecurityAlert)]
    [InlineData(DataUseCaseMessagingUseCaseUs.M2M)]
    [InlineData(DataUseCaseMessagingUseCaseUs.Mixed)]
    [InlineData(DataUseCaseMessagingUseCaseUs.HigherEducation)]
    [InlineData(DataUseCaseMessagingUseCaseUs.PollingVoting)]
    [InlineData(DataUseCaseMessagingUseCaseUs.PublicServiceAnnouncement)]
    [InlineData(DataUseCaseMessagingUseCaseUs.LowVolume)]
    public void SerializationRoundtrip_Works(DataUseCaseMessagingUseCaseUs rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataUseCaseMessagingUseCaseUs> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataUseCaseMessagingUseCaseUs>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataUseCaseMessagingUseCaseUs>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataUseCaseMessagingUseCaseUs>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Error
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string expectedCode = "code";
        Dictionary<string, List<string>> expectedDetails = new() { { "foo", ["string"] } };
        string expectedDocUrl = "doc_url";
        string expectedMessage = "message";

        Assert.Equal(expectedCode, model.Code);
        Assert.NotNull(model.Details);
        Assert.Equal(expectedDetails.Count, model.Details.Count);
        foreach (var item in expectedDetails)
        {
            Assert.True(model.Details.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, model.Details[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], model.Details[item.Key][i]);
            }
        }
        Assert.Equal(expectedDocUrl, model.DocUrl);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Error
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Error
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCode = "code";
        Dictionary<string, List<string>> expectedDetails = new() { { "foo", ["string"] } };
        string expectedDocUrl = "doc_url";
        string expectedMessage = "message";

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.NotNull(deserialized.Details);
        Assert.Equal(expectedDetails.Count, deserialized.Details.Count);
        foreach (var item in expectedDetails)
        {
            Assert.True(deserialized.Details.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, deserialized.Details[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], deserialized.Details[item.Key][i]);
            }
        }
        Assert.Equal(expectedDocUrl, deserialized.DocUrl);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Error
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Error
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Error
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Error
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",

            // Null should be interpreted as omitted for these properties
            Code = null,
            Message = null,
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Error
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",

            // Null should be interpreted as omitted for these properties
            Code = null,
            Message = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Error { Code = "code", Message = "message" };

        Assert.Null(model.Details);
        Assert.False(model.RawData.ContainsKey("details"));
        Assert.Null(model.DocUrl);
        Assert.False(model.RawData.ContainsKey("doc_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Error { Code = "code", Message = "message" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Error
        {
            Code = "code",
            Message = "message",

            Details = null,
            DocUrl = null,
        };

        Assert.Null(model.Details);
        Assert.True(model.RawData.ContainsKey("details"));
        Assert.Null(model.DocUrl);
        Assert.True(model.RawData.ContainsKey("doc_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Error
        {
            Code = "code",
            Message = "message",

            Details = null,
            DocUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Error
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        Error copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MetaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Meta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string expectedRequestID = "request_id";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVersion = "version";

        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Meta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Meta>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Meta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Meta>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedRequestID = "request_id";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVersion = "version";

        Assert.Equal(expectedRequestID, deserialized.RequestID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Meta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Meta { };

        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Meta { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Meta
        {
            // Null should be interpreted as omitted for these properties
            RequestID = null,
            Timestamp = null,
            Version = null,
        };

        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Meta
        {
            // Null should be interpreted as omitted for these properties
            RequestID = null,
            Timestamp = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Meta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        Meta copied = new(model);

        Assert.Equal(model, copied);
    }
}
