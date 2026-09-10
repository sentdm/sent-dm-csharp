using System;
using System.Net.Http;
using Sentdm.Models.Contacts;

namespace Sentdm.Tests.Models.Contacts;

public class ContactListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactListParams
        {
            Channel = "channel",
            Page = 0,
            PageSize = 0,
            Phone = "phone",
            Search = "search",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedChannel = "channel";
        int expectedPage = 0;
        int expectedPageSize = 0;
        string expectedPhone = "phone";
        string expectedSearch = "search";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedChannel, parameters.Channel);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedPhone, parameters.Phone);
        Assert.Equal(expectedSearch, parameters.Search);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ContactListParams
        {
            Channel = "channel",
            Phone = "phone",
            Search = "search",
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
        var parameters = new ContactListParams
        {
            Channel = "channel",
            Phone = "phone",
            Search = "search",

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
        var parameters = new ContactListParams
        {
            Page = 0,
            PageSize = 0,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Channel);
        Assert.False(parameters.RawQueryData.ContainsKey("channel"));
        Assert.Null(parameters.Phone);
        Assert.False(parameters.RawQueryData.ContainsKey("phone"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ContactListParams
        {
            Page = 0,
            PageSize = 0,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            Channel = null,
            Phone = null,
            Search = null,
        };

        Assert.Null(parameters.Channel);
        Assert.True(parameters.RawQueryData.ContainsKey("channel"));
        Assert.Null(parameters.Phone);
        Assert.True(parameters.RawQueryData.ContainsKey("phone"));
        Assert.Null(parameters.Search);
        Assert.True(parameters.RawQueryData.ContainsKey("search"));
    }

    [Fact]
    public void Url_Works()
    {
        ContactListParams parameters = new()
        {
            Channel = "channel",
            Page = 0,
            PageSize = 0,
            Phone = "phone",
            Search = "search",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/contacts?channel=channel&page=0&page_size=0&phone=phone&search=search"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ContactListParams parameters = new()
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
        var parameters = new ContactListParams
        {
            Channel = "channel",
            Page = 0,
            PageSize = 0,
            Phone = "phone",
            Search = "search",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ContactListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
