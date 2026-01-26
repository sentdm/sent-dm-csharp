using System;
using System.Collections.Generic;
using System.Net.Http;
using SentDm.Models.Messages;

namespace SentDm.Tests.Models.Messages;

public class MessageSendToContactParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageSendToContactParams
        {
            ContactID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            TemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
            TemplateVariables = new Dictionary<string, string>()
            {
                { "name", "John Doe" },
                { "order_id", "12345" },
            },
        };

        string expectedContactID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8";
        string expectedTemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8";
        string expectedXApiKey = "";
        string expectedXSenderID = "00000000-0000-0000-0000-000000000000";
        Dictionary<string, string> expectedTemplateVariables = new()
        {
            { "name", "John Doe" },
            { "order_id", "12345" },
        };

        Assert.Equal(expectedContactID, parameters.ContactID);
        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedXApiKey, parameters.XApiKey);
        Assert.Equal(expectedXSenderID, parameters.XSenderID);
        Assert.NotNull(parameters.TemplateVariables);
        Assert.Equal(expectedTemplateVariables.Count, parameters.TemplateVariables.Count);
        foreach (var item in expectedTemplateVariables)
        {
            Assert.True(parameters.TemplateVariables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.TemplateVariables[item.Key]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MessageSendToContactParams
        {
            ContactID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            TemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        Assert.Null(parameters.TemplateVariables);
        Assert.False(parameters.RawBodyData.ContainsKey("templateVariables"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MessageSendToContactParams
        {
            ContactID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            TemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",

            TemplateVariables = null,
        };

        Assert.Null(parameters.TemplateVariables);
        Assert.True(parameters.RawBodyData.ContainsKey("templateVariables"));
    }

    [Fact]
    public void Url_Works()
    {
        MessageSendToContactParams parameters = new()
        {
            ContactID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            TemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(new Uri("https://api.sent.dm/v2/messages/contact"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MessageSendToContactParams parameters = new()
        {
            ContactID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            TemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        parameters.AddHeadersToRequest(
            requestMessage,
            new() { ApiKey = "My API Key", SenderID = "My Sender ID" }
        );

        Assert.Equal([""], requestMessage.Headers.GetValues("x-api-key"));
        Assert.Equal(
            ["00000000-0000-0000-0000-000000000000"],
            requestMessage.Headers.GetValues("x-sender-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MessageSendToContactParams
        {
            ContactID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            TemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
            TemplateVariables = new Dictionary<string, string>()
            {
                { "name", "John Doe" },
                { "order_id", "12345" },
            },
        };

        MessageSendToContactParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
