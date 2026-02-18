using System;
using SentDm.Models.Contacts;

namespace SentDm.Tests.Models.Contacts;

public class ContactRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactRetrieveParams { ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8" };

        string expectedID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ContactRetrieveParams parameters = new() { ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/contacts/6ba7b810-9dad-11d1-80b4-00c04fd430c8"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactRetrieveParams { ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8" };

        ContactRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
