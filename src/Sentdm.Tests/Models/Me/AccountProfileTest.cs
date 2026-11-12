using System;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Me;

namespace Sentdm.Tests.Models.Me;

public class AccountProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountProfile
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
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedIcon = "icon";
        string expectedName = "name";
        string expectedRole = "role";
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

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedIcon, model.Icon);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRole, model.Role);
        Assert.Equal(expectedSettings, model.Settings);
        Assert.Equal(expectedShortName, model.ShortName);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountProfile
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountProfile
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedIcon = "icon";
        string expectedName = "name";
        string expectedRole = "role";
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

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedIcon, deserialized.Icon);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRole, deserialized.Role);
        Assert.Equal(expectedSettings, deserialized.Settings);
        Assert.Equal(expectedShortName, deserialized.ShortName);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountProfile
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountProfile
        {
            Description = "description",
            Icon = "icon",
            Role = "role",
            ShortName = "short_name",
            Status = "status",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Settings);
        Assert.False(model.RawData.ContainsKey("settings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountProfile
        {
            Description = "description",
            Icon = "icon",
            Role = "role",
            ShortName = "short_name",
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AccountProfile
        {
            Description = "description",
            Icon = "icon",
            Role = "role",
            ShortName = "short_name",
            Status = "status",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Name = null,
            Settings = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Settings);
        Assert.False(model.RawData.ContainsKey("settings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountProfile
        {
            Description = "description",
            Icon = "icon",
            Role = "role",
            ShortName = "short_name",
            Status = "status",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Name = null,
            Settings = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountProfile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
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
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Icon);
        Assert.False(model.RawData.ContainsKey("icon"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
        Assert.Null(model.ShortName);
        Assert.False(model.RawData.ContainsKey("short_name"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountProfile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AccountProfile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
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

            Description = null,
            Icon = null,
            Role = null,
            ShortName = null,
            Status = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Icon);
        Assert.True(model.RawData.ContainsKey("icon"));
        Assert.Null(model.Role);
        Assert.True(model.RawData.ContainsKey("role"));
        Assert.Null(model.ShortName);
        Assert.True(model.RawData.ContainsKey("short_name"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountProfile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
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

            Description = null,
            Icon = null,
            Role = null,
            ShortName = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountProfile
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
        };

        AccountProfile copied = new(model);

        Assert.Equal(model, copied);
    }
}
