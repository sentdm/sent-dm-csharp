using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class NumberLookupServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var numberLookup = await this.client.NumberLookup.Retrieve(
            new() { PhoneNumber = "phoneNumber" },
            TestContext.Current.CancellationToken
        );
        numberLookup.Validate();
    }
}
