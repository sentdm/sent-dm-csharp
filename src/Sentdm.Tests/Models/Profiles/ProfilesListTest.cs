using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Profiles;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Profiles;

public class ProfilesListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfilesList
        {
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
            Profiles =
            [
                new()
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
            ],
        };

        PaginationMeta expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };
        List<ProfileDetail> expectedProfiles =
        [
            new()
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
        ];

        Assert.Equal(expectedPagination, model.Pagination);
        Assert.NotNull(model.Profiles);
        Assert.Equal(expectedProfiles.Count, model.Profiles.Count);
        for (int i = 0; i < expectedProfiles.Count; i++)
        {
            Assert.Equal(expectedProfiles[i], model.Profiles[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProfilesList
        {
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
            Profiles =
            [
                new()
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
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfilesList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfilesList
        {
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
            Profiles =
            [
                new()
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
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfilesList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PaginationMeta expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };
        List<ProfileDetail> expectedProfiles =
        [
            new()
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
        ];

        Assert.Equal(expectedPagination, deserialized.Pagination);
        Assert.NotNull(deserialized.Profiles);
        Assert.Equal(expectedProfiles.Count, deserialized.Profiles.Count);
        for (int i = 0; i < expectedProfiles.Count; i++)
        {
            Assert.Equal(expectedProfiles[i], deserialized.Profiles[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProfilesList
        {
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
            Profiles =
            [
                new()
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
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProfilesList { };

        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
        Assert.Null(model.Profiles);
        Assert.False(model.RawData.ContainsKey("profiles"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProfilesList { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ProfilesList
        {
            // Null should be interpreted as omitted for these properties
            Pagination = null,
            Profiles = null,
        };

        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
        Assert.Null(model.Profiles);
        Assert.False(model.RawData.ContainsKey("profiles"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProfilesList
        {
            // Null should be interpreted as omitted for these properties
            Pagination = null,
            Profiles = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProfilesList
        {
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
            Profiles =
            [
                new()
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
            ],
        };

        ProfilesList copied = new(model);

        Assert.Equal(model, copied);
    }
}
