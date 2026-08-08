using System;
using System.Net.Http;
using Sentdm.Models.Conversations;

namespace Sentdm.Tests.Models.Conversations;

public class ConversationListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ConversationListParams
        {
            Page = 0,
            PageSize = 0,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        int expectedPage = 0;
        int expectedPageSize = 0;
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ConversationListParams { Page = 0, PageSize = 0 };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ConversationListParams
        {
            Page = 0,
            PageSize = 0,

            // Null should be interpreted as omitted for these properties
            XProfileID = null,
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void Url_Works()
    {
        ConversationListParams parameters = new() { Page = 0, PageSize = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.sent.dm/v3/conversations?page=0&page_size=0"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ConversationListParams parameters = new()
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
        var parameters = new ConversationListParams
        {
            Page = 0,
            PageSize = 0,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ConversationListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
