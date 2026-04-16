using System;
using System.Net.Http;
using Sentdm.Models.Contacts;

namespace Sentdm.Tests.Models.Contacts;

public class ContactRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactRetrieveParams
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ContactRetrieveParams { ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8" };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ContactRetrieveParams
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",

            // Null should be interpreted as omitted for these properties
            XProfileID = null,
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void Url_Works()
    {
        ContactRetrieveParams parameters = new() { ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.sent.dm/v3/contacts/6ba7b810-9dad-11d1-80b4-00c04fd430c8"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ContactRetrieveParams parameters = new()
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
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
        var parameters = new ContactRetrieveParams
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ContactRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
