using System;
using System.Collections.Generic;
using System.Net.Http;
using Sentdm.Models.Messages;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Messages;

public class MessageSendParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageSendParams
        {
            Channel = ["sms", "whatsapp"],
            Channels = new Dictionary<string, IReadOnlyList<MessageChannelOptions>>()
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
        Dictionary<string, List<MessageChannelOptions>> expectedChannels = new()
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
        TemplateRef expectedTemplate = new()
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
            Channels = new Dictionary<string, IReadOnlyList<MessageChannelOptions>>()
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
            Channels = new Dictionary<string, IReadOnlyList<MessageChannelOptions>>()
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
            Channels = new Dictionary<string, IReadOnlyList<MessageChannelOptions>>()
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
