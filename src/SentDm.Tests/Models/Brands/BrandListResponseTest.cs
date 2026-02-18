using System;
using System.Collections.Generic;
using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Brands;
using SentDm.Models.Webhooks;

namespace SentDm.Tests.Models.Brands;

public class BrandListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandListResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        List<BrandWithKyc> expectedData =
        [
            new()
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
            },
        ];
        ApiError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            ResponseTimeMs = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedMeta, model.Meta);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandListResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandListResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BrandWithKyc> expectedData =
        [
            new()
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
            },
        ];
        ApiError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            ResponseTimeMs = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedMeta, deserialized.Meta);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandListResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandListResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
        };

        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandListResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BrandListResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },

            // Null should be interpreted as omitted for these properties
            Meta = null,
            Success = null,
        };

        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandListResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },

            // Null should be interpreted as omitted for these properties
            Meta = null,
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandListResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandListResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrandListResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,

            Data = null,
            Error = null,
        };

        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandListResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,

            Data = null,
            Error = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrandListResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        BrandListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
