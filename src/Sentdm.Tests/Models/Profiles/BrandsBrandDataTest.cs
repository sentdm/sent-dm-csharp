using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class BrandsBrandDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandsBrandData
        {
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            },
            Contact = new()
            {
                Name = "x",
                BusinessName = "businessName",
                Email = "dev@stainless.com",
                Phone = "phone",
                PhoneCountryCode = "phoneCountryCode",
                Role = "role",
            },
            Business = new()
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
            },
        };

        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo expectedCompliance =
            new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            };
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo expectedContact =
            new()
            {
                Name = "x",
                BusinessName = "businessName",
                Email = "dev@stainless.com",
                Phone = "phone",
                PhoneCountryCode = "phoneCountryCode",
                Role = "role",
            };
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo expectedBusiness =
            new()
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

        Assert.Equal(expectedCompliance, model.Compliance);
        Assert.Equal(expectedContact, model.Contact);
        Assert.Equal(expectedBusiness, model.Business);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandsBrandData
        {
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            },
            Contact = new()
            {
                Name = "x",
                BusinessName = "businessName",
                Email = "dev@stainless.com",
                Phone = "phone",
                PhoneCountryCode = "phoneCountryCode",
                Role = "role",
            },
            Business = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandsBrandData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandsBrandData
        {
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            },
            Contact = new()
            {
                Name = "x",
                BusinessName = "businessName",
                Email = "dev@stainless.com",
                Phone = "phone",
                PhoneCountryCode = "phoneCountryCode",
                Role = "role",
            },
            Business = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandsBrandData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo expectedCompliance =
            new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            };
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo expectedContact =
            new()
            {
                Name = "x",
                BusinessName = "businessName",
                Email = "dev@stainless.com",
                Phone = "phone",
                PhoneCountryCode = "phoneCountryCode",
                Role = "role",
            };
        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandBusinessInfo expectedBusiness =
            new()
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

        Assert.Equal(expectedCompliance, deserialized.Compliance);
        Assert.Equal(expectedContact, deserialized.Contact);
        Assert.Equal(expectedBusiness, deserialized.Business);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandsBrandData
        {
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            },
            Contact = new()
            {
                Name = "x",
                BusinessName = "businessName",
                Email = "dev@stainless.com",
                Phone = "phone",
                PhoneCountryCode = "phoneCountryCode",
                Role = "role",
            },
            Business = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandsBrandData
        {
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            },
            Contact = new()
            {
                Name = "x",
                BusinessName = "businessName",
                Email = "dev@stainless.com",
                Phone = "phone",
                PhoneCountryCode = "phoneCountryCode",
                Role = "role",
            },
        };

        Assert.Null(model.Business);
        Assert.False(model.RawData.ContainsKey("business"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandsBrandData
        {
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            },
            Contact = new()
            {
                Name = "x",
                BusinessName = "businessName",
                Email = "dev@stainless.com",
                Phone = "phone",
                PhoneCountryCode = "phoneCountryCode",
                Role = "role",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrandsBrandData
        {
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            },
            Contact = new()
            {
                Name = "x",
                BusinessName = "businessName",
                Email = "dev@stainless.com",
                Phone = "phone",
                PhoneCountryCode = "phoneCountryCode",
                Role = "role",
            },

            Business = null,
        };

        Assert.Null(model.Business);
        Assert.True(model.RawData.ContainsKey("business"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandsBrandData
        {
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            },
            Contact = new()
            {
                Name = "x",
                BusinessName = "businessName",
                Email = "dev@stainless.com",
                Phone = "phone",
                PhoneCountryCode = "phoneCountryCode",
                Role = "role",
            },

            Business = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrandsBrandData
        {
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            },
            Contact = new()
            {
                Name = "x",
                BusinessName = "businessName",
                Email = "dev@stainless.com",
                Phone = "phone",
                PhoneCountryCode = "phoneCountryCode",
                Role = "role",
            },
            Business = new()
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
            },
        };

        BrandsBrandData copied = new(model);

        Assert.Equal(model, copied);
    }
}
