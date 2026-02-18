using System.Threading.Tasks;

namespace SentDm.Tests.Services;

public class MessageServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveActivities_Works()
    {
        var response = await this.client.Messages.RetrieveActivities(
            "8ba7b830-9dad-11d1-80b4-00c04fd430c8",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveStatus_Works()
    {
        var response = await this.client.Messages.RetrieveStatus(
            "8ba7b830-9dad-11d1-80b4-00c04fd430c8",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Send_Works()
    {
        var response = await this.client.Messages.Send(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
