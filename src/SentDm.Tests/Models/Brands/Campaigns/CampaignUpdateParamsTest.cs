using System;
using System.Net.Http;
using SentDm.Models.Brands.Campaigns;

namespace SentDm.Tests.Models.Brands.Campaigns;

public class CampaignUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CampaignUpdateParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            CampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
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
                MessageFlow = "User signs up on website and opts in to receive SMS notifications",
                OptinKeywords = null,
                OptinMessage = null,
                OptoutKeywords = null,
                OptoutMessage = null,
                PrivacyPolicyLink = null,
                TermsAndConditionsLink = null,
            },
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        string expectedBrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890";
        string expectedCampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901";
        CampaignData expectedCampaign = new()
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
            MessageFlow = "User signs up on website and opts in to receive SMS notifications",
            OptinKeywords = null,
            OptinMessage = null,
            OptoutKeywords = null,
            OptoutMessage = null,
            PrivacyPolicyLink = null,
            TermsAndConditionsLink = null,
        };
        bool expectedTestMode = false;
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedCampaignID, parameters.CampaignID);
        Assert.Equal(expectedCampaign, parameters.Campaign);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CampaignUpdateParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            CampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
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
                MessageFlow = "User signs up on website and opts in to receive SMS notifications",
                OptinKeywords = null,
                OptinMessage = null,
                OptoutKeywords = null,
                OptoutMessage = null,
                PrivacyPolicyLink = null,
                TermsAndConditionsLink = null,
            },
        };

        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CampaignUpdateParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            CampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
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
                MessageFlow = "User signs up on website and opts in to receive SMS notifications",
                OptinKeywords = null,
                OptinMessage = null,
                OptoutKeywords = null,
                OptoutMessage = null,
                PrivacyPolicyLink = null,
                TermsAndConditionsLink = null,
            },

            // Null should be interpreted as omitted for these properties
            TestMode = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void Url_Works()
    {
        CampaignUpdateParams parameters = new()
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            CampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
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
                MessageFlow = "User signs up on website and opts in to receive SMS notifications",
                OptinKeywords = null,
                OptinMessage = null,
                OptoutKeywords = null,
                OptoutMessage = null,
                PrivacyPolicyLink = null,
                TermsAndConditionsLink = null,
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.sent.dm/v3/brands/a1b2c3d4-e5f6-7890-abcd-ef1234567890/campaigns/b2c3d4e5-f6a7-8901-bcde-f12345678901"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CampaignUpdateParams parameters = new()
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            CampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
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
                MessageFlow = "User signs up on website and opts in to receive SMS notifications",
                OptinKeywords = null,
                OptinMessage = null,
                OptoutKeywords = null,
                OptoutMessage = null,
                PrivacyPolicyLink = null,
                TermsAndConditionsLink = null,
            },
            IdempotencyKey = "req_abc123_retry1",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CampaignUpdateParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            CampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
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
                MessageFlow = "User signs up on website and opts in to receive SMS notifications",
                OptinKeywords = null,
                OptinMessage = null,
                OptoutKeywords = null,
                OptoutMessage = null,
                PrivacyPolicyLink = null,
                TermsAndConditionsLink = null,
            },
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        CampaignUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
