using System;
using System.Net.Http;
using SentDm.Models.Organizations;

namespace SentDm.Tests.Models.Organizations;

public class OrganizationRetrieveProfilesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OrganizationRetrieveProfilesParams
        {
            OrgID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        string expectedOrgID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8";
        string expectedXApiKey = "";
        string expectedXSenderID = "00000000-0000-0000-0000-000000000000";

        Assert.Equal(expectedOrgID, parameters.OrgID);
        Assert.Equal(expectedXApiKey, parameters.XApiKey);
        Assert.Equal(expectedXSenderID, parameters.XSenderID);
    }

    [Fact]
    public void Url_Works()
    {
        OrganizationRetrieveProfilesParams parameters = new()
        {
            OrgID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(
            new Uri(
                "https://api.sent.dm/v2/organizations/6ba7b810-9dad-11d1-80b4-00c04fd430c8/profiles"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        OrganizationRetrieveProfilesParams parameters = new()
        {
            OrgID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
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
        var parameters = new OrganizationRetrieveProfilesParams
        {
            OrgID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            XApiKey = "",
            XSenderID = "00000000-0000-0000-0000-000000000000",
        };

        OrganizationRetrieveProfilesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
