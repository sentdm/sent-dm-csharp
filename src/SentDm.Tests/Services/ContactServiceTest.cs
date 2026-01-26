using System.Threading.Tasks;

namespace SentDm.Tests.Services;

public class ContactServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var contacts = await this.client.Contacts.List(
            new()
            {
                Page = 0,
                PageSize = 0,
                XApiKey = "",
                XSenderID = "00000000-0000-0000-0000-000000000000",
            },
            TestContext.Current.CancellationToken
        );
        contacts.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveByPhone_Works()
    {
        var contactListItem = await this.client.Contacts.RetrieveByPhone(
            new()
            {
                PhoneNumber = "phoneNumber",
                XApiKey = "",
                XSenderID = "00000000-0000-0000-0000-000000000000",
            },
            TestContext.Current.CancellationToken
        );
        contactListItem.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveID_Works()
    {
        var contactListItem = await this.client.Contacts.RetrieveID(
            new()
            {
                ID = "id",
                XApiKey = "",
                XSenderID = "00000000-0000-0000-0000-000000000000",
            },
            TestContext.Current.CancellationToken
        );
        contactListItem.Validate();
    }
}
