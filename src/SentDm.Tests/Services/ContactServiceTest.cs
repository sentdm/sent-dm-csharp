using System.Threading.Tasks;

namespace SentDm.Tests.Services;

public class ContactServiceTest : TestBase
{
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
    public async Task RetrieveByPhone_Works()
    {
        var contactListItem = await this.client.Contacts.RetrieveByPhone(
            new() { PhoneNumber = "phoneNumber" },
            TestContext.Current.CancellationToken
        );
        contactListItem.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveID_Works()
    {
        var contactListItem = await this.client.Contacts.RetrieveID(
            new() { ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
        contactListItem.Validate();
    }
}
