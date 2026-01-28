using System;
using Sentdm.Models.Organizations.Users;

namespace Sentdm.Tests.Models.Organizations.Users;

public class UserInviteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserInviteParams
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            Email = "user@example.com",
            InvitedBy = "650e8400-e29b-41d4-a716-446655440000",
            Name = "John Doe",
            Role = "admin",
        };

        string expectedCustomerID = "550e8400-e29b-41d4-a716-446655440000";
        string expectedEmail = "user@example.com";
        string expectedInvitedBy = "650e8400-e29b-41d4-a716-446655440000";
        string expectedName = "John Doe";
        string expectedRole = "admin";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedInvitedBy, parameters.InvitedBy);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedRole, parameters.Role);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserInviteParams
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            InvitedBy = "650e8400-e29b-41d4-a716-446655440000",
        };

        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Role);
        Assert.False(parameters.RawBodyData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserInviteParams
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            InvitedBy = "650e8400-e29b-41d4-a716-446655440000",

            // Null should be interpreted as omitted for these properties
            Email = null,
            Name = null,
            Role = null,
        };

        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Role);
        Assert.False(parameters.RawBodyData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserInviteParams
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            Email = "user@example.com",
            Name = "John Doe",
            Role = "admin",
        };

        Assert.Null(parameters.InvitedBy);
        Assert.False(parameters.RawBodyData.ContainsKey("invitedBy"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new UserInviteParams
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            Email = "user@example.com",
            Name = "John Doe",
            Role = "admin",

            InvitedBy = null,
        };

        Assert.Null(parameters.InvitedBy);
        Assert.True(parameters.RawBodyData.ContainsKey("invitedBy"));
    }

    [Fact]
    public void Url_Works()
    {
        UserInviteParams parameters = new() { CustomerID = "550e8400-e29b-41d4-a716-446655440000" };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(
            new Uri(
                "https://api.sent.dm/v2/organizations/550e8400-e29b-41d4-a716-446655440000/users"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserInviteParams
        {
            CustomerID = "550e8400-e29b-41d4-a716-446655440000",
            Email = "user@example.com",
            InvitedBy = "650e8400-e29b-41d4-a716-446655440000",
            Name = "John Doe",
            Role = "admin",
        };

        UserInviteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
