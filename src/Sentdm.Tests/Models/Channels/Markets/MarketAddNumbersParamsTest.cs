using System;
using System.Collections.Generic;
using System.Net.Http;
using Sentdm.Models.Channels.Markets;
using Sentdm.Models.Channels.Sms;

namespace Sentdm.Tests.Models.Channels.Markets;

public class MarketAddNumbersParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MarketAddNumbersParams
        {
            Channel = "sms",
            Country = "US",
            Type = "TEN_DLC",
            Numbers =
            [
                new() { AreaCode = "415", Quantity = 2 },
                new() { AreaCode = "212", Quantity = 1 },
            ],
            IdempotencyKey = "req_abc123_retry1",
            CampaignID = "8f14e45f-ceea-467f-a8f0-7c2a3d1b9e01",
            Sandbox = false,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedChannel = "sms";
        string expectedCountry = "US";
        string expectedType = "TEN_DLC";
        List<SmsNumberRequest?> expectedNumbers =
        [
            new() { AreaCode = "415", Quantity = 2 },
            new() { AreaCode = "212", Quantity = 1 },
        ];
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedCampaignID = "8f14e45f-ceea-467f-a8f0-7c2a3d1b9e01";
        bool expectedSandbox = false;
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedChannel, parameters.Channel);
        Assert.Equal(expectedCountry, parameters.Country);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedNumbers.Count, parameters.Numbers.Count);
        for (int i = 0; i < expectedNumbers.Count; i++)
        {
            Assert.Equal(expectedNumbers[i], parameters.Numbers[i]);
        }
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedCampaignID, parameters.CampaignID);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MarketAddNumbersParams
        {
            Channel = "sms",
            Country = "US",
            Type = "TEN_DLC",
            Numbers =
            [
                new() { AreaCode = "415", Quantity = 2 },
                new() { AreaCode = "212", Quantity = 1 },
            ],
            IdempotencyKey = "req_abc123_retry1",
            CampaignID = "8f14e45f-ceea-467f-a8f0-7c2a3d1b9e01",
        };

        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MarketAddNumbersParams
        {
            Channel = "sms",
            Country = "US",
            Type = "TEN_DLC",
            Numbers =
            [
                new() { AreaCode = "415", Quantity = 2 },
                new() { AreaCode = "212", Quantity = 1 },
            ],
            IdempotencyKey = "req_abc123_retry1",
            CampaignID = "8f14e45f-ceea-467f-a8f0-7c2a3d1b9e01",

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
        var parameters = new MarketAddNumbersParams
        {
            Channel = "sms",
            Country = "US",
            Type = "TEN_DLC",
            Numbers =
            [
                new() { AreaCode = "415", Quantity = 2 },
                new() { AreaCode = "212", Quantity = 1 },
            ],
            IdempotencyKey = "req_abc123_retry1",
            Sandbox = false,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.CampaignID);
        Assert.False(parameters.RawBodyData.ContainsKey("campaign_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MarketAddNumbersParams
        {
            Channel = "sms",
            Country = "US",
            Type = "TEN_DLC",
            Numbers =
            [
                new() { AreaCode = "415", Quantity = 2 },
                new() { AreaCode = "212", Quantity = 1 },
            ],
            IdempotencyKey = "req_abc123_retry1",
            Sandbox = false,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            CampaignID = null,
        };

        Assert.Null(parameters.CampaignID);
        Assert.True(parameters.RawBodyData.ContainsKey("campaign_id"));
    }

    [Fact]
    public void Url_Works()
    {
        MarketAddNumbersParams parameters = new()
        {
            Channel = "sms",
            Country = "US",
            Type = "TEN_DLC",
            Numbers =
            [
                new() { AreaCode = "415", Quantity = 2 },
                new() { AreaCode = "212", Quantity = 1 },
            ],
            IdempotencyKey = "req_abc123_retry1",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.sent.dm/v3/channels/sms/US/TEN_DLC/numbers"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MarketAddNumbersParams parameters = new()
        {
            Channel = "sms",
            Country = "US",
            Type = "TEN_DLC",
            Numbers =
            [
                new() { AreaCode = "415", Quantity = 2 },
                new() { AreaCode = "212", Quantity = 1 },
            ],
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
        Assert.Equal(
            ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            requestMessage.Headers.GetValues("x-profile-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MarketAddNumbersParams
        {
            Channel = "sms",
            Country = "US",
            Type = "TEN_DLC",
            Numbers =
            [
                new() { AreaCode = "415", Quantity = 2 },
                new() { AreaCode = "212", Quantity = 1 },
            ],
            IdempotencyKey = "req_abc123_retry1",
            CampaignID = "8f14e45f-ceea-467f-a8f0-7c2a3d1b9e01",
            Sandbox = false,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        MarketAddNumbersParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
