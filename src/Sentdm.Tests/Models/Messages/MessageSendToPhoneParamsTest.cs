using System;
using System.Collections.Generic;
using Sentdm.Models.Messages;

namespace Sentdm.Tests.Models.Messages;

public class MessageSendToPhoneParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageSendToPhoneParams
        {
            PhoneNumber = "+1234567890",
            TemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            TemplateVariables = new Dictionary<string, string>()
            {
                { "name", "John Doe" },
                { "order_id", "12345" },
            },
        };

        string expectedPhoneNumber = "+1234567890";
        string expectedTemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8";
        Dictionary<string, string> expectedTemplateVariables = new()
        {
            { "name", "John Doe" },
            { "order_id", "12345" },
        };

        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
        Assert.Equal(expectedTemplateID, parameters.TemplateID);
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
        var parameters = new MessageSendToPhoneParams
        {
            PhoneNumber = "+1234567890",
            TemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
        };

        Assert.Null(parameters.TemplateVariables);
        Assert.False(parameters.RawBodyData.ContainsKey("templateVariables"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MessageSendToPhoneParams
        {
            PhoneNumber = "+1234567890",
            TemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",

            TemplateVariables = null,
        };

        Assert.Null(parameters.TemplateVariables);
        Assert.True(parameters.RawBodyData.ContainsKey("templateVariables"));
    }

    [Fact]
    public void Url_Works()
    {
        MessageSendToPhoneParams parameters = new()
        {
            PhoneNumber = "+1234567890",
            TemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(new Uri("https://api.sent.dm/v2/messages/phone"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MessageSendToPhoneParams
        {
            PhoneNumber = "+1234567890",
            TemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            TemplateVariables = new Dictionary<string, string>()
            {
                { "name", "John Doe" },
                { "order_id", "12345" },
            },
        };

        MessageSendToPhoneParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
