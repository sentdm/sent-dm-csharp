using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Messages;

namespace Sentdm.Tests.Models.Messages;

public class MessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Message
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
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedActiveContactPrice = 0;
        string expectedChannel = "channel";
        string expectedContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDirection = "direction";
        List<MessageStatusEvent> expectedEvents =
        [
            new()
            {
                Status = "status",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Reason = "reason",
                ReasonCode = "reason_code",
            },
        ];
        MessageBody expectedMessageBody = new()
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
        };
        string expectedPhone = "phone";
        string expectedPhoneInternational = "phone_international";
        double expectedPrice = 0;
        string expectedReason = "reason";
        string expectedReasonCode = "reason_code";
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
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReasonCode, model.ReasonCode);
        Assert.Equal(expectedRegionCode, model.RegionCode);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTemplateCategory, model.TemplateCategory);
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.Equal(expectedTemplateName, model.TemplateName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Message
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Message
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(
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
        List<MessageStatusEvent> expectedEvents =
        [
            new()
            {
                Status = "status",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Reason = "reason",
                ReasonCode = "reason_code",
            },
        ];
        MessageBody expectedMessageBody = new()
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
        };
        string expectedPhone = "phone";
        string expectedPhoneInternational = "phone_international";
        double expectedPrice = 0;
        string expectedReason = "reason";
        string expectedReasonCode = "reason_code";
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
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReasonCode, deserialized.ReasonCode);
        Assert.Equal(expectedRegionCode, deserialized.RegionCode);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTemplateCategory, deserialized.TemplateCategory);
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.Equal(expectedTemplateName, deserialized.TemplateName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Message
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Message
        {
            ActiveContactPrice = 0,
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
            Price = 0,
            Reason = "reason",
            ReasonCode = "reason_code",
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
        var model = new Message
        {
            ActiveContactPrice = 0,
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
            Price = 0,
            Reason = "reason",
            ReasonCode = "reason_code",
            TemplateCategory = "template_category",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Message
        {
            ActiveContactPrice = 0,
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
            Price = 0,
            Reason = "reason",
            ReasonCode = "reason_code",
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
        var model = new Message
        {
            ActiveContactPrice = 0,
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
            Price = 0,
            Reason = "reason",
            ReasonCode = "reason_code",
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
        var model = new Message
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
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.ReasonCode);
        Assert.False(model.RawData.ContainsKey("reason_code"));
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
        var model = new Message
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
        var model = new Message
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
            Reason = null,
            ReasonCode = null,
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
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.ReasonCode);
        Assert.True(model.RawData.ContainsKey("reason_code"));
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
        var model = new Message
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
            Reason = null,
            ReasonCode = null,
            TemplateCategory = null,
            TemplateID = null,
            TemplateName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Message
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
        };

        Message copied = new(model);

        Assert.Equal(model, copied);
    }
}
