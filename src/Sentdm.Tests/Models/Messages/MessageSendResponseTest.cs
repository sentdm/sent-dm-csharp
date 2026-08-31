using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Messages;

namespace Sentdm.Tests.Models.Messages;

public class MessageSendResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageSendResponse
        {
            Data = new()
            {
                Recipients =
                [
                    new()
                    {
                        Body = "body",
                        Channel = "channel",
                        MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        To = "to",
                    },
                ],
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
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

        MessageSendResponseData expectedData = new()
        {
            Recipients =
            [
                new()
                {
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    To = "to",
                },
            ],
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };
        MessageSendResponseError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        MessageSendResponseMeta expectedMeta = new()
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
        var model = new MessageSendResponse
        {
            Data = new()
            {
                Recipients =
                [
                    new()
                    {
                        Body = "body",
                        Channel = "channel",
                        MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        To = "to",
                    },
                ],
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
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
        var deserialized = JsonSerializer.Deserialize<MessageSendResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageSendResponse
        {
            Data = new()
            {
                Recipients =
                [
                    new()
                    {
                        Body = "body",
                        Channel = "channel",
                        MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        To = "to",
                    },
                ],
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
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
        var deserialized = JsonSerializer.Deserialize<MessageSendResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        MessageSendResponseData expectedData = new()
        {
            Recipients =
            [
                new()
                {
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    To = "to",
                },
            ],
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };
        MessageSendResponseError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        MessageSendResponseMeta expectedMeta = new()
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
        var model = new MessageSendResponse
        {
            Data = new()
            {
                Recipients =
                [
                    new()
                    {
                        Body = "body",
                        Channel = "channel",
                        MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        To = "to",
                    },
                ],
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
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
        var model = new MessageSendResponse
        {
            Data = new()
            {
                Recipients =
                [
                    new()
                    {
                        Body = "body",
                        Channel = "channel",
                        MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        To = "to",
                    },
                ],
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
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
        var model = new MessageSendResponse
        {
            Data = new()
            {
                Recipients =
                [
                    new()
                    {
                        Body = "body",
                        Channel = "channel",
                        MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        To = "to",
                    },
                ],
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
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
        var model = new MessageSendResponse
        {
            Data = new()
            {
                Recipients =
                [
                    new()
                    {
                        Body = "body",
                        Channel = "channel",
                        MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        To = "to",
                    },
                ],
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
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
        var model = new MessageSendResponse
        {
            Data = new()
            {
                Recipients =
                [
                    new()
                    {
                        Body = "body",
                        Channel = "channel",
                        MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        To = "to",
                    },
                ],
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
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
        var model = new MessageSendResponse
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
        var model = new MessageSendResponse
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
        var model = new MessageSendResponse
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
        var model = new MessageSendResponse
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
        var model = new MessageSendResponse
        {
            Data = new()
            {
                Recipients =
                [
                    new()
                    {
                        Body = "body",
                        Channel = "channel",
                        MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        To = "to",
                    },
                ],
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
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

        MessageSendResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MessageSendResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageSendResponseData
        {
            Recipients =
            [
                new()
                {
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    To = "to",
                },
            ],
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };

        List<Recipient> expectedRecipients =
        [
            new()
            {
                Body = "body",
                Channel = "channel",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                To = "to",
            },
        ];
        string expectedStatus = "status";
        string expectedTemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTemplateName = "template_name";

        Assert.NotNull(model.Recipients);
        Assert.Equal(expectedRecipients.Count, model.Recipients.Count);
        for (int i = 0; i < expectedRecipients.Count; i++)
        {
            Assert.Equal(expectedRecipients[i], model.Recipients[i]);
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.Equal(expectedTemplateName, model.TemplateName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageSendResponseData
        {
            Recipients =
            [
                new()
                {
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    To = "to",
                },
            ],
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageSendResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageSendResponseData
        {
            Recipients =
            [
                new()
                {
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    To = "to",
                },
            ],
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageSendResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Recipient> expectedRecipients =
        [
            new()
            {
                Body = "body",
                Channel = "channel",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                To = "to",
            },
        ];
        string expectedStatus = "status";
        string expectedTemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTemplateName = "template_name";

        Assert.NotNull(deserialized.Recipients);
        Assert.Equal(expectedRecipients.Count, deserialized.Recipients.Count);
        for (int i = 0; i < expectedRecipients.Count; i++)
        {
            Assert.Equal(expectedRecipients[i], deserialized.Recipients[i]);
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.Equal(expectedTemplateName, deserialized.TemplateName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageSendResponseData
        {
            Recipients =
            [
                new()
                {
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    To = "to",
                },
            ],
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageSendResponseData { };

        Assert.Null(model.Recipients);
        Assert.False(model.RawData.ContainsKey("recipients"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("template_id"));
        Assert.Null(model.TemplateName);
        Assert.False(model.RawData.ContainsKey("template_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageSendResponseData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageSendResponseData
        {
            // Null should be interpreted as omitted for these properties
            Recipients = null,
            Status = null,
            TemplateID = null,
            TemplateName = null,
        };

        Assert.Null(model.Recipients);
        Assert.False(model.RawData.ContainsKey("recipients"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("template_id"));
        Assert.Null(model.TemplateName);
        Assert.False(model.RawData.ContainsKey("template_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageSendResponseData
        {
            // Null should be interpreted as omitted for these properties
            Recipients = null,
            Status = null,
            TemplateID = null,
            TemplateName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageSendResponseData
        {
            Recipients =
            [
                new()
                {
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    To = "to",
                },
            ],
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };

        MessageSendResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RecipientTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Recipient
        {
            Body = "body",
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",
        };

        string expectedBody = "body";
        string expectedChannel = "channel";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTo = "to";

        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.Equal(expectedTo, model.To);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Recipient
        {
            Body = "body",
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Recipient>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Recipient
        {
            Body = "body",
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Recipient>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBody = "body";
        string expectedChannel = "channel";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTo = "to";

        Assert.Equal(expectedBody, deserialized.Body);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.Equal(expectedTo, deserialized.To);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Recipient
        {
            Body = "body",
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Recipient { Body = "body", Channel = "channel" };

        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Recipient { Body = "body", Channel = "channel" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Recipient
        {
            Body = "body",
            Channel = "channel",

            // Null should be interpreted as omitted for these properties
            MessageID = null,
            To = null,
        };

        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Recipient
        {
            Body = "body",
            Channel = "channel",

            // Null should be interpreted as omitted for these properties
            MessageID = null,
            To = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Recipient { MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e", To = "to" };

        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Recipient { MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e", To = "to" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Recipient
        {
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",

            Body = null,
            Channel = null,
        };

        Assert.Null(model.Body);
        Assert.True(model.RawData.ContainsKey("body"));
        Assert.Null(model.Channel);
        Assert.True(model.RawData.ContainsKey("channel"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Recipient
        {
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",

            Body = null,
            Channel = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Recipient
        {
            Body = "body",
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",
        };

        Recipient copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MessageSendResponseErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageSendResponseError
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
        var model = new MessageSendResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageSendResponseError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageSendResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageSendResponseError>(
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
        var model = new MessageSendResponseError
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
        var model = new MessageSendResponseError
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
        var model = new MessageSendResponseError
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageSendResponseError
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
        var model = new MessageSendResponseError
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
        var model = new MessageSendResponseError { Code = "code", Message = "message" };

        Assert.Null(model.Details);
        Assert.False(model.RawData.ContainsKey("details"));
        Assert.Null(model.DocUrl);
        Assert.False(model.RawData.ContainsKey("doc_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageSendResponseError { Code = "code", Message = "message" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MessageSendResponseError
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
        var model = new MessageSendResponseError
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
        var model = new MessageSendResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        MessageSendResponseError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MessageSendResponseMetaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageSendResponseMeta
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
        var model = new MessageSendResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageSendResponseMeta>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageSendResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageSendResponseMeta>(
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
        var model = new MessageSendResponseMeta
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
        var model = new MessageSendResponseMeta { };

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
        var model = new MessageSendResponseMeta { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageSendResponseMeta
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
        var model = new MessageSendResponseMeta
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
        var model = new MessageSendResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        MessageSendResponseMeta copied = new(model);

        Assert.Equal(model, copied);
    }
}
