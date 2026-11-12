using System.Threading.Tasks;

namespace Sentdm.Tests.Services.Channels.Sms;

public class TenDlcServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task AddCampaign_Works()
    {
        var apiResponseOfSmsMarket = await this.client.Channels.Sms.TenDlc.AddCampaign(
            new() { IdempotencyKey = "req_abc123_retry1" },
            TestContext.Current.CancellationToken
        );
        apiResponseOfSmsMarket.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task AddNumbers_Works()
    {
        var apiResponseOfSmsMarket = await this.client.Channels.Sms.TenDlc.AddNumbers(
            new()
            {
                CampaignID = "8f14e45f-ceea-467f-a8f0-7c2a3d1b9e01",
                Numbers = [new() { AreaCode = "415", Quantity = 2 }],
                IdempotencyKey = "req_abc123_retry1",
            },
            TestContext.Current.CancellationToken
        );
        apiResponseOfSmsMarket.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveCompliance_Works()
    {
        var apiResponseOfSuppliedCompliance =
            await this.client.Channels.Sms.TenDlc.RetrieveCompliance(
                new(),
                TestContext.Current.CancellationToken
            );
        apiResponseOfSuppliedCompliance.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateCampaign_Works()
    {
        var apiResponseOfSmsMarket = await this.client.Channels.Sms.TenDlc.UpdateCampaign(
            "3f2a6c1e-8b4d-4e2a-9c7f-1d5b0a9e4c21",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfSmsMarket.Validate();
    }
}
