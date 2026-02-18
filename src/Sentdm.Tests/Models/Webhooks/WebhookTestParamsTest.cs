using System;
using System.Net.Http;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookTestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookTestParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            EventType = "message.sent",
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        string expectedID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8";
        string expectedEventType = "message.sent";
        bool expectedTestMode = false;
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEventType, parameters.EventType);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookTestParams { ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8" };

        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawBodyData.ContainsKey("event_type"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookTestParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",

            // Null should be interpreted as omitted for these properties
            EventType = null,
            TestMode = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawBodyData.ContainsKey("event_type"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookTestParams parameters = new() { ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/webhooks/d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8/test"),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WebhookTestParams parameters = new()
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
        var parameters = new WebhookTestParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            EventType = "message.sent",
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        WebhookTestParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
