using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Messages;

namespace Sentdm.Tests.Models.Messages;

public class MessageSendParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageSendParams
        {
            Channel = ["sms", "whatsapp"],
            Channels = new Dictionary<
                string,
                IReadOnlyList<SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest>
            >()
            {
                {
                    "foo",
                    [
                        new()
                        {
                            Country = "country",
                            From = ["string"],
                            Strategy = "strategy",
                        },
                    ]
                },
            },
            MediaUrls = ["string"],
            Sandbox = false,
            ScheduledAt = null,
            Subject = null,
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
            Text = null,
            To = ["+14155551234", "+14155555678"],
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        List<string> expectedChannel = ["sms", "whatsapp"];
        Dictionary<
            string,
            List<SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest>
        > expectedChannels = new()
        {
            {
                "foo",
                [
                    new()
                    {
                        Country = "country",
                        From = ["string"],
                        Strategy = "strategy",
                    },
                ]
            },
        };
        List<string> expectedMediaUrls = ["string"];
        bool expectedSandbox = false;
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
        List<string> expectedTo = ["+14155551234", "+14155555678"];
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.NotNull(parameters.Channel);
        Assert.Equal(expectedChannel.Count, parameters.Channel.Count);
        for (int i = 0; i < expectedChannel.Count; i++)
        {
            Assert.Equal(expectedChannel[i], parameters.Channel[i]);
        }
        Assert.NotNull(parameters.Channels);
        Assert.Equal(expectedChannels.Count, parameters.Channels.Count);
        foreach (var item in expectedChannels)
        {
            Assert.True(parameters.Channels.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, parameters.Channels[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], parameters.Channels[item.Key][i]);
            }
        }
        Assert.NotNull(parameters.MediaUrls);
        Assert.Equal(expectedMediaUrls.Count, parameters.MediaUrls.Count);
        for (int i = 0; i < expectedMediaUrls.Count; i++)
        {
            Assert.Equal(expectedMediaUrls[i], parameters.MediaUrls[i]);
        }
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Null(parameters.ScheduledAt);
        Assert.Null(parameters.Subject);
        Assert.Equal(expectedTemplate, parameters.Template);
        Assert.Null(parameters.Text);
        Assert.NotNull(parameters.To);
        Assert.Equal(expectedTo.Count, parameters.To.Count);
        for (int i = 0; i < expectedTo.Count; i++)
        {
            Assert.Equal(expectedTo[i], parameters.To[i]);
        }
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MessageSendParams
        {
            Channel = ["sms", "whatsapp"],
            Channels = new Dictionary<
                string,
                IReadOnlyList<SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest>
            >()
            {
                {
                    "foo",
                    [
                        new()
                        {
                            Country = "country",
                            From = ["string"],
                            Strategy = "strategy",
                        },
                    ]
                },
            },
            MediaUrls = ["string"],
            ScheduledAt = null,
            Subject = null,
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
            Text = null,
        };

        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawBodyData.ContainsKey("to"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MessageSendParams
        {
            Channel = ["sms", "whatsapp"],
            Channels = new Dictionary<
                string,
                IReadOnlyList<SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest>
            >()
            {
                {
                    "foo",
                    [
                        new()
                        {
                            Country = "country",
                            From = ["string"],
                            Strategy = "strategy",
                        },
                    ]
                },
            },
            MediaUrls = ["string"],
            ScheduledAt = null,
            Subject = null,
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
            Text = null,

            // Null should be interpreted as omitted for these properties
            Sandbox = null,
            To = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawBodyData.ContainsKey("to"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MessageSendParams
        {
            Sandbox = false,
            To = ["+14155551234", "+14155555678"],
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Channel);
        Assert.False(parameters.RawBodyData.ContainsKey("channel"));
        Assert.Null(parameters.Channels);
        Assert.False(parameters.RawBodyData.ContainsKey("channels"));
        Assert.Null(parameters.MediaUrls);
        Assert.False(parameters.RawBodyData.ContainsKey("media_urls"));
        Assert.Null(parameters.ScheduledAt);
        Assert.False(parameters.RawBodyData.ContainsKey("scheduled_at"));
        Assert.Null(parameters.Subject);
        Assert.False(parameters.RawBodyData.ContainsKey("subject"));
        Assert.Null(parameters.Template);
        Assert.False(parameters.RawBodyData.ContainsKey("template"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MessageSendParams
        {
            Sandbox = false,
            To = ["+14155551234", "+14155555678"],
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            Channel = null,
            Channels = null,
            MediaUrls = null,
            ScheduledAt = null,
            Subject = null,
            Template = null,
            Text = null,
        };

        Assert.Null(parameters.Channel);
        Assert.True(parameters.RawBodyData.ContainsKey("channel"));
        Assert.Null(parameters.Channels);
        Assert.True(parameters.RawBodyData.ContainsKey("channels"));
        Assert.Null(parameters.MediaUrls);
        Assert.True(parameters.RawBodyData.ContainsKey("media_urls"));
        Assert.Null(parameters.ScheduledAt);
        Assert.True(parameters.RawBodyData.ContainsKey("scheduled_at"));
        Assert.Null(parameters.Subject);
        Assert.True(parameters.RawBodyData.ContainsKey("subject"));
        Assert.Null(parameters.Template);
        Assert.True(parameters.RawBodyData.ContainsKey("template"));
        Assert.Null(parameters.Text);
        Assert.True(parameters.RawBodyData.ContainsKey("text"));
    }

    [Fact]
    public void Url_Works()
    {
        MessageSendParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.sent.dm/v3/messages"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MessageSendParams parameters = new()
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
        var parameters = new MessageSendParams
        {
            Channel = ["sms", "whatsapp"],
            Channels = new Dictionary<
                string,
                IReadOnlyList<SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest>
            >()
            {
                {
                    "foo",
                    [
                        new()
                        {
                            Country = "country",
                            From = ["string"],
                            Strategy = "strategy",
                        },
                    ]
                },
            },
            MediaUrls = ["string"],
            Sandbox = false,
            ScheduledAt = null,
            Subject = null,
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
            Text = null,
            To = ["+14155551234", "+14155555678"],
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        MessageSendParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequestTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest
            {
                Country = "country",
                From = ["string"],
                Strategy = "strategy",
            };

        string expectedCountry = "country";
        List<string> expectedFrom = ["string"];
        string expectedStrategy = "strategy";

        Assert.Equal(expectedCountry, model.Country);
        Assert.NotNull(model.From);
        Assert.Equal(expectedFrom.Count, model.From.Count);
        for (int i = 0; i < expectedFrom.Count; i++)
        {
            Assert.Equal(expectedFrom[i], model.From[i]);
        }
        Assert.Equal(expectedStrategy, model.Strategy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest
            {
                Country = "country",
                From = ["string"],
                Strategy = "strategy",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest
            {
                Country = "country",
                From = ["string"],
                Strategy = "strategy",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCountry = "country";
        List<string> expectedFrom = ["string"];
        string expectedStrategy = "strategy";

        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.NotNull(deserialized.From);
        Assert.Equal(expectedFrom.Count, deserialized.From.Count);
        for (int i = 0; i < expectedFrom.Count; i++)
        {
            Assert.Equal(expectedFrom[i], deserialized.From[i]);
        }
        Assert.Equal(expectedStrategy, deserialized.Strategy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest
            {
                Country = "country",
                From = ["string"],
                Strategy = "strategy",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest
            { };

        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.Strategy);
        Assert.False(model.RawData.ContainsKey("strategy"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest
            { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest
            {
                Country = null,
                From = null,
                Strategy = null,
            };

        Assert.Null(model.Country);
        Assert.True(model.RawData.ContainsKey("country"));
        Assert.Null(model.From);
        Assert.True(model.RawData.ContainsKey("from"));
        Assert.Null(model.Strategy);
        Assert.True(model.RawData.ContainsKey("strategy"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest
            {
                Country = null,
                From = null,
                Strategy = null,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest
            {
                Country = "country",
                From = ["string"],
                Strategy = "strategy",
            };

        SentDmServicesEndpointsCustomerApIv3MessagesRequestsMessageChannelOptionsRequest copied =
            new(model);

        Assert.Equal(model, copied);
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
