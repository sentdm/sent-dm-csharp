using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookListEventTypesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListEventTypesResponse
        {
            Data = new()
            {
                EventTypes =
                [
                    new()
                    {
                        Description = "description",
                        DisplayName = "display_name",
                        EventTypeValue = "event_type",
                        IsActive = true,
                        Name = "name",
                        SubTypes = [],
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

        WebhookListEventTypesResponseData expectedData = new()
        {
            EventTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventTypeValue = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
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
        WebhookListEventTypesResponseError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        WebhookListEventTypesResponseMeta expectedMeta = new()
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
        var model = new WebhookListEventTypesResponse
        {
            Data = new()
            {
                EventTypes =
                [
                    new()
                    {
                        Description = "description",
                        DisplayName = "display_name",
                        EventTypeValue = "event_type",
                        IsActive = true,
                        Name = "name",
                        SubTypes = [],
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
        var deserialized = JsonSerializer.Deserialize<WebhookListEventTypesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListEventTypesResponse
        {
            Data = new()
            {
                EventTypes =
                [
                    new()
                    {
                        Description = "description",
                        DisplayName = "display_name",
                        EventTypeValue = "event_type",
                        IsActive = true,
                        Name = "name",
                        SubTypes = [],
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
        var deserialized = JsonSerializer.Deserialize<WebhookListEventTypesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WebhookListEventTypesResponseData expectedData = new()
        {
            EventTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventTypeValue = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
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
        WebhookListEventTypesResponseError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        WebhookListEventTypesResponseMeta expectedMeta = new()
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
        var model = new WebhookListEventTypesResponse
        {
            Data = new()
            {
                EventTypes =
                [
                    new()
                    {
                        Description = "description",
                        DisplayName = "display_name",
                        EventTypeValue = "event_type",
                        IsActive = true,
                        Name = "name",
                        SubTypes = [],
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
        var model = new WebhookListEventTypesResponse
        {
            Data = new()
            {
                EventTypes =
                [
                    new()
                    {
                        Description = "description",
                        DisplayName = "display_name",
                        EventTypeValue = "event_type",
                        IsActive = true,
                        Name = "name",
                        SubTypes = [],
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
        var model = new WebhookListEventTypesResponse
        {
            Data = new()
            {
                EventTypes =
                [
                    new()
                    {
                        Description = "description",
                        DisplayName = "display_name",
                        EventTypeValue = "event_type",
                        IsActive = true,
                        Name = "name",
                        SubTypes = [],
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
        var model = new WebhookListEventTypesResponse
        {
            Data = new()
            {
                EventTypes =
                [
                    new()
                    {
                        Description = "description",
                        DisplayName = "display_name",
                        EventTypeValue = "event_type",
                        IsActive = true,
                        Name = "name",
                        SubTypes = [],
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
        var model = new WebhookListEventTypesResponse
        {
            Data = new()
            {
                EventTypes =
                [
                    new()
                    {
                        Description = "description",
                        DisplayName = "display_name",
                        EventTypeValue = "event_type",
                        IsActive = true,
                        Name = "name",
                        SubTypes = [],
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
        var model = new WebhookListEventTypesResponse
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
        var model = new WebhookListEventTypesResponse
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
        var model = new WebhookListEventTypesResponse
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
        var model = new WebhookListEventTypesResponse
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
        var model = new WebhookListEventTypesResponse
        {
            Data = new()
            {
                EventTypes =
                [
                    new()
                    {
                        Description = "description",
                        DisplayName = "display_name",
                        EventTypeValue = "event_type",
                        IsActive = true,
                        Name = "name",
                        SubTypes = [],
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

        WebhookListEventTypesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookListEventTypesResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListEventTypesResponseData
        {
            EventTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventTypeValue = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
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

        List<EventType> expectedEventTypes =
        [
            new()
            {
                Description = "description",
                DisplayName = "display_name",
                EventTypeValue = "event_type",
                IsActive = true,
                Name = "name",
                SubTypes = [],
            },
        ];
        WebhookListEventTypesResponseDataPagination expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.NotNull(model.EventTypes);
        Assert.Equal(expectedEventTypes.Count, model.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], model.EventTypes[i]);
        }
        Assert.Equal(expectedPagination, model.Pagination);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookListEventTypesResponseData
        {
            EventTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventTypeValue = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
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
        var deserialized = JsonSerializer.Deserialize<WebhookListEventTypesResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListEventTypesResponseData
        {
            EventTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventTypeValue = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
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
        var deserialized = JsonSerializer.Deserialize<WebhookListEventTypesResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<EventType> expectedEventTypes =
        [
            new()
            {
                Description = "description",
                DisplayName = "display_name",
                EventTypeValue = "event_type",
                IsActive = true,
                Name = "name",
                SubTypes = [],
            },
        ];
        WebhookListEventTypesResponseDataPagination expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.NotNull(deserialized.EventTypes);
        Assert.Equal(expectedEventTypes.Count, deserialized.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], deserialized.EventTypes[i]);
        }
        Assert.Equal(expectedPagination, deserialized.Pagination);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookListEventTypesResponseData
        {
            EventTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventTypeValue = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
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
        var model = new WebhookListEventTypesResponseData { };

        Assert.Null(model.EventTypes);
        Assert.False(model.RawData.ContainsKey("event_types"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookListEventTypesResponseData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookListEventTypesResponseData
        {
            // Null should be interpreted as omitted for these properties
            EventTypes = null,
            Pagination = null,
        };

        Assert.Null(model.EventTypes);
        Assert.False(model.RawData.ContainsKey("event_types"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookListEventTypesResponseData
        {
            // Null should be interpreted as omitted for these properties
            EventTypes = null,
            Pagination = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookListEventTypesResponseData
        {
            EventTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventTypeValue = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
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

        WebhookListEventTypesResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventType
        {
            Description = "description",
            DisplayName = "display_name",
            EventTypeValue = "event_type",
            IsActive = true,
            Name = "name",
            SubTypes = [],
        };

        string expectedDescription = "description";
        string expectedDisplayName = "display_name";
        string expectedEventTypeValue = "event_type";
        bool expectedIsActive = true;
        string expectedName = "name";
        List<JsonElement> expectedSubTypes = [];

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEventTypeValue, model.EventTypeValue);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.SubTypes);
        Assert.Equal(expectedSubTypes.Count, model.SubTypes.Count);
        for (int i = 0; i < expectedSubTypes.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSubTypes[i], model.SubTypes[i]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventType
        {
            Description = "description",
            DisplayName = "display_name",
            EventTypeValue = "event_type",
            IsActive = true,
            Name = "name",
            SubTypes = [],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventType>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventType
        {
            Description = "description",
            DisplayName = "display_name",
            EventTypeValue = "event_type",
            IsActive = true,
            Name = "name",
            SubTypes = [],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventType>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedDisplayName = "display_name";
        string expectedEventTypeValue = "event_type";
        bool expectedIsActive = true;
        string expectedName = "name";
        List<JsonElement> expectedSubTypes = [];

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEventTypeValue, deserialized.EventTypeValue);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.SubTypes);
        Assert.Equal(expectedSubTypes.Count, deserialized.SubTypes.Count);
        for (int i = 0; i < expectedSubTypes.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSubTypes[i], deserialized.SubTypes[i]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventType
        {
            Description = "description",
            DisplayName = "display_name",
            EventTypeValue = "event_type",
            IsActive = true,
            Name = "name",
            SubTypes = [],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EventType
        {
            Description = "description",
            EventTypeValue = "event_type",
            SubTypes = [],
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EventType
        {
            Description = "description",
            EventTypeValue = "event_type",
            SubTypes = [],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EventType
        {
            Description = "description",
            EventTypeValue = "event_type",
            SubTypes = [],

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            IsActive = null,
            Name = null,
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EventType
        {
            Description = "description",
            EventTypeValue = "event_type",
            SubTypes = [],

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            IsActive = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EventType
        {
            DisplayName = "display_name",
            IsActive = true,
            Name = "name",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.EventTypeValue);
        Assert.False(model.RawData.ContainsKey("event_type"));
        Assert.Null(model.SubTypes);
        Assert.False(model.RawData.ContainsKey("sub_types"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EventType
        {
            DisplayName = "display_name",
            IsActive = true,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EventType
        {
            DisplayName = "display_name",
            IsActive = true,
            Name = "name",

            Description = null,
            EventTypeValue = null,
            SubTypes = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.EventTypeValue);
        Assert.True(model.RawData.ContainsKey("event_type"));
        Assert.Null(model.SubTypes);
        Assert.True(model.RawData.ContainsKey("sub_types"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EventType
        {
            DisplayName = "display_name",
            IsActive = true,
            Name = "name",

            Description = null,
            EventTypeValue = null,
            SubTypes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventType
        {
            Description = "description",
            DisplayName = "display_name",
            EventTypeValue = "event_type",
            IsActive = true,
            Name = "name",
            SubTypes = [],
        };

        EventType copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookListEventTypesResponseDataPaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListEventTypesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        WebhookListEventTypesResponseDataPaginationCursors expectedCursors = new()
        {
            After = "after",
            Before = "before",
        };
        bool expectedHasMore = true;
        int expectedPage = 0;
        int expectedPageSize = 0;
        int expectedTotalCount = 0;
        int expectedTotalPages = 0;

        Assert.Equal(expectedCursors, model.Cursors);
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedPageSize, model.PageSize);
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.Equal(expectedTotalPages, model.TotalPages);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookListEventTypesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListEventTypesResponseDataPagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListEventTypesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListEventTypesResponseDataPagination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WebhookListEventTypesResponseDataPaginationCursors expectedCursors = new()
        {
            After = "after",
            Before = "before",
        };
        bool expectedHasMore = true;
        int expectedPage = 0;
        int expectedPageSize = 0;
        int expectedTotalCount = 0;
        int expectedTotalPages = 0;

        Assert.Equal(expectedCursors, deserialized.Cursors);
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedPageSize, deserialized.PageSize);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.Equal(expectedTotalPages, deserialized.TotalPages);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookListEventTypesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookListEventTypesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },
        };

        Assert.Null(model.HasMore);
        Assert.False(model.RawData.ContainsKey("has_more"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PageSize);
        Assert.False(model.RawData.ContainsKey("page_size"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("total_count"));
        Assert.Null(model.TotalPages);
        Assert.False(model.RawData.ContainsKey("total_pages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookListEventTypesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookListEventTypesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },

            // Null should be interpreted as omitted for these properties
            HasMore = null,
            Page = null,
            PageSize = null,
            TotalCount = null,
            TotalPages = null,
        };

        Assert.Null(model.HasMore);
        Assert.False(model.RawData.ContainsKey("has_more"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PageSize);
        Assert.False(model.RawData.ContainsKey("page_size"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("total_count"));
        Assert.Null(model.TotalPages);
        Assert.False(model.RawData.ContainsKey("total_pages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookListEventTypesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },

            // Null should be interpreted as omitted for these properties
            HasMore = null,
            Page = null,
            PageSize = null,
            TotalCount = null,
            TotalPages = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookListEventTypesResponseDataPagination
        {
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.Null(model.Cursors);
        Assert.False(model.RawData.ContainsKey("cursors"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookListEventTypesResponseDataPagination
        {
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookListEventTypesResponseDataPagination
        {
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,

            Cursors = null,
        };

        Assert.Null(model.Cursors);
        Assert.True(model.RawData.ContainsKey("cursors"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookListEventTypesResponseDataPagination
        {
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,

            Cursors = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookListEventTypesResponseDataPagination
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        WebhookListEventTypesResponseDataPagination copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookListEventTypesResponseDataPaginationCursorsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListEventTypesResponseDataPaginationCursors
        {
            After = "after",
            Before = "before",
        };

        string expectedAfter = "after";
        string expectedBefore = "before";

        Assert.Equal(expectedAfter, model.After);
        Assert.Equal(expectedBefore, model.Before);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookListEventTypesResponseDataPaginationCursors
        {
            After = "after",
            Before = "before",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WebhookListEventTypesResponseDataPaginationCursors>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListEventTypesResponseDataPaginationCursors
        {
            After = "after",
            Before = "before",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WebhookListEventTypesResponseDataPaginationCursors>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAfter = "after";
        string expectedBefore = "before";

        Assert.Equal(expectedAfter, deserialized.After);
        Assert.Equal(expectedBefore, deserialized.Before);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookListEventTypesResponseDataPaginationCursors
        {
            After = "after",
            Before = "before",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookListEventTypesResponseDataPaginationCursors { };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookListEventTypesResponseDataPaginationCursors { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookListEventTypesResponseDataPaginationCursors
        {
            After = null,
            Before = null,
        };

        Assert.Null(model.After);
        Assert.True(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.True(model.RawData.ContainsKey("before"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookListEventTypesResponseDataPaginationCursors
        {
            After = null,
            Before = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookListEventTypesResponseDataPaginationCursors
        {
            After = "after",
            Before = "before",
        };

        WebhookListEventTypesResponseDataPaginationCursors copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookListEventTypesResponseErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListEventTypesResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string expectedCode = "code";
        Dictionary<string, List<string>> expectedDetails = new() { { "foo", ["string"] } };
        string expectedDocUrl = "doc_url";
        string expectedMessage = "message";

        Assert.Equal(expectedCode, model.Code);
        Assert.NotNull(model.Details);
        Assert.Equal(expectedDetails.Count, model.Details.Count);
        foreach (var item in expectedDetails)
        {
            Assert.True(model.Details.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, model.Details[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], model.Details[item.Key][i]);
            }
        }
        Assert.Equal(expectedDocUrl, model.DocUrl);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookListEventTypesResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListEventTypesResponseError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListEventTypesResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListEventTypesResponseError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCode = "code";
        Dictionary<string, List<string>> expectedDetails = new() { { "foo", ["string"] } };
        string expectedDocUrl = "doc_url";
        string expectedMessage = "message";

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.NotNull(deserialized.Details);
        Assert.Equal(expectedDetails.Count, deserialized.Details.Count);
        foreach (var item in expectedDetails)
        {
            Assert.True(deserialized.Details.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, deserialized.Details[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], deserialized.Details[item.Key][i]);
            }
        }
        Assert.Equal(expectedDocUrl, deserialized.DocUrl);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookListEventTypesResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookListEventTypesResponseError
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookListEventTypesResponseError
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookListEventTypesResponseError
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",

            // Null should be interpreted as omitted for these properties
            Code = null,
            Message = null,
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookListEventTypesResponseError
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",

            // Null should be interpreted as omitted for these properties
            Code = null,
            Message = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookListEventTypesResponseError { Code = "code", Message = "message" };

        Assert.Null(model.Details);
        Assert.False(model.RawData.ContainsKey("details"));
        Assert.Null(model.DocUrl);
        Assert.False(model.RawData.ContainsKey("doc_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookListEventTypesResponseError { Code = "code", Message = "message" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookListEventTypesResponseError
        {
            Code = "code",
            Message = "message",

            Details = null,
            DocUrl = null,
        };

        Assert.Null(model.Details);
        Assert.True(model.RawData.ContainsKey("details"));
        Assert.Null(model.DocUrl);
        Assert.True(model.RawData.ContainsKey("doc_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookListEventTypesResponseError
        {
            Code = "code",
            Message = "message",

            Details = null,
            DocUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookListEventTypesResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        WebhookListEventTypesResponseError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookListEventTypesResponseMetaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListEventTypesResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string expectedRequestID = "request_id";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVersion = "version";

        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookListEventTypesResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListEventTypesResponseMeta>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListEventTypesResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListEventTypesResponseMeta>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRequestID = "request_id";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVersion = "version";

        Assert.Equal(expectedRequestID, deserialized.RequestID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookListEventTypesResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookListEventTypesResponseMeta { };

        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookListEventTypesResponseMeta { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookListEventTypesResponseMeta
        {
            // Null should be interpreted as omitted for these properties
            RequestID = null,
            Timestamp = null,
            Version = null,
        };

        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookListEventTypesResponseMeta
        {
            // Null should be interpreted as omitted for these properties
            RequestID = null,
            Timestamp = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookListEventTypesResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        WebhookListEventTypesResponseMeta copied = new(model);

        Assert.Equal(model, copied);
    }
}
