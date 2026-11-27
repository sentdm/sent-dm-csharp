using System.Text.Json;
using System.Threading.Tasks;
using Sentdm.Models.Channels.Sms.TenDlc;

namespace Sentdm.Tests.Services.Channels.Sms;

public class TenDlcServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task AddCampaign_Works()
    {
        var apiResponseOfChannelMarket = await this.client.Channels.Sms.TenDlc.AddCampaign(
            new()
            {
                Description = "Appointment reminders for patients who opted in when booking.",
                HelpKeywords = "help_keywords",
                HelpMessage = "xxxxxxxxxxxxxxxxxxxx",
                MessageFlow = "Patients opt in on the booking form by checking a consent box.",
                OptInKeywords = "opt_in_keywords",
                OptInMessage = "xxxxxxxxxxxxxxxxxxxx",
                OptOutKeywords = "opt_out_keywords",
                OptOutMessage = "xxxxxxxxxxxxxxxxxxxx",
                PrivacyPolicyLink = "privacy_policy_link",
                TermsAndConditionsLink = "terms_and_conditions_link",
                UseCases =
                [
                    new()
                    {
                        SampleMessages =
                        [
                            JsonSerializer.SerializeToElement(
                                "Reminder: your appointment is tomorrow at 10:00. Reply STOP to opt out."
                            ),
                        ],
                        UseCase = UseCase.AccountNotification,
                    },
                ],
                Volume = "volume",
                IdempotencyKey = "req_abc123_retry1",
            },
            TestContext.Current.CancellationToken
        );
        apiResponseOfChannelMarket.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListCampaigns_Works()
    {
        var response = await this.client.Channels.Sms.TenDlc.ListCampaigns(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateCampaign_Works()
    {
        var apiResponseOfChannelMarket = await this.client.Channels.Sms.TenDlc.UpdateCampaign(
            "3f2a6c1e-8b4d-4e2a-9c7f-1d5b0a9e4c21",
            new(),
            TestContext.Current.CancellationToken
        );
        apiResponseOfChannelMarket.Validate();
    }
}
