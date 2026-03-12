using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class ProfileDetailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileDetail
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

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedAllowContactSharing = true;
        bool expectedAllowNumberChangeDuringOnboarding = true;
        bool expectedAllowTemplateSharing = true;
        BillingContact expectedBillingContact = new()
        {
            Address = "address",
            Email = "email",
            Name = "name",
            Phone = "phone",
        };
        string expectedBillingModel = "billing_model";
        Brand expectedBrand = new()
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
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedEmail = "email";
        string expectedIcon = "icon";
        bool expectedInheritContacts = true;
        bool expectedInheritTcrBrand = true;
        bool expectedInheritTcrCampaign = true;
        bool expectedInheritTemplates = true;
        string expectedName = "name";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedSendingPhoneNumber = "sending_phone_number";
        string expectedSendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedSendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedShortName = "short_name";
        string expectedStatus = "status";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedWabaID = "waba_id";
        string expectedWhatsappPhoneNumber = "whatsapp_phone_number";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAllowContactSharing, model.AllowContactSharing);
        Assert.Equal(
            expectedAllowNumberChangeDuringOnboarding,
            model.AllowNumberChangeDuringOnboarding
        );
        Assert.Equal(expectedAllowTemplateSharing, model.AllowTemplateSharing);
        Assert.Equal(expectedBillingContact, model.BillingContact);
        Assert.Equal(expectedBillingModel, model.BillingModel);
        Assert.Equal(expectedBrand, model.Brand);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedIcon, model.Icon);
        Assert.Equal(expectedInheritContacts, model.InheritContacts);
        Assert.Equal(expectedInheritTcrBrand, model.InheritTcrBrand);
        Assert.Equal(expectedInheritTcrCampaign, model.InheritTcrCampaign);
        Assert.Equal(expectedInheritTemplates, model.InheritTemplates);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.Equal(expectedSendingPhoneNumber, model.SendingPhoneNumber);
        Assert.Equal(expectedSendingPhoneNumberProfileID, model.SendingPhoneNumberProfileID);
        Assert.Equal(expectedSendingWhatsappNumberProfileID, model.SendingWhatsappNumberProfileID);
        Assert.Equal(expectedShortName, model.ShortName);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedWabaID, model.WabaID);
        Assert.Equal(expectedWhatsappPhoneNumber, model.WhatsappPhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProfileDetail
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileDetail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfileDetail
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileDetail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedAllowContactSharing = true;
        bool expectedAllowNumberChangeDuringOnboarding = true;
        bool expectedAllowTemplateSharing = true;
        BillingContact expectedBillingContact = new()
        {
            Address = "address",
            Email = "email",
            Name = "name",
            Phone = "phone",
        };
        string expectedBillingModel = "billing_model";
        Brand expectedBrand = new()
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
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedEmail = "email";
        string expectedIcon = "icon";
        bool expectedInheritContacts = true;
        bool expectedInheritTcrBrand = true;
        bool expectedInheritTcrCampaign = true;
        bool expectedInheritTemplates = true;
        string expectedName = "name";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedSendingPhoneNumber = "sending_phone_number";
        string expectedSendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedSendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedShortName = "short_name";
        string expectedStatus = "status";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedWabaID = "waba_id";
        string expectedWhatsappPhoneNumber = "whatsapp_phone_number";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAllowContactSharing, deserialized.AllowContactSharing);
        Assert.Equal(
            expectedAllowNumberChangeDuringOnboarding,
            deserialized.AllowNumberChangeDuringOnboarding
        );
        Assert.Equal(expectedAllowTemplateSharing, deserialized.AllowTemplateSharing);
        Assert.Equal(expectedBillingContact, deserialized.BillingContact);
        Assert.Equal(expectedBillingModel, deserialized.BillingModel);
        Assert.Equal(expectedBrand, deserialized.Brand);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedIcon, deserialized.Icon);
        Assert.Equal(expectedInheritContacts, deserialized.InheritContacts);
        Assert.Equal(expectedInheritTcrBrand, deserialized.InheritTcrBrand);
        Assert.Equal(expectedInheritTcrCampaign, deserialized.InheritTcrCampaign);
        Assert.Equal(expectedInheritTemplates, deserialized.InheritTemplates);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.Equal(expectedSendingPhoneNumber, deserialized.SendingPhoneNumber);
        Assert.Equal(expectedSendingPhoneNumberProfileID, deserialized.SendingPhoneNumberProfileID);
        Assert.Equal(
            expectedSendingWhatsappNumberProfileID,
            deserialized.SendingWhatsappNumberProfileID
        );
        Assert.Equal(expectedShortName, deserialized.ShortName);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedWabaID, deserialized.WabaID);
        Assert.Equal(expectedWhatsappPhoneNumber, deserialized.WhatsappPhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProfileDetail
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProfileDetail
        {
            AllowNumberChangeDuringOnboarding = true,
            BillingContact = new()
            {
                Address = "address",
                Email = "email",
                Name = "name",
                Phone = "phone",
            },
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
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ShortName = "short_name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WabaID = "waba_id",
            WhatsappPhoneNumber = "whatsapp_phone_number",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AllowContactSharing);
        Assert.False(model.RawData.ContainsKey("allow_contact_sharing"));
        Assert.Null(model.AllowTemplateSharing);
        Assert.False(model.RawData.ContainsKey("allow_template_sharing"));
        Assert.Null(model.BillingModel);
        Assert.False(model.RawData.ContainsKey("billing_model"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.InheritContacts);
        Assert.False(model.RawData.ContainsKey("inherit_contacts"));
        Assert.Null(model.InheritTcrBrand);
        Assert.False(model.RawData.ContainsKey("inherit_tcr_brand"));
        Assert.Null(model.InheritTcrCampaign);
        Assert.False(model.RawData.ContainsKey("inherit_tcr_campaign"));
        Assert.Null(model.InheritTemplates);
        Assert.False(model.RawData.ContainsKey("inherit_templates"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProfileDetail
        {
            AllowNumberChangeDuringOnboarding = true,
            BillingContact = new()
            {
                Address = "address",
                Email = "email",
                Name = "name",
                Phone = "phone",
            },
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
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ShortName = "short_name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WabaID = "waba_id",
            WhatsappPhoneNumber = "whatsapp_phone_number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ProfileDetail
        {
            AllowNumberChangeDuringOnboarding = true,
            BillingContact = new()
            {
                Address = "address",
                Email = "email",
                Name = "name",
                Phone = "phone",
            },
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
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ShortName = "short_name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WabaID = "waba_id",
            WhatsappPhoneNumber = "whatsapp_phone_number",

            // Null should be interpreted as omitted for these properties
            ID = null,
            AllowContactSharing = null,
            AllowTemplateSharing = null,
            BillingModel = null,
            CreatedAt = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
            Name = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AllowContactSharing);
        Assert.False(model.RawData.ContainsKey("allow_contact_sharing"));
        Assert.Null(model.AllowTemplateSharing);
        Assert.False(model.RawData.ContainsKey("allow_template_sharing"));
        Assert.Null(model.BillingModel);
        Assert.False(model.RawData.ContainsKey("billing_model"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.InheritContacts);
        Assert.False(model.RawData.ContainsKey("inherit_contacts"));
        Assert.Null(model.InheritTcrBrand);
        Assert.False(model.RawData.ContainsKey("inherit_tcr_brand"));
        Assert.Null(model.InheritTcrCampaign);
        Assert.False(model.RawData.ContainsKey("inherit_tcr_campaign"));
        Assert.Null(model.InheritTemplates);
        Assert.False(model.RawData.ContainsKey("inherit_templates"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProfileDetail
        {
            AllowNumberChangeDuringOnboarding = true,
            BillingContact = new()
            {
                Address = "address",
                Email = "email",
                Name = "name",
                Phone = "phone",
            },
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
            Description = "description",
            Email = "email",
            Icon = "icon",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingPhoneNumber = "sending_phone_number",
            SendingPhoneNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SendingWhatsappNumberProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ShortName = "short_name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WabaID = "waba_id",
            WhatsappPhoneNumber = "whatsapp_phone_number",

            // Null should be interpreted as omitted for these properties
            ID = null,
            AllowContactSharing = null,
            AllowTemplateSharing = null,
            BillingModel = null,
            CreatedAt = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
            Name = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProfileDetail
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AllowContactSharing = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            Name = "name",
            Status = "status",
        };

        Assert.Null(model.AllowNumberChangeDuringOnboarding);
        Assert.False(model.RawData.ContainsKey("allow_number_change_during_onboarding"));
        Assert.Null(model.BillingContact);
        Assert.False(model.RawData.ContainsKey("billing_contact"));
        Assert.Null(model.Brand);
        Assert.False(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Icon);
        Assert.False(model.RawData.ContainsKey("icon"));
        Assert.Null(model.OrganizationID);
        Assert.False(model.RawData.ContainsKey("organization_id"));
        Assert.Null(model.SendingPhoneNumber);
        Assert.False(model.RawData.ContainsKey("sending_phone_number"));
        Assert.Null(model.SendingPhoneNumberProfileID);
        Assert.False(model.RawData.ContainsKey("sending_phone_number_profile_id"));
        Assert.Null(model.SendingWhatsappNumberProfileID);
        Assert.False(model.RawData.ContainsKey("sending_whatsapp_number_profile_id"));
        Assert.Null(model.ShortName);
        Assert.False(model.RawData.ContainsKey("short_name"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.WabaID);
        Assert.False(model.RawData.ContainsKey("waba_id"));
        Assert.Null(model.WhatsappPhoneNumber);
        Assert.False(model.RawData.ContainsKey("whatsapp_phone_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProfileDetail
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AllowContactSharing = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            Name = "name",
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProfileDetail
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AllowContactSharing = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            Name = "name",
            Status = "status",

            AllowNumberChangeDuringOnboarding = null,
            BillingContact = null,
            Brand = null,
            Description = null,
            Email = null,
            Icon = null,
            OrganizationID = null,
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            SendingWhatsappNumberProfileID = null,
            ShortName = null,
            UpdatedAt = null,
            WabaID = null,
            WhatsappPhoneNumber = null,
        };

        Assert.Null(model.AllowNumberChangeDuringOnboarding);
        Assert.True(model.RawData.ContainsKey("allow_number_change_during_onboarding"));
        Assert.Null(model.BillingContact);
        Assert.True(model.RawData.ContainsKey("billing_contact"));
        Assert.Null(model.Brand);
        Assert.True(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.Icon);
        Assert.True(model.RawData.ContainsKey("icon"));
        Assert.Null(model.OrganizationID);
        Assert.True(model.RawData.ContainsKey("organization_id"));
        Assert.Null(model.SendingPhoneNumber);
        Assert.True(model.RawData.ContainsKey("sending_phone_number"));
        Assert.Null(model.SendingPhoneNumberProfileID);
        Assert.True(model.RawData.ContainsKey("sending_phone_number_profile_id"));
        Assert.Null(model.SendingWhatsappNumberProfileID);
        Assert.True(model.RawData.ContainsKey("sending_whatsapp_number_profile_id"));
        Assert.Null(model.ShortName);
        Assert.True(model.RawData.ContainsKey("short_name"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.WabaID);
        Assert.True(model.RawData.ContainsKey("waba_id"));
        Assert.Null(model.WhatsappPhoneNumber);
        Assert.True(model.RawData.ContainsKey("whatsapp_phone_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProfileDetail
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AllowContactSharing = true,
            AllowTemplateSharing = true,
            BillingModel = "billing_model",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InheritContacts = true,
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            InheritTemplates = true,
            Name = "name",
            Status = "status",

            AllowNumberChangeDuringOnboarding = null,
            BillingContact = null,
            Brand = null,
            Description = null,
            Email = null,
            Icon = null,
            OrganizationID = null,
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            SendingWhatsappNumberProfileID = null,
            ShortName = null,
            UpdatedAt = null,
            WabaID = null,
            WhatsappPhoneNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProfileDetail
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

        ProfileDetail copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BillingContactTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingContact
        {
            Address = "address",
            Email = "email",
            Name = "name",
            Phone = "phone",
        };

        string expectedAddress = "address";
        string expectedEmail = "email";
        string expectedName = "name";
        string expectedPhone = "phone";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPhone, model.Phone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillingContact
        {
            Address = "address",
            Email = "email",
            Name = "name",
            Phone = "phone",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingContact>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillingContact
        {
            Address = "address",
            Email = "email",
            Name = "name",
            Phone = "phone",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingContact>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddress = "address";
        string expectedEmail = "email";
        string expectedName = "name";
        string expectedPhone = "phone";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPhone, deserialized.Phone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillingContact
        {
            Address = "address",
            Email = "email",
            Name = "name",
            Phone = "phone",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BillingContact { };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BillingContact { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BillingContact
        {
            Address = null,
            Email = null,
            Name = null,
            Phone = null,
        };

        Assert.Null(model.Address);
        Assert.True(model.RawData.ContainsKey("address"));
        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.Phone);
        Assert.True(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BillingContact
        {
            Address = null,
            Email = null,
            Name = null,
            Phone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BillingContact
        {
            Address = "address",
            Email = "email",
            Name = "name",
            Phone = "phone",
        };

        BillingContact copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BrandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Brand
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
        Business expectedBusiness = new()
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
        Compliance expectedCompliance = new()
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
        Contact expectedContact = new()
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
        var model = new Brand
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
        var deserialized = JsonSerializer.Deserialize<Brand>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Brand
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
        var deserialized = JsonSerializer.Deserialize<Brand>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Business expectedBusiness = new()
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
        Compliance expectedCompliance = new()
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
        Contact expectedContact = new()
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
        var model = new Brand
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
        var model = new Brand
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
        var model = new Brand
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
        var model = new Brand
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
        var model = new Brand
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
        var model = new Brand
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
        var model = new Brand
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
        var model = new Brand
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
        var model = new Brand
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
        var model = new Brand
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

        Brand copied = new(model);

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
        var model = new Business
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
        var deserialized = JsonSerializer.Deserialize<Business>(
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
        var model = new Business
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
        var model = new Business { };

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

        Business copied = new(model);

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
        var model = new Compliance
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
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            ExpectedMessagingVolume = "expected_messaging_volume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Compliance>(
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
        var model = new Compliance
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
        var model = new Compliance
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
        var model = new Compliance
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
        var model = new Compliance
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
        var model = new Compliance
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
        var model = new Compliance
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
        var model = new Compliance
        {
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Compliance
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
        var model = new Compliance
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
        var model = new Compliance
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
        var model = new Contact
        {
            BusinessName = "business_name",
            Email = "email",
            Name = "name",
            Phone = "phone",
            PhoneCountryCode = "phone_country_code",
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
            BusinessName = "business_name",
            Email = "email",
            Name = "name",
            Phone = "phone",
            PhoneCountryCode = "phone_country_code",
            Role = "role",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contact>(
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
        var model = new Contact
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
        var model = new Contact
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
        var model = new Contact
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
        var model = new Contact
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
        var model = new Contact
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
        var model = new Contact { Name = "name" };

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
        var model = new Contact { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Contact
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
        var model = new Contact
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
        var model = new Contact
        {
            BusinessName = "business_name",
            Email = "email",
            Name = "name",
            Phone = "phone",
            PhoneCountryCode = "phone_country_code",
            Role = "role",
        };

        Contact copied = new(model);

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
