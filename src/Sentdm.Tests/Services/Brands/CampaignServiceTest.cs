using System.Threading.Tasks;
using Sentdm.Models.Brands.Campaigns;

namespace Sentdm.Tests.Services.Brands;

public class CampaignServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var apiResponseTcrCampaignWithUseCases = await this.client.Brands.Campaigns.Create(
            "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            new()
            {
                Campaign = new()
                {
                    Description = "Appointment reminders and account notifications",
                    Name = "Customer Notifications",
                    Type = "App",
                    UseCases =
                    [
                        new()
                        {
                            MessagingUseCaseUs = MessagingUseCaseUs.AccountNotification,
                            SampleMessages =
                            [
                                "Hi {name}, your appointment is confirmed for {date} at {time}.",
                                "Your order #{order_id} has been shipped. Track at {url}",
                            ],
                        },
                    ],
                    HelpKeywords = "HELP, INFO, SUPPORT",
                    HelpMessage = "Reply STOP to unsubscribe or contact support@acmecorp.com",
                    MessageFlow =
                        "User signs up on website and opts in to receive SMS notifications",
                    OptinKeywords = "YES, START, SUBSCRIBE",
                    OptinMessage =
                        "You have opted in to Acme Corp notifications. Reply STOP to opt out.",
                    OptoutKeywords = "STOP, UNSUBSCRIBE, END",
                    OptoutMessage = "You have been unsubscribed. Reply START to opt back in.",
                    PrivacyPolicyLink = "https://acmecorp.com/privacy",
                    TermsAndConditionsLink = "https://acmecorp.com/terms",
                },
            },
            TestContext.Current.CancellationToken
        );
        apiResponseTcrCampaignWithUseCases.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var apiResponseTcrCampaignWithUseCases = await this.client.Brands.Campaigns.Update(
            "b2c3d4e5-f6a7-8901-bcde-f12345678901",
            new()
            {
                BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                Campaign = new()
                {
                    Description = "Updated appointment reminders and account notifications",
                    Name = "Customer Notifications Updated",
                    Type = "App",
                    UseCases =
                    [
                        new()
                        {
                            MessagingUseCaseUs = MessagingUseCaseUs.AccountNotification,
                            SampleMessages =
                            [
                                "Hi {name}, your appointment is confirmed for {date} at {time}.",
                                "Your order #{order_id} has been shipped. Track at {url}",
                            ],
                        },
                    ],
                    HelpKeywords = null,
                    HelpMessage = null,
                    MessageFlow =
                        "User signs up on website and opts in to receive SMS notifications",
                    OptinKeywords = null,
                    OptinMessage = null,
                    OptoutKeywords = null,
                    OptoutMessage = null,
                    PrivacyPolicyLink = null,
                    TermsAndConditionsLink = null,
                },
            },
            TestContext.Current.CancellationToken
        );
        apiResponseTcrCampaignWithUseCases.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var campaigns = await this.client.Brands.Campaigns.List(
            "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            new(),
            TestContext.Current.CancellationToken
        );
        campaigns.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Brands.Campaigns.Delete(
            "b2c3d4e5-f6a7-8901-bcde-f12345678901",
            new()
            {
                BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                Body = new() { TestMode = false },
            },
            TestContext.Current.CancellationToken
        );
    }
}
