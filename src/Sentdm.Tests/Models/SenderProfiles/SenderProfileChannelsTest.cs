using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.SenderProfiles;

namespace Sentdm.Tests.Models.SenderProfiles;

public class SenderProfileChannelsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SenderProfileChannels
        {
            Rcs = new()
            {
                Description = "description",
                AgentUseCase = "agent_use_case",
                BannerUrl = "banner_url",
                BillingCategory = "billing_category",
                BrandColor = "brand_color",
                BrandEmail = "brand_email",
                BrandName = "brand_name",
                BrandPhoneNumber = "brand_phone_number",
                BriefCompanyDescription = "brief_company_description",
                CompanyEin = "company_ein",
                ContactNameAndTitle = "contact_name_and_title",
                CustomerSupportEmail = "customer_support_email",
                CustomerSupportPhoneNumber = "customer_support_phone_number",
                DisplayName = "display_name",
                EntityType = "entity_type",
                HelpMessage = "help_message",
                HostingRegion = "hosting_region",
                LogoUrl = "logo_url",
                OfficialAddress = new()
                {
                    City = "city",
                    Country = "country",
                    PostalCode = "postal_code",
                    State = "state",
                    Street = "street",
                },
                OptInProcessDescription = "opt_in_process_description",
                OptInScreenshotUrl = "opt_in_screenshot_url",
                PrivacyPolicyUrl = "privacy_policy_url",
                SampleMessages = ["string"],
                StartMessage = "start_message",
                StopMessage = "stop_message",
                TermsAndConditionsUrl = "terms_and_conditions_url",
                WebsiteUrl = "website_url",
            },
            Sms = new()
            {
                Country = "x",
                AreaCodes = ["string"],
                NumberType = "number_type",
                Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
                SenderValue = "sender_value",
            },
            Whatsapp = new() { PhoneNumberID = "phone_number_id", WabaID = "waba_id" },
        };

        SenderProfileRcs expectedRcs = new()
        {
            Description = "description",
            AgentUseCase = "agent_use_case",
            BannerUrl = "banner_url",
            BillingCategory = "billing_category",
            BrandColor = "brand_color",
            BrandEmail = "brand_email",
            BrandName = "brand_name",
            BrandPhoneNumber = "brand_phone_number",
            BriefCompanyDescription = "brief_company_description",
            CompanyEin = "company_ein",
            ContactNameAndTitle = "contact_name_and_title",
            CustomerSupportEmail = "customer_support_email",
            CustomerSupportPhoneNumber = "customer_support_phone_number",
            DisplayName = "display_name",
            EntityType = "entity_type",
            HelpMessage = "help_message",
            HostingRegion = "hosting_region",
            LogoUrl = "logo_url",
            OfficialAddress = new()
            {
                City = "city",
                Country = "country",
                PostalCode = "postal_code",
                State = "state",
                Street = "street",
            },
            OptInProcessDescription = "opt_in_process_description",
            OptInScreenshotUrl = "opt_in_screenshot_url",
            PrivacyPolicyUrl = "privacy_policy_url",
            SampleMessages = ["string"],
            StartMessage = "start_message",
            StopMessage = "stop_message",
            TermsAndConditionsUrl = "terms_and_conditions_url",
            WebsiteUrl = "website_url",
        };
        SenderProfileSms expectedSms = new()
        {
            Country = "x",
            AreaCodes = ["string"],
            NumberType = "number_type",
            Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
            SenderValue = "sender_value",
        };
        SenderProfileWhatsapp expectedWhatsapp = new()
        {
            PhoneNumberID = "phone_number_id",
            WabaID = "waba_id",
        };

        Assert.Equal(expectedRcs, model.Rcs);
        Assert.Equal(expectedSms, model.Sms);
        Assert.Equal(expectedWhatsapp, model.Whatsapp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SenderProfileChannels
        {
            Rcs = new()
            {
                Description = "description",
                AgentUseCase = "agent_use_case",
                BannerUrl = "banner_url",
                BillingCategory = "billing_category",
                BrandColor = "brand_color",
                BrandEmail = "brand_email",
                BrandName = "brand_name",
                BrandPhoneNumber = "brand_phone_number",
                BriefCompanyDescription = "brief_company_description",
                CompanyEin = "company_ein",
                ContactNameAndTitle = "contact_name_and_title",
                CustomerSupportEmail = "customer_support_email",
                CustomerSupportPhoneNumber = "customer_support_phone_number",
                DisplayName = "display_name",
                EntityType = "entity_type",
                HelpMessage = "help_message",
                HostingRegion = "hosting_region",
                LogoUrl = "logo_url",
                OfficialAddress = new()
                {
                    City = "city",
                    Country = "country",
                    PostalCode = "postal_code",
                    State = "state",
                    Street = "street",
                },
                OptInProcessDescription = "opt_in_process_description",
                OptInScreenshotUrl = "opt_in_screenshot_url",
                PrivacyPolicyUrl = "privacy_policy_url",
                SampleMessages = ["string"],
                StartMessage = "start_message",
                StopMessage = "stop_message",
                TermsAndConditionsUrl = "terms_and_conditions_url",
                WebsiteUrl = "website_url",
            },
            Sms = new()
            {
                Country = "x",
                AreaCodes = ["string"],
                NumberType = "number_type",
                Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
                SenderValue = "sender_value",
            },
            Whatsapp = new() { PhoneNumberID = "phone_number_id", WabaID = "waba_id" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfileChannels>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SenderProfileChannels
        {
            Rcs = new()
            {
                Description = "description",
                AgentUseCase = "agent_use_case",
                BannerUrl = "banner_url",
                BillingCategory = "billing_category",
                BrandColor = "brand_color",
                BrandEmail = "brand_email",
                BrandName = "brand_name",
                BrandPhoneNumber = "brand_phone_number",
                BriefCompanyDescription = "brief_company_description",
                CompanyEin = "company_ein",
                ContactNameAndTitle = "contact_name_and_title",
                CustomerSupportEmail = "customer_support_email",
                CustomerSupportPhoneNumber = "customer_support_phone_number",
                DisplayName = "display_name",
                EntityType = "entity_type",
                HelpMessage = "help_message",
                HostingRegion = "hosting_region",
                LogoUrl = "logo_url",
                OfficialAddress = new()
                {
                    City = "city",
                    Country = "country",
                    PostalCode = "postal_code",
                    State = "state",
                    Street = "street",
                },
                OptInProcessDescription = "opt_in_process_description",
                OptInScreenshotUrl = "opt_in_screenshot_url",
                PrivacyPolicyUrl = "privacy_policy_url",
                SampleMessages = ["string"],
                StartMessage = "start_message",
                StopMessage = "stop_message",
                TermsAndConditionsUrl = "terms_and_conditions_url",
                WebsiteUrl = "website_url",
            },
            Sms = new()
            {
                Country = "x",
                AreaCodes = ["string"],
                NumberType = "number_type",
                Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
                SenderValue = "sender_value",
            },
            Whatsapp = new() { PhoneNumberID = "phone_number_id", WabaID = "waba_id" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfileChannels>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SenderProfileRcs expectedRcs = new()
        {
            Description = "description",
            AgentUseCase = "agent_use_case",
            BannerUrl = "banner_url",
            BillingCategory = "billing_category",
            BrandColor = "brand_color",
            BrandEmail = "brand_email",
            BrandName = "brand_name",
            BrandPhoneNumber = "brand_phone_number",
            BriefCompanyDescription = "brief_company_description",
            CompanyEin = "company_ein",
            ContactNameAndTitle = "contact_name_and_title",
            CustomerSupportEmail = "customer_support_email",
            CustomerSupportPhoneNumber = "customer_support_phone_number",
            DisplayName = "display_name",
            EntityType = "entity_type",
            HelpMessage = "help_message",
            HostingRegion = "hosting_region",
            LogoUrl = "logo_url",
            OfficialAddress = new()
            {
                City = "city",
                Country = "country",
                PostalCode = "postal_code",
                State = "state",
                Street = "street",
            },
            OptInProcessDescription = "opt_in_process_description",
            OptInScreenshotUrl = "opt_in_screenshot_url",
            PrivacyPolicyUrl = "privacy_policy_url",
            SampleMessages = ["string"],
            StartMessage = "start_message",
            StopMessage = "stop_message",
            TermsAndConditionsUrl = "terms_and_conditions_url",
            WebsiteUrl = "website_url",
        };
        SenderProfileSms expectedSms = new()
        {
            Country = "x",
            AreaCodes = ["string"],
            NumberType = "number_type",
            Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
            SenderValue = "sender_value",
        };
        SenderProfileWhatsapp expectedWhatsapp = new()
        {
            PhoneNumberID = "phone_number_id",
            WabaID = "waba_id",
        };

        Assert.Equal(expectedRcs, deserialized.Rcs);
        Assert.Equal(expectedSms, deserialized.Sms);
        Assert.Equal(expectedWhatsapp, deserialized.Whatsapp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SenderProfileChannels
        {
            Rcs = new()
            {
                Description = "description",
                AgentUseCase = "agent_use_case",
                BannerUrl = "banner_url",
                BillingCategory = "billing_category",
                BrandColor = "brand_color",
                BrandEmail = "brand_email",
                BrandName = "brand_name",
                BrandPhoneNumber = "brand_phone_number",
                BriefCompanyDescription = "brief_company_description",
                CompanyEin = "company_ein",
                ContactNameAndTitle = "contact_name_and_title",
                CustomerSupportEmail = "customer_support_email",
                CustomerSupportPhoneNumber = "customer_support_phone_number",
                DisplayName = "display_name",
                EntityType = "entity_type",
                HelpMessage = "help_message",
                HostingRegion = "hosting_region",
                LogoUrl = "logo_url",
                OfficialAddress = new()
                {
                    City = "city",
                    Country = "country",
                    PostalCode = "postal_code",
                    State = "state",
                    Street = "street",
                },
                OptInProcessDescription = "opt_in_process_description",
                OptInScreenshotUrl = "opt_in_screenshot_url",
                PrivacyPolicyUrl = "privacy_policy_url",
                SampleMessages = ["string"],
                StartMessage = "start_message",
                StopMessage = "stop_message",
                TermsAndConditionsUrl = "terms_and_conditions_url",
                WebsiteUrl = "website_url",
            },
            Sms = new()
            {
                Country = "x",
                AreaCodes = ["string"],
                NumberType = "number_type",
                Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
                SenderValue = "sender_value",
            },
            Whatsapp = new() { PhoneNumberID = "phone_number_id", WabaID = "waba_id" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SenderProfileChannels { };

        Assert.Null(model.Rcs);
        Assert.False(model.RawData.ContainsKey("rcs"));
        Assert.Null(model.Sms);
        Assert.False(model.RawData.ContainsKey("sms"));
        Assert.Null(model.Whatsapp);
        Assert.False(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SenderProfileChannels { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SenderProfileChannels
        {
            Rcs = null,
            Sms = null,
            Whatsapp = null,
        };

        Assert.Null(model.Rcs);
        Assert.True(model.RawData.ContainsKey("rcs"));
        Assert.Null(model.Sms);
        Assert.True(model.RawData.ContainsKey("sms"));
        Assert.Null(model.Whatsapp);
        Assert.True(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SenderProfileChannels
        {
            Rcs = null,
            Sms = null,
            Whatsapp = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SenderProfileChannels
        {
            Rcs = new()
            {
                Description = "description",
                AgentUseCase = "agent_use_case",
                BannerUrl = "banner_url",
                BillingCategory = "billing_category",
                BrandColor = "brand_color",
                BrandEmail = "brand_email",
                BrandName = "brand_name",
                BrandPhoneNumber = "brand_phone_number",
                BriefCompanyDescription = "brief_company_description",
                CompanyEin = "company_ein",
                ContactNameAndTitle = "contact_name_and_title",
                CustomerSupportEmail = "customer_support_email",
                CustomerSupportPhoneNumber = "customer_support_phone_number",
                DisplayName = "display_name",
                EntityType = "entity_type",
                HelpMessage = "help_message",
                HostingRegion = "hosting_region",
                LogoUrl = "logo_url",
                OfficialAddress = new()
                {
                    City = "city",
                    Country = "country",
                    PostalCode = "postal_code",
                    State = "state",
                    Street = "street",
                },
                OptInProcessDescription = "opt_in_process_description",
                OptInScreenshotUrl = "opt_in_screenshot_url",
                PrivacyPolicyUrl = "privacy_policy_url",
                SampleMessages = ["string"],
                StartMessage = "start_message",
                StopMessage = "stop_message",
                TermsAndConditionsUrl = "terms_and_conditions_url",
                WebsiteUrl = "website_url",
            },
            Sms = new()
            {
                Country = "x",
                AreaCodes = ["string"],
                NumberType = "number_type",
                Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
                SenderValue = "sender_value",
            },
            Whatsapp = new() { PhoneNumberID = "phone_number_id", WabaID = "waba_id" },
        };

        SenderProfileChannels copied = new(model);

        Assert.Equal(model, copied);
    }
}
