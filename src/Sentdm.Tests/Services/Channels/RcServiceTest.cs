using System.Threading.Tasks;

namespace Sentdm.Tests.Services.Channels;

public class RcServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var apiResponseOfRcsAgent = await this.client.Channels.Rcs.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfRcsAgent.Validate();
    }
}
