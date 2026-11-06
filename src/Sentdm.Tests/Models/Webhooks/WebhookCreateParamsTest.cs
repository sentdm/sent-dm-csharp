using System;
using System.Collections.Generic;
using System.Net.Http;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookCreateParams
        {
            DisplayName = "Order Notifications",
            EndpointUrl = "https://example.com/webhooks/orders",
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "message", ["delivered", "failed"] },
                { "templates", ["approved", "rejected"] },
            },
            EventTypes = ["contact", "message", "templates"],
            IsInheritable = false,
            RetryCount = 3,
            Sandbox = false,
            SenderProfile = new()
            {
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
            },
            TimeoutSeconds = 30,
            WebhookVersion = null,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedDisplayName = "Order Notifications";
        string expectedEndpointUrl = "https://example.com/webhooks/orders";
        Dictionary<string, List<string>> expectedEventFilters = new()
        {
            { "message", ["delivered", "failed"] },
            { "templates", ["approved", "rejected"] },
        };
        List<string> expectedEventTypes = ["contact", "message", "templates"];
        bool expectedIsInheritable = false;
        int expectedRetryCount = 3;
        bool expectedSandbox = false;
        WebhookSenderProfileConfig expectedSenderProfile = new()
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
        };
        int expectedTimeoutSeconds = 30;
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedEndpointUrl, parameters.EndpointUrl);
        Assert.NotNull(parameters.EventFilters);
        Assert.Equal(expectedEventFilters.Count, parameters.EventFilters.Count);
        foreach (var item in expectedEventFilters)
        {
            Assert.True(parameters.EventFilters.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, parameters.EventFilters[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], parameters.EventFilters[item.Key][i]);
            }
        }
        Assert.NotNull(parameters.EventTypes);
        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.Equal(expectedIsInheritable, parameters.IsInheritable);
        Assert.Equal(expectedRetryCount, parameters.RetryCount);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedSenderProfile, parameters.SenderProfile);
        Assert.Equal(expectedTimeoutSeconds, parameters.TimeoutSeconds);
        Assert.Null(parameters.WebhookVersion);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookCreateParams
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "message", ["delivered", "failed"] },
                { "templates", ["approved", "rejected"] },
            },
            SenderProfile = new()
            {
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
            },
            WebhookVersion = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.EndpointUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("endpoint_url"));
        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("event_types"));
        Assert.Null(parameters.IsInheritable);
        Assert.False(parameters.RawBodyData.ContainsKey("is_inheritable"));
        Assert.Null(parameters.RetryCount);
        Assert.False(parameters.RawBodyData.ContainsKey("retry_count"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.TimeoutSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("timeout_seconds"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookCreateParams
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "message", ["delivered", "failed"] },
                { "templates", ["approved", "rejected"] },
            },
            SenderProfile = new()
            {
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
            },
            WebhookVersion = null,

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            EndpointUrl = null,
            EventTypes = null,
            IsInheritable = null,
            RetryCount = null,
            Sandbox = null,
            TimeoutSeconds = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.EndpointUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("endpoint_url"));
        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("event_types"));
        Assert.Null(parameters.IsInheritable);
        Assert.False(parameters.RawBodyData.ContainsKey("is_inheritable"));
        Assert.Null(parameters.RetryCount);
        Assert.False(parameters.RawBodyData.ContainsKey("retry_count"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.TimeoutSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("timeout_seconds"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookCreateParams
        {
            DisplayName = "Order Notifications",
            EndpointUrl = "https://example.com/webhooks/orders",
            EventTypes = ["contact", "message", "templates"],
            IsInheritable = false,
            RetryCount = 3,
            Sandbox = false,
            TimeoutSeconds = 30,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.EventFilters);
        Assert.False(parameters.RawBodyData.ContainsKey("event_filters"));
        Assert.Null(parameters.SenderProfile);
        Assert.False(parameters.RawBodyData.ContainsKey("sender_profile"));
        Assert.Null(parameters.WebhookVersion);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_version"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WebhookCreateParams
        {
            DisplayName = "Order Notifications",
            EndpointUrl = "https://example.com/webhooks/orders",
            EventTypes = ["contact", "message", "templates"],
            IsInheritable = false,
            RetryCount = 3,
            Sandbox = false,
            TimeoutSeconds = 30,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            EventFilters = null,
            SenderProfile = null,
            WebhookVersion = null,
        };

        Assert.Null(parameters.EventFilters);
        Assert.True(parameters.RawBodyData.ContainsKey("event_filters"));
        Assert.Null(parameters.SenderProfile);
        Assert.True(parameters.RawBodyData.ContainsKey("sender_profile"));
        Assert.Null(parameters.WebhookVersion);
        Assert.True(parameters.RawBodyData.ContainsKey("webhook_version"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.sent.dm/v3/webhooks"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WebhookCreateParams parameters = new()
        {
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
        Assert.Equal(
            ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            requestMessage.Headers.GetValues("x-profile-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookCreateParams
        {
            DisplayName = "Order Notifications",
            EndpointUrl = "https://example.com/webhooks/orders",
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "message", ["delivered", "failed"] },
                { "templates", ["approved", "rejected"] },
            },
            EventTypes = ["contact", "message", "templates"],
            IsInheritable = false,
            RetryCount = 3,
            Sandbox = false,
            SenderProfile = new()
            {
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
            },
            TimeoutSeconds = 30,
            WebhookVersion = null,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        WebhookCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
