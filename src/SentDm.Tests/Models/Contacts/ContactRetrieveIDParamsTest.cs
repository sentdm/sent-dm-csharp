using System;
using SentDm.Models.Contacts;

namespace SentDm.Tests.Models.Contacts;

public class ContactRetrieveIDParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactRetrieveIDParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ContactRetrieveIDParams parameters = new() { ID = "id" };

        var url = parameters.Url(
            new()
            {
                AdminAuthScheme = "My Admin Auth Scheme",
                CustomerAuthScheme = "My Customer Auth Scheme",
            }
        );

        Assert.Equal(new Uri("https://api.sent.dm/v2/contacts/id?id=id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactRetrieveIDParams { ID = "id" };

        ContactRetrieveIDParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
