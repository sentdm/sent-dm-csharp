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

public class SenderProfilesListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SenderProfilesList
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
                                        SenderValue = "sender_value",
                                        Status = "status",
                                    },
                                ],
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SenderValue = "sender_value",
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

        PaginationMeta expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };
        List<SenderProfile> expectedSenderProfiles =
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
                                    SenderValue = "sender_value",
                                    Status = "status",
                                },
                            ],
                            Reason = "reason",
                            ReasonCode = "reason_code",
                            SenderValue = "sender_value",
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
        ];

        Assert.Equal(expectedPagination, model.Pagination);
        Assert.NotNull(model.SenderProfiles);
        Assert.Equal(expectedSenderProfiles.Count, model.SenderProfiles.Count);
        for (int i = 0; i < expectedSenderProfiles.Count; i++)
        {
            Assert.Equal(expectedSenderProfiles[i], model.SenderProfiles[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SenderProfilesList
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
                                        SenderValue = "sender_value",
                                        Status = "status",
                                    },
                                ],
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SenderValue = "sender_value",
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfilesList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SenderProfilesList
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
                                        SenderValue = "sender_value",
                                        Status = "status",
                                    },
                                ],
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SenderValue = "sender_value",
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfilesList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PaginationMeta expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };
        List<SenderProfile> expectedSenderProfiles =
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
                                    SenderValue = "sender_value",
                                    Status = "status",
                                },
                            ],
                            Reason = "reason",
                            ReasonCode = "reason_code",
                            SenderValue = "sender_value",
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
        ];

        Assert.Equal(expectedPagination, deserialized.Pagination);
        Assert.NotNull(deserialized.SenderProfiles);
        Assert.Equal(expectedSenderProfiles.Count, deserialized.SenderProfiles.Count);
        for (int i = 0; i < expectedSenderProfiles.Count; i++)
        {
            Assert.Equal(expectedSenderProfiles[i], deserialized.SenderProfiles[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SenderProfilesList
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
                                        SenderValue = "sender_value",
                                        Status = "status",
                                    },
                                ],
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SenderValue = "sender_value",
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SenderProfilesList { };

        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
        Assert.Null(model.SenderProfiles);
        Assert.False(model.RawData.ContainsKey("sender_profiles"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SenderProfilesList { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SenderProfilesList
        {
            // Null should be interpreted as omitted for these properties
            Pagination = null,
            SenderProfiles = null,
        };

        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
        Assert.Null(model.SenderProfiles);
        Assert.False(model.RawData.ContainsKey("sender_profiles"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SenderProfilesList
        {
            // Null should be interpreted as omitted for these properties
            Pagination = null,
            SenderProfiles = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SenderProfilesList
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
                                        SenderValue = "sender_value",
                                        Status = "status",
                                    },
                                ],
                                Reason = "reason",
                                ReasonCode = "reason_code",
                                SenderValue = "sender_value",
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

        SenderProfilesList copied = new(model);

        Assert.Equal(model, copied);
    }
}
