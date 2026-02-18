using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Messages;
using Sentdm.Models.Webhooks;

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
                Body = "body",
                Recipients =
                [
                    new()
                    {
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
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        MessageSendResponseData expectedData = new()
        {
            Body = "body",
            Recipients =
            [
                new()
                {
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    To = "to",
                },
            ],
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };
        ApiError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
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
        var model = new MessageSendResponse
        {
            Data = new()
            {
                Body = "body",
                Recipients =
                [
                    new()
                    {
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
                ResponseTimeMs = 0,
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
                Body = "body",
                Recipients =
                [
                    new()
                    {
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
                ResponseTimeMs = 0,
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
            Body = "body",
            Recipients =
            [
                new()
                {
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    To = "to",
                },
            ],
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };
        ApiError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
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
        var model = new MessageSendResponse
        {
            Data = new()
            {
                Body = "body",
                Recipients =
                [
                    new()
                    {
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
        var model = new MessageSendResponse
        {
            Data = new()
            {
                Body = "body",
                Recipients =
                [
                    new()
                    {
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
                Body = "body",
                Recipients =
                [
                    new()
                    {
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
                Body = "body",
                Recipients =
                [
                    new()
                    {
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
                Body = "body",
                Recipients =
                [
                    new()
                    {
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
        var model = new MessageSendResponse
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
        var model = new MessageSendResponse
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
        var model = new MessageSendResponse
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
        var model = new MessageSendResponse
        {
            Data = new()
            {
                Body = "body",
                Recipients =
                [
                    new()
                    {
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
                ResponseTimeMs = 0,
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
            Body = "body",
            Recipients =
            [
                new()
                {
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    To = "to",
                },
            ],
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };

        string expectedBody = "body";
        List<Recipient> expectedRecipients =
        [
            new()
            {
                Channel = "channel",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                To = "to",
            },
        ];
        string expectedStatus = "status";
        string expectedTemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTemplateName = "template_name";

        Assert.Equal(expectedBody, model.Body);
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
            Body = "body",
            Recipients =
            [
                new()
                {
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
            Body = "body",
            Recipients =
            [
                new()
                {
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

        string expectedBody = "body";
        List<Recipient> expectedRecipients =
        [
            new()
            {
                Channel = "channel",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                To = "to",
            },
        ];
        string expectedStatus = "status";
        string expectedTemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTemplateName = "template_name";

        Assert.Equal(expectedBody, deserialized.Body);
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
            Body = "body",
            Recipients =
            [
                new()
                {
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
        var model = new MessageSendResponseData { Body = "body" };

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
        var model = new MessageSendResponseData { Body = "body" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageSendResponseData
        {
            Body = "body",

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
            Body = "body",

            // Null should be interpreted as omitted for these properties
            Recipients = null,
            Status = null,
            TemplateID = null,
            TemplateName = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageSendResponseData
        {
            Recipients =
            [
                new()
                {
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    To = "to",
                },
            ],
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
        };

        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageSendResponseData
        {
            Recipients =
            [
                new()
                {
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
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MessageSendResponseData
        {
            Recipients =
            [
                new()
                {
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    To = "to",
                },
            ],
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",

            Body = null,
        };

        Assert.Null(model.Body);
        Assert.True(model.RawData.ContainsKey("body"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageSendResponseData
        {
            Recipients =
            [
                new()
                {
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    To = "to",
                },
            ],
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",

            Body = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageSendResponseData
        {
            Body = "body",
            Recipients =
            [
                new()
                {
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
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",
        };

        string expectedChannel = "channel";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTo = "to";

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.Equal(expectedTo, model.To);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Recipient
        {
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

        string expectedChannel = "channel";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTo = "to";

        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.Equal(expectedTo, deserialized.To);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Recipient
        {
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Recipient { Channel = "channel" };

        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Recipient { Channel = "channel" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Recipient
        {
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

            Channel = null,
        };

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

            Channel = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Recipient
        {
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",
        };

        Recipient copied = new(model);

        Assert.Equal(model, copied);
    }
}
