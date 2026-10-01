using System;
using System.Net.Http;
using Sentdm.Models.Calls;

namespace Sentdm.Tests.Models.Calls;

public class CallRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CallRetrieveParams
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "call_9f2ab000-0000-4000-8000-000000000001";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CallRetrieveParams
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CallRetrieveParams
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",

            // Null should be interpreted as omitted for these properties
            XProfileID = null,
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void Url_Works()
    {
        CallRetrieveParams parameters = new() { ID = "call_9f2ab000-0000-4000-8000-000000000001" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.sent.dm/v3/calls/call_9f2ab000-0000-4000-8000-000000000001"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CallRetrieveParams parameters = new()
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
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
        var parameters = new CallRetrieveParams
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        CallRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
