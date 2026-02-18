using System;
using Sentdm.Models.Brands.Campaigns;

namespace Sentdm.Tests.Models.Brands.Campaigns;

public class CampaignListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CampaignListParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
        };

        string expectedBrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890";

        Assert.Equal(expectedBrandID, parameters.BrandID);
    }

    [Fact]
    public void Url_Works()
    {
        CampaignListParams parameters = new() { BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/brands/a1b2c3d4-e5f6-7890-abcd-ef1234567890/campaigns"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CampaignListParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
        };

        CampaignListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
