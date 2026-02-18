using System;
using System.Net.Http;
using SentDm.Models.Profiles;

namespace SentDm.Tests.Models.Profiles;

public class ProfileUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            ProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = null,
            AllowTemplateSharing = null,
            BillingModel = "organization",
            Description = "Updated sales department sender profile",
            Icon = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
            Name = "Sales Team - Updated",
            ProfileIDValue = "770e8400-e29b-41d4-a716-446655440002",
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            SendingWhatsappNumberProfileID = null,
            ShortName = null,
            TestMode = false,
            WhatsappPhoneNumber = null,
            IdempotencyKey = "req_abc123_retry1",
        };

        string expectedProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedAllowContactSharing = true;
        string expectedBillingModel = "organization";
        string expectedDescription = "Updated sales department sender profile";
        string expectedName = "Sales Team - Updated";
        string expectedProfileIDValue = "770e8400-e29b-41d4-a716-446655440002";
        bool expectedTestMode = false;
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedProfileID, parameters.ProfileID);
        Assert.Equal(expectedAllowContactSharing, parameters.AllowContactSharing);
        Assert.Null(parameters.AllowNumberChangeDuringOnboarding);
        Assert.Null(parameters.AllowTemplateSharing);
        Assert.Equal(expectedBillingModel, parameters.BillingModel);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Null(parameters.Icon);
        Assert.Null(parameters.InheritContacts);
        Assert.Null(parameters.InheritTcrBrand);
        Assert.Null(parameters.InheritTcrCampaign);
        Assert.Null(parameters.InheritTemplates);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedProfileIDValue, parameters.ProfileIDValue);
        Assert.Null(parameters.SendingPhoneNumber);
        Assert.Null(parameters.SendingPhoneNumberProfileID);
        Assert.Null(parameters.SendingWhatsappNumberProfileID);
        Assert.Null(parameters.ShortName);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.Null(parameters.WhatsappPhoneNumber);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            ProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = null,
            AllowTemplateSharing = null,
            BillingModel = "organization",
            Description = "Updated sales department sender profile",
            Icon = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
            Name = "Sales Team - Updated",
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            SendingWhatsappNumberProfileID = null,
            ShortName = null,
            WhatsappPhoneNumber = null,
        };

        Assert.Null(parameters.ProfileIDValue);
        Assert.False(parameters.RawBodyData.ContainsKey("profile_id"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            ProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = null,
            AllowTemplateSharing = null,
            BillingModel = "organization",
            Description = "Updated sales department sender profile",
            Icon = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
            Name = "Sales Team - Updated",
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            SendingWhatsappNumberProfileID = null,
            ShortName = null,
            WhatsappPhoneNumber = null,

            // Null should be interpreted as omitted for these properties
            ProfileIDValue = null,
            TestMode = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.ProfileIDValue);
        Assert.False(parameters.RawBodyData.ContainsKey("profile_id"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            ProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProfileIDValue = "770e8400-e29b-41d4-a716-446655440002",
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        Assert.Null(parameters.AllowContactSharing);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_contact_sharing"));
        Assert.Null(parameters.AllowNumberChangeDuringOnboarding);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_number_change_during_onboarding"));
        Assert.Null(parameters.AllowTemplateSharing);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_template_sharing"));
        Assert.Null(parameters.BillingModel);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_model"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Icon);
        Assert.False(parameters.RawBodyData.ContainsKey("icon"));
        Assert.Null(parameters.InheritContacts);
        Assert.False(parameters.RawBodyData.ContainsKey("inherit_contacts"));
        Assert.Null(parameters.InheritTcrBrand);
        Assert.False(parameters.RawBodyData.ContainsKey("inherit_tcr_brand"));
        Assert.Null(parameters.InheritTcrCampaign);
        Assert.False(parameters.RawBodyData.ContainsKey("inherit_tcr_campaign"));
        Assert.Null(parameters.InheritTemplates);
        Assert.False(parameters.RawBodyData.ContainsKey("inherit_templates"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.SendingPhoneNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("sending_phone_number"));
        Assert.Null(parameters.SendingPhoneNumberProfileID);
        Assert.False(parameters.RawBodyData.ContainsKey("sending_phone_number_profile_id"));
        Assert.Null(parameters.SendingWhatsappNumberProfileID);
        Assert.False(parameters.RawBodyData.ContainsKey("sending_whatsapp_number_profile_id"));
        Assert.Null(parameters.ShortName);
        Assert.False(parameters.RawBodyData.ContainsKey("short_name"));
        Assert.Null(parameters.WhatsappPhoneNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("whatsapp_phone_number"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            ProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProfileIDValue = "770e8400-e29b-41d4-a716-446655440002",
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",

            AllowContactSharing = null,
            AllowNumberChangeDuringOnboarding = null,
            AllowTemplateSharing = null,
            BillingModel = null,
            Description = null,
            Icon = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
            Name = null,
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            SendingWhatsappNumberProfileID = null,
            ShortName = null,
            WhatsappPhoneNumber = null,
        };

        Assert.Null(parameters.AllowContactSharing);
        Assert.True(parameters.RawBodyData.ContainsKey("allow_contact_sharing"));
        Assert.Null(parameters.AllowNumberChangeDuringOnboarding);
        Assert.True(parameters.RawBodyData.ContainsKey("allow_number_change_during_onboarding"));
        Assert.Null(parameters.AllowTemplateSharing);
        Assert.True(parameters.RawBodyData.ContainsKey("allow_template_sharing"));
        Assert.Null(parameters.BillingModel);
        Assert.True(parameters.RawBodyData.ContainsKey("billing_model"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Icon);
        Assert.True(parameters.RawBodyData.ContainsKey("icon"));
        Assert.Null(parameters.InheritContacts);
        Assert.True(parameters.RawBodyData.ContainsKey("inherit_contacts"));
        Assert.Null(parameters.InheritTcrBrand);
        Assert.True(parameters.RawBodyData.ContainsKey("inherit_tcr_brand"));
        Assert.Null(parameters.InheritTcrCampaign);
        Assert.True(parameters.RawBodyData.ContainsKey("inherit_tcr_campaign"));
        Assert.Null(parameters.InheritTemplates);
        Assert.True(parameters.RawBodyData.ContainsKey("inherit_templates"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.SendingPhoneNumber);
        Assert.True(parameters.RawBodyData.ContainsKey("sending_phone_number"));
        Assert.Null(parameters.SendingPhoneNumberProfileID);
        Assert.True(parameters.RawBodyData.ContainsKey("sending_phone_number_profile_id"));
        Assert.Null(parameters.SendingWhatsappNumberProfileID);
        Assert.True(parameters.RawBodyData.ContainsKey("sending_whatsapp_number_profile_id"));
        Assert.Null(parameters.ShortName);
        Assert.True(parameters.RawBodyData.ContainsKey("short_name"));
        Assert.Null(parameters.WhatsappPhoneNumber);
        Assert.True(parameters.RawBodyData.ContainsKey("whatsapp_phone_number"));
    }

    [Fact]
    public void Url_Works()
    {
        ProfileUpdateParams parameters = new()
        {
            ProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/profiles/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ProfileUpdateParams parameters = new()
        {
            ProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            IdempotencyKey = "req_abc123_retry1",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            ProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = null,
            AllowTemplateSharing = null,
            BillingModel = "organization",
            Description = "Updated sales department sender profile",
            Icon = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
            Name = "Sales Team - Updated",
            ProfileIDValue = "770e8400-e29b-41d4-a716-446655440002",
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            SendingWhatsappNumberProfileID = null,
            ShortName = null,
            TestMode = false,
            WhatsappPhoneNumber = null,
            IdempotencyKey = "req_abc123_retry1",
        };

        ProfileUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
