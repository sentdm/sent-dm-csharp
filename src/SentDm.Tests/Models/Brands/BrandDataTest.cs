using System.Collections.Generic;
using System.Text.Json;
using SentDm.Core;
using SentDm.Exceptions;
using SentDm.Models.Brands;

namespace SentDm.Tests.Models.Brands;

public class BrandDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandData
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            ContactName = "x",
            Vertical = TcrVertical.Professional,
            BrandName = "brandName",
            BusinessLegalName = "businessLegalName",
            BusinessName = "businessName",
            BusinessRole = "businessRole",
            BusinessUrl = "https://example.com",
            City = "city",
            ContactEmail = "dev@stainless.com",
            ContactPhone = "contactPhone",
            ContactPhoneCountryCode = "contactPhoneCountryCode",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            EntityType = EntityType.PrivateProfit,
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PostalCode = "postalCode",
            PrimaryUseCase = "primaryUseCase",
            State = "state",
            Street = "street",
            TaxID = "taxId",
            TaxIDType = "taxIdType",
        };

        ApiEnum<string, TcrBrandRelationship> expectedBrandRelationship =
            TcrBrandRelationship.BasicAccount;
        string expectedContactName = "x";
        ApiEnum<string, TcrVertical> expectedVertical = TcrVertical.Professional;
        string expectedBrandName = "brandName";
        string expectedBusinessLegalName = "businessLegalName";
        string expectedBusinessName = "businessName";
        string expectedBusinessRole = "businessRole";
        string expectedBusinessUrl = "https://example.com";
        string expectedCity = "city";
        string expectedContactEmail = "dev@stainless.com";
        string expectedContactPhone = "contactPhone";
        string expectedContactPhoneCountryCode = "contactPhoneCountryCode";
        string expectedCountry = "country";
        string expectedCountryOfRegistration = "countryOfRegistration";
        List<DestinationCountry> expectedDestinationCountries =
        [
            new() { ID = "id", IsMain = true },
        ];
        ApiEnum<string, EntityType> expectedEntityType = EntityType.PrivateProfit;
        string expectedExpectedMessagingVolume = "expectedMessagingVolume";
        bool expectedIsTcrApplication = true;
        string expectedNotes = "notes";
        string expectedPhoneNumberPrefix = "phoneNumberPrefix";
        string expectedPostalCode = "postalCode";
        string expectedPrimaryUseCase = "primaryUseCase";
        string expectedState = "state";
        string expectedStreet = "street";
        string expectedTaxID = "taxId";
        string expectedTaxIDType = "taxIdType";

        Assert.Equal(expectedBrandRelationship, model.BrandRelationship);
        Assert.Equal(expectedContactName, model.ContactName);
        Assert.Equal(expectedVertical, model.Vertical);
        Assert.Equal(expectedBrandName, model.BrandName);
        Assert.Equal(expectedBusinessLegalName, model.BusinessLegalName);
        Assert.Equal(expectedBusinessName, model.BusinessName);
        Assert.Equal(expectedBusinessRole, model.BusinessRole);
        Assert.Equal(expectedBusinessUrl, model.BusinessUrl);
        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedContactEmail, model.ContactEmail);
        Assert.Equal(expectedContactPhone, model.ContactPhone);
        Assert.Equal(expectedContactPhoneCountryCode, model.ContactPhoneCountryCode);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedCountryOfRegistration, model.CountryOfRegistration);
        Assert.NotNull(model.DestinationCountries);
        Assert.Equal(expectedDestinationCountries.Count, model.DestinationCountries.Count);
        for (int i = 0; i < expectedDestinationCountries.Count; i++)
        {
            Assert.Equal(expectedDestinationCountries[i], model.DestinationCountries[i]);
        }
        Assert.Equal(expectedEntityType, model.EntityType);
        Assert.Equal(expectedExpectedMessagingVolume, model.ExpectedMessagingVolume);
        Assert.Equal(expectedIsTcrApplication, model.IsTcrApplication);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedPhoneNumberPrefix, model.PhoneNumberPrefix);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedPrimaryUseCase, model.PrimaryUseCase);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStreet, model.Street);
        Assert.Equal(expectedTaxID, model.TaxID);
        Assert.Equal(expectedTaxIDType, model.TaxIDType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandData
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            ContactName = "x",
            Vertical = TcrVertical.Professional,
            BrandName = "brandName",
            BusinessLegalName = "businessLegalName",
            BusinessName = "businessName",
            BusinessRole = "businessRole",
            BusinessUrl = "https://example.com",
            City = "city",
            ContactEmail = "dev@stainless.com",
            ContactPhone = "contactPhone",
            ContactPhoneCountryCode = "contactPhoneCountryCode",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            EntityType = EntityType.PrivateProfit,
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PostalCode = "postalCode",
            PrimaryUseCase = "primaryUseCase",
            State = "state",
            Street = "street",
            TaxID = "taxId",
            TaxIDType = "taxIdType",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandData>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandData
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            ContactName = "x",
            Vertical = TcrVertical.Professional,
            BrandName = "brandName",
            BusinessLegalName = "businessLegalName",
            BusinessName = "businessName",
            BusinessRole = "businessRole",
            BusinessUrl = "https://example.com",
            City = "city",
            ContactEmail = "dev@stainless.com",
            ContactPhone = "contactPhone",
            ContactPhoneCountryCode = "contactPhoneCountryCode",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            EntityType = EntityType.PrivateProfit,
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PostalCode = "postalCode",
            PrimaryUseCase = "primaryUseCase",
            State = "state",
            Street = "street",
            TaxID = "taxId",
            TaxIDType = "taxIdType",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, TcrBrandRelationship> expectedBrandRelationship =
            TcrBrandRelationship.BasicAccount;
        string expectedContactName = "x";
        ApiEnum<string, TcrVertical> expectedVertical = TcrVertical.Professional;
        string expectedBrandName = "brandName";
        string expectedBusinessLegalName = "businessLegalName";
        string expectedBusinessName = "businessName";
        string expectedBusinessRole = "businessRole";
        string expectedBusinessUrl = "https://example.com";
        string expectedCity = "city";
        string expectedContactEmail = "dev@stainless.com";
        string expectedContactPhone = "contactPhone";
        string expectedContactPhoneCountryCode = "contactPhoneCountryCode";
        string expectedCountry = "country";
        string expectedCountryOfRegistration = "countryOfRegistration";
        List<DestinationCountry> expectedDestinationCountries =
        [
            new() { ID = "id", IsMain = true },
        ];
        ApiEnum<string, EntityType> expectedEntityType = EntityType.PrivateProfit;
        string expectedExpectedMessagingVolume = "expectedMessagingVolume";
        bool expectedIsTcrApplication = true;
        string expectedNotes = "notes";
        string expectedPhoneNumberPrefix = "phoneNumberPrefix";
        string expectedPostalCode = "postalCode";
        string expectedPrimaryUseCase = "primaryUseCase";
        string expectedState = "state";
        string expectedStreet = "street";
        string expectedTaxID = "taxId";
        string expectedTaxIDType = "taxIdType";

        Assert.Equal(expectedBrandRelationship, deserialized.BrandRelationship);
        Assert.Equal(expectedContactName, deserialized.ContactName);
        Assert.Equal(expectedVertical, deserialized.Vertical);
        Assert.Equal(expectedBrandName, deserialized.BrandName);
        Assert.Equal(expectedBusinessLegalName, deserialized.BusinessLegalName);
        Assert.Equal(expectedBusinessName, deserialized.BusinessName);
        Assert.Equal(expectedBusinessRole, deserialized.BusinessRole);
        Assert.Equal(expectedBusinessUrl, deserialized.BusinessUrl);
        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedContactEmail, deserialized.ContactEmail);
        Assert.Equal(expectedContactPhone, deserialized.ContactPhone);
        Assert.Equal(expectedContactPhoneCountryCode, deserialized.ContactPhoneCountryCode);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedCountryOfRegistration, deserialized.CountryOfRegistration);
        Assert.NotNull(deserialized.DestinationCountries);
        Assert.Equal(expectedDestinationCountries.Count, deserialized.DestinationCountries.Count);
        for (int i = 0; i < expectedDestinationCountries.Count; i++)
        {
            Assert.Equal(expectedDestinationCountries[i], deserialized.DestinationCountries[i]);
        }
        Assert.Equal(expectedEntityType, deserialized.EntityType);
        Assert.Equal(expectedExpectedMessagingVolume, deserialized.ExpectedMessagingVolume);
        Assert.Equal(expectedIsTcrApplication, deserialized.IsTcrApplication);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedPhoneNumberPrefix, deserialized.PhoneNumberPrefix);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedPrimaryUseCase, deserialized.PrimaryUseCase);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStreet, deserialized.Street);
        Assert.Equal(expectedTaxID, deserialized.TaxID);
        Assert.Equal(expectedTaxIDType, deserialized.TaxIDType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandData
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            ContactName = "x",
            Vertical = TcrVertical.Professional,
            BrandName = "brandName",
            BusinessLegalName = "businessLegalName",
            BusinessName = "businessName",
            BusinessRole = "businessRole",
            BusinessUrl = "https://example.com",
            City = "city",
            ContactEmail = "dev@stainless.com",
            ContactPhone = "contactPhone",
            ContactPhoneCountryCode = "contactPhoneCountryCode",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            EntityType = EntityType.PrivateProfit,
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PostalCode = "postalCode",
            PrimaryUseCase = "primaryUseCase",
            State = "state",
            Street = "street",
            TaxID = "taxId",
            TaxIDType = "taxIdType",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandData
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            ContactName = "x",
            Vertical = TcrVertical.Professional,
        };

        Assert.Null(model.BrandName);
        Assert.False(model.RawData.ContainsKey("brandName"));
        Assert.Null(model.BusinessLegalName);
        Assert.False(model.RawData.ContainsKey("businessLegalName"));
        Assert.Null(model.BusinessName);
        Assert.False(model.RawData.ContainsKey("businessName"));
        Assert.Null(model.BusinessRole);
        Assert.False(model.RawData.ContainsKey("businessRole"));
        Assert.Null(model.BusinessUrl);
        Assert.False(model.RawData.ContainsKey("businessUrl"));
        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.ContactEmail);
        Assert.False(model.RawData.ContainsKey("contactEmail"));
        Assert.Null(model.ContactPhone);
        Assert.False(model.RawData.ContainsKey("contactPhone"));
        Assert.Null(model.ContactPhoneCountryCode);
        Assert.False(model.RawData.ContainsKey("contactPhoneCountryCode"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.CountryOfRegistration);
        Assert.False(model.RawData.ContainsKey("countryOfRegistration"));
        Assert.Null(model.DestinationCountries);
        Assert.False(model.RawData.ContainsKey("destinationCountries"));
        Assert.Null(model.EntityType);
        Assert.False(model.RawData.ContainsKey("entityType"));
        Assert.Null(model.ExpectedMessagingVolume);
        Assert.False(model.RawData.ContainsKey("expectedMessagingVolume"));
        Assert.Null(model.IsTcrApplication);
        Assert.False(model.RawData.ContainsKey("isTcrApplication"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.PhoneNumberPrefix);
        Assert.False(model.RawData.ContainsKey("phoneNumberPrefix"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postalCode"));
        Assert.Null(model.PrimaryUseCase);
        Assert.False(model.RawData.ContainsKey("primaryUseCase"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.False(model.RawData.ContainsKey("street"));
        Assert.Null(model.TaxID);
        Assert.False(model.RawData.ContainsKey("taxId"));
        Assert.Null(model.TaxIDType);
        Assert.False(model.RawData.ContainsKey("taxIdType"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandData
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            ContactName = "x",
            Vertical = TcrVertical.Professional,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrandData
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            ContactName = "x",
            Vertical = TcrVertical.Professional,

            BrandName = null,
            BusinessLegalName = null,
            BusinessName = null,
            BusinessRole = null,
            BusinessUrl = null,
            City = null,
            ContactEmail = null,
            ContactPhone = null,
            ContactPhoneCountryCode = null,
            Country = null,
            CountryOfRegistration = null,
            DestinationCountries = null,
            EntityType = null,
            ExpectedMessagingVolume = null,
            IsTcrApplication = null,
            Notes = null,
            PhoneNumberPrefix = null,
            PostalCode = null,
            PrimaryUseCase = null,
            State = null,
            Street = null,
            TaxID = null,
            TaxIDType = null,
        };

        Assert.Null(model.BrandName);
        Assert.True(model.RawData.ContainsKey("brandName"));
        Assert.Null(model.BusinessLegalName);
        Assert.True(model.RawData.ContainsKey("businessLegalName"));
        Assert.Null(model.BusinessName);
        Assert.True(model.RawData.ContainsKey("businessName"));
        Assert.Null(model.BusinessRole);
        Assert.True(model.RawData.ContainsKey("businessRole"));
        Assert.Null(model.BusinessUrl);
        Assert.True(model.RawData.ContainsKey("businessUrl"));
        Assert.Null(model.City);
        Assert.True(model.RawData.ContainsKey("city"));
        Assert.Null(model.ContactEmail);
        Assert.True(model.RawData.ContainsKey("contactEmail"));
        Assert.Null(model.ContactPhone);
        Assert.True(model.RawData.ContainsKey("contactPhone"));
        Assert.Null(model.ContactPhoneCountryCode);
        Assert.True(model.RawData.ContainsKey("contactPhoneCountryCode"));
        Assert.Null(model.Country);
        Assert.True(model.RawData.ContainsKey("country"));
        Assert.Null(model.CountryOfRegistration);
        Assert.True(model.RawData.ContainsKey("countryOfRegistration"));
        Assert.Null(model.DestinationCountries);
        Assert.True(model.RawData.ContainsKey("destinationCountries"));
        Assert.Null(model.EntityType);
        Assert.True(model.RawData.ContainsKey("entityType"));
        Assert.Null(model.ExpectedMessagingVolume);
        Assert.True(model.RawData.ContainsKey("expectedMessagingVolume"));
        Assert.Null(model.IsTcrApplication);
        Assert.True(model.RawData.ContainsKey("isTcrApplication"));
        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.PhoneNumberPrefix);
        Assert.True(model.RawData.ContainsKey("phoneNumberPrefix"));
        Assert.Null(model.PostalCode);
        Assert.True(model.RawData.ContainsKey("postalCode"));
        Assert.Null(model.PrimaryUseCase);
        Assert.True(model.RawData.ContainsKey("primaryUseCase"));
        Assert.Null(model.State);
        Assert.True(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.True(model.RawData.ContainsKey("street"));
        Assert.Null(model.TaxID);
        Assert.True(model.RawData.ContainsKey("taxId"));
        Assert.Null(model.TaxIDType);
        Assert.True(model.RawData.ContainsKey("taxIdType"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandData
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            ContactName = "x",
            Vertical = TcrVertical.Professional,

            BrandName = null,
            BusinessLegalName = null,
            BusinessName = null,
            BusinessRole = null,
            BusinessUrl = null,
            City = null,
            ContactEmail = null,
            ContactPhone = null,
            ContactPhoneCountryCode = null,
            Country = null,
            CountryOfRegistration = null,
            DestinationCountries = null,
            EntityType = null,
            ExpectedMessagingVolume = null,
            IsTcrApplication = null,
            Notes = null,
            PhoneNumberPrefix = null,
            PostalCode = null,
            PrimaryUseCase = null,
            State = null,
            Street = null,
            TaxID = null,
            TaxIDType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrandData
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            ContactName = "x",
            Vertical = TcrVertical.Professional,
            BrandName = "brandName",
            BusinessLegalName = "businessLegalName",
            BusinessName = "businessName",
            BusinessRole = "businessRole",
            BusinessUrl = "https://example.com",
            City = "city",
            ContactEmail = "dev@stainless.com",
            ContactPhone = "contactPhone",
            ContactPhoneCountryCode = "contactPhoneCountryCode",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            EntityType = EntityType.PrivateProfit,
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PostalCode = "postalCode",
            PrimaryUseCase = "primaryUseCase",
            State = "state",
            Street = "street",
            TaxID = "taxId",
            TaxIDType = "taxIdType",
        };

        BrandData copied = new(model);

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
        Assert.Throws<SentDmInvalidDataException>(() => value.Validate());
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
