using System;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Models.Channels.Sms;
using Sentdm.Models.SenderProfiles;

namespace Sentdm.Tests.Models.SenderProfiles;

public class SenderProfileCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SenderProfileCreateParams
        {
            Billing = new() { Inherit = true },
            Channels = new()
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
                    Country = "US",
                    AreaCodes = ["string"],
                    NumberType = "TEN_DLC",
                    Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
                    SenderValue = "sender_value",
                },
                Whatsapp = new() { PhoneNumberID = "phone_number_id", WabaID = "waba_id" },
            },
            Compliance = new()
            {
                Brand = new()
                {
                    BusinessName = "business_name",
                    City = "city",
                    ContactEmail = "dev@stainless.com",
                    ContactName = "contact_name",
                    ContactPhone = "contact_phone",
                    Country = "country",
                    EinIssuingCountry = "ein_issuing_country",
                    EntityType = EntityType.PrivateProfit,
                    Inherit = true,
                    LegalName = "legal_name",
                    PostalCode = "postal_code",
                    State = "state",
                    Street = "street",
                    TaxID = "tax_id",
                    TaxIDType = "tax_id_type",
                    Website = "website",
                },
                Campaign = new()
                {
                    Description = "description",
                    HelpKeywords = "help_keywords",
                    HelpMessage = "help_message",
                    Inherit = true,
                    MessageFlow = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    OptInKeywords = "opt_in_keywords",
                    OptInMessage = "opt_in_message",
                    OptOutKeywords = "opt_out_keywords",
                    OptOutMessage = "opt_out_message",
                    PrivacyPolicyLink = "privacy_policy_link",
                    TermsAndConditionsLink = "terms_and_conditions_link",
                    UseCases =
                    [
                        new()
                        {
                            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
                            UseCaseValue = UseCaseUseCase.Marketing,
                        },
                    ],
                    Volume = "volume",
                },
            },
            Description = null,
            Name = "Example Retail",
            Notifications = null,
            Sandbox = false,
            ShortName = "Example",
            IdempotencyKey = "req_abc123_retry1",
        };

        SenderProfileBillingRequest expectedBilling = new() { Inherit = true };
        SenderProfileChannels expectedChannels = new()
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
                Country = "US",
                AreaCodes = ["string"],
                NumberType = "TEN_DLC",
                Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
                SenderValue = "sender_value",
            },
            Whatsapp = new() { PhoneNumberID = "phone_number_id", WabaID = "waba_id" },
        };
        MarketCompliance expectedCompliance = new()
        {
            Brand = new()
            {
                BusinessName = "business_name",
                City = "city",
                ContactEmail = "dev@stainless.com",
                ContactName = "contact_name",
                ContactPhone = "contact_phone",
                Country = "country",
                EinIssuingCountry = "ein_issuing_country",
                EntityType = EntityType.PrivateProfit,
                Inherit = true,
                LegalName = "legal_name",
                PostalCode = "postal_code",
                State = "state",
                Street = "street",
                TaxID = "tax_id",
                TaxIDType = "tax_id_type",
                Website = "website",
            },
            Campaign = new()
            {
                Description = "description",
                HelpKeywords = "help_keywords",
                HelpMessage = "help_message",
                Inherit = true,
                MessageFlow = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                OptInKeywords = "opt_in_keywords",
                OptInMessage = "opt_in_message",
                OptOutKeywords = "opt_out_keywords",
                OptOutMessage = "opt_out_message",
                PrivacyPolicyLink = "privacy_policy_link",
                TermsAndConditionsLink = "terms_and_conditions_link",
                UseCases =
                [
                    new()
                    {
                        SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
                        UseCaseValue = UseCaseUseCase.Marketing,
                    },
                ],
                Volume = "volume",
            },
        };
        string expectedName = "Example Retail";
        bool expectedSandbox = false;
        string expectedShortName = "Example";
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedBilling, parameters.Billing);
        Assert.Equal(expectedChannels, parameters.Channels);
        Assert.Equal(expectedCompliance, parameters.Compliance);
        Assert.Null(parameters.Description);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Null(parameters.Notifications);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedShortName, parameters.ShortName);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SenderProfileCreateParams
        {
            Billing = new() { Inherit = true },
            Channels = new()
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
                    Country = "US",
                    AreaCodes = ["string"],
                    NumberType = "TEN_DLC",
                    Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
                    SenderValue = "sender_value",
                },
                Whatsapp = new() { PhoneNumberID = "phone_number_id", WabaID = "waba_id" },
            },
            Description = null,
            Notifications = null,
        };

        Assert.Null(parameters.Compliance);
        Assert.False(parameters.RawBodyData.ContainsKey("compliance"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.ShortName);
        Assert.False(parameters.RawBodyData.ContainsKey("short_name"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SenderProfileCreateParams
        {
            Billing = new() { Inherit = true },
            Channels = new()
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
                    Country = "US",
                    AreaCodes = ["string"],
                    NumberType = "TEN_DLC",
                    Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
                    SenderValue = "sender_value",
                },
                Whatsapp = new() { PhoneNumberID = "phone_number_id", WabaID = "waba_id" },
            },
            Description = null,
            Notifications = null,

            // Null should be interpreted as omitted for these properties
            Compliance = null,
            Name = null,
            Sandbox = null,
            ShortName = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.Compliance);
        Assert.False(parameters.RawBodyData.ContainsKey("compliance"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.ShortName);
        Assert.False(parameters.RawBodyData.ContainsKey("short_name"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SenderProfileCreateParams
        {
            Compliance = new()
            {
                Brand = new()
                {
                    BusinessName = "business_name",
                    City = "city",
                    ContactEmail = "dev@stainless.com",
                    ContactName = "contact_name",
                    ContactPhone = "contact_phone",
                    Country = "country",
                    EinIssuingCountry = "ein_issuing_country",
                    EntityType = EntityType.PrivateProfit,
                    Inherit = true,
                    LegalName = "legal_name",
                    PostalCode = "postal_code",
                    State = "state",
                    Street = "street",
                    TaxID = "tax_id",
                    TaxIDType = "tax_id_type",
                    Website = "website",
                },
                Campaign = new()
                {
                    Description = "description",
                    HelpKeywords = "help_keywords",
                    HelpMessage = "help_message",
                    Inherit = true,
                    MessageFlow = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    OptInKeywords = "opt_in_keywords",
                    OptInMessage = "opt_in_message",
                    OptOutKeywords = "opt_out_keywords",
                    OptOutMessage = "opt_out_message",
                    PrivacyPolicyLink = "privacy_policy_link",
                    TermsAndConditionsLink = "terms_and_conditions_link",
                    UseCases =
                    [
                        new()
                        {
                            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
                            UseCaseValue = UseCaseUseCase.Marketing,
                        },
                    ],
                    Volume = "volume",
                },
            },
            Name = "Example Retail",
            Sandbox = false,
            ShortName = "Example",
            IdempotencyKey = "req_abc123_retry1",
        };

        Assert.Null(parameters.Billing);
        Assert.False(parameters.RawBodyData.ContainsKey("billing"));
        Assert.Null(parameters.Channels);
        Assert.False(parameters.RawBodyData.ContainsKey("channels"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Notifications);
        Assert.False(parameters.RawBodyData.ContainsKey("notifications"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SenderProfileCreateParams
        {
            Compliance = new()
            {
                Brand = new()
                {
                    BusinessName = "business_name",
                    City = "city",
                    ContactEmail = "dev@stainless.com",
                    ContactName = "contact_name",
                    ContactPhone = "contact_phone",
                    Country = "country",
                    EinIssuingCountry = "ein_issuing_country",
                    EntityType = EntityType.PrivateProfit,
                    Inherit = true,
                    LegalName = "legal_name",
                    PostalCode = "postal_code",
                    State = "state",
                    Street = "street",
                    TaxID = "tax_id",
                    TaxIDType = "tax_id_type",
                    Website = "website",
                },
                Campaign = new()
                {
                    Description = "description",
                    HelpKeywords = "help_keywords",
                    HelpMessage = "help_message",
                    Inherit = true,
                    MessageFlow = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    OptInKeywords = "opt_in_keywords",
                    OptInMessage = "opt_in_message",
                    OptOutKeywords = "opt_out_keywords",
                    OptOutMessage = "opt_out_message",
                    PrivacyPolicyLink = "privacy_policy_link",
                    TermsAndConditionsLink = "terms_and_conditions_link",
                    UseCases =
                    [
                        new()
                        {
                            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
                            UseCaseValue = UseCaseUseCase.Marketing,
                        },
                    ],
                    Volume = "volume",
                },
            },
            Name = "Example Retail",
            Sandbox = false,
            ShortName = "Example",
            IdempotencyKey = "req_abc123_retry1",

            Billing = null,
            Channels = null,
            Description = null,
            Notifications = null,
        };

        Assert.Null(parameters.Billing);
        Assert.True(parameters.RawBodyData.ContainsKey("billing"));
        Assert.Null(parameters.Channels);
        Assert.True(parameters.RawBodyData.ContainsKey("channels"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Notifications);
        Assert.True(parameters.RawBodyData.ContainsKey("notifications"));
    }

    [Fact]
    public void Url_Works()
    {
        SenderProfileCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.sent.dm/v3/sender-profiles"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SenderProfileCreateParams parameters = new() { IdempotencyKey = "req_abc123_retry1" };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SenderProfileCreateParams
        {
            Billing = new() { Inherit = true },
            Channels = new()
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
                    Country = "US",
                    AreaCodes = ["string"],
                    NumberType = "TEN_DLC",
                    Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
                    SenderValue = "sender_value",
                },
                Whatsapp = new() { PhoneNumberID = "phone_number_id", WabaID = "waba_id" },
            },
            Compliance = new()
            {
                Brand = new()
                {
                    BusinessName = "business_name",
                    City = "city",
                    ContactEmail = "dev@stainless.com",
                    ContactName = "contact_name",
                    ContactPhone = "contact_phone",
                    Country = "country",
                    EinIssuingCountry = "ein_issuing_country",
                    EntityType = EntityType.PrivateProfit,
                    Inherit = true,
                    LegalName = "legal_name",
                    PostalCode = "postal_code",
                    State = "state",
                    Street = "street",
                    TaxID = "tax_id",
                    TaxIDType = "tax_id_type",
                    Website = "website",
                },
                Campaign = new()
                {
                    Description = "description",
                    HelpKeywords = "help_keywords",
                    HelpMessage = "help_message",
                    Inherit = true,
                    MessageFlow = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    OptInKeywords = "opt_in_keywords",
                    OptInMessage = "opt_in_message",
                    OptOutKeywords = "opt_out_keywords",
                    OptOutMessage = "opt_out_message",
                    PrivacyPolicyLink = "privacy_policy_link",
                    TermsAndConditionsLink = "terms_and_conditions_link",
                    UseCases =
                    [
                        new()
                        {
                            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
                            UseCaseValue = UseCaseUseCase.Marketing,
                        },
                    ],
                    Volume = "volume",
                },
            },
            Description = null,
            Name = "Example Retail",
            Notifications = null,
            Sandbox = false,
            ShortName = "Example",
            IdempotencyKey = "req_abc123_retry1",
        };

        SenderProfileCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
