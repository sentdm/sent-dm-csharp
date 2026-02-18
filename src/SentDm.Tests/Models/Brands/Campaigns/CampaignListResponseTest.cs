using System;
using System.Collections.Generic;
using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Brands.Campaigns;
using SentDm.Models.Webhooks;

namespace SentDm.Tests.Models.Brands.Campaigns;

public class CampaignListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CampaignListResponse
        {
            Data =
            [
                new()
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
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        List<TcrCampaignWithUseCases> expectedData =
        [
            new()
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
            },
        ];
        ApiError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            ResponseTimeMs = 0,
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
        var model = new CampaignListResponse
        {
            Data =
            [
                new()
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
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CampaignListResponse
        {
            Data =
            [
                new()
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
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TcrCampaignWithUseCases> expectedData =
        [
            new()
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
            },
        ];
        ApiError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            ResponseTimeMs = 0,
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
        var model = new CampaignListResponse
        {
            Data =
            [
                new()
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
                ResponseTimeMs = 0,
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
        var model = new CampaignListResponse
        {
            Data =
            [
                new()
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
        var model = new CampaignListResponse
        {
            Data =
            [
                new()
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
        var model = new CampaignListResponse
        {
            Data =
            [
                new()
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
        var model = new CampaignListResponse
        {
            Data =
            [
                new()
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
        var model = new CampaignListResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
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
        var model = new CampaignListResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
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
        var model = new CampaignListResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
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
        var model = new CampaignListResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
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
        var model = new CampaignListResponse
        {
            Data =
            [
                new()
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
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        CampaignListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
