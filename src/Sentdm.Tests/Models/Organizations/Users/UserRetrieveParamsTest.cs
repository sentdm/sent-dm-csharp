using System;
using Sentdm.Models.Organizations.Users;

namespace Sentdm.Tests.Models.Organizations.Users;

public class UserRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRetrieveParams
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            UserID = "650e8400-e29b-41d4-a716-446655440000",
        };

        string expectedCustomerID = "550e8400-e29b-41d4-a716-446655440000";
        string expectedUserID = "650e8400-e29b-41d4-a716-446655440000";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        UserRetrieveParams parameters = new()
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            UserID = "650e8400-e29b-41d4-a716-446655440000",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(
            new Uri(
                "https://api.sent.dm/v2/organizations/550e8400-e29b-41d4-a716-446655440000/users/650e8400-e29b-41d4-a716-446655440000"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserRetrieveParams
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            UserID = "650e8400-e29b-41d4-a716-446655440000",
        };

        UserRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
