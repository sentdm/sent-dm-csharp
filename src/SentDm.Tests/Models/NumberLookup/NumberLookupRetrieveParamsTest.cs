using System;
using System.Net.Http;
using SentDm.Models.NumberLookup;

namespace SentDm.Tests.Models.NumberLookup;

public class NumberLookupRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NumberLookupRetrieveParams
        {
            PhoneNumber = "phoneNumber",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        string expectedPhoneNumber = "phoneNumber";
        string expectedXApiKey = "";
        string expectedXSenderID = "00000000-0000-0000-0000-000000000000";

        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
        Assert.Equal(expectedXApiKey, parameters.XApiKey);
        Assert.Equal(expectedXSenderID, parameters.XSenderID);
    }

    [Fact]
    public void Url_Works()
    {
        NumberLookupRetrieveParams parameters = new()
        {
            PhoneNumber = "phoneNumber",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(new Uri("https://api.sent.dm/v2/number-lookup?phoneNumber=phoneNumber"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        NumberLookupRetrieveParams parameters = new()
        {
            PhoneNumber = "phoneNumber",
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
        var parameters = new NumberLookupRetrieveParams
        {
            PhoneNumber = "phoneNumber",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        NumberLookupRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
