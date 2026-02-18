using System;
using System.Collections.Generic;
using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Me;
using Webhooks = SentDm.Models.Webhooks;

namespace SentDm.Tests.Models.Me;

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
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Icon = "icon",
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
                Status = "status",
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
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        Data expectedData = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Icon = "icon",
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
            Status = "status",
        };
        Webhooks::ApiError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        Webhooks::ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            ResponseTimeMs = 0,
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
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Icon = "icon",
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
                Status = "status",
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
                ResponseTimeMs = 0,
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
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Icon = "icon",
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
                Status = "status",
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
                ResponseTimeMs = 0,
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
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Icon = "icon",
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
            Status = "status",
        };
        Webhooks::ApiError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        Webhooks::ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            ResponseTimeMs = 0,
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
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Icon = "icon",
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
                Status = "status",
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
                ResponseTimeMs = 0,
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
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Icon = "icon",
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
                Status = "status",
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
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Icon = "icon",
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
                Status = "status",
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
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Icon = "icon",
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
                Status = "status",
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
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Icon = "icon",
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
                Status = "status",
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
                ResponseTimeMs = 0,
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
                ResponseTimeMs = 0,
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
                ResponseTimeMs = 0,
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
                ResponseTimeMs = 0,
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
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Icon = "icon",
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
                Status = "status",
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
                ResponseTimeMs = 0,
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
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Icon = "icon",
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
            Status = "status",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedIcon = "icon";
        string expectedName = "name";
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
        string expectedStatus = "status";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedIcon, model.Icon);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.Profiles);
        Assert.Equal(expectedProfiles.Count, model.Profiles.Count);
        for (int i = 0; i < expectedProfiles.Count; i++)
        {
            Assert.Equal(expectedProfiles[i], model.Profiles[i]);
        }
        Assert.Equal(expectedSettings, model.Settings);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Icon = "icon",
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
            Status = "status",
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
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Icon = "icon",
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
            Status = "status",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedIcon = "icon";
        string expectedName = "name";
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
        string expectedStatus = "status";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedIcon, deserialized.Icon);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.Profiles);
        Assert.Equal(expectedProfiles.Count, deserialized.Profiles.Count);
        for (int i = 0; i < expectedProfiles.Count; i++)
        {
            Assert.Equal(expectedProfiles[i], deserialized.Profiles[i]);
        }
        Assert.Equal(expectedSettings, deserialized.Settings);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Icon = "icon",
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
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            Description = "description",
            Icon = "icon",
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
            Status = "status",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            Description = "description",
            Icon = "icon",
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
            Icon = "icon",
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
            Status = "status",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Name = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            Description = "description",
            Icon = "icon",
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
            Status = "status",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Icon);
        Assert.False(model.RawData.ContainsKey("icon"));
        Assert.Null(model.Profiles);
        Assert.False(model.RawData.ContainsKey("profiles"));
        Assert.Null(model.Settings);
        Assert.False(model.RawData.ContainsKey("settings"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",

            Description = null,
            Icon = null,
            Profiles = null,
            Settings = null,
            Status = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Icon);
        Assert.True(model.RawData.ContainsKey("icon"));
        Assert.Null(model.Profiles);
        Assert.True(model.RawData.ContainsKey("profiles"));
        Assert.Null(model.Settings);
        Assert.True(model.RawData.ContainsKey("settings"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",

            Description = null,
            Icon = null,
            Profiles = null,
            Settings = null,
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
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Icon = "icon",
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
            Status = "status",
        };

        Data copied = new(model);

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
