using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookRetrieveResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DisplayName = "display_name",
                EndpointUrl = "endpoint_url",
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
                IsActive = true,
                LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RetryCount = 0,
                SigningSecret = "signing_secret",
                TimeoutSeconds = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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

        WebhookRetrieveResponseData expectedData = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
            IsActive = true,
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryCount = 0,
            SigningSecret = "signing_secret",
            TimeoutSeconds = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        WebhookRetrieveResponseError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        WebhookRetrieveResponseMeta expectedMeta = new()
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
        var model = new WebhookRetrieveResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DisplayName = "display_name",
                EndpointUrl = "endpoint_url",
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
                IsActive = true,
                LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RetryCount = 0,
                SigningSecret = "signing_secret",
                TimeoutSeconds = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var deserialized = JsonSerializer.Deserialize<WebhookRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookRetrieveResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DisplayName = "display_name",
                EndpointUrl = "endpoint_url",
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
                IsActive = true,
                LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RetryCount = 0,
                SigningSecret = "signing_secret",
                TimeoutSeconds = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var deserialized = JsonSerializer.Deserialize<WebhookRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WebhookRetrieveResponseData expectedData = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
            IsActive = true,
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryCount = 0,
            SigningSecret = "signing_secret",
            TimeoutSeconds = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        WebhookRetrieveResponseError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        WebhookRetrieveResponseMeta expectedMeta = new()
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
        var model = new WebhookRetrieveResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DisplayName = "display_name",
                EndpointUrl = "endpoint_url",
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
                IsActive = true,
                LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RetryCount = 0,
                SigningSecret = "signing_secret",
                TimeoutSeconds = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new WebhookRetrieveResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DisplayName = "display_name",
                EndpointUrl = "endpoint_url",
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
                IsActive = true,
                LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RetryCount = 0,
                SigningSecret = "signing_secret",
                TimeoutSeconds = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new WebhookRetrieveResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DisplayName = "display_name",
                EndpointUrl = "endpoint_url",
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
                IsActive = true,
                LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RetryCount = 0,
                SigningSecret = "signing_secret",
                TimeoutSeconds = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new WebhookRetrieveResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DisplayName = "display_name",
                EndpointUrl = "endpoint_url",
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
                IsActive = true,
                LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RetryCount = 0,
                SigningSecret = "signing_secret",
                TimeoutSeconds = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new WebhookRetrieveResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DisplayName = "display_name",
                EndpointUrl = "endpoint_url",
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
                IsActive = true,
                LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RetryCount = 0,
                SigningSecret = "signing_secret",
                TimeoutSeconds = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new WebhookRetrieveResponse
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
        var model = new WebhookRetrieveResponse
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
        var model = new WebhookRetrieveResponse
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
        var model = new WebhookRetrieveResponse
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
        var model = new WebhookRetrieveResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DisplayName = "display_name",
                EndpointUrl = "endpoint_url",
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
                IsActive = true,
                LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RetryCount = 0,
                SigningSecret = "signing_secret",
                TimeoutSeconds = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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

        WebhookRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookRetrieveResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookRetrieveResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
            IsActive = true,
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryCount = 0,
            SigningSecret = "signing_secret",
            TimeoutSeconds = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        int expectedConsecutiveFailures = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDisplayName = "display_name";
        string expectedEndpointUrl = "endpoint_url";
        Dictionary<string, List<string>> expectedEventFilters = new() { { "foo", ["string"] } };
        List<string> expectedEventTypes = ["string"];
        bool expectedIsActive = true;
        DateTimeOffset expectedLastDeliveryAttemptAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedLastSuccessfulDeliveryAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        int expectedRetryCount = 0;
        string expectedSigningSecret = "signing_secret";
        int expectedTimeoutSeconds = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConsecutiveFailures, model.ConsecutiveFailures);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEndpointUrl, model.EndpointUrl);
        Assert.NotNull(model.EventFilters);
        Assert.Equal(expectedEventFilters.Count, model.EventFilters.Count);
        foreach (var item in expectedEventFilters)
        {
            Assert.True(model.EventFilters.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, model.EventFilters[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], model.EventFilters[item.Key][i]);
            }
        }
        Assert.NotNull(model.EventTypes);
        Assert.Equal(expectedEventTypes.Count, model.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], model.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedLastDeliveryAttemptAt, model.LastDeliveryAttemptAt);
        Assert.Equal(expectedLastSuccessfulDeliveryAt, model.LastSuccessfulDeliveryAt);
        Assert.Equal(expectedRetryCount, model.RetryCount);
        Assert.Equal(expectedSigningSecret, model.SigningSecret);
        Assert.Equal(expectedTimeoutSeconds, model.TimeoutSeconds);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookRetrieveResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
            IsActive = true,
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryCount = 0,
            SigningSecret = "signing_secret",
            TimeoutSeconds = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookRetrieveResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookRetrieveResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
            IsActive = true,
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryCount = 0,
            SigningSecret = "signing_secret",
            TimeoutSeconds = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookRetrieveResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        int expectedConsecutiveFailures = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDisplayName = "display_name";
        string expectedEndpointUrl = "endpoint_url";
        Dictionary<string, List<string>> expectedEventFilters = new() { { "foo", ["string"] } };
        List<string> expectedEventTypes = ["string"];
        bool expectedIsActive = true;
        DateTimeOffset expectedLastDeliveryAttemptAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedLastSuccessfulDeliveryAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        int expectedRetryCount = 0;
        string expectedSigningSecret = "signing_secret";
        int expectedTimeoutSeconds = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConsecutiveFailures, deserialized.ConsecutiveFailures);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEndpointUrl, deserialized.EndpointUrl);
        Assert.NotNull(deserialized.EventFilters);
        Assert.Equal(expectedEventFilters.Count, deserialized.EventFilters.Count);
        foreach (var item in expectedEventFilters)
        {
            Assert.True(deserialized.EventFilters.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, deserialized.EventFilters[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], deserialized.EventFilters[item.Key][i]);
            }
        }
        Assert.NotNull(deserialized.EventTypes);
        Assert.Equal(expectedEventTypes.Count, deserialized.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], deserialized.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedLastDeliveryAttemptAt, deserialized.LastDeliveryAttemptAt);
        Assert.Equal(expectedLastSuccessfulDeliveryAt, deserialized.LastSuccessfulDeliveryAt);
        Assert.Equal(expectedRetryCount, deserialized.RetryCount);
        Assert.Equal(expectedSigningSecret, deserialized.SigningSecret);
        Assert.Equal(expectedTimeoutSeconds, deserialized.TimeoutSeconds);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookRetrieveResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
            IsActive = true,
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryCount = 0,
            SigningSecret = "signing_secret",
            TimeoutSeconds = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookRetrieveResponseData
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SigningSecret = "signing_secret",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ConsecutiveFailures);
        Assert.False(model.RawData.ContainsKey("consecutive_failures"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.EndpointUrl);
        Assert.False(model.RawData.ContainsKey("endpoint_url"));
        Assert.Null(model.EventTypes);
        Assert.False(model.RawData.ContainsKey("event_types"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.RetryCount);
        Assert.False(model.RawData.ContainsKey("retry_count"));
        Assert.Null(model.TimeoutSeconds);
        Assert.False(model.RawData.ContainsKey("timeout_seconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookRetrieveResponseData
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SigningSecret = "signing_secret",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookRetrieveResponseData
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SigningSecret = "signing_secret",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            ConsecutiveFailures = null,
            CreatedAt = null,
            DisplayName = null,
            EndpointUrl = null,
            EventTypes = null,
            IsActive = null,
            RetryCount = null,
            TimeoutSeconds = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ConsecutiveFailures);
        Assert.False(model.RawData.ContainsKey("consecutive_failures"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.EndpointUrl);
        Assert.False(model.RawData.ContainsKey("endpoint_url"));
        Assert.Null(model.EventTypes);
        Assert.False(model.RawData.ContainsKey("event_types"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.RetryCount);
        Assert.False(model.RawData.ContainsKey("retry_count"));
        Assert.Null(model.TimeoutSeconds);
        Assert.False(model.RawData.ContainsKey("timeout_seconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookRetrieveResponseData
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SigningSecret = "signing_secret",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            ConsecutiveFailures = null,
            CreatedAt = null,
            DisplayName = null,
            EndpointUrl = null,
            EventTypes = null,
            IsActive = null,
            RetryCount = null,
            TimeoutSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookRetrieveResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventTypes = ["string"],
            IsActive = true,
            RetryCount = 0,
            TimeoutSeconds = 0,
        };

        Assert.Null(model.EventFilters);
        Assert.False(model.RawData.ContainsKey("event_filters"));
        Assert.Null(model.LastDeliveryAttemptAt);
        Assert.False(model.RawData.ContainsKey("last_delivery_attempt_at"));
        Assert.Null(model.LastSuccessfulDeliveryAt);
        Assert.False(model.RawData.ContainsKey("last_successful_delivery_at"));
        Assert.Null(model.SigningSecret);
        Assert.False(model.RawData.ContainsKey("signing_secret"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookRetrieveResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventTypes = ["string"],
            IsActive = true,
            RetryCount = 0,
            TimeoutSeconds = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookRetrieveResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventTypes = ["string"],
            IsActive = true,
            RetryCount = 0,
            TimeoutSeconds = 0,

            EventFilters = null,
            LastDeliveryAttemptAt = null,
            LastSuccessfulDeliveryAt = null,
            SigningSecret = null,
            UpdatedAt = null,
        };

        Assert.Null(model.EventFilters);
        Assert.True(model.RawData.ContainsKey("event_filters"));
        Assert.Null(model.LastDeliveryAttemptAt);
        Assert.True(model.RawData.ContainsKey("last_delivery_attempt_at"));
        Assert.Null(model.LastSuccessfulDeliveryAt);
        Assert.True(model.RawData.ContainsKey("last_successful_delivery_at"));
        Assert.Null(model.SigningSecret);
        Assert.True(model.RawData.ContainsKey("signing_secret"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookRetrieveResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventTypes = ["string"],
            IsActive = true,
            RetryCount = 0,
            TimeoutSeconds = 0,

            EventFilters = null,
            LastDeliveryAttemptAt = null,
            LastSuccessfulDeliveryAt = null,
            SigningSecret = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookRetrieveResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
            IsActive = true,
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryCount = 0,
            SigningSecret = "signing_secret",
            TimeoutSeconds = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        WebhookRetrieveResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookRetrieveResponseErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookRetrieveResponseError
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
        var model = new WebhookRetrieveResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookRetrieveResponseError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookRetrieveResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookRetrieveResponseError>(
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
        var model = new WebhookRetrieveResponseError
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
        var model = new WebhookRetrieveResponseError
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
        var model = new WebhookRetrieveResponseError
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookRetrieveResponseError
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
        var model = new WebhookRetrieveResponseError
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
        var model = new WebhookRetrieveResponseError { Code = "code", Message = "message" };

        Assert.Null(model.Details);
        Assert.False(model.RawData.ContainsKey("details"));
        Assert.Null(model.DocUrl);
        Assert.False(model.RawData.ContainsKey("doc_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookRetrieveResponseError { Code = "code", Message = "message" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookRetrieveResponseError
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
        var model = new WebhookRetrieveResponseError
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
        var model = new WebhookRetrieveResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        WebhookRetrieveResponseError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookRetrieveResponseMetaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookRetrieveResponseMeta
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
        var model = new WebhookRetrieveResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookRetrieveResponseMeta>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookRetrieveResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookRetrieveResponseMeta>(
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
        var model = new WebhookRetrieveResponseMeta
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
        var model = new WebhookRetrieveResponseMeta { };

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
        var model = new WebhookRetrieveResponseMeta { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookRetrieveResponseMeta
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
        var model = new WebhookRetrieveResponseMeta
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
        var model = new WebhookRetrieveResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        WebhookRetrieveResponseMeta copied = new(model);

        Assert.Equal(model, copied);
    }
}
