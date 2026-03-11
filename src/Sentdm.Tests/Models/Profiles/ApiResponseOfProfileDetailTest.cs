using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Brands;
using Sentdm.Models.Profiles;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Profiles;

public class ApiResponseOfProfileDetailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiResponseOfProfileDetail
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingContact = new()
                {
                    Address = "address",
                    Email = "email",
                    Name = "name",
                    Phone = "phone",
                },
                BillingModel = "billing_model",
                Brand = new()
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
                },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Email = "email",
                Icon = "icon",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                Name = "name",
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ShortName = "short_name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WabaID = "waba_id",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
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
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        ProfileDetail expectedData = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = true,
            AllowTemplateSharing = true,
            BillingContact = new()
            {
                Address = "address",
                Email = "email",
                Name = "name",
                Phone = "phone",
            },
            BillingModel = "billing_model",
            Brand = new()
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
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Email = "email",
            Icon = "icon",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ShortName = "short_name",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WabaID = "waba_id",
            WhatsappPhoneNumber = "whatsapp_phone_number",
        };
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
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedMeta, model.Meta);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiResponseOfProfileDetail
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingContact = new()
                {
                    Address = "address",
                    Email = "email",
                    Name = "name",
                    Phone = "phone",
                },
                BillingModel = "billing_model",
                Brand = new()
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
                },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Email = "email",
                Icon = "icon",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                Name = "name",
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ShortName = "short_name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WabaID = "waba_id",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
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
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfProfileDetail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiResponseOfProfileDetail
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingContact = new()
                {
                    Address = "address",
                    Email = "email",
                    Name = "name",
                    Phone = "phone",
                },
                BillingModel = "billing_model",
                Brand = new()
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
                },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Email = "email",
                Icon = "icon",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                Name = "name",
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ShortName = "short_name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WabaID = "waba_id",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
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
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfProfileDetail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ProfileDetail expectedData = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = true,
            AllowTemplateSharing = true,
            BillingContact = new()
            {
                Address = "address",
                Email = "email",
                Name = "name",
                Phone = "phone",
            },
            BillingModel = "billing_model",
            Brand = new()
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
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Email = "email",
            Icon = "icon",
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ShortName = "short_name",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WabaID = "waba_id",
            WhatsappPhoneNumber = "whatsapp_phone_number",
        };
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
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedMeta, deserialized.Meta);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiResponseOfProfileDetail
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingContact = new()
                {
                    Address = "address",
                    Email = "email",
                    Name = "name",
                    Phone = "phone",
                },
                BillingModel = "billing_model",
                Brand = new()
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
                },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Email = "email",
                Icon = "icon",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                Name = "name",
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ShortName = "short_name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WabaID = "waba_id",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
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
        var model = new ApiResponseOfProfileDetail
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingContact = new()
                {
                    Address = "address",
                    Email = "email",
                    Name = "name",
                    Phone = "phone",
                },
                BillingModel = "billing_model",
                Brand = new()
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
                },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Email = "email",
                Icon = "icon",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                Name = "name",
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ShortName = "short_name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WabaID = "waba_id",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
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
        var model = new ApiResponseOfProfileDetail
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingContact = new()
                {
                    Address = "address",
                    Email = "email",
                    Name = "name",
                    Phone = "phone",
                },
                BillingModel = "billing_model",
                Brand = new()
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
                },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Email = "email",
                Icon = "icon",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                Name = "name",
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ShortName = "short_name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WabaID = "waba_id",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
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
        var model = new ApiResponseOfProfileDetail
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingContact = new()
                {
                    Address = "address",
                    Email = "email",
                    Name = "name",
                    Phone = "phone",
                },
                BillingModel = "billing_model",
                Brand = new()
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
                },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Email = "email",
                Icon = "icon",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                Name = "name",
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ShortName = "short_name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WabaID = "waba_id",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
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
        var model = new ApiResponseOfProfileDetail
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingContact = new()
                {
                    Address = "address",
                    Email = "email",
                    Name = "name",
                    Phone = "phone",
                },
                BillingModel = "billing_model",
                Brand = new()
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
                },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Email = "email",
                Icon = "icon",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                Name = "name",
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ShortName = "short_name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WabaID = "waba_id",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
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
        var model = new ApiResponseOfProfileDetail
        {
            Meta = new()
            {
                RequestID = "request_id",
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
        var model = new ApiResponseOfProfileDetail
        {
            Meta = new()
            {
                RequestID = "request_id",
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
        var model = new ApiResponseOfProfileDetail
        {
            Meta = new()
            {
                RequestID = "request_id",
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
        var model = new ApiResponseOfProfileDetail
        {
            Meta = new()
            {
                RequestID = "request_id",
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
        var model = new ApiResponseOfProfileDetail
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AllowContactSharing = true,
                AllowNumberChangeDuringOnboarding = true,
                AllowTemplateSharing = true,
                BillingContact = new()
                {
                    Address = "address",
                    Email = "email",
                    Name = "name",
                    Phone = "phone",
                },
                BillingModel = "billing_model",
                Brand = new()
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
                },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Email = "email",
                Icon = "icon",
                InheritContacts = true,
                InheritTcrBrand = true,
                InheritTcrCampaign = true,
                InheritTemplates = true,
                Name = "name",
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingPhoneNumber = "sending_phone_number",
                SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ShortName = "short_name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WabaID = "waba_id",
                WhatsappPhoneNumber = "whatsapp_phone_number",
            },
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
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        ApiResponseOfProfileDetail copied = new(model);

        Assert.Equal(model, copied);
    }
}
