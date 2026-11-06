using System.Threading.Tasks;

namespace Sentdm.Tests.Services.Channels;

public class WhatsappServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var apiResponseOfWhatsappChannel = await this.client.Channels.Whatsapp.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfWhatsappChannel.Validate();
    }
}
