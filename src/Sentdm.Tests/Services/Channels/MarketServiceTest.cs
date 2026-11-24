using System.Threading.Tasks;

namespace Sentdm.Tests.Services.Channels;

public class MarketServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var apiResponseOfChannelMarket = await this.client.Channels.Markets.Retrieve(
            "ten_dlc",
            new() { Channel = "sms", Country = "US" },
            TestContext.Current.CancellationToken
        );
        apiResponseOfChannelMarket.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var apiResponseOfChannelMarket = await this.client.Channels.Markets.Update(
            "ten_dlc",
            new() { Channel = "sms", Country = "US" },
            TestContext.Current.CancellationToken
        );
        apiResponseOfChannelMarket.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var apiResponseOfListOfChannelMarket = await this.client.Channels.Markets.List(
            "channel",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfListOfChannelMarket.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task AddNumbers_Works()
    {
        var apiResponseOfChannelMarket = await this.client.Channels.Markets.AddNumbers(
            "TEN_DLC",
            new()
            {
                Channel = "sms",
                Country = "US",
                Numbers =
                [
                    new() { AreaCode = "415", Quantity = 2 },
                    new() { AreaCode = "212", Quantity = 1 },
                ],
                IdempotencyKey = "req_abc123_retry1",
            },
            TestContext.Current.CancellationToken
        );
        apiResponseOfChannelMarket.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListNumbers_Works()
    {
        var apiResponseOfMarketNumbers = await this.client.Channels.Markets.ListNumbers(
            "type",
            new() { Channel = "channel", Country = "country" },
            TestContext.Current.CancellationToken
        );
        apiResponseOfMarketNumbers.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ReplaceNumbers_Works()
    {
        var apiResponseOfChannelMarket = await this.client.Channels.Markets.ReplaceNumbers(
            "TEN_DLC",
            new()
            {
                Channel = "sms",
                Country = "US",
                Numbers =
                [
                    new() { AreaCode = "415", Quantity = 2 },
                    new() { AreaCode = "212", Quantity = 1 },
                ],
            },
            TestContext.Current.CancellationToken
        );
        apiResponseOfChannelMarket.Validate();
    }
}
