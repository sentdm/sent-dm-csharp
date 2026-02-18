using System;
using System.Net.Http;
using Sentdm.Models.Users;

namespace Sentdm.Tests.Models.Users;

public class UserUpdateRoleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserUpdateRoleParams
        {
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Role = "billing",
            TestMode = false,
            UserIDValue = "aa0e8400-e29b-41d4-a716-446655440005",
            IdempotencyKey = "req_abc123_retry1",
        };

        string expectedUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedRole = "billing";
        bool expectedTestMode = false;
        string expectedUserIDValue = "aa0e8400-e29b-41d4-a716-446655440005";
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedRole, parameters.Role);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.Equal(expectedUserIDValue, parameters.UserIDValue);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserUpdateRoleParams
        {
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Role);
        Assert.False(parameters.RawBodyData.ContainsKey("role"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.UserIDValue);
        Assert.False(parameters.RawBodyData.ContainsKey("user_id"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserUpdateRoleParams
        {
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            Role = null,
            TestMode = null,
            UserIDValue = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.Role);
        Assert.False(parameters.RawBodyData.ContainsKey("role"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.UserIDValue);
        Assert.False(parameters.RawBodyData.ContainsKey("user_id"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void Url_Works()
    {
        UserUpdateRoleParams parameters = new() { UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/users/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        UserUpdateRoleParams parameters = new()
        {
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            IdempotencyKey = "req_abc123_retry1",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserUpdateRoleParams
        {
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Role = "billing",
            TestMode = false,
            UserIDValue = "aa0e8400-e29b-41d4-a716-446655440005",
            IdempotencyKey = "req_abc123_retry1",
        };

        UserUpdateRoleParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
