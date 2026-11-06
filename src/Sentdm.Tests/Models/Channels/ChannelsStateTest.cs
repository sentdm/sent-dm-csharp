using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels;
using Sentdm.Models.Channels.Rcs;
using Sms = Sentdm.Models.Channels.Sms;
using Voice = Sentdm.Models.Channels.Voice;
using Whatsapp = Sentdm.Models.Channels.Whatsapp;

namespace Sentdm.Tests.Models.Channels;

public class ChannelsStateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChannelsState
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

        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<MmsMarket> expectedMms =
        [
            new()
            {
                Country = "country",
                NumberType = "number_type",
                SenderValue = "sender_value",
                Status = "status",
            },
        ];
        RcsAgent expectedRcs = new()
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
        };
        List<Sms::SmsMarket> expectedSms =
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
        ];
        List<Voice::VoiceNumber> expectedVoice =
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
        ];
        Whatsapp::WhatsappChannel expectedWhatsapp = new()
        {
            OwnerBusinessID = "owner_business_id",
            PhoneNumberID = "phone_number_id",
            Reason = "reason",
            ReasonCode = "reason_code",
            SolutionID = "solution_id",
            Status = Whatsapp::Status.Provisioning,
            WabaID = "waba_id",
        };

        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.NotNull(model.Mms);
        Assert.Equal(expectedMms.Count, model.Mms.Count);
        for (int i = 0; i < expectedMms.Count; i++)
        {
            Assert.Equal(expectedMms[i], model.Mms[i]);
        }
        Assert.Equal(expectedRcs, model.Rcs);
        Assert.NotNull(model.Sms);
        Assert.Equal(expectedSms.Count, model.Sms.Count);
        for (int i = 0; i < expectedSms.Count; i++)
        {
            Assert.Equal(expectedSms[i], model.Sms[i]);
        }
        Assert.NotNull(model.Voice);
        Assert.Equal(expectedVoice.Count, model.Voice.Count);
        for (int i = 0; i < expectedVoice.Count; i++)
        {
            Assert.Equal(expectedVoice[i], model.Voice[i]);
        }
        Assert.Equal(expectedWhatsapp, model.Whatsapp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChannelsState
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChannelsState>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChannelsState
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChannelsState>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<MmsMarket> expectedMms =
        [
            new()
            {
                Country = "country",
                NumberType = "number_type",
                SenderValue = "sender_value",
                Status = "status",
            },
        ];
        RcsAgent expectedRcs = new()
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
        };
        List<Sms::SmsMarket> expectedSms =
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
        ];
        List<Voice::VoiceNumber> expectedVoice =
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
        ];
        Whatsapp::WhatsappChannel expectedWhatsapp = new()
        {
            OwnerBusinessID = "owner_business_id",
            PhoneNumberID = "phone_number_id",
            Reason = "reason",
            ReasonCode = "reason_code",
            SolutionID = "solution_id",
            Status = Whatsapp::Status.Provisioning,
            WabaID = "waba_id",
        };

        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.NotNull(deserialized.Mms);
        Assert.Equal(expectedMms.Count, deserialized.Mms.Count);
        for (int i = 0; i < expectedMms.Count; i++)
        {
            Assert.Equal(expectedMms[i], deserialized.Mms[i]);
        }
        Assert.Equal(expectedRcs, deserialized.Rcs);
        Assert.NotNull(deserialized.Sms);
        Assert.Equal(expectedSms.Count, deserialized.Sms.Count);
        for (int i = 0; i < expectedSms.Count; i++)
        {
            Assert.Equal(expectedSms[i], deserialized.Sms[i]);
        }
        Assert.NotNull(deserialized.Voice);
        Assert.Equal(expectedVoice.Count, deserialized.Voice.Count);
        for (int i = 0; i < expectedVoice.Count; i++)
        {
            Assert.Equal(expectedVoice[i], deserialized.Voice[i]);
        }
        Assert.Equal(expectedWhatsapp, deserialized.Whatsapp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChannelsState
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChannelsState
        {
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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

        Assert.Null(model.Mms);
        Assert.False(model.RawData.ContainsKey("mms"));
        Assert.Null(model.Sms);
        Assert.False(model.RawData.ContainsKey("sms"));
        Assert.Null(model.Voice);
        Assert.False(model.RawData.ContainsKey("voice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChannelsState
        {
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChannelsState
        {
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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

            // Null should be interpreted as omitted for these properties
            Mms = null,
            Sms = null,
            Voice = null,
        };

        Assert.Null(model.Mms);
        Assert.False(model.RawData.ContainsKey("mms"));
        Assert.Null(model.Sms);
        Assert.False(model.RawData.ContainsKey("sms"));
        Assert.Null(model.Voice);
        Assert.False(model.RawData.ContainsKey("voice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChannelsState
        {
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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

            // Null should be interpreted as omitted for these properties
            Mms = null,
            Sms = null,
            Voice = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChannelsState
        {
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
        };

        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customer_id"));
        Assert.Null(model.Rcs);
        Assert.False(model.RawData.ContainsKey("rcs"));
        Assert.Null(model.Whatsapp);
        Assert.False(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChannelsState
        {
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChannelsState
        {
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

            CustomerID = null,
            Rcs = null,
            Whatsapp = null,
        };

        Assert.Null(model.CustomerID);
        Assert.True(model.RawData.ContainsKey("customer_id"));
        Assert.Null(model.Rcs);
        Assert.True(model.RawData.ContainsKey("rcs"));
        Assert.Null(model.Whatsapp);
        Assert.True(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChannelsState
        {
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

            CustomerID = null,
            Rcs = null,
            Whatsapp = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChannelsState
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

        ChannelsState copied = new(model);

        Assert.Equal(model, copied);
    }
}
