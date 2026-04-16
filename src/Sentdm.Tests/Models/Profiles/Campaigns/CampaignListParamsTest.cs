using System;
using System.Net.Http;
using Sentdm.Models.Profiles.Campaigns;

namespace Sentdm.Tests.Models.Profiles.Campaigns;

public class CampaignListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CampaignListParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedProfileID = "770e8400-e29b-41d4-a716-446655440002";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedProfileID, parameters.ProfileID);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CampaignListParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CampaignListParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",

            // Null should be interpreted as omitted for these properties
            XProfileID = null,
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void Url_Works()
    {
        CampaignListParams parameters = new()
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/profiles/770e8400-e29b-41d4-a716-446655440002/campaigns"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CampaignListParams parameters = new()
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
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
        var parameters = new CampaignListParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        CampaignListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
