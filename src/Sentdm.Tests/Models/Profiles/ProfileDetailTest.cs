using System;
using System.Text.Json;
using Sentdm.Core;
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
        BrandWithKyc expectedBrand = new()
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
        BrandWithKyc expectedBrand = new()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProfileDetail
        {
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
            Description = "description",
            Email = "email",
            Icon = "icon",
            InheritContacts = true,
            InheritTemplates = true,
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
        Assert.Null(model.BillingModel);
        Assert.False(model.RawData.ContainsKey("billing_model"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.InheritTcrBrand);
        Assert.False(model.RawData.ContainsKey("inherit_tcr_brand"));
        Assert.Null(model.InheritTcrCampaign);
        Assert.False(model.RawData.ContainsKey("inherit_tcr_campaign"));
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
            Description = "description",
            Email = "email",
            Icon = "icon",
            InheritContacts = true,
            InheritTemplates = true,
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
            Description = "description",
            Email = "email",
            Icon = "icon",
            InheritContacts = true,
            InheritTemplates = true,
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
            BillingModel = null,
            CreatedAt = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            Name = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.BillingModel);
        Assert.False(model.RawData.ContainsKey("billing_model"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.InheritTcrBrand);
        Assert.False(model.RawData.ContainsKey("inherit_tcr_brand"));
        Assert.Null(model.InheritTcrCampaign);
        Assert.False(model.RawData.ContainsKey("inherit_tcr_campaign"));
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
            Description = "description",
            Email = "email",
            Icon = "icon",
            InheritContacts = true,
            InheritTemplates = true,
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
            BillingModel = null,
            CreatedAt = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
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
            BillingModel = "billing_model",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            Name = "name",
            Status = "status",
        };

        Assert.Null(model.AllowContactSharing);
        Assert.False(model.RawData.ContainsKey("allow_contact_sharing"));
        Assert.Null(model.AllowNumberChangeDuringOnboarding);
        Assert.False(model.RawData.ContainsKey("allow_number_change_during_onboarding"));
        Assert.Null(model.AllowTemplateSharing);
        Assert.False(model.RawData.ContainsKey("allow_template_sharing"));
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
        Assert.Null(model.InheritContacts);
        Assert.False(model.RawData.ContainsKey("inherit_contacts"));
        Assert.Null(model.InheritTemplates);
        Assert.False(model.RawData.ContainsKey("inherit_templates"));
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
            BillingModel = "billing_model",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
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
            BillingModel = "billing_model",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            Name = "name",
            Status = "status",

            AllowContactSharing = null,
            AllowNumberChangeDuringOnboarding = null,
            AllowTemplateSharing = null,
            BillingContact = null,
            Brand = null,
            Description = null,
            Email = null,
            Icon = null,
            InheritContacts = null,
            InheritTemplates = null,
            OrganizationID = null,
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            SendingWhatsappNumberProfileID = null,
            ShortName = null,
            UpdatedAt = null,
            WabaID = null,
            WhatsappPhoneNumber = null,
        };

        Assert.Null(model.AllowContactSharing);
        Assert.True(model.RawData.ContainsKey("allow_contact_sharing"));
        Assert.Null(model.AllowNumberChangeDuringOnboarding);
        Assert.True(model.RawData.ContainsKey("allow_number_change_during_onboarding"));
        Assert.Null(model.AllowTemplateSharing);
        Assert.True(model.RawData.ContainsKey("allow_template_sharing"));
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
        Assert.Null(model.InheritContacts);
        Assert.True(model.RawData.ContainsKey("inherit_contacts"));
        Assert.Null(model.InheritTemplates);
        Assert.True(model.RawData.ContainsKey("inherit_templates"));
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
            BillingModel = "billing_model",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InheritTcrBrand = true,
            InheritTcrCampaign = true,
            Name = "name",
            Status = "status",

            AllowContactSharing = null,
            AllowNumberChangeDuringOnboarding = null,
            AllowTemplateSharing = null,
            BillingContact = null,
            Brand = null,
            Description = null,
            Email = null,
            Icon = null,
            InheritContacts = null,
            InheritTemplates = null,
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
        };

        ProfileDetail copied = new(model);

        Assert.Equal(model, copied);
    }
}
