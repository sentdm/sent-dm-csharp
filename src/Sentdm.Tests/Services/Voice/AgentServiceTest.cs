using System.Threading.Tasks;

namespace Sentdm.Tests.Services.Voice;

public class AgentServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var apiResponseOfVoiceAgent = await this.client.Voice.Agents.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfVoiceAgent.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var apiResponseOfVoiceAgent = await this.client.Voice.Agents.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfVoiceAgent.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var apiResponseOfVoiceAgent = await this.client.Voice.Agents.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfVoiceAgent.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Voice.Agents.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Voice.Agents.Delete("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RotateSecret_Works()
    {
        var apiResponseOfVoiceAgentSecret = await this.client.Voice.Agents.RotateSecret(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfVoiceAgentSecret.Validate();
    }
}
