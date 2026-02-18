using System;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class ProfileDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileDeleteParams
        {
            ProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProfileIDValue = "770e8400-e29b-41d4-a716-446655440002",
            TestMode = false,
        };

        string expectedProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProfileIDValue = "770e8400-e29b-41d4-a716-446655440002";
        bool expectedTestMode = false;

        Assert.Equal(expectedProfileID, parameters.ProfileID);
        Assert.Equal(expectedProfileIDValue, parameters.ProfileIDValue);
        Assert.Equal(expectedTestMode, parameters.TestMode);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProfileDeleteParams
        {
            ProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.ProfileIDValue);
        Assert.False(parameters.RawBodyData.ContainsKey("profile_id"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProfileDeleteParams
        {
            ProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            ProfileIDValue = null,
            TestMode = null,
        };

        Assert.Null(parameters.ProfileIDValue);
        Assert.False(parameters.RawBodyData.ContainsKey("profile_id"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
    }

    [Fact]
    public void Url_Works()
    {
        ProfileDeleteParams parameters = new()
        {
            ProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/profiles/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProfileDeleteParams
        {
            ProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProfileIDValue = "770e8400-e29b-41d4-a716-446655440002",
            TestMode = false,
        };

        ProfileDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
