using System.Threading.Tasks;

namespace Sentdm.Tests.Services.Voice;

public class CatalogueServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var apiResponseOfVoiceCatalogue = await this.client.Voice.Catalogue.List(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfVoiceCatalogue.Validate();
    }
}
