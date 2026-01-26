using System;
using System.Net.Http;
using SentDm.Models.Contacts;

namespace SentDm.Tests.Models.Contacts;

public class ContactListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactListParams
        {
            Page = 0,
            PageSize = 0,
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        int expectedPage = 0;
        int expectedPageSize = 0;
        string expectedXApiKey = "";
        string expectedXSenderID = "00000000-0000-0000-0000-000000000000";

        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedXApiKey, parameters.XApiKey);
        Assert.Equal(expectedXSenderID, parameters.XSenderID);
    }

    [Fact]
    public void Url_Works()
    {
        ContactListParams parameters = new()
        {
            Page = 0,
            PageSize = 0,
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(new Uri("https://api.sent.dm/v2/contacts?page=0&pageSize=0"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ContactListParams parameters = new()
        {
            Page = 0,
            PageSize = 0,
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
        var parameters = new ContactListParams
        {
            Page = 0,
            PageSize = 0,
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        ContactListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
