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
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
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
        var model = new WebhookResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
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
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
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
        var deserialized = JsonSerializer.Deserialize<WebhookResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        int expectedConsecutiveFailures = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDisplayName = "display_name";
        string expectedEndpointUrl = "endpoint_url";
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
        var model = new WebhookResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
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
        var model = new WebhookResponse
        {
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
        var model = new WebhookResponse
        {
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
        var model = new WebhookResponse
        {
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
        var model = new WebhookResponse
        {
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
        var model = new WebhookResponse
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
        var model = new WebhookResponse
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
        var model = new WebhookResponse
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

            LastDeliveryAttemptAt = null,
            LastSuccessfulDeliveryAt = null,
            SigningSecret = null,
            UpdatedAt = null,
        };

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
        var model = new WebhookResponse
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
        var model = new WebhookResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            EventTypes = ["string"],
            IsActive = true,
            LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryCount = 0,
            SigningSecret = "signing_secret",
            TimeoutSeconds = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        WebhookResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
