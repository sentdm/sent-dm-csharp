using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var apiResponseOfUser = await this.client.Users.Retrieve(
            "userId",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfUser.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var users = await this.client.Users.List(new(), TestContext.Current.CancellationToken);
        users.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Invite_Works()
    {
        var apiResponseOfUser = await this.client.Users.Invite(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfUser.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Remove_Works()
    {
        await this.client.Users.Remove("userId", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateRole_Works()
    {
        var apiResponseOfUser = await this.client.Users.UpdateRole(
            "userId",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfUser.Validate();
    }
}
