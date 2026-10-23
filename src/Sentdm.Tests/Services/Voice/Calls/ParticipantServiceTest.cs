using System.Threading.Tasks;

namespace Sentdm.Tests.Services.Voice.Calls;

public class ParticipantServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Voice.Calls.Participants.Update(
            "call_9f2ab000-0000-4000-8000-000000000002",
            new() { ID = "call_9f2ab000-0000-4000-8000-000000000001" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var apiResponseOfListOfCallParticipant = await this.client.Voice.Calls.Participants.List(
            "call_9f2ab000-0000-4000-8000-000000000001",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfListOfCallParticipant.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Add_Works()
    {
        var apiResponseOfCall = await this.client.Voice.Calls.Participants.Add(
            "call_9f2ab000-0000-4000-8000-000000000001",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfCall.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Remove_Works()
    {
        await this.client.Voice.Calls.Participants.Remove(
            "call_9f2ab000-0000-4000-8000-000000000002",
            new() { ID = "call_9f2ab000-0000-4000-8000-000000000001" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RemoveAll_Works()
    {
        await this.client.Voice.Calls.Participants.RemoveAll(
            "call_9f2ab000-0000-4000-8000-000000000001",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
