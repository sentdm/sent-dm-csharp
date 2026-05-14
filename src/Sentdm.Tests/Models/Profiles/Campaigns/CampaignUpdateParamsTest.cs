using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Profiles.Campaigns;

namespace Sentdm.Tests.Models.Profiles.Campaigns;

public class CampaignUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CampaignUpdateParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
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
                        MessagingUseCaseUs =
                            CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedProfileID = "770e8400-e29b-41d4-a716-446655440002";
        string expectedCampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901";
        CampaignUpdateParamsCampaign expectedCampaign = new()
        {
            Description = "Updated appointment reminders and account notifications",
            Name = "Customer Notifications Updated",
            Type = "App",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs =
                        CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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
        bool expectedSandbox = false;
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedProfileID, parameters.ProfileID);
        Assert.Equal(expectedCampaignID, parameters.CampaignID);
        Assert.Equal(expectedCampaign, parameters.Campaign);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CampaignUpdateParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
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
                        MessagingUseCaseUs =
                            CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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
        var parameters = new CampaignUpdateParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
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
                        MessagingUseCaseUs =
                            CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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
        CampaignUpdateParams parameters = new()
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
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
                        MessagingUseCaseUs =
                            CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/profiles/770e8400-e29b-41d4-a716-446655440002/campaigns/b2c3d4e5-f6a7-8901-bcde-f12345678901"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CampaignUpdateParams parameters = new()
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
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
                        MessagingUseCaseUs =
                            CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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
        var parameters = new CampaignUpdateParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
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
                        MessagingUseCaseUs =
                            CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        CampaignUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CampaignUpdateParamsCampaignTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CampaignUpdateParamsCampaign
        {
            Description = "Updated appointment reminders and account notifications",
            Name = "Customer Notifications Updated",
            Type = "App",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs =
                        CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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

        string expectedDescription = "Updated appointment reminders and account notifications";
        string expectedName = "Customer Notifications Updated";
        string expectedType = "App";
        List<CampaignUpdateParamsCampaignUseCase> expectedUseCases =
        [
            new()
            {
                MessagingUseCaseUs =
                    CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
                SampleMessages =
                [
                    "Hi {name}, your appointment is confirmed for {date} at {time}.",
                    "Your order #{order_id} has been shipped. Track at {url}",
                ],
            },
        ];
        string expectedMessageFlow =
            "User signs up on website and opts in to receive SMS notifications";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUseCases.Count, model.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], model.UseCases[i]);
        }
        Assert.Null(model.HelpKeywords);
        Assert.Null(model.HelpMessage);
        Assert.Equal(expectedMessageFlow, model.MessageFlow);
        Assert.Null(model.OptinKeywords);
        Assert.Null(model.OptinMessage);
        Assert.Null(model.OptoutKeywords);
        Assert.Null(model.OptoutMessage);
        Assert.Null(model.PrivacyPolicyLink);
        Assert.Null(model.TermsAndConditionsLink);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CampaignUpdateParamsCampaign
        {
            Description = "Updated appointment reminders and account notifications",
            Name = "Customer Notifications Updated",
            Type = "App",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs =
                        CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignUpdateParamsCampaign>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CampaignUpdateParamsCampaign
        {
            Description = "Updated appointment reminders and account notifications",
            Name = "Customer Notifications Updated",
            Type = "App",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs =
                        CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignUpdateParamsCampaign>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "Updated appointment reminders and account notifications";
        string expectedName = "Customer Notifications Updated";
        string expectedType = "App";
        List<CampaignUpdateParamsCampaignUseCase> expectedUseCases =
        [
            new()
            {
                MessagingUseCaseUs =
                    CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
                SampleMessages =
                [
                    "Hi {name}, your appointment is confirmed for {date} at {time}.",
                    "Your order #{order_id} has been shipped. Track at {url}",
                ],
            },
        ];
        string expectedMessageFlow =
            "User signs up on website and opts in to receive SMS notifications";

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUseCases.Count, deserialized.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], deserialized.UseCases[i]);
        }
        Assert.Null(deserialized.HelpKeywords);
        Assert.Null(deserialized.HelpMessage);
        Assert.Equal(expectedMessageFlow, deserialized.MessageFlow);
        Assert.Null(deserialized.OptinKeywords);
        Assert.Null(deserialized.OptinMessage);
        Assert.Null(deserialized.OptoutKeywords);
        Assert.Null(deserialized.OptoutMessage);
        Assert.Null(deserialized.PrivacyPolicyLink);
        Assert.Null(deserialized.TermsAndConditionsLink);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CampaignUpdateParamsCampaign
        {
            Description = "Updated appointment reminders and account notifications",
            Name = "Customer Notifications Updated",
            Type = "App",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs =
                        CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CampaignUpdateParamsCampaign
        {
            Description = "Updated appointment reminders and account notifications",
            Name = "Customer Notifications Updated",
            Type = "App",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs =
                        CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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
        var model = new CampaignUpdateParamsCampaign
        {
            Description = "Updated appointment reminders and account notifications",
            Name = "Customer Notifications Updated",
            Type = "App",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs =
                        CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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
        var model = new CampaignUpdateParamsCampaign
        {
            Description = "Updated appointment reminders and account notifications",
            Name = "Customer Notifications Updated",
            Type = "App",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs =
                        CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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
        var model = new CampaignUpdateParamsCampaign
        {
            Description = "Updated appointment reminders and account notifications",
            Name = "Customer Notifications Updated",
            Type = "App",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs =
                        CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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
        var model = new CampaignUpdateParamsCampaign
        {
            Description = "Updated appointment reminders and account notifications",
            Name = "Customer Notifications Updated",
            Type = "App",
            UseCases =
            [
                new()
                {
                    MessagingUseCaseUs =
                        CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification,
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

        CampaignUpdateParamsCampaign copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CampaignUpdateParamsCampaignUseCaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CampaignUpdateParamsCampaignUseCase
        {
            MessagingUseCaseUs = CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        ApiEnum<
            string,
            CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs
        > expectedMessagingUseCaseUs =
            CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.Marketing;
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
        var model = new CampaignUpdateParamsCampaignUseCase
        {
            MessagingUseCaseUs = CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignUpdateParamsCampaignUseCase>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CampaignUpdateParamsCampaignUseCase
        {
            MessagingUseCaseUs = CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignUpdateParamsCampaignUseCase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs
        > expectedMessagingUseCaseUs =
            CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.Marketing;
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
        var model = new CampaignUpdateParamsCampaignUseCase
        {
            MessagingUseCaseUs = CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CampaignUpdateParamsCampaignUseCase
        {
            MessagingUseCaseUs = CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.Marketing,
            SampleMessages = ["string"],
        };

        CampaignUpdateParamsCampaignUseCase copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUsTest : TestBase
{
    [Theory]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.Marketing)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.CustomerCare)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.FraudAlert)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.TwoFa)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.DeliveryNotification)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.SecurityAlert)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.M2M)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.Mixed)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.HigherEducation)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.PollingVoting)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.PublicServiceAnnouncement)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.LowVolume)]
    public void Validation_Works(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.Marketing)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.AccountNotification)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.CustomerCare)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.FraudAlert)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.TwoFa)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.DeliveryNotification)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.SecurityAlert)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.M2M)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.Mixed)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.HigherEducation)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.PollingVoting)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.PublicServiceAnnouncement)]
    [InlineData(CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs.LowVolume)]
    public void SerializationRoundtrip_Works(
        CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
