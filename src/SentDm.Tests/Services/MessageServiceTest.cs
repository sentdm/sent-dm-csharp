using System.Threading.Tasks;

namespace SentDm.Tests.Services;

public class MessageServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var message = await this.client.Messages.Retrieve(
            "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            new() { XApiKey = "", XSenderID = "00000000-0000-0000-0000-000000000000" },
            TestContext.Current.CancellationToken
        );
        message.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SendQuickMessage_Works()
    {
        await this.client.Messages.SendQuickMessage(
            new()
            {
                CustomMessage = "Hello, this is a test message!",
                PhoneNumber = "+1234567890",
                XApiKey = "",
                XSenderID = "00000000-0000-0000-0000-000000000000",
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SendToContact_Works()
    {
        await this.client.Messages.SendToContact(
            new()
            {
                ContactID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
                TemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
                XApiKey = "",
                XSenderID = "00000000-0000-0000-0000-000000000000",
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SendToPhone_Works()
    {
        await this.client.Messages.SendToPhone(
            new()
            {
                PhoneNumber = "+1234567890",
                TemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
                XApiKey = "",
                XSenderID = "00000000-0000-0000-0000-000000000000",
            },
            TestContext.Current.CancellationToken
        );
    }
}
