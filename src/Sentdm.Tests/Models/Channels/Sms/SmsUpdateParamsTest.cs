using System;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Models.Channels.Sms;

namespace Sentdm.Tests.Models.Channels.Sms;

public class SmsUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SmsUpdateParams
        {
            Country = "US",
            Type = "ten_dlc",
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

        string expectedCountry = "US";
        string expectedType = "ten_dlc";
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

        Assert.Equal(expectedCountry, parameters.Country);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedCompliance, parameters.Compliance);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SmsUpdateParams { Country = "US", Type = "ten_dlc" };

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
        var parameters = new SmsUpdateParams
        {
            Country = "US",
            Type = "ten_dlc",

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
        SmsUpdateParams parameters = new() { Country = "US", Type = "ten_dlc" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.sent.dm/v3/channels/sms/US/ten_dlc"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SmsUpdateParams parameters = new()
        {
            Country = "US",
            Type = "ten_dlc",
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
        var parameters = new SmsUpdateParams
        {
            Country = "US",
            Type = "ten_dlc",
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

        SmsUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
