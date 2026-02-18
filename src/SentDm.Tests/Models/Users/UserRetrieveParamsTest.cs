using System;
using SentDm.Models.Users;

namespace SentDm.Tests.Models.Users;

public class UserRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRetrieveParams { UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        string expectedUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        UserRetrieveParams parameters = new() { UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/users/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserRetrieveParams { UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        UserRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
