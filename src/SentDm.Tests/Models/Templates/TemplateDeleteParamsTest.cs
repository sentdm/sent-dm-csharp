using System;
using SentDm.Models.Templates;

namespace SentDm.Tests.Models.Templates;

public class TemplateDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateDeleteParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            DeleteFromMeta = false,
            TestMode = false,
        };

        string expectedID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8";
        bool expectedDeleteFromMeta = false;
        bool expectedTestMode = false;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDeleteFromMeta, parameters.DeleteFromMeta);
        Assert.Equal(expectedTestMode, parameters.TestMode);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateDeleteParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            DeleteFromMeta = false,
        };

        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplateDeleteParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            DeleteFromMeta = false,

            // Null should be interpreted as omitted for these properties
            TestMode = null,
        };

        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateDeleteParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            TestMode = false,
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
            TestMode = false,

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
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateDeleteParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            DeleteFromMeta = false,
            TestMode = false,
        };

        TemplateDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
