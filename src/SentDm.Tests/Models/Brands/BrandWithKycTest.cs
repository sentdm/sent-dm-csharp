using System;
using System.Collections.Generic;
using System.Text.Json;
using SentDm.Core;
using SentDm.Exceptions;
using SentDm.Models.Brands;

namespace SentDm.Tests.Models.Brands;

public class BrandWithKycTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandWithKyc
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            BusinessLegalName = "businessLegalName",
            BusinessName = "businessName",
            BusinessRole = "businessRole",
            BusinessUrl = "businessUrl",
            City = "city",
            ContactEmail = "contactEmail",
            ContactName = "contactName",
            ContactPhone = "contactPhone",
            ContactPhoneCountryCode = "contactPhoneCountryCode",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "cspId",
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            EntityType = "entityType",
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IdentityStatus = IdentityStatus.SelfDeclared,
            IsInherited = true,
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PostalCode = "postalCode",
            PrimaryUseCase = "primaryUseCase",
            State = "state",
            Status = Status.Active,
            Street = "street",
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            TcrBrandID = "tcrBrandId",
            UniversalEin = "universalEin",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = TcrVertical.Professional,
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, TcrBrandRelationship> expectedBrandRelationship =
            TcrBrandRelationship.BasicAccount;
        string expectedBusinessLegalName = "businessLegalName";
        string expectedBusinessName = "businessName";
        string expectedBusinessRole = "businessRole";
        string expectedBusinessUrl = "businessUrl";
        string expectedCity = "city";
        string expectedContactEmail = "contactEmail";
        string expectedContactName = "contactName";
        string expectedContactPhone = "contactPhone";
        string expectedContactPhoneCountryCode = "contactPhoneCountryCode";
        string expectedCountry = "country";
        string expectedCountryOfRegistration = "countryOfRegistration";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCspID = "cspId";
        List<DestinationCountry> expectedDestinationCountries =
        [
            new() { ID = "id", IsMain = true },
        ];
        string expectedEntityType = "entityType";
        string expectedExpectedMessagingVolume = "expectedMessagingVolume";
        ApiEnum<string, IdentityStatus> expectedIdentityStatus = IdentityStatus.SelfDeclared;
        bool expectedIsInherited = true;
        bool expectedIsTcrApplication = true;
        string expectedNotes = "notes";
        string expectedPhoneNumberPrefix = "phoneNumberPrefix";
        string expectedPostalCode = "postalCode";
        string expectedPrimaryUseCase = "primaryUseCase";
        string expectedState = "state";
        ApiEnum<string, Status> expectedStatus = Status.Active;
        string expectedStreet = "street";
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedSubmittedToTcr = true;
        string expectedTaxID = "taxId";
        string expectedTaxIDType = "taxIdType";
        string expectedTcrBrandID = "tcrBrandId";
        string expectedUniversalEin = "universalEin";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, TcrVertical> expectedVertical = TcrVertical.Professional;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBrandRelationship, model.BrandRelationship);
        Assert.Equal(expectedBusinessLegalName, model.BusinessLegalName);
        Assert.Equal(expectedBusinessName, model.BusinessName);
        Assert.Equal(expectedBusinessRole, model.BusinessRole);
        Assert.Equal(expectedBusinessUrl, model.BusinessUrl);
        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedContactEmail, model.ContactEmail);
        Assert.Equal(expectedContactName, model.ContactName);
        Assert.Equal(expectedContactPhone, model.ContactPhone);
        Assert.Equal(expectedContactPhoneCountryCode, model.ContactPhoneCountryCode);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedCountryOfRegistration, model.CountryOfRegistration);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCspID, model.CspID);
        Assert.NotNull(model.DestinationCountries);
        Assert.Equal(expectedDestinationCountries.Count, model.DestinationCountries.Count);
        for (int i = 0; i < expectedDestinationCountries.Count; i++)
        {
            Assert.Equal(expectedDestinationCountries[i], model.DestinationCountries[i]);
        }
        Assert.Equal(expectedEntityType, model.EntityType);
        Assert.Equal(expectedExpectedMessagingVolume, model.ExpectedMessagingVolume);
        Assert.Equal(expectedIdentityStatus, model.IdentityStatus);
        Assert.Equal(expectedIsInherited, model.IsInherited);
        Assert.Equal(expectedIsTcrApplication, model.IsTcrApplication);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedPhoneNumberPrefix, model.PhoneNumberPrefix);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedPrimaryUseCase, model.PrimaryUseCase);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStreet, model.Street);
        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
        Assert.Equal(expectedSubmittedToTcr, model.SubmittedToTcr);
        Assert.Equal(expectedTaxID, model.TaxID);
        Assert.Equal(expectedTaxIDType, model.TaxIDType);
        Assert.Equal(expectedTcrBrandID, model.TcrBrandID);
        Assert.Equal(expectedUniversalEin, model.UniversalEin);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVertical, model.Vertical);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandWithKyc
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            BusinessLegalName = "businessLegalName",
            BusinessName = "businessName",
            BusinessRole = "businessRole",
            BusinessUrl = "businessUrl",
            City = "city",
            ContactEmail = "contactEmail",
            ContactName = "contactName",
            ContactPhone = "contactPhone",
            ContactPhoneCountryCode = "contactPhoneCountryCode",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "cspId",
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            EntityType = "entityType",
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IdentityStatus = IdentityStatus.SelfDeclared,
            IsInherited = true,
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PostalCode = "postalCode",
            PrimaryUseCase = "primaryUseCase",
            State = "state",
            Status = Status.Active,
            Street = "street",
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            TcrBrandID = "tcrBrandId",
            UniversalEin = "universalEin",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = TcrVertical.Professional,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandWithKyc>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandWithKyc
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            BusinessLegalName = "businessLegalName",
            BusinessName = "businessName",
            BusinessRole = "businessRole",
            BusinessUrl = "businessUrl",
            City = "city",
            ContactEmail = "contactEmail",
            ContactName = "contactName",
            ContactPhone = "contactPhone",
            ContactPhoneCountryCode = "contactPhoneCountryCode",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "cspId",
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            EntityType = "entityType",
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IdentityStatus = IdentityStatus.SelfDeclared,
            IsInherited = true,
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PostalCode = "postalCode",
            PrimaryUseCase = "primaryUseCase",
            State = "state",
            Status = Status.Active,
            Street = "street",
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            TcrBrandID = "tcrBrandId",
            UniversalEin = "universalEin",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = TcrVertical.Professional,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandWithKyc>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, TcrBrandRelationship> expectedBrandRelationship =
            TcrBrandRelationship.BasicAccount;
        string expectedBusinessLegalName = "businessLegalName";
        string expectedBusinessName = "businessName";
        string expectedBusinessRole = "businessRole";
        string expectedBusinessUrl = "businessUrl";
        string expectedCity = "city";
        string expectedContactEmail = "contactEmail";
        string expectedContactName = "contactName";
        string expectedContactPhone = "contactPhone";
        string expectedContactPhoneCountryCode = "contactPhoneCountryCode";
        string expectedCountry = "country";
        string expectedCountryOfRegistration = "countryOfRegistration";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCspID = "cspId";
        List<DestinationCountry> expectedDestinationCountries =
        [
            new() { ID = "id", IsMain = true },
        ];
        string expectedEntityType = "entityType";
        string expectedExpectedMessagingVolume = "expectedMessagingVolume";
        ApiEnum<string, IdentityStatus> expectedIdentityStatus = IdentityStatus.SelfDeclared;
        bool expectedIsInherited = true;
        bool expectedIsTcrApplication = true;
        string expectedNotes = "notes";
        string expectedPhoneNumberPrefix = "phoneNumberPrefix";
        string expectedPostalCode = "postalCode";
        string expectedPrimaryUseCase = "primaryUseCase";
        string expectedState = "state";
        ApiEnum<string, Status> expectedStatus = Status.Active;
        string expectedStreet = "street";
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedSubmittedToTcr = true;
        string expectedTaxID = "taxId";
        string expectedTaxIDType = "taxIdType";
        string expectedTcrBrandID = "tcrBrandId";
        string expectedUniversalEin = "universalEin";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, TcrVertical> expectedVertical = TcrVertical.Professional;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBrandRelationship, deserialized.BrandRelationship);
        Assert.Equal(expectedBusinessLegalName, deserialized.BusinessLegalName);
        Assert.Equal(expectedBusinessName, deserialized.BusinessName);
        Assert.Equal(expectedBusinessRole, deserialized.BusinessRole);
        Assert.Equal(expectedBusinessUrl, deserialized.BusinessUrl);
        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedContactEmail, deserialized.ContactEmail);
        Assert.Equal(expectedContactName, deserialized.ContactName);
        Assert.Equal(expectedContactPhone, deserialized.ContactPhone);
        Assert.Equal(expectedContactPhoneCountryCode, deserialized.ContactPhoneCountryCode);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedCountryOfRegistration, deserialized.CountryOfRegistration);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCspID, deserialized.CspID);
        Assert.NotNull(deserialized.DestinationCountries);
        Assert.Equal(expectedDestinationCountries.Count, deserialized.DestinationCountries.Count);
        for (int i = 0; i < expectedDestinationCountries.Count; i++)
        {
            Assert.Equal(expectedDestinationCountries[i], deserialized.DestinationCountries[i]);
        }
        Assert.Equal(expectedEntityType, deserialized.EntityType);
        Assert.Equal(expectedExpectedMessagingVolume, deserialized.ExpectedMessagingVolume);
        Assert.Equal(expectedIdentityStatus, deserialized.IdentityStatus);
        Assert.Equal(expectedIsInherited, deserialized.IsInherited);
        Assert.Equal(expectedIsTcrApplication, deserialized.IsTcrApplication);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedPhoneNumberPrefix, deserialized.PhoneNumberPrefix);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedPrimaryUseCase, deserialized.PrimaryUseCase);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStreet, deserialized.Street);
        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
        Assert.Equal(expectedSubmittedToTcr, deserialized.SubmittedToTcr);
        Assert.Equal(expectedTaxID, deserialized.TaxID);
        Assert.Equal(expectedTaxIDType, deserialized.TaxIDType);
        Assert.Equal(expectedTcrBrandID, deserialized.TcrBrandID);
        Assert.Equal(expectedUniversalEin, deserialized.UniversalEin);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVertical, deserialized.Vertical);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandWithKyc
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            BusinessLegalName = "businessLegalName",
            BusinessName = "businessName",
            BusinessRole = "businessRole",
            BusinessUrl = "businessUrl",
            City = "city",
            ContactEmail = "contactEmail",
            ContactName = "contactName",
            ContactPhone = "contactPhone",
            ContactPhoneCountryCode = "contactPhoneCountryCode",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "cspId",
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            EntityType = "entityType",
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IdentityStatus = IdentityStatus.SelfDeclared,
            IsInherited = true,
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PostalCode = "postalCode",
            PrimaryUseCase = "primaryUseCase",
            State = "state",
            Status = Status.Active,
            Street = "street",
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            TcrBrandID = "tcrBrandId",
            UniversalEin = "universalEin",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = TcrVertical.Professional,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandWithKyc
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            BusinessLegalName = "businessLegalName",
            BusinessName = "businessName",
            BusinessRole = "businessRole",
            BusinessUrl = "businessUrl",
            City = "city",
            ContactEmail = "contactEmail",
            ContactPhone = "contactPhone",
            ContactPhoneCountryCode = "contactPhoneCountryCode",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            CspID = "cspId",
            EntityType = "entityType",
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IdentityStatus = IdentityStatus.SelfDeclared,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PostalCode = "postalCode",
            PrimaryUseCase = "primaryUseCase",
            State = "state",
            Status = Status.Active,
            Street = "street",
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            TcrBrandID = "tcrBrandId",
            UniversalEin = "universalEin",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = TcrVertical.Professional,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ContactName);
        Assert.False(model.RawData.ContainsKey("contactName"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DestinationCountries);
        Assert.False(model.RawData.ContainsKey("destinationCountries"));
        Assert.Null(model.IsInherited);
        Assert.False(model.RawData.ContainsKey("isInherited"));
        Assert.Null(model.IsTcrApplication);
        Assert.False(model.RawData.ContainsKey("isTcrApplication"));
        Assert.Null(model.SubmittedToTcr);
        Assert.False(model.RawData.ContainsKey("submittedToTCR"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandWithKyc
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            BusinessLegalName = "businessLegalName",
            BusinessName = "businessName",
            BusinessRole = "businessRole",
            BusinessUrl = "businessUrl",
            City = "city",
            ContactEmail = "contactEmail",
            ContactPhone = "contactPhone",
            ContactPhoneCountryCode = "contactPhoneCountryCode",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            CspID = "cspId",
            EntityType = "entityType",
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IdentityStatus = IdentityStatus.SelfDeclared,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PostalCode = "postalCode",
            PrimaryUseCase = "primaryUseCase",
            State = "state",
            Status = Status.Active,
            Street = "street",
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            TcrBrandID = "tcrBrandId",
            UniversalEin = "universalEin",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = TcrVertical.Professional,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BrandWithKyc
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            BusinessLegalName = "businessLegalName",
            BusinessName = "businessName",
            BusinessRole = "businessRole",
            BusinessUrl = "businessUrl",
            City = "city",
            ContactEmail = "contactEmail",
            ContactPhone = "contactPhone",
            ContactPhoneCountryCode = "contactPhoneCountryCode",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            CspID = "cspId",
            EntityType = "entityType",
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IdentityStatus = IdentityStatus.SelfDeclared,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PostalCode = "postalCode",
            PrimaryUseCase = "primaryUseCase",
            State = "state",
            Status = Status.Active,
            Street = "street",
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            TcrBrandID = "tcrBrandId",
            UniversalEin = "universalEin",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = TcrVertical.Professional,

            // Null should be interpreted as omitted for these properties
            ID = null,
            ContactName = null,
            CreatedAt = null,
            DestinationCountries = null,
            IsInherited = null,
            IsTcrApplication = null,
            SubmittedToTcr = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ContactName);
        Assert.False(model.RawData.ContainsKey("contactName"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DestinationCountries);
        Assert.False(model.RawData.ContainsKey("destinationCountries"));
        Assert.Null(model.IsInherited);
        Assert.False(model.RawData.ContainsKey("isInherited"));
        Assert.Null(model.IsTcrApplication);
        Assert.False(model.RawData.ContainsKey("isTcrApplication"));
        Assert.Null(model.SubmittedToTcr);
        Assert.False(model.RawData.ContainsKey("submittedToTCR"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandWithKyc
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            BusinessLegalName = "businessLegalName",
            BusinessName = "businessName",
            BusinessRole = "businessRole",
            BusinessUrl = "businessUrl",
            City = "city",
            ContactEmail = "contactEmail",
            ContactPhone = "contactPhone",
            ContactPhoneCountryCode = "contactPhoneCountryCode",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            CspID = "cspId",
            EntityType = "entityType",
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IdentityStatus = IdentityStatus.SelfDeclared,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PostalCode = "postalCode",
            PrimaryUseCase = "primaryUseCase",
            State = "state",
            Status = Status.Active,
            Street = "street",
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            TcrBrandID = "tcrBrandId",
            UniversalEin = "universalEin",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = TcrVertical.Professional,

            // Null should be interpreted as omitted for these properties
            ID = null,
            ContactName = null,
            CreatedAt = null,
            DestinationCountries = null,
            IsInherited = null,
            IsTcrApplication = null,
            SubmittedToTcr = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandWithKyc
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ContactName = "contactName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsInherited = true,
            IsTcrApplication = true,
            SubmittedToTcr = true,
        };

        Assert.Null(model.BrandRelationship);
        Assert.False(model.RawData.ContainsKey("brandRelationship"));
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
        Assert.Null(model.CspID);
        Assert.False(model.RawData.ContainsKey("cspId"));
        Assert.Null(model.EntityType);
        Assert.False(model.RawData.ContainsKey("entityType"));
        Assert.Null(model.ExpectedMessagingVolume);
        Assert.False(model.RawData.ContainsKey("expectedMessagingVolume"));
        Assert.Null(model.IdentityStatus);
        Assert.False(model.RawData.ContainsKey("identityStatus"));
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
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Street);
        Assert.False(model.RawData.ContainsKey("street"));
        Assert.Null(model.SubmittedAt);
        Assert.False(model.RawData.ContainsKey("submittedAt"));
        Assert.Null(model.TaxID);
        Assert.False(model.RawData.ContainsKey("taxId"));
        Assert.Null(model.TaxIDType);
        Assert.False(model.RawData.ContainsKey("taxIdType"));
        Assert.Null(model.TcrBrandID);
        Assert.False(model.RawData.ContainsKey("tcrBrandId"));
        Assert.Null(model.UniversalEin);
        Assert.False(model.RawData.ContainsKey("universalEin"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.Vertical);
        Assert.False(model.RawData.ContainsKey("vertical"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandWithKyc
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ContactName = "contactName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsInherited = true,
            IsTcrApplication = true,
            SubmittedToTcr = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrandWithKyc
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ContactName = "contactName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsInherited = true,
            IsTcrApplication = true,
            SubmittedToTcr = true,

            BrandRelationship = null,
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
            CspID = null,
            EntityType = null,
            ExpectedMessagingVolume = null,
            IdentityStatus = null,
            Notes = null,
            PhoneNumberPrefix = null,
            PostalCode = null,
            PrimaryUseCase = null,
            State = null,
            Status = null,
            Street = null,
            SubmittedAt = null,
            TaxID = null,
            TaxIDType = null,
            TcrBrandID = null,
            UniversalEin = null,
            UpdatedAt = null,
            Vertical = null,
        };

        Assert.Null(model.BrandRelationship);
        Assert.True(model.RawData.ContainsKey("brandRelationship"));
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
        Assert.Null(model.CspID);
        Assert.True(model.RawData.ContainsKey("cspId"));
        Assert.Null(model.EntityType);
        Assert.True(model.RawData.ContainsKey("entityType"));
        Assert.Null(model.ExpectedMessagingVolume);
        Assert.True(model.RawData.ContainsKey("expectedMessagingVolume"));
        Assert.Null(model.IdentityStatus);
        Assert.True(model.RawData.ContainsKey("identityStatus"));
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
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.Street);
        Assert.True(model.RawData.ContainsKey("street"));
        Assert.Null(model.SubmittedAt);
        Assert.True(model.RawData.ContainsKey("submittedAt"));
        Assert.Null(model.TaxID);
        Assert.True(model.RawData.ContainsKey("taxId"));
        Assert.Null(model.TaxIDType);
        Assert.True(model.RawData.ContainsKey("taxIdType"));
        Assert.Null(model.TcrBrandID);
        Assert.True(model.RawData.ContainsKey("tcrBrandId"));
        Assert.Null(model.UniversalEin);
        Assert.True(model.RawData.ContainsKey("universalEin"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.Vertical);
        Assert.True(model.RawData.ContainsKey("vertical"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandWithKyc
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ContactName = "contactName",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsInherited = true,
            IsTcrApplication = true,
            SubmittedToTcr = true,

            BrandRelationship = null,
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
            CspID = null,
            EntityType = null,
            ExpectedMessagingVolume = null,
            IdentityStatus = null,
            Notes = null,
            PhoneNumberPrefix = null,
            PostalCode = null,
            PrimaryUseCase = null,
            State = null,
            Status = null,
            Street = null,
            SubmittedAt = null,
            TaxID = null,
            TaxIDType = null,
            TcrBrandID = null,
            UniversalEin = null,
            UpdatedAt = null,
            Vertical = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrandWithKyc
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            BusinessLegalName = "businessLegalName",
            BusinessName = "businessName",
            BusinessRole = "businessRole",
            BusinessUrl = "businessUrl",
            City = "city",
            ContactEmail = "contactEmail",
            ContactName = "contactName",
            ContactPhone = "contactPhone",
            ContactPhoneCountryCode = "contactPhoneCountryCode",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "cspId",
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            EntityType = "entityType",
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IdentityStatus = IdentityStatus.SelfDeclared,
            IsInherited = true,
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PostalCode = "postalCode",
            PrimaryUseCase = "primaryUseCase",
            State = "state",
            Status = Status.Active,
            Street = "street",
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            TcrBrandID = "tcrBrandId",
            UniversalEin = "universalEin",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = TcrVertical.Professional,
        };

        BrandWithKyc copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IdentityStatusTest : TestBase
{
    [Theory]
    [InlineData(IdentityStatus.SelfDeclared)]
    [InlineData(IdentityStatus.Unverified)]
    [InlineData(IdentityStatus.Verified)]
    [InlineData(IdentityStatus.VettedVerified)]
    public void Validation_Works(IdentityStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IdentityStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IdentityStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentDmInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IdentityStatus.SelfDeclared)]
    [InlineData(IdentityStatus.Unverified)]
    [InlineData(IdentityStatus.Verified)]
    [InlineData(IdentityStatus.VettedVerified)]
    public void SerializationRoundtrip_Works(IdentityStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IdentityStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IdentityStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IdentityStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IdentityStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Inactive)]
    [InlineData(Status.Suspended)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentDmInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Inactive)]
    [InlineData(Status.Suspended)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
