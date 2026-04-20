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
                        SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    },
                ],
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
                    SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                },
            ],
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
                        SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    },
                ],
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
                        SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    },
                ],
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
                    SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                },
            ],
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
                        SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    },
                ],
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
                        SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    },
                ],
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
                        SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    },
                ],
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
                        SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    },
                ],
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
                        SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    },
                ],
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
                        SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    },
                ],
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
                    SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                },
            ],
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
                SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
        ];

        Assert.NotNull(model.EventTypes);
        Assert.Equal(expectedEventTypes.Count, model.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], model.EventTypes[i]);
        }
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
                    SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                },
            ],
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
                    SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                },
            ],
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
                SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
            },
        ];

        Assert.NotNull(deserialized.EventTypes);
        Assert.Equal(expectedEventTypes.Count, deserialized.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], deserialized.EventTypes[i]);
        }
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
                    SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookListEventTypesResponseData { };

        Assert.Null(model.EventTypes);
        Assert.False(model.RawData.ContainsKey("event_types"));
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
        };

        Assert.Null(model.EventTypes);
        Assert.False(model.RawData.ContainsKey("event_types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookListEventTypesResponseData
        {
            // Null should be interpreted as omitted for these properties
            EventTypes = null,
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
                    SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
                },
            ],
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
            SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string expectedDescription = "description";
        string expectedDisplayName = "display_name";
        string expectedEventTypeValue = "event_type";
        bool expectedIsActive = true;
        string expectedName = "name";
        List<JsonElement> expectedSubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")];

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
            SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
            SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
        List<JsonElement> expectedSubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")];

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
            SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
            SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
            SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
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
            SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],

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
            SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],

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
            SubTypes = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        EventType copied = new(model);

        Assert.Equal(model, copied);
    }
}
