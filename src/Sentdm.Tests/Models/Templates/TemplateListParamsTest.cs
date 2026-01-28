using System;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateListParams
        {
            Page = 0,
            PageSize = 0,
            Category = "category",
            Search = "search",
            Status = "status",
        };

        int expectedPage = 0;
        int expectedPageSize = 0;
        string expectedCategory = "category";
        string expectedSearch = "search";
        string expectedStatus = "status";

        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedSearch, parameters.Search);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateListParams { Page = 0, PageSize = 0 };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TemplateListParams
        {
            Page = 0,
            PageSize = 0,

            Category = null,
            Search = null,
            Status = null,
        };

        Assert.Null(parameters.Category);
        Assert.True(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.Search);
        Assert.True(parameters.RawQueryData.ContainsKey("search"));
        Assert.Null(parameters.Status);
        Assert.True(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplateListParams parameters = new()
        {
            Page = 0,
            PageSize = 0,
            Category = "category",
            Search = "search",
            Status = "status",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(
            new Uri(
                "https://api.sent.dm/v2/templates?page=0&pageSize=0&category=category&search=search&status=status"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateListParams
        {
            Page = 0,
            PageSize = 0,
            Category = "category",
            Search = "search",
            Status = "status",
        };

        TemplateListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
