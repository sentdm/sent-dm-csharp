using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Me;

namespace Sentdm.Tests.Models.Me;

public class AccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Account
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channels = new()
            {
                Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
                Sms = new() { Configured = true, PhoneNumber = "phone_number" },
                Whatsapp = new()
                {
                    BusinessName = "business_name",
                    Configured = true,
                    PhoneNumber = "phone_number",
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Email = "email",
            EnableTemplateAutoCreationForSp = true,
            Icon = "icon",
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Profiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Icon = "icon",
                    Name = "name",
                    Role = "role",
                    Settings = new()
                    {
                        AllowContactSharing = true,
                        AllowTemplateSharing = true,
                        BillingModel = "billing_model",
                        InheritContacts = true,
                        InheritTcrBrand = true,
                        InheritTcrCampaign = true,
                        InheritTemplates = true,
                    },
                    ShortName = "short_name",
                    Status = "status",
                },
            ],
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
            },
            ShortName = "short_name",
            Status = "status",
            Type = "type",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        AccountChannels expectedChannels = new()
        {
            Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
            Sms = new() { Configured = true, PhoneNumber = "phone_number" },
            Whatsapp = new()
            {
                BusinessName = "business_name",
                Configured = true,
                PhoneNumber = "phone_number",
            },
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedEmail = "email";
        bool expectedEnableTemplateAutoCreationForSp = true;
        string expectedIcon = "icon";
        string expectedName = "name";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<AccountProfile> expectedProfiles =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Icon = "icon",
                Name = "name",
                Role = "role",
                Settings = new()
                {
                    AllowContactSharing = true,
                    AllowTemplateSharing = true,
                    BillingModel = "billing_model",
                    InheritContacts = true,
                    InheritTcrBrand = true,
                    InheritTcrCampaign = true,
                    InheritTemplates = true,
                },
                ShortName = "short_name",
                Status = "status",
            },
        ];
        string expectedSendingPhoneNumber = "sending_phone_number";
        string expectedSendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ProfileSettings expectedSettings = new()
        {
            AllowContactSharing = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
        };
        string expectedShortName = "short_name";
        string expectedStatus = "status";
        string expectedType = "type";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChannels, model.Channels);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(
            expectedEnableTemplateAutoCreationForSp,
            model.EnableTemplateAutoCreationForSp
        );
        Assert.Equal(expectedIcon, model.Icon);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.NotNull(model.Profiles);
        Assert.Equal(expectedProfiles.Count, model.Profiles.Count);
        for (int i = 0; i < expectedProfiles.Count; i++)
        {
            Assert.Equal(expectedProfiles[i], model.Profiles[i]);
        }
        Assert.Equal(expectedSendingPhoneNumber, model.SendingPhoneNumber);
        Assert.Equal(expectedSendingPhoneNumberProfileID, model.SendingPhoneNumberProfileID);
        Assert.Equal(expectedSettings, model.Settings);
        Assert.Equal(expectedShortName, model.ShortName);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Account
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channels = new()
            {
                Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
                Sms = new() { Configured = true, PhoneNumber = "phone_number" },
                Whatsapp = new()
                {
                    BusinessName = "business_name",
                    Configured = true,
                    PhoneNumber = "phone_number",
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Email = "email",
            EnableTemplateAutoCreationForSp = true,
            Icon = "icon",
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Profiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Icon = "icon",
                    Name = "name",
                    Role = "role",
                    Settings = new()
                    {
                        AllowContactSharing = true,
                        AllowTemplateSharing = true,
                        BillingModel = "billing_model",
                        InheritContacts = true,
                        InheritTcrBrand = true,
                        InheritTcrCampaign = true,
                        InheritTemplates = true,
                    },
                    ShortName = "short_name",
                    Status = "status",
                },
            ],
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
            },
            ShortName = "short_name",
            Status = "status",
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Account>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Account
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channels = new()
            {
                Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
                Sms = new() { Configured = true, PhoneNumber = "phone_number" },
                Whatsapp = new()
                {
                    BusinessName = "business_name",
                    Configured = true,
                    PhoneNumber = "phone_number",
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Email = "email",
            EnableTemplateAutoCreationForSp = true,
            Icon = "icon",
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Profiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Icon = "icon",
                    Name = "name",
                    Role = "role",
                    Settings = new()
                    {
                        AllowContactSharing = true,
                        AllowTemplateSharing = true,
                        BillingModel = "billing_model",
                        InheritContacts = true,
                        InheritTcrBrand = true,
                        InheritTcrCampaign = true,
                        InheritTemplates = true,
                    },
                    ShortName = "short_name",
                    Status = "status",
                },
            ],
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
            },
            ShortName = "short_name",
            Status = "status",
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Account>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        AccountChannels expectedChannels = new()
        {
            Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
            Sms = new() { Configured = true, PhoneNumber = "phone_number" },
            Whatsapp = new()
            {
                BusinessName = "business_name",
                Configured = true,
                PhoneNumber = "phone_number",
            },
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedEmail = "email";
        bool expectedEnableTemplateAutoCreationForSp = true;
        string expectedIcon = "icon";
        string expectedName = "name";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<AccountProfile> expectedProfiles =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Icon = "icon",
                Name = "name",
                Role = "role",
                Settings = new()
                {
                    AllowContactSharing = true,
                    AllowTemplateSharing = true,
                    BillingModel = "billing_model",
                    InheritContacts = true,
                    InheritTcrBrand = true,
                    InheritTcrCampaign = true,
                    InheritTemplates = true,
                },
                ShortName = "short_name",
                Status = "status",
            },
        ];
        string expectedSendingPhoneNumber = "sending_phone_number";
        string expectedSendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ProfileSettings expectedSettings = new()
        {
            AllowContactSharing = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
        };
        string expectedShortName = "short_name";
        string expectedStatus = "status";
        string expectedType = "type";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChannels, deserialized.Channels);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(
            expectedEnableTemplateAutoCreationForSp,
            deserialized.EnableTemplateAutoCreationForSp
        );
        Assert.Equal(expectedIcon, deserialized.Icon);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.NotNull(deserialized.Profiles);
        Assert.Equal(expectedProfiles.Count, deserialized.Profiles.Count);
        for (int i = 0; i < expectedProfiles.Count; i++)
        {
            Assert.Equal(expectedProfiles[i], deserialized.Profiles[i]);
        }
        Assert.Equal(expectedSendingPhoneNumber, deserialized.SendingPhoneNumber);
        Assert.Equal(expectedSendingPhoneNumberProfileID, deserialized.SendingPhoneNumberProfileID);
        Assert.Equal(expectedSettings, deserialized.Settings);
        Assert.Equal(expectedShortName, deserialized.ShortName);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Account
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channels = new()
            {
                Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
                Sms = new() { Configured = true, PhoneNumber = "phone_number" },
                Whatsapp = new()
                {
                    BusinessName = "business_name",
                    Configured = true,
                    PhoneNumber = "phone_number",
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Email = "email",
            EnableTemplateAutoCreationForSp = true,
            Icon = "icon",
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Profiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Icon = "icon",
                    Name = "name",
                    Role = "role",
                    Settings = new()
                    {
                        AllowContactSharing = true,
                        AllowTemplateSharing = true,
                        BillingModel = "billing_model",
                        InheritContacts = true,
                        InheritTcrBrand = true,
                        InheritTcrCampaign = true,
                        InheritTemplates = true,
                    },
                    ShortName = "short_name",
                    Status = "status",
                },
            ],
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
            },
            ShortName = "short_name",
            Status = "status",
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Account
        {
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
            },
            ShortName = "short_name",
            Status = "status",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.EnableTemplateAutoCreationForSp);
        Assert.False(model.RawData.ContainsKey("enable_template_auto_creation_for_sp"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Profiles);
        Assert.False(model.RawData.ContainsKey("profiles"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Account
        {
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
            },
            ShortName = "short_name",
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Account
        {
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
            },
            ShortName = "short_name",
            Status = "status",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Channels = null,
            CreatedAt = null,
            EnableTemplateAutoCreationForSp = null,
            Name = null,
            Profiles = null,
            Type = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.EnableTemplateAutoCreationForSp);
        Assert.False(model.RawData.ContainsKey("enable_template_auto_creation_for_sp"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Profiles);
        Assert.False(model.RawData.ContainsKey("profiles"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Account
        {
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
            },
            ShortName = "short_name",
            Status = "status",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Channels = null,
            CreatedAt = null,
            EnableTemplateAutoCreationForSp = null,
            Name = null,
            Profiles = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Account
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channels = new()
            {
                Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
                Sms = new() { Configured = true, PhoneNumber = "phone_number" },
                Whatsapp = new()
                {
                    BusinessName = "business_name",
                    Configured = true,
                    PhoneNumber = "phone_number",
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnableTemplateAutoCreationForSp = true,
            Name = "name",
            Profiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Icon = "icon",
                    Name = "name",
                    Role = "role",
                    Settings = new()
                    {
                        AllowContactSharing = true,
                        AllowTemplateSharing = true,
                        BillingModel = "billing_model",
                        InheritContacts = true,
                        InheritTcrBrand = true,
                        InheritTcrCampaign = true,
                        InheritTemplates = true,
                    },
                    ShortName = "short_name",
                    Status = "status",
                },
            ],
            Type = "type",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Icon);
        Assert.False(model.RawData.ContainsKey("icon"));
        Assert.Null(model.OrganizationID);
        Assert.False(model.RawData.ContainsKey("organization_id"));
        Assert.Null(model.SendingPhoneNumber);
        Assert.False(model.RawData.ContainsKey("sending_phone_number"));
        Assert.Null(model.SendingPhoneNumberProfileID);
        Assert.False(model.RawData.ContainsKey("sending_phone_number_profile_id"));
        Assert.Null(model.Settings);
        Assert.False(model.RawData.ContainsKey("settings"));
        Assert.Null(model.ShortName);
        Assert.False(model.RawData.ContainsKey("short_name"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Account
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channels = new()
            {
                Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
                Sms = new() { Configured = true, PhoneNumber = "phone_number" },
                Whatsapp = new()
                {
                    BusinessName = "business_name",
                    Configured = true,
                    PhoneNumber = "phone_number",
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnableTemplateAutoCreationForSp = true,
            Name = "name",
            Profiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Icon = "icon",
                    Name = "name",
                    Role = "role",
                    Settings = new()
                    {
                        AllowContactSharing = true,
                        AllowTemplateSharing = true,
                        BillingModel = "billing_model",
                        InheritContacts = true,
                        InheritTcrBrand = true,
                        InheritTcrCampaign = true,
                        InheritTemplates = true,
                    },
                    ShortName = "short_name",
                    Status = "status",
                },
            ],
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Account
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channels = new()
            {
                Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
                Sms = new() { Configured = true, PhoneNumber = "phone_number" },
                Whatsapp = new()
                {
                    BusinessName = "business_name",
                    Configured = true,
                    PhoneNumber = "phone_number",
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnableTemplateAutoCreationForSp = true,
            Name = "name",
            Profiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Icon = "icon",
                    Name = "name",
                    Role = "role",
                    Settings = new()
                    {
                        AllowContactSharing = true,
                        AllowTemplateSharing = true,
                        BillingModel = "billing_model",
                        InheritContacts = true,
                        InheritTcrBrand = true,
                        InheritTcrCampaign = true,
                        InheritTemplates = true,
                    },
                    ShortName = "short_name",
                    Status = "status",
                },
            ],
            Type = "type",

            Description = null,
            Email = null,
            Icon = null,
            OrganizationID = null,
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            Settings = null,
            ShortName = null,
            Status = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.Icon);
        Assert.True(model.RawData.ContainsKey("icon"));
        Assert.Null(model.OrganizationID);
        Assert.True(model.RawData.ContainsKey("organization_id"));
        Assert.Null(model.SendingPhoneNumber);
        Assert.True(model.RawData.ContainsKey("sending_phone_number"));
        Assert.Null(model.SendingPhoneNumberProfileID);
        Assert.True(model.RawData.ContainsKey("sending_phone_number_profile_id"));
        Assert.Null(model.Settings);
        Assert.True(model.RawData.ContainsKey("settings"));
        Assert.Null(model.ShortName);
        Assert.True(model.RawData.ContainsKey("short_name"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Account
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channels = new()
            {
                Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
                Sms = new() { Configured = true, PhoneNumber = "phone_number" },
                Whatsapp = new()
                {
                    BusinessName = "business_name",
                    Configured = true,
                    PhoneNumber = "phone_number",
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnableTemplateAutoCreationForSp = true,
            Name = "name",
            Profiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Icon = "icon",
                    Name = "name",
                    Role = "role",
                    Settings = new()
                    {
                        AllowContactSharing = true,
                        AllowTemplateSharing = true,
                        BillingModel = "billing_model",
                        InheritContacts = true,
                        InheritTcrBrand = true,
                        InheritTcrCampaign = true,
                        InheritTemplates = true,
                    },
                    ShortName = "short_name",
                    Status = "status",
                },
            ],
            Type = "type",

            Description = null,
            Email = null,
            Icon = null,
            OrganizationID = null,
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            Settings = null,
            ShortName = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Account
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channels = new()
            {
                Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
                Sms = new() { Configured = true, PhoneNumber = "phone_number" },
                Whatsapp = new()
                {
                    BusinessName = "business_name",
                    Configured = true,
                    PhoneNumber = "phone_number",
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Email = "email",
            EnableTemplateAutoCreationForSp = true,
            Icon = "icon",
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Profiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Icon = "icon",
                    Name = "name",
                    Role = "role",
                    Settings = new()
                    {
                        AllowContactSharing = true,
                        AllowTemplateSharing = true,
                        BillingModel = "billing_model",
                        InheritContacts = true,
                        InheritTcrBrand = true,
                        InheritTcrCampaign = true,
                        InheritTemplates = true,
                    },
                    ShortName = "short_name",
                    Status = "status",
                },
            ],
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Settings = new()
            {
                AllowContactSharing = true,
                AllowTemplateSharing = true,
                BillingModel = "billing_model",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
            },
            ShortName = "short_name",
            Status = "status",
            Type = "type",
        };

        Account copied = new(model);

        Assert.Equal(model, copied);
    }
}
