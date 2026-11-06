using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Channels.Rcs;

namespace Sentdm.Tests.Models.Channels.Rcs;

public class RcCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RcCreateParams
        {
            AgentUseCase = AgentUseCase.Notifications,
            BannerUrl = "https://example.com/assets/banner-1440x448.png",
            BrandColor = "#1a73e8",
            BrandEmail = "hello@example.com",
            BrandName = "Example Retail",
            BrandPhoneNumber = "+12125550100",
            BriefCompanyDescription =
                "Example Retail sells home goods across the US and ships to 48 states.",
            CompanyEin = "12-3456789",
            ContactNameAndTitle = "Jane Smith, Head of Marketing",
            CustomerSupportEmail = "support@example.com",
            CustomerSupportPhoneNumber = "+18005550100",
            Description = "Order and delivery notifications for Example Retail customers.",
            DisplayName = "Example Retail",
            EntityType = "PRIVATE_PROFIT",
            HelpMessage = "For help, visit https://example.com/support or call 1-800-555-0100.",
            LogoUrl = "https://example.com/assets/logo-224x224.png",
            OfficialAddress = new()
            {
                City = "New York",
                Country = "US",
                PostalCode = "10001",
                State = "NY",
                Street = "123 Main St",
            },
            OptInProcessDescription =
                "Customers opt in at checkout by checking the SMS/RCS notifications box.",
            OptInScreenshotUrl = null,
            PrivacyPolicyUrl = "https://example.com/privacy",
            SampleMessages = ["Your order #12345 has shipped and will arrive tomorrow."],
            Sandbox = false,
            StartMessage = "Welcome to Example Retail! Reply HELP for help or STOP to opt out.",
            StopMessage = "You have been unsubscribed from Example Retail notifications.",
            TermsAndConditionsUrl = "https://example.com/terms",
            WebsiteUrl = "https://example.com",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ApiEnum<string, AgentUseCase> expectedAgentUseCase = AgentUseCase.Notifications;
        string expectedBannerUrl = "https://example.com/assets/banner-1440x448.png";
        string expectedBrandColor = "#1a73e8";
        string expectedBrandEmail = "hello@example.com";
        string expectedBrandName = "Example Retail";
        string expectedBrandPhoneNumber = "+12125550100";
        string expectedBriefCompanyDescription =
            "Example Retail sells home goods across the US and ships to 48 states.";
        string expectedCompanyEin = "12-3456789";
        string expectedContactNameAndTitle = "Jane Smith, Head of Marketing";
        string expectedCustomerSupportEmail = "support@example.com";
        string expectedCustomerSupportPhoneNumber = "+18005550100";
        string expectedDescription =
            "Order and delivery notifications for Example Retail customers.";
        string expectedDisplayName = "Example Retail";
        string expectedEntityType = "PRIVATE_PROFIT";
        string expectedHelpMessage =
            "For help, visit https://example.com/support or call 1-800-555-0100.";
        string expectedLogoUrl = "https://example.com/assets/logo-224x224.png";
        RcsAddress expectedOfficialAddress = new()
        {
            City = "New York",
            Country = "US",
            PostalCode = "10001",
            State = "NY",
            Street = "123 Main St",
        };
        string expectedOptInProcessDescription =
            "Customers opt in at checkout by checking the SMS/RCS notifications box.";
        string expectedPrivacyPolicyUrl = "https://example.com/privacy";
        List<string> expectedSampleMessages =
        [
            "Your order #12345 has shipped and will arrive tomorrow.",
        ];
        bool expectedSandbox = false;
        string expectedStartMessage =
            "Welcome to Example Retail! Reply HELP for help or STOP to opt out.";
        string expectedStopMessage =
            "You have been unsubscribed from Example Retail notifications.";
        string expectedTermsAndConditionsUrl = "https://example.com/terms";
        string expectedWebsiteUrl = "https://example.com";
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedAgentUseCase, parameters.AgentUseCase);
        Assert.Equal(expectedBannerUrl, parameters.BannerUrl);
        Assert.Equal(expectedBrandColor, parameters.BrandColor);
        Assert.Equal(expectedBrandEmail, parameters.BrandEmail);
        Assert.Equal(expectedBrandName, parameters.BrandName);
        Assert.Equal(expectedBrandPhoneNumber, parameters.BrandPhoneNumber);
        Assert.Equal(expectedBriefCompanyDescription, parameters.BriefCompanyDescription);
        Assert.Equal(expectedCompanyEin, parameters.CompanyEin);
        Assert.Equal(expectedContactNameAndTitle, parameters.ContactNameAndTitle);
        Assert.Equal(expectedCustomerSupportEmail, parameters.CustomerSupportEmail);
        Assert.Equal(expectedCustomerSupportPhoneNumber, parameters.CustomerSupportPhoneNumber);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedEntityType, parameters.EntityType);
        Assert.Equal(expectedHelpMessage, parameters.HelpMessage);
        Assert.Equal(expectedLogoUrl, parameters.LogoUrl);
        Assert.Equal(expectedOfficialAddress, parameters.OfficialAddress);
        Assert.Equal(expectedOptInProcessDescription, parameters.OptInProcessDescription);
        Assert.Null(parameters.OptInScreenshotUrl);
        Assert.Equal(expectedPrivacyPolicyUrl, parameters.PrivacyPolicyUrl);
        Assert.NotNull(parameters.SampleMessages);
        Assert.Equal(expectedSampleMessages.Count, parameters.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], parameters.SampleMessages[i]);
        }
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedStartMessage, parameters.StartMessage);
        Assert.Equal(expectedStopMessage, parameters.StopMessage);
        Assert.Equal(expectedTermsAndConditionsUrl, parameters.TermsAndConditionsUrl);
        Assert.Equal(expectedWebsiteUrl, parameters.WebsiteUrl);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RcCreateParams { OptInScreenshotUrl = null };

        Assert.Null(parameters.AgentUseCase);
        Assert.False(parameters.RawBodyData.ContainsKey("agent_use_case"));
        Assert.Null(parameters.BannerUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("banner_url"));
        Assert.Null(parameters.BrandColor);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_color"));
        Assert.Null(parameters.BrandEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_email"));
        Assert.Null(parameters.BrandName);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_name"));
        Assert.Null(parameters.BrandPhoneNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_phone_number"));
        Assert.Null(parameters.BriefCompanyDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("brief_company_description"));
        Assert.Null(parameters.CompanyEin);
        Assert.False(parameters.RawBodyData.ContainsKey("company_ein"));
        Assert.Null(parameters.ContactNameAndTitle);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_name_and_title"));
        Assert.Null(parameters.CustomerSupportEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_support_email"));
        Assert.Null(parameters.CustomerSupportPhoneNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_support_phone_number"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.EntityType);
        Assert.False(parameters.RawBodyData.ContainsKey("entity_type"));
        Assert.Null(parameters.HelpMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("help_message"));
        Assert.Null(parameters.LogoUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("logo_url"));
        Assert.Null(parameters.OfficialAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("official_address"));
        Assert.Null(parameters.OptInProcessDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("opt_in_process_description"));
        Assert.Null(parameters.PrivacyPolicyUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("privacy_policy_url"));
        Assert.Null(parameters.SampleMessages);
        Assert.False(parameters.RawBodyData.ContainsKey("sample_messages"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.StartMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("start_message"));
        Assert.Null(parameters.StopMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("stop_message"));
        Assert.Null(parameters.TermsAndConditionsUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("terms_and_conditions_url"));
        Assert.Null(parameters.WebsiteUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("website_url"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RcCreateParams
        {
            OptInScreenshotUrl = null,

            // Null should be interpreted as omitted for these properties
            AgentUseCase = null,
            BannerUrl = null,
            BrandColor = null,
            BrandEmail = null,
            BrandName = null,
            BrandPhoneNumber = null,
            BriefCompanyDescription = null,
            CompanyEin = null,
            ContactNameAndTitle = null,
            CustomerSupportEmail = null,
            CustomerSupportPhoneNumber = null,
            Description = null,
            DisplayName = null,
            EntityType = null,
            HelpMessage = null,
            LogoUrl = null,
            OfficialAddress = null,
            OptInProcessDescription = null,
            PrivacyPolicyUrl = null,
            SampleMessages = null,
            Sandbox = null,
            StartMessage = null,
            StopMessage = null,
            TermsAndConditionsUrl = null,
            WebsiteUrl = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.AgentUseCase);
        Assert.False(parameters.RawBodyData.ContainsKey("agent_use_case"));
        Assert.Null(parameters.BannerUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("banner_url"));
        Assert.Null(parameters.BrandColor);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_color"));
        Assert.Null(parameters.BrandEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_email"));
        Assert.Null(parameters.BrandName);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_name"));
        Assert.Null(parameters.BrandPhoneNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_phone_number"));
        Assert.Null(parameters.BriefCompanyDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("brief_company_description"));
        Assert.Null(parameters.CompanyEin);
        Assert.False(parameters.RawBodyData.ContainsKey("company_ein"));
        Assert.Null(parameters.ContactNameAndTitle);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_name_and_title"));
        Assert.Null(parameters.CustomerSupportEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_support_email"));
        Assert.Null(parameters.CustomerSupportPhoneNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_support_phone_number"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.EntityType);
        Assert.False(parameters.RawBodyData.ContainsKey("entity_type"));
        Assert.Null(parameters.HelpMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("help_message"));
        Assert.Null(parameters.LogoUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("logo_url"));
        Assert.Null(parameters.OfficialAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("official_address"));
        Assert.Null(parameters.OptInProcessDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("opt_in_process_description"));
        Assert.Null(parameters.PrivacyPolicyUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("privacy_policy_url"));
        Assert.Null(parameters.SampleMessages);
        Assert.False(parameters.RawBodyData.ContainsKey("sample_messages"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.StartMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("start_message"));
        Assert.Null(parameters.StopMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("stop_message"));
        Assert.Null(parameters.TermsAndConditionsUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("terms_and_conditions_url"));
        Assert.Null(parameters.WebsiteUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("website_url"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RcCreateParams
        {
            AgentUseCase = AgentUseCase.Notifications,
            BannerUrl = "https://example.com/assets/banner-1440x448.png",
            BrandColor = "#1a73e8",
            BrandEmail = "hello@example.com",
            BrandName = "Example Retail",
            BrandPhoneNumber = "+12125550100",
            BriefCompanyDescription =
                "Example Retail sells home goods across the US and ships to 48 states.",
            CompanyEin = "12-3456789",
            ContactNameAndTitle = "Jane Smith, Head of Marketing",
            CustomerSupportEmail = "support@example.com",
            CustomerSupportPhoneNumber = "+18005550100",
            Description = "Order and delivery notifications for Example Retail customers.",
            DisplayName = "Example Retail",
            EntityType = "PRIVATE_PROFIT",
            HelpMessage = "For help, visit https://example.com/support or call 1-800-555-0100.",
            LogoUrl = "https://example.com/assets/logo-224x224.png",
            OfficialAddress = new()
            {
                City = "New York",
                Country = "US",
                PostalCode = "10001",
                State = "NY",
                Street = "123 Main St",
            },
            OptInProcessDescription =
                "Customers opt in at checkout by checking the SMS/RCS notifications box.",
            PrivacyPolicyUrl = "https://example.com/privacy",
            SampleMessages = ["Your order #12345 has shipped and will arrive tomorrow."],
            Sandbox = false,
            StartMessage = "Welcome to Example Retail! Reply HELP for help or STOP to opt out.",
            StopMessage = "You have been unsubscribed from Example Retail notifications.",
            TermsAndConditionsUrl = "https://example.com/terms",
            WebsiteUrl = "https://example.com",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.OptInScreenshotUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("opt_in_screenshot_url"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RcCreateParams
        {
            AgentUseCase = AgentUseCase.Notifications,
            BannerUrl = "https://example.com/assets/banner-1440x448.png",
            BrandColor = "#1a73e8",
            BrandEmail = "hello@example.com",
            BrandName = "Example Retail",
            BrandPhoneNumber = "+12125550100",
            BriefCompanyDescription =
                "Example Retail sells home goods across the US and ships to 48 states.",
            CompanyEin = "12-3456789",
            ContactNameAndTitle = "Jane Smith, Head of Marketing",
            CustomerSupportEmail = "support@example.com",
            CustomerSupportPhoneNumber = "+18005550100",
            Description = "Order and delivery notifications for Example Retail customers.",
            DisplayName = "Example Retail",
            EntityType = "PRIVATE_PROFIT",
            HelpMessage = "For help, visit https://example.com/support or call 1-800-555-0100.",
            LogoUrl = "https://example.com/assets/logo-224x224.png",
            OfficialAddress = new()
            {
                City = "New York",
                Country = "US",
                PostalCode = "10001",
                State = "NY",
                Street = "123 Main St",
            },
            OptInProcessDescription =
                "Customers opt in at checkout by checking the SMS/RCS notifications box.",
            PrivacyPolicyUrl = "https://example.com/privacy",
            SampleMessages = ["Your order #12345 has shipped and will arrive tomorrow."],
            Sandbox = false,
            StartMessage = "Welcome to Example Retail! Reply HELP for help or STOP to opt out.",
            StopMessage = "You have been unsubscribed from Example Retail notifications.",
            TermsAndConditionsUrl = "https://example.com/terms",
            WebsiteUrl = "https://example.com",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            OptInScreenshotUrl = null,
        };

        Assert.Null(parameters.OptInScreenshotUrl);
        Assert.True(parameters.RawBodyData.ContainsKey("opt_in_screenshot_url"));
    }

    [Fact]
    public void Url_Works()
    {
        RcCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.sent.dm/v3/channels/rcs"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        RcCreateParams parameters = new()
        {
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
        Assert.Equal(
            ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            requestMessage.Headers.GetValues("x-profile-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RcCreateParams
        {
            AgentUseCase = AgentUseCase.Notifications,
            BannerUrl = "https://example.com/assets/banner-1440x448.png",
            BrandColor = "#1a73e8",
            BrandEmail = "hello@example.com",
            BrandName = "Example Retail",
            BrandPhoneNumber = "+12125550100",
            BriefCompanyDescription =
                "Example Retail sells home goods across the US and ships to 48 states.",
            CompanyEin = "12-3456789",
            ContactNameAndTitle = "Jane Smith, Head of Marketing",
            CustomerSupportEmail = "support@example.com",
            CustomerSupportPhoneNumber = "+18005550100",
            Description = "Order and delivery notifications for Example Retail customers.",
            DisplayName = "Example Retail",
            EntityType = "PRIVATE_PROFIT",
            HelpMessage = "For help, visit https://example.com/support or call 1-800-555-0100.",
            LogoUrl = "https://example.com/assets/logo-224x224.png",
            OfficialAddress = new()
            {
                City = "New York",
                Country = "US",
                PostalCode = "10001",
                State = "NY",
                Street = "123 Main St",
            },
            OptInProcessDescription =
                "Customers opt in at checkout by checking the SMS/RCS notifications box.",
            OptInScreenshotUrl = null,
            PrivacyPolicyUrl = "https://example.com/privacy",
            SampleMessages = ["Your order #12345 has shipped and will arrive tomorrow."],
            Sandbox = false,
            StartMessage = "Welcome to Example Retail! Reply HELP for help or STOP to opt out.",
            StopMessage = "You have been unsubscribed from Example Retail notifications.",
            TermsAndConditionsUrl = "https://example.com/terms",
            WebsiteUrl = "https://example.com",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        RcCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AgentUseCaseTest : TestBase
{
    [Theory]
    [InlineData(AgentUseCase.Verification)]
    [InlineData(AgentUseCase.Notifications)]
    [InlineData(AgentUseCase.Marketing)]
    [InlineData(AgentUseCase.MultiUse)]
    public void Validation_Works(AgentUseCase rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentUseCase> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgentUseCase>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AgentUseCase.Verification)]
    [InlineData(AgentUseCase.Notifications)]
    [InlineData(AgentUseCase.Marketing)]
    [InlineData(AgentUseCase.MultiUse)]
    public void SerializationRoundtrip_Works(AgentUseCase rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentUseCase> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AgentUseCase>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgentUseCase>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AgentUseCase>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
