using System;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

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
            IdentityStatus = TcrBrandIdentityStatus.SelfDeclared,
            IsInherited = true,
            Status = TcrBrandStatus.Active,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubmittedToTcr = true,
            TcrBrandID = "tcr_brand_id",
            UniversalEin = "universal_ein",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        BrandBusiness expectedBusiness = new()
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
        BrandCompliance expectedCompliance = new()
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };
        BrandContact expectedContact = new()
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
        ApiEnum<string, TcrBrandIdentityStatus> expectedIdentityStatus =
            TcrBrandIdentityStatus.SelfDeclared;
        bool expectedIsInherited = true;
        ApiEnum<string, TcrBrandStatus> expectedStatus = TcrBrandStatus.Active;
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
            IdentityStatus = TcrBrandIdentityStatus.SelfDeclared,
            IsInherited = true,
            Status = TcrBrandStatus.Active,
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
            IdentityStatus = TcrBrandIdentityStatus.SelfDeclared,
            IsInherited = true,
            Status = TcrBrandStatus.Active,
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
        BrandBusiness expectedBusiness = new()
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
        BrandCompliance expectedCompliance = new()
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };
        BrandContact expectedContact = new()
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
        ApiEnum<string, TcrBrandIdentityStatus> expectedIdentityStatus =
            TcrBrandIdentityStatus.SelfDeclared;
        bool expectedIsInherited = true;
        ApiEnum<string, TcrBrandStatus> expectedStatus = TcrBrandStatus.Active;
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
            IdentityStatus = TcrBrandIdentityStatus.SelfDeclared,
            IsInherited = true,
            Status = TcrBrandStatus.Active,
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
            IdentityStatus = TcrBrandIdentityStatus.SelfDeclared,
            Status = TcrBrandStatus.Active,
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
            IdentityStatus = TcrBrandIdentityStatus.SelfDeclared,
            Status = TcrBrandStatus.Active,
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
            IdentityStatus = TcrBrandIdentityStatus.SelfDeclared,
            Status = TcrBrandStatus.Active,
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
            IdentityStatus = TcrBrandIdentityStatus.SelfDeclared,
            Status = TcrBrandStatus.Active,
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
            IdentityStatus = TcrBrandIdentityStatus.SelfDeclared,
            IsInherited = true,
            Status = TcrBrandStatus.Active,
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
