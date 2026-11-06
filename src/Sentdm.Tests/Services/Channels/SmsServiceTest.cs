using System.Threading.Tasks;
using Sentdm.Models.Channels.Sms;

namespace Sentdm.Tests.Services.Channels;

public class SmsServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var apiResponseOfSmsMarket = await this.client.Channels.Sms.Create(
            new() { NumberType = NumberType.TenDlc },
            TestContext.Current.CancellationToken
        );
        apiResponseOfSmsMarket.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var apiResponseOfSmsMarket = await this.client.Channels.Sms.Retrieve(
            "ten_dlc",
            new() { Country = "US" },
            TestContext.Current.CancellationToken
        );
        apiResponseOfSmsMarket.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var apiResponseOfSmsMarket = await this.client.Channels.Sms.Update(
            "ten_dlc",
            new() { Country = "US" },
            TestContext.Current.CancellationToken
        );
        apiResponseOfSmsMarket.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var apiResponseOfListOfSmsMarket = await this.client.Channels.Sms.List(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfListOfSmsMarket.Validate();
    }
}
