using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Channels.Sms.TenDlc;

namespace Sentdm.Tests.Models.Channels.Sms.TenDlc;

public class TenDlcAddCampaignParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TenDlcAddCampaignParams
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
                    UseCaseValue = UseCaseUseCase.AccountNotification,
                },
            ],
            Volume = "volume",
            IdempotencyKey = "req_abc123_retry1",
            Sandbox = false,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedDescription =
            "Appointment reminders for patients who opted in when booking.";
        string expectedHelpKeywords = "help_keywords";
        string expectedHelpMessage = "xxxxxxxxxxxxxxxxxxxx";
        string expectedMessageFlow =
            "Patients opt in on the booking form by checking a consent box.";
        string expectedOptInKeywords = "opt_in_keywords";
        string expectedOptInMessage = "xxxxxxxxxxxxxxxxxxxx";
        string expectedOptOutKeywords = "opt_out_keywords";
        string expectedOptOutMessage = "xxxxxxxxxxxxxxxxxxxx";
        string expectedPrivacyPolicyLink = "privacy_policy_link";
        string expectedTermsAndConditionsLink = "terms_and_conditions_link";
        List<UseCase> expectedUseCases =
        [
            new()
            {
                SampleMessages =
                [
                    JsonSerializer.SerializeToElement(
                        "Reminder: your appointment is tomorrow at 10:00. Reply STOP to opt out."
                    ),
                ],
                UseCaseValue = UseCaseUseCase.AccountNotification,
            },
        ];
        string expectedVolume = "volume";
        string expectedIdempotencyKey = "req_abc123_retry1";
        bool expectedSandbox = false;
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedHelpKeywords, parameters.HelpKeywords);
        Assert.Equal(expectedHelpMessage, parameters.HelpMessage);
        Assert.Equal(expectedMessageFlow, parameters.MessageFlow);
        Assert.Equal(expectedOptInKeywords, parameters.OptInKeywords);
        Assert.Equal(expectedOptInMessage, parameters.OptInMessage);
        Assert.Equal(expectedOptOutKeywords, parameters.OptOutKeywords);
        Assert.Equal(expectedOptOutMessage, parameters.OptOutMessage);
        Assert.Equal(expectedPrivacyPolicyLink, parameters.PrivacyPolicyLink);
        Assert.Equal(expectedTermsAndConditionsLink, parameters.TermsAndConditionsLink);
        Assert.Equal(expectedUseCases.Count, parameters.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], parameters.UseCases[i]);
        }
        Assert.Equal(expectedVolume, parameters.Volume);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TenDlcAddCampaignParams
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
                    UseCaseValue = UseCaseUseCase.AccountNotification,
                },
            ],
            Volume = "volume",
            IdempotencyKey = "req_abc123_retry1",
        };

        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TenDlcAddCampaignParams
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
                    UseCaseValue = UseCaseUseCase.AccountNotification,
                },
            ],
            Volume = "volume",
            IdempotencyKey = "req_abc123_retry1",

            // Null should be interpreted as omitted for these properties
            Sandbox = null,
            XProfileID = null,
        };

        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void Url_Works()
    {
        TenDlcAddCampaignParams parameters = new()
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
                    UseCaseValue = UseCaseUseCase.AccountNotification,
                },
            ],
            Volume = "volume",
            IdempotencyKey = "req_abc123_retry1",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.sent.dm/v3/channels/sms/US/TEN_DLC/campaigns"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TenDlcAddCampaignParams parameters = new()
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
                    UseCaseValue = UseCaseUseCase.AccountNotification,
                },
            ],
            Volume = "volume",
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
        var parameters = new TenDlcAddCampaignParams
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
                    UseCaseValue = UseCaseUseCase.AccountNotification,
                },
            ],
            Volume = "volume",
            IdempotencyKey = "req_abc123_retry1",
            Sandbox = false,
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        TenDlcAddCampaignParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class UseCaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UseCase
        {
            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
            UseCaseValue = UseCaseUseCase.Marketing,
        };

        List<JsonElement> expectedSampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")];
        ApiEnum<string, UseCaseUseCase> expectedUseCaseValue = UseCaseUseCase.Marketing;

        Assert.Equal(expectedSampleMessages.Count, model.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSampleMessages[i], model.SampleMessages[i]));
        }
        Assert.Equal(expectedUseCaseValue, model.UseCaseValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UseCase
        {
            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
            UseCaseValue = UseCaseUseCase.Marketing,
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
            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
            UseCaseValue = UseCaseUseCase.Marketing,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UseCase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<JsonElement> expectedSampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")];
        ApiEnum<string, UseCaseUseCase> expectedUseCaseValue = UseCaseUseCase.Marketing;

        Assert.Equal(expectedSampleMessages.Count, deserialized.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.True(
                JsonElement.DeepEquals(expectedSampleMessages[i], deserialized.SampleMessages[i])
            );
        }
        Assert.Equal(expectedUseCaseValue, deserialized.UseCaseValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UseCase
        {
            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
            UseCaseValue = UseCaseUseCase.Marketing,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UseCase
        {
            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
            UseCaseValue = UseCaseUseCase.Marketing,
        };

        UseCase copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UseCaseUseCaseTest : TestBase
{
    [Theory]
    [InlineData(UseCaseUseCase.Marketing)]
    [InlineData(UseCaseUseCase.AccountNotification)]
    [InlineData(UseCaseUseCase.CustomerCare)]
    [InlineData(UseCaseUseCase.FraudAlert)]
    [InlineData(UseCaseUseCase.V2Fa)]
    [InlineData(UseCaseUseCase.DeliveryNotification)]
    [InlineData(UseCaseUseCase.SecurityAlert)]
    [InlineData(UseCaseUseCase.M2M)]
    [InlineData(UseCaseUseCase.HigherEducation)]
    [InlineData(UseCaseUseCase.PollingVoting)]
    [InlineData(UseCaseUseCase.PublicServiceAnnouncement)]
    public void Validation_Works(UseCaseUseCase rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UseCaseUseCase> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UseCaseUseCase>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UseCaseUseCase.Marketing)]
    [InlineData(UseCaseUseCase.AccountNotification)]
    [InlineData(UseCaseUseCase.CustomerCare)]
    [InlineData(UseCaseUseCase.FraudAlert)]
    [InlineData(UseCaseUseCase.V2Fa)]
    [InlineData(UseCaseUseCase.DeliveryNotification)]
    [InlineData(UseCaseUseCase.SecurityAlert)]
    [InlineData(UseCaseUseCase.M2M)]
    [InlineData(UseCaseUseCase.HigherEducation)]
    [InlineData(UseCaseUseCase.PollingVoting)]
    [InlineData(UseCaseUseCase.PublicServiceAnnouncement)]
    public void SerializationRoundtrip_Works(UseCaseUseCase rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UseCaseUseCase> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UseCaseUseCase>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UseCaseUseCase>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UseCaseUseCase>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
