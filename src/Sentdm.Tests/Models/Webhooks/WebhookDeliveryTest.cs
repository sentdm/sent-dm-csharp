using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookDeliveryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookDelivery
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
                    ParentMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
                    SentAgentID = "sent_agent_id",
                    SentInstanceID = "sent_instance_id",
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
                ParentMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Reason = "reason",
                ReasonCode = "reason_code",
                ScheduleReason = "schedule_reason",
                ScheduledAt = "scheduled_at",
                SentAgentID = "sent_agent_id",
                SentInstanceID = "sent_instance_id",
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
        var model = new WebhookDelivery
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
                    ParentMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
                    SentAgentID = "sent_agent_id",
                    SentInstanceID = "sent_instance_id",
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
        var deserialized = JsonSerializer.Deserialize<WebhookDelivery>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookDelivery
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
                    ParentMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
                    SentAgentID = "sent_agent_id",
                    SentInstanceID = "sent_instance_id",
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
        var deserialized = JsonSerializer.Deserialize<WebhookDelivery>(
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
                ParentMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Reason = "reason",
                ReasonCode = "reason_code",
                ScheduleReason = "schedule_reason",
                ScheduledAt = "scheduled_at",
                SentAgentID = "sent_agent_id",
                SentInstanceID = "sent_instance_id",
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
        var model = new WebhookDelivery
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
                    ParentMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
                    SentAgentID = "sent_agent_id",
                    SentInstanceID = "sent_instance_id",
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
        var model = new WebhookDelivery
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
        var model = new WebhookDelivery
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
        var model = new WebhookDelivery
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
        var model = new WebhookDelivery
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
        var model = new WebhookDelivery
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
                    ParentMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
                    SentAgentID = "sent_agent_id",
                    SentInstanceID = "sent_instance_id",
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
        var model = new WebhookDelivery
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
                    ParentMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
                    SentAgentID = "sent_agent_id",
                    SentInstanceID = "sent_instance_id",
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
        var model = new WebhookDelivery
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
                    ParentMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
                    SentAgentID = "sent_agent_id",
                    SentInstanceID = "sent_instance_id",
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
        var model = new WebhookDelivery
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
                    ParentMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
                    SentAgentID = "sent_agent_id",
                    SentInstanceID = "sent_instance_id",
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
        var model = new WebhookDelivery
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
                    ParentMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
                    SentAgentID = "sent_agent_id",
                    SentInstanceID = "sent_instance_id",
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

        WebhookDelivery copied = new(model);

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
                ParentMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Reason = "reason",
                ReasonCode = "reason_code",
                ScheduleReason = "schedule_reason",
                ScheduledAt = "scheduled_at",
                SentAgentID = "sent_agent_id",
                SentInstanceID = "sent_instance_id",
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
                Media =
                [
                    new()
                    {
                        HashSha256 = "hash_sha256",
                        MimeType = "mime_type",
                        SizeBytes = 0,
                        Url = "url",
                    },
                ],
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OutboundNumber = "outbound_number",
                Referral = JsonSerializer.Deserialize<JsonElement>("{}"),
                SentAgentID = "sent_agent_id",
                SentInstanceID = "sent_instance_id",
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
    public void ChannelEventValidationWorks()
    {
        EventData value = new ChannelEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                Country = "country",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Channel = "channel",
                Compliance = new()
                {
                    Brand = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Campaign = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Campaigns =
                    [
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    ],
                    Documents =
                    [
                        new()
                        {
                            DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            FileName = "file_name",
                            Key = "key",
                        },
                    ],
                },
                NumberType = "number_type",
                Reason = "reason",
                ReasonCode = "reason_code",
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
    public void ContactEventValidationWorks()
    {
        EventData value = new ContactEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                OptOut = true,
                Source = "source",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AgentID = "agent_id",
                Channel = "channel",
                ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                From = "from",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Text = "text",
                To = "to",
            },
            RequestID = "request_id",
            Timestamp = "timestamp",
        };
        value.Validate();
    }

    [Fact]
    public void LinkEventValidationWorks()
    {
        EventData value = new LinkEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                RecordID = "record_id",
                AccessCountry = "access_country",
                AccessOutcome = "access_outcome",
                Browser = "browser",
                BytesServed = 0,
                Channel = "channel",
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Device = "device",
                LinkKind = "link_kind",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OccurredAt = "occurred_at",
                ReferenceKey = "reference_key",
                ReferrerHost = "referrer_host",
                RequestMethod = "request_method",
                SenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                StatusCode = 0,
                TrafficClass = "traffic_class",
            },
            RequestID = "request_id",
            Timestamp = "timestamp",
        };
        value.Validate();
    }

    [Fact]
    public void CallEventValidationWorks()
    {
        EventData value = new CallEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                CallID = "call_id",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AgentID = "agent_id",
                Channel = "channel",
                DurationSeconds = 0,
                Mode = "mode",
                Number = "number",
                Price = 0,
                Reason = "reason",
                RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                UpdatedAt = "updated_at",
            },
            RequestID = "request_id",
            Timestamp = "timestamp",
        };
        value.Validate();
    }

    [Fact]
    public void SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayloadValidationWorks()
    {
        EventData value =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload()
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    EventID = "event_id",
                    OccurredAt = "occurred_at",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Actor = "actor",
                    AgentID = "agent_id",
                    AgentName = "agent_name",
                    AgentVersion = 0,
                    ContactID = "contact_id",
                    ContactPhoneNumber = "contact_phone_number",
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    InstanceID = "instance_id",
                    Sequence = 0,
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
                ParentMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Reason = "reason",
                ReasonCode = "reason_code",
                ScheduleReason = "schedule_reason",
                ScheduledAt = "scheduled_at",
                SentAgentID = "sent_agent_id",
                SentInstanceID = "sent_instance_id",
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
                Media =
                [
                    new()
                    {
                        HashSha256 = "hash_sha256",
                        MimeType = "mime_type",
                        SizeBytes = 0,
                        Url = "url",
                    },
                ],
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OutboundNumber = "outbound_number",
                Referral = JsonSerializer.Deserialize<JsonElement>("{}"),
                SentAgentID = "sent_agent_id",
                SentInstanceID = "sent_instance_id",
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
    public void ChannelEventSerializationRoundtripWorks()
    {
        EventData value = new ChannelEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                Country = "country",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Channel = "channel",
                Compliance = new()
                {
                    Brand = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Campaign = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Campaigns =
                    [
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    ],
                    Documents =
                    [
                        new()
                        {
                            DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            FileName = "file_name",
                            Key = "key",
                        },
                    ],
                },
                NumberType = "number_type",
                Reason = "reason",
                ReasonCode = "reason_code",
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
    public void ContactEventSerializationRoundtripWorks()
    {
        EventData value = new ContactEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                OptOut = true,
                Source = "source",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AgentID = "agent_id",
                Channel = "channel",
                ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                From = "from",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Text = "text",
                To = "to",
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
    public void LinkEventSerializationRoundtripWorks()
    {
        EventData value = new LinkEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                RecordID = "record_id",
                AccessCountry = "access_country",
                AccessOutcome = "access_outcome",
                Browser = "browser",
                BytesServed = 0,
                Channel = "channel",
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Device = "device",
                LinkKind = "link_kind",
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OccurredAt = "occurred_at",
                ReferenceKey = "reference_key",
                ReferrerHost = "referrer_host",
                RequestMethod = "request_method",
                SenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                StatusCode = 0,
                TrafficClass = "traffic_class",
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
    public void CallEventSerializationRoundtripWorks()
    {
        EventData value = new CallEvent()
        {
            Event = "event",
            Field = "field",
            Payload = new()
            {
                CallID = "call_id",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AgentID = "agent_id",
                Channel = "channel",
                DurationSeconds = 0,
                Mode = "mode",
                Number = "number",
                Price = 0,
                Reason = "reason",
                RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
    public void SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayloadSerializationRoundtripWorks()
    {
        EventData value =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload()
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    EventID = "event_id",
                    OccurredAt = "occurred_at",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Actor = "actor",
                    AgentID = "agent_id",
                    AgentName = "agent_name",
                    AgentVersion = 0,
                    ContactID = "contact_id",
                    ContactPhoneNumber = "contact_phone_number",
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    InstanceID = "instance_id",
                    Sequence = 0,
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

public class SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayloadTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    EventID = "event_id",
                    OccurredAt = "occurred_at",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Actor = "actor",
                    AgentID = "agent_id",
                    AgentName = "agent_name",
                    AgentVersion = 0,
                    ContactID = "contact_id",
                    ContactPhoneNumber = "contact_phone_number",
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    InstanceID = "instance_id",
                    Sequence = 0,
                },
                RequestID = "request_id",
                Timestamp = "timestamp",
            };

        string expectedEvent = "event";
        string expectedField = "field";
        Payload expectedPayload = new()
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Actor = "actor",
            AgentID = "agent_id",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            InstanceID = "instance_id",
            Sequence = 0,
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    EventID = "event_id",
                    OccurredAt = "occurred_at",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Actor = "actor",
                    AgentID = "agent_id",
                    AgentName = "agent_name",
                    AgentVersion = 0,
                    ContactID = "contact_id",
                    ContactPhoneNumber = "contact_phone_number",
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    InstanceID = "instance_id",
                    Sequence = 0,
                },
                RequestID = "request_id",
                Timestamp = "timestamp",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    EventID = "event_id",
                    OccurredAt = "occurred_at",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Actor = "actor",
                    AgentID = "agent_id",
                    AgentName = "agent_name",
                    AgentVersion = 0,
                    ContactID = "contact_id",
                    ContactPhoneNumber = "contact_phone_number",
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    InstanceID = "instance_id",
                    Sequence = 0,
                },
                RequestID = "request_id",
                Timestamp = "timestamp",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedEvent = "event";
        string expectedField = "field";
        Payload expectedPayload = new()
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Actor = "actor",
            AgentID = "agent_id",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            InstanceID = "instance_id",
            Sequence = 0,
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    EventID = "event_id",
                    OccurredAt = "occurred_at",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Actor = "actor",
                    AgentID = "agent_id",
                    AgentName = "agent_name",
                    AgentVersion = 0,
                    ContactID = "contact_id",
                    ContactPhoneNumber = "contact_phone_number",
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    InstanceID = "instance_id",
                    Sequence = 0,
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload
            {
                Event = "event",
                Payload = new()
                {
                    EventID = "event_id",
                    OccurredAt = "occurred_at",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Actor = "actor",
                    AgentID = "agent_id",
                    AgentName = "agent_name",
                    AgentVersion = 0,
                    ContactID = "contact_id",
                    ContactPhoneNumber = "contact_phone_number",
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    InstanceID = "instance_id",
                    Sequence = 0,
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload
            {
                Event = "event",
                Payload = new()
                {
                    EventID = "event_id",
                    OccurredAt = "occurred_at",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Actor = "actor",
                    AgentID = "agent_id",
                    AgentName = "agent_name",
                    AgentVersion = 0,
                    ContactID = "contact_id",
                    ContactPhoneNumber = "contact_phone_number",
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    InstanceID = "instance_id",
                    Sequence = 0,
                },
                RequestID = "request_id",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload
            {
                Event = "event",
                Payload = new()
                {
                    EventID = "event_id",
                    OccurredAt = "occurred_at",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Actor = "actor",
                    AgentID = "agent_id",
                    AgentName = "agent_name",
                    AgentVersion = 0,
                    ContactID = "contact_id",
                    ContactPhoneNumber = "contact_phone_number",
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    InstanceID = "instance_id",
                    Sequence = 0,
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload
            {
                Event = "event",
                Payload = new()
                {
                    EventID = "event_id",
                    OccurredAt = "occurred_at",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Actor = "actor",
                    AgentID = "agent_id",
                    AgentName = "agent_name",
                    AgentVersion = 0,
                    ContactID = "contact_id",
                    ContactPhoneNumber = "contact_phone_number",
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    InstanceID = "instance_id",
                    Sequence = 0,
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload
            {
                Event = "event",
                Field = "field",
                Payload = new()
                {
                    EventID = "event_id",
                    OccurredAt = "occurred_at",
                    AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Actor = "actor",
                    AgentID = "agent_id",
                    AgentName = "agent_name",
                    AgentVersion = 0,
                    ContactID = "contact_id",
                    ContactPhoneNumber = "contact_phone_number",
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    InstanceID = "instance_id",
                    Sequence = 0,
                },
                RequestID = "request_id",
                Timestamp = "timestamp",
            };

        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfAgentWebhookPayload copied = new(
            model
        );

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
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Actor = "actor",
            AgentID = "agent_id",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            InstanceID = "instance_id",
            Sequence = 0,
        };

        string expectedEventID = "event_id";
        string expectedOccurredAt = "occurred_at";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedActor = "actor";
        string expectedAgentID = "agent_id";
        string expectedAgentName = "agent_name";
        int expectedAgentVersion = 0;
        string expectedContactID = "contact_id";
        string expectedContactPhoneNumber = "contact_phone_number";
        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedInstanceID = "instance_id";
        long expectedSequence = 0;

        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedOccurredAt, model.OccurredAt);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedActor, model.Actor);
        Assert.Equal(expectedAgentID, model.AgentID);
        Assert.Equal(expectedAgentName, model.AgentName);
        Assert.Equal(expectedAgentVersion, model.AgentVersion);
        Assert.Equal(expectedContactID, model.ContactID);
        Assert.Equal(expectedContactPhoneNumber, model.ContactPhoneNumber);
        Assert.NotNull(model.Data);
        Assert.True(JsonElement.DeepEquals(expectedData, model.Data.Value));
        Assert.Equal(expectedInstanceID, model.InstanceID);
        Assert.Equal(expectedSequence, model.Sequence);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Payload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Actor = "actor",
            AgentID = "agent_id",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            InstanceID = "instance_id",
            Sequence = 0,
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
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Actor = "actor",
            AgentID = "agent_id",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            InstanceID = "instance_id",
            Sequence = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Payload>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEventID = "event_id";
        string expectedOccurredAt = "occurred_at";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedActor = "actor";
        string expectedAgentID = "agent_id";
        string expectedAgentName = "agent_name";
        int expectedAgentVersion = 0;
        string expectedContactID = "contact_id";
        string expectedContactPhoneNumber = "contact_phone_number";
        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedInstanceID = "instance_id";
        long expectedSequence = 0;

        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedOccurredAt, deserialized.OccurredAt);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedActor, deserialized.Actor);
        Assert.Equal(expectedAgentID, deserialized.AgentID);
        Assert.Equal(expectedAgentName, deserialized.AgentName);
        Assert.Equal(expectedAgentVersion, deserialized.AgentVersion);
        Assert.Equal(expectedContactID, deserialized.ContactID);
        Assert.Equal(expectedContactPhoneNumber, deserialized.ContactPhoneNumber);
        Assert.NotNull(deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedData, deserialized.Data.Value));
        Assert.Equal(expectedInstanceID, deserialized.InstanceID);
        Assert.Equal(expectedSequence, deserialized.Sequence);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Payload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Actor = "actor",
            AgentID = "agent_id",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            InstanceID = "instance_id",
            Sequence = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Payload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            Actor = "actor",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            InstanceID = "instance_id",
            Sequence = 0,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.AgentID);
        Assert.False(model.RawData.ContainsKey("agent_id"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Payload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            Actor = "actor",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            InstanceID = "instance_id",
            Sequence = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Payload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            Actor = "actor",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            InstanceID = "instance_id",
            Sequence = 0,

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            AgentID = null,
            Data = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.AgentID);
        Assert.False(model.RawData.ContainsKey("agent_id"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Payload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            Actor = "actor",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            InstanceID = "instance_id",
            Sequence = 0,

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            AgentID = null,
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Payload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AgentID = "agent_id",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.Actor);
        Assert.False(model.RawData.ContainsKey("actor"));
        Assert.Null(model.AgentName);
        Assert.False(model.RawData.ContainsKey("agent_name"));
        Assert.Null(model.AgentVersion);
        Assert.False(model.RawData.ContainsKey("agent_version"));
        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contact_id"));
        Assert.Null(model.ContactPhoneNumber);
        Assert.False(model.RawData.ContainsKey("contact_phone_number"));
        Assert.Null(model.InstanceID);
        Assert.False(model.RawData.ContainsKey("instance_id"));
        Assert.Null(model.Sequence);
        Assert.False(model.RawData.ContainsKey("sequence"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Payload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AgentID = "agent_id",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Payload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AgentID = "agent_id",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),

            Actor = null,
            AgentName = null,
            AgentVersion = null,
            ContactID = null,
            ContactPhoneNumber = null,
            InstanceID = null,
            Sequence = null,
        };

        Assert.Null(model.Actor);
        Assert.True(model.RawData.ContainsKey("actor"));
        Assert.Null(model.AgentName);
        Assert.True(model.RawData.ContainsKey("agent_name"));
        Assert.Null(model.AgentVersion);
        Assert.True(model.RawData.ContainsKey("agent_version"));
        Assert.Null(model.ContactID);
        Assert.True(model.RawData.ContainsKey("contact_id"));
        Assert.Null(model.ContactPhoneNumber);
        Assert.True(model.RawData.ContainsKey("contact_phone_number"));
        Assert.Null(model.InstanceID);
        Assert.True(model.RawData.ContainsKey("instance_id"));
        Assert.Null(model.Sequence);
        Assert.True(model.RawData.ContainsKey("sequence"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Payload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AgentID = "agent_id",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),

            Actor = null,
            AgentName = null,
            AgentVersion = null,
            ContactID = null,
            ContactPhoneNumber = null,
            InstanceID = null,
            Sequence = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Payload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Actor = "actor",
            AgentID = "agent_id",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            InstanceID = "instance_id",
            Sequence = 0,
        };

        Payload copied = new(model);

        Assert.Equal(model, copied);
    }
}
