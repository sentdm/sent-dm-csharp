using System;
using SentDm.Models.Contacts;

namespace SentDm.Tests.Models.Contacts;

public class ContactListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactListParams { Page = 0, PageSize = 0 };

        int expectedPage = 0;
        int expectedPageSize = 0;

        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void Url_Works()
    {
        ContactListParams parameters = new() { Page = 0, PageSize = 0 };

        var url = parameters.Url(
            new()
            {
                AdminAuthScheme = "My Admin Auth Scheme",
                CustomerAuthScheme = "My Customer Auth Scheme",
            }
        );

        Assert.Equal(new Uri("https://api.sent.dm/v2/contacts?page=0&pageSize=0"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactListParams { Page = 0, PageSize = 0 };

        ContactListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
