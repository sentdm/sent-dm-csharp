using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class OrganizationServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var organizations = await this.client.Organizations.List(
            new(),
            TestContext.Current.CancellationToken
        );
        organizations.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveProfiles_Works()
    {
        var response = await this.client.Organizations.RetrieveProfiles(
            "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
