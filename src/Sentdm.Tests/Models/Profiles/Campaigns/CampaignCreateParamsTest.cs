using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
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
        Campaign expectedCampaign = new()
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

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/profiles/770e8400-e29b-41d4-a716-446655440002/campaigns"
                ),
                url
            )
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

public class CampaignTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Campaign
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

        string expectedDescription = "Appointment reminders and account notifications";
        string expectedName = "Customer Notifications";
        string expectedType = "App";
        List<UseCase> expectedUseCases =
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
        ];
        string expectedHelpKeywords = "HELP, INFO, SUPPORT";
        string expectedHelpMessage = "Reply STOP to unsubscribe or contact support@acmecorp.com";
        string expectedMessageFlow =
            "User signs up on website and opts in to receive SMS notifications";
        string expectedOptinKeywords = "YES, START, SUBSCRIBE";
        string expectedOptinMessage =
            "You have opted in to Acme Corp notifications. Reply STOP to opt out.";
        string expectedOptoutKeywords = "STOP, UNSUBSCRIBE, END";
        string expectedOptoutMessage = "You have been unsubscribed. Reply START to opt back in.";
        string expectedPrivacyPolicyLink = "https://acmecorp.com/privacy";
        string expectedTermsAndConditionsLink = "https://acmecorp.com/terms";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUseCases.Count, model.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], model.UseCases[i]);
        }
        Assert.Equal(expectedHelpKeywords, model.HelpKeywords);
        Assert.Equal(expectedHelpMessage, model.HelpMessage);
        Assert.Equal(expectedMessageFlow, model.MessageFlow);
        Assert.Equal(expectedOptinKeywords, model.OptinKeywords);
        Assert.Equal(expectedOptinMessage, model.OptinMessage);
        Assert.Equal(expectedOptoutKeywords, model.OptoutKeywords);
        Assert.Equal(expectedOptoutMessage, model.OptoutMessage);
        Assert.Equal(expectedPrivacyPolicyLink, model.PrivacyPolicyLink);
        Assert.Equal(expectedTermsAndConditionsLink, model.TermsAndConditionsLink);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Campaign
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Campaign>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Campaign
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Campaign>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "Appointment reminders and account notifications";
        string expectedName = "Customer Notifications";
        string expectedType = "App";
        List<UseCase> expectedUseCases =
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
        ];
        string expectedHelpKeywords = "HELP, INFO, SUPPORT";
        string expectedHelpMessage = "Reply STOP to unsubscribe or contact support@acmecorp.com";
        string expectedMessageFlow =
            "User signs up on website and opts in to receive SMS notifications";
        string expectedOptinKeywords = "YES, START, SUBSCRIBE";
        string expectedOptinMessage =
            "You have opted in to Acme Corp notifications. Reply STOP to opt out.";
        string expectedOptoutKeywords = "STOP, UNSUBSCRIBE, END";
        string expectedOptoutMessage = "You have been unsubscribed. Reply START to opt back in.";
        string expectedPrivacyPolicyLink = "https://acmecorp.com/privacy";
        string expectedTermsAndConditionsLink = "https://acmecorp.com/terms";

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUseCases.Count, deserialized.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], deserialized.UseCases[i]);
        }
        Assert.Equal(expectedHelpKeywords, deserialized.HelpKeywords);
        Assert.Equal(expectedHelpMessage, deserialized.HelpMessage);
        Assert.Equal(expectedMessageFlow, deserialized.MessageFlow);
        Assert.Equal(expectedOptinKeywords, deserialized.OptinKeywords);
        Assert.Equal(expectedOptinMessage, deserialized.OptinMessage);
        Assert.Equal(expectedOptoutKeywords, deserialized.OptoutKeywords);
        Assert.Equal(expectedOptoutMessage, deserialized.OptoutMessage);
        Assert.Equal(expectedPrivacyPolicyLink, deserialized.PrivacyPolicyLink);
        Assert.Equal(expectedTermsAndConditionsLink, deserialized.TermsAndConditionsLink);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Campaign
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Campaign
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
        };

        Assert.Null(model.HelpKeywords);
        Assert.False(model.RawData.ContainsKey("helpKeywords"));
        Assert.Null(model.HelpMessage);
        Assert.False(model.RawData.ContainsKey("helpMessage"));
        Assert.Null(model.MessageFlow);
        Assert.False(model.RawData.ContainsKey("messageFlow"));
        Assert.Null(model.OptinKeywords);
        Assert.False(model.RawData.ContainsKey("optinKeywords"));
        Assert.Null(model.OptinMessage);
        Assert.False(model.RawData.ContainsKey("optinMessage"));
        Assert.Null(model.OptoutKeywords);
        Assert.False(model.RawData.ContainsKey("optoutKeywords"));
        Assert.Null(model.OptoutMessage);
        Assert.False(model.RawData.ContainsKey("optoutMessage"));
        Assert.Null(model.PrivacyPolicyLink);
        Assert.False(model.RawData.ContainsKey("privacyPolicyLink"));
        Assert.Null(model.TermsAndConditionsLink);
        Assert.False(model.RawData.ContainsKey("termsAndConditionsLink"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Campaign
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Campaign
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

            HelpKeywords = null,
            HelpMessage = null,
            MessageFlow = null,
            OptinKeywords = null,
            OptinMessage = null,
            OptoutKeywords = null,
            OptoutMessage = null,
            PrivacyPolicyLink = null,
            TermsAndConditionsLink = null,
        };

        Assert.Null(model.HelpKeywords);
        Assert.True(model.RawData.ContainsKey("helpKeywords"));
        Assert.Null(model.HelpMessage);
        Assert.True(model.RawData.ContainsKey("helpMessage"));
        Assert.Null(model.MessageFlow);
        Assert.True(model.RawData.ContainsKey("messageFlow"));
        Assert.Null(model.OptinKeywords);
        Assert.True(model.RawData.ContainsKey("optinKeywords"));
        Assert.Null(model.OptinMessage);
        Assert.True(model.RawData.ContainsKey("optinMessage"));
        Assert.Null(model.OptoutKeywords);
        Assert.True(model.RawData.ContainsKey("optoutKeywords"));
        Assert.Null(model.OptoutMessage);
        Assert.True(model.RawData.ContainsKey("optoutMessage"));
        Assert.Null(model.PrivacyPolicyLink);
        Assert.True(model.RawData.ContainsKey("privacyPolicyLink"));
        Assert.Null(model.TermsAndConditionsLink);
        Assert.True(model.RawData.ContainsKey("termsAndConditionsLink"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Campaign
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

            HelpKeywords = null,
            HelpMessage = null,
            MessageFlow = null,
            OptinKeywords = null,
            OptinMessage = null,
            OptoutKeywords = null,
            OptoutMessage = null,
            PrivacyPolicyLink = null,
            TermsAndConditionsLink = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Campaign
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

        Campaign copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UseCaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UseCase
        {
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        ApiEnum<string, MessagingUseCaseUs> expectedMessagingUseCaseUs =
            MessagingUseCaseUs.Marketing;
        List<string> expectedSampleMessages = ["string"];

        Assert.Equal(expectedMessagingUseCaseUs, model.MessagingUseCaseUs);
        Assert.Equal(expectedSampleMessages.Count, model.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], model.SampleMessages[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UseCase
        {
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UseCase>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UseCase
        {
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UseCase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, MessagingUseCaseUs> expectedMessagingUseCaseUs =
            MessagingUseCaseUs.Marketing;
        List<string> expectedSampleMessages = ["string"];

        Assert.Equal(expectedMessagingUseCaseUs, deserialized.MessagingUseCaseUs);
        Assert.Equal(expectedSampleMessages.Count, deserialized.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], deserialized.SampleMessages[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UseCase
        {
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UseCase
        {
            MessagingUseCaseUs = MessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        UseCase copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MessagingUseCaseUsTest : TestBase
{
    [Theory]
    [InlineData(MessagingUseCaseUs.Marketing)]
    [InlineData(MessagingUseCaseUs.AccountNotification)]
    [InlineData(MessagingUseCaseUs.CustomerCare)]
    [InlineData(MessagingUseCaseUs.FraudAlert)]
    [InlineData(MessagingUseCaseUs.TwoFa)]
    [InlineData(MessagingUseCaseUs.DeliveryNotification)]
    [InlineData(MessagingUseCaseUs.SecurityAlert)]
    [InlineData(MessagingUseCaseUs.M2M)]
    [InlineData(MessagingUseCaseUs.Mixed)]
    [InlineData(MessagingUseCaseUs.HigherEducation)]
    [InlineData(MessagingUseCaseUs.PollingVoting)]
    [InlineData(MessagingUseCaseUs.PublicServiceAnnouncement)]
    [InlineData(MessagingUseCaseUs.LowVolume)]
    public void Validation_Works(MessagingUseCaseUs rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessagingUseCaseUs> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessagingUseCaseUs>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MessagingUseCaseUs.Marketing)]
    [InlineData(MessagingUseCaseUs.AccountNotification)]
    [InlineData(MessagingUseCaseUs.CustomerCare)]
    [InlineData(MessagingUseCaseUs.FraudAlert)]
    [InlineData(MessagingUseCaseUs.TwoFa)]
    [InlineData(MessagingUseCaseUs.DeliveryNotification)]
    [InlineData(MessagingUseCaseUs.SecurityAlert)]
    [InlineData(MessagingUseCaseUs.M2M)]
    [InlineData(MessagingUseCaseUs.Mixed)]
    [InlineData(MessagingUseCaseUs.HigherEducation)]
    [InlineData(MessagingUseCaseUs.PollingVoting)]
    [InlineData(MessagingUseCaseUs.PublicServiceAnnouncement)]
    [InlineData(MessagingUseCaseUs.LowVolume)]
    public void SerializationRoundtrip_Works(MessagingUseCaseUs rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessagingUseCaseUs> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessagingUseCaseUs>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessagingUseCaseUs>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessagingUseCaseUs>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
