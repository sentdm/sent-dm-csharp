using System;
using Sentdm.Models.SenderProfiles;

namespace Sentdm.Tests.Models.SenderProfiles;

public class SenderProfileListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SenderProfileListParams { Page = 0, PageSize = 0 };

        int expectedPage = 0;
        int expectedPageSize = 0;

        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SenderProfileListParams { };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SenderProfileListParams
        {
            // Null should be interpreted as omitted for these properties
            Page = null,
            PageSize = null,
        };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void Url_Works()
    {
        SenderProfileListParams parameters = new() { Page = 0, PageSize = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.sent.dm/v3/sender-profiles?page=0&page_size=0"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SenderProfileListParams { Page = 0, PageSize = 0 };

        SenderProfileListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
