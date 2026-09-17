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
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
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
                Body = "body",
                Channel = "channel",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OutboundNumber = "outbound_number",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                UpdatedAt = "updated_at",
            },
            RequestID = "request_id",
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
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
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
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
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
                Body = "body",
                Channel = "channel",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OutboundNumber = "outbound_number",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                UpdatedAt = "updated_at",
            },
            RequestID = "request_id",
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
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
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
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
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
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
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
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
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
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
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
                    Body = "body",
                    Channel = "channel",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OutboundNumber = "outbound_number",
                    TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TemplateName = "template_name",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
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
                Body = "body",
                Channel = "channel",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OutboundNumber = "outbound_number",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                UpdatedAt = "updated_at",
            },
            RequestID = "request_id",
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
            RequestID = "request_id",
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
                AutoReplyAction = "auto_reply_action",
                Category = "category",
                Channel = "channel",
                Language = "language",
                Reason = "reason",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
            },
            RequestID = "request_id",
            Timestamp = "timestamp",
        };
        value.Validate();
    }

    [Fact]
    public void SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayloadValidationWorks()
    {
        EventData value =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload()
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    Country = "country",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    NumberType = "number_type",
                    Reason = "reason",
                    SenderValue = "sender_value",
                    Status = "status",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
                Timestamp = "timestamp",
            };
        value.Validate();
    }

    [Fact]
    public void SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadValidationWorks()
    {
        EventData value =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload()
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    OptOut = true,
                    Source = "source",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PhoneNumber = "phone_number",
                    Text = "text",
                },
                RequestID = "request_id",
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
                Body = "body",
                Channel = "channel",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OutboundNumber = "outbound_number",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
                UpdatedAt = "updated_at",
            },
            RequestID = "request_id",
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
            RequestID = "request_id",
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
                AutoReplyAction = "auto_reply_action",
                Category = "category",
                Channel = "channel",
                Language = "language",
                Reason = "reason",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateName = "template_name",
            },
            RequestID = "request_id",
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
    public void SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayloadSerializationRoundtripWorks()
    {
        EventData value =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload()
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    Country = "country",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    NumberType = "number_type",
                    Reason = "reason",
                    SenderValue = "sender_value",
                    Status = "status",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
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
    public void SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadSerializationRoundtripWorks()
    {
        EventData value =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload()
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    OptOut = true,
                    Source = "source",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PhoneNumber = "phone_number",
                    Text = "text",
                },
                RequestID = "request_id",
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

public class SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayloadTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    Country = "country",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    NumberType = "number_type",
                    Reason = "reason",
                    SenderValue = "sender_value",
                    Status = "status",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
                Timestamp = "timestamp",
            };

        string expectedEvent = "event";
        string expectedField = "field";
        Payload expectedPayload = new()
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
            Status = "status",
            UpdatedAt = "updated_at",
        };
        string expectedRequestID = "request_id";
        string expectedTimestamp = "timestamp";

        Assert.Equal(expectedEvent, model.Event);
        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedPayload, model.Payload);
        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    Country = "country",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    NumberType = "number_type",
                    Reason = "reason",
                    SenderValue = "sender_value",
                    Status = "status",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
                Timestamp = "timestamp",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    Country = "country",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    NumberType = "number_type",
                    Reason = "reason",
                    SenderValue = "sender_value",
                    Status = "status",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
                Timestamp = "timestamp",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedEvent = "event";
        string expectedField = "field";
        Payload expectedPayload = new()
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
            Status = "status",
            UpdatedAt = "updated_at",
        };
        string expectedRequestID = "request_id";
        string expectedTimestamp = "timestamp";

        Assert.Equal(expectedEvent, deserialized.Event);
        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedPayload, deserialized.Payload);
        Assert.Equal(expectedRequestID, deserialized.RequestID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    Country = "country",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    NumberType = "number_type",
                    Reason = "reason",
                    SenderValue = "sender_value",
                    Status = "status",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
                Timestamp = "timestamp",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload
            {
                Event = "event",
                Payload = new()
                {
                    Country = "country",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    NumberType = "number_type",
                    Reason = "reason",
                    SenderValue = "sender_value",
                    Status = "status",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
            };

        Assert.Null(model.Field);
        Assert.False(model.RawData.ContainsKey("field"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload
            {
                Event = "event",
                Payload = new()
                {
                    Country = "country",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    NumberType = "number_type",
                    Reason = "reason",
                    SenderValue = "sender_value",
                    Status = "status",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload
            {
                Event = "event",
                Payload = new()
                {
                    Country = "country",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    NumberType = "number_type",
                    Reason = "reason",
                    SenderValue = "sender_value",
                    Status = "status",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",

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
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload
            {
                Event = "event",
                Payload = new()
                {
                    Country = "country",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    NumberType = "number_type",
                    Reason = "reason",
                    SenderValue = "sender_value",
                    Status = "status",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",

                // Null should be interpreted as omitted for these properties
                Field = null,
                Timestamp = null,
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload
            {
                Field = "field",
                Timestamp = "timestamp",
            };

        Assert.Null(model.Event);
        Assert.False(model.RawData.ContainsKey("event"));
        Assert.Null(model.Payload);
        Assert.False(model.RawData.ContainsKey("payload"));
        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload
            {
                Field = "field",
                Timestamp = "timestamp",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload
            {
                Field = "field",
                Timestamp = "timestamp",

                Event = null,
                Payload = null,
                RequestID = null,
            };

        Assert.Null(model.Event);
        Assert.True(model.RawData.ContainsKey("event"));
        Assert.Null(model.Payload);
        Assert.True(model.RawData.ContainsKey("payload"));
        Assert.Null(model.RequestID);
        Assert.True(model.RawData.ContainsKey("request_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload
            {
                Field = "field",
                Timestamp = "timestamp",

                Event = null,
                Payload = null,
                RequestID = null,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    Country = "country",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    NumberType = "number_type",
                    Reason = "reason",
                    SenderValue = "sender_value",
                    Status = "status",
                    UpdatedAt = "updated_at",
                },
                RequestID = "request_id",
                Timestamp = "timestamp",
            };

        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfChannelWebhookPayload copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class PayloadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Payload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
            Status = "status",
            UpdatedAt = "updated_at",
        };

        string expectedCountry = "country";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        string expectedNumberType = "number_type";
        string expectedReason = "reason";
        string expectedSenderValue = "sender_value";
        string expectedStatus = "status";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedNumberType, model.NumberType);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedSenderValue, model.SenderValue);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Payload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
            Status = "status",
            UpdatedAt = "updated_at",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Payload>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Payload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
            Status = "status",
            UpdatedAt = "updated_at",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Payload>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCountry = "country";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        string expectedNumberType = "number_type";
        string expectedReason = "reason";
        string expectedSenderValue = "sender_value";
        string expectedStatus = "status";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedNumberType, deserialized.NumberType);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedSenderValue, deserialized.SenderValue);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Payload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
            Status = "status",
            UpdatedAt = "updated_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Payload
        {
            Country = "country",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Payload
        {
            Country = "country",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Payload
        {
            Country = "country",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Channel = null,
            Status = null,
            UpdatedAt = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Payload
        {
            Country = "country",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Channel = null,
            Status = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Payload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Status = "status",
            UpdatedAt = "updated_at",
        };

        Assert.Null(model.NumberType);
        Assert.False(model.RawData.ContainsKey("number_type"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.SenderValue);
        Assert.False(model.RawData.ContainsKey("sender_value"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Payload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Status = "status",
            UpdatedAt = "updated_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Payload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Status = "status",
            UpdatedAt = "updated_at",

            NumberType = null,
            Reason = null,
            SenderValue = null,
        };

        Assert.Null(model.NumberType);
        Assert.True(model.RawData.ContainsKey("number_type"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.SenderValue);
        Assert.True(model.RawData.ContainsKey("sender_value"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Payload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Status = "status",
            UpdatedAt = "updated_at",

            NumberType = null,
            Reason = null,
            SenderValue = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Payload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
            Status = "status",
            UpdatedAt = "updated_at",
        };

        Payload copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    OptOut = true,
                    Source = "source",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PhoneNumber = "phone_number",
                    Text = "text",
                },
                RequestID = "request_id",
                Timestamp = "timestamp",
            };

        string expectedEvent = "event";
        string expectedField = "field";
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload expectedPayload =
            new()
            {
                OptOut = true,
                Source = "source",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Channel = "channel",
                ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PhoneNumber = "phone_number",
                Text = "text",
            };
        string expectedRequestID = "request_id";
        string expectedTimestamp = "timestamp";

        Assert.Equal(expectedEvent, model.Event);
        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedPayload, model.Payload);
        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    OptOut = true,
                    Source = "source",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PhoneNumber = "phone_number",
                    Text = "text",
                },
                RequestID = "request_id",
                Timestamp = "timestamp",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    OptOut = true,
                    Source = "source",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PhoneNumber = "phone_number",
                    Text = "text",
                },
                RequestID = "request_id",
                Timestamp = "timestamp",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedEvent = "event";
        string expectedField = "field";
        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload expectedPayload =
            new()
            {
                OptOut = true,
                Source = "source",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Channel = "channel",
                ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PhoneNumber = "phone_number",
                Text = "text",
            };
        string expectedRequestID = "request_id";
        string expectedTimestamp = "timestamp";

        Assert.Equal(expectedEvent, deserialized.Event);
        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedPayload, deserialized.Payload);
        Assert.Equal(expectedRequestID, deserialized.RequestID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    OptOut = true,
                    Source = "source",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PhoneNumber = "phone_number",
                    Text = "text",
                },
                RequestID = "request_id",
                Timestamp = "timestamp",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
            {
                Event = "event",
                Payload = new()
                {
                    OptOut = true,
                    Source = "source",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PhoneNumber = "phone_number",
                    Text = "text",
                },
                RequestID = "request_id",
            };

        Assert.Null(model.Field);
        Assert.False(model.RawData.ContainsKey("field"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
            {
                Event = "event",
                Payload = new()
                {
                    OptOut = true,
                    Source = "source",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PhoneNumber = "phone_number",
                    Text = "text",
                },
                RequestID = "request_id",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
            {
                Event = "event",
                Payload = new()
                {
                    OptOut = true,
                    Source = "source",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PhoneNumber = "phone_number",
                    Text = "text",
                },
                RequestID = "request_id",

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
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
            {
                Event = "event",
                Payload = new()
                {
                    OptOut = true,
                    Source = "source",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PhoneNumber = "phone_number",
                    Text = "text",
                },
                RequestID = "request_id",

                // Null should be interpreted as omitted for these properties
                Field = null,
                Timestamp = null,
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
            {
                Field = "field",
                Timestamp = "timestamp",
            };

        Assert.Null(model.Event);
        Assert.False(model.RawData.ContainsKey("event"));
        Assert.Null(model.Payload);
        Assert.False(model.RawData.ContainsKey("payload"));
        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
            {
                Field = "field",
                Timestamp = "timestamp",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
            {
                Field = "field",
                Timestamp = "timestamp",

                Event = null,
                Payload = null,
                RequestID = null,
            };

        Assert.Null(model.Event);
        Assert.True(model.RawData.ContainsKey("event"));
        Assert.Null(model.Payload);
        Assert.True(model.RawData.ContainsKey("payload"));
        Assert.Null(model.RequestID);
        Assert.True(model.RawData.ContainsKey("request_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
            {
                Field = "field",
                Timestamp = "timestamp",

                Event = null,
                Payload = null,
                RequestID = null,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    OptOut = true,
                    Source = "source",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Channel = "channel",
                    ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    PhoneNumber = "phone_number",
                    Text = "text",
                },
                RequestID = "request_id",
                Timestamp = "timestamp",
            };

        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayload copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayloadTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
            {
                OptOut = true,
                Source = "source",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Channel = "channel",
                ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PhoneNumber = "phone_number",
                Text = "text",
            };

        bool expectedOptOut = true;
        string expectedSource = "source";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        string expectedContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPhoneNumber = "phone_number";
        string expectedText = "text";

        Assert.Equal(expectedOptOut, model.OptOut);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedContactID, model.ContactID);
        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
            {
                OptOut = true,
                Source = "source",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Channel = "channel",
                ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PhoneNumber = "phone_number",
                Text = "text",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
            {
                OptOut = true,
                Source = "source",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Channel = "channel",
                ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PhoneNumber = "phone_number",
                Text = "text",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        bool expectedOptOut = true;
        string expectedSource = "source";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        string expectedContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPhoneNumber = "phone_number";
        string expectedText = "text";

        Assert.Equal(expectedOptOut, deserialized.OptOut);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedContactID, deserialized.ContactID);
        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
            {
                OptOut = true,
                Source = "source",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Channel = "channel",
                ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PhoneNumber = "phone_number",
                Text = "text",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
            {
                OptOut = true,
                Source = "source",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Text = "text",
            };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contact_id"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
            {
                OptOut = true,
                Source = "source",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Text = "text",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
            {
                OptOut = true,
                Source = "source",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Text = "text",

                // Null should be interpreted as omitted for these properties
                AccountID = null,
                Channel = null,
                ContactID = null,
                PhoneNumber = null,
            };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contact_id"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
            {
                OptOut = true,
                Source = "source",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Text = "text",

                // Null should be interpreted as omitted for these properties
                AccountID = null,
                Channel = null,
                ContactID = null,
                PhoneNumber = null,
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
            {
                OptOut = true,
                Source = "source",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Channel = "channel",
                ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PhoneNumber = "phone_number",
            };

        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
            {
                OptOut = true,
                Source = "source",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Channel = "channel",
                ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PhoneNumber = "phone_number",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
            {
                OptOut = true,
                Source = "source",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Channel = "channel",
                ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PhoneNumber = "phone_number",

                MessageID = null,
                Text = null,
            };

        Assert.Null(model.MessageID);
        Assert.True(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.Text);
        Assert.True(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
            {
                OptOut = true,
                Source = "source",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Channel = "channel",
                ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PhoneNumber = "phone_number",

                MessageID = null,
                Text = null,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload
            {
                OptOut = true,
                Source = "source",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Channel = "channel",
                ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PhoneNumber = "phone_number",
                Text = "text",
            };

        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfContactWebhookPayloadPayload copied =
            new(model);

        Assert.Equal(model, copied);
    }
}
