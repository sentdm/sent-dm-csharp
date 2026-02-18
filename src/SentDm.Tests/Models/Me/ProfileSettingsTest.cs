using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Me;

namespace SentDm.Tests.Models.Me;

public class ProfileSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileSettings
        {
            AllowContactSharing = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
        };

        bool expectedAllowContactSharing = true;
        bool expectedAllowTemplateSharing = true;
        string expectedBillingModel = "billing_model";
        bool expectedInheritContacts = true;
        bool expectedInheritTcrBrand = true;
        bool expectedInheritTcrCampaign = true;
        bool expectedInheritTemplates = true;

        Assert.Equal(expectedAllowContactSharing, model.AllowContactSharing);
        Assert.Equal(expectedAllowTemplateSharing, model.AllowTemplateSharing);
        Assert.Equal(expectedBillingModel, model.BillingModel);
        Assert.Equal(expectedInheritContacts, model.InheritContacts);
        Assert.Equal(expectedInheritTcrBrand, model.InheritTcrBrand);
        Assert.Equal(expectedInheritTcrCampaign, model.InheritTcrCampaign);
        Assert.Equal(expectedInheritTemplates, model.InheritTemplates);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProfileSettings
        {
            AllowContactSharing = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileSettings>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfileSettings
        {
            AllowContactSharing = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileSettings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAllowContactSharing = true;
        bool expectedAllowTemplateSharing = true;
        string expectedBillingModel = "billing_model";
        bool expectedInheritContacts = true;
        bool expectedInheritTcrBrand = true;
        bool expectedInheritTcrCampaign = true;
        bool expectedInheritTemplates = true;

        Assert.Equal(expectedAllowContactSharing, deserialized.AllowContactSharing);
        Assert.Equal(expectedAllowTemplateSharing, deserialized.AllowTemplateSharing);
        Assert.Equal(expectedBillingModel, deserialized.BillingModel);
        Assert.Equal(expectedInheritContacts, deserialized.InheritContacts);
        Assert.Equal(expectedInheritTcrBrand, deserialized.InheritTcrBrand);
        Assert.Equal(expectedInheritTcrCampaign, deserialized.InheritTcrCampaign);
        Assert.Equal(expectedInheritTemplates, deserialized.InheritTemplates);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProfileSettings
        {
            AllowContactSharing = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProfileSettings { };

        Assert.Null(model.AllowContactSharing);
        Assert.False(model.RawData.ContainsKey("allow_contact_sharing"));
        Assert.Null(model.AllowTemplateSharing);
        Assert.False(model.RawData.ContainsKey("allow_template_sharing"));
        Assert.Null(model.BillingModel);
        Assert.False(model.RawData.ContainsKey("billing_model"));
        Assert.Null(model.InheritContacts);
        Assert.False(model.RawData.ContainsKey("inherit_contacts"));
        Assert.Null(model.InheritTcrBrand);
        Assert.False(model.RawData.ContainsKey("inherit_tcr_brand"));
        Assert.Null(model.InheritTcrCampaign);
        Assert.False(model.RawData.ContainsKey("inherit_tcr_campaign"));
        Assert.Null(model.InheritTemplates);
        Assert.False(model.RawData.ContainsKey("inherit_templates"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProfileSettings { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProfileSettings
        {
            AllowContactSharing = null,
            AllowTemplateSharing = null,
            BillingModel = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
        };

        Assert.Null(model.AllowContactSharing);
        Assert.True(model.RawData.ContainsKey("allow_contact_sharing"));
        Assert.Null(model.AllowTemplateSharing);
        Assert.True(model.RawData.ContainsKey("allow_template_sharing"));
        Assert.Null(model.BillingModel);
        Assert.True(model.RawData.ContainsKey("billing_model"));
        Assert.Null(model.InheritContacts);
        Assert.True(model.RawData.ContainsKey("inherit_contacts"));
        Assert.Null(model.InheritTcrBrand);
        Assert.True(model.RawData.ContainsKey("inherit_tcr_brand"));
        Assert.Null(model.InheritTcrCampaign);
        Assert.True(model.RawData.ContainsKey("inherit_tcr_campaign"));
        Assert.Null(model.InheritTemplates);
        Assert.True(model.RawData.ContainsKey("inherit_templates"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProfileSettings
        {
            AllowContactSharing = null,
            AllowTemplateSharing = null,
            BillingModel = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProfileSettings
        {
            AllowContactSharing = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
        };

        ProfileSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}
