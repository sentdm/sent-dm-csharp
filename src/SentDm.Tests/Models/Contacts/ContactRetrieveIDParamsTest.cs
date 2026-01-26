using System;
using System.Net.Http;
using SentDm.Models.Contacts;

namespace SentDm.Tests.Models.Contacts;

public class ContactRetrieveIDParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactRetrieveIDParams
        {
            ID = "id",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        string expectedID = "id";
        string expectedXApiKey = "";
        string expectedXSenderID = "00000000-0000-0000-0000-000000000000";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedXApiKey, parameters.XApiKey);
        Assert.Equal(expectedXSenderID, parameters.XSenderID);
    }

    [Fact]
    public void Url_Works()
    {
        ContactRetrieveIDParams parameters = new()
        {
            ID = "id",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(new Uri("https://api.sent.dm/v2/contacts/id?id=id"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ContactRetrieveIDParams parameters = new()
        {
            ID = "id",
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
        var parameters = new ContactRetrieveIDParams
        {
            ID = "id",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        ContactRetrieveIDParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
