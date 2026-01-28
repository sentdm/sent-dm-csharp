using System;
using SentDm.Models.Contacts;

namespace SentDm.Tests.Models.Contacts;

public class ContactRetrieveIDParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactRetrieveIDParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ContactRetrieveIDParams parameters = new() { ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v2/contacts/id?id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactRetrieveIDParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ContactRetrieveIDParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
