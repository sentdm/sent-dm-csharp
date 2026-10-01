using System;
using System.Collections.Generic;
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
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
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
                Reason = "reason",
                ReasonCode = "reason_code",
                ScheduleReason = "schedule_reason",
                ScheduledAt = "scheduled_at",
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
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
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
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
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
                Reason = "reason",
                ReasonCode = "reason_code",
                ScheduleReason = "schedule_reason",
                ScheduledAt = "scheduled_at",
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
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
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
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
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
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
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
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
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
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
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
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduleReason = "schedule_reason",
                    ScheduledAt = "scheduled_at",
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
                Reason = "reason",
                ReasonCode = "reason_code",
                ScheduleReason = "schedule_reason",
                ScheduledAt = "scheduled_at",
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
    public void SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayloadValidationWorks()
    {
        EventData value =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload()
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
                Channel = "channel",
                DurationSeconds = 0,
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
                Reason = "reason",
                ReasonCode = "reason_code",
                ScheduleReason = "schedule_reason",
                ScheduledAt = "scheduled_at",
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
    public void SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayloadSerializationRoundtripWorks()
    {
        EventData value =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload()
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
                Channel = "channel",
                DurationSeconds = 0,
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
}

public class SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayloadTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload
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

        string expectedEvent = "event";
        string expectedField = "field";
        Payload expectedPayload = new()
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedEvent = "event";
        string expectedField = "field";
        Payload expectedPayload = new()
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload
            {
                Event = "event",
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload
            {
                Event = "event",
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
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload
            {
                Event = "event",
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload
            {
                Event = "event",
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload
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
            new SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload
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

        SentDmServicesCommonServicesWebhooksContractsWebhookEventOfLinkWebhookPayload copied = new(
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
        };

        string expectedRecordID = "record_id";
        string expectedAccessCountry = "access_country";
        string expectedAccessOutcome = "access_outcome";
        string expectedBrowser = "browser";
        long expectedBytesServed = 0;
        string expectedChannel = "channel";
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDevice = "device";
        string expectedLinkKind = "link_kind";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedOccurredAt = "occurred_at";
        string expectedReferenceKey = "reference_key";
        string expectedReferrerHost = "referrer_host";
        string expectedRequestMethod = "request_method";
        string expectedSenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        int expectedStatusCode = 0;
        string expectedTrafficClass = "traffic_class";

        Assert.Equal(expectedRecordID, model.RecordID);
        Assert.Equal(expectedAccessCountry, model.AccessCountry);
        Assert.Equal(expectedAccessOutcome, model.AccessOutcome);
        Assert.Equal(expectedBrowser, model.Browser);
        Assert.Equal(expectedBytesServed, model.BytesServed);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedDevice, model.Device);
        Assert.Equal(expectedLinkKind, model.LinkKind);
        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.Equal(expectedOccurredAt, model.OccurredAt);
        Assert.Equal(expectedReferenceKey, model.ReferenceKey);
        Assert.Equal(expectedReferrerHost, model.ReferrerHost);
        Assert.Equal(expectedRequestMethod, model.RequestMethod);
        Assert.Equal(expectedSenderProfileID, model.SenderProfileID);
        Assert.Equal(expectedStatusCode, model.StatusCode);
        Assert.Equal(expectedTrafficClass, model.TrafficClass);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Payload
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Payload>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRecordID = "record_id";
        string expectedAccessCountry = "access_country";
        string expectedAccessOutcome = "access_outcome";
        string expectedBrowser = "browser";
        long expectedBytesServed = 0;
        string expectedChannel = "channel";
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDevice = "device";
        string expectedLinkKind = "link_kind";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedOccurredAt = "occurred_at";
        string expectedReferenceKey = "reference_key";
        string expectedReferrerHost = "referrer_host";
        string expectedRequestMethod = "request_method";
        string expectedSenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        int expectedStatusCode = 0;
        string expectedTrafficClass = "traffic_class";

        Assert.Equal(expectedRecordID, deserialized.RecordID);
        Assert.Equal(expectedAccessCountry, deserialized.AccessCountry);
        Assert.Equal(expectedAccessOutcome, deserialized.AccessOutcome);
        Assert.Equal(expectedBrowser, deserialized.Browser);
        Assert.Equal(expectedBytesServed, deserialized.BytesServed);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedDevice, deserialized.Device);
        Assert.Equal(expectedLinkKind, deserialized.LinkKind);
        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.Equal(expectedOccurredAt, deserialized.OccurredAt);
        Assert.Equal(expectedReferenceKey, deserialized.ReferenceKey);
        Assert.Equal(expectedReferrerHost, deserialized.ReferrerHost);
        Assert.Equal(expectedRequestMethod, deserialized.RequestMethod);
        Assert.Equal(expectedSenderProfileID, deserialized.SenderProfileID);
        Assert.Equal(expectedStatusCode, deserialized.StatusCode);
        Assert.Equal(expectedTrafficClass, deserialized.TrafficClass);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Payload
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Payload
        {
            RecordID = "record_id",
            AccessCountry = "access_country",
            AccessOutcome = "access_outcome",
            Browser = "browser",
            BytesServed = 0,
            Channel = "channel",
            Device = "device",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceKey = "reference_key",
            ReferrerHost = "referrer_host",
            RequestMethod = "request_method",
            SenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            StatusCode = 0,
            TrafficClass = "traffic_class",
        };

        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customer_id"));
        Assert.Null(model.LinkKind);
        Assert.False(model.RawData.ContainsKey("link_kind"));
        Assert.Null(model.OccurredAt);
        Assert.False(model.RawData.ContainsKey("occurred_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Payload
        {
            RecordID = "record_id",
            AccessCountry = "access_country",
            AccessOutcome = "access_outcome",
            Browser = "browser",
            BytesServed = 0,
            Channel = "channel",
            Device = "device",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceKey = "reference_key",
            ReferrerHost = "referrer_host",
            RequestMethod = "request_method",
            SenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            StatusCode = 0,
            TrafficClass = "traffic_class",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Payload
        {
            RecordID = "record_id",
            AccessCountry = "access_country",
            AccessOutcome = "access_outcome",
            Browser = "browser",
            BytesServed = 0,
            Channel = "channel",
            Device = "device",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceKey = "reference_key",
            ReferrerHost = "referrer_host",
            RequestMethod = "request_method",
            SenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            StatusCode = 0,
            TrafficClass = "traffic_class",

            // Null should be interpreted as omitted for these properties
            CustomerID = null,
            LinkKind = null,
            OccurredAt = null,
        };

        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customer_id"));
        Assert.Null(model.LinkKind);
        Assert.False(model.RawData.ContainsKey("link_kind"));
        Assert.Null(model.OccurredAt);
        Assert.False(model.RawData.ContainsKey("occurred_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Payload
        {
            RecordID = "record_id",
            AccessCountry = "access_country",
            AccessOutcome = "access_outcome",
            Browser = "browser",
            BytesServed = 0,
            Channel = "channel",
            Device = "device",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceKey = "reference_key",
            ReferrerHost = "referrer_host",
            RequestMethod = "request_method",
            SenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            StatusCode = 0,
            TrafficClass = "traffic_class",

            // Null should be interpreted as omitted for these properties
            CustomerID = null,
            LinkKind = null,
            OccurredAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Payload
        {
            RecordID = "record_id",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LinkKind = "link_kind",
            OccurredAt = "occurred_at",
        };

        Assert.Null(model.AccessCountry);
        Assert.False(model.RawData.ContainsKey("access_country"));
        Assert.Null(model.AccessOutcome);
        Assert.False(model.RawData.ContainsKey("access_outcome"));
        Assert.Null(model.Browser);
        Assert.False(model.RawData.ContainsKey("browser"));
        Assert.Null(model.BytesServed);
        Assert.False(model.RawData.ContainsKey("bytes_served"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Device);
        Assert.False(model.RawData.ContainsKey("device"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.ReferenceKey);
        Assert.False(model.RawData.ContainsKey("reference_key"));
        Assert.Null(model.ReferrerHost);
        Assert.False(model.RawData.ContainsKey("referrer_host"));
        Assert.Null(model.RequestMethod);
        Assert.False(model.RawData.ContainsKey("request_method"));
        Assert.Null(model.SenderProfileID);
        Assert.False(model.RawData.ContainsKey("sender_profile_id"));
        Assert.Null(model.StatusCode);
        Assert.False(model.RawData.ContainsKey("status_code"));
        Assert.Null(model.TrafficClass);
        Assert.False(model.RawData.ContainsKey("traffic_class"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Payload
        {
            RecordID = "record_id",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LinkKind = "link_kind",
            OccurredAt = "occurred_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Payload
        {
            RecordID = "record_id",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LinkKind = "link_kind",
            OccurredAt = "occurred_at",

            AccessCountry = null,
            AccessOutcome = null,
            Browser = null,
            BytesServed = null,
            Channel = null,
            Device = null,
            MessageID = null,
            ReferenceKey = null,
            ReferrerHost = null,
            RequestMethod = null,
            SenderProfileID = null,
            StatusCode = null,
            TrafficClass = null,
        };

        Assert.Null(model.AccessCountry);
        Assert.True(model.RawData.ContainsKey("access_country"));
        Assert.Null(model.AccessOutcome);
        Assert.True(model.RawData.ContainsKey("access_outcome"));
        Assert.Null(model.Browser);
        Assert.True(model.RawData.ContainsKey("browser"));
        Assert.Null(model.BytesServed);
        Assert.True(model.RawData.ContainsKey("bytes_served"));
        Assert.Null(model.Channel);
        Assert.True(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Device);
        Assert.True(model.RawData.ContainsKey("device"));
        Assert.Null(model.MessageID);
        Assert.True(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.ReferenceKey);
        Assert.True(model.RawData.ContainsKey("reference_key"));
        Assert.Null(model.ReferrerHost);
        Assert.True(model.RawData.ContainsKey("referrer_host"));
        Assert.Null(model.RequestMethod);
        Assert.True(model.RawData.ContainsKey("request_method"));
        Assert.Null(model.SenderProfileID);
        Assert.True(model.RawData.ContainsKey("sender_profile_id"));
        Assert.Null(model.StatusCode);
        Assert.True(model.RawData.ContainsKey("status_code"));
        Assert.Null(model.TrafficClass);
        Assert.True(model.RawData.ContainsKey("traffic_class"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Payload
        {
            RecordID = "record_id",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LinkKind = "link_kind",
            OccurredAt = "occurred_at",

            AccessCountry = null,
            AccessOutcome = null,
            Browser = null,
            BytesServed = null,
            Channel = null,
            Device = null,
            MessageID = null,
            ReferenceKey = null,
            ReferrerHost = null,
            RequestMethod = null,
            SenderProfileID = null,
            StatusCode = null,
            TrafficClass = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Payload
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
        };

        Payload copied = new(model);

        Assert.Equal(model, copied);
    }
}
