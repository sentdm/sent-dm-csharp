using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookListEventsPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListEventsPageResponse
        {
            Data = new()
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

        WebhookListEventsPageResponseData expectedData = new()
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
        ErrorDetail expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
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
        var model = new WebhookListEventsPageResponse
        {
            Data = new()
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
        var deserialized = JsonSerializer.Deserialize<WebhookListEventsPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListEventsPageResponse
        {
            Data = new()
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
        var deserialized = JsonSerializer.Deserialize<WebhookListEventsPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WebhookListEventsPageResponseData expectedData = new()
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
        ErrorDetail expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
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
        var model = new WebhookListEventsPageResponse
        {
            Data = new()
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
        var model = new WebhookListEventsPageResponse
        {
            Data = new()
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
        var model = new WebhookListEventsPageResponse
        {
            Data = new()
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
        var model = new WebhookListEventsPageResponse
        {
            Data = new()
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
        var model = new WebhookListEventsPageResponse
        {
            Data = new()
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
        var model = new WebhookListEventsPageResponse
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
        var model = new WebhookListEventsPageResponse
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
        var model = new WebhookListEventsPageResponse
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
        var model = new WebhookListEventsPageResponse
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
        var model = new WebhookListEventsPageResponse
        {
            Data = new()
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

        WebhookListEventsPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookListEventsPageResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListEventsPageResponseData
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

        List<WebhookListEventsResponse> expectedEvents =
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
        var model = new WebhookListEventsPageResponseData
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
        var deserialized = JsonSerializer.Deserialize<WebhookListEventsPageResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListEventsPageResponseData
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
        var deserialized = JsonSerializer.Deserialize<WebhookListEventsPageResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<WebhookListEventsResponse> expectedEvents =
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
        var model = new WebhookListEventsPageResponseData
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
        var model = new WebhookListEventsPageResponseData { };

        Assert.Null(model.Events);
        Assert.False(model.RawData.ContainsKey("events"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookListEventsPageResponseData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookListEventsPageResponseData
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
        var model = new WebhookListEventsPageResponseData
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
        var model = new WebhookListEventsPageResponseData
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

        WebhookListEventsPageResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
