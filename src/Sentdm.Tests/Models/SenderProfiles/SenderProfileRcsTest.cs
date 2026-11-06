using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Rcs;
using Sentdm.Models.SenderProfiles;

namespace Sentdm.Tests.Models.SenderProfiles;

public class SenderProfileRcsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SenderProfileRcs
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

        string expectedDescription = "description";
        string expectedAgentUseCase = "agent_use_case";
        string expectedBannerUrl = "banner_url";
        string expectedBillingCategory = "billing_category";
        string expectedBrandColor = "brand_color";
        string expectedBrandEmail = "brand_email";
        string expectedBrandName = "brand_name";
        string expectedBrandPhoneNumber = "brand_phone_number";
        string expectedBriefCompanyDescription = "brief_company_description";
        string expectedCompanyEin = "company_ein";
        string expectedContactNameAndTitle = "contact_name_and_title";
        string expectedCustomerSupportEmail = "customer_support_email";
        string expectedCustomerSupportPhoneNumber = "customer_support_phone_number";
        string expectedDisplayName = "display_name";
        string expectedEntityType = "entity_type";
        string expectedHelpMessage = "help_message";
        string expectedHostingRegion = "hosting_region";
        string expectedLogoUrl = "logo_url";
        RcsAddress expectedOfficialAddress = new()
        {
            City = "city",
            Country = "country",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
        };
        string expectedOptInProcessDescription = "opt_in_process_description";
        string expectedOptInScreenshotUrl = "opt_in_screenshot_url";
        string expectedPrivacyPolicyUrl = "privacy_policy_url";
        List<string> expectedSampleMessages = ["string"];
        string expectedStartMessage = "start_message";
        string expectedStopMessage = "stop_message";
        string expectedTermsAndConditionsUrl = "terms_and_conditions_url";
        string expectedWebsiteUrl = "website_url";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedAgentUseCase, model.AgentUseCase);
        Assert.Equal(expectedBannerUrl, model.BannerUrl);
        Assert.Equal(expectedBillingCategory, model.BillingCategory);
        Assert.Equal(expectedBrandColor, model.BrandColor);
        Assert.Equal(expectedBrandEmail, model.BrandEmail);
        Assert.Equal(expectedBrandName, model.BrandName);
        Assert.Equal(expectedBrandPhoneNumber, model.BrandPhoneNumber);
        Assert.Equal(expectedBriefCompanyDescription, model.BriefCompanyDescription);
        Assert.Equal(expectedCompanyEin, model.CompanyEin);
        Assert.Equal(expectedContactNameAndTitle, model.ContactNameAndTitle);
        Assert.Equal(expectedCustomerSupportEmail, model.CustomerSupportEmail);
        Assert.Equal(expectedCustomerSupportPhoneNumber, model.CustomerSupportPhoneNumber);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEntityType, model.EntityType);
        Assert.Equal(expectedHelpMessage, model.HelpMessage);
        Assert.Equal(expectedHostingRegion, model.HostingRegion);
        Assert.Equal(expectedLogoUrl, model.LogoUrl);
        Assert.Equal(expectedOfficialAddress, model.OfficialAddress);
        Assert.Equal(expectedOptInProcessDescription, model.OptInProcessDescription);
        Assert.Equal(expectedOptInScreenshotUrl, model.OptInScreenshotUrl);
        Assert.Equal(expectedPrivacyPolicyUrl, model.PrivacyPolicyUrl);
        Assert.NotNull(model.SampleMessages);
        Assert.Equal(expectedSampleMessages.Count, model.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], model.SampleMessages[i]);
        }
        Assert.Equal(expectedStartMessage, model.StartMessage);
        Assert.Equal(expectedStopMessage, model.StopMessage);
        Assert.Equal(expectedTermsAndConditionsUrl, model.TermsAndConditionsUrl);
        Assert.Equal(expectedWebsiteUrl, model.WebsiteUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SenderProfileRcs
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfileRcs>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SenderProfileRcs
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfileRcs>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedAgentUseCase = "agent_use_case";
        string expectedBannerUrl = "banner_url";
        string expectedBillingCategory = "billing_category";
        string expectedBrandColor = "brand_color";
        string expectedBrandEmail = "brand_email";
        string expectedBrandName = "brand_name";
        string expectedBrandPhoneNumber = "brand_phone_number";
        string expectedBriefCompanyDescription = "brief_company_description";
        string expectedCompanyEin = "company_ein";
        string expectedContactNameAndTitle = "contact_name_and_title";
        string expectedCustomerSupportEmail = "customer_support_email";
        string expectedCustomerSupportPhoneNumber = "customer_support_phone_number";
        string expectedDisplayName = "display_name";
        string expectedEntityType = "entity_type";
        string expectedHelpMessage = "help_message";
        string expectedHostingRegion = "hosting_region";
        string expectedLogoUrl = "logo_url";
        RcsAddress expectedOfficialAddress = new()
        {
            City = "city",
            Country = "country",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
        };
        string expectedOptInProcessDescription = "opt_in_process_description";
        string expectedOptInScreenshotUrl = "opt_in_screenshot_url";
        string expectedPrivacyPolicyUrl = "privacy_policy_url";
        List<string> expectedSampleMessages = ["string"];
        string expectedStartMessage = "start_message";
        string expectedStopMessage = "stop_message";
        string expectedTermsAndConditionsUrl = "terms_and_conditions_url";
        string expectedWebsiteUrl = "website_url";

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedAgentUseCase, deserialized.AgentUseCase);
        Assert.Equal(expectedBannerUrl, deserialized.BannerUrl);
        Assert.Equal(expectedBillingCategory, deserialized.BillingCategory);
        Assert.Equal(expectedBrandColor, deserialized.BrandColor);
        Assert.Equal(expectedBrandEmail, deserialized.BrandEmail);
        Assert.Equal(expectedBrandName, deserialized.BrandName);
        Assert.Equal(expectedBrandPhoneNumber, deserialized.BrandPhoneNumber);
        Assert.Equal(expectedBriefCompanyDescription, deserialized.BriefCompanyDescription);
        Assert.Equal(expectedCompanyEin, deserialized.CompanyEin);
        Assert.Equal(expectedContactNameAndTitle, deserialized.ContactNameAndTitle);
        Assert.Equal(expectedCustomerSupportEmail, deserialized.CustomerSupportEmail);
        Assert.Equal(expectedCustomerSupportPhoneNumber, deserialized.CustomerSupportPhoneNumber);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEntityType, deserialized.EntityType);
        Assert.Equal(expectedHelpMessage, deserialized.HelpMessage);
        Assert.Equal(expectedHostingRegion, deserialized.HostingRegion);
        Assert.Equal(expectedLogoUrl, deserialized.LogoUrl);
        Assert.Equal(expectedOfficialAddress, deserialized.OfficialAddress);
        Assert.Equal(expectedOptInProcessDescription, deserialized.OptInProcessDescription);
        Assert.Equal(expectedOptInScreenshotUrl, deserialized.OptInScreenshotUrl);
        Assert.Equal(expectedPrivacyPolicyUrl, deserialized.PrivacyPolicyUrl);
        Assert.NotNull(deserialized.SampleMessages);
        Assert.Equal(expectedSampleMessages.Count, deserialized.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], deserialized.SampleMessages[i]);
        }
        Assert.Equal(expectedStartMessage, deserialized.StartMessage);
        Assert.Equal(expectedStopMessage, deserialized.StopMessage);
        Assert.Equal(expectedTermsAndConditionsUrl, deserialized.TermsAndConditionsUrl);
        Assert.Equal(expectedWebsiteUrl, deserialized.WebsiteUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SenderProfileRcs
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SenderProfileRcs { Description = "description" };

        Assert.Null(model.AgentUseCase);
        Assert.False(model.RawData.ContainsKey("agent_use_case"));
        Assert.Null(model.BannerUrl);
        Assert.False(model.RawData.ContainsKey("banner_url"));
        Assert.Null(model.BillingCategory);
        Assert.False(model.RawData.ContainsKey("billing_category"));
        Assert.Null(model.BrandColor);
        Assert.False(model.RawData.ContainsKey("brand_color"));
        Assert.Null(model.BrandEmail);
        Assert.False(model.RawData.ContainsKey("brand_email"));
        Assert.Null(model.BrandName);
        Assert.False(model.RawData.ContainsKey("brand_name"));
        Assert.Null(model.BrandPhoneNumber);
        Assert.False(model.RawData.ContainsKey("brand_phone_number"));
        Assert.Null(model.BriefCompanyDescription);
        Assert.False(model.RawData.ContainsKey("brief_company_description"));
        Assert.Null(model.CompanyEin);
        Assert.False(model.RawData.ContainsKey("company_ein"));
        Assert.Null(model.ContactNameAndTitle);
        Assert.False(model.RawData.ContainsKey("contact_name_and_title"));
        Assert.Null(model.CustomerSupportEmail);
        Assert.False(model.RawData.ContainsKey("customer_support_email"));
        Assert.Null(model.CustomerSupportPhoneNumber);
        Assert.False(model.RawData.ContainsKey("customer_support_phone_number"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.EntityType);
        Assert.False(model.RawData.ContainsKey("entity_type"));
        Assert.Null(model.HelpMessage);
        Assert.False(model.RawData.ContainsKey("help_message"));
        Assert.Null(model.HostingRegion);
        Assert.False(model.RawData.ContainsKey("hosting_region"));
        Assert.Null(model.LogoUrl);
        Assert.False(model.RawData.ContainsKey("logo_url"));
        Assert.Null(model.OfficialAddress);
        Assert.False(model.RawData.ContainsKey("official_address"));
        Assert.Null(model.OptInProcessDescription);
        Assert.False(model.RawData.ContainsKey("opt_in_process_description"));
        Assert.Null(model.OptInScreenshotUrl);
        Assert.False(model.RawData.ContainsKey("opt_in_screenshot_url"));
        Assert.Null(model.PrivacyPolicyUrl);
        Assert.False(model.RawData.ContainsKey("privacy_policy_url"));
        Assert.Null(model.SampleMessages);
        Assert.False(model.RawData.ContainsKey("sample_messages"));
        Assert.Null(model.StartMessage);
        Assert.False(model.RawData.ContainsKey("start_message"));
        Assert.Null(model.StopMessage);
        Assert.False(model.RawData.ContainsKey("stop_message"));
        Assert.Null(model.TermsAndConditionsUrl);
        Assert.False(model.RawData.ContainsKey("terms_and_conditions_url"));
        Assert.Null(model.WebsiteUrl);
        Assert.False(model.RawData.ContainsKey("website_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SenderProfileRcs { Description = "description" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SenderProfileRcs
        {
            Description = "description",

            AgentUseCase = null,
            BannerUrl = null,
            BillingCategory = null,
            BrandColor = null,
            BrandEmail = null,
            BrandName = null,
            BrandPhoneNumber = null,
            BriefCompanyDescription = null,
            CompanyEin = null,
            ContactNameAndTitle = null,
            CustomerSupportEmail = null,
            CustomerSupportPhoneNumber = null,
            DisplayName = null,
            EntityType = null,
            HelpMessage = null,
            HostingRegion = null,
            LogoUrl = null,
            OfficialAddress = null,
            OptInProcessDescription = null,
            OptInScreenshotUrl = null,
            PrivacyPolicyUrl = null,
            SampleMessages = null,
            StartMessage = null,
            StopMessage = null,
            TermsAndConditionsUrl = null,
            WebsiteUrl = null,
        };

        Assert.Null(model.AgentUseCase);
        Assert.True(model.RawData.ContainsKey("agent_use_case"));
        Assert.Null(model.BannerUrl);
        Assert.True(model.RawData.ContainsKey("banner_url"));
        Assert.Null(model.BillingCategory);
        Assert.True(model.RawData.ContainsKey("billing_category"));
        Assert.Null(model.BrandColor);
        Assert.True(model.RawData.ContainsKey("brand_color"));
        Assert.Null(model.BrandEmail);
        Assert.True(model.RawData.ContainsKey("brand_email"));
        Assert.Null(model.BrandName);
        Assert.True(model.RawData.ContainsKey("brand_name"));
        Assert.Null(model.BrandPhoneNumber);
        Assert.True(model.RawData.ContainsKey("brand_phone_number"));
        Assert.Null(model.BriefCompanyDescription);
        Assert.True(model.RawData.ContainsKey("brief_company_description"));
        Assert.Null(model.CompanyEin);
        Assert.True(model.RawData.ContainsKey("company_ein"));
        Assert.Null(model.ContactNameAndTitle);
        Assert.True(model.RawData.ContainsKey("contact_name_and_title"));
        Assert.Null(model.CustomerSupportEmail);
        Assert.True(model.RawData.ContainsKey("customer_support_email"));
        Assert.Null(model.CustomerSupportPhoneNumber);
        Assert.True(model.RawData.ContainsKey("customer_support_phone_number"));
        Assert.Null(model.DisplayName);
        Assert.True(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.EntityType);
        Assert.True(model.RawData.ContainsKey("entity_type"));
        Assert.Null(model.HelpMessage);
        Assert.True(model.RawData.ContainsKey("help_message"));
        Assert.Null(model.HostingRegion);
        Assert.True(model.RawData.ContainsKey("hosting_region"));
        Assert.Null(model.LogoUrl);
        Assert.True(model.RawData.ContainsKey("logo_url"));
        Assert.Null(model.OfficialAddress);
        Assert.True(model.RawData.ContainsKey("official_address"));
        Assert.Null(model.OptInProcessDescription);
        Assert.True(model.RawData.ContainsKey("opt_in_process_description"));
        Assert.Null(model.OptInScreenshotUrl);
        Assert.True(model.RawData.ContainsKey("opt_in_screenshot_url"));
        Assert.Null(model.PrivacyPolicyUrl);
        Assert.True(model.RawData.ContainsKey("privacy_policy_url"));
        Assert.Null(model.SampleMessages);
        Assert.True(model.RawData.ContainsKey("sample_messages"));
        Assert.Null(model.StartMessage);
        Assert.True(model.RawData.ContainsKey("start_message"));
        Assert.Null(model.StopMessage);
        Assert.True(model.RawData.ContainsKey("stop_message"));
        Assert.Null(model.TermsAndConditionsUrl);
        Assert.True(model.RawData.ContainsKey("terms_and_conditions_url"));
        Assert.Null(model.WebsiteUrl);
        Assert.True(model.RawData.ContainsKey("website_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SenderProfileRcs
        {
            Description = "description",

            AgentUseCase = null,
            BannerUrl = null,
            BillingCategory = null,
            BrandColor = null,
            BrandEmail = null,
            BrandName = null,
            BrandPhoneNumber = null,
            BriefCompanyDescription = null,
            CompanyEin = null,
            ContactNameAndTitle = null,
            CustomerSupportEmail = null,
            CustomerSupportPhoneNumber = null,
            DisplayName = null,
            EntityType = null,
            HelpMessage = null,
            HostingRegion = null,
            LogoUrl = null,
            OfficialAddress = null,
            OptInProcessDescription = null,
            OptInScreenshotUrl = null,
            PrivacyPolicyUrl = null,
            SampleMessages = null,
            StartMessage = null,
            StopMessage = null,
            TermsAndConditionsUrl = null,
            WebsiteUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SenderProfileRcs
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

        SenderProfileRcs copied = new(model);

        Assert.Equal(model, copied);
    }
}
