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
            UserID = "aa0e8400-e29b-41d4-a716-446655440005",
            Role = "billing",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedUserID = "aa0e8400-e29b-41d4-a716-446655440005";
        string expectedRole = "billing";
        bool expectedSandbox = false;
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedRole, parameters.Role);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserUpdateRoleParams
        {
            UserID = "aa0e8400-e29b-41d4-a716-446655440005",
        };

        Assert.Null(parameters.Role);
        Assert.False(parameters.RawBodyData.ContainsKey("role"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserUpdateRoleParams
        {
            UserID = "aa0e8400-e29b-41d4-a716-446655440005",

            // Null should be interpreted as omitted for these properties
            Role = null,
            Sandbox = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.Role);
        Assert.False(parameters.RawBodyData.ContainsKey("role"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void Url_Works()
    {
        UserUpdateRoleParams parameters = new() { UserID = "aa0e8400-e29b-41d4-a716-446655440005" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.sent.dm/v3/users/aa0e8400-e29b-41d4-a716-446655440005"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        UserUpdateRoleParams parameters = new()
        {
            UserID = "aa0e8400-e29b-41d4-a716-446655440005",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
        Assert.Equal(
            ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            requestMessage.Headers.GetValues("x-profile-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserUpdateRoleParams
        {
            UserID = "aa0e8400-e29b-41d4-a716-446655440005",
            Role = "billing",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        UserUpdateRoleParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
