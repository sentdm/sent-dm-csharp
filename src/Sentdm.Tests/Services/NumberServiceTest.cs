using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class NumberServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Lookup_Works()
    {
        var response = await this.client.Numbers.Lookup(
            "+12025551234",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
