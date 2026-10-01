using System;
using System.Net.Http;
using Sentdm.Models.Calls;

namespace Sentdm.Tests.Models.Calls;

public class CallListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CallListParams
        {
            Direction = "direction",
            From = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Number = "number",
            Page = 0,
            PageSize = 0,
            Status = "status",
            To = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedDirection = "direction";
        DateTimeOffset expectedFrom = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedNumber = "number";
        int expectedPage = 0;
        int expectedPageSize = 0;
        string expectedStatus = "status";
        DateTimeOffset expectedTo = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedDirection, parameters.Direction);
        Assert.Equal(expectedFrom, parameters.From);
        Assert.Equal(expectedNumber, parameters.Number);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedTo, parameters.To);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CallListParams
        {
            Direction = "direction",
            From = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Number = "number",
            Status = "status",
            To = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var parameters = new CallListParams
        {
            Direction = "direction",
            From = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Number = "number",
            Status = "status",
            To = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

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
        var parameters = new CallListParams
        {
            Page = 0,
            PageSize = 0,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Direction);
        Assert.False(parameters.RawQueryData.ContainsKey("direction"));
        Assert.Null(parameters.From);
        Assert.False(parameters.RawQueryData.ContainsKey("from"));
        Assert.Null(parameters.Number);
        Assert.False(parameters.RawQueryData.ContainsKey("number"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawQueryData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CallListParams
        {
            Page = 0,
            PageSize = 0,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            Direction = null,
            From = null,
            Number = null,
            Status = null,
            To = null,
        };

        Assert.Null(parameters.Direction);
        Assert.True(parameters.RawQueryData.ContainsKey("direction"));
        Assert.Null(parameters.From);
        Assert.True(parameters.RawQueryData.ContainsKey("from"));
        Assert.Null(parameters.Number);
        Assert.True(parameters.RawQueryData.ContainsKey("number"));
        Assert.Null(parameters.Status);
        Assert.True(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.To);
        Assert.True(parameters.RawQueryData.ContainsKey("to"));
    }

    [Fact]
    public void Url_Works()
    {
        CallListParams parameters = new()
        {
            Direction = "direction",
            From = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            Number = "number",
            Page = 0,
            PageSize = 0,
            Status = "status",
            To = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/calls?direction=direction&from=2019-12-27T18%3a11%3a19.117%2b00%3a00&number=number&page=0&page_size=0&status=status&to=2019-12-27T18%3a11%3a19.117%2b00%3a00"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CallListParams parameters = new() { XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(
            ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            requestMessage.Headers.GetValues("x-profile-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CallListParams
        {
            Direction = "direction",
            From = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Number = "number",
            Page = 0,
            PageSize = 0,
            Status = "status",
            To = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        CallListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
