using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class TemplateEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateEvent
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channel = "channel",
                Language = "language",
                Reason = "reason",
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                WhatsappTemplateID = "whatsapp_template_id",
            },
            Timestamp = "timestamp",
        };

        string expectedEvent = "event";
        string expectedField = "field";
        TemplateEventPayload expectedPayload = new()
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channel = "channel",
            Language = "language",
            Reason = "reason",
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
            WhatsappTemplateID = "whatsapp_template_id",
        };
        string expectedTimestamp = "timestamp";

        Assert.Equal(expectedEvent, model.Event);
        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedPayload, model.Payload);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateEvent
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channel = "channel",
                Language = "language",
                Reason = "reason",
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                WhatsappTemplateID = "whatsapp_template_id",
            },
            Timestamp = "timestamp",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateEvent
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channel = "channel",
                Language = "language",
                Reason = "reason",
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                WhatsappTemplateID = "whatsapp_template_id",
            },
            Timestamp = "timestamp",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEvent = "event";
        string expectedField = "field";
        TemplateEventPayload expectedPayload = new()
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channel = "channel",
            Language = "language",
            Reason = "reason",
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
            WhatsappTemplateID = "whatsapp_template_id",
        };
        string expectedTimestamp = "timestamp";

        Assert.Equal(expectedEvent, deserialized.Event);
        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedPayload, deserialized.Payload);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateEvent
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channel = "channel",
                Language = "language",
                Reason = "reason",
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                WhatsappTemplateID = "whatsapp_template_id",
            },
            Timestamp = "timestamp",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateEvent
        {
            Event = "event",
            Payload = new()
            {
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channel = "channel",
                Language = "language",
                Reason = "reason",
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                WhatsappTemplateID = "whatsapp_template_id",
            },
        };

        Assert.Null(model.Field);
        Assert.False(model.RawData.ContainsKey("field"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateEvent
        {
            Event = "event",
            Payload = new()
            {
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channel = "channel",
                Language = "language",
                Reason = "reason",
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                WhatsappTemplateID = "whatsapp_template_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplateEvent
        {
            Event = "event",
            Payload = new()
            {
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channel = "channel",
                Language = "language",
                Reason = "reason",
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                WhatsappTemplateID = "whatsapp_template_id",
            },

            // Null should be interpreted as omitted for these properties
            Field = null,
            Timestamp = null,
        };

        Assert.Null(model.Field);
        Assert.False(model.RawData.ContainsKey("field"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateEvent
        {
            Event = "event",
            Payload = new()
            {
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channel = "channel",
                Language = "language",
                Reason = "reason",
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                WhatsappTemplateID = "whatsapp_template_id",
            },

            // Null should be interpreted as omitted for these properties
            Field = null,
            Timestamp = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateEvent { Field = "field", Timestamp = "timestamp" };

        Assert.Null(model.Event);
        Assert.False(model.RawData.ContainsKey("event"));
        Assert.Null(model.Payload);
        Assert.False(model.RawData.ContainsKey("payload"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateEvent { Field = "field", Timestamp = "timestamp" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateEvent
        {
            Field = "field",
            Timestamp = "timestamp",

            Event = null,
            Payload = null,
        };

        Assert.Null(model.Event);
        Assert.True(model.RawData.ContainsKey("event"));
        Assert.Null(model.Payload);
        Assert.True(model.RawData.ContainsKey("payload"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateEvent
        {
            Field = "field",
            Timestamp = "timestamp",

            Event = null,
            Payload = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateEvent
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channel = "channel",
                Language = "language",
                Reason = "reason",
                Status = "status",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                WhatsappTemplateID = "whatsapp_template_id",
            },
            Timestamp = "timestamp",
        };

        TemplateEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
