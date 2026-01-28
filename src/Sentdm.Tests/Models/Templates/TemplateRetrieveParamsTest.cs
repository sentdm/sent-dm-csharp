using System;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateRetrieveParams { ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8" };

        string expectedID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        TemplateRetrieveParams parameters = new() { ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8" };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v2/templates/7ba7b820-9dad-11d1-80b4-00c04fd430c8"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateRetrieveParams { ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8" };

        TemplateRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
