using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class ChannelServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var apiResponseOfChannelsState = await this.client.Channels.List(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfChannelsState.Validate();
    }
}
