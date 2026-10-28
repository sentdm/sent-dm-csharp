using System;
using System.Net.Http;
using Sentdm.Models.Voice.Catalogue;

namespace Sentdm.Tests.Models.Voice.Catalogue;

public class CatalogueListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CatalogueListParams
        {
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CatalogueListParams { };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CatalogueListParams
        {
            // Null should be interpreted as omitted for these properties
            XProfileID = null,
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void Url_Works()
    {
        CatalogueListParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.sent.dm/v3/voice/voices"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CatalogueListParams parameters = new()
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
        var parameters = new CatalogueListParams
        {
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        CatalogueListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
