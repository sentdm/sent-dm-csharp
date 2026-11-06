using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels;
using Sentdm.Models.Channels.Rcs;
using Sentdm.Models.SenderProfiles;
using Sms = Sentdm.Models.Channels.Sms;
using Whatsapp = Sentdm.Models.Channels.Whatsapp;

namespace Sentdm.Tests.Models.SenderProfiles;

public class SenderProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SenderProfile
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
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedApiKey = "api_key";
        SenderProfileBilling expectedBilling = new() { Inherit = true };
        ChannelsState expectedChannels = new()
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
        };
        Sms::SuppliedCompliance expectedCompliance = new()
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
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedName = "name";
        string expectedNotifications = "notifications";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedShortName = "short_name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedBilling, model.Billing);
        Assert.Equal(expectedChannels, model.Channels);
        Assert.Equal(expectedCompliance, model.Compliance);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedNotifications, model.Notifications);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.Equal(expectedShortName, model.ShortName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SenderProfile
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SenderProfile
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedApiKey = "api_key";
        SenderProfileBilling expectedBilling = new() { Inherit = true };
        ChannelsState expectedChannels = new()
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
        };
        Sms::SuppliedCompliance expectedCompliance = new()
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
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedName = "name";
        string expectedNotifications = "notifications";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedShortName = "short_name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedBilling, deserialized.Billing);
        Assert.Equal(expectedChannels, deserialized.Channels);
        Assert.Equal(expectedCompliance, deserialized.Compliance);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedNotifications, deserialized.Notifications);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.Equal(expectedShortName, deserialized.ShortName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SenderProfile
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SenderProfile
        {
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
            Description = "description",
            Notifications = "notifications",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ShortName = "short_name",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SenderProfile
        {
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
            Description = "description",
            Notifications = "notifications",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ShortName = "short_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SenderProfile
        {
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
            Description = "description",
            Notifications = "notifications",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ShortName = "short_name",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Name = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SenderProfile
        {
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
            Description = "description",
            Notifications = "notifications",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ShortName = "short_name",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SenderProfile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.Billing);
        Assert.False(model.RawData.ContainsKey("billing"));
        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Compliance);
        Assert.False(model.RawData.ContainsKey("compliance"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Notifications);
        Assert.False(model.RawData.ContainsKey("notifications"));
        Assert.Null(model.OrganizationID);
        Assert.False(model.RawData.ContainsKey("organization_id"));
        Assert.Null(model.ShortName);
        Assert.False(model.RawData.ContainsKey("short_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SenderProfile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SenderProfile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",

            ApiKey = null,
            Billing = null,
            Channels = null,
            Compliance = null,
            Description = null,
            Notifications = null,
            OrganizationID = null,
            ShortName = null,
        };

        Assert.Null(model.ApiKey);
        Assert.True(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.Billing);
        Assert.True(model.RawData.ContainsKey("billing"));
        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Compliance);
        Assert.True(model.RawData.ContainsKey("compliance"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Notifications);
        Assert.True(model.RawData.ContainsKey("notifications"));
        Assert.Null(model.OrganizationID);
        Assert.True(model.RawData.ContainsKey("organization_id"));
        Assert.Null(model.ShortName);
        Assert.True(model.RawData.ContainsKey("short_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SenderProfile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",

            ApiKey = null,
            Billing = null,
            Channels = null,
            Compliance = null,
            Description = null,
            Notifications = null,
            OrganizationID = null,
            ShortName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SenderProfile
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
        };

        SenderProfile copied = new(model);

        Assert.Equal(model, copied);
    }
}
