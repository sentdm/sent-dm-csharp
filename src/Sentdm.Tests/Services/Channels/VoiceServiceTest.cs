using System.Threading.Tasks;

namespace Sentdm.Tests.Services.Channels;

public class VoiceServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var apiResponseOfVoiceNumberCreated = await this.client.Channels.Voice.Create(
            new() { CallbackUrl = "https://example.com/voice" },
            TestContext.Current.CancellationToken
        );
        apiResponseOfVoiceNumberCreated.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var apiResponseOfVoiceNumber = await this.client.Channels.Voice.Retrieve(
            "+12125550100",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfVoiceNumber.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var apiResponseOfVoiceNumber = await this.client.Channels.Voice.Update(
            "+12125550100",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfVoiceNumber.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var apiResponseOfListOfVoiceNumber = await this.client.Channels.Voice.List(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfListOfVoiceNumber.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateToken_Works()
    {
        var apiResponseOfVoiceToken = await this.client.Channels.Voice.CreateToken(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfVoiceToken.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RotateSecret_Works()
    {
        var apiResponseOfVoiceSecret = await this.client.Channels.Voice.RotateSecret(
            "+12125550100",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfVoiceSecret.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Test_Works()
    {
        var apiResponseOfVoiceCallbackTest = await this.client.Channels.Voice.Test(
            "+12025550123",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfVoiceCallbackTest.Validate();
    }
}
