using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
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
                    UseCase = UseCase.AccountNotification,
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
        List<TenDlcCampaignUseCase> expectedUseCases =
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
                    UseCase = UseCase.AccountNotification,
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
                    UseCase = UseCase.AccountNotification,
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
                    UseCase = UseCase.AccountNotification,
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
                    UseCase = UseCase.AccountNotification,
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
                    UseCase = UseCase.AccountNotification,
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
