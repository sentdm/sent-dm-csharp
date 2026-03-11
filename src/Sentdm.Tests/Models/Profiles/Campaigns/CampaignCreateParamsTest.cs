using System;
using System.Net.Http;
using Sentdm.Models.Profiles.Campaigns;

namespace Sentdm.Tests.Models.Profiles.Campaigns;

public class CampaignCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CampaignCreateParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
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
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedProfileID = "770e8400-e29b-41d4-a716-446655440002";
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
        bool expectedSandbox = false;
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedProfileID, parameters.ProfileID);
        Assert.Equal(expectedCampaign, parameters.Campaign);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CampaignCreateParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
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

        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CampaignCreateParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
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
            Sandbox = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void Url_Works()
    {
        CampaignCreateParams parameters = new()
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
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
            new Uri(
                "https://api.sent.dm/v3/profiles/770e8400-e29b-41d4-a716-446655440002/campaigns"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CampaignCreateParams parameters = new()
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
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
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
        Assert.Equal(
            ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            requestMessage.Headers.GetValues("x-profile-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CampaignCreateParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
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
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        CampaignCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
