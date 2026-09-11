using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class ConversationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Conversations.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListMessages_Works()
    {
        var page = await this.client.Conversations.ListMessages(
            "08fab313-c9e2-502c-975e-08b0356c432e",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
