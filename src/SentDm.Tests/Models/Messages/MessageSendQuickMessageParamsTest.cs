using System;
using System.Net.Http;
using SentDm.Models.Messages;

namespace SentDm.Tests.Models.Messages;

public class MessageSendQuickMessageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageSendQuickMessageParams
        {
            CustomMessage = "Hello, this is a test message!",
            PhoneNumber = "+1234567890",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        string expectedCustomMessage = "Hello, this is a test message!";
        string expectedPhoneNumber = "+1234567890";
        string expectedXApiKey = "";
        string expectedXSenderID = "00000000-0000-0000-0000-000000000000";

        Assert.Equal(expectedCustomMessage, parameters.CustomMessage);
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
        Assert.Equal(expectedXApiKey, parameters.XApiKey);
        Assert.Equal(expectedXSenderID, parameters.XSenderID);
    }

    [Fact]
    public void Url_Works()
    {
        MessageSendQuickMessageParams parameters = new()
        {
            CustomMessage = "Hello, this is a test message!",
            PhoneNumber = "+1234567890",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(new Uri("https://api.sent.dm/v2/messages/quick-message"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MessageSendQuickMessageParams parameters = new()
        {
            CustomMessage = "Hello, this is a test message!",
            PhoneNumber = "+1234567890",
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
        var parameters = new MessageSendQuickMessageParams
        {
            CustomMessage = "Hello, this is a test message!",
            PhoneNumber = "+1234567890",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        MessageSendQuickMessageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
