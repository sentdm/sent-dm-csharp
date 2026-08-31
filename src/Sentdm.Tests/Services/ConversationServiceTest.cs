using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class ConversationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var conversations = await this.client.Conversations.List(
            new() { Page = 0, PageSize = 0 },
            TestContext.Current.CancellationToken
        );
        conversations.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListMessages_Works()
    {
        var response = await this.client.Conversations.ListMessages(
            "08fab313-c9e2-502c-975e-08b0356c432e",
            new() { Page = 0, PageSize = 0 },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
