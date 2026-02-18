using System;
using System.Net.Http;
using SentDm.Models.Brands.Campaigns;

namespace SentDm.Tests.Models.Brands.Campaigns;

public class CampaignCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CampaignCreateParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
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
                MessageFlow = "User signs up on website and opts in to receive SMS notifications",
                OptinKeywords = "YES, START, SUBSCRIBE",
                OptinMessage =
                    "You have opted in to Acme Corp notifications. Reply STOP to opt out.",
                OptoutKeywords = "STOP, UNSUBSCRIBE, END",
                OptoutMessage = "You have been unsubscribed. Reply START to opt back in.",
                PrivacyPolicyLink = "https://acmecorp.com/privacy",
                TermsAndConditionsLink = "https://acmecorp.com/terms",
            },
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        string expectedBrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890";
        CampaignData expectedCampaign = new()
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
            MessageFlow = "User signs up on website and opts in to receive SMS notifications",
            OptinKeywords = "YES, START, SUBSCRIBE",
            OptinMessage = "You have opted in to Acme Corp notifications. Reply STOP to opt out.",
            OptoutKeywords = "STOP, UNSUBSCRIBE, END",
            OptoutMessage = "You have been unsubscribed. Reply START to opt back in.",
            PrivacyPolicyLink = "https://acmecorp.com/privacy",
            TermsAndConditionsLink = "https://acmecorp.com/terms",
        };
        bool expectedTestMode = false;
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedCampaign, parameters.Campaign);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CampaignCreateParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
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
                MessageFlow = "User signs up on website and opts in to receive SMS notifications",
                OptinKeywords = "YES, START, SUBSCRIBE",
                OptinMessage =
                    "You have opted in to Acme Corp notifications. Reply STOP to opt out.",
                OptoutKeywords = "STOP, UNSUBSCRIBE, END",
                OptoutMessage = "You have been unsubscribed. Reply START to opt back in.",
                PrivacyPolicyLink = "https://acmecorp.com/privacy",
                TermsAndConditionsLink = "https://acmecorp.com/terms",
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
        var parameters = new CampaignCreateParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
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
                MessageFlow = "User signs up on website and opts in to receive SMS notifications",
                OptinKeywords = "YES, START, SUBSCRIBE",
                OptinMessage =
                    "You have opted in to Acme Corp notifications. Reply STOP to opt out.",
                OptoutKeywords = "STOP, UNSUBSCRIBE, END",
                OptoutMessage = "You have been unsubscribed. Reply START to opt back in.",
                PrivacyPolicyLink = "https://acmecorp.com/privacy",
                TermsAndConditionsLink = "https://acmecorp.com/terms",
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
        CampaignCreateParams parameters = new()
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
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
                MessageFlow = "User signs up on website and opts in to receive SMS notifications",
                OptinKeywords = "YES, START, SUBSCRIBE",
                OptinMessage =
                    "You have opted in to Acme Corp notifications. Reply STOP to opt out.",
                OptoutKeywords = "STOP, UNSUBSCRIBE, END",
                OptoutMessage = "You have been unsubscribed. Reply START to opt back in.",
                PrivacyPolicyLink = "https://acmecorp.com/privacy",
                TermsAndConditionsLink = "https://acmecorp.com/terms",
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/brands/a1b2c3d4-e5f6-7890-abcd-ef1234567890/campaigns"),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CampaignCreateParams parameters = new()
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
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
                MessageFlow = "User signs up on website and opts in to receive SMS notifications",
                OptinKeywords = "YES, START, SUBSCRIBE",
                OptinMessage =
                    "You have opted in to Acme Corp notifications. Reply STOP to opt out.",
                OptoutKeywords = "STOP, UNSUBSCRIBE, END",
                OptoutMessage = "You have been unsubscribed. Reply START to opt back in.",
                PrivacyPolicyLink = "https://acmecorp.com/privacy",
                TermsAndConditionsLink = "https://acmecorp.com/terms",
            },
            IdempotencyKey = "req_abc123_retry1",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CampaignCreateParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
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
                MessageFlow = "User signs up on website and opts in to receive SMS notifications",
                OptinKeywords = "YES, START, SUBSCRIBE",
                OptinMessage =
                    "You have opted in to Acme Corp notifications. Reply STOP to opt out.",
                OptoutKeywords = "STOP, UNSUBSCRIBE, END",
                OptoutMessage = "You have been unsubscribed. Reply START to opt back in.",
                PrivacyPolicyLink = "https://acmecorp.com/privacy",
                TermsAndConditionsLink = "https://acmecorp.com/terms",
            },
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        CampaignCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
