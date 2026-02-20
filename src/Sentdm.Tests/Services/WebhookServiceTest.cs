using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class WebhookServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var apiResponseWebhook = await this.client.Webhooks.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseWebhook.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var apiResponseWebhook = await this.client.Webhooks.Retrieve(
            "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseWebhook.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var apiResponseWebhook = await this.client.Webhooks.Update(
            "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseWebhook.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var webhooks = await this.client.Webhooks.List(
            new() { Page = 0, PageSize = 0 },
            TestContext.Current.CancellationToken
        );
        webhooks.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Webhooks.Delete(
            "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListEventTypes_Works()
    {
        var response = await this.client.Webhooks.ListEventTypes(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListEvents_Works()
    {
        var response = await this.client.Webhooks.ListEvents(
            "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            new() { Page = 0, PageSize = 0 },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RotateSecret_Works()
    {
        var response = await this.client.Webhooks.RotateSecret(
            "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            new() { Body = new() { TestMode = false } },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Test_Works()
    {
        var response = await this.client.Webhooks.Test(
            "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ToggleStatus_Works()
    {
        var apiResponseWebhook = await this.client.Webhooks.ToggleStatus(
            "d4f5a6b7-c8d9-4e0f-a1b2-c3d4e5f6a7b8",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseWebhook.Validate();
    }
}
