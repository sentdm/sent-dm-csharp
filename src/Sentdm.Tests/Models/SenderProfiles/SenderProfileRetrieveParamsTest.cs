using System;
using Sentdm.Models.SenderProfiles;

namespace Sentdm.Tests.Models.SenderProfiles;

public class SenderProfileRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SenderProfileRetrieveParams
        {
            ID = "770e8400-e29b-41d4-a716-446655440002",
        };

        string expectedID = "770e8400-e29b-41d4-a716-446655440002";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        SenderProfileRetrieveParams parameters = new()
        {
            ID = "770e8400-e29b-41d4-a716-446655440002",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/sender-profiles/770e8400-e29b-41d4-a716-446655440002"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SenderProfileRetrieveParams
        {
            ID = "770e8400-e29b-41d4-a716-446655440002",
        };

        SenderProfileRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
