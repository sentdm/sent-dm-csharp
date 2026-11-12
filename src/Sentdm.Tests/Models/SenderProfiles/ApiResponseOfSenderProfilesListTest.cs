using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Rcs;
using Sentdm.Models.SenderProfiles;
using Sentdm.Models.Webhooks;
using Sms = Sentdm.Models.Channels.Sms;
using Whatsapp = Sentdm.Models.Channels.Whatsapp;

namespace Sentdm.Tests.Models.SenderProfiles;

public class ApiResponseOfSenderProfilesListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiResponseOfSenderProfilesList
        {
            Data = new()
            {
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
                SenderProfiles =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ApiKey = "api_key",
                        Billing = new() { Inherit = true },
                        Channels = new()
                        {
                            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            Mms =
                            [
                                new()
                                {
                                    Country = "country",
                                    NumberType = "number_type",
                                    SenderValue = "sender_value",
                                    Status = "status",
                                },
                            ],
                            Rcs = new()
                            {
                                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                AgentUseCase = "agent_use_case",
                                BrandColor = "brand_color",
                                BrandEmail = "brand_email",
                                BrandName = "brand_name",
                                BrandPhoneNumber = "brand_phone_number",
                                BriefCompanyDescription = "brief_company_description",
                                CompanyEin = "company_ein",
                                ContactNameAndTitle = "contact_name_and_title",
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CustomerSupportEmail = "customer_support_email",
                                CustomerSupportPhoneNumber = "customer_support_phone_number",
                                Description = "description",
                                DisplayName = "display_name",
                                EntityType = "entity_type",
                                HelpMessage = "help_message",
                                OfficialAddress = new()
                                {
                                    City = "city",
                                    Country = "country",
                                    PostalCode = "postal_code",
                                    State = "state",
                                    Street = "street",
                                },
                                OptInProcessDescription = "opt_in_process_description",
                                PhoneNumber = "phone_number",
                                PrivacyPolicyUrl = "privacy_policy_url",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SampleMessages = ["string"],
                                StartMessage = "start_message",
                                Status = Status.Provisioning,
                                StopMessage = "stop_message",
                                TermsAndConditionsUrl = "terms_and_conditions_url",
                                WebsiteUrl = "website_url",
                            },
                            Sms =
                            [
                                new()
                                {
                                    Compliance = new()
                                    {
                                        Brand = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaign = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaigns =
                                        [
                                            new Dictionary<string, JsonElement>()
                                            {
                                                { "foo", JsonSerializer.SerializeToElement("bar") },
                                            },
                                        ],
                                        Documents =
                                        [
                                            new()
                                            {
                                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                                FileName = "file_name",
                                                Key = "key",
                                            },
                                        ],
                                    },
                                    Country = "country",
                                    NumberType = "number_type",
                                    Numbers =
                                    [
                                        new()
                                        {
                                            AreaCode = "area_code",
                                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                            SenderValue = "sender_value",
                                            Status = "status",
                                        },
                                    ],
                                    Reason = "reason",
                                    ReasonCode = "reason_code",
                                    Status = Sms::Status.Provisioning,
                                },
                            ],
                            Voice =
                            [
                                new()
                                {
                                    AgentID = "agent_id",
                                    CallbackUrl = "callback_url",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    DefaultForAppCalls = true,
                                    Number = "number",
                                    RoutesTo = "routes_to",
                                    Status = "status",
                                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                },
                            ],
                            Whatsapp = new()
                            {
                                OwnerBusinessID = "owner_business_id",
                                PhoneNumberID = "phone_number_id",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SolutionID = "solution_id",
                                Status = Whatsapp::Status.Provisioning,
                                WabaID = "waba_id",
                            },
                        },
                        Compliance = new()
                        {
                            Brand = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaign = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaigns =
                            [
                                new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                            ],
                            Documents =
                            [
                                new()
                                {
                                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                    FileName = "file_name",
                                    Key = "key",
                                },
                            ],
                        },
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Description = "description",
                        Name = "name",
                        Notifications = "notifications",
                        OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ShortName = "short_name",
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

        SenderProfilesList expectedData = new()
        {
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
            SenderProfiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ApiKey = "api_key",
                    Billing = new() { Inherit = true },
                    Channels = new()
                    {
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Mms =
                        [
                            new()
                            {
                                Country = "country",
                                NumberType = "number_type",
                                SenderValue = "sender_value",
                                Status = "status",
                            },
                        ],
                        Rcs = new()
                        {
                            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            AgentUseCase = "agent_use_case",
                            BrandColor = "brand_color",
                            BrandEmail = "brand_email",
                            BrandName = "brand_name",
                            BrandPhoneNumber = "brand_phone_number",
                            BriefCompanyDescription = "brief_company_description",
                            CompanyEin = "company_ein",
                            ContactNameAndTitle = "contact_name_and_title",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CustomerSupportEmail = "customer_support_email",
                            CustomerSupportPhoneNumber = "customer_support_phone_number",
                            Description = "description",
                            DisplayName = "display_name",
                            EntityType = "entity_type",
                            HelpMessage = "help_message",
                            OfficialAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                PostalCode = "postal_code",
                                State = "state",
                                Street = "street",
                            },
                            OptInProcessDescription = "opt_in_process_description",
                            PhoneNumber = "phone_number",
                            PrivacyPolicyUrl = "privacy_policy_url",
                            Reason = "reason",
                            ReasonCode = "reason_code",
                            SampleMessages = ["string"],
                            StartMessage = "start_message",
                            Status = Status.Provisioning,
                            StopMessage = "stop_message",
                            TermsAndConditionsUrl = "terms_and_conditions_url",
                            WebsiteUrl = "website_url",
                        },
                        Sms =
                        [
                            new()
                            {
                                Compliance = new()
                                {
                                    Brand = new Dictionary<string, JsonElement>()
                                    {
                                        { "foo", JsonSerializer.SerializeToElement("bar") },
                                    },
                                    Campaign = new Dictionary<string, JsonElement>()
                                    {
                                        { "foo", JsonSerializer.SerializeToElement("bar") },
                                    },
                                    Campaigns =
                                    [
                                        new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                    ],
                                    Documents =
                                    [
                                        new()
                                        {
                                            DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                            FileName = "file_name",
                                            Key = "key",
                                        },
                                    ],
                                },
                                Country = "country",
                                NumberType = "number_type",
                                Numbers =
                                [
                                    new()
                                    {
                                        AreaCode = "area_code",
                                        CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                        SenderValue = "sender_value",
                                        Status = "status",
                                    },
                                ],
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                Status = Sms::Status.Provisioning,
                            },
                        ],
                        Voice =
                        [
                            new()
                            {
                                AgentID = "agent_id",
                                CallbackUrl = "callback_url",
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                DefaultForAppCalls = true,
                                Number = "number",
                                RoutesTo = "routes_to",
                                Status = "status",
                                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            },
                        ],
                        Whatsapp = new()
                        {
                            OwnerBusinessID = "owner_business_id",
                            PhoneNumberID = "phone_number_id",
                            Reason = "reason",
                            ReasonCode = "reason_code",
                            SolutionID = "solution_id",
                            Status = Whatsapp::Status.Provisioning,
                            WabaID = "waba_id",
                        },
                    },
                    Compliance = new()
                    {
                        Brand = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaign = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaigns =
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ],
                        Documents =
                        [
                            new()
                            {
                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                FileName = "file_name",
                                Key = "key",
                            },
                        ],
                    },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    Notifications = "notifications",
                    OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ShortName = "short_name",
                },
            ],
        };
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

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedMeta, model.Meta);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiResponseOfSenderProfilesList
        {
            Data = new()
            {
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
                SenderProfiles =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ApiKey = "api_key",
                        Billing = new() { Inherit = true },
                        Channels = new()
                        {
                            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            Mms =
                            [
                                new()
                                {
                                    Country = "country",
                                    NumberType = "number_type",
                                    SenderValue = "sender_value",
                                    Status = "status",
                                },
                            ],
                            Rcs = new()
                            {
                                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                AgentUseCase = "agent_use_case",
                                BrandColor = "brand_color",
                                BrandEmail = "brand_email",
                                BrandName = "brand_name",
                                BrandPhoneNumber = "brand_phone_number",
                                BriefCompanyDescription = "brief_company_description",
                                CompanyEin = "company_ein",
                                ContactNameAndTitle = "contact_name_and_title",
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CustomerSupportEmail = "customer_support_email",
                                CustomerSupportPhoneNumber = "customer_support_phone_number",
                                Description = "description",
                                DisplayName = "display_name",
                                EntityType = "entity_type",
                                HelpMessage = "help_message",
                                OfficialAddress = new()
                                {
                                    City = "city",
                                    Country = "country",
                                    PostalCode = "postal_code",
                                    State = "state",
                                    Street = "street",
                                },
                                OptInProcessDescription = "opt_in_process_description",
                                PhoneNumber = "phone_number",
                                PrivacyPolicyUrl = "privacy_policy_url",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SampleMessages = ["string"],
                                StartMessage = "start_message",
                                Status = Status.Provisioning,
                                StopMessage = "stop_message",
                                TermsAndConditionsUrl = "terms_and_conditions_url",
                                WebsiteUrl = "website_url",
                            },
                            Sms =
                            [
                                new()
                                {
                                    Compliance = new()
                                    {
                                        Brand = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaign = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaigns =
                                        [
                                            new Dictionary<string, JsonElement>()
                                            {
                                                { "foo", JsonSerializer.SerializeToElement("bar") },
                                            },
                                        ],
                                        Documents =
                                        [
                                            new()
                                            {
                                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                                FileName = "file_name",
                                                Key = "key",
                                            },
                                        ],
                                    },
                                    Country = "country",
                                    NumberType = "number_type",
                                    Numbers =
                                    [
                                        new()
                                        {
                                            AreaCode = "area_code",
                                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                            SenderValue = "sender_value",
                                            Status = "status",
                                        },
                                    ],
                                    Reason = "reason",
                                    ReasonCode = "reason_code",
                                    Status = Sms::Status.Provisioning,
                                },
                            ],
                            Voice =
                            [
                                new()
                                {
                                    AgentID = "agent_id",
                                    CallbackUrl = "callback_url",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    DefaultForAppCalls = true,
                                    Number = "number",
                                    RoutesTo = "routes_to",
                                    Status = "status",
                                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                },
                            ],
                            Whatsapp = new()
                            {
                                OwnerBusinessID = "owner_business_id",
                                PhoneNumberID = "phone_number_id",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SolutionID = "solution_id",
                                Status = Whatsapp::Status.Provisioning,
                                WabaID = "waba_id",
                            },
                        },
                        Compliance = new()
                        {
                            Brand = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaign = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaigns =
                            [
                                new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                            ],
                            Documents =
                            [
                                new()
                                {
                                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                    FileName = "file_name",
                                    Key = "key",
                                },
                            ],
                        },
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Description = "description",
                        Name = "name",
                        Notifications = "notifications",
                        OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ShortName = "short_name",
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
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfSenderProfilesList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiResponseOfSenderProfilesList
        {
            Data = new()
            {
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
                SenderProfiles =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ApiKey = "api_key",
                        Billing = new() { Inherit = true },
                        Channels = new()
                        {
                            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            Mms =
                            [
                                new()
                                {
                                    Country = "country",
                                    NumberType = "number_type",
                                    SenderValue = "sender_value",
                                    Status = "status",
                                },
                            ],
                            Rcs = new()
                            {
                                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                AgentUseCase = "agent_use_case",
                                BrandColor = "brand_color",
                                BrandEmail = "brand_email",
                                BrandName = "brand_name",
                                BrandPhoneNumber = "brand_phone_number",
                                BriefCompanyDescription = "brief_company_description",
                                CompanyEin = "company_ein",
                                ContactNameAndTitle = "contact_name_and_title",
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CustomerSupportEmail = "customer_support_email",
                                CustomerSupportPhoneNumber = "customer_support_phone_number",
                                Description = "description",
                                DisplayName = "display_name",
                                EntityType = "entity_type",
                                HelpMessage = "help_message",
                                OfficialAddress = new()
                                {
                                    City = "city",
                                    Country = "country",
                                    PostalCode = "postal_code",
                                    State = "state",
                                    Street = "street",
                                },
                                OptInProcessDescription = "opt_in_process_description",
                                PhoneNumber = "phone_number",
                                PrivacyPolicyUrl = "privacy_policy_url",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SampleMessages = ["string"],
                                StartMessage = "start_message",
                                Status = Status.Provisioning,
                                StopMessage = "stop_message",
                                TermsAndConditionsUrl = "terms_and_conditions_url",
                                WebsiteUrl = "website_url",
                            },
                            Sms =
                            [
                                new()
                                {
                                    Compliance = new()
                                    {
                                        Brand = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaign = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaigns =
                                        [
                                            new Dictionary<string, JsonElement>()
                                            {
                                                { "foo", JsonSerializer.SerializeToElement("bar") },
                                            },
                                        ],
                                        Documents =
                                        [
                                            new()
                                            {
                                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                                FileName = "file_name",
                                                Key = "key",
                                            },
                                        ],
                                    },
                                    Country = "country",
                                    NumberType = "number_type",
                                    Numbers =
                                    [
                                        new()
                                        {
                                            AreaCode = "area_code",
                                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                            SenderValue = "sender_value",
                                            Status = "status",
                                        },
                                    ],
                                    Reason = "reason",
                                    ReasonCode = "reason_code",
                                    Status = Sms::Status.Provisioning,
                                },
                            ],
                            Voice =
                            [
                                new()
                                {
                                    AgentID = "agent_id",
                                    CallbackUrl = "callback_url",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    DefaultForAppCalls = true,
                                    Number = "number",
                                    RoutesTo = "routes_to",
                                    Status = "status",
                                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                },
                            ],
                            Whatsapp = new()
                            {
                                OwnerBusinessID = "owner_business_id",
                                PhoneNumberID = "phone_number_id",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SolutionID = "solution_id",
                                Status = Whatsapp::Status.Provisioning,
                                WabaID = "waba_id",
                            },
                        },
                        Compliance = new()
                        {
                            Brand = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaign = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaigns =
                            [
                                new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                            ],
                            Documents =
                            [
                                new()
                                {
                                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                    FileName = "file_name",
                                    Key = "key",
                                },
                            ],
                        },
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Description = "description",
                        Name = "name",
                        Notifications = "notifications",
                        OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ShortName = "short_name",
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
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfSenderProfilesList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SenderProfilesList expectedData = new()
        {
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
            SenderProfiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ApiKey = "api_key",
                    Billing = new() { Inherit = true },
                    Channels = new()
                    {
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Mms =
                        [
                            new()
                            {
                                Country = "country",
                                NumberType = "number_type",
                                SenderValue = "sender_value",
                                Status = "status",
                            },
                        ],
                        Rcs = new()
                        {
                            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            AgentUseCase = "agent_use_case",
                            BrandColor = "brand_color",
                            BrandEmail = "brand_email",
                            BrandName = "brand_name",
                            BrandPhoneNumber = "brand_phone_number",
                            BriefCompanyDescription = "brief_company_description",
                            CompanyEin = "company_ein",
                            ContactNameAndTitle = "contact_name_and_title",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CustomerSupportEmail = "customer_support_email",
                            CustomerSupportPhoneNumber = "customer_support_phone_number",
                            Description = "description",
                            DisplayName = "display_name",
                            EntityType = "entity_type",
                            HelpMessage = "help_message",
                            OfficialAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                PostalCode = "postal_code",
                                State = "state",
                                Street = "street",
                            },
                            OptInProcessDescription = "opt_in_process_description",
                            PhoneNumber = "phone_number",
                            PrivacyPolicyUrl = "privacy_policy_url",
                            Reason = "reason",
                            ReasonCode = "reason_code",
                            SampleMessages = ["string"],
                            StartMessage = "start_message",
                            Status = Status.Provisioning,
                            StopMessage = "stop_message",
                            TermsAndConditionsUrl = "terms_and_conditions_url",
                            WebsiteUrl = "website_url",
                        },
                        Sms =
                        [
                            new()
                            {
                                Compliance = new()
                                {
                                    Brand = new Dictionary<string, JsonElement>()
                                    {
                                        { "foo", JsonSerializer.SerializeToElement("bar") },
                                    },
                                    Campaign = new Dictionary<string, JsonElement>()
                                    {
                                        { "foo", JsonSerializer.SerializeToElement("bar") },
                                    },
                                    Campaigns =
                                    [
                                        new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                    ],
                                    Documents =
                                    [
                                        new()
                                        {
                                            DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                            FileName = "file_name",
                                            Key = "key",
                                        },
                                    ],
                                },
                                Country = "country",
                                NumberType = "number_type",
                                Numbers =
                                [
                                    new()
                                    {
                                        AreaCode = "area_code",
                                        CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                        SenderValue = "sender_value",
                                        Status = "status",
                                    },
                                ],
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                Status = Sms::Status.Provisioning,
                            },
                        ],
                        Voice =
                        [
                            new()
                            {
                                AgentID = "agent_id",
                                CallbackUrl = "callback_url",
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                DefaultForAppCalls = true,
                                Number = "number",
                                RoutesTo = "routes_to",
                                Status = "status",
                                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            },
                        ],
                        Whatsapp = new()
                        {
                            OwnerBusinessID = "owner_business_id",
                            PhoneNumberID = "phone_number_id",
                            Reason = "reason",
                            ReasonCode = "reason_code",
                            SolutionID = "solution_id",
                            Status = Whatsapp::Status.Provisioning,
                            WabaID = "waba_id",
                        },
                    },
                    Compliance = new()
                    {
                        Brand = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaign = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaigns =
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ],
                        Documents =
                        [
                            new()
                            {
                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                FileName = "file_name",
                                Key = "key",
                            },
                        ],
                    },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Name = "name",
                    Notifications = "notifications",
                    OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ShortName = "short_name",
                },
            ],
        };
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

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedMeta, deserialized.Meta);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiResponseOfSenderProfilesList
        {
            Data = new()
            {
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
                SenderProfiles =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ApiKey = "api_key",
                        Billing = new() { Inherit = true },
                        Channels = new()
                        {
                            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            Mms =
                            [
                                new()
                                {
                                    Country = "country",
                                    NumberType = "number_type",
                                    SenderValue = "sender_value",
                                    Status = "status",
                                },
                            ],
                            Rcs = new()
                            {
                                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                AgentUseCase = "agent_use_case",
                                BrandColor = "brand_color",
                                BrandEmail = "brand_email",
                                BrandName = "brand_name",
                                BrandPhoneNumber = "brand_phone_number",
                                BriefCompanyDescription = "brief_company_description",
                                CompanyEin = "company_ein",
                                ContactNameAndTitle = "contact_name_and_title",
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CustomerSupportEmail = "customer_support_email",
                                CustomerSupportPhoneNumber = "customer_support_phone_number",
                                Description = "description",
                                DisplayName = "display_name",
                                EntityType = "entity_type",
                                HelpMessage = "help_message",
                                OfficialAddress = new()
                                {
                                    City = "city",
                                    Country = "country",
                                    PostalCode = "postal_code",
                                    State = "state",
                                    Street = "street",
                                },
                                OptInProcessDescription = "opt_in_process_description",
                                PhoneNumber = "phone_number",
                                PrivacyPolicyUrl = "privacy_policy_url",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SampleMessages = ["string"],
                                StartMessage = "start_message",
                                Status = Status.Provisioning,
                                StopMessage = "stop_message",
                                TermsAndConditionsUrl = "terms_and_conditions_url",
                                WebsiteUrl = "website_url",
                            },
                            Sms =
                            [
                                new()
                                {
                                    Compliance = new()
                                    {
                                        Brand = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaign = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaigns =
                                        [
                                            new Dictionary<string, JsonElement>()
                                            {
                                                { "foo", JsonSerializer.SerializeToElement("bar") },
                                            },
                                        ],
                                        Documents =
                                        [
                                            new()
                                            {
                                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                                FileName = "file_name",
                                                Key = "key",
                                            },
                                        ],
                                    },
                                    Country = "country",
                                    NumberType = "number_type",
                                    Numbers =
                                    [
                                        new()
                                        {
                                            AreaCode = "area_code",
                                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                            SenderValue = "sender_value",
                                            Status = "status",
                                        },
                                    ],
                                    Reason = "reason",
                                    ReasonCode = "reason_code",
                                    Status = Sms::Status.Provisioning,
                                },
                            ],
                            Voice =
                            [
                                new()
                                {
                                    AgentID = "agent_id",
                                    CallbackUrl = "callback_url",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    DefaultForAppCalls = true,
                                    Number = "number",
                                    RoutesTo = "routes_to",
                                    Status = "status",
                                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                },
                            ],
                            Whatsapp = new()
                            {
                                OwnerBusinessID = "owner_business_id",
                                PhoneNumberID = "phone_number_id",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SolutionID = "solution_id",
                                Status = Whatsapp::Status.Provisioning,
                                WabaID = "waba_id",
                            },
                        },
                        Compliance = new()
                        {
                            Brand = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaign = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaigns =
                            [
                                new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                            ],
                            Documents =
                            [
                                new()
                                {
                                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                    FileName = "file_name",
                                    Key = "key",
                                },
                            ],
                        },
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Description = "description",
                        Name = "name",
                        Notifications = "notifications",
                        OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ShortName = "short_name",
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
        var model = new ApiResponseOfSenderProfilesList
        {
            Data = new()
            {
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
                SenderProfiles =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ApiKey = "api_key",
                        Billing = new() { Inherit = true },
                        Channels = new()
                        {
                            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            Mms =
                            [
                                new()
                                {
                                    Country = "country",
                                    NumberType = "number_type",
                                    SenderValue = "sender_value",
                                    Status = "status",
                                },
                            ],
                            Rcs = new()
                            {
                                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                AgentUseCase = "agent_use_case",
                                BrandColor = "brand_color",
                                BrandEmail = "brand_email",
                                BrandName = "brand_name",
                                BrandPhoneNumber = "brand_phone_number",
                                BriefCompanyDescription = "brief_company_description",
                                CompanyEin = "company_ein",
                                ContactNameAndTitle = "contact_name_and_title",
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CustomerSupportEmail = "customer_support_email",
                                CustomerSupportPhoneNumber = "customer_support_phone_number",
                                Description = "description",
                                DisplayName = "display_name",
                                EntityType = "entity_type",
                                HelpMessage = "help_message",
                                OfficialAddress = new()
                                {
                                    City = "city",
                                    Country = "country",
                                    PostalCode = "postal_code",
                                    State = "state",
                                    Street = "street",
                                },
                                OptInProcessDescription = "opt_in_process_description",
                                PhoneNumber = "phone_number",
                                PrivacyPolicyUrl = "privacy_policy_url",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SampleMessages = ["string"],
                                StartMessage = "start_message",
                                Status = Status.Provisioning,
                                StopMessage = "stop_message",
                                TermsAndConditionsUrl = "terms_and_conditions_url",
                                WebsiteUrl = "website_url",
                            },
                            Sms =
                            [
                                new()
                                {
                                    Compliance = new()
                                    {
                                        Brand = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaign = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaigns =
                                        [
                                            new Dictionary<string, JsonElement>()
                                            {
                                                { "foo", JsonSerializer.SerializeToElement("bar") },
                                            },
                                        ],
                                        Documents =
                                        [
                                            new()
                                            {
                                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                                FileName = "file_name",
                                                Key = "key",
                                            },
                                        ],
                                    },
                                    Country = "country",
                                    NumberType = "number_type",
                                    Numbers =
                                    [
                                        new()
                                        {
                                            AreaCode = "area_code",
                                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                            SenderValue = "sender_value",
                                            Status = "status",
                                        },
                                    ],
                                    Reason = "reason",
                                    ReasonCode = "reason_code",
                                    Status = Sms::Status.Provisioning,
                                },
                            ],
                            Voice =
                            [
                                new()
                                {
                                    AgentID = "agent_id",
                                    CallbackUrl = "callback_url",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    DefaultForAppCalls = true,
                                    Number = "number",
                                    RoutesTo = "routes_to",
                                    Status = "status",
                                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                },
                            ],
                            Whatsapp = new()
                            {
                                OwnerBusinessID = "owner_business_id",
                                PhoneNumberID = "phone_number_id",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SolutionID = "solution_id",
                                Status = Whatsapp::Status.Provisioning,
                                WabaID = "waba_id",
                            },
                        },
                        Compliance = new()
                        {
                            Brand = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaign = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaigns =
                            [
                                new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                            ],
                            Documents =
                            [
                                new()
                                {
                                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                    FileName = "file_name",
                                    Key = "key",
                                },
                            ],
                        },
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Description = "description",
                        Name = "name",
                        Notifications = "notifications",
                        OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ShortName = "short_name",
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
        var model = new ApiResponseOfSenderProfilesList
        {
            Data = new()
            {
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
                SenderProfiles =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ApiKey = "api_key",
                        Billing = new() { Inherit = true },
                        Channels = new()
                        {
                            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            Mms =
                            [
                                new()
                                {
                                    Country = "country",
                                    NumberType = "number_type",
                                    SenderValue = "sender_value",
                                    Status = "status",
                                },
                            ],
                            Rcs = new()
                            {
                                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                AgentUseCase = "agent_use_case",
                                BrandColor = "brand_color",
                                BrandEmail = "brand_email",
                                BrandName = "brand_name",
                                BrandPhoneNumber = "brand_phone_number",
                                BriefCompanyDescription = "brief_company_description",
                                CompanyEin = "company_ein",
                                ContactNameAndTitle = "contact_name_and_title",
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CustomerSupportEmail = "customer_support_email",
                                CustomerSupportPhoneNumber = "customer_support_phone_number",
                                Description = "description",
                                DisplayName = "display_name",
                                EntityType = "entity_type",
                                HelpMessage = "help_message",
                                OfficialAddress = new()
                                {
                                    City = "city",
                                    Country = "country",
                                    PostalCode = "postal_code",
                                    State = "state",
                                    Street = "street",
                                },
                                OptInProcessDescription = "opt_in_process_description",
                                PhoneNumber = "phone_number",
                                PrivacyPolicyUrl = "privacy_policy_url",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SampleMessages = ["string"],
                                StartMessage = "start_message",
                                Status = Status.Provisioning,
                                StopMessage = "stop_message",
                                TermsAndConditionsUrl = "terms_and_conditions_url",
                                WebsiteUrl = "website_url",
                            },
                            Sms =
                            [
                                new()
                                {
                                    Compliance = new()
                                    {
                                        Brand = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaign = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaigns =
                                        [
                                            new Dictionary<string, JsonElement>()
                                            {
                                                { "foo", JsonSerializer.SerializeToElement("bar") },
                                            },
                                        ],
                                        Documents =
                                        [
                                            new()
                                            {
                                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                                FileName = "file_name",
                                                Key = "key",
                                            },
                                        ],
                                    },
                                    Country = "country",
                                    NumberType = "number_type",
                                    Numbers =
                                    [
                                        new()
                                        {
                                            AreaCode = "area_code",
                                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                            SenderValue = "sender_value",
                                            Status = "status",
                                        },
                                    ],
                                    Reason = "reason",
                                    ReasonCode = "reason_code",
                                    Status = Sms::Status.Provisioning,
                                },
                            ],
                            Voice =
                            [
                                new()
                                {
                                    AgentID = "agent_id",
                                    CallbackUrl = "callback_url",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    DefaultForAppCalls = true,
                                    Number = "number",
                                    RoutesTo = "routes_to",
                                    Status = "status",
                                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                },
                            ],
                            Whatsapp = new()
                            {
                                OwnerBusinessID = "owner_business_id",
                                PhoneNumberID = "phone_number_id",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SolutionID = "solution_id",
                                Status = Whatsapp::Status.Provisioning,
                                WabaID = "waba_id",
                            },
                        },
                        Compliance = new()
                        {
                            Brand = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaign = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaigns =
                            [
                                new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                            ],
                            Documents =
                            [
                                new()
                                {
                                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                    FileName = "file_name",
                                    Key = "key",
                                },
                            ],
                        },
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Description = "description",
                        Name = "name",
                        Notifications = "notifications",
                        OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ShortName = "short_name",
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
        var model = new ApiResponseOfSenderProfilesList
        {
            Data = new()
            {
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
                SenderProfiles =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ApiKey = "api_key",
                        Billing = new() { Inherit = true },
                        Channels = new()
                        {
                            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            Mms =
                            [
                                new()
                                {
                                    Country = "country",
                                    NumberType = "number_type",
                                    SenderValue = "sender_value",
                                    Status = "status",
                                },
                            ],
                            Rcs = new()
                            {
                                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                AgentUseCase = "agent_use_case",
                                BrandColor = "brand_color",
                                BrandEmail = "brand_email",
                                BrandName = "brand_name",
                                BrandPhoneNumber = "brand_phone_number",
                                BriefCompanyDescription = "brief_company_description",
                                CompanyEin = "company_ein",
                                ContactNameAndTitle = "contact_name_and_title",
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CustomerSupportEmail = "customer_support_email",
                                CustomerSupportPhoneNumber = "customer_support_phone_number",
                                Description = "description",
                                DisplayName = "display_name",
                                EntityType = "entity_type",
                                HelpMessage = "help_message",
                                OfficialAddress = new()
                                {
                                    City = "city",
                                    Country = "country",
                                    PostalCode = "postal_code",
                                    State = "state",
                                    Street = "street",
                                },
                                OptInProcessDescription = "opt_in_process_description",
                                PhoneNumber = "phone_number",
                                PrivacyPolicyUrl = "privacy_policy_url",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SampleMessages = ["string"],
                                StartMessage = "start_message",
                                Status = Status.Provisioning,
                                StopMessage = "stop_message",
                                TermsAndConditionsUrl = "terms_and_conditions_url",
                                WebsiteUrl = "website_url",
                            },
                            Sms =
                            [
                                new()
                                {
                                    Compliance = new()
                                    {
                                        Brand = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaign = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaigns =
                                        [
                                            new Dictionary<string, JsonElement>()
                                            {
                                                { "foo", JsonSerializer.SerializeToElement("bar") },
                                            },
                                        ],
                                        Documents =
                                        [
                                            new()
                                            {
                                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                                FileName = "file_name",
                                                Key = "key",
                                            },
                                        ],
                                    },
                                    Country = "country",
                                    NumberType = "number_type",
                                    Numbers =
                                    [
                                        new()
                                        {
                                            AreaCode = "area_code",
                                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                            SenderValue = "sender_value",
                                            Status = "status",
                                        },
                                    ],
                                    Reason = "reason",
                                    ReasonCode = "reason_code",
                                    Status = Sms::Status.Provisioning,
                                },
                            ],
                            Voice =
                            [
                                new()
                                {
                                    AgentID = "agent_id",
                                    CallbackUrl = "callback_url",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    DefaultForAppCalls = true,
                                    Number = "number",
                                    RoutesTo = "routes_to",
                                    Status = "status",
                                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                },
                            ],
                            Whatsapp = new()
                            {
                                OwnerBusinessID = "owner_business_id",
                                PhoneNumberID = "phone_number_id",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SolutionID = "solution_id",
                                Status = Whatsapp::Status.Provisioning,
                                WabaID = "waba_id",
                            },
                        },
                        Compliance = new()
                        {
                            Brand = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaign = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaigns =
                            [
                                new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                            ],
                            Documents =
                            [
                                new()
                                {
                                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                    FileName = "file_name",
                                    Key = "key",
                                },
                            ],
                        },
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Description = "description",
                        Name = "name",
                        Notifications = "notifications",
                        OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ShortName = "short_name",
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
        var model = new ApiResponseOfSenderProfilesList
        {
            Data = new()
            {
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
                SenderProfiles =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ApiKey = "api_key",
                        Billing = new() { Inherit = true },
                        Channels = new()
                        {
                            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            Mms =
                            [
                                new()
                                {
                                    Country = "country",
                                    NumberType = "number_type",
                                    SenderValue = "sender_value",
                                    Status = "status",
                                },
                            ],
                            Rcs = new()
                            {
                                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                AgentUseCase = "agent_use_case",
                                BrandColor = "brand_color",
                                BrandEmail = "brand_email",
                                BrandName = "brand_name",
                                BrandPhoneNumber = "brand_phone_number",
                                BriefCompanyDescription = "brief_company_description",
                                CompanyEin = "company_ein",
                                ContactNameAndTitle = "contact_name_and_title",
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CustomerSupportEmail = "customer_support_email",
                                CustomerSupportPhoneNumber = "customer_support_phone_number",
                                Description = "description",
                                DisplayName = "display_name",
                                EntityType = "entity_type",
                                HelpMessage = "help_message",
                                OfficialAddress = new()
                                {
                                    City = "city",
                                    Country = "country",
                                    PostalCode = "postal_code",
                                    State = "state",
                                    Street = "street",
                                },
                                OptInProcessDescription = "opt_in_process_description",
                                PhoneNumber = "phone_number",
                                PrivacyPolicyUrl = "privacy_policy_url",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SampleMessages = ["string"],
                                StartMessage = "start_message",
                                Status = Status.Provisioning,
                                StopMessage = "stop_message",
                                TermsAndConditionsUrl = "terms_and_conditions_url",
                                WebsiteUrl = "website_url",
                            },
                            Sms =
                            [
                                new()
                                {
                                    Compliance = new()
                                    {
                                        Brand = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaign = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaigns =
                                        [
                                            new Dictionary<string, JsonElement>()
                                            {
                                                { "foo", JsonSerializer.SerializeToElement("bar") },
                                            },
                                        ],
                                        Documents =
                                        [
                                            new()
                                            {
                                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                                FileName = "file_name",
                                                Key = "key",
                                            },
                                        ],
                                    },
                                    Country = "country",
                                    NumberType = "number_type",
                                    Numbers =
                                    [
                                        new()
                                        {
                                            AreaCode = "area_code",
                                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                            SenderValue = "sender_value",
                                            Status = "status",
                                        },
                                    ],
                                    Reason = "reason",
                                    ReasonCode = "reason_code",
                                    Status = Sms::Status.Provisioning,
                                },
                            ],
                            Voice =
                            [
                                new()
                                {
                                    AgentID = "agent_id",
                                    CallbackUrl = "callback_url",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    DefaultForAppCalls = true,
                                    Number = "number",
                                    RoutesTo = "routes_to",
                                    Status = "status",
                                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                },
                            ],
                            Whatsapp = new()
                            {
                                OwnerBusinessID = "owner_business_id",
                                PhoneNumberID = "phone_number_id",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SolutionID = "solution_id",
                                Status = Whatsapp::Status.Provisioning,
                                WabaID = "waba_id",
                            },
                        },
                        Compliance = new()
                        {
                            Brand = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaign = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaigns =
                            [
                                new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                            ],
                            Documents =
                            [
                                new()
                                {
                                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                    FileName = "file_name",
                                    Key = "key",
                                },
                            ],
                        },
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Description = "description",
                        Name = "name",
                        Notifications = "notifications",
                        OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ShortName = "short_name",
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
        var model = new ApiResponseOfSenderProfilesList
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
        var model = new ApiResponseOfSenderProfilesList
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
        var model = new ApiResponseOfSenderProfilesList
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
        var model = new ApiResponseOfSenderProfilesList
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
        var model = new ApiResponseOfSenderProfilesList
        {
            Data = new()
            {
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
                SenderProfiles =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ApiKey = "api_key",
                        Billing = new() { Inherit = true },
                        Channels = new()
                        {
                            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            Mms =
                            [
                                new()
                                {
                                    Country = "country",
                                    NumberType = "number_type",
                                    SenderValue = "sender_value",
                                    Status = "status",
                                },
                            ],
                            Rcs = new()
                            {
                                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                AgentUseCase = "agent_use_case",
                                BrandColor = "brand_color",
                                BrandEmail = "brand_email",
                                BrandName = "brand_name",
                                BrandPhoneNumber = "brand_phone_number",
                                BriefCompanyDescription = "brief_company_description",
                                CompanyEin = "company_ein",
                                ContactNameAndTitle = "contact_name_and_title",
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CustomerSupportEmail = "customer_support_email",
                                CustomerSupportPhoneNumber = "customer_support_phone_number",
                                Description = "description",
                                DisplayName = "display_name",
                                EntityType = "entity_type",
                                HelpMessage = "help_message",
                                OfficialAddress = new()
                                {
                                    City = "city",
                                    Country = "country",
                                    PostalCode = "postal_code",
                                    State = "state",
                                    Street = "street",
                                },
                                OptInProcessDescription = "opt_in_process_description",
                                PhoneNumber = "phone_number",
                                PrivacyPolicyUrl = "privacy_policy_url",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SampleMessages = ["string"],
                                StartMessage = "start_message",
                                Status = Status.Provisioning,
                                StopMessage = "stop_message",
                                TermsAndConditionsUrl = "terms_and_conditions_url",
                                WebsiteUrl = "website_url",
                            },
                            Sms =
                            [
                                new()
                                {
                                    Compliance = new()
                                    {
                                        Brand = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaign = new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Campaigns =
                                        [
                                            new Dictionary<string, JsonElement>()
                                            {
                                                { "foo", JsonSerializer.SerializeToElement("bar") },
                                            },
                                        ],
                                        Documents =
                                        [
                                            new()
                                            {
                                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                                FileName = "file_name",
                                                Key = "key",
                                            },
                                        ],
                                    },
                                    Country = "country",
                                    NumberType = "number_type",
                                    Numbers =
                                    [
                                        new()
                                        {
                                            AreaCode = "area_code",
                                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                            SenderValue = "sender_value",
                                            Status = "status",
                                        },
                                    ],
                                    Reason = "reason",
                                    ReasonCode = "reason_code",
                                    Status = Sms::Status.Provisioning,
                                },
                            ],
                            Voice =
                            [
                                new()
                                {
                                    AgentID = "agent_id",
                                    CallbackUrl = "callback_url",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    DefaultForAppCalls = true,
                                    Number = "number",
                                    RoutesTo = "routes_to",
                                    Status = "status",
                                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                },
                            ],
                            Whatsapp = new()
                            {
                                OwnerBusinessID = "owner_business_id",
                                PhoneNumberID = "phone_number_id",
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SolutionID = "solution_id",
                                Status = Whatsapp::Status.Provisioning,
                                WabaID = "waba_id",
                            },
                        },
                        Compliance = new()
                        {
                            Brand = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaign = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Campaigns =
                            [
                                new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                            ],
                            Documents =
                            [
                                new()
                                {
                                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                    FileName = "file_name",
                                    Key = "key",
                                },
                            ],
                        },
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Description = "description",
                        Name = "name",
                        Notifications = "notifications",
                        OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ShortName = "short_name",
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

        ApiResponseOfSenderProfilesList copied = new(model);

        Assert.Equal(model, copied);
    }
}
