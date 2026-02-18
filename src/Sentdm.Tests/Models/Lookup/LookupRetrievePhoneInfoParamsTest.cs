using System;
using Sentdm.Models.Lookup;

namespace Sentdm.Tests.Models.Lookup;

public class LookupRetrievePhoneInfoParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LookupRetrievePhoneInfoParams { PhoneNumber = "phoneNumber" };

        string expectedPhoneNumber = "phoneNumber";

        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
    }

    [Fact]
    public void Url_Works()
    {
        LookupRetrievePhoneInfoParams parameters = new() { PhoneNumber = "phoneNumber" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.sent.dm/v3/lookup/number/phoneNumber"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LookupRetrievePhoneInfoParams { PhoneNumber = "phoneNumber" };

        LookupRetrievePhoneInfoParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
