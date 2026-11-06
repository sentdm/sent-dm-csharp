using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Channels.Sms;

namespace Sentdm.Tests.Models.Channels.Sms;

public class MarketComplianceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MarketCompliance
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

        Brand expectedBrand = new()
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
        };
        Campaign expectedCampaign = new()
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
        };

        Assert.Equal(expectedBrand, model.Brand);
        Assert.Equal(expectedCampaign, model.Campaign);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MarketCompliance
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MarketCompliance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MarketCompliance
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MarketCompliance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Brand expectedBrand = new()
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
        };
        Campaign expectedCampaign = new()
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
        };

        Assert.Equal(expectedBrand, deserialized.Brand);
        Assert.Equal(expectedCampaign, deserialized.Campaign);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MarketCompliance
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MarketCompliance { };

        Assert.Null(model.Brand);
        Assert.False(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Campaign);
        Assert.False(model.RawData.ContainsKey("campaign"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MarketCompliance { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MarketCompliance
        {
            // Null should be interpreted as omitted for these properties
            Brand = null,
            Campaign = null,
        };

        Assert.Null(model.Brand);
        Assert.False(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Campaign);
        Assert.False(model.RawData.ContainsKey("campaign"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MarketCompliance
        {
            // Null should be interpreted as omitted for these properties
            Brand = null,
            Campaign = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MarketCompliance
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

        MarketCompliance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BrandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Brand
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
        };

        string expectedBusinessName = "business_name";
        string expectedCity = "city";
        string expectedContactEmail = "dev@stainless.com";
        string expectedContactName = "contact_name";
        string expectedContactPhone = "contact_phone";
        string expectedCountry = "country";
        string expectedEinIssuingCountry = "ein_issuing_country";
        ApiEnum<string, EntityType> expectedEntityType = EntityType.PrivateProfit;
        bool expectedInherit = true;
        string expectedLegalName = "legal_name";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";
        string expectedStreet = "street";
        string expectedTaxID = "tax_id";
        string expectedTaxIDType = "tax_id_type";
        string expectedWebsite = "website";

        Assert.Equal(expectedBusinessName, model.BusinessName);
        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedContactEmail, model.ContactEmail);
        Assert.Equal(expectedContactName, model.ContactName);
        Assert.Equal(expectedContactPhone, model.ContactPhone);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedEinIssuingCountry, model.EinIssuingCountry);
        Assert.Equal(expectedEntityType, model.EntityType);
        Assert.Equal(expectedInherit, model.Inherit);
        Assert.Equal(expectedLegalName, model.LegalName);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStreet, model.Street);
        Assert.Equal(expectedTaxID, model.TaxID);
        Assert.Equal(expectedTaxIDType, model.TaxIDType);
        Assert.Equal(expectedWebsite, model.Website);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Brand
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Brand>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Brand
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Brand>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedBusinessName = "business_name";
        string expectedCity = "city";
        string expectedContactEmail = "dev@stainless.com";
        string expectedContactName = "contact_name";
        string expectedContactPhone = "contact_phone";
        string expectedCountry = "country";
        string expectedEinIssuingCountry = "ein_issuing_country";
        ApiEnum<string, EntityType> expectedEntityType = EntityType.PrivateProfit;
        bool expectedInherit = true;
        string expectedLegalName = "legal_name";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";
        string expectedStreet = "street";
        string expectedTaxID = "tax_id";
        string expectedTaxIDType = "tax_id_type";
        string expectedWebsite = "website";

        Assert.Equal(expectedBusinessName, deserialized.BusinessName);
        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedContactEmail, deserialized.ContactEmail);
        Assert.Equal(expectedContactName, deserialized.ContactName);
        Assert.Equal(expectedContactPhone, deserialized.ContactPhone);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedEinIssuingCountry, deserialized.EinIssuingCountry);
        Assert.Equal(expectedEntityType, deserialized.EntityType);
        Assert.Equal(expectedInherit, deserialized.Inherit);
        Assert.Equal(expectedLegalName, deserialized.LegalName);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStreet, deserialized.Street);
        Assert.Equal(expectedTaxID, deserialized.TaxID);
        Assert.Equal(expectedTaxIDType, deserialized.TaxIDType);
        Assert.Equal(expectedWebsite, deserialized.Website);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Brand
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Brand { };

        Assert.Null(model.BusinessName);
        Assert.False(model.RawData.ContainsKey("business_name"));
        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.ContactEmail);
        Assert.False(model.RawData.ContainsKey("contact_email"));
        Assert.Null(model.ContactName);
        Assert.False(model.RawData.ContainsKey("contact_name"));
        Assert.Null(model.ContactPhone);
        Assert.False(model.RawData.ContainsKey("contact_phone"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.EinIssuingCountry);
        Assert.False(model.RawData.ContainsKey("ein_issuing_country"));
        Assert.Null(model.EntityType);
        Assert.False(model.RawData.ContainsKey("entity_type"));
        Assert.Null(model.Inherit);
        Assert.False(model.RawData.ContainsKey("inherit"));
        Assert.Null(model.LegalName);
        Assert.False(model.RawData.ContainsKey("legal_name"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postal_code"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.False(model.RawData.ContainsKey("street"));
        Assert.Null(model.TaxID);
        Assert.False(model.RawData.ContainsKey("tax_id"));
        Assert.Null(model.TaxIDType);
        Assert.False(model.RawData.ContainsKey("tax_id_type"));
        Assert.Null(model.Website);
        Assert.False(model.RawData.ContainsKey("website"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Brand { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Brand
        {
            // Null should be interpreted as omitted for these properties
            BusinessName = null,
            City = null,
            ContactEmail = null,
            ContactName = null,
            ContactPhone = null,
            Country = null,
            EinIssuingCountry = null,
            EntityType = null,
            Inherit = null,
            LegalName = null,
            PostalCode = null,
            State = null,
            Street = null,
            TaxID = null,
            TaxIDType = null,
            Website = null,
        };

        Assert.Null(model.BusinessName);
        Assert.False(model.RawData.ContainsKey("business_name"));
        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.ContactEmail);
        Assert.False(model.RawData.ContainsKey("contact_email"));
        Assert.Null(model.ContactName);
        Assert.False(model.RawData.ContainsKey("contact_name"));
        Assert.Null(model.ContactPhone);
        Assert.False(model.RawData.ContainsKey("contact_phone"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.EinIssuingCountry);
        Assert.False(model.RawData.ContainsKey("ein_issuing_country"));
        Assert.Null(model.EntityType);
        Assert.False(model.RawData.ContainsKey("entity_type"));
        Assert.Null(model.Inherit);
        Assert.False(model.RawData.ContainsKey("inherit"));
        Assert.Null(model.LegalName);
        Assert.False(model.RawData.ContainsKey("legal_name"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postal_code"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.False(model.RawData.ContainsKey("street"));
        Assert.Null(model.TaxID);
        Assert.False(model.RawData.ContainsKey("tax_id"));
        Assert.Null(model.TaxIDType);
        Assert.False(model.RawData.ContainsKey("tax_id_type"));
        Assert.Null(model.Website);
        Assert.False(model.RawData.ContainsKey("website"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Brand
        {
            // Null should be interpreted as omitted for these properties
            BusinessName = null,
            City = null,
            ContactEmail = null,
            ContactName = null,
            ContactPhone = null,
            Country = null,
            EinIssuingCountry = null,
            EntityType = null,
            Inherit = null,
            LegalName = null,
            PostalCode = null,
            State = null,
            Street = null,
            TaxID = null,
            TaxIDType = null,
            Website = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Brand
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
        };

        Brand copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityTypeTest : TestBase
{
    [Theory]
    [InlineData(EntityType.PrivateProfit)]
    [InlineData(EntityType.PublicProfit)]
    [InlineData(EntityType.NonProfit)]
    [InlineData(EntityType.SoleProprietor)]
    [InlineData(EntityType.Government)]
    public void Validation_Works(EntityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntityType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntityType.PrivateProfit)]
    [InlineData(EntityType.PublicProfit)]
    [InlineData(EntityType.NonProfit)]
    [InlineData(EntityType.SoleProprietor)]
    [InlineData(EntityType.Government)]
    public void SerializationRoundtrip_Works(EntityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntityType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntityType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntityType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CampaignTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Campaign
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
        };

        string expectedDescription = "description";
        string expectedHelpKeywords = "help_keywords";
        string expectedHelpMessage = "help_message";
        bool expectedInherit = true;
        string expectedMessageFlow = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
        string expectedOptInKeywords = "opt_in_keywords";
        string expectedOptInMessage = "opt_in_message";
        string expectedOptOutKeywords = "opt_out_keywords";
        string expectedOptOutMessage = "opt_out_message";
        string expectedPrivacyPolicyLink = "privacy_policy_link";
        string expectedTermsAndConditionsLink = "terms_and_conditions_link";
        List<UseCase> expectedUseCases =
        [
            new()
            {
                SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
                UseCaseValue = UseCaseUseCase.Marketing,
            },
        ];
        string expectedVolume = "volume";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedHelpKeywords, model.HelpKeywords);
        Assert.Equal(expectedHelpMessage, model.HelpMessage);
        Assert.Equal(expectedInherit, model.Inherit);
        Assert.Equal(expectedMessageFlow, model.MessageFlow);
        Assert.Equal(expectedOptInKeywords, model.OptInKeywords);
        Assert.Equal(expectedOptInMessage, model.OptInMessage);
        Assert.Equal(expectedOptOutKeywords, model.OptOutKeywords);
        Assert.Equal(expectedOptOutMessage, model.OptOutMessage);
        Assert.Equal(expectedPrivacyPolicyLink, model.PrivacyPolicyLink);
        Assert.Equal(expectedTermsAndConditionsLink, model.TermsAndConditionsLink);
        Assert.NotNull(model.UseCases);
        Assert.Equal(expectedUseCases.Count, model.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], model.UseCases[i]);
        }
        Assert.Equal(expectedVolume, model.Volume);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Campaign
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Campaign>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedHelpKeywords = "help_keywords";
        string expectedHelpMessage = "help_message";
        bool expectedInherit = true;
        string expectedMessageFlow = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
        string expectedOptInKeywords = "opt_in_keywords";
        string expectedOptInMessage = "opt_in_message";
        string expectedOptOutKeywords = "opt_out_keywords";
        string expectedOptOutMessage = "opt_out_message";
        string expectedPrivacyPolicyLink = "privacy_policy_link";
        string expectedTermsAndConditionsLink = "terms_and_conditions_link";
        List<UseCase> expectedUseCases =
        [
            new()
            {
                SampleMessages = [JsonSerializer.Deserialize<JsonElement>("{}")],
                UseCaseValue = UseCaseUseCase.Marketing,
            },
        ];
        string expectedVolume = "volume";

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedHelpKeywords, deserialized.HelpKeywords);
        Assert.Equal(expectedHelpMessage, deserialized.HelpMessage);
        Assert.Equal(expectedInherit, deserialized.Inherit);
        Assert.Equal(expectedMessageFlow, deserialized.MessageFlow);
        Assert.Equal(expectedOptInKeywords, deserialized.OptInKeywords);
        Assert.Equal(expectedOptInMessage, deserialized.OptInMessage);
        Assert.Equal(expectedOptOutKeywords, deserialized.OptOutKeywords);
        Assert.Equal(expectedOptOutMessage, deserialized.OptOutMessage);
        Assert.Equal(expectedPrivacyPolicyLink, deserialized.PrivacyPolicyLink);
        Assert.Equal(expectedTermsAndConditionsLink, deserialized.TermsAndConditionsLink);
        Assert.NotNull(deserialized.UseCases);
        Assert.Equal(expectedUseCases.Count, deserialized.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], deserialized.UseCases[i]);
        }
        Assert.Equal(expectedVolume, deserialized.Volume);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Campaign
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Campaign { };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.HelpKeywords);
        Assert.False(model.RawData.ContainsKey("help_keywords"));
        Assert.Null(model.HelpMessage);
        Assert.False(model.RawData.ContainsKey("help_message"));
        Assert.Null(model.Inherit);
        Assert.False(model.RawData.ContainsKey("inherit"));
        Assert.Null(model.MessageFlow);
        Assert.False(model.RawData.ContainsKey("message_flow"));
        Assert.Null(model.OptInKeywords);
        Assert.False(model.RawData.ContainsKey("opt_in_keywords"));
        Assert.Null(model.OptInMessage);
        Assert.False(model.RawData.ContainsKey("opt_in_message"));
        Assert.Null(model.OptOutKeywords);
        Assert.False(model.RawData.ContainsKey("opt_out_keywords"));
        Assert.Null(model.OptOutMessage);
        Assert.False(model.RawData.ContainsKey("opt_out_message"));
        Assert.Null(model.PrivacyPolicyLink);
        Assert.False(model.RawData.ContainsKey("privacy_policy_link"));
        Assert.Null(model.TermsAndConditionsLink);
        Assert.False(model.RawData.ContainsKey("terms_and_conditions_link"));
        Assert.Null(model.UseCases);
        Assert.False(model.RawData.ContainsKey("use_cases"));
        Assert.Null(model.Volume);
        Assert.False(model.RawData.ContainsKey("volume"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Campaign { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Campaign
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            HelpKeywords = null,
            HelpMessage = null,
            Inherit = null,
            MessageFlow = null,
            OptInKeywords = null,
            OptInMessage = null,
            OptOutKeywords = null,
            OptOutMessage = null,
            PrivacyPolicyLink = null,
            TermsAndConditionsLink = null,
            UseCases = null,
            Volume = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.HelpKeywords);
        Assert.False(model.RawData.ContainsKey("help_keywords"));
        Assert.Null(model.HelpMessage);
        Assert.False(model.RawData.ContainsKey("help_message"));
        Assert.Null(model.Inherit);
        Assert.False(model.RawData.ContainsKey("inherit"));
        Assert.Null(model.MessageFlow);
        Assert.False(model.RawData.ContainsKey("message_flow"));
        Assert.Null(model.OptInKeywords);
        Assert.False(model.RawData.ContainsKey("opt_in_keywords"));
        Assert.Null(model.OptInMessage);
        Assert.False(model.RawData.ContainsKey("opt_in_message"));
        Assert.Null(model.OptOutKeywords);
        Assert.False(model.RawData.ContainsKey("opt_out_keywords"));
        Assert.Null(model.OptOutMessage);
        Assert.False(model.RawData.ContainsKey("opt_out_message"));
        Assert.Null(model.PrivacyPolicyLink);
        Assert.False(model.RawData.ContainsKey("privacy_policy_link"));
        Assert.Null(model.TermsAndConditionsLink);
        Assert.False(model.RawData.ContainsKey("terms_and_conditions_link"));
        Assert.Null(model.UseCases);
        Assert.False(model.RawData.ContainsKey("use_cases"));
        Assert.Null(model.Volume);
        Assert.False(model.RawData.ContainsKey("volume"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Campaign
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            HelpKeywords = null,
            HelpMessage = null,
            Inherit = null,
            MessageFlow = null,
            OptInKeywords = null,
            OptInMessage = null,
            OptOutKeywords = null,
            OptOutMessage = null,
            PrivacyPolicyLink = null,
            TermsAndConditionsLink = null,
            UseCases = null,
            Volume = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Campaign
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
