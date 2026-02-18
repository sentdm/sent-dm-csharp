using System;
using System.Net.Http;
using SentDm.Models.Profiles;

namespace SentDm.Tests.Models.Profiles;

public class ProfileCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileCreateParams
        {
            AllowContactSharing = true,
            AllowTemplateSharing = false,
            BillingModel = "profile",
            Description = "Sales department sender profile",
            Icon = "https://example.com/sales-icon.png",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            Name = "Sales Team",
            ShortName = "SALES",
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        bool expectedAllowContactSharing = true;
        bool expectedAllowTemplateSharing = false;
        string expectedBillingModel = "profile";
        string expectedDescription = "Sales department sender profile";
        string expectedIcon = "https://example.com/sales-icon.png";
        bool expectedInheritContacts = true;
        bool expectedInheritTcrBrand = true;
        bool expectedInheritTcrCampaign = true;
        bool expectedInheritTemplates = true;
        string expectedName = "Sales Team";
        string expectedShortName = "SALES";
        bool expectedTestMode = false;
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedAllowContactSharing, parameters.AllowContactSharing);
        Assert.Equal(expectedAllowTemplateSharing, parameters.AllowTemplateSharing);
        Assert.Equal(expectedBillingModel, parameters.BillingModel);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedIcon, parameters.Icon);
        Assert.Equal(expectedInheritContacts, parameters.InheritContacts);
        Assert.Equal(expectedInheritTcrBrand, parameters.InheritTcrBrand);
        Assert.Equal(expectedInheritTcrCampaign, parameters.InheritTcrCampaign);
        Assert.Equal(expectedInheritTemplates, parameters.InheritTemplates);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedShortName, parameters.ShortName);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProfileCreateParams
        {
            BillingModel = "profile",
            Description = "Sales department sender profile",
            Icon = "https://example.com/sales-icon.png",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            ShortName = "SALES",
        };

        Assert.Null(parameters.AllowContactSharing);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_contact_sharing"));
        Assert.Null(parameters.AllowTemplateSharing);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_template_sharing"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProfileCreateParams
        {
            BillingModel = "profile",
            Description = "Sales department sender profile",
            Icon = "https://example.com/sales-icon.png",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            ShortName = "SALES",

            // Null should be interpreted as omitted for these properties
            AllowContactSharing = null,
            AllowTemplateSharing = null,
            Name = null,
            TestMode = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.AllowContactSharing);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_contact_sharing"));
        Assert.Null(parameters.AllowTemplateSharing);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_template_sharing"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProfileCreateParams
        {
            AllowContactSharing = true,
            AllowTemplateSharing = false,
            Name = "Sales Team",
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

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
        Assert.Null(parameters.ShortName);
        Assert.False(parameters.RawBodyData.ContainsKey("short_name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ProfileCreateParams
        {
            AllowContactSharing = true,
            AllowTemplateSharing = false,
            Name = "Sales Team",
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",

            BillingModel = null,
            Description = null,
            Icon = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
            ShortName = null,
        };

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
        Assert.Null(parameters.ShortName);
        Assert.True(parameters.RawBodyData.ContainsKey("short_name"));
    }

    [Fact]
    public void Url_Works()
    {
        ProfileCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.sent.dm/v3/profiles"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ProfileCreateParams parameters = new() { IdempotencyKey = "req_abc123_retry1" };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProfileCreateParams
        {
            AllowContactSharing = true,
            AllowTemplateSharing = false,
            BillingModel = "profile",
            Description = "Sales department sender profile",
            Icon = "https://example.com/sales-icon.png",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            Name = "Sales Team",
            ShortName = "SALES",
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        ProfileCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
