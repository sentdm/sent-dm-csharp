using System.Threading.Tasks;

namespace Sentdm.Tests.Services.Organizations;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var customerUser = await this.client.Organizations.Users.Retrieve(
            "650e8400-e29b-41d4-a716-446655440000",
            new() { CustomerID = "550e8400-e29b-41d4-a716-446655440000" },
            TestContext.Current.CancellationToken
        );
        customerUser.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var users = await this.client.Organizations.Users.List(
            "550e8400-e29b-41d4-a716-446655440000",
            new() { Page = 0, PageSize = 0 },
            TestContext.Current.CancellationToken
        );
        users.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Organizations.Users.Delete(
            "650e8400-e29b-41d4-a716-446655440000",
            new() { CustomerID = "550e8400-e29b-41d4-a716-446655440000" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Invite_Works()
    {
        var customerUser = await this.client.Organizations.Users.Invite(
            "550e8400-e29b-41d4-a716-446655440000",
            new(),
            TestContext.Current.CancellationToken
        );
        customerUser.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task UpdateRole_Works()
    {
        var customerUser = await this.client.Organizations.Users.UpdateRole(
            "650e8400-e29b-41d4-a716-446655440000",
            new() { CustomerID = "550e8400-e29b-41d4-a716-446655440000" },
            TestContext.Current.CancellationToken
        );
        customerUser.Validate();
    }
}
