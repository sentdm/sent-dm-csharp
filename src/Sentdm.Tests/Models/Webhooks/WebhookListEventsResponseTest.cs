using System;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookListEventsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListEventsResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            ErrorMessage = "error_message",
            EventData = new MessageEvent()
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    MessageStatus = "message_status",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AgentID = "agent_id",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                Timestamp = "timestamp",
            },
            EventType = "event_type",
            HttpStatusCode = 0,
            ProcessingCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProcessingStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResponseBody = "response_body",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedDeliveryAttempts = 0;
        string expectedDeliveryStatus = "delivery_status";
        string expectedErrorMessage = "error_message";
        EventData expectedEventData = new MessageEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                MessageStatus = "message_status",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AgentID = "agent_id",
                Channel = "channel",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OutboundNumber = "outbound_number",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                UpdatedAt = "updated_at",
            },
            Timestamp = "timestamp",
        };
        string expectedEventType = "event_type";
        int expectedHttpStatusCode = 0;
        DateTimeOffset expectedProcessingCompletedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedProcessingStartedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedResponseBody = "response_body";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeliveryAttempts, model.DeliveryAttempts);
        Assert.Equal(expectedDeliveryStatus, model.DeliveryStatus);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedEventData, model.EventData);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedHttpStatusCode, model.HttpStatusCode);
        Assert.Equal(expectedProcessingCompletedAt, model.ProcessingCompletedAt);
        Assert.Equal(expectedProcessingStartedAt, model.ProcessingStartedAt);
        Assert.Equal(expectedResponseBody, model.ResponseBody);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookListEventsResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            ErrorMessage = "error_message",
            EventData = new MessageEvent()
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    MessageStatus = "message_status",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AgentID = "agent_id",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                Timestamp = "timestamp",
            },
            EventType = "event_type",
            HttpStatusCode = 0,
            ProcessingCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProcessingStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResponseBody = "response_body",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListEventsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListEventsResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            ErrorMessage = "error_message",
            EventData = new MessageEvent()
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    MessageStatus = "message_status",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AgentID = "agent_id",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                Timestamp = "timestamp",
            },
            EventType = "event_type",
            HttpStatusCode = 0,
            ProcessingCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProcessingStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResponseBody = "response_body",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListEventsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedDeliveryAttempts = 0;
        string expectedDeliveryStatus = "delivery_status";
        string expectedErrorMessage = "error_message";
        EventData expectedEventData = new MessageEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                MessageStatus = "message_status",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AgentID = "agent_id",
                Channel = "channel",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OutboundNumber = "outbound_number",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                UpdatedAt = "updated_at",
            },
            Timestamp = "timestamp",
        };
        string expectedEventType = "event_type";
        int expectedHttpStatusCode = 0;
        DateTimeOffset expectedProcessingCompletedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedProcessingStartedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedResponseBody = "response_body";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeliveryAttempts, deserialized.DeliveryAttempts);
        Assert.Equal(expectedDeliveryStatus, deserialized.DeliveryStatus);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedEventData, deserialized.EventData);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedHttpStatusCode, deserialized.HttpStatusCode);
        Assert.Equal(expectedProcessingCompletedAt, deserialized.ProcessingCompletedAt);
        Assert.Equal(expectedProcessingStartedAt, deserialized.ProcessingStartedAt);
        Assert.Equal(expectedResponseBody, deserialized.ResponseBody);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookListEventsResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            ErrorMessage = "error_message",
            EventData = new MessageEvent()
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    MessageStatus = "message_status",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AgentID = "agent_id",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                Timestamp = "timestamp",
            },
            EventType = "event_type",
            HttpStatusCode = 0,
            ProcessingCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProcessingStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResponseBody = "response_body",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookListEventsResponse
        {
            ErrorMessage = "error_message",
            HttpStatusCode = 0,
            ProcessingCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProcessingStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResponseBody = "response_body",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DeliveryAttempts);
        Assert.False(model.RawData.ContainsKey("delivery_attempts"));
        Assert.Null(model.DeliveryStatus);
        Assert.False(model.RawData.ContainsKey("delivery_status"));
        Assert.Null(model.EventData);
        Assert.False(model.RawData.ContainsKey("event_data"));
        Assert.Null(model.EventType);
        Assert.False(model.RawData.ContainsKey("event_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookListEventsResponse
        {
            ErrorMessage = "error_message",
            HttpStatusCode = 0,
            ProcessingCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProcessingStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResponseBody = "response_body",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookListEventsResponse
        {
            ErrorMessage = "error_message",
            HttpStatusCode = 0,
            ProcessingCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProcessingStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResponseBody = "response_body",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            DeliveryAttempts = null,
            DeliveryStatus = null,
            EventData = null,
            EventType = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DeliveryAttempts);
        Assert.False(model.RawData.ContainsKey("delivery_attempts"));
        Assert.Null(model.DeliveryStatus);
        Assert.False(model.RawData.ContainsKey("delivery_status"));
        Assert.Null(model.EventData);
        Assert.False(model.RawData.ContainsKey("event_data"));
        Assert.Null(model.EventType);
        Assert.False(model.RawData.ContainsKey("event_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookListEventsResponse
        {
            ErrorMessage = "error_message",
            HttpStatusCode = 0,
            ProcessingCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProcessingStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResponseBody = "response_body",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            DeliveryAttempts = null,
            DeliveryStatus = null,
            EventData = null,
            EventType = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookListEventsResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            EventData = new MessageEvent()
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    MessageStatus = "message_status",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AgentID = "agent_id",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                Timestamp = "timestamp",
            },
            EventType = "event_type",
        };

        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.HttpStatusCode);
        Assert.False(model.RawData.ContainsKey("http_status_code"));
        Assert.Null(model.ProcessingCompletedAt);
        Assert.False(model.RawData.ContainsKey("processing_completed_at"));
        Assert.Null(model.ProcessingStartedAt);
        Assert.False(model.RawData.ContainsKey("processing_started_at"));
        Assert.Null(model.ResponseBody);
        Assert.False(model.RawData.ContainsKey("response_body"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookListEventsResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            EventData = new MessageEvent()
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    MessageStatus = "message_status",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AgentID = "agent_id",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                Timestamp = "timestamp",
            },
            EventType = "event_type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookListEventsResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            EventData = new MessageEvent()
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    MessageStatus = "message_status",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AgentID = "agent_id",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                Timestamp = "timestamp",
            },
            EventType = "event_type",

            ErrorMessage = null,
            HttpStatusCode = null,
            ProcessingCompletedAt = null,
            ProcessingStartedAt = null,
            ResponseBody = null,
        };

        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.HttpStatusCode);
        Assert.True(model.RawData.ContainsKey("http_status_code"));
        Assert.Null(model.ProcessingCompletedAt);
        Assert.True(model.RawData.ContainsKey("processing_completed_at"));
        Assert.Null(model.ProcessingStartedAt);
        Assert.True(model.RawData.ContainsKey("processing_started_at"));
        Assert.Null(model.ResponseBody);
        Assert.True(model.RawData.ContainsKey("response_body"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookListEventsResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            EventData = new MessageEvent()
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    MessageStatus = "message_status",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AgentID = "agent_id",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                Timestamp = "timestamp",
            },
            EventType = "event_type",

            ErrorMessage = null,
            HttpStatusCode = null,
            ProcessingCompletedAt = null,
            ProcessingStartedAt = null,
            ResponseBody = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookListEventsResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            ErrorMessage = "error_message",
            EventData = new MessageEvent()
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    MessageStatus = "message_status",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AgentID = "agent_id",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                Timestamp = "timestamp",
            },
            EventType = "event_type",
            HttpStatusCode = 0,
            ProcessingCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProcessingStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResponseBody = "response_body",
        };

        WebhookListEventsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventDataTest : TestBase
{
    [Fact]
    public void MessageEventValidationWorks()
    {
        EventData value = new MessageEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                MessageStatus = "message_status",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AgentID = "agent_id",
                Channel = "channel",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OutboundNumber = "outbound_number",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                UpdatedAt = "updated_at",
            },
            Timestamp = "timestamp",
        };
        value.Validate();
    }

    [Fact]
    public void InboundMessageEventValidationWorks()
    {
        EventData value = new InboundMessageEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                InboundNumber = "inbound_number",
                ReceivedAt = "received_at",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Channel = "channel",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OutboundNumber = "outbound_number",
                Text = "text",
                UpdatedAt = "updated_at",
            },
            Timestamp = "timestamp",
        };
        value.Validate();
    }

    [Fact]
    public void TemplateEventValidationWorks()
    {
        EventData value = new TemplateEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                Status = "status",
                WhatsappTemplateID = "whatsapp_template_id",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channel = "channel",
                Language = "language",
                Reason = "reason",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
            },
            Timestamp = "timestamp",
        };
        value.Validate();
    }

    [Fact]
    public void MessageEventSerializationRoundtripWorks()
    {
        EventData value = new MessageEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                MessageStatus = "message_status",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AgentID = "agent_id",
                Channel = "channel",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OutboundNumber = "outbound_number",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                UpdatedAt = "updated_at",
            },
            Timestamp = "timestamp",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InboundMessageEventSerializationRoundtripWorks()
    {
        EventData value = new InboundMessageEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                InboundNumber = "inbound_number",
                ReceivedAt = "received_at",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Channel = "channel",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OutboundNumber = "outbound_number",
                Text = "text",
                UpdatedAt = "updated_at",
            },
            Timestamp = "timestamp",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TemplateEventSerializationRoundtripWorks()
    {
        EventData value = new TemplateEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                Status = "status",
                WhatsappTemplateID = "whatsapp_template_id",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channel = "channel",
                Language = "language",
                Reason = "reason",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
            },
            Timestamp = "timestamp",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
