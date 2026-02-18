using System;
using Sentdm.Models.Messages;

namespace Sentdm.Tests.Models.Messages;

public class MessageRetrieveActivitiesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageRetrieveActivitiesParams
        {
            ID = "8ba7b830-9dad-11d1-80b4-00c04fd430c8",
        };

        string expectedID = "8ba7b830-9dad-11d1-80b4-00c04fd430c8";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        MessageRetrieveActivitiesParams parameters = new()
        {
            ID = "8ba7b830-9dad-11d1-80b4-00c04fd430c8",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.sent.dm/v3/messages/8ba7b830-9dad-11d1-80b4-00c04fd430c8/activities"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MessageRetrieveActivitiesParams
        {
            ID = "8ba7b830-9dad-11d1-80b4-00c04fd430c8",
        };

        MessageRetrieveActivitiesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
