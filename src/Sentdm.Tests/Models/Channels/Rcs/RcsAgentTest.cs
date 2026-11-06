using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Channels.Rcs;

namespace Sentdm.Tests.Models.Channels.Rcs;

public class RcsAgentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RcsAgent
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

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAgentUseCase = "agent_use_case";
        string expectedBrandColor = "brand_color";
        string expectedBrandEmail = "brand_email";
        string expectedBrandName = "brand_name";
        string expectedBrandPhoneNumber = "brand_phone_number";
        string expectedBriefCompanyDescription = "brief_company_description";
        string expectedCompanyEin = "company_ein";
        string expectedContactNameAndTitle = "contact_name_and_title";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerSupportEmail = "customer_support_email";
        string expectedCustomerSupportPhoneNumber = "customer_support_phone_number";
        string expectedDescription = "description";
        string expectedDisplayName = "display_name";
        string expectedEntityType = "entity_type";
        string expectedHelpMessage = "help_message";
        RcsAddress expectedOfficialAddress = new()
        {
            City = "city",
            Country = "country",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
        };
        string expectedOptInProcessDescription = "opt_in_process_description";
        string expectedPhoneNumber = "phone_number";
        string expectedPrivacyPolicyUrl = "privacy_policy_url";
        string expectedReason = "reason";
        string expectedReasonCode = "reason_code";
        List<string> expectedSampleMessages = ["string"];
        string expectedStartMessage = "start_message";
        ApiEnum<string, Status> expectedStatus = Status.Provisioning;
        string expectedStopMessage = "stop_message";
        string expectedTermsAndConditionsUrl = "terms_and_conditions_url";
        string expectedWebsiteUrl = "website_url";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgentUseCase, model.AgentUseCase);
        Assert.Equal(expectedBrandColor, model.BrandColor);
        Assert.Equal(expectedBrandEmail, model.BrandEmail);
        Assert.Equal(expectedBrandName, model.BrandName);
        Assert.Equal(expectedBrandPhoneNumber, model.BrandPhoneNumber);
        Assert.Equal(expectedBriefCompanyDescription, model.BriefCompanyDescription);
        Assert.Equal(expectedCompanyEin, model.CompanyEin);
        Assert.Equal(expectedContactNameAndTitle, model.ContactNameAndTitle);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerSupportEmail, model.CustomerSupportEmail);
        Assert.Equal(expectedCustomerSupportPhoneNumber, model.CustomerSupportPhoneNumber);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEntityType, model.EntityType);
        Assert.Equal(expectedHelpMessage, model.HelpMessage);
        Assert.Equal(expectedOfficialAddress, model.OfficialAddress);
        Assert.Equal(expectedOptInProcessDescription, model.OptInProcessDescription);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedPrivacyPolicyUrl, model.PrivacyPolicyUrl);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReasonCode, model.ReasonCode);
        Assert.NotNull(model.SampleMessages);
        Assert.Equal(expectedSampleMessages.Count, model.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], model.SampleMessages[i]);
        }
        Assert.Equal(expectedStartMessage, model.StartMessage);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStopMessage, model.StopMessage);
        Assert.Equal(expectedTermsAndConditionsUrl, model.TermsAndConditionsUrl);
        Assert.Equal(expectedWebsiteUrl, model.WebsiteUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RcsAgent
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RcsAgent>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RcsAgent
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RcsAgent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAgentUseCase = "agent_use_case";
        string expectedBrandColor = "brand_color";
        string expectedBrandEmail = "brand_email";
        string expectedBrandName = "brand_name";
        string expectedBrandPhoneNumber = "brand_phone_number";
        string expectedBriefCompanyDescription = "brief_company_description";
        string expectedCompanyEin = "company_ein";
        string expectedContactNameAndTitle = "contact_name_and_title";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerSupportEmail = "customer_support_email";
        string expectedCustomerSupportPhoneNumber = "customer_support_phone_number";
        string expectedDescription = "description";
        string expectedDisplayName = "display_name";
        string expectedEntityType = "entity_type";
        string expectedHelpMessage = "help_message";
        RcsAddress expectedOfficialAddress = new()
        {
            City = "city",
            Country = "country",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
        };
        string expectedOptInProcessDescription = "opt_in_process_description";
        string expectedPhoneNumber = "phone_number";
        string expectedPrivacyPolicyUrl = "privacy_policy_url";
        string expectedReason = "reason";
        string expectedReasonCode = "reason_code";
        List<string> expectedSampleMessages = ["string"];
        string expectedStartMessage = "start_message";
        ApiEnum<string, Status> expectedStatus = Status.Provisioning;
        string expectedStopMessage = "stop_message";
        string expectedTermsAndConditionsUrl = "terms_and_conditions_url";
        string expectedWebsiteUrl = "website_url";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgentUseCase, deserialized.AgentUseCase);
        Assert.Equal(expectedBrandColor, deserialized.BrandColor);
        Assert.Equal(expectedBrandEmail, deserialized.BrandEmail);
        Assert.Equal(expectedBrandName, deserialized.BrandName);
        Assert.Equal(expectedBrandPhoneNumber, deserialized.BrandPhoneNumber);
        Assert.Equal(expectedBriefCompanyDescription, deserialized.BriefCompanyDescription);
        Assert.Equal(expectedCompanyEin, deserialized.CompanyEin);
        Assert.Equal(expectedContactNameAndTitle, deserialized.ContactNameAndTitle);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerSupportEmail, deserialized.CustomerSupportEmail);
        Assert.Equal(expectedCustomerSupportPhoneNumber, deserialized.CustomerSupportPhoneNumber);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEntityType, deserialized.EntityType);
        Assert.Equal(expectedHelpMessage, deserialized.HelpMessage);
        Assert.Equal(expectedOfficialAddress, deserialized.OfficialAddress);
        Assert.Equal(expectedOptInProcessDescription, deserialized.OptInProcessDescription);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedPrivacyPolicyUrl, deserialized.PrivacyPolicyUrl);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReasonCode, deserialized.ReasonCode);
        Assert.NotNull(deserialized.SampleMessages);
        Assert.Equal(expectedSampleMessages.Count, deserialized.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], deserialized.SampleMessages[i]);
        }
        Assert.Equal(expectedStartMessage, deserialized.StartMessage);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStopMessage, deserialized.StopMessage);
        Assert.Equal(expectedTermsAndConditionsUrl, deserialized.TermsAndConditionsUrl);
        Assert.Equal(expectedWebsiteUrl, deserialized.WebsiteUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RcsAgent
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RcsAgent { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AgentUseCase);
        Assert.False(model.RawData.ContainsKey("agent_use_case"));
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
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CustomerSupportEmail);
        Assert.False(model.RawData.ContainsKey("customer_support_email"));
        Assert.Null(model.CustomerSupportPhoneNumber);
        Assert.False(model.RawData.ContainsKey("customer_support_phone_number"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.EntityType);
        Assert.False(model.RawData.ContainsKey("entity_type"));
        Assert.Null(model.HelpMessage);
        Assert.False(model.RawData.ContainsKey("help_message"));
        Assert.Null(model.OfficialAddress);
        Assert.False(model.RawData.ContainsKey("official_address"));
        Assert.Null(model.OptInProcessDescription);
        Assert.False(model.RawData.ContainsKey("opt_in_process_description"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.PrivacyPolicyUrl);
        Assert.False(model.RawData.ContainsKey("privacy_policy_url"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.ReasonCode);
        Assert.False(model.RawData.ContainsKey("reason_code"));
        Assert.Null(model.SampleMessages);
        Assert.False(model.RawData.ContainsKey("sample_messages"));
        Assert.Null(model.StartMessage);
        Assert.False(model.RawData.ContainsKey("start_message"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
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
        var model = new RcsAgent { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RcsAgent
        {
            ID = null,
            AgentUseCase = null,
            BrandColor = null,
            BrandEmail = null,
            BrandName = null,
            BrandPhoneNumber = null,
            BriefCompanyDescription = null,
            CompanyEin = null,
            ContactNameAndTitle = null,
            CreatedAt = null,
            CustomerSupportEmail = null,
            CustomerSupportPhoneNumber = null,
            Description = null,
            DisplayName = null,
            EntityType = null,
            HelpMessage = null,
            OfficialAddress = null,
            OptInProcessDescription = null,
            PhoneNumber = null,
            PrivacyPolicyUrl = null,
            Reason = null,
            ReasonCode = null,
            SampleMessages = null,
            StartMessage = null,
            Status = null,
            StopMessage = null,
            TermsAndConditionsUrl = null,
            WebsiteUrl = null,
        };

        Assert.Null(model.ID);
        Assert.True(model.RawData.ContainsKey("id"));
        Assert.Null(model.AgentUseCase);
        Assert.True(model.RawData.ContainsKey("agent_use_case"));
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
        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CustomerSupportEmail);
        Assert.True(model.RawData.ContainsKey("customer_support_email"));
        Assert.Null(model.CustomerSupportPhoneNumber);
        Assert.True(model.RawData.ContainsKey("customer_support_phone_number"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayName);
        Assert.True(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.EntityType);
        Assert.True(model.RawData.ContainsKey("entity_type"));
        Assert.Null(model.HelpMessage);
        Assert.True(model.RawData.ContainsKey("help_message"));
        Assert.Null(model.OfficialAddress);
        Assert.True(model.RawData.ContainsKey("official_address"));
        Assert.Null(model.OptInProcessDescription);
        Assert.True(model.RawData.ContainsKey("opt_in_process_description"));
        Assert.Null(model.PhoneNumber);
        Assert.True(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.PrivacyPolicyUrl);
        Assert.True(model.RawData.ContainsKey("privacy_policy_url"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.ReasonCode);
        Assert.True(model.RawData.ContainsKey("reason_code"));
        Assert.Null(model.SampleMessages);
        Assert.True(model.RawData.ContainsKey("sample_messages"));
        Assert.Null(model.StartMessage);
        Assert.True(model.RawData.ContainsKey("start_message"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
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
        var model = new RcsAgent
        {
            ID = null,
            AgentUseCase = null,
            BrandColor = null,
            BrandEmail = null,
            BrandName = null,
            BrandPhoneNumber = null,
            BriefCompanyDescription = null,
            CompanyEin = null,
            ContactNameAndTitle = null,
            CreatedAt = null,
            CustomerSupportEmail = null,
            CustomerSupportPhoneNumber = null,
            Description = null,
            DisplayName = null,
            EntityType = null,
            HelpMessage = null,
            OfficialAddress = null,
            OptInProcessDescription = null,
            PhoneNumber = null,
            PrivacyPolicyUrl = null,
            Reason = null,
            ReasonCode = null,
            SampleMessages = null,
            StartMessage = null,
            Status = null,
            StopMessage = null,
            TermsAndConditionsUrl = null,
            WebsiteUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RcsAgent
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

        RcsAgent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Provisioning)]
    [InlineData(Status.ActionNeeded)]
    [InlineData(Status.PendingReview)]
    [InlineData(Status.Active)]
    [InlineData(Status.Inactive)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Provisioning)]
    [InlineData(Status.ActionNeeded)]
    [InlineData(Status.PendingReview)]
    [InlineData(Status.Active)]
    [InlineData(Status.Inactive)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
