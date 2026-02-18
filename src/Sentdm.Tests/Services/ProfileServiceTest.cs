using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class ProfileServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var apiResponseOfProfileDetail = await this.client.Profiles.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfProfileDetail.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var apiResponseOfProfileDetail = await this.client.Profiles.Retrieve(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfProfileDetail.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var apiResponseOfProfileDetail = await this.client.Profiles.Update(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfProfileDetail.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var profiles = await this.client.Profiles.List(
            new(),
            TestContext.Current.CancellationToken
        );
        profiles.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Profiles.Delete(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Complete_Works()
    {
        await this.client.Profiles.Complete(
            "660e8400-e29b-41d4-a716-446655440000",
            new() { WebHookUrl = "https://your-app.com/webhook/profile-complete" },
            TestContext.Current.CancellationToken
        );
    }
}
