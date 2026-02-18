using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Messages;

namespace SentDm.Tests.Models.Messages;

public class MessageSendParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageSendParams
        {
            Channel = ["sms", "whatsapp"],
            Template = new()
            {
                ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
                Name = "order_confirmation",
                Parameters = new Dictionary<string, string>()
                {
                    { "name", "John Doe" },
                    { "order_id", "12345" },
                },
            },
            TestMode = false,
            To = ["+14155551234", "+14155555678"],
            IdempotencyKey = "req_abc123_retry1",
        };

        List<string> expectedChannel = ["sms", "whatsapp"];
        Template expectedTemplate = new()
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            Name = "order_confirmation",
            Parameters = new Dictionary<string, string>()
            {
                { "name", "John Doe" },
                { "order_id", "12345" },
            },
        };
        bool expectedTestMode = false;
        List<string> expectedTo = ["+14155551234", "+14155555678"];
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.NotNull(parameters.Channel);
        Assert.Equal(expectedChannel.Count, parameters.Channel.Count);
        for (int i = 0; i < expectedChannel.Count; i++)
        {
            Assert.Equal(expectedChannel[i], parameters.Channel[i]);
        }
        Assert.Equal(expectedTemplate, parameters.Template);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.NotNull(parameters.To);
        Assert.Equal(expectedTo.Count, parameters.To.Count);
        for (int i = 0; i < expectedTo.Count; i++)
        {
            Assert.Equal(expectedTo[i], parameters.To[i]);
        }
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MessageSendParams { Channel = ["sms", "whatsapp"] };

        Assert.Null(parameters.Template);
        Assert.False(parameters.RawBodyData.ContainsKey("template"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawBodyData.ContainsKey("to"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MessageSendParams
        {
            Channel = ["sms", "whatsapp"],

            // Null should be interpreted as omitted for these properties
            Template = null,
            TestMode = null,
            To = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.Template);
        Assert.False(parameters.RawBodyData.ContainsKey("template"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawBodyData.ContainsKey("to"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MessageSendParams
        {
            Template = new()
            {
                ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
                Name = "order_confirmation",
                Parameters = new Dictionary<string, string>()
                {
                    { "name", "John Doe" },
                    { "order_id", "12345" },
                },
            },
            TestMode = false,
            To = ["+14155551234", "+14155555678"],
            IdempotencyKey = "req_abc123_retry1",
        };

        Assert.Null(parameters.Channel);
        Assert.False(parameters.RawBodyData.ContainsKey("channel"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MessageSendParams
        {
            Template = new()
            {
                ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
                Name = "order_confirmation",
                Parameters = new Dictionary<string, string>()
                {
                    { "name", "John Doe" },
                    { "order_id", "12345" },
                },
            },
            TestMode = false,
            To = ["+14155551234", "+14155555678"],
            IdempotencyKey = "req_abc123_retry1",

            Channel = null,
        };

        Assert.Null(parameters.Channel);
        Assert.True(parameters.RawBodyData.ContainsKey("channel"));
    }

    [Fact]
    public void Url_Works()
    {
        MessageSendParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.sent.dm/v3/messages"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MessageSendParams parameters = new() { IdempotencyKey = "req_abc123_retry1" };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MessageSendParams
        {
            Channel = ["sms", "whatsapp"],
            Template = new()
            {
                ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
                Name = "order_confirmation",
                Parameters = new Dictionary<string, string>()
                {
                    { "name", "John Doe" },
                    { "order_id", "12345" },
                },
            },
            TestMode = false,
            To = ["+14155551234", "+14155555678"],
            IdempotencyKey = "req_abc123_retry1",
        };

        MessageSendParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TemplateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Template
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            Name = "order_confirmation",
            Parameters = new Dictionary<string, string>()
            {
                { "name", "John Doe" },
                { "order_id", "12345" },
            },
        };

        string expectedID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8";
        string expectedName = "order_confirmation";
        Dictionary<string, string> expectedParameters = new()
        {
            { "name", "John Doe" },
            { "order_id", "12345" },
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.Parameters);
        Assert.Equal(expectedParameters.Count, model.Parameters.Count);
        foreach (var item in expectedParameters)
        {
            Assert.True(model.Parameters.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Parameters[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Template
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            Name = "order_confirmation",
            Parameters = new Dictionary<string, string>()
            {
                { "name", "John Doe" },
                { "order_id", "12345" },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Template>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Template
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            Name = "order_confirmation",
            Parameters = new Dictionary<string, string>()
            {
                { "name", "John Doe" },
                { "order_id", "12345" },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Template>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8";
        string expectedName = "order_confirmation";
        Dictionary<string, string> expectedParameters = new()
        {
            { "name", "John Doe" },
            { "order_id", "12345" },
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.Parameters);
        Assert.Equal(expectedParameters.Count, deserialized.Parameters.Count);
        foreach (var item in expectedParameters)
        {
            Assert.True(deserialized.Parameters.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Parameters[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Template
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            Name = "order_confirmation",
            Parameters = new Dictionary<string, string>()
            {
                { "name", "John Doe" },
                { "order_id", "12345" },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Template { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Parameters);
        Assert.False(model.RawData.ContainsKey("parameters"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Template { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Template
        {
            ID = null,
            Name = null,
            Parameters = null,
        };

        Assert.Null(model.ID);
        Assert.True(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.Parameters);
        Assert.True(model.RawData.ContainsKey("parameters"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Template
        {
            ID = null,
            Name = null,
            Parameters = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Template
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            Name = "order_confirmation",
            Parameters = new Dictionary<string, string>()
            {
                { "name", "John Doe" },
                { "order_id", "12345" },
            },
        };

        Template copied = new(model);

        Assert.Equal(model, copied);
    }
}
