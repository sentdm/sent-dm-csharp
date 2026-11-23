using System.Threading.Tasks;
using Sentdm.Models.Channels.Sms;

namespace Sentdm.Tests.Services.Channels;

public class SmsServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var sms = await this.client.Channels.Sms.Create(
            new() { NumberType = NumberType.TenDlc },
            TestContext.Current.CancellationToken
        );
        sms.Validate();
    }
}
