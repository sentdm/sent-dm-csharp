using System;
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
        };

        string expectedCustomMessage = "Hello, this is a test message!";
        string expectedPhoneNumber = "+1234567890";

        Assert.Equal(expectedCustomMessage, parameters.CustomMessage);
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
    }

    [Fact]
    public void Url_Works()
    {
        MessageSendQuickMessageParams parameters = new()
        {
            CustomMessage = "Hello, this is a test message!",
            PhoneNumber = "+1234567890",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(new Uri("https://api.sent.dm/v2/messages/quick-message"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MessageSendQuickMessageParams
        {
            CustomMessage = "Hello, this is a test message!",
            PhoneNumber = "+1234567890",
        };

        MessageSendQuickMessageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
