using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class MeServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var me = await this.client.Me.Retrieve(new(), TestContext.Current.CancellationToken);
        me.Validate();
    }
}
