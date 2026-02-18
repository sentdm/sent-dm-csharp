using System.Threading.Tasks;

namespace SentDm.Tests.Services;

public class LookupServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrievePhoneInfo_Works()
    {
        var response = await this.client.Lookup.RetrievePhoneInfo(
            "phoneNumber",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
