using System;
using SentDm.Models.Contacts;

namespace SentDm.Tests.Models.Contacts;

public class ContactListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactListParams
        {
            Page = 0,
            PageSize = 0,
            Channel = "channel",
            Phone = "phone",
            Search = "search",
        };

        int expectedPage = 0;
        int expectedPageSize = 0;
        string expectedChannel = "channel";
        string expectedPhone = "phone";
        string expectedSearch = "search";

        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedChannel, parameters.Channel);
        Assert.Equal(expectedPhone, parameters.Phone);
        Assert.Equal(expectedSearch, parameters.Search);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ContactListParams { Page = 0, PageSize = 0 };

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
            Page = 0,
            PageSize = 0,
            Channel = "channel",
            Phone = "phone",
            Search = "search",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.sent.dm/v3/contacts?page=0&pageSize=0&channel=channel&phone=phone&search=search"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactListParams
        {
            Page = 0,
            PageSize = 0,
            Channel = "channel",
            Phone = "phone",
            Search = "search",
        };

        ContactListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
