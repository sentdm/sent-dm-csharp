using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var user = await this.client.Users.Retrieve(
            "880e8400-e29b-41d4-a716-446655440003",
            new(),
            TestContext.Current.CancellationToken
        );
        user.Validate();
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
        var response = await this.client.Users.Invite(new(), TestContext.Current.CancellationToken);
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Remove_Works()
    {
        await this.client.Users.Remove(
            "aa0e8400-e29b-41d4-a716-446655440005",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateRole_Works()
    {
        var response = await this.client.Users.UpdateRole(
            "aa0e8400-e29b-41d4-a716-446655440005",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
