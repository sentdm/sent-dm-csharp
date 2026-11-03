using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Messages;

namespace Sentdm.Tests.Models.Messages;

public class MessageResendResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageResendResponseData
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
        var model = new MessageResendResponseData
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
        var deserialized = JsonSerializer.Deserialize<MessageResendResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageResendResponseData
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
        var deserialized = JsonSerializer.Deserialize<MessageResendResponseData>(
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
        var model = new MessageResendResponseData
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
        var model = new MessageResendResponseData { };

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
        var model = new MessageResendResponseData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageResendResponseData
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
        var model = new MessageResendResponseData
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
        var model = new MessageResendResponseData
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

        MessageResendResponseData copied = new(model);

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
