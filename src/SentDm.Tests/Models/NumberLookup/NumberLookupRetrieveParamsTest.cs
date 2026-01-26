using System;
using SentDm.Models.NumberLookup;

namespace SentDm.Tests.Models.NumberLookup;

public class NumberLookupRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NumberLookupRetrieveParams { PhoneNumber = "phoneNumber" };

        string expectedPhoneNumber = "phoneNumber";

        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
    }

    [Fact]
    public void Url_Works()
    {
        NumberLookupRetrieveParams parameters = new() { PhoneNumber = "phoneNumber" };

        var url = parameters.Url(
            new()
            {
                AdminAuthScheme = "My Admin Auth Scheme",
                CustomerAuthScheme = "My Customer Auth Scheme",
            }
        );

        Assert.Equal(new Uri("https://api.sent.dm/v2/number-lookup?phoneNumber=phoneNumber"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NumberLookupRetrieveParams { PhoneNumber = "phoneNumber" };

        NumberLookupRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
