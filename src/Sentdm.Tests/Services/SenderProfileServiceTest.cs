using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class SenderProfileServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var apiResponseOfSenderProfile = await this.client.SenderProfiles.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfSenderProfile.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var apiResponseOfSenderProfile = await this.client.SenderProfiles.Retrieve(
            "770e8400-e29b-41d4-a716-446655440002",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfSenderProfile.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var apiResponseOfSenderProfile = await this.client.SenderProfiles.Update(
            "770e8400-e29b-41d4-a716-446655440002",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfSenderProfile.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.SenderProfiles.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.SenderProfiles.Delete(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
