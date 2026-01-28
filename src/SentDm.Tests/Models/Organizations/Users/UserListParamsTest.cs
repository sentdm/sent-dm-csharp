using System;
using SentDm.Models.Organizations.Users;

namespace SentDm.Tests.Models.Organizations.Users;

public class UserListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserListParams
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            Page = 0,
            PageSize = 0,
        };

        string expectedCustomerID = "550e8400-e29b-41d4-a716-446655440000";
        int expectedPage = 0;
        int expectedPageSize = 0;

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void Url_Works()
    {
        UserListParams parameters = new()
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            Page = 0,
            PageSize = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(
            new Uri(
                "https://api.sent.dm/v2/organizations/550e8400-e29b-41d4-a716-446655440000/users?page=0&pageSize=0"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserListParams
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            Page = 0,
            PageSize = 0,
        };

        UserListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
