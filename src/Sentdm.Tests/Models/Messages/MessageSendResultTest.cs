using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Messages;

namespace Sentdm.Tests.Models.Messages;

public class MessageSendResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageSendResult
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

        List<MessageRecipient> expectedRecipients =
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
        var model = new MessageSendResult
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
        var deserialized = JsonSerializer.Deserialize<MessageSendResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageSendResult
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
        var deserialized = JsonSerializer.Deserialize<MessageSendResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<MessageRecipient> expectedRecipients =
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
        var model = new MessageSendResult
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
        var model = new MessageSendResult { };

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
        var model = new MessageSendResult { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageSendResult
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
        var model = new MessageSendResult
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
        var model = new MessageSendResult
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

        MessageSendResult copied = new(model);

        Assert.Equal(model, copied);
    }
}
