using System;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookRotateSecretParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookRotateSecretParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            Body = new() { Sandbox = false },
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8";
        Body expectedBody = new() { Sandbox = false };
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedBody, parameters.Body);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookRotateSecretParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            Body = new() { Sandbox = false },
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookRotateSecretParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            Body = new() { Sandbox = false },

            // Null should be interpreted as omitted for these properties
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookRotateSecretParams parameters = new()
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            Body = new() { Sandbox = false },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.sent.dm/v3/webhooks/d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8/rotate-secret"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WebhookRotateSecretParams parameters = new()
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            Body = new() { Sandbox = false },
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
        var parameters = new WebhookRotateSecretParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            Body = new() { Sandbox = false },
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        WebhookRotateSecretParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BodyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Body { Sandbox = false };

        bool expectedSandbox = false;

        Assert.Equal(expectedSandbox, model.Sandbox);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Body { Sandbox = false };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Body { Sandbox = false };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedSandbox = false;

        Assert.Equal(expectedSandbox, deserialized.Sandbox);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Body { Sandbox = false };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Body { };

        Assert.Null(model.Sandbox);
        Assert.False(model.RawData.ContainsKey("sandbox"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Body { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Body
        {
            // Null should be interpreted as omitted for these properties
            Sandbox = null,
        };

        Assert.Null(model.Sandbox);
        Assert.False(model.RawData.ContainsKey("sandbox"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Body
        {
            // Null should be interpreted as omitted for these properties
            Sandbox = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Body { Sandbox = false };

        Body copied = new(model);

        Assert.Equal(model, copied);
    }
}
