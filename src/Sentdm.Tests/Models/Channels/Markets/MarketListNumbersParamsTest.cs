using System;
using System.Net.Http;
using Sentdm.Models.Channels.Markets;

namespace Sentdm.Tests.Models.Channels.Markets;

public class MarketListNumbersParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MarketListNumbersParams
        {
            Channel = "channel",
            Country = "country",
            Type = "type",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedChannel = "channel";
        string expectedCountry = "country";
        string expectedType = "type";
        string expectedCampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedChannel, parameters.Channel);
        Assert.Equal(expectedCountry, parameters.Country);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedCampaignID, parameters.CampaignID);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MarketListNumbersParams
        {
            Channel = "channel",
            Country = "country",
            Type = "type",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MarketListNumbersParams
        {
            Channel = "channel",
            Country = "country",
            Type = "type",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            XProfileID = null,
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MarketListNumbersParams
        {
            Channel = "channel",
            Country = "country",
            Type = "type",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.CampaignID);
        Assert.False(parameters.RawQueryData.ContainsKey("campaign_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MarketListNumbersParams
        {
            Channel = "channel",
            Country = "country",
            Type = "type",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            CampaignID = null,
        };

        Assert.Null(parameters.CampaignID);
        Assert.True(parameters.RawQueryData.ContainsKey("campaign_id"));
    }

    [Fact]
    public void Url_Works()
    {
        MarketListNumbersParams parameters = new()
        {
            Channel = "channel",
            Country = "country",
            Type = "type",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/channels/channel/country/type/numbers?campaign_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MarketListNumbersParams parameters = new()
        {
            Channel = "channel",
            Country = "country",
            Type = "type",
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
        var parameters = new MarketListNumbersParams
        {
            Channel = "channel",
            Country = "country",
            Type = "type",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        MarketListNumbersParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
