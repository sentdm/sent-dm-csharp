using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
            IsActive = true,
            IsInheritable = true,
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryCount = 0,
            SenderProfile = new()
            {
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
            },
            SigningSecret = "signing_secret",
            TimeoutSeconds = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookVersion = 0,
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        int expectedConsecutiveFailures = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDisplayName = "display_name";
        string expectedEndpointUrl = "endpoint_url";
        Dictionary<string, List<string>> expectedEventFilters = new() { { "foo", ["string"] } };
        List<string> expectedEventTypes = ["string"];
        bool expectedIsActive = true;
        bool expectedIsInheritable = true;
        DateTimeOffset expectedLastDeliveryAttemptAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedLastSuccessfulDeliveryAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        int expectedRetryCount = 0;
        WebhookResponseSenderProfile expectedSenderProfile = new()
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
        };
        string expectedSigningSecret = "signing_secret";
        int expectedTimeoutSeconds = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedWebhookVersion = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConsecutiveFailures, model.ConsecutiveFailures);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
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
        Assert.Equal(expectedIsInheritable, model.IsInheritable);
        Assert.Equal(expectedLastDeliveryAttemptAt, model.LastDeliveryAttemptAt);
        Assert.Equal(expectedLastSuccessfulDeliveryAt, model.LastSuccessfulDeliveryAt);
        Assert.Equal(expectedRetryCount, model.RetryCount);
        Assert.Equal(expectedSenderProfile, model.SenderProfile);
        Assert.Equal(expectedSigningSecret, model.SigningSecret);
        Assert.Equal(expectedTimeoutSeconds, model.TimeoutSeconds);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedWebhookVersion, model.WebhookVersion);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
            IsActive = true,
            IsInheritable = true,
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryCount = 0,
            SenderProfile = new()
            {
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
            },
            SigningSecret = "signing_secret",
            TimeoutSeconds = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookVersion = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
            IsActive = true,
            IsInheritable = true,
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryCount = 0,
            SenderProfile = new()
            {
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
            },
            SigningSecret = "signing_secret",
            TimeoutSeconds = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookVersion = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        int expectedConsecutiveFailures = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDisplayName = "display_name";
        string expectedEndpointUrl = "endpoint_url";
        Dictionary<string, List<string>> expectedEventFilters = new() { { "foo", ["string"] } };
        List<string> expectedEventTypes = ["string"];
        bool expectedIsActive = true;
        bool expectedIsInheritable = true;
        DateTimeOffset expectedLastDeliveryAttemptAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedLastSuccessfulDeliveryAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        int expectedRetryCount = 0;
        WebhookResponseSenderProfile expectedSenderProfile = new()
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
        };
        string expectedSigningSecret = "signing_secret";
        int expectedTimeoutSeconds = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedWebhookVersion = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConsecutiveFailures, deserialized.ConsecutiveFailures);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
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
        Assert.Equal(expectedIsInheritable, deserialized.IsInheritable);
        Assert.Equal(expectedLastDeliveryAttemptAt, deserialized.LastDeliveryAttemptAt);
        Assert.Equal(expectedLastSuccessfulDeliveryAt, deserialized.LastSuccessfulDeliveryAt);
        Assert.Equal(expectedRetryCount, deserialized.RetryCount);
        Assert.Equal(expectedSenderProfile, deserialized.SenderProfile);
        Assert.Equal(expectedSigningSecret, deserialized.SigningSecret);
        Assert.Equal(expectedTimeoutSeconds, deserialized.TimeoutSeconds);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedWebhookVersion, deserialized.WebhookVersion);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
            IsActive = true,
            IsInheritable = true,
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryCount = 0,
            SenderProfile = new()
            {
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
            },
            SigningSecret = "signing_secret",
            TimeoutSeconds = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookVersion = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookResponse
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderProfile = new()
            {
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
            },
            SigningSecret = "signing_secret",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ConsecutiveFailures);
        Assert.False(model.RawData.ContainsKey("consecutive_failures"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customer_id"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.EndpointUrl);
        Assert.False(model.RawData.ContainsKey("endpoint_url"));
        Assert.Null(model.EventTypes);
        Assert.False(model.RawData.ContainsKey("event_types"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.IsInheritable);
        Assert.False(model.RawData.ContainsKey("is_inheritable"));
        Assert.Null(model.RetryCount);
        Assert.False(model.RawData.ContainsKey("retry_count"));
        Assert.Null(model.TimeoutSeconds);
        Assert.False(model.RawData.ContainsKey("timeout_seconds"));
        Assert.Null(model.WebhookVersion);
        Assert.False(model.RawData.ContainsKey("webhook_version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookResponse
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderProfile = new()
            {
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
            },
            SigningSecret = "signing_secret",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookResponse
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderProfile = new()
            {
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
            },
            SigningSecret = "signing_secret",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            ConsecutiveFailures = null,
            CreatedAt = null,
            CustomerID = null,
            DisplayName = null,
            EndpointUrl = null,
            EventTypes = null,
            IsActive = null,
            IsInheritable = null,
            RetryCount = null,
            TimeoutSeconds = null,
            WebhookVersion = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ConsecutiveFailures);
        Assert.False(model.RawData.ContainsKey("consecutive_failures"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customer_id"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.EndpointUrl);
        Assert.False(model.RawData.ContainsKey("endpoint_url"));
        Assert.Null(model.EventTypes);
        Assert.False(model.RawData.ContainsKey("event_types"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.IsInheritable);
        Assert.False(model.RawData.ContainsKey("is_inheritable"));
        Assert.Null(model.RetryCount);
        Assert.False(model.RawData.ContainsKey("retry_count"));
        Assert.Null(model.TimeoutSeconds);
        Assert.False(model.RawData.ContainsKey("timeout_seconds"));
        Assert.Null(model.WebhookVersion);
        Assert.False(model.RawData.ContainsKey("webhook_version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookResponse
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderProfile = new()
            {
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
            },
            SigningSecret = "signing_secret",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            ConsecutiveFailures = null,
            CreatedAt = null,
            CustomerID = null,
            DisplayName = null,
            EndpointUrl = null,
            EventTypes = null,
            IsActive = null,
            IsInheritable = null,
            RetryCount = null,
            TimeoutSeconds = null,
            WebhookVersion = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventTypes = ["string"],
            IsActive = true,
            IsInheritable = true,
            RetryCount = 0,
            TimeoutSeconds = 0,
            WebhookVersion = 0,
        };

        Assert.Null(model.EventFilters);
        Assert.False(model.RawData.ContainsKey("event_filters"));
        Assert.Null(model.LastDeliveryAttemptAt);
        Assert.False(model.RawData.ContainsKey("last_delivery_attempt_at"));
        Assert.Null(model.LastSuccessfulDeliveryAt);
        Assert.False(model.RawData.ContainsKey("last_successful_delivery_at"));
        Assert.Null(model.SenderProfile);
        Assert.False(model.RawData.ContainsKey("sender_profile"));
        Assert.Null(model.SigningSecret);
        Assert.False(model.RawData.ContainsKey("signing_secret"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventTypes = ["string"],
            IsActive = true,
            IsInheritable = true,
            RetryCount = 0,
            TimeoutSeconds = 0,
            WebhookVersion = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventTypes = ["string"],
            IsActive = true,
            IsInheritable = true,
            RetryCount = 0,
            TimeoutSeconds = 0,
            WebhookVersion = 0,

            EventFilters = null,
            LastDeliveryAttemptAt = null,
            LastSuccessfulDeliveryAt = null,
            SenderProfile = null,
            SigningSecret = null,
            UpdatedAt = null,
        };

        Assert.Null(model.EventFilters);
        Assert.True(model.RawData.ContainsKey("event_filters"));
        Assert.Null(model.LastDeliveryAttemptAt);
        Assert.True(model.RawData.ContainsKey("last_delivery_attempt_at"));
        Assert.Null(model.LastSuccessfulDeliveryAt);
        Assert.True(model.RawData.ContainsKey("last_successful_delivery_at"));
        Assert.Null(model.SenderProfile);
        Assert.True(model.RawData.ContainsKey("sender_profile"));
        Assert.Null(model.SigningSecret);
        Assert.True(model.RawData.ContainsKey("signing_secret"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventTypes = ["string"],
            IsActive = true,
            IsInheritable = true,
            RetryCount = 0,
            TimeoutSeconds = 0,
            WebhookVersion = 0,

            EventFilters = null,
            LastDeliveryAttemptAt = null,
            LastSuccessfulDeliveryAt = null,
            SenderProfile = null,
            SigningSecret = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
            IsActive = true,
            IsInheritable = true,
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryCount = 0,
            SenderProfile = new()
            {
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
            },
            SigningSecret = "signing_secret",
            TimeoutSeconds = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookVersion = 0,
        };

        WebhookResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookResponseSenderProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookResponseSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
        };

        Dictionary<string, List<string>> expectedEventFilters = new() { { "foo", ["string"] } };
        List<string> expectedEventTypes = ["string"];

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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookResponseSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookResponseSenderProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookResponseSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookResponseSenderProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, List<string>> expectedEventFilters = new() { { "foo", ["string"] } };
        List<string> expectedEventTypes = ["string"];

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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookResponseSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookResponseSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
        };

        Assert.Null(model.EventTypes);
        Assert.False(model.RawData.ContainsKey("event_types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookResponseSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookResponseSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },

            // Null should be interpreted as omitted for these properties
            EventTypes = null,
        };

        Assert.Null(model.EventTypes);
        Assert.False(model.RawData.ContainsKey("event_types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookResponseSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },

            // Null should be interpreted as omitted for these properties
            EventTypes = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookResponseSenderProfile { EventTypes = ["string"] };

        Assert.Null(model.EventFilters);
        Assert.False(model.RawData.ContainsKey("event_filters"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookResponseSenderProfile { EventTypes = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookResponseSenderProfile
        {
            EventTypes = ["string"],

            EventFilters = null,
        };

        Assert.Null(model.EventFilters);
        Assert.True(model.RawData.ContainsKey("event_filters"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookResponseSenderProfile
        {
            EventTypes = ["string"],

            EventFilters = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookResponseSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
        };

        WebhookResponseSenderProfile copied = new(model);

        Assert.Equal(model, copied);
    }
}
