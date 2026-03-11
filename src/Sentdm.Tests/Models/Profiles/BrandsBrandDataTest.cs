using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
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

        Compliance expectedCompliance = new()
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
        Contact expectedContact = new()
        {
            Name = "x",
            BusinessName = "businessName",
            Email = "dev@stainless.com",
            Phone = "phone",
            PhoneCountryCode = "phoneCountryCode",
            Role = "role",
        };
        Business expectedBusiness = new()
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

        Compliance expectedCompliance = new()
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
        Contact expectedContact = new()
        {
            Name = "x",
            BusinessName = "businessName",
            Email = "dev@stainless.com",
            Phone = "phone",
            PhoneCountryCode = "phoneCountryCode",
            Role = "role",
        };
        Business expectedBusiness = new()
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

public class ComplianceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Compliance
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

        ApiEnum<string, TcrBrandRelationship> expectedBrandRelationship =
            TcrBrandRelationship.BasicAccount;
        ApiEnum<string, TcrVertical> expectedVertical = TcrVertical.Professional;
        List<DestinationCountry> expectedDestinationCountries =
        [
            new() { ID = "id", IsMain = true },
        ];
        string expectedExpectedMessagingVolume = "expectedMessagingVolume";
        bool expectedIsTcrApplication = true;
        string expectedNotes = "notes";
        string expectedPhoneNumberPrefix = "phoneNumberPrefix";
        string expectedPrimaryUseCase = "primaryUseCase";

        Assert.Equal(expectedBrandRelationship, model.BrandRelationship);
        Assert.Equal(expectedVertical, model.Vertical);
        Assert.NotNull(model.DestinationCountries);
        Assert.Equal(expectedDestinationCountries.Count, model.DestinationCountries.Count);
        for (int i = 0; i < expectedDestinationCountries.Count; i++)
        {
            Assert.Equal(expectedDestinationCountries[i], model.DestinationCountries[i]);
        }
        Assert.Equal(expectedExpectedMessagingVolume, model.ExpectedMessagingVolume);
        Assert.Equal(expectedIsTcrApplication, model.IsTcrApplication);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedPhoneNumberPrefix, model.PhoneNumberPrefix);
        Assert.Equal(expectedPrimaryUseCase, model.PrimaryUseCase);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Compliance
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Compliance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Compliance
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Compliance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, TcrBrandRelationship> expectedBrandRelationship =
            TcrBrandRelationship.BasicAccount;
        ApiEnum<string, TcrVertical> expectedVertical = TcrVertical.Professional;
        List<DestinationCountry> expectedDestinationCountries =
        [
            new() { ID = "id", IsMain = true },
        ];
        string expectedExpectedMessagingVolume = "expectedMessagingVolume";
        bool expectedIsTcrApplication = true;
        string expectedNotes = "notes";
        string expectedPhoneNumberPrefix = "phoneNumberPrefix";
        string expectedPrimaryUseCase = "primaryUseCase";

        Assert.Equal(expectedBrandRelationship, deserialized.BrandRelationship);
        Assert.Equal(expectedVertical, deserialized.Vertical);
        Assert.NotNull(deserialized.DestinationCountries);
        Assert.Equal(expectedDestinationCountries.Count, deserialized.DestinationCountries.Count);
        for (int i = 0; i < expectedDestinationCountries.Count; i++)
        {
            Assert.Equal(expectedDestinationCountries[i], deserialized.DestinationCountries[i]);
        }
        Assert.Equal(expectedExpectedMessagingVolume, deserialized.ExpectedMessagingVolume);
        Assert.Equal(expectedIsTcrApplication, deserialized.IsTcrApplication);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedPhoneNumberPrefix, deserialized.PhoneNumberPrefix);
        Assert.Equal(expectedPrimaryUseCase, deserialized.PrimaryUseCase);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Compliance
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Compliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            Vertical = TcrVertical.Professional,
        };

        Assert.Null(model.DestinationCountries);
        Assert.False(model.RawData.ContainsKey("destinationCountries"));
        Assert.Null(model.ExpectedMessagingVolume);
        Assert.False(model.RawData.ContainsKey("expectedMessagingVolume"));
        Assert.Null(model.IsTcrApplication);
        Assert.False(model.RawData.ContainsKey("isTcrApplication"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.PhoneNumberPrefix);
        Assert.False(model.RawData.ContainsKey("phoneNumberPrefix"));
        Assert.Null(model.PrimaryUseCase);
        Assert.False(model.RawData.ContainsKey("primaryUseCase"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Compliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            Vertical = TcrVertical.Professional,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Compliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            Vertical = TcrVertical.Professional,

            DestinationCountries = null,
            ExpectedMessagingVolume = null,
            IsTcrApplication = null,
            Notes = null,
            PhoneNumberPrefix = null,
            PrimaryUseCase = null,
        };

        Assert.Null(model.DestinationCountries);
        Assert.True(model.RawData.ContainsKey("destinationCountries"));
        Assert.Null(model.ExpectedMessagingVolume);
        Assert.True(model.RawData.ContainsKey("expectedMessagingVolume"));
        Assert.Null(model.IsTcrApplication);
        Assert.True(model.RawData.ContainsKey("isTcrApplication"));
        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.PhoneNumberPrefix);
        Assert.True(model.RawData.ContainsKey("phoneNumberPrefix"));
        Assert.Null(model.PrimaryUseCase);
        Assert.True(model.RawData.ContainsKey("primaryUseCase"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Compliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            Vertical = TcrVertical.Professional,

            DestinationCountries = null,
            ExpectedMessagingVolume = null,
            IsTcrApplication = null,
            Notes = null,
            PhoneNumberPrefix = null,
            PrimaryUseCase = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Compliance
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

        Compliance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContactTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contact
        {
            Name = "x",
            BusinessName = "businessName",
            Email = "dev@stainless.com",
            Phone = "phone",
            PhoneCountryCode = "phoneCountryCode",
            Role = "role",
        };

        string expectedName = "x";
        string expectedBusinessName = "businessName";
        string expectedEmail = "dev@stainless.com";
        string expectedPhone = "phone";
        string expectedPhoneCountryCode = "phoneCountryCode";
        string expectedRole = "role";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBusinessName, model.BusinessName);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedPhone, model.Phone);
        Assert.Equal(expectedPhoneCountryCode, model.PhoneCountryCode);
        Assert.Equal(expectedRole, model.Role);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contact
        {
            Name = "x",
            BusinessName = "businessName",
            Email = "dev@stainless.com",
            Phone = "phone",
            PhoneCountryCode = "phoneCountryCode",
            Role = "role",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contact>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contact
        {
            Name = "x",
            BusinessName = "businessName",
            Email = "dev@stainless.com",
            Phone = "phone",
            PhoneCountryCode = "phoneCountryCode",
            Role = "role",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contact>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        string expectedBusinessName = "businessName";
        string expectedEmail = "dev@stainless.com";
        string expectedPhone = "phone";
        string expectedPhoneCountryCode = "phoneCountryCode";
        string expectedRole = "role";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBusinessName, deserialized.BusinessName);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedPhone, deserialized.Phone);
        Assert.Equal(expectedPhoneCountryCode, deserialized.PhoneCountryCode);
        Assert.Equal(expectedRole, deserialized.Role);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contact
        {
            Name = "x",
            BusinessName = "businessName",
            Email = "dev@stainless.com",
            Phone = "phone",
            PhoneCountryCode = "phoneCountryCode",
            Role = "role",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contact { Name = "x" };

        Assert.Null(model.BusinessName);
        Assert.False(model.RawData.ContainsKey("businessName"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
        Assert.Null(model.PhoneCountryCode);
        Assert.False(model.RawData.ContainsKey("phoneCountryCode"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Contact { Name = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Contact
        {
            Name = "x",

            BusinessName = null,
            Email = null,
            Phone = null,
            PhoneCountryCode = null,
            Role = null,
        };

        Assert.Null(model.BusinessName);
        Assert.True(model.RawData.ContainsKey("businessName"));
        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.Phone);
        Assert.True(model.RawData.ContainsKey("phone"));
        Assert.Null(model.PhoneCountryCode);
        Assert.True(model.RawData.ContainsKey("phoneCountryCode"));
        Assert.Null(model.Role);
        Assert.True(model.RawData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Contact
        {
            Name = "x",

            BusinessName = null,
            Email = null,
            Phone = null,
            PhoneCountryCode = null,
            Role = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contact
        {
            Name = "x",
            BusinessName = "businessName",
            Email = "dev@stainless.com",
            Phone = "phone",
            PhoneCountryCode = "phoneCountryCode",
            Role = "role",
        };

        Contact copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BusinessTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Business
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
        var model = new Business
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
        var deserialized = JsonSerializer.Deserialize<Business>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Business
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
        var deserialized = JsonSerializer.Deserialize<Business>(
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
        var model = new Business
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
        var model = new Business { };

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
        var model = new Business { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Business
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
        var model = new Business
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
        var model = new Business
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

        Business copied = new(model);

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
