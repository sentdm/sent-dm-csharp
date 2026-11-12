using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Models.Channels.Sms.TenDlc;

namespace Sentdm.Tests.Models.Channels.Sms.TenDlc;

public class TenDlcUpdateCampaignParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TenDlcUpdateCampaignParams
        {
            CampaignID = "3f2a6c1e-8b4d-4e2a-9c7f-1d5b0a9e4c21",
            Description = "description",
            HelpKeywords = "help_keywords",
            HelpMessage = "help_message",
            MessageFlow = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
            OptInKeywords = "opt_in_keywords",
            OptInMessage = "opt_in_message",
            OptOutKeywords = "opt_out_keywords",
            OptOutMessage = "opt_out_message",
            PrivacyPolicyLink = "privacy_policy_link",
            Sandbox = false,
            TermsAndConditionsLink = "terms_and_conditions_link",
            UseCases =
            [
                new()
                {
                    SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    UseCase = UseCase.Marketing,
                },
            ],
            Volume = "volume",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedCampaignID = "3f2a6c1e-8b4d-4e2a-9c7f-1d5b0a9e4c21";
        string expectedDescription = "description";
        string expectedHelpKeywords = "help_keywords";
        string expectedHelpMessage = "help_message";
        string expectedMessageFlow = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
        string expectedOptInKeywords = "opt_in_keywords";
        string expectedOptInMessage = "opt_in_message";
        string expectedOptOutKeywords = "opt_out_keywords";
        string expectedOptOutMessage = "opt_out_message";
        string expectedPrivacyPolicyLink = "privacy_policy_link";
        bool expectedSandbox = false;
        string expectedTermsAndConditionsLink = "terms_and_conditions_link";
        List<TenDlcCampaignUseCase> expectedUseCases =
        [
            new()
            {
                SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
                UseCase = UseCase.Marketing,
            },
        ];
        string expectedVolume = "volume";
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedCampaignID, parameters.CampaignID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedHelpKeywords, parameters.HelpKeywords);
        Assert.Equal(expectedHelpMessage, parameters.HelpMessage);
        Assert.Equal(expectedMessageFlow, parameters.MessageFlow);
        Assert.Equal(expectedOptInKeywords, parameters.OptInKeywords);
        Assert.Equal(expectedOptInMessage, parameters.OptInMessage);
        Assert.Equal(expectedOptOutKeywords, parameters.OptOutKeywords);
        Assert.Equal(expectedOptOutMessage, parameters.OptOutMessage);
        Assert.Equal(expectedPrivacyPolicyLink, parameters.PrivacyPolicyLink);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedTermsAndConditionsLink, parameters.TermsAndConditionsLink);
        Assert.NotNull(parameters.UseCases);
        Assert.Equal(expectedUseCases.Count, parameters.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], parameters.UseCases[i]);
        }
        Assert.Equal(expectedVolume, parameters.Volume);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TenDlcUpdateCampaignParams
        {
            CampaignID = "3f2a6c1e-8b4d-4e2a-9c7f-1d5b0a9e4c21",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.HelpKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("help_keywords"));
        Assert.Null(parameters.HelpMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("help_message"));
        Assert.Null(parameters.MessageFlow);
        Assert.False(parameters.RawBodyData.ContainsKey("message_flow"));
        Assert.Null(parameters.OptInKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("opt_in_keywords"));
        Assert.Null(parameters.OptInMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("opt_in_message"));
        Assert.Null(parameters.OptOutKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("opt_out_keywords"));
        Assert.Null(parameters.OptOutMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("opt_out_message"));
        Assert.Null(parameters.PrivacyPolicyLink);
        Assert.False(parameters.RawBodyData.ContainsKey("privacy_policy_link"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.TermsAndConditionsLink);
        Assert.False(parameters.RawBodyData.ContainsKey("terms_and_conditions_link"));
        Assert.Null(parameters.UseCases);
        Assert.False(parameters.RawBodyData.ContainsKey("use_cases"));
        Assert.Null(parameters.Volume);
        Assert.False(parameters.RawBodyData.ContainsKey("volume"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TenDlcUpdateCampaignParams
        {
            CampaignID = "3f2a6c1e-8b4d-4e2a-9c7f-1d5b0a9e4c21",

            // Null should be interpreted as omitted for these properties
            Description = null,
            HelpKeywords = null,
            HelpMessage = null,
            MessageFlow = null,
            OptInKeywords = null,
            OptInMessage = null,
            OptOutKeywords = null,
            OptOutMessage = null,
            PrivacyPolicyLink = null,
            Sandbox = null,
            TermsAndConditionsLink = null,
            UseCases = null,
            Volume = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.HelpKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("help_keywords"));
        Assert.Null(parameters.HelpMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("help_message"));
        Assert.Null(parameters.MessageFlow);
        Assert.False(parameters.RawBodyData.ContainsKey("message_flow"));
        Assert.Null(parameters.OptInKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("opt_in_keywords"));
        Assert.Null(parameters.OptInMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("opt_in_message"));
        Assert.Null(parameters.OptOutKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("opt_out_keywords"));
        Assert.Null(parameters.OptOutMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("opt_out_message"));
        Assert.Null(parameters.PrivacyPolicyLink);
        Assert.False(parameters.RawBodyData.ContainsKey("privacy_policy_link"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.TermsAndConditionsLink);
        Assert.False(parameters.RawBodyData.ContainsKey("terms_and_conditions_link"));
        Assert.Null(parameters.UseCases);
        Assert.False(parameters.RawBodyData.ContainsKey("use_cases"));
        Assert.Null(parameters.Volume);
        Assert.False(parameters.RawBodyData.ContainsKey("volume"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void Url_Works()
    {
        TenDlcUpdateCampaignParams parameters = new()
        {
            CampaignID = "3f2a6c1e-8b4d-4e2a-9c7f-1d5b0a9e4c21",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/channels/sms/compliances/US/TEN_DLC/campaigns/3f2a6c1e-8b4d-4e2a-9c7f-1d5b0a9e4c21"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TenDlcUpdateCampaignParams parameters = new()
        {
            CampaignID = "3f2a6c1e-8b4d-4e2a-9c7f-1d5b0a9e4c21",
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
        var parameters = new TenDlcUpdateCampaignParams
        {
            CampaignID = "3f2a6c1e-8b4d-4e2a-9c7f-1d5b0a9e4c21",
            Description = "description",
            HelpKeywords = "help_keywords",
            HelpMessage = "help_message",
            MessageFlow = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
            OptInKeywords = "opt_in_keywords",
            OptInMessage = "opt_in_message",
            OptOutKeywords = "opt_out_keywords",
            OptOutMessage = "opt_out_message",
            PrivacyPolicyLink = "privacy_policy_link",
            Sandbox = false,
            TermsAndConditionsLink = "terms_and_conditions_link",
            UseCases =
            [
                new()
                {
                    SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    UseCase = UseCase.Marketing,
                },
            ],
            Volume = "volume",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        TenDlcUpdateCampaignParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
