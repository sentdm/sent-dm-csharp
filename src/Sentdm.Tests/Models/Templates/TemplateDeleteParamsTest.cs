using System;
using System.Net.Http;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateDeleteParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            DeleteFromMeta = false,
            Sandbox = false,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8";
        bool expectedDeleteFromMeta = false;
        bool expectedSandbox = false;
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDeleteFromMeta, parameters.DeleteFromMeta);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateDeleteParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            DeleteFromMeta = false,
        };

        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplateDeleteParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            DeleteFromMeta = false,

            // Null should be interpreted as omitted for these properties
            Sandbox = null,
            XProfileID = null,
        };

        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateDeleteParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            Sandbox = false,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.DeleteFromMeta);
        Assert.False(parameters.RawBodyData.ContainsKey("delete_from_meta"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TemplateDeleteParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            Sandbox = false,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            DeleteFromMeta = null,
        };

        Assert.Null(parameters.DeleteFromMeta);
        Assert.True(parameters.RawBodyData.ContainsKey("delete_from_meta"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplateDeleteParams parameters = new() { ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/templates/7ba7b820-9dad-11d1-80b4-00c04fd430c8"),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TemplateDeleteParams parameters = new()
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
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
        var parameters = new TemplateDeleteParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            DeleteFromMeta = false,
            Sandbox = false,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        TemplateDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
