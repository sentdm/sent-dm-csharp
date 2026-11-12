using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookEventsListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookEventsList
        {
            Events =
            [
                new()
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
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        List<WebhookDelivery> expectedEvents =
        [
            new()
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
            },
        ];
        PaginationMeta expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.NotNull(model.Events);
        Assert.Equal(expectedEvents.Count, model.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], model.Events[i]);
        }
        Assert.Equal(expectedPagination, model.Pagination);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookEventsList
        {
            Events =
            [
                new()
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
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookEventsList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookEventsList
        {
            Events =
            [
                new()
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
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookEventsList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<WebhookDelivery> expectedEvents =
        [
            new()
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
            },
        ];
        PaginationMeta expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.NotNull(deserialized.Events);
        Assert.Equal(expectedEvents.Count, deserialized.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], deserialized.Events[i]);
        }
        Assert.Equal(expectedPagination, deserialized.Pagination);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookEventsList
        {
            Events =
            [
                new()
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
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookEventsList { };

        Assert.Null(model.Events);
        Assert.False(model.RawData.ContainsKey("events"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookEventsList { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookEventsList
        {
            // Null should be interpreted as omitted for these properties
            Events = null,
            Pagination = null,
        };

        Assert.Null(model.Events);
        Assert.False(model.RawData.ContainsKey("events"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookEventsList
        {
            // Null should be interpreted as omitted for these properties
            Events = null,
            Pagination = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookEventsList
        {
            Events =
            [
                new()
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
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        WebhookEventsList copied = new(model);

        Assert.Equal(model, copied);
    }
}
