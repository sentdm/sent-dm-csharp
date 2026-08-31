using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Conversations;

namespace Sentdm.Tests.Models.Conversations;

public class ConversationListMessagesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponse
        {
            Data = new()
            {
                Messages =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ActiveContactPrice = 0,
                        Channel = "channel",
                        ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Direction = "direction",
                        Events =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Description = "description",
                            },
                        ],
                        MessageBody = new()
                        {
                            Buttons =
                            [
                                new()
                                {
                                    PostbackData = "postbackData",
                                    Text = "text",
                                    Type = "type",
                                    Value = "value",
                                },
                            ],
                            Content = "content",
                            Footer = "footer",
                            Header = "header",
                        },
                        Phone = "phone",
                        PhoneInternational = "phone_international",
                        Price = 0,
                        RegionCode = "region_code",
                        Status = "status",
                        TemplateCategory = "template_category",
                        TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        TemplateName = "template_name",
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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

        ConversationListMessagesResponseData expectedData = new()
        {
            Messages =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ActiveContactPrice = 0,
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Direction = "direction",
                    Events =
                    [
                        new()
                        {
                            Status = "status",
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Description = "description",
                        },
                    ],
                    MessageBody = new()
                    {
                        Buttons =
                        [
                            new()
                            {
                                PostbackData = "postbackData",
                                Text = "text",
                                Type = "type",
                                Value = "value",
                            },
                        ],
                        Content = "content",
                        Footer = "footer",
                        Header = "header",
                    },
                    Phone = "phone",
                    PhoneInternational = "phone_international",
                    Price = 0,
                    RegionCode = "region_code",
                    Status = "status",
                    TemplateCategory = "template_category",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };
        ConversationListMessagesResponseError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ConversationListMessagesResponseMeta expectedMeta = new()
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
        var model = new ConversationListMessagesResponse
        {
            Data = new()
            {
                Messages =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ActiveContactPrice = 0,
                        Channel = "channel",
                        ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Direction = "direction",
                        Events =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Description = "description",
                            },
                        ],
                        MessageBody = new()
                        {
                            Buttons =
                            [
                                new()
                                {
                                    PostbackData = "postbackData",
                                    Text = "text",
                                    Type = "type",
                                    Value = "value",
                                },
                            ],
                            Content = "content",
                            Footer = "footer",
                            Header = "header",
                        },
                        Phone = "phone",
                        PhoneInternational = "phone_international",
                        Price = 0,
                        RegionCode = "region_code",
                        Status = "status",
                        TemplateCategory = "template_category",
                        TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        TemplateName = "template_name",
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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
        var deserialized = JsonSerializer.Deserialize<ConversationListMessagesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationListMessagesResponse
        {
            Data = new()
            {
                Messages =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ActiveContactPrice = 0,
                        Channel = "channel",
                        ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Direction = "direction",
                        Events =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Description = "description",
                            },
                        ],
                        MessageBody = new()
                        {
                            Buttons =
                            [
                                new()
                                {
                                    PostbackData = "postbackData",
                                    Text = "text",
                                    Type = "type",
                                    Value = "value",
                                },
                            ],
                            Content = "content",
                            Footer = "footer",
                            Header = "header",
                        },
                        Phone = "phone",
                        PhoneInternational = "phone_international",
                        Price = 0,
                        RegionCode = "region_code",
                        Status = "status",
                        TemplateCategory = "template_category",
                        TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        TemplateName = "template_name",
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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
        var deserialized = JsonSerializer.Deserialize<ConversationListMessagesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ConversationListMessagesResponseData expectedData = new()
        {
            Messages =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ActiveContactPrice = 0,
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Direction = "direction",
                    Events =
                    [
                        new()
                        {
                            Status = "status",
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Description = "description",
                        },
                    ],
                    MessageBody = new()
                    {
                        Buttons =
                        [
                            new()
                            {
                                PostbackData = "postbackData",
                                Text = "text",
                                Type = "type",
                                Value = "value",
                            },
                        ],
                        Content = "content",
                        Footer = "footer",
                        Header = "header",
                    },
                    Phone = "phone",
                    PhoneInternational = "phone_international",
                    Price = 0,
                    RegionCode = "region_code",
                    Status = "status",
                    TemplateCategory = "template_category",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };
        ConversationListMessagesResponseError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ConversationListMessagesResponseMeta expectedMeta = new()
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
        var model = new ConversationListMessagesResponse
        {
            Data = new()
            {
                Messages =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ActiveContactPrice = 0,
                        Channel = "channel",
                        ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Direction = "direction",
                        Events =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Description = "description",
                            },
                        ],
                        MessageBody = new()
                        {
                            Buttons =
                            [
                                new()
                                {
                                    PostbackData = "postbackData",
                                    Text = "text",
                                    Type = "type",
                                    Value = "value",
                                },
                            ],
                            Content = "content",
                            Footer = "footer",
                            Header = "header",
                        },
                        Phone = "phone",
                        PhoneInternational = "phone_international",
                        Price = 0,
                        RegionCode = "region_code",
                        Status = "status",
                        TemplateCategory = "template_category",
                        TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        TemplateName = "template_name",
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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
        var model = new ConversationListMessagesResponse
        {
            Data = new()
            {
                Messages =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ActiveContactPrice = 0,
                        Channel = "channel",
                        ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Direction = "direction",
                        Events =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Description = "description",
                            },
                        ],
                        MessageBody = new()
                        {
                            Buttons =
                            [
                                new()
                                {
                                    PostbackData = "postbackData",
                                    Text = "text",
                                    Type = "type",
                                    Value = "value",
                                },
                            ],
                            Content = "content",
                            Footer = "footer",
                            Header = "header",
                        },
                        Phone = "phone",
                        PhoneInternational = "phone_international",
                        Price = 0,
                        RegionCode = "region_code",
                        Status = "status",
                        TemplateCategory = "template_category",
                        TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        TemplateName = "template_name",
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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
        var model = new ConversationListMessagesResponse
        {
            Data = new()
            {
                Messages =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ActiveContactPrice = 0,
                        Channel = "channel",
                        ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Direction = "direction",
                        Events =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Description = "description",
                            },
                        ],
                        MessageBody = new()
                        {
                            Buttons =
                            [
                                new()
                                {
                                    PostbackData = "postbackData",
                                    Text = "text",
                                    Type = "type",
                                    Value = "value",
                                },
                            ],
                            Content = "content",
                            Footer = "footer",
                            Header = "header",
                        },
                        Phone = "phone",
                        PhoneInternational = "phone_international",
                        Price = 0,
                        RegionCode = "region_code",
                        Status = "status",
                        TemplateCategory = "template_category",
                        TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        TemplateName = "template_name",
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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
        var model = new ConversationListMessagesResponse
        {
            Data = new()
            {
                Messages =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ActiveContactPrice = 0,
                        Channel = "channel",
                        ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Direction = "direction",
                        Events =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Description = "description",
                            },
                        ],
                        MessageBody = new()
                        {
                            Buttons =
                            [
                                new()
                                {
                                    PostbackData = "postbackData",
                                    Text = "text",
                                    Type = "type",
                                    Value = "value",
                                },
                            ],
                            Content = "content",
                            Footer = "footer",
                            Header = "header",
                        },
                        Phone = "phone",
                        PhoneInternational = "phone_international",
                        Price = 0,
                        RegionCode = "region_code",
                        Status = "status",
                        TemplateCategory = "template_category",
                        TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        TemplateName = "template_name",
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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
        var model = new ConversationListMessagesResponse
        {
            Data = new()
            {
                Messages =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ActiveContactPrice = 0,
                        Channel = "channel",
                        ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Direction = "direction",
                        Events =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Description = "description",
                            },
                        ],
                        MessageBody = new()
                        {
                            Buttons =
                            [
                                new()
                                {
                                    PostbackData = "postbackData",
                                    Text = "text",
                                    Type = "type",
                                    Value = "value",
                                },
                            ],
                            Content = "content",
                            Footer = "footer",
                            Header = "header",
                        },
                        Phone = "phone",
                        PhoneInternational = "phone_international",
                        Price = 0,
                        RegionCode = "region_code",
                        Status = "status",
                        TemplateCategory = "template_category",
                        TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        TemplateName = "template_name",
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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
        var model = new ConversationListMessagesResponse
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
        var model = new ConversationListMessagesResponse
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
        var model = new ConversationListMessagesResponse
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
        var model = new ConversationListMessagesResponse
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
        var model = new ConversationListMessagesResponse
        {
            Data = new()
            {
                Messages =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ActiveContactPrice = 0,
                        Channel = "channel",
                        ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Direction = "direction",
                        Events =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Description = "description",
                            },
                        ],
                        MessageBody = new()
                        {
                            Buttons =
                            [
                                new()
                                {
                                    PostbackData = "postbackData",
                                    Text = "text",
                                    Type = "type",
                                    Value = "value",
                                },
                            ],
                            Content = "content",
                            Footer = "footer",
                            Header = "header",
                        },
                        Phone = "phone",
                        PhoneInternational = "phone_international",
                        Price = 0,
                        RegionCode = "region_code",
                        Status = "status",
                        TemplateCategory = "template_category",
                        TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        TemplateName = "template_name",
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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

        ConversationListMessagesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConversationListMessagesResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseData
        {
            Messages =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ActiveContactPrice = 0,
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Direction = "direction",
                    Events =
                    [
                        new()
                        {
                            Status = "status",
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Description = "description",
                        },
                    ],
                    MessageBody = new()
                    {
                        Buttons =
                        [
                            new()
                            {
                                PostbackData = "postbackData",
                                Text = "text",
                                Type = "type",
                                Value = "value",
                            },
                        ],
                        Content = "content",
                        Footer = "footer",
                        Header = "header",
                    },
                    Phone = "phone",
                    PhoneInternational = "phone_international",
                    Price = 0,
                    RegionCode = "region_code",
                    Status = "status",
                    TemplateCategory = "template_category",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        List<ConversationListMessagesResponseDataMessage> expectedMessages =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ActiveContactPrice = 0,
                Channel = "channel",
                ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Direction = "direction",
                Events =
                [
                    new()
                    {
                        Status = "status",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Description = "description",
                    },
                ],
                MessageBody = new()
                {
                    Buttons =
                    [
                        new()
                        {
                            PostbackData = "postbackData",
                            Text = "text",
                            Type = "type",
                            Value = "value",
                        },
                    ],
                    Content = "content",
                    Footer = "footer",
                    Header = "header",
                },
                Phone = "phone",
                PhoneInternational = "phone_international",
                Price = 0,
                RegionCode = "region_code",
                Status = "status",
                TemplateCategory = "template_category",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
            },
        ];
        ConversationListMessagesResponseDataPagination expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.NotNull(model.Messages);
        Assert.Equal(expectedMessages.Count, model.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], model.Messages[i]);
        }
        Assert.Equal(expectedPagination, model.Pagination);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseData
        {
            Messages =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ActiveContactPrice = 0,
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Direction = "direction",
                    Events =
                    [
                        new()
                        {
                            Status = "status",
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Description = "description",
                        },
                    ],
                    MessageBody = new()
                    {
                        Buttons =
                        [
                            new()
                            {
                                PostbackData = "postbackData",
                                Text = "text",
                                Type = "type",
                                Value = "value",
                            },
                        ],
                        Content = "content",
                        Footer = "footer",
                        Header = "header",
                    },
                    Phone = "phone",
                    PhoneInternational = "phone_international",
                    Price = 0,
                    RegionCode = "region_code",
                    Status = "status",
                    TemplateCategory = "template_category",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationListMessagesResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationListMessagesResponseData
        {
            Messages =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ActiveContactPrice = 0,
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Direction = "direction",
                    Events =
                    [
                        new()
                        {
                            Status = "status",
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Description = "description",
                        },
                    ],
                    MessageBody = new()
                    {
                        Buttons =
                        [
                            new()
                            {
                                PostbackData = "postbackData",
                                Text = "text",
                                Type = "type",
                                Value = "value",
                            },
                        ],
                        Content = "content",
                        Footer = "footer",
                        Header = "header",
                    },
                    Phone = "phone",
                    PhoneInternational = "phone_international",
                    Price = 0,
                    RegionCode = "region_code",
                    Status = "status",
                    TemplateCategory = "template_category",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationListMessagesResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ConversationListMessagesResponseDataMessage> expectedMessages =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ActiveContactPrice = 0,
                Channel = "channel",
                ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Direction = "direction",
                Events =
                [
                    new()
                    {
                        Status = "status",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Description = "description",
                    },
                ],
                MessageBody = new()
                {
                    Buttons =
                    [
                        new()
                        {
                            PostbackData = "postbackData",
                            Text = "text",
                            Type = "type",
                            Value = "value",
                        },
                    ],
                    Content = "content",
                    Footer = "footer",
                    Header = "header",
                },
                Phone = "phone",
                PhoneInternational = "phone_international",
                Price = 0,
                RegionCode = "region_code",
                Status = "status",
                TemplateCategory = "template_category",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
            },
        ];
        ConversationListMessagesResponseDataPagination expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.NotNull(deserialized.Messages);
        Assert.Equal(expectedMessages.Count, deserialized.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], deserialized.Messages[i]);
        }
        Assert.Equal(expectedPagination, deserialized.Pagination);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversationListMessagesResponseData
        {
            Messages =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ActiveContactPrice = 0,
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Direction = "direction",
                    Events =
                    [
                        new()
                        {
                            Status = "status",
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Description = "description",
                        },
                    ],
                    MessageBody = new()
                    {
                        Buttons =
                        [
                            new()
                            {
                                PostbackData = "postbackData",
                                Text = "text",
                                Type = "type",
                                Value = "value",
                            },
                        ],
                        Content = "content",
                        Footer = "footer",
                        Header = "header",
                    },
                    Phone = "phone",
                    PhoneInternational = "phone_international",
                    Price = 0,
                    RegionCode = "region_code",
                    Status = "status",
                    TemplateCategory = "template_category",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseData { };

        Assert.Null(model.Messages);
        Assert.False(model.RawData.ContainsKey("messages"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListMessagesResponseData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseData
        {
            // Null should be interpreted as omitted for these properties
            Messages = null,
            Pagination = null,
        };

        Assert.Null(model.Messages);
        Assert.False(model.RawData.ContainsKey("messages"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationListMessagesResponseData
        {
            // Null should be interpreted as omitted for these properties
            Messages = null,
            Pagination = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationListMessagesResponseData
        {
            Messages =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ActiveContactPrice = 0,
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Direction = "direction",
                    Events =
                    [
                        new()
                        {
                            Status = "status",
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Description = "description",
                        },
                    ],
                    MessageBody = new()
                    {
                        Buttons =
                        [
                            new()
                            {
                                PostbackData = "postbackData",
                                Text = "text",
                                Type = "type",
                                Value = "value",
                            },
                        ],
                        Content = "content",
                        Footer = "footer",
                        Header = "header",
                    },
                    Phone = "phone",
                    PhoneInternational = "phone_international",
                    Price = 0,
                    RegionCode = "region_code",
                    Status = "status",
                    TemplateCategory = "template_category",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        ConversationListMessagesResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConversationListMessagesResponseDataMessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseDataMessage
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ActiveContactPrice = 0,
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Direction = "direction",
            Events =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
            MessageBody = new()
            {
                Buttons =
                [
                    new()
                    {
                        PostbackData = "postbackData",
                        Text = "text",
                        Type = "type",
                        Value = "value",
                    },
                ],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            Phone = "phone",
            PhoneInternational = "phone_international",
            Price = 0,
            RegionCode = "region_code",
            Status = "status",
            TemplateCategory = "template_category",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedActiveContactPrice = 0;
        string expectedChannel = "channel";
        string expectedContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDirection = "direction";
        List<ConversationListMessagesResponseDataMessageEvent> expectedEvents =
        [
            new()
            {
                Status = "status",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
            },
        ];
        ConversationListMessagesResponseDataMessageMessageBody expectedMessageBody = new()
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Content = "content",
            Footer = "footer",
            Header = "header",
        };
        string expectedPhone = "phone";
        string expectedPhoneInternational = "phone_international";
        double expectedPrice = 0;
        string expectedRegionCode = "region_code";
        string expectedStatus = "status";
        string expectedTemplateCategory = "template_category";
        string expectedTemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTemplateName = "template_name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedActiveContactPrice, model.ActiveContactPrice);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedContactID, model.ContactID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedDirection, model.Direction);
        Assert.NotNull(model.Events);
        Assert.Equal(expectedEvents.Count, model.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], model.Events[i]);
        }
        Assert.Equal(expectedMessageBody, model.MessageBody);
        Assert.Equal(expectedPhone, model.Phone);
        Assert.Equal(expectedPhoneInternational, model.PhoneInternational);
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedRegionCode, model.RegionCode);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTemplateCategory, model.TemplateCategory);
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.Equal(expectedTemplateName, model.TemplateName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseDataMessage
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ActiveContactPrice = 0,
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Direction = "direction",
            Events =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
            MessageBody = new()
            {
                Buttons =
                [
                    new()
                    {
                        PostbackData = "postbackData",
                        Text = "text",
                        Type = "type",
                        Value = "value",
                    },
                ],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            Phone = "phone",
            PhoneInternational = "phone_international",
            Price = 0,
            RegionCode = "region_code",
            Status = "status",
            TemplateCategory = "template_category",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationListMessagesResponseDataMessage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationListMessagesResponseDataMessage
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ActiveContactPrice = 0,
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Direction = "direction",
            Events =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
            MessageBody = new()
            {
                Buttons =
                [
                    new()
                    {
                        PostbackData = "postbackData",
                        Text = "text",
                        Type = "type",
                        Value = "value",
                    },
                ],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            Phone = "phone",
            PhoneInternational = "phone_international",
            Price = 0,
            RegionCode = "region_code",
            Status = "status",
            TemplateCategory = "template_category",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationListMessagesResponseDataMessage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedActiveContactPrice = 0;
        string expectedChannel = "channel";
        string expectedContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDirection = "direction";
        List<ConversationListMessagesResponseDataMessageEvent> expectedEvents =
        [
            new()
            {
                Status = "status",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
            },
        ];
        ConversationListMessagesResponseDataMessageMessageBody expectedMessageBody = new()
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Content = "content",
            Footer = "footer",
            Header = "header",
        };
        string expectedPhone = "phone";
        string expectedPhoneInternational = "phone_international";
        double expectedPrice = 0;
        string expectedRegionCode = "region_code";
        string expectedStatus = "status";
        string expectedTemplateCategory = "template_category";
        string expectedTemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTemplateName = "template_name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedActiveContactPrice, deserialized.ActiveContactPrice);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedContactID, deserialized.ContactID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedDirection, deserialized.Direction);
        Assert.NotNull(deserialized.Events);
        Assert.Equal(expectedEvents.Count, deserialized.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], deserialized.Events[i]);
        }
        Assert.Equal(expectedMessageBody, deserialized.MessageBody);
        Assert.Equal(expectedPhone, deserialized.Phone);
        Assert.Equal(expectedPhoneInternational, deserialized.PhoneInternational);
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedRegionCode, deserialized.RegionCode);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTemplateCategory, deserialized.TemplateCategory);
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.Equal(expectedTemplateName, deserialized.TemplateName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessage
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ActiveContactPrice = 0,
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Direction = "direction",
            Events =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
            MessageBody = new()
            {
                Buttons =
                [
                    new()
                    {
                        PostbackData = "postbackData",
                        Text = "text",
                        Type = "type",
                        Value = "value",
                    },
                ],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            Phone = "phone",
            PhoneInternational = "phone_international",
            Price = 0,
            RegionCode = "region_code",
            Status = "status",
            TemplateCategory = "template_category",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseDataMessage
        {
            ActiveContactPrice = 0,
            Events =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
            MessageBody = new()
            {
                Buttons =
                [
                    new()
                    {
                        PostbackData = "postbackData",
                        Text = "text",
                        Type = "type",
                        Value = "value",
                    },
                ],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            Price = 0,
            TemplateCategory = "template_category",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contact_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customer_id"));
        Assert.Null(model.Direction);
        Assert.False(model.RawData.ContainsKey("direction"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
        Assert.Null(model.PhoneInternational);
        Assert.False(model.RawData.ContainsKey("phone_international"));
        Assert.Null(model.RegionCode);
        Assert.False(model.RawData.ContainsKey("region_code"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessage
        {
            ActiveContactPrice = 0,
            Events =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
            MessageBody = new()
            {
                Buttons =
                [
                    new()
                    {
                        PostbackData = "postbackData",
                        Text = "text",
                        Type = "type",
                        Value = "value",
                    },
                ],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            Price = 0,
            TemplateCategory = "template_category",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseDataMessage
        {
            ActiveContactPrice = 0,
            Events =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
            MessageBody = new()
            {
                Buttons =
                [
                    new()
                    {
                        PostbackData = "postbackData",
                        Text = "text",
                        Type = "type",
                        Value = "value",
                    },
                ],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            Price = 0,
            TemplateCategory = "template_category",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Channel = null,
            ContactID = null,
            CreatedAt = null,
            CustomerID = null,
            Direction = null,
            Phone = null,
            PhoneInternational = null,
            RegionCode = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contact_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customer_id"));
        Assert.Null(model.Direction);
        Assert.False(model.RawData.ContainsKey("direction"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
        Assert.Null(model.PhoneInternational);
        Assert.False(model.RawData.ContainsKey("phone_international"));
        Assert.Null(model.RegionCode);
        Assert.False(model.RawData.ContainsKey("region_code"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessage
        {
            ActiveContactPrice = 0,
            Events =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
            MessageBody = new()
            {
                Buttons =
                [
                    new()
                    {
                        PostbackData = "postbackData",
                        Text = "text",
                        Type = "type",
                        Value = "value",
                    },
                ],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            Price = 0,
            TemplateCategory = "template_category",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Channel = null,
            ContactID = null,
            CreatedAt = null,
            CustomerID = null,
            Direction = null,
            Phone = null,
            PhoneInternational = null,
            RegionCode = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseDataMessage
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Direction = "direction",
            Phone = "phone",
            PhoneInternational = "phone_international",
            RegionCode = "region_code",
            Status = "status",
        };

        Assert.Null(model.ActiveContactPrice);
        Assert.False(model.RawData.ContainsKey("active_contact_price"));
        Assert.Null(model.Events);
        Assert.False(model.RawData.ContainsKey("events"));
        Assert.Null(model.MessageBody);
        Assert.False(model.RawData.ContainsKey("message_body"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.TemplateCategory);
        Assert.False(model.RawData.ContainsKey("template_category"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("template_id"));
        Assert.Null(model.TemplateName);
        Assert.False(model.RawData.ContainsKey("template_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessage
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Direction = "direction",
            Phone = "phone",
            PhoneInternational = "phone_international",
            RegionCode = "region_code",
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ConversationListMessagesResponseDataMessage
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Direction = "direction",
            Phone = "phone",
            PhoneInternational = "phone_international",
            RegionCode = "region_code",
            Status = "status",

            ActiveContactPrice = null,
            Events = null,
            MessageBody = null,
            Price = null,
            TemplateCategory = null,
            TemplateID = null,
            TemplateName = null,
        };

        Assert.Null(model.ActiveContactPrice);
        Assert.True(model.RawData.ContainsKey("active_contact_price"));
        Assert.Null(model.Events);
        Assert.True(model.RawData.ContainsKey("events"));
        Assert.Null(model.MessageBody);
        Assert.True(model.RawData.ContainsKey("message_body"));
        Assert.Null(model.Price);
        Assert.True(model.RawData.ContainsKey("price"));
        Assert.Null(model.TemplateCategory);
        Assert.True(model.RawData.ContainsKey("template_category"));
        Assert.Null(model.TemplateID);
        Assert.True(model.RawData.ContainsKey("template_id"));
        Assert.Null(model.TemplateName);
        Assert.True(model.RawData.ContainsKey("template_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessage
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Direction = "direction",
            Phone = "phone",
            PhoneInternational = "phone_international",
            RegionCode = "region_code",
            Status = "status",

            ActiveContactPrice = null,
            Events = null,
            MessageBody = null,
            Price = null,
            TemplateCategory = null,
            TemplateID = null,
            TemplateName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationListMessagesResponseDataMessage
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ActiveContactPrice = 0,
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Direction = "direction",
            Events =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
            MessageBody = new()
            {
                Buttons =
                [
                    new()
                    {
                        PostbackData = "postbackData",
                        Text = "text",
                        Type = "type",
                        Value = "value",
                    },
                ],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            Phone = "phone",
            PhoneInternational = "phone_international",
            Price = 0,
            RegionCode = "region_code",
            Status = "status",
            TemplateCategory = "template_category",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };

        ConversationListMessagesResponseDataMessage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConversationListMessagesResponseDataMessageEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageEvent
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        string expectedStatus = "status";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageEvent
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationListMessagesResponseDataMessageEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageEvent
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationListMessagesResponseDataMessageEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedStatus = "status";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageEvent
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageEvent
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageEvent
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageEvent
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageEvent
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageEvent
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        ConversationListMessagesResponseDataMessageEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConversationListMessagesResponseDataMessageMessageBodyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Content = "content",
            Footer = "footer",
            Header = "header",
        };

        List<ConversationListMessagesResponseDataMessageMessageBodyButton> expectedButtons =
        [
            new()
            {
                PostbackData = "postbackData",
                Text = "text",
                Type = "type",
                Value = "value",
            },
        ];
        string expectedContent = "content";
        string expectedFooter = "footer";
        string expectedHeader = "header";

        Assert.NotNull(model.Buttons);
        Assert.Equal(expectedButtons.Count, model.Buttons.Count);
        for (int i = 0; i < expectedButtons.Count; i++)
        {
            Assert.Equal(expectedButtons[i], model.Buttons[i]);
        }
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedFooter, model.Footer);
        Assert.Equal(expectedHeader, model.Header);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Content = "content",
            Footer = "footer",
            Header = "header",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationListMessagesResponseDataMessageMessageBody>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Content = "content",
            Footer = "footer",
            Header = "header",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationListMessagesResponseDataMessageMessageBody>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<ConversationListMessagesResponseDataMessageMessageBodyButton> expectedButtons =
        [
            new()
            {
                PostbackData = "postbackData",
                Text = "text",
                Type = "type",
                Value = "value",
            },
        ];
        string expectedContent = "content";
        string expectedFooter = "footer";
        string expectedHeader = "header";

        Assert.NotNull(deserialized.Buttons);
        Assert.Equal(expectedButtons.Count, deserialized.Buttons.Count);
        for (int i = 0; i < expectedButtons.Count; i++)
        {
            Assert.Equal(expectedButtons[i], deserialized.Buttons[i]);
        }
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedFooter, deserialized.Footer);
        Assert.Equal(expectedHeader, deserialized.Header);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Content = "content",
            Footer = "footer",
            Header = "header",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Footer = "footer",
            Header = "header",
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Footer = "footer",
            Header = "header",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Footer = "footer",
            Header = "header",

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Footer = "footer",
            Header = "header",

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBody
        {
            Content = "content",
        };

        Assert.Null(model.Buttons);
        Assert.False(model.RawData.ContainsKey("buttons"));
        Assert.Null(model.Footer);
        Assert.False(model.RawData.ContainsKey("footer"));
        Assert.Null(model.Header);
        Assert.False(model.RawData.ContainsKey("header"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBody
        {
            Content = "content",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBody
        {
            Content = "content",

            Buttons = null,
            Footer = null,
            Header = null,
        };

        Assert.Null(model.Buttons);
        Assert.True(model.RawData.ContainsKey("buttons"));
        Assert.Null(model.Footer);
        Assert.True(model.RawData.ContainsKey("footer"));
        Assert.Null(model.Header);
        Assert.True(model.RawData.ContainsKey("header"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBody
        {
            Content = "content",

            Buttons = null,
            Footer = null,
            Header = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Content = "content",
            Footer = "footer",
            Header = "header",
        };

        ConversationListMessagesResponseDataMessageMessageBody copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConversationListMessagesResponseDataMessageMessageBodyButtonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBodyButton
        {
            PostbackData = "postbackData",
            Text = "text",
            Type = "type",
            Value = "value",
        };

        string expectedPostbackData = "postbackData";
        string expectedText = "text";
        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedPostbackData, model.PostbackData);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBodyButton
        {
            PostbackData = "postbackData",
            Text = "text",
            Type = "type",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationListMessagesResponseDataMessageMessageBodyButton>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBodyButton
        {
            PostbackData = "postbackData",
            Text = "text",
            Type = "type",
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationListMessagesResponseDataMessageMessageBodyButton>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedPostbackData = "postbackData";
        string expectedText = "text";
        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedPostbackData, deserialized.PostbackData);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBodyButton
        {
            PostbackData = "postbackData",
            Text = "text",
            Type = "type",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBodyButton
        {
            PostbackData = "postbackData",
            Text = "text",
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBodyButton
        {
            PostbackData = "postbackData",
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBodyButton
        {
            PostbackData = "postbackData",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Type = null,
            Value = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBodyButton
        {
            PostbackData = "postbackData",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Type = null,
            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBodyButton
        {
            Type = "type",
            Value = "value",
        };

        Assert.Null(model.PostbackData);
        Assert.False(model.RawData.ContainsKey("postbackData"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBodyButton
        {
            Type = "type",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBodyButton
        {
            Type = "type",
            Value = "value",

            PostbackData = null,
            Text = null,
        };

        Assert.Null(model.PostbackData);
        Assert.True(model.RawData.ContainsKey("postbackData"));
        Assert.Null(model.Text);
        Assert.True(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBodyButton
        {
            Type = "type",
            Value = "value",

            PostbackData = null,
            Text = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationListMessagesResponseDataMessageMessageBodyButton
        {
            PostbackData = "postbackData",
            Text = "text",
            Type = "type",
            Value = "value",
        };

        ConversationListMessagesResponseDataMessageMessageBodyButton copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConversationListMessagesResponseDataPaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        ConversationListMessagesResponseDataPaginationCursors expectedCursors = new()
        {
            After = "after",
            Before = "before",
        };
        bool expectedHasMore = true;
        int expectedPage = 0;
        int expectedPageSize = 0;
        int expectedTotalCount = 0;
        int expectedTotalPages = 0;

        Assert.Equal(expectedCursors, model.Cursors);
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedPageSize, model.PageSize);
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.Equal(expectedTotalPages, model.TotalPages);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationListMessagesResponseDataPagination>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationListMessagesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationListMessagesResponseDataPagination>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ConversationListMessagesResponseDataPaginationCursors expectedCursors = new()
        {
            After = "after",
            Before = "before",
        };
        bool expectedHasMore = true;
        int expectedPage = 0;
        int expectedPageSize = 0;
        int expectedTotalCount = 0;
        int expectedTotalPages = 0;

        Assert.Equal(expectedCursors, deserialized.Cursors);
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedPageSize, deserialized.PageSize);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.Equal(expectedTotalPages, deserialized.TotalPages);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversationListMessagesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },
        };

        Assert.Null(model.HasMore);
        Assert.False(model.RawData.ContainsKey("has_more"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PageSize);
        Assert.False(model.RawData.ContainsKey("page_size"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("total_count"));
        Assert.Null(model.TotalPages);
        Assert.False(model.RawData.ContainsKey("total_pages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },

            // Null should be interpreted as omitted for these properties
            HasMore = null,
            Page = null,
            PageSize = null,
            TotalCount = null,
            TotalPages = null,
        };

        Assert.Null(model.HasMore);
        Assert.False(model.RawData.ContainsKey("has_more"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PageSize);
        Assert.False(model.RawData.ContainsKey("page_size"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("total_count"));
        Assert.Null(model.TotalPages);
        Assert.False(model.RawData.ContainsKey("total_pages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },

            // Null should be interpreted as omitted for these properties
            HasMore = null,
            Page = null,
            PageSize = null,
            TotalCount = null,
            TotalPages = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseDataPagination
        {
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.Null(model.Cursors);
        Assert.False(model.RawData.ContainsKey("cursors"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataPagination
        {
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ConversationListMessagesResponseDataPagination
        {
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,

            Cursors = null,
        };

        Assert.Null(model.Cursors);
        Assert.True(model.RawData.ContainsKey("cursors"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataPagination
        {
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,

            Cursors = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationListMessagesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        ConversationListMessagesResponseDataPagination copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConversationListMessagesResponseDataPaginationCursorsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseDataPaginationCursors
        {
            After = "after",
            Before = "before",
        };

        string expectedAfter = "after";
        string expectedBefore = "before";

        Assert.Equal(expectedAfter, model.After);
        Assert.Equal(expectedBefore, model.Before);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseDataPaginationCursors
        {
            After = "after",
            Before = "before",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationListMessagesResponseDataPaginationCursors>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationListMessagesResponseDataPaginationCursors
        {
            After = "after",
            Before = "before",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationListMessagesResponseDataPaginationCursors>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAfter = "after";
        string expectedBefore = "before";

        Assert.Equal(expectedAfter, deserialized.After);
        Assert.Equal(expectedBefore, deserialized.Before);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversationListMessagesResponseDataPaginationCursors
        {
            After = "after",
            Before = "before",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseDataPaginationCursors { };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataPaginationCursors { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ConversationListMessagesResponseDataPaginationCursors
        {
            After = null,
            Before = null,
        };

        Assert.Null(model.After);
        Assert.True(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.True(model.RawData.ContainsKey("before"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationListMessagesResponseDataPaginationCursors
        {
            After = null,
            Before = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationListMessagesResponseDataPaginationCursors
        {
            After = "after",
            Before = "before",
        };

        ConversationListMessagesResponseDataPaginationCursors copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConversationListMessagesResponseErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string expectedCode = "code";
        Dictionary<string, List<string>> expectedDetails = new() { { "foo", ["string"] } };
        string expectedDocUrl = "doc_url";
        string expectedMessage = "message";

        Assert.Equal(expectedCode, model.Code);
        Assert.NotNull(model.Details);
        Assert.Equal(expectedDetails.Count, model.Details.Count);
        foreach (var item in expectedDetails)
        {
            Assert.True(model.Details.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, model.Details[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], model.Details[item.Key][i]);
            }
        }
        Assert.Equal(expectedDocUrl, model.DocUrl);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationListMessagesResponseError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationListMessagesResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationListMessagesResponseError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCode = "code";
        Dictionary<string, List<string>> expectedDetails = new() { { "foo", ["string"] } };
        string expectedDocUrl = "doc_url";
        string expectedMessage = "message";

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.NotNull(deserialized.Details);
        Assert.Equal(expectedDetails.Count, deserialized.Details.Count);
        foreach (var item in expectedDetails)
        {
            Assert.True(deserialized.Details.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, deserialized.Details[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], deserialized.Details[item.Key][i]);
            }
        }
        Assert.Equal(expectedDocUrl, deserialized.DocUrl);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversationListMessagesResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseError
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListMessagesResponseError
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseError
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",

            // Null should be interpreted as omitted for these properties
            Code = null,
            Message = null,
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationListMessagesResponseError
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",

            // Null should be interpreted as omitted for these properties
            Code = null,
            Message = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseError
        {
            Code = "code",
            Message = "message",
        };

        Assert.Null(model.Details);
        Assert.False(model.RawData.ContainsKey("details"));
        Assert.Null(model.DocUrl);
        Assert.False(model.RawData.ContainsKey("doc_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListMessagesResponseError
        {
            Code = "code",
            Message = "message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ConversationListMessagesResponseError
        {
            Code = "code",
            Message = "message",

            Details = null,
            DocUrl = null,
        };

        Assert.Null(model.Details);
        Assert.True(model.RawData.ContainsKey("details"));
        Assert.Null(model.DocUrl);
        Assert.True(model.RawData.ContainsKey("doc_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationListMessagesResponseError
        {
            Code = "code",
            Message = "message",

            Details = null,
            DocUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationListMessagesResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        ConversationListMessagesResponseError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConversationListMessagesResponseMetaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string expectedRequestID = "request_id";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVersion = "version";

        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversationListMessagesResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationListMessagesResponseMeta>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationListMessagesResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationListMessagesResponseMeta>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRequestID = "request_id";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVersion = "version";

        Assert.Equal(expectedRequestID, deserialized.RequestID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversationListMessagesResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseMeta { };

        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListMessagesResponseMeta { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConversationListMessagesResponseMeta
        {
            // Null should be interpreted as omitted for these properties
            RequestID = null,
            Timestamp = null,
            Version = null,
        };

        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationListMessagesResponseMeta
        {
            // Null should be interpreted as omitted for these properties
            RequestID = null,
            Timestamp = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationListMessagesResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        ConversationListMessagesResponseMeta copied = new(model);

        Assert.Equal(model, copied);
    }
}
