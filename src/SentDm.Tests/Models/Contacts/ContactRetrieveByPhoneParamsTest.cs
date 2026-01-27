using System;
using SentDm.Models.Contacts;

namespace SentDm.Tests.Models.Contacts;

public class ContactRetrieveByPhoneParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactRetrieveByPhoneParams { PhoneNumber = "phoneNumber" };

        string expectedPhoneNumber = "phoneNumber";

        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
    }

    [Fact]
    public void Url_Works()
    {
        ContactRetrieveByPhoneParams parameters = new() { PhoneNumber = "phoneNumber" };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(new Uri("https://api.sent.dm/v2/contacts/phone?phoneNumber=phoneNumber"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactRetrieveByPhoneParams { PhoneNumber = "phoneNumber" };

        ContactRetrieveByPhoneParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
