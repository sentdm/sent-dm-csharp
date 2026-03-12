using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Me;
using Webhooks = Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Me;

public class MeRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MeRetrieveResponse
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        Data expectedData = new()
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
        Webhooks::ErrorDetail expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        Webhooks::ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedMeta, model.Meta);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MeRetrieveResponse
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MeRetrieveResponse
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
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
        Webhooks::ErrorDetail expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        Webhooks::ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedMeta, deserialized.Meta);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MeRetrieveResponse
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MeRetrieveResponse
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
        };

        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MeRetrieveResponse
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MeRetrieveResponse
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },

            // Null should be interpreted as omitted for these properties
            Meta = null,
            Success = null,
        };

        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MeRetrieveResponse
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },

            // Null should be interpreted as omitted for these properties
            Meta = null,
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MeRetrieveResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MeRetrieveResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MeRetrieveResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,

            Data = null,
            Error = null,
        };

        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MeRetrieveResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,

            Data = null,
            Error = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MeRetrieveResponse
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        MeRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
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
        Channels expectedChannels = new()
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
        string expectedIcon = "icon";
        string expectedName = "name";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<Profile> expectedProfiles =
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
        Assert.Equal(expectedIcon, model.Icon);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.NotNull(model.Profiles);
        Assert.Equal(expectedProfiles.Count, model.Profiles.Count);
        for (int i = 0; i < expectedProfiles.Count; i++)
        {
            Assert.Equal(expectedProfiles[i], model.Profiles[i]);
        }
        Assert.Equal(expectedSettings, model.Settings);
        Assert.Equal(expectedShortName, model.ShortName);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
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
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
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
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Channels expectedChannels = new()
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
        string expectedIcon = "icon";
        string expectedName = "name";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<Profile> expectedProfiles =
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
        Assert.Equal(expectedIcon, deserialized.Icon);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.NotNull(deserialized.Profiles);
        Assert.Equal(expectedProfiles.Count, deserialized.Profiles.Count);
        for (int i = 0; i < expectedProfiles.Count; i++)
        {
            Assert.Equal(expectedProfiles[i], deserialized.Profiles[i]);
        }
        Assert.Equal(expectedSettings, deserialized.Settings);
        Assert.Equal(expectedShortName, deserialized.ShortName);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
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
        var model = new Data
        {
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
        var model = new Data
        {
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
        var model = new Data
        {
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
        var model = new Data
        {
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = null,
            Profiles = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
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
        var model = new Data
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
        var model = new Data
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
        var model = new Data
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
            Settings = null,
            ShortName = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
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

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChannelsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Channels
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

        Rcs expectedRcs = new() { Configured = true, PhoneNumber = "phone_number" };
        Sms expectedSms = new() { Configured = true, PhoneNumber = "phone_number" };
        Whatsapp expectedWhatsapp = new()
        {
            BusinessName = "business_name",
            Configured = true,
            PhoneNumber = "phone_number",
        };

        Assert.Equal(expectedRcs, model.Rcs);
        Assert.Equal(expectedSms, model.Sms);
        Assert.Equal(expectedWhatsapp, model.Whatsapp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Channels
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Channels>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Channels
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Channels>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Rcs expectedRcs = new() { Configured = true, PhoneNumber = "phone_number" };
        Sms expectedSms = new() { Configured = true, PhoneNumber = "phone_number" };
        Whatsapp expectedWhatsapp = new()
        {
            BusinessName = "business_name",
            Configured = true,
            PhoneNumber = "phone_number",
        };

        Assert.Equal(expectedRcs, deserialized.Rcs);
        Assert.Equal(expectedSms, deserialized.Sms);
        Assert.Equal(expectedWhatsapp, deserialized.Whatsapp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Channels
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Channels { };

        Assert.Null(model.Rcs);
        Assert.False(model.RawData.ContainsKey("rcs"));
        Assert.Null(model.Sms);
        Assert.False(model.RawData.ContainsKey("sms"));
        Assert.Null(model.Whatsapp);
        Assert.False(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Channels { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Channels
        {
            // Null should be interpreted as omitted for these properties
            Rcs = null,
            Sms = null,
            Whatsapp = null,
        };

        Assert.Null(model.Rcs);
        Assert.False(model.RawData.ContainsKey("rcs"));
        Assert.Null(model.Sms);
        Assert.False(model.RawData.ContainsKey("sms"));
        Assert.Null(model.Whatsapp);
        Assert.False(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Channels
        {
            // Null should be interpreted as omitted for these properties
            Rcs = null,
            Sms = null,
            Whatsapp = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Channels
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

        Channels copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RcsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Rcs { Configured = true, PhoneNumber = "phone_number" };

        bool expectedConfigured = true;
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedConfigured, model.Configured);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Rcs { Configured = true, PhoneNumber = "phone_number" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rcs>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Rcs { Configured = true, PhoneNumber = "phone_number" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rcs>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedConfigured = true;
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedConfigured, deserialized.Configured);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Rcs { Configured = true, PhoneNumber = "phone_number" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Rcs { PhoneNumber = "phone_number" };

        Assert.Null(model.Configured);
        Assert.False(model.RawData.ContainsKey("configured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Rcs { PhoneNumber = "phone_number" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Rcs
        {
            PhoneNumber = "phone_number",

            // Null should be interpreted as omitted for these properties
            Configured = null,
        };

        Assert.Null(model.Configured);
        Assert.False(model.RawData.ContainsKey("configured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Rcs
        {
            PhoneNumber = "phone_number",

            // Null should be interpreted as omitted for these properties
            Configured = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Rcs { Configured = true };

        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Rcs { Configured = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Rcs
        {
            Configured = true,

            PhoneNumber = null,
        };

        Assert.Null(model.PhoneNumber);
        Assert.True(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Rcs
        {
            Configured = true,

            PhoneNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Rcs { Configured = true, PhoneNumber = "phone_number" };

        Rcs copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SmsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Sms { Configured = true, PhoneNumber = "phone_number" };

        bool expectedConfigured = true;
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedConfigured, model.Configured);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Sms { Configured = true, PhoneNumber = "phone_number" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sms>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Sms { Configured = true, PhoneNumber = "phone_number" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sms>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedConfigured = true;
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedConfigured, deserialized.Configured);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Sms { Configured = true, PhoneNumber = "phone_number" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Sms { PhoneNumber = "phone_number" };

        Assert.Null(model.Configured);
        Assert.False(model.RawData.ContainsKey("configured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Sms { PhoneNumber = "phone_number" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Sms
        {
            PhoneNumber = "phone_number",

            // Null should be interpreted as omitted for these properties
            Configured = null,
        };

        Assert.Null(model.Configured);
        Assert.False(model.RawData.ContainsKey("configured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Sms
        {
            PhoneNumber = "phone_number",

            // Null should be interpreted as omitted for these properties
            Configured = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Sms { Configured = true };

        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Sms { Configured = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Sms
        {
            Configured = true,

            PhoneNumber = null,
        };

        Assert.Null(model.PhoneNumber);
        Assert.True(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Sms
        {
            Configured = true,

            PhoneNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Sms { Configured = true, PhoneNumber = "phone_number" };

        Sms copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WhatsappTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Whatsapp
        {
            BusinessName = "business_name",
            Configured = true,
            PhoneNumber = "phone_number",
        };

        string expectedBusinessName = "business_name";
        bool expectedConfigured = true;
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedBusinessName, model.BusinessName);
        Assert.Equal(expectedConfigured, model.Configured);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Whatsapp
        {
            BusinessName = "business_name",
            Configured = true,
            PhoneNumber = "phone_number",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Whatsapp>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Whatsapp
        {
            BusinessName = "business_name",
            Configured = true,
            PhoneNumber = "phone_number",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Whatsapp>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessName = "business_name";
        bool expectedConfigured = true;
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedBusinessName, deserialized.BusinessName);
        Assert.Equal(expectedConfigured, deserialized.Configured);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Whatsapp
        {
            BusinessName = "business_name",
            Configured = true,
            PhoneNumber = "phone_number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Whatsapp { BusinessName = "business_name", PhoneNumber = "phone_number" };

        Assert.Null(model.Configured);
        Assert.False(model.RawData.ContainsKey("configured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Whatsapp { BusinessName = "business_name", PhoneNumber = "phone_number" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Whatsapp
        {
            BusinessName = "business_name",
            PhoneNumber = "phone_number",

            // Null should be interpreted as omitted for these properties
            Configured = null,
        };

        Assert.Null(model.Configured);
        Assert.False(model.RawData.ContainsKey("configured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Whatsapp
        {
            BusinessName = "business_name",
            PhoneNumber = "phone_number",

            // Null should be interpreted as omitted for these properties
            Configured = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Whatsapp { Configured = true };

        Assert.Null(model.BusinessName);
        Assert.False(model.RawData.ContainsKey("business_name"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Whatsapp { Configured = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Whatsapp
        {
            Configured = true,

            BusinessName = null,
            PhoneNumber = null,
        };

        Assert.Null(model.BusinessName);
        Assert.True(model.RawData.ContainsKey("business_name"));
        Assert.Null(model.PhoneNumber);
        Assert.True(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Whatsapp
        {
            Configured = true,

            BusinessName = null,
            PhoneNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Whatsapp
        {
            BusinessName = "business_name",
            Configured = true,
            PhoneNumber = "phone_number",
        };

        Whatsapp copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Profile
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
        var model = new Profile
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
        var deserialized = JsonSerializer.Deserialize<Profile>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Profile
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
        var deserialized = JsonSerializer.Deserialize<Profile>(
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
        var model = new Profile
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
        var model = new Profile
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
        var model = new Profile
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
        var model = new Profile
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
        var model = new Profile
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
        var model = new Profile
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
        var model = new Profile
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
        var model = new Profile
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
        var model = new Profile
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
        var model = new Profile
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

        Profile copied = new(model);

        Assert.Equal(model, copied);
    }
}
