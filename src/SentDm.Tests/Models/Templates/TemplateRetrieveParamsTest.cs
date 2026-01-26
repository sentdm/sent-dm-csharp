using System;
using System.Net.Http;
using SentDm.Models.Templates;

namespace SentDm.Tests.Models.Templates;

public class TemplateRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateRetrieveParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        string expectedID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8";
        string expectedXApiKey = "";
        string expectedXSenderID = "00000000-0000-0000-0000-000000000000";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedXApiKey, parameters.XApiKey);
        Assert.Equal(expectedXSenderID, parameters.XSenderID);
    }

    [Fact]
    public void Url_Works()
    {
        TemplateRetrieveParams parameters = new()
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v2/templates/7ba7b820-9dad-11d1-80b4-00c04fd430c8"),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TemplateRetrieveParams parameters = new()
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
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
        var parameters = new TemplateRetrieveParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        TemplateRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
