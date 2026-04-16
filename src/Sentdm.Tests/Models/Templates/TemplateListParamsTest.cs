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
            Page = 0,
            PageSize = 0,
            Category = "category",
            IsWelcomePlayground = true,
            Search = "search",
            Status = "status",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        int expectedPage = 0;
        int expectedPageSize = 0;
        string expectedCategory = "category";
        bool expectedIsWelcomePlayground = true;
        string expectedSearch = "search";
        string expectedStatus = "status";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedIsWelcomePlayground, parameters.IsWelcomePlayground);
        Assert.Equal(expectedSearch, parameters.Search);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateListParams
        {
            Page = 0,
            PageSize = 0,
            Category = "category",
            IsWelcomePlayground = true,
            Search = "search",
            Status = "status",
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplateListParams
        {
            Page = 0,
            PageSize = 0,
            Category = "category",
            IsWelcomePlayground = true,
            Search = "search",
            Status = "status",

            // Null should be interpreted as omitted for these properties
            XProfileID = null,
        };

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
            Page = 0,
            PageSize = 0,
            Category = "category",
            IsWelcomePlayground = true,
            Search = "search",
            Status = "status",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/templates?page=0&page_size=0&category=category&is_welcome_playground=true&search=search&status=status"
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
            Page = 0,
            PageSize = 0,
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
            Page = 0,
            PageSize = 0,
            Category = "category",
            IsWelcomePlayground = true,
            Search = "search",
            Status = "status",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        TemplateListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
