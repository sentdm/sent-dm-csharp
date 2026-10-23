using System.Threading.Tasks;

namespace Sentdm.Tests.Services.Voice;

public class TokenServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var apiResponseOfVoiceToken = await this.client.Voice.Tokens.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfVoiceToken.Validate();
    }
}
