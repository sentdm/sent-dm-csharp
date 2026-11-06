using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Conversations;
using Sentdm.Models.Messages;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Conversations;

public class ConversationMessagesListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationMessagesList
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
                            Reason = "reason",
                            ReasonCode = "reason_code",
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
                        HeaderMedia = new() { Type = "type", Url = "url" },
                        Media =
                        [
                            new()
                            {
                                MediaType = "mediaType",
                                MimeType = "mimeType",
                                SizeBytes = 0,
                                SourceHashSha256 = "sourceHashSha256",
                                Url = "url",
                            },
                        ],
                        Subject = "subject",
                    },
                    Phone = "phone",
                    PhoneInternational = "phone_international",
                    Price = 0,
                    Reason = "reason",
                    ReasonCode = "reason_code",
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

        List<Message> expectedMessages =
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
                        Reason = "reason",
                        ReasonCode = "reason_code",
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
                    HeaderMedia = new() { Type = "type", Url = "url" },
                    Media =
                    [
                        new()
                        {
                            MediaType = "mediaType",
                            MimeType = "mimeType",
                            SizeBytes = 0,
                            SourceHashSha256 = "sourceHashSha256",
                            Url = "url",
                        },
                    ],
                    Subject = "subject",
                },
                Phone = "phone",
                PhoneInternational = "phone_international",
                Price = 0,
                Reason = "reason",
                ReasonCode = "reason_code",
                RegionCode = "region_code",
                Status = "status",
                TemplateCategory = "template_category",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
            },
        ];
        PaginationMeta expectedPagination = new()
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
        var model = new ConversationMessagesList
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
                            Reason = "reason",
                            ReasonCode = "reason_code",
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
                        HeaderMedia = new() { Type = "type", Url = "url" },
                        Media =
                        [
                            new()
                            {
                                MediaType = "mediaType",
                                MimeType = "mimeType",
                                SizeBytes = 0,
                                SourceHashSha256 = "sourceHashSha256",
                                Url = "url",
                            },
                        ],
                        Subject = "subject",
                    },
                    Phone = "phone",
                    PhoneInternational = "phone_international",
                    Price = 0,
                    Reason = "reason",
                    ReasonCode = "reason_code",
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
        var deserialized = JsonSerializer.Deserialize<ConversationMessagesList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationMessagesList
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
                            Reason = "reason",
                            ReasonCode = "reason_code",
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
                        HeaderMedia = new() { Type = "type", Url = "url" },
                        Media =
                        [
                            new()
                            {
                                MediaType = "mediaType",
                                MimeType = "mimeType",
                                SizeBytes = 0,
                                SourceHashSha256 = "sourceHashSha256",
                                Url = "url",
                            },
                        ],
                        Subject = "subject",
                    },
                    Phone = "phone",
                    PhoneInternational = "phone_international",
                    Price = 0,
                    Reason = "reason",
                    ReasonCode = "reason_code",
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
        var deserialized = JsonSerializer.Deserialize<ConversationMessagesList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Message> expectedMessages =
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
                        Reason = "reason",
                        ReasonCode = "reason_code",
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
                    HeaderMedia = new() { Type = "type", Url = "url" },
                    Media =
                    [
                        new()
                        {
                            MediaType = "mediaType",
                            MimeType = "mimeType",
                            SizeBytes = 0,
                            SourceHashSha256 = "sourceHashSha256",
                            Url = "url",
                        },
                    ],
                    Subject = "subject",
                },
                Phone = "phone",
                PhoneInternational = "phone_international",
                Price = 0,
                Reason = "reason",
                ReasonCode = "reason_code",
                RegionCode = "region_code",
                Status = "status",
                TemplateCategory = "template_category",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
            },
        ];
        PaginationMeta expectedPagination = new()
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
        var model = new ConversationMessagesList
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
                            Reason = "reason",
                            ReasonCode = "reason_code",
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
                        HeaderMedia = new() { Type = "type", Url = "url" },
                        Media =
                        [
                            new()
                            {
                                MediaType = "mediaType",
                                MimeType = "mimeType",
                                SizeBytes = 0,
                                SourceHashSha256 = "sourceHashSha256",
                                Url = "url",
                            },
                        ],
                        Subject = "subject",
                    },
                    Phone = "phone",
                    PhoneInternational = "phone_international",
                    Price = 0,
                    Reason = "reason",
                    ReasonCode = "reason_code",
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
        var model = new ConversationMessagesList { };

        Assert.Null(model.Messages);
        Assert.False(model.RawData.ContainsKey("messages"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationMessagesList { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConversationMessagesList
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
        var model = new ConversationMessagesList
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
        var model = new ConversationMessagesList
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
                            Reason = "reason",
                            ReasonCode = "reason_code",
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
                        HeaderMedia = new() { Type = "type", Url = "url" },
                        Media =
                        [
                            new()
                            {
                                MediaType = "mediaType",
                                MimeType = "mimeType",
                                SizeBytes = 0,
                                SourceHashSha256 = "sourceHashSha256",
                                Url = "url",
                            },
                        ],
                        Subject = "subject",
                    },
                    Phone = "phone",
                    PhoneInternational = "phone_international",
                    Price = 0,
                    Reason = "reason",
                    ReasonCode = "reason_code",
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

        ConversationMessagesList copied = new(model);

        Assert.Equal(model, copied);
    }
}
