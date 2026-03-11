using System.Threading.Tasks;
using Sentdm.Models.Profiles.Campaigns;

namespace Sentdm.Tests.Services.Profiles;

public class CampaignServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var apiResponseOfTcrCampaignWithUseCases = await this.client.Profiles.Campaigns.Create(
            "770e8400-e29b-41d4-a716-446655440002",
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
        apiResponseOfTcrCampaignWithUseCases.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var apiResponseOfTcrCampaignWithUseCases = await this.client.Profiles.Campaigns.Update(
            "b2c3d4e5-f6a7-8901-bcde-f12345678901",
            new()
            {
                ProfileID = "770e8400-e29b-41d4-a716-446655440002",
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
        apiResponseOfTcrCampaignWithUseCases.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var campaigns = await this.client.Profiles.Campaigns.List(
            "770e8400-e29b-41d4-a716-446655440002",
            new(),
            TestContext.Current.CancellationToken
        );
        campaigns.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Profiles.Campaigns.Delete(
            "b2c3d4e5-f6a7-8901-bcde-f12345678901",
            new()
            {
                ProfileID = "770e8400-e29b-41d4-a716-446655440002",
                Body = new() { Sandbox = false },
            },
            TestContext.Current.CancellationToken
        );
    }
}
