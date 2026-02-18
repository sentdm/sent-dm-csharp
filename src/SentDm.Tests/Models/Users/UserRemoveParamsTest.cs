using System;
using SentDm.Models.Users;

namespace SentDm.Tests.Models.Users;

public class UserRemoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRemoveParams
        {
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TestMode = false,
            UserIDValue = "aa0e8400-e29b-41d4-a716-446655440005",
        };

        string expectedUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedTestMode = false;
        string expectedUserIDValue = "aa0e8400-e29b-41d4-a716-446655440005";

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.Equal(expectedUserIDValue, parameters.UserIDValue);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserRemoveParams { UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.UserIDValue);
        Assert.False(parameters.RawBodyData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserRemoveParams
        {
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            TestMode = null,
            UserIDValue = null,
        };

        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.UserIDValue);
        Assert.False(parameters.RawBodyData.ContainsKey("user_id"));
    }

    [Fact]
    public void Url_Works()
    {
        UserRemoveParams parameters = new() { UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/users/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserRemoveParams
        {
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TestMode = false,
            UserIDValue = "aa0e8400-e29b-41d4-a716-446655440005",
        };

        UserRemoveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
