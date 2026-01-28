using System;
using SentDm.Models.Organizations.Users;

namespace SentDm.Tests.Models.Organizations.Users;

public class UserUpdateRoleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserUpdateRoleParams
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            UserID = "650e8400-e29b-41d4-a716-446655440000",
            Role = "admin",
        };

        string expectedCustomerID = "550e8400-e29b-41d4-a716-446655440000";
        string expectedUserID = "650e8400-e29b-41d4-a716-446655440000";
        string expectedRole = "admin";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedRole, parameters.Role);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserUpdateRoleParams
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            UserID = "650e8400-e29b-41d4-a716-446655440000",
        };

        Assert.Null(parameters.Role);
        Assert.False(parameters.RawBodyData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserUpdateRoleParams
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            UserID = "650e8400-e29b-41d4-a716-446655440000",

            // Null should be interpreted as omitted for these properties
            Role = null,
        };

        Assert.Null(parameters.Role);
        Assert.False(parameters.RawBodyData.ContainsKey("role"));
    }

    [Fact]
    public void Url_Works()
    {
        UserUpdateRoleParams parameters = new()
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
        var parameters = new UserUpdateRoleParams
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            UserID = "650e8400-e29b-41d4-a716-446655440000",
            Role = "admin",
        };

        UserUpdateRoleParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
