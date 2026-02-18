using System;
using System.Collections.Generic;
using System.Net.Http;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            DisplayName = "Updated Order Notifications",
            EndpointUrl = "https://example.com/webhooks/orders-v2",
            EventTypes = ["messages", "templates"],
            RetryCount = 5,
            TestMode = false,
            TimeoutSeconds = 60,
            IdempotencyKey = "req_abc123_retry1",
        };

        string expectedID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8";
        string expectedDisplayName = "Updated Order Notifications";
        string expectedEndpointUrl = "https://example.com/webhooks/orders-v2";
        List<string> expectedEventTypes = ["messages", "templates"];
        int expectedRetryCount = 5;
        bool expectedTestMode = false;
        int expectedTimeoutSeconds = 60;
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedEndpointUrl, parameters.EndpointUrl);
        Assert.NotNull(parameters.EventTypes);
        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.Equal(expectedRetryCount, parameters.RetryCount);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.Equal(expectedTimeoutSeconds, parameters.TimeoutSeconds);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookUpdateParams { ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8" };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.EndpointUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("endpoint_url"));
        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("event_types"));
        Assert.Null(parameters.RetryCount);
        Assert.False(parameters.RawBodyData.ContainsKey("retry_count"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.TimeoutSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("timeout_seconds"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            EndpointUrl = null,
            EventTypes = null,
            RetryCount = null,
            TestMode = null,
            TimeoutSeconds = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.EndpointUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("endpoint_url"));
        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("event_types"));
        Assert.Null(parameters.RetryCount);
        Assert.False(parameters.RawBodyData.ContainsKey("retry_count"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.TimeoutSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("timeout_seconds"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookUpdateParams parameters = new() { ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/webhooks/d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8"),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WebhookUpdateParams parameters = new()
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            IdempotencyKey = "req_abc123_retry1",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            DisplayName = "Updated Order Notifications",
            EndpointUrl = "https://example.com/webhooks/orders-v2",
            EventTypes = ["messages", "templates"],
            RetryCount = 5,
            TestMode = false,
            TimeoutSeconds = 60,
            IdempotencyKey = "req_abc123_retry1",
        };

        WebhookUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
