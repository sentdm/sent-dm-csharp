using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class MessageServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var apiResponseOfCancelledMessage = await this.client.Messages.Cancel(
            "8ba7b830-9dad-11d1-80b4-00c04fd430c8",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfCancelledMessage.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Resend_Works()
    {
        var messageSendResponse = await this.client.Messages.Resend(
            "8ba7b830-9dad-11d1-80b4-00c04fd430c8",
            new(),
            TestContext.Current.CancellationToken
        );
        messageSendResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveActivities_Works()
    {
        var apiResponseOfMessageActivities = await this.client.Messages.RetrieveActivities(
            "8ba7b830-9dad-11d1-80b4-00c04fd430c8",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfMessageActivities.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveStatus_Works()
    {
        var apiResponseOfMessage = await this.client.Messages.RetrieveStatus(
            "8ba7b830-9dad-11d1-80b4-00c04fd430c8",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfMessage.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Send_Works()
    {
        var messageSendResponse = await this.client.Messages.Send(
            new(),
            TestContext.Current.CancellationToken
        );
        messageSendResponse.Validate();
    }
}
