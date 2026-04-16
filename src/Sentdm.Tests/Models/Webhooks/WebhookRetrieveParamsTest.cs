using System;
using System.Net.Http;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookRetrieveParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookRetrieveParams { ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8" };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookRetrieveParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",

            // Null should be interpreted as omitted for these properties
            XProfileID = null,
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookRetrieveParams parameters = new() { ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.sent.dm/v3/webhooks/d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WebhookRetrieveParams parameters = new()
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
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
        var parameters = new WebhookRetrieveParams
        {
            ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        WebhookRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
