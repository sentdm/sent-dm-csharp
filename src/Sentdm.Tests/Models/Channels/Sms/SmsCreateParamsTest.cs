using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Channels.Sms;

namespace Sentdm.Tests.Models.Channels.Sms;

public class SmsCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SmsCreateParams
        {
            NumberType = NumberType.TenDlc,
            AreaCodes = ["415", "628"],
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
            Country = "US",
            Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
            Sandbox = false,
            SenderValue = null,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ApiEnum<string, NumberType> expectedNumberType = NumberType.TenDlc;
        List<string> expectedAreaCodes = ["415", "628"];
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
        string expectedCountry = "US";
        List<SmsNumberRequest> expectedNumbers = [new() { AreaCode = "area_code", Quantity = 0 }];
        bool expectedSandbox = false;
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedNumberType, parameters.NumberType);
        Assert.NotNull(parameters.AreaCodes);
        Assert.Equal(expectedAreaCodes.Count, parameters.AreaCodes.Count);
        for (int i = 0; i < expectedAreaCodes.Count; i++)
        {
            Assert.Equal(expectedAreaCodes[i], parameters.AreaCodes[i]);
        }
        Assert.Equal(expectedCompliance, parameters.Compliance);
        Assert.Equal(expectedCountry, parameters.Country);
        Assert.NotNull(parameters.Numbers);
        Assert.Equal(expectedNumbers.Count, parameters.Numbers.Count);
        for (int i = 0; i < expectedNumbers.Count; i++)
        {
            Assert.Equal(expectedNumbers[i], parameters.Numbers[i]);
        }
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Null(parameters.SenderValue);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SmsCreateParams
        {
            NumberType = NumberType.TenDlc,
            AreaCodes = ["415", "628"],
            Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
            SenderValue = null,
        };

        Assert.Null(parameters.Compliance);
        Assert.False(parameters.RawBodyData.ContainsKey("compliance"));
        Assert.Null(parameters.Country);
        Assert.False(parameters.RawBodyData.ContainsKey("country"));
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
        var parameters = new SmsCreateParams
        {
            NumberType = NumberType.TenDlc,
            AreaCodes = ["415", "628"],
            Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
            SenderValue = null,

            // Null should be interpreted as omitted for these properties
            Compliance = null,
            Country = null,
            Sandbox = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.Compliance);
        Assert.False(parameters.RawBodyData.ContainsKey("compliance"));
        Assert.Null(parameters.Country);
        Assert.False(parameters.RawBodyData.ContainsKey("country"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SmsCreateParams
        {
            NumberType = NumberType.TenDlc,
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
            Country = "US",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.AreaCodes);
        Assert.False(parameters.RawBodyData.ContainsKey("area_codes"));
        Assert.Null(parameters.Numbers);
        Assert.False(parameters.RawBodyData.ContainsKey("numbers"));
        Assert.Null(parameters.SenderValue);
        Assert.False(parameters.RawBodyData.ContainsKey("sender_value"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SmsCreateParams
        {
            NumberType = NumberType.TenDlc,
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
            Country = "US",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            AreaCodes = null,
            Numbers = null,
            SenderValue = null,
        };

        Assert.Null(parameters.AreaCodes);
        Assert.True(parameters.RawBodyData.ContainsKey("area_codes"));
        Assert.Null(parameters.Numbers);
        Assert.True(parameters.RawBodyData.ContainsKey("numbers"));
        Assert.Null(parameters.SenderValue);
        Assert.True(parameters.RawBodyData.ContainsKey("sender_value"));
    }

    [Fact]
    public void Url_Works()
    {
        SmsCreateParams parameters = new() { NumberType = NumberType.TenDlc };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.sent.dm/v3/channels/sms"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SmsCreateParams parameters = new()
        {
            NumberType = NumberType.TenDlc,
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
        var parameters = new SmsCreateParams
        {
            NumberType = NumberType.TenDlc,
            AreaCodes = ["415", "628"],
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
            Country = "US",
            Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
            Sandbox = false,
            SenderValue = null,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        SmsCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class NumberTypeTest : TestBase
{
    [Theory]
    [InlineData(NumberType.Local)]
    [InlineData(NumberType.TollFree)]
    [InlineData(NumberType.ShortCode)]
    [InlineData(NumberType.Alphanumeric)]
    [InlineData(NumberType.TenDlc)]
    [InlineData(NumberType.Mobile)]
    [InlineData(NumberType.V10Dlc)]
    public void Validation_Works(NumberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NumberType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NumberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NumberType.Local)]
    [InlineData(NumberType.TollFree)]
    [InlineData(NumberType.ShortCode)]
    [InlineData(NumberType.Alphanumeric)]
    [InlineData(NumberType.TenDlc)]
    [InlineData(NumberType.Mobile)]
    [InlineData(NumberType.V10Dlc)]
    public void SerializationRoundtrip_Works(NumberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NumberType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NumberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NumberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NumberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
