using System.Threading.Tasks;

namespace SentDm.Tests.Services;

public class NumberLookupServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var numberLookup = await this.client.NumberLookup.Retrieve(
            new()
            {
                PhoneNumber = "phoneNumber",
                XApiKey = "",
                XSenderID = "00000000-0000-0000-0000-000000000000",
            },
            TestContext.Current.CancellationToken
        );
        numberLookup.Validate();
    }
}
