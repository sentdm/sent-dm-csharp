using System.Threading.Tasks;

namespace Sentdm.Tests.Services.Voice;

public class VoiceServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var apiResponseOfVoiceCatalogue = await this.client.Voice.Voices.List(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfVoiceCatalogue.Validate();
    }
}
