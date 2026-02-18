using System;
using SentDm.Models.Webhooks;

namespace SentDm.Tests.Models.Webhooks;

public class WebhookListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookListParams
        {
            Page = 0,
            PageSize = 0,
            IsActive = true,
            Search = "search",
        };

        int expectedPage = 0;
        int expectedPageSize = 0;
        bool expectedIsActive = true;
        string expectedSearch = "search";

        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedIsActive, parameters.IsActive);
        Assert.Equal(expectedSearch, parameters.Search);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookListParams { Page = 0, PageSize = 0 };

        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawQueryData.ContainsKey("isActive"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WebhookListParams
        {
            Page = 0,
            PageSize = 0,

            IsActive = null,
            Search = null,
        };

        Assert.Null(parameters.IsActive);
        Assert.True(parameters.RawQueryData.ContainsKey("isActive"));
        Assert.Null(parameters.Search);
        Assert.True(parameters.RawQueryData.ContainsKey("search"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookListParams parameters = new()
        {
            Page = 0,
            PageSize = 0,
            IsActive = true,
            Search = "search",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.sent.dm/v3/webhooks?page=0&pageSize=0&isActive=true&search=search"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookListParams
        {
            Page = 0,
            PageSize = 0,
            IsActive = true,
            Search = "search",
        };

        WebhookListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
