using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class CallServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var apiResponseOfCall = await this.client.Calls.Retrieve(
            "call_9f2ab000-0000-4000-8000-000000000001",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfCall.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Calls.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Hangup_Works()
    {
        await this.client.Calls.Hangup(
            "call_9f2ab000-0000-4000-8000-000000000001",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListRecordings_Works()
    {
        var apiResponseOfCallRecordings = await this.client.Calls.ListRecordings(
            "call_9f2ab000-0000-4000-8000-000000000001",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfCallRecordings.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Record_Works()
    {
        await this.client.Calls.Record(
            "call_9f2ab000-0000-4000-8000-000000000001",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
