using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class ComplianceServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveRequirements_Works()
    {
        var apiResponseOfComplianceRequirements = await this.client.Compliance.RetrieveRequirements(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfComplianceRequirements.Validate();
    }
}
