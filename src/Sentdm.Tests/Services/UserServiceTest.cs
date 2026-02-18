using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var apiResponseOfUser = await this.client.Users.Retrieve(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfUser.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var users = await this.client.Users.List(new(), TestContext.Current.CancellationToken);
        users.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Invite_Works()
    {
        var apiResponseOfUser = await this.client.Users.Invite(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfUser.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Remove_Works()
    {
        await this.client.Users.Remove(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task UpdateRole_Works()
    {
        var apiResponseOfUser = await this.client.Users.UpdateRole(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfUser.Validate();
    }
}
