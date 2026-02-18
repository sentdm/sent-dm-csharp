using System;
using System.Collections.Generic;
using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Profiles;
using Webhooks = SentDm.Models.Webhooks;

namespace SentDm.Tests.Models.Profiles;

public class ProfileListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileListResponse
        {
            Data = new()
            {
                Profiles =
                [
                    new()
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
                    },
                ],
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
            Profiles =
            [
                new()
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
                },
            ],
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
        var model = new ProfileListResponse
        {
            Data = new()
            {
                Profiles =
                [
                    new()
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
                    },
                ],
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
        var deserialized = JsonSerializer.Deserialize<ProfileListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfileListResponse
        {
            Data = new()
            {
                Profiles =
                [
                    new()
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
                    },
                ],
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
        var deserialized = JsonSerializer.Deserialize<ProfileListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            Profiles =
            [
                new()
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
                },
            ],
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
        var model = new ProfileListResponse
        {
            Data = new()
            {
                Profiles =
                [
                    new()
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
                    },
                ],
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
        var model = new ProfileListResponse
        {
            Data = new()
            {
                Profiles =
                [
                    new()
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
                    },
                ],
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
        var model = new ProfileListResponse
        {
            Data = new()
            {
                Profiles =
                [
                    new()
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
                    },
                ],
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
        var model = new ProfileListResponse
        {
            Data = new()
            {
                Profiles =
                [
                    new()
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
                    },
                ],
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
        var model = new ProfileListResponse
        {
            Data = new()
            {
                Profiles =
                [
                    new()
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
                    },
                ],
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
        var model = new ProfileListResponse
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
        var model = new ProfileListResponse
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
        var model = new ProfileListResponse
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
        var model = new ProfileListResponse
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
        var model = new ProfileListResponse
        {
            Data = new()
            {
                Profiles =
                [
                    new()
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
                    },
                ],
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

        ProfileListResponse copied = new(model);

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
            Profiles =
            [
                new()
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
                },
            ],
        };

        List<ProfileDetail> expectedProfiles =
        [
            new()
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
            },
        ];

        Assert.NotNull(model.Profiles);
        Assert.Equal(expectedProfiles.Count, model.Profiles.Count);
        for (int i = 0; i < expectedProfiles.Count; i++)
        {
            Assert.Equal(expectedProfiles[i], model.Profiles[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Profiles =
            [
                new()
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
                },
            ],
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
            Profiles =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<ProfileDetail> expectedProfiles =
        [
            new()
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
            },
        ];

        Assert.NotNull(deserialized.Profiles);
        Assert.Equal(expectedProfiles.Count, deserialized.Profiles.Count);
        for (int i = 0; i < expectedProfiles.Count; i++)
        {
            Assert.Equal(expectedProfiles[i], deserialized.Profiles[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Profiles =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data { };

        Assert.Null(model.Profiles);
        Assert.False(model.RawData.ContainsKey("profiles"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            Profiles = null,
        };

        Assert.Null(model.Profiles);
        Assert.False(model.RawData.ContainsKey("profiles"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            Profiles = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Profiles =
            [
                new()
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
                },
            ],
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}
