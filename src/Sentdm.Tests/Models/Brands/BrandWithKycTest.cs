using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Brands;

namespace Sentdm.Tests.Models.Brands;

public class BrandWithKycTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandWithKyc
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Business = new()
            {
                City = "city",
                Country = "country",
                CountryOfRegistration = "country_of_registration",
                EntityType = "entity_type",
                LegalName = "legal_name",
                PostalCode = "postal_code",
                State = "state",
                Street = "street",
                TaxID = "tax_id",
                TaxIDType = "tax_id_type",
                Url = "url",
            },
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expected_messaging_volume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phone_number_prefix",
                PrimaryUseCase = "primary_use_case",
                Vertical = TcrVertical.Professional,
            },
            Contact = new()
            {
                BusinessName = "business_name",
                Email = "email",
                Name = "name",
                Phone = "phone",
                PhoneCountryCode = "phone_country_code",
                Role = "role",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "csp_id",
            IdentityStatus = IdentityStatus.SelfDeclared,
            IsInherited = true,
            Status = Status.Active,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrBrandID = "tcr_brand_id",
            UniversalEin = "universal_ein",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        BrandWithKycBusiness expectedBusiness = new()
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "country_of_registration",
            EntityType = "entity_type",
            LegalName = "legal_name",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
            TaxID = "tax_id",
            TaxIDType = "tax_id_type",
            Url = "url",
        };
        BrandWithKycCompliance expectedCompliance = new()
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            ExpectedMessagingVolume = "expected_messaging_volume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };
        BrandWithKycContact expectedContact = new()
        {
            BusinessName = "business_name",
            Email = "email",
            Name = "name",
            Phone = "phone",
            PhoneCountryCode = "phone_country_code",
            Role = "role",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCspID = "csp_id";
        ApiEnum<string, IdentityStatus> expectedIdentityStatus = IdentityStatus.SelfDeclared;
        bool expectedIsInherited = true;
        ApiEnum<string, Status> expectedStatus = Status.Active;
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedSubmittedToTcr = true;
        string expectedTcrBrandID = "tcr_brand_id";
        string expectedUniversalEin = "universal_ein";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBusiness, model.Business);
        Assert.Equal(expectedCompliance, model.Compliance);
        Assert.Equal(expectedContact, model.Contact);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCspID, model.CspID);
        Assert.Equal(expectedIdentityStatus, model.IdentityStatus);
        Assert.Equal(expectedIsInherited, model.IsInherited);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
        Assert.Equal(expectedSubmittedToTcr, model.SubmittedToTcr);
        Assert.Equal(expectedTcrBrandID, model.TcrBrandID);
        Assert.Equal(expectedUniversalEin, model.UniversalEin);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandWithKyc
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Business = new()
            {
                City = "city",
                Country = "country",
                CountryOfRegistration = "country_of_registration",
                EntityType = "entity_type",
                LegalName = "legal_name",
                PostalCode = "postal_code",
                State = "state",
                Street = "street",
                TaxID = "tax_id",
                TaxIDType = "tax_id_type",
                Url = "url",
            },
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expected_messaging_volume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phone_number_prefix",
                PrimaryUseCase = "primary_use_case",
                Vertical = TcrVertical.Professional,
            },
            Contact = new()
            {
                BusinessName = "business_name",
                Email = "email",
                Name = "name",
                Phone = "phone",
                PhoneCountryCode = "phone_country_code",
                Role = "role",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "csp_id",
            IdentityStatus = IdentityStatus.SelfDeclared,
            IsInherited = true,
            Status = Status.Active,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrBrandID = "tcr_brand_id",
            UniversalEin = "universal_ein",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Business = new()
            {
                City = "city",
                Country = "country",
                CountryOfRegistration = "country_of_registration",
                EntityType = "entity_type",
                LegalName = "legal_name",
                PostalCode = "postal_code",
                State = "state",
                Street = "street",
                TaxID = "tax_id",
                TaxIDType = "tax_id_type",
                Url = "url",
            },
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expected_messaging_volume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phone_number_prefix",
                PrimaryUseCase = "primary_use_case",
                Vertical = TcrVertical.Professional,
            },
            Contact = new()
            {
                BusinessName = "business_name",
                Email = "email",
                Name = "name",
                Phone = "phone",
                PhoneCountryCode = "phone_country_code",
                Role = "role",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "csp_id",
            IdentityStatus = IdentityStatus.SelfDeclared,
            IsInherited = true,
            Status = Status.Active,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrBrandID = "tcr_brand_id",
            UniversalEin = "universal_ein",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandWithKyc>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        BrandWithKycBusiness expectedBusiness = new()
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "country_of_registration",
            EntityType = "entity_type",
            LegalName = "legal_name",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
            TaxID = "tax_id",
            TaxIDType = "tax_id_type",
            Url = "url",
        };
        BrandWithKycCompliance expectedCompliance = new()
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            ExpectedMessagingVolume = "expected_messaging_volume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };
        BrandWithKycContact expectedContact = new()
        {
            BusinessName = "business_name",
            Email = "email",
            Name = "name",
            Phone = "phone",
            PhoneCountryCode = "phone_country_code",
            Role = "role",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCspID = "csp_id";
        ApiEnum<string, IdentityStatus> expectedIdentityStatus = IdentityStatus.SelfDeclared;
        bool expectedIsInherited = true;
        ApiEnum<string, Status> expectedStatus = Status.Active;
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedSubmittedToTcr = true;
        string expectedTcrBrandID = "tcr_brand_id";
        string expectedUniversalEin = "universal_ein";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBusiness, deserialized.Business);
        Assert.Equal(expectedCompliance, deserialized.Compliance);
        Assert.Equal(expectedContact, deserialized.Contact);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCspID, deserialized.CspID);
        Assert.Equal(expectedIdentityStatus, deserialized.IdentityStatus);
        Assert.Equal(expectedIsInherited, deserialized.IsInherited);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
        Assert.Equal(expectedSubmittedToTcr, deserialized.SubmittedToTcr);
        Assert.Equal(expectedTcrBrandID, deserialized.TcrBrandID);
        Assert.Equal(expectedUniversalEin, deserialized.UniversalEin);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandWithKyc
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Business = new()
            {
                City = "city",
                Country = "country",
                CountryOfRegistration = "country_of_registration",
                EntityType = "entity_type",
                LegalName = "legal_name",
                PostalCode = "postal_code",
                State = "state",
                Street = "street",
                TaxID = "tax_id",
                TaxIDType = "tax_id_type",
                Url = "url",
            },
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expected_messaging_volume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phone_number_prefix",
                PrimaryUseCase = "primary_use_case",
                Vertical = TcrVertical.Professional,
            },
            Contact = new()
            {
                BusinessName = "business_name",
                Email = "email",
                Name = "name",
                Phone = "phone",
                PhoneCountryCode = "phone_country_code",
                Role = "role",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "csp_id",
            IdentityStatus = IdentityStatus.SelfDeclared,
            IsInherited = true,
            Status = Status.Active,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrBrandID = "tcr_brand_id",
            UniversalEin = "universal_ein",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandWithKyc
        {
            Business = new()
            {
                City = "city",
                Country = "country",
                CountryOfRegistration = "country_of_registration",
                EntityType = "entity_type",
                LegalName = "legal_name",
                PostalCode = "postal_code",
                State = "state",
                Street = "street",
                TaxID = "tax_id",
                TaxIDType = "tax_id_type",
                Url = "url",
            },
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expected_messaging_volume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phone_number_prefix",
                PrimaryUseCase = "primary_use_case",
                Vertical = TcrVertical.Professional,
            },
            Contact = new()
            {
                BusinessName = "business_name",
                Email = "email",
                Name = "name",
                Phone = "phone",
                PhoneCountryCode = "phone_country_code",
                Role = "role",
            },
            CspID = "csp_id",
            IdentityStatus = IdentityStatus.SelfDeclared,
            Status = Status.Active,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrBrandID = "tcr_brand_id",
            UniversalEin = "universal_ein",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.IsInherited);
        Assert.False(model.RawData.ContainsKey("is_inherited"));
        Assert.Null(model.SubmittedToTcr);
        Assert.False(model.RawData.ContainsKey("submitted_to_tcr"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandWithKyc
        {
            Business = new()
            {
                City = "city",
                Country = "country",
                CountryOfRegistration = "country_of_registration",
                EntityType = "entity_type",
                LegalName = "legal_name",
                PostalCode = "postal_code",
                State = "state",
                Street = "street",
                TaxID = "tax_id",
                TaxIDType = "tax_id_type",
                Url = "url",
            },
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expected_messaging_volume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phone_number_prefix",
                PrimaryUseCase = "primary_use_case",
                Vertical = TcrVertical.Professional,
            },
            Contact = new()
            {
                BusinessName = "business_name",
                Email = "email",
                Name = "name",
                Phone = "phone",
                PhoneCountryCode = "phone_country_code",
                Role = "role",
            },
            CspID = "csp_id",
            IdentityStatus = IdentityStatus.SelfDeclared,
            Status = Status.Active,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrBrandID = "tcr_brand_id",
            UniversalEin = "universal_ein",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BrandWithKyc
        {
            Business = new()
            {
                City = "city",
                Country = "country",
                CountryOfRegistration = "country_of_registration",
                EntityType = "entity_type",
                LegalName = "legal_name",
                PostalCode = "postal_code",
                State = "state",
                Street = "street",
                TaxID = "tax_id",
                TaxIDType = "tax_id_type",
                Url = "url",
            },
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expected_messaging_volume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phone_number_prefix",
                PrimaryUseCase = "primary_use_case",
                Vertical = TcrVertical.Professional,
            },
            Contact = new()
            {
                BusinessName = "business_name",
                Email = "email",
                Name = "name",
                Phone = "phone",
                PhoneCountryCode = "phone_country_code",
                Role = "role",
            },
            CspID = "csp_id",
            IdentityStatus = IdentityStatus.SelfDeclared,
            Status = Status.Active,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrBrandID = "tcr_brand_id",
            UniversalEin = "universal_ein",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            IsInherited = null,
            SubmittedToTcr = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.IsInherited);
        Assert.False(model.RawData.ContainsKey("is_inherited"));
        Assert.Null(model.SubmittedToTcr);
        Assert.False(model.RawData.ContainsKey("submitted_to_tcr"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandWithKyc
        {
            Business = new()
            {
                City = "city",
                Country = "country",
                CountryOfRegistration = "country_of_registration",
                EntityType = "entity_type",
                LegalName = "legal_name",
                PostalCode = "postal_code",
                State = "state",
                Street = "street",
                TaxID = "tax_id",
                TaxIDType = "tax_id_type",
                Url = "url",
            },
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expected_messaging_volume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phone_number_prefix",
                PrimaryUseCase = "primary_use_case",
                Vertical = TcrVertical.Professional,
            },
            Contact = new()
            {
                BusinessName = "business_name",
                Email = "email",
                Name = "name",
                Phone = "phone",
                PhoneCountryCode = "phone_country_code",
                Role = "role",
            },
            CspID = "csp_id",
            IdentityStatus = IdentityStatus.SelfDeclared,
            Status = Status.Active,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TcrBrandID = "tcr_brand_id",
            UniversalEin = "universal_ein",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            IsInherited = null,
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
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsInherited = true,
            SubmittedToTcr = true,
        };

        Assert.Null(model.Business);
        Assert.False(model.RawData.ContainsKey("business"));
        Assert.Null(model.Compliance);
        Assert.False(model.RawData.ContainsKey("compliance"));
        Assert.Null(model.Contact);
        Assert.False(model.RawData.ContainsKey("contact"));
        Assert.Null(model.CspID);
        Assert.False(model.RawData.ContainsKey("csp_id"));
        Assert.Null(model.IdentityStatus);
        Assert.False(model.RawData.ContainsKey("identity_status"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.SubmittedAt);
        Assert.False(model.RawData.ContainsKey("submitted_at"));
        Assert.Null(model.TcrBrandID);
        Assert.False(model.RawData.ContainsKey("tcr_brand_id"));
        Assert.Null(model.UniversalEin);
        Assert.False(model.RawData.ContainsKey("universal_ein"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandWithKyc
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsInherited = true,
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
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsInherited = true,
            SubmittedToTcr = true,

            Business = null,
            Compliance = null,
            Contact = null,
            CspID = null,
            IdentityStatus = null,
            Status = null,
            SubmittedAt = null,
            TcrBrandID = null,
            UniversalEin = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Business);
        Assert.True(model.RawData.ContainsKey("business"));
        Assert.Null(model.Compliance);
        Assert.True(model.RawData.ContainsKey("compliance"));
        Assert.Null(model.Contact);
        Assert.True(model.RawData.ContainsKey("contact"));
        Assert.Null(model.CspID);
        Assert.True(model.RawData.ContainsKey("csp_id"));
        Assert.Null(model.IdentityStatus);
        Assert.True(model.RawData.ContainsKey("identity_status"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.SubmittedAt);
        Assert.True(model.RawData.ContainsKey("submitted_at"));
        Assert.Null(model.TcrBrandID);
        Assert.True(model.RawData.ContainsKey("tcr_brand_id"));
        Assert.Null(model.UniversalEin);
        Assert.True(model.RawData.ContainsKey("universal_ein"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandWithKyc
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsInherited = true,
            SubmittedToTcr = true,

            Business = null,
            Compliance = null,
            Contact = null,
            CspID = null,
            IdentityStatus = null,
            Status = null,
            SubmittedAt = null,
            TcrBrandID = null,
            UniversalEin = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrandWithKyc
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Business = new()
            {
                City = "city",
                Country = "country",
                CountryOfRegistration = "country_of_registration",
                EntityType = "entity_type",
                LegalName = "legal_name",
                PostalCode = "postal_code",
                State = "state",
                Street = "street",
                TaxID = "tax_id",
                TaxIDType = "tax_id_type",
                Url = "url",
            },
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expected_messaging_volume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phone_number_prefix",
                PrimaryUseCase = "primary_use_case",
                Vertical = TcrVertical.Professional,
            },
            Contact = new()
            {
                BusinessName = "business_name",
                Email = "email",
                Name = "name",
                Phone = "phone",
                PhoneCountryCode = "phone_country_code",
                Role = "role",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CspID = "csp_id",
            IdentityStatus = IdentityStatus.SelfDeclared,
            IsInherited = true,
            Status = Status.Active,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrBrandID = "tcr_brand_id",
            UniversalEin = "universal_ein",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BrandWithKyc copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BrandWithKycBusinessTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandWithKycBusiness
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "country_of_registration",
            EntityType = "entity_type",
            LegalName = "legal_name",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
            TaxID = "tax_id",
            TaxIDType = "tax_id_type",
            Url = "url",
        };

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedCountryOfRegistration = "country_of_registration";
        string expectedEntityType = "entity_type";
        string expectedLegalName = "legal_name";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";
        string expectedStreet = "street";
        string expectedTaxID = "tax_id";
        string expectedTaxIDType = "tax_id_type";
        string expectedUrl = "url";

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
        var model = new BrandWithKycBusiness
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "country_of_registration",
            EntityType = "entity_type",
            LegalName = "legal_name",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
            TaxID = "tax_id",
            TaxIDType = "tax_id_type",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandWithKycBusiness>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandWithKycBusiness
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "country_of_registration",
            EntityType = "entity_type",
            LegalName = "legal_name",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
            TaxID = "tax_id",
            TaxIDType = "tax_id_type",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandWithKycBusiness>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedCountryOfRegistration = "country_of_registration";
        string expectedEntityType = "entity_type";
        string expectedLegalName = "legal_name";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";
        string expectedStreet = "street";
        string expectedTaxID = "tax_id";
        string expectedTaxIDType = "tax_id_type";
        string expectedUrl = "url";

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
        var model = new BrandWithKycBusiness
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "country_of_registration",
            EntityType = "entity_type",
            LegalName = "legal_name",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
            TaxID = "tax_id",
            TaxIDType = "tax_id_type",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandWithKycBusiness { };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.CountryOfRegistration);
        Assert.False(model.RawData.ContainsKey("country_of_registration"));
        Assert.Null(model.EntityType);
        Assert.False(model.RawData.ContainsKey("entity_type"));
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
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandWithKycBusiness { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrandWithKycBusiness
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
        Assert.True(model.RawData.ContainsKey("country_of_registration"));
        Assert.Null(model.EntityType);
        Assert.True(model.RawData.ContainsKey("entity_type"));
        Assert.Null(model.LegalName);
        Assert.True(model.RawData.ContainsKey("legal_name"));
        Assert.Null(model.PostalCode);
        Assert.True(model.RawData.ContainsKey("postal_code"));
        Assert.Null(model.State);
        Assert.True(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.True(model.RawData.ContainsKey("street"));
        Assert.Null(model.TaxID);
        Assert.True(model.RawData.ContainsKey("tax_id"));
        Assert.Null(model.TaxIDType);
        Assert.True(model.RawData.ContainsKey("tax_id_type"));
        Assert.Null(model.Url);
        Assert.True(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandWithKycBusiness
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
        var model = new BrandWithKycBusiness
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "country_of_registration",
            EntityType = "entity_type",
            LegalName = "legal_name",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
            TaxID = "tax_id",
            TaxIDType = "tax_id_type",
            Url = "url",
        };

        BrandWithKycBusiness copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BrandWithKycComplianceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandWithKycCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            ExpectedMessagingVolume = "expected_messaging_volume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };

        ApiEnum<string, TcrBrandRelationship> expectedBrandRelationship =
            TcrBrandRelationship.BasicAccount;
        List<DestinationCountry> expectedDestinationCountries =
        [
            new() { ID = "id", IsMain = true },
        ];
        string expectedExpectedMessagingVolume = "expected_messaging_volume";
        bool expectedIsTcrApplication = true;
        string expectedNotes = "notes";
        string expectedPhoneNumberPrefix = "phone_number_prefix";
        string expectedPrimaryUseCase = "primary_use_case";
        ApiEnum<string, TcrVertical> expectedVertical = TcrVertical.Professional;

        Assert.Equal(expectedBrandRelationship, model.BrandRelationship);
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
        Assert.Equal(expectedVertical, model.Vertical);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandWithKycCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            ExpectedMessagingVolume = "expected_messaging_volume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandWithKycCompliance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandWithKycCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            ExpectedMessagingVolume = "expected_messaging_volume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandWithKycCompliance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, TcrBrandRelationship> expectedBrandRelationship =
            TcrBrandRelationship.BasicAccount;
        List<DestinationCountry> expectedDestinationCountries =
        [
            new() { ID = "id", IsMain = true },
        ];
        string expectedExpectedMessagingVolume = "expected_messaging_volume";
        bool expectedIsTcrApplication = true;
        string expectedNotes = "notes";
        string expectedPhoneNumberPrefix = "phone_number_prefix";
        string expectedPrimaryUseCase = "primary_use_case";
        ApiEnum<string, TcrVertical> expectedVertical = TcrVertical.Professional;

        Assert.Equal(expectedBrandRelationship, deserialized.BrandRelationship);
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
        Assert.Equal(expectedVertical, deserialized.Vertical);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandWithKycCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            ExpectedMessagingVolume = "expected_messaging_volume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandWithKycCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            ExpectedMessagingVolume = "expected_messaging_volume",
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };

        Assert.Null(model.DestinationCountries);
        Assert.False(model.RawData.ContainsKey("destination_countries"));
        Assert.Null(model.IsTcrApplication);
        Assert.False(model.RawData.ContainsKey("is_tcr_application"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandWithKycCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            ExpectedMessagingVolume = "expected_messaging_volume",
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BrandWithKycCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            ExpectedMessagingVolume = "expected_messaging_volume",
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,

            // Null should be interpreted as omitted for these properties
            DestinationCountries = null,
            IsTcrApplication = null,
        };

        Assert.Null(model.DestinationCountries);
        Assert.False(model.RawData.ContainsKey("destination_countries"));
        Assert.Null(model.IsTcrApplication);
        Assert.False(model.RawData.ContainsKey("is_tcr_application"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandWithKycCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            ExpectedMessagingVolume = "expected_messaging_volume",
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,

            // Null should be interpreted as omitted for these properties
            DestinationCountries = null,
            IsTcrApplication = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandWithKycCompliance
        {
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,
        };

        Assert.Null(model.BrandRelationship);
        Assert.False(model.RawData.ContainsKey("brand_relationship"));
        Assert.Null(model.ExpectedMessagingVolume);
        Assert.False(model.RawData.ContainsKey("expected_messaging_volume"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.PhoneNumberPrefix);
        Assert.False(model.RawData.ContainsKey("phone_number_prefix"));
        Assert.Null(model.PrimaryUseCase);
        Assert.False(model.RawData.ContainsKey("primary_use_case"));
        Assert.Null(model.Vertical);
        Assert.False(model.RawData.ContainsKey("vertical"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandWithKycCompliance
        {
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrandWithKycCompliance
        {
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,

            BrandRelationship = null,
            ExpectedMessagingVolume = null,
            Notes = null,
            PhoneNumberPrefix = null,
            PrimaryUseCase = null,
            Vertical = null,
        };

        Assert.Null(model.BrandRelationship);
        Assert.True(model.RawData.ContainsKey("brand_relationship"));
        Assert.Null(model.ExpectedMessagingVolume);
        Assert.True(model.RawData.ContainsKey("expected_messaging_volume"));
        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.PhoneNumberPrefix);
        Assert.True(model.RawData.ContainsKey("phone_number_prefix"));
        Assert.Null(model.PrimaryUseCase);
        Assert.True(model.RawData.ContainsKey("primary_use_case"));
        Assert.Null(model.Vertical);
        Assert.True(model.RawData.ContainsKey("vertical"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandWithKycCompliance
        {
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,

            BrandRelationship = null,
            ExpectedMessagingVolume = null,
            Notes = null,
            PhoneNumberPrefix = null,
            PrimaryUseCase = null,
            Vertical = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrandWithKycCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            ExpectedMessagingVolume = "expected_messaging_volume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };

        BrandWithKycCompliance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BrandWithKycContactTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandWithKycContact
        {
            BusinessName = "business_name",
            Email = "email",
            Name = "name",
            Phone = "phone",
            PhoneCountryCode = "phone_country_code",
            Role = "role",
        };

        string expectedBusinessName = "business_name";
        string expectedEmail = "email";
        string expectedName = "name";
        string expectedPhone = "phone";
        string expectedPhoneCountryCode = "phone_country_code";
        string expectedRole = "role";

        Assert.Equal(expectedBusinessName, model.BusinessName);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPhone, model.Phone);
        Assert.Equal(expectedPhoneCountryCode, model.PhoneCountryCode);
        Assert.Equal(expectedRole, model.Role);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandWithKycContact
        {
            BusinessName = "business_name",
            Email = "email",
            Name = "name",
            Phone = "phone",
            PhoneCountryCode = "phone_country_code",
            Role = "role",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandWithKycContact>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandWithKycContact
        {
            BusinessName = "business_name",
            Email = "email",
            Name = "name",
            Phone = "phone",
            PhoneCountryCode = "phone_country_code",
            Role = "role",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandWithKycContact>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessName = "business_name";
        string expectedEmail = "email";
        string expectedName = "name";
        string expectedPhone = "phone";
        string expectedPhoneCountryCode = "phone_country_code";
        string expectedRole = "role";

        Assert.Equal(expectedBusinessName, deserialized.BusinessName);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPhone, deserialized.Phone);
        Assert.Equal(expectedPhoneCountryCode, deserialized.PhoneCountryCode);
        Assert.Equal(expectedRole, deserialized.Role);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandWithKycContact
        {
            BusinessName = "business_name",
            Email = "email",
            Name = "name",
            Phone = "phone",
            PhoneCountryCode = "phone_country_code",
            Role = "role",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandWithKycContact
        {
            BusinessName = "business_name",
            Email = "email",
            Phone = "phone",
            PhoneCountryCode = "phone_country_code",
            Role = "role",
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandWithKycContact
        {
            BusinessName = "business_name",
            Email = "email",
            Phone = "phone",
            PhoneCountryCode = "phone_country_code",
            Role = "role",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BrandWithKycContact
        {
            BusinessName = "business_name",
            Email = "email",
            Phone = "phone",
            PhoneCountryCode = "phone_country_code",
            Role = "role",

            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandWithKycContact
        {
            BusinessName = "business_name",
            Email = "email",
            Phone = "phone",
            PhoneCountryCode = "phone_country_code",
            Role = "role",

            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandWithKycContact { Name = "name" };

        Assert.Null(model.BusinessName);
        Assert.False(model.RawData.ContainsKey("business_name"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
        Assert.Null(model.PhoneCountryCode);
        Assert.False(model.RawData.ContainsKey("phone_country_code"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandWithKycContact { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrandWithKycContact
        {
            Name = "name",

            BusinessName = null,
            Email = null,
            Phone = null,
            PhoneCountryCode = null,
            Role = null,
        };

        Assert.Null(model.BusinessName);
        Assert.True(model.RawData.ContainsKey("business_name"));
        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.Phone);
        Assert.True(model.RawData.ContainsKey("phone"));
        Assert.Null(model.PhoneCountryCode);
        Assert.True(model.RawData.ContainsKey("phone_country_code"));
        Assert.Null(model.Role);
        Assert.True(model.RawData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandWithKycContact
        {
            Name = "name",

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
        var model = new BrandWithKycContact
        {
            BusinessName = "business_name",
            Email = "email",
            Name = "name",
            Phone = "phone",
            PhoneCountryCode = "phone_country_code",
            Role = "role",
        };

        BrandWithKycContact copied = new(model);

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
