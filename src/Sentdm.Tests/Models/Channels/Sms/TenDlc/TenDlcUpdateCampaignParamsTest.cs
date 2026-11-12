using System;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Models.Channels.Sms;
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
            Compliance = new()
            {
                Brand = new()
                {
                    BusinessName = "business_name",
                    City = "city",
                    ContactEmail = "dev@stainless.com",
                    ContactName = "contact_name",
                    ContactPhone = "contact_phone",
                    Country = "country",
                    EinIssuingCountry = "ein_issuing_country",
                    EntityType = EntityType.PrivateProfit,
                    Inherit = true,
                    LegalName = "legal_name",
                    PostalCode = "postal_code",
                    State = "state",
                    Street = "street",
                    TaxID = "tax_id",
                    TaxIDType = "tax_id_type",
                    Website = "website",
                },
                Campaign = new()
                {
                    Description = "description",
                    HelpKeywords = "help_keywords",
                    HelpMessage = "help_message",
                    Inherit = true,
                    MessageFlow = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    OptInKeywords = "opt_in_keywords",
                    OptInMessage = "opt_in_message",
                    OptOutKeywords = "opt_out_keywords",
                    OptOutMessage = "opt_out_message",
                    PrivacyPolicyLink = "privacy_policy_link",
                    TermsAndConditionsLink = "terms_and_conditions_link",
                    UseCases =
                    [
                        new()
                        {
                            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
                            UseCaseValue = UseCaseUseCase.Marketing,
                        },
                    ],
                    Volume = "volume",
                },
            },
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedCampaignID = "3f2a6c1e-8b4d-4e2a-9c7f-1d5b0a9e4c21";
        MarketCompliance expectedCompliance = new()
        {
            Brand = new()
            {
                BusinessName = "business_name",
                City = "city",
                ContactEmail = "dev@stainless.com",
                ContactName = "contact_name",
                ContactPhone = "contact_phone",
                Country = "country",
                EinIssuingCountry = "ein_issuing_country",
                EntityType = EntityType.PrivateProfit,
                Inherit = true,
                LegalName = "legal_name",
                PostalCode = "postal_code",
                State = "state",
                Street = "street",
                TaxID = "tax_id",
                TaxIDType = "tax_id_type",
                Website = "website",
            },
            Campaign = new()
            {
                Description = "description",
                HelpKeywords = "help_keywords",
                HelpMessage = "help_message",
                Inherit = true,
                MessageFlow = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                OptInKeywords = "opt_in_keywords",
                OptInMessage = "opt_in_message",
                OptOutKeywords = "opt_out_keywords",
                OptOutMessage = "opt_out_message",
                PrivacyPolicyLink = "privacy_policy_link",
                TermsAndConditionsLink = "terms_and_conditions_link",
                UseCases =
                [
                    new()
                    {
                        SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
                        UseCaseValue = UseCaseUseCase.Marketing,
                    },
                ],
                Volume = "volume",
            },
        };
        bool expectedSandbox = false;
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedCampaignID, parameters.CampaignID);
        Assert.Equal(expectedCompliance, parameters.Compliance);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
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

        Assert.Null(parameters.Compliance);
        Assert.False(parameters.RawBodyData.ContainsKey("compliance"));
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
        var parameters = new TenDlcUpdateCampaignParams
        {
            CampaignID = "3f2a6c1e-8b4d-4e2a-9c7f-1d5b0a9e4c21",

            // Null should be interpreted as omitted for these properties
            Compliance = null,
            Sandbox = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.Compliance);
        Assert.False(parameters.RawBodyData.ContainsKey("compliance"));
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
            Compliance = new()
            {
                Brand = new()
                {
                    BusinessName = "business_name",
                    City = "city",
                    ContactEmail = "dev@stainless.com",
                    ContactName = "contact_name",
                    ContactPhone = "contact_phone",
                    Country = "country",
                    EinIssuingCountry = "ein_issuing_country",
                    EntityType = EntityType.PrivateProfit,
                    Inherit = true,
                    LegalName = "legal_name",
                    PostalCode = "postal_code",
                    State = "state",
                    Street = "street",
                    TaxID = "tax_id",
                    TaxIDType = "tax_id_type",
                    Website = "website",
                },
                Campaign = new()
                {
                    Description = "description",
                    HelpKeywords = "help_keywords",
                    HelpMessage = "help_message",
                    Inherit = true,
                    MessageFlow = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    OptInKeywords = "opt_in_keywords",
                    OptInMessage = "opt_in_message",
                    OptOutKeywords = "opt_out_keywords",
                    OptOutMessage = "opt_out_message",
                    PrivacyPolicyLink = "privacy_policy_link",
                    TermsAndConditionsLink = "terms_and_conditions_link",
                    UseCases =
                    [
                        new()
                        {
                            SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
                            UseCaseValue = UseCaseUseCase.Marketing,
                        },
                    ],
                    Volume = "volume",
                },
            },
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        TenDlcUpdateCampaignParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
