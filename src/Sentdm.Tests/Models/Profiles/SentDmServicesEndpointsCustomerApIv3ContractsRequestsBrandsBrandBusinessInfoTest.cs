using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfoTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            EntityType = EntityType.PrivateProfit,
            LegalName = "legalName",
            PostalCode = "postalCode",
            State = "state",
            Street = "street",
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            Url = "https://example.com",
        };

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedCountryOfRegistration = "countryOfRegistration";
        ApiEnum<string, EntityType> expectedEntityType = EntityType.PrivateProfit;
        string expectedLegalName = "legalName";
        string expectedPostalCode = "postalCode";
        string expectedState = "state";
        string expectedStreet = "street";
        string expectedTaxID = "taxId";
        string expectedTaxIDType = "taxIdType";
        string expectedUrl = "https://example.com";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedCountryOfRegistration, model.CountryOfRegistration);
        Assert.Equal(expectedEntityType, model.EntityType);
        Assert.Equal(expectedLegalName, model.LegalName);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStreet, model.Street);
        Assert.Equal(expectedTaxID, model.TaxID);
        Assert.Equal(expectedTaxIDType, model.TaxIDType);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            EntityType = EntityType.PrivateProfit,
            LegalName = "legalName",
            PostalCode = "postalCode",
            State = "state",
            Street = "street",
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            Url = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            EntityType = EntityType.PrivateProfit,
            LegalName = "legalName",
            PostalCode = "postalCode",
            State = "state",
            Street = "street",
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            Url = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedCountryOfRegistration = "countryOfRegistration";
        ApiEnum<string, EntityType> expectedEntityType = EntityType.PrivateProfit;
        string expectedLegalName = "legalName";
        string expectedPostalCode = "postalCode";
        string expectedState = "state";
        string expectedStreet = "street";
        string expectedTaxID = "taxId";
        string expectedTaxIDType = "taxIdType";
        string expectedUrl = "https://example.com";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedCountryOfRegistration, deserialized.CountryOfRegistration);
        Assert.Equal(expectedEntityType, deserialized.EntityType);
        Assert.Equal(expectedLegalName, deserialized.LegalName);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStreet, deserialized.Street);
        Assert.Equal(expectedTaxID, deserialized.TaxID);
        Assert.Equal(expectedTaxIDType, deserialized.TaxIDType);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            EntityType = EntityType.PrivateProfit,
            LegalName = "legalName",
            PostalCode = "postalCode",
            State = "state",
            Street = "street",
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo
        { };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.CountryOfRegistration);
        Assert.False(model.RawData.ContainsKey("countryOfRegistration"));
        Assert.Null(model.EntityType);
        Assert.False(model.RawData.ContainsKey("entityType"));
        Assert.Null(model.LegalName);
        Assert.False(model.RawData.ContainsKey("legalName"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postalCode"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.False(model.RawData.ContainsKey("street"));
        Assert.Null(model.TaxID);
        Assert.False(model.RawData.ContainsKey("taxId"));
        Assert.Null(model.TaxIDType);
        Assert.False(model.RawData.ContainsKey("taxIdType"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo
        { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo
        {
            City = null,
            Country = null,
            CountryOfRegistration = null,
            EntityType = null,
            LegalName = null,
            PostalCode = null,
            State = null,
            Street = null,
            TaxID = null,
            TaxIDType = null,
            Url = null,
        };

        Assert.Null(model.City);
        Assert.True(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.True(model.RawData.ContainsKey("country"));
        Assert.Null(model.CountryOfRegistration);
        Assert.True(model.RawData.ContainsKey("countryOfRegistration"));
        Assert.Null(model.EntityType);
        Assert.True(model.RawData.ContainsKey("entityType"));
        Assert.Null(model.LegalName);
        Assert.True(model.RawData.ContainsKey("legalName"));
        Assert.Null(model.PostalCode);
        Assert.True(model.RawData.ContainsKey("postalCode"));
        Assert.Null(model.State);
        Assert.True(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.True(model.RawData.ContainsKey("street"));
        Assert.Null(model.TaxID);
        Assert.True(model.RawData.ContainsKey("taxId"));
        Assert.Null(model.TaxIDType);
        Assert.True(model.RawData.ContainsKey("taxIdType"));
        Assert.Null(model.Url);
        Assert.True(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo
        {
            City = null,
            Country = null,
            CountryOfRegistration = null,
            EntityType = null,
            LegalName = null,
            PostalCode = null,
            State = null,
            Street = null,
            TaxID = null,
            TaxIDType = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            EntityType = EntityType.PrivateProfit,
            LegalName = "legalName",
            PostalCode = "postalCode",
            State = "state",
            Street = "street",
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            Url = "https://example.com",
        };

        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo copied = new(
            model
        );

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
