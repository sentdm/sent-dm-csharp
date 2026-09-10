using System;
using System.Net.Http;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateListParams
        {
            Category = "category",
            IsWelcomePlayground = true,
            Page = 0,
            PageSize = 0,
            Search = "search",
            Status = "status",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedCategory = "category";
        bool expectedIsWelcomePlayground = true;
        int expectedPage = 0;
        int expectedPageSize = 0;
        string expectedSearch = "search";
        string expectedStatus = "status";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedIsWelcomePlayground, parameters.IsWelcomePlayground);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedSearch, parameters.Search);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateListParams
        {
            Category = "category",
            IsWelcomePlayground = true,
            Search = "search",
            Status = "status",
        };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplateListParams
        {
            Category = "category",
            IsWelcomePlayground = true,
            Search = "search",
            Status = "status",

            // Null should be interpreted as omitted for these properties
            Page = null,
            PageSize = null,
            XProfileID = null,
        };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateListParams
        {
            Page = 0,
            PageSize = 0,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.IsWelcomePlayground);
        Assert.False(parameters.RawQueryData.ContainsKey("is_welcome_playground"));
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
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            Category = null,
            IsWelcomePlayground = null,
            Search = null,
            Status = null,
        };

        Assert.Null(parameters.Category);
        Assert.True(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.IsWelcomePlayground);
        Assert.True(parameters.RawQueryData.ContainsKey("is_welcome_playground"));
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
            Category = "category",
            IsWelcomePlayground = true,
            Page = 0,
            PageSize = 0,
            Search = "search",
            Status = "status",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/templates?category=category&is_welcome_playground=true&page=0&page_size=0&search=search&status=status"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TemplateListParams parameters = new()
        {
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(
            ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            requestMessage.Headers.GetValues("x-profile-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateListParams
        {
            Category = "category",
            IsWelcomePlayground = true,
            Page = 0,
            PageSize = 0,
            Search = "search",
            Status = "status",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        TemplateListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
