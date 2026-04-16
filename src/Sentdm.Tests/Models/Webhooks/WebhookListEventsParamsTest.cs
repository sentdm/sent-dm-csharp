using System;
using System.Net.Http;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookListEventsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookListEventsParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            Page = 0,
            PageSize = 0,
            Search = "search",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8";
        int expectedPage = 0;
        int expectedPageSize = 0;
        string expectedSearch = "search";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedSearch, parameters.Search);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookListEventsParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            Page = 0,
            PageSize = 0,
            Search = "search",
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookListEventsParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            Page = 0,
            PageSize = 0,
            Search = "search",

            // Null should be interpreted as omitted for these properties
            XProfileID = null,
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookListEventsParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            Page = 0,
            PageSize = 0,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WebhookListEventsParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            Page = 0,
            PageSize = 0,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            Search = null,
        };

        Assert.Null(parameters.Search);
        Assert.True(parameters.RawQueryData.ContainsKey("search"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookListEventsParams parameters = new()
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            Page = 0,
            PageSize = 0,
            Search = "search",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/webhooks/d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8/events?page=0&page_size=0&search=search"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WebhookListEventsParams parameters = new()
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
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
        var parameters = new WebhookListEventsParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            Page = 0,
            PageSize = 0,
            Search = "search",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        WebhookListEventsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
