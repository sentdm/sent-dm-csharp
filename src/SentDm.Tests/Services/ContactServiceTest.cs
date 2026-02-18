using System.Threading.Tasks;

namespace SentDm.Tests.Services;

public class ContactServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var apiResponseContact = await this.client.Contacts.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseContact.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var apiResponseContact = await this.client.Contacts.Retrieve(
            "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseContact.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var apiResponseContact = await this.client.Contacts.Update(
            "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseContact.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var contacts = await this.client.Contacts.List(
            new() { Page = 0, PageSize = 0 },
            TestContext.Current.CancellationToken
        );
        contacts.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Contacts.Delete(
            "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            new() { Body = new() { TestMode = false } },
            TestContext.Current.CancellationToken
        );
    }
}
