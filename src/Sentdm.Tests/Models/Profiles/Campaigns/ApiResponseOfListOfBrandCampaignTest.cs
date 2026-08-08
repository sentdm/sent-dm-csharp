using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Profiles.Campaigns;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Profiles.Campaigns;

public class ApiResponseOfListOfBrandCampaignTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiResponseOfListOfBrandCampaign
        {
            Data =
            [
                new()
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
                },
            ],
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

        List<BrandCampaign> expectedData =
        [
            new()
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
            },
        ];
        ErrorDetail expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedMeta, model.Meta);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiResponseOfListOfBrandCampaign
        {
            Data =
            [
                new()
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
                },
            ],
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
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfListOfBrandCampaign>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiResponseOfListOfBrandCampaign
        {
            Data =
            [
                new()
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
                },
            ],
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
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfListOfBrandCampaign>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BrandCampaign> expectedData =
        [
            new()
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
            },
        ];
        ErrorDetail expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedMeta, deserialized.Meta);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiResponseOfListOfBrandCampaign
        {
            Data =
            [
                new()
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
                },
            ],
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
        var model = new ApiResponseOfListOfBrandCampaign
        {
            Data =
            [
                new()
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
                },
            ],
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
        var model = new ApiResponseOfListOfBrandCampaign
        {
            Data =
            [
                new()
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
                },
            ],
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
        var model = new ApiResponseOfListOfBrandCampaign
        {
            Data =
            [
                new()
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
                },
            ],
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
        var model = new ApiResponseOfListOfBrandCampaign
        {
            Data =
            [
                new()
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
                },
            ],
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
        var model = new ApiResponseOfListOfBrandCampaign
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
        var model = new ApiResponseOfListOfBrandCampaign
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
        var model = new ApiResponseOfListOfBrandCampaign
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
        var model = new ApiResponseOfListOfBrandCampaign
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
        var model = new ApiResponseOfListOfBrandCampaign
        {
            Data =
            [
                new()
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
                },
            ],
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

        ApiResponseOfListOfBrandCampaign copied = new(model);

        Assert.Equal(model, copied);
    }
}
