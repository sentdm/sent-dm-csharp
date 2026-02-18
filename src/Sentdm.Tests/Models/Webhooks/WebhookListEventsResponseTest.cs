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
                        EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        WebhookListEventsResponseData expectedData = new()
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
                    EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new WebhookListEventsResponse
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
                        EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
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
                        EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListEventsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WebhookListEventsResponseData expectedData = new()
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
                    EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new WebhookListEventsResponse
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
                        EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new WebhookListEventsResponse
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
                        EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new WebhookListEventsResponse
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
                        EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new WebhookListEventsResponse
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
                        EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new WebhookListEventsResponse
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
                        EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new WebhookListEventsResponse
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
        var model = new WebhookListEventsResponse
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
        var model = new WebhookListEventsResponse
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
        var model = new WebhookListEventsResponse
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
        var model = new WebhookListEventsResponse
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
                        EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        WebhookListEventsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookListEventsResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListEventsResponseData
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
                    EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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

        List<Event> expectedEvents =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DeliveryAttempts = 0,
                DeliveryStatus = "delivery_status",
                ErrorMessage = "error_message",
                EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new WebhookListEventsResponseData
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
                    EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var deserialized = JsonSerializer.Deserialize<WebhookListEventsResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListEventsResponseData
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
                    EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var deserialized = JsonSerializer.Deserialize<WebhookListEventsResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Event> expectedEvents =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DeliveryAttempts = 0,
                DeliveryStatus = "delivery_status",
                ErrorMessage = "error_message",
                EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new WebhookListEventsResponseData
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
                    EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new WebhookListEventsResponseData { };

        Assert.Null(model.Events);
        Assert.False(model.RawData.ContainsKey("events"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookListEventsResponseData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookListEventsResponseData
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
        var model = new WebhookListEventsResponseData
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
        var model = new WebhookListEventsResponseData
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
                    EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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

        WebhookListEventsResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Event
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            ErrorMessage = "error_message",
            EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        JsonElement expectedEventData = JsonSerializer.Deserialize<JsonElement>("{}");
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
        Assert.NotNull(model.EventData);
        Assert.True(JsonElement.DeepEquals(expectedEventData, model.EventData.Value));
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedHttpStatusCode, model.HttpStatusCode);
        Assert.Equal(expectedProcessingCompletedAt, model.ProcessingCompletedAt);
        Assert.Equal(expectedProcessingStartedAt, model.ProcessingStartedAt);
        Assert.Equal(expectedResponseBody, model.ResponseBody);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Event
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            ErrorMessage = "error_message",
            EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = "event_type",
            HttpStatusCode = 0,
            ProcessingCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProcessingStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResponseBody = "response_body",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Event
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            ErrorMessage = "error_message",
            EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = "event_type",
            HttpStatusCode = 0,
            ProcessingCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProcessingStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResponseBody = "response_body",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedDeliveryAttempts = 0;
        string expectedDeliveryStatus = "delivery_status";
        string expectedErrorMessage = "error_message";
        JsonElement expectedEventData = JsonSerializer.Deserialize<JsonElement>("{}");
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
        Assert.NotNull(deserialized.EventData);
        Assert.True(JsonElement.DeepEquals(expectedEventData, deserialized.EventData.Value));
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedHttpStatusCode, deserialized.HttpStatusCode);
        Assert.Equal(expectedProcessingCompletedAt, deserialized.ProcessingCompletedAt);
        Assert.Equal(expectedProcessingStartedAt, deserialized.ProcessingStartedAt);
        Assert.Equal(expectedResponseBody, deserialized.ResponseBody);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Event
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            ErrorMessage = "error_message",
            EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new Event
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
        var model = new Event
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
        var model = new Event
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
        var model = new Event
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
        var model = new Event
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new Event
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = "event_type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Event
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new Event
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new Event
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryAttempts = 0,
            DeliveryStatus = "delivery_status",
            ErrorMessage = "error_message",
            EventData = JsonSerializer.Deserialize<JsonElement>("{}"),
            EventType = "event_type",
            HttpStatusCode = 0,
            ProcessingCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProcessingStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResponseBody = "response_body",
        };

        Event copied = new(model);

        Assert.Equal(model, copied);
    }
}
