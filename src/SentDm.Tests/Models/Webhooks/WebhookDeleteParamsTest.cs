using System;
using SentDm.Models.Webhooks;

namespace SentDm.Tests.Models.Webhooks;

public class WebhookDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookDeleteParams { ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8" };

        string expectedID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        WebhookDeleteParams parameters = new() { ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/webhooks/d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookDeleteParams { ID = "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8" };

        WebhookDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
