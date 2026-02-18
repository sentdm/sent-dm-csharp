using System;
using System.Net.Http;
using Sentdm.Models.Users;

namespace Sentdm.Tests.Models.Users;

public class UserInviteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserInviteParams
        {
            Email = "newuser@example.com",
            Name = "New User",
            Role = "developer",
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        string expectedEmail = "newuser@example.com";
        string expectedName = "New User";
        string expectedRole = "developer";
        bool expectedTestMode = false;
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedRole, parameters.Role);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserInviteParams { };

        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Role);
        Assert.False(parameters.RawBodyData.ContainsKey("role"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserInviteParams
        {
            // Null should be interpreted as omitted for these properties
            Email = null,
            Name = null,
            Role = null,
            TestMode = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Role);
        Assert.False(parameters.RawBodyData.ContainsKey("role"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void Url_Works()
    {
        UserInviteParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.sent.dm/v3/users"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        UserInviteParams parameters = new() { IdempotencyKey = "req_abc123_retry1" };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserInviteParams
        {
            Email = "newuser@example.com",
            Name = "New User",
            Role = "developer",
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        UserInviteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
