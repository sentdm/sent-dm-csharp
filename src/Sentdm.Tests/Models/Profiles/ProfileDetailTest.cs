using System;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class ProfileDetailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileDetail
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Email = "email",
            Icon = "icon",
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
            ShortName = "short_name",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedEmail = "email";
        string expectedIcon = "icon";
        string expectedName = "name";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Settings expectedSettings = new()
        {
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WhatsappPhoneNumber = "whatsapp_phone_number",
        };
        string expectedShortName = "short_name";
        string expectedStatus = "status";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedIcon, model.Icon);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.Equal(expectedSettings, model.Settings);
        Assert.Equal(expectedShortName, model.ShortName);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProfileDetail
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Email = "email",
            Icon = "icon",
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
            ShortName = "short_name",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileDetail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfileDetail
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Email = "email",
            Icon = "icon",
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
            ShortName = "short_name",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileDetail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedEmail = "email";
        string expectedIcon = "icon";
        string expectedName = "name";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Settings expectedSettings = new()
        {
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WhatsappPhoneNumber = "whatsapp_phone_number",
        };
        string expectedShortName = "short_name";
        string expectedStatus = "status";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedIcon, deserialized.Icon);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.Equal(expectedSettings, deserialized.Settings);
        Assert.Equal(expectedShortName, deserialized.ShortName);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProfileDetail
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Email = "email",
            Icon = "icon",
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
            ShortName = "short_name",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProfileDetail
        {
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ShortName = "short_name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Settings);
        Assert.False(model.RawData.ContainsKey("settings"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProfileDetail
        {
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ShortName = "short_name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ProfileDetail
        {
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ShortName = "short_name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Name = null,
            Settings = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Settings);
        Assert.False(model.RawData.ContainsKey("settings"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProfileDetail
        {
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ShortName = "short_name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Name = null,
            Settings = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProfileDetail
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
            Status = "status",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Icon);
        Assert.False(model.RawData.ContainsKey("icon"));
        Assert.Null(model.OrganizationID);
        Assert.False(model.RawData.ContainsKey("organization_id"));
        Assert.Null(model.ShortName);
        Assert.False(model.RawData.ContainsKey("short_name"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProfileDetail
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProfileDetail
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
            Status = "status",

            Description = null,
            Email = null,
            Icon = null,
            OrganizationID = null,
            ShortName = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.Icon);
        Assert.True(model.RawData.ContainsKey("icon"));
        Assert.Null(model.OrganizationID);
        Assert.True(model.RawData.ContainsKey("organization_id"));
        Assert.Null(model.ShortName);
        Assert.True(model.RawData.ContainsKey("short_name"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProfileDetail
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
            Status = "status",

            Description = null,
            Email = null,
            Icon = null,
            OrganizationID = null,
            ShortName = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProfileDetail
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Email = "email",
            Icon = "icon",
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
            ShortName = "short_name",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ProfileDetail copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Settings
        {
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WhatsappPhoneNumber = "whatsapp_phone_number",
        };

        bool expectedAllowContactSharing = true;
        bool expectedAllowNumberChangeDuringOnboarding = true;
        bool expectedAllowTemplateSharing = true;
        string expectedBillingModel = "billing_model";
        bool expectedInheritContacts = true;
        bool expectedInheritTcrBrand = true;
        bool expectedInheritTcrCampaign = true;
        bool expectedInheritTemplates = true;
        string expectedSendingPhoneNumber = "sending_phone_number";
        string expectedSendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedSendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedWhatsappPhoneNumber = "whatsapp_phone_number";

        Assert.Equal(expectedAllowContactSharing, model.AllowContactSharing);
        Assert.Equal(
            expectedAllowNumberChangeDuringOnboarding,
            model.AllowNumberChangeDuringOnboarding
        );
        Assert.Equal(expectedAllowTemplateSharing, model.AllowTemplateSharing);
        Assert.Equal(expectedBillingModel, model.BillingModel);
        Assert.Equal(expectedInheritContacts, model.InheritContacts);
        Assert.Equal(expectedInheritTcrBrand, model.InheritTcrBrand);
        Assert.Equal(expectedInheritTcrCampaign, model.InheritTcrCampaign);
        Assert.Equal(expectedInheritTemplates, model.InheritTemplates);
        Assert.Equal(expectedSendingPhoneNumber, model.SendingPhoneNumber);
        Assert.Equal(expectedSendingPhoneNumberProfileID, model.SendingPhoneNumberProfileID);
        Assert.Equal(expectedSendingWhatsappNumberProfileID, model.SendingWhatsappNumberProfileID);
        Assert.Equal(expectedWhatsappPhoneNumber, model.WhatsappPhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Settings
        {
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WhatsappPhoneNumber = "whatsapp_phone_number",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Settings>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Settings
        {
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WhatsappPhoneNumber = "whatsapp_phone_number",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Settings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAllowContactSharing = true;
        bool expectedAllowNumberChangeDuringOnboarding = true;
        bool expectedAllowTemplateSharing = true;
        string expectedBillingModel = "billing_model";
        bool expectedInheritContacts = true;
        bool expectedInheritTcrBrand = true;
        bool expectedInheritTcrCampaign = true;
        bool expectedInheritTemplates = true;
        string expectedSendingPhoneNumber = "sending_phone_number";
        string expectedSendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedSendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedWhatsappPhoneNumber = "whatsapp_phone_number";

        Assert.Equal(expectedAllowContactSharing, deserialized.AllowContactSharing);
        Assert.Equal(
            expectedAllowNumberChangeDuringOnboarding,
            deserialized.AllowNumberChangeDuringOnboarding
        );
        Assert.Equal(expectedAllowTemplateSharing, deserialized.AllowTemplateSharing);
        Assert.Equal(expectedBillingModel, deserialized.BillingModel);
        Assert.Equal(expectedInheritContacts, deserialized.InheritContacts);
        Assert.Equal(expectedInheritTcrBrand, deserialized.InheritTcrBrand);
        Assert.Equal(expectedInheritTcrCampaign, deserialized.InheritTcrCampaign);
        Assert.Equal(expectedInheritTemplates, deserialized.InheritTemplates);
        Assert.Equal(expectedSendingPhoneNumber, deserialized.SendingPhoneNumber);
        Assert.Equal(expectedSendingPhoneNumberProfileID, deserialized.SendingPhoneNumberProfileID);
        Assert.Equal(
            expectedSendingWhatsappNumberProfileID,
            deserialized.SendingWhatsappNumberProfileID
        );
        Assert.Equal(expectedWhatsappPhoneNumber, deserialized.WhatsappPhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Settings
        {
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WhatsappPhoneNumber = "whatsapp_phone_number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Settings
        {
            AllowNumberChangeDuringOnboarding = true,
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WhatsappPhoneNumber = "whatsapp_phone_number",
        };

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
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Settings
        {
            AllowNumberChangeDuringOnboarding = true,
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WhatsappPhoneNumber = "whatsapp_phone_number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Settings
        {
            AllowNumberChangeDuringOnboarding = true,
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WhatsappPhoneNumber = "whatsapp_phone_number",

            // Null should be interpreted as omitted for these properties
            AllowContactSharing = null,
            AllowTemplateSharing = null,
            BillingModel = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
        };

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
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Settings
        {
            AllowNumberChangeDuringOnboarding = true,
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WhatsappPhoneNumber = "whatsapp_phone_number",

            // Null should be interpreted as omitted for these properties
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
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Settings
        {
            AllowContactSharing = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
        };

        Assert.Null(model.AllowNumberChangeDuringOnboarding);
        Assert.False(model.RawData.ContainsKey("allow_number_change_during_onboarding"));
        Assert.Null(model.SendingPhoneNumber);
        Assert.False(model.RawData.ContainsKey("sending_phone_number"));
        Assert.Null(model.SendingPhoneNumberProfileID);
        Assert.False(model.RawData.ContainsKey("sending_phone_number_profile_id"));
        Assert.Null(model.SendingWhatsappNumberProfileID);
        Assert.False(model.RawData.ContainsKey("sending_whatsapp_number_profile_id"));
        Assert.Null(model.WhatsappPhoneNumber);
        Assert.False(model.RawData.ContainsKey("whatsapp_phone_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Settings
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
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Settings
        {
            AllowContactSharing = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,

            AllowNumberChangeDuringOnboarding = null,
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            SendingWhatsappNumberProfileID = null,
            WhatsappPhoneNumber = null,
        };

        Assert.Null(model.AllowNumberChangeDuringOnboarding);
        Assert.True(model.RawData.ContainsKey("allow_number_change_during_onboarding"));
        Assert.Null(model.SendingPhoneNumber);
        Assert.True(model.RawData.ContainsKey("sending_phone_number"));
        Assert.Null(model.SendingPhoneNumberProfileID);
        Assert.True(model.RawData.ContainsKey("sending_phone_number_profile_id"));
        Assert.Null(model.SendingWhatsappNumberProfileID);
        Assert.True(model.RawData.ContainsKey("sending_whatsapp_number_profile_id"));
        Assert.Null(model.WhatsappPhoneNumber);
        Assert.True(model.RawData.ContainsKey("whatsapp_phone_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Settings
        {
            AllowContactSharing = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,

            AllowNumberChangeDuringOnboarding = null,
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            SendingWhatsappNumberProfileID = null,
            WhatsappPhoneNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Settings
        {
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WhatsappPhoneNumber = "whatsapp_phone_number",
        };

        Settings copied = new(model);

        Assert.Equal(model, copied);
    }
}
