using System.Threading.Tasks;

namespace SentDm.Tests.Services;

public class TemplateServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var apiResponseTemplate = await this.client.Templates.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseTemplate.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var apiResponseTemplate = await this.client.Templates.Retrieve(
            "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseTemplate.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var apiResponseTemplate = await this.client.Templates.Update(
            "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseTemplate.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var templates = await this.client.Templates.List(
            new() { Page = 0, PageSize = 0 },
            TestContext.Current.CancellationToken
        );
        templates.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Templates.Delete(
            "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
