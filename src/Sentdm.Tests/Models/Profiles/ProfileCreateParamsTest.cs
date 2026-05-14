using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class ProfileCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileCreateParams
        {
            AllowContactSharing = true,
            AllowTemplateSharing = false,
            BillingContact = new()
            {
                Email = "billing@acmecorp.com",
                Name = "Acme Corp",
                Address = "123 Main Street, New York, NY 10001, US",
                Phone = "+12025551234",
            },
            BillingModel = "profile",
            Brand = new()
            {
                Compliance = new()
                {
                    BrandRelationship = BrandRelationship.SmallAccount,
                    Vertical = Vertical.Professional,
                    DestinationCountries = [new() { ID = "US", IsMain = false }],
                    ExpectedMessagingVolume = "10000",
                    IsTcrApplication = true,
                    Notes = null,
                    PhoneNumberPrefix = "+1",
                    PrimaryUseCase = "Customer notifications and appointment reminders",
                },
                Contact = new()
                {
                    Name = "John Smith",
                    BusinessName = "Acme Corp",
                    Email = "john@acmecorp.com",
                    Phone = "+12025551234",
                    PhoneCountryCode = "1",
                    Role = "CEO",
                },
                Business = new()
                {
                    City = "New York",
                    Country = "US",
                    CountryOfRegistration = "US",
                    EntityType = EntityType.PrivateProfit,
                    LegalName = "Acme Corporation LLC",
                    PostalCode = "10001",
                    State = "NY",
                    Street = "123 Main Street",
                    TaxID = "12-3456789",
                    TaxIDType = "us_ein",
                    Url = "https://acmecorp.com",
                },
            },
            Description = "Sales department sender profile",
            Icon = "https://example.com/sales-icon.png",
            InheritContacts = true,
            InheritTcrBrand = false,
            InheritTcrCampaign = false,
            InheritTemplates = true,
            Name = "Sales Team",
            PaymentDetails = new()
            {
                CardNumber = "4111111111111111",
                Cvc = "123",
                Expiry = "09/27",
                ZipCode = "10001",
            },
            Sandbox = false,
            ShortName = "SALES",
            WhatsappBusinessAccount = new()
            {
                AccessToken = "EAAxxxxxxxxxxxxxxx",
                WabaID = "123456789012345",
                PhoneNumberID = "987654321098765",
            },
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        bool expectedAllowContactSharing = true;
        bool expectedAllowTemplateSharing = false;
        BillingContact expectedBillingContact = new()
        {
            Email = "billing@acmecorp.com",
            Name = "Acme Corp",
            Address = "123 Main Street, New York, NY 10001, US",
            Phone = "+12025551234",
        };
        string expectedBillingModel = "profile";
        Brand expectedBrand = new()
        {
            Compliance = new()
            {
                BrandRelationship = BrandRelationship.SmallAccount,
                Vertical = Vertical.Professional,
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PrimaryUseCase = "Customer notifications and appointment reminders",
            },
            Contact = new()
            {
                Name = "John Smith",
                BusinessName = "Acme Corp",
                Email = "john@acmecorp.com",
                Phone = "+12025551234",
                PhoneCountryCode = "1",
                Role = "CEO",
            },
            Business = new()
            {
                City = "New York",
                Country = "US",
                CountryOfRegistration = "US",
                EntityType = EntityType.PrivateProfit,
                LegalName = "Acme Corporation LLC",
                PostalCode = "10001",
                State = "NY",
                Street = "123 Main Street",
                TaxID = "12-3456789",
                TaxIDType = "us_ein",
                Url = "https://acmecorp.com",
            },
        };
        string expectedDescription = "Sales department sender profile";
        string expectedIcon = "https://example.com/sales-icon.png";
        bool expectedInheritContacts = true;
        bool expectedInheritTcrBrand = false;
        bool expectedInheritTcrCampaign = false;
        bool expectedInheritTemplates = true;
        string expectedName = "Sales Team";
        PaymentDetails expectedPaymentDetails = new()
        {
            CardNumber = "4111111111111111",
            Cvc = "123",
            Expiry = "09/27",
            ZipCode = "10001",
        };
        bool expectedSandbox = false;
        string expectedShortName = "SALES";
        WhatsappBusinessAccount expectedWhatsappBusinessAccount = new()
        {
            AccessToken = "EAAxxxxxxxxxxxxxxx",
            WabaID = "123456789012345",
            PhoneNumberID = "987654321098765",
        };
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedAllowContactSharing, parameters.AllowContactSharing);
        Assert.Equal(expectedAllowTemplateSharing, parameters.AllowTemplateSharing);
        Assert.Equal(expectedBillingContact, parameters.BillingContact);
        Assert.Equal(expectedBillingModel, parameters.BillingModel);
        Assert.Equal(expectedBrand, parameters.Brand);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedIcon, parameters.Icon);
        Assert.Equal(expectedInheritContacts, parameters.InheritContacts);
        Assert.Equal(expectedInheritTcrBrand, parameters.InheritTcrBrand);
        Assert.Equal(expectedInheritTcrCampaign, parameters.InheritTcrCampaign);
        Assert.Equal(expectedInheritTemplates, parameters.InheritTemplates);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPaymentDetails, parameters.PaymentDetails);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedShortName, parameters.ShortName);
        Assert.Equal(expectedWhatsappBusinessAccount, parameters.WhatsappBusinessAccount);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProfileCreateParams
        {
            BillingContact = new()
            {
                Email = "billing@acmecorp.com",
                Name = "Acme Corp",
                Address = "123 Main Street, New York, NY 10001, US",
                Phone = "+12025551234",
            },
            BillingModel = "profile",
            Brand = new()
            {
                Compliance = new()
                {
                    BrandRelationship = BrandRelationship.SmallAccount,
                    Vertical = Vertical.Professional,
                    DestinationCountries = [new() { ID = "US", IsMain = false }],
                    ExpectedMessagingVolume = "10000",
                    IsTcrApplication = true,
                    Notes = null,
                    PhoneNumberPrefix = "+1",
                    PrimaryUseCase = "Customer notifications and appointment reminders",
                },
                Contact = new()
                {
                    Name = "John Smith",
                    BusinessName = "Acme Corp",
                    Email = "john@acmecorp.com",
                    Phone = "+12025551234",
                    PhoneCountryCode = "1",
                    Role = "CEO",
                },
                Business = new()
                {
                    City = "New York",
                    Country = "US",
                    CountryOfRegistration = "US",
                    EntityType = EntityType.PrivateProfit,
                    LegalName = "Acme Corporation LLC",
                    PostalCode = "10001",
                    State = "NY",
                    Street = "123 Main Street",
                    TaxID = "12-3456789",
                    TaxIDType = "us_ein",
                    Url = "https://acmecorp.com",
                },
            },
            Description = "Sales department sender profile",
            Icon = "https://example.com/sales-icon.png",
            InheritContacts = true,
            InheritTcrBrand = false,
            InheritTcrCampaign = false,
            InheritTemplates = true,
            PaymentDetails = new()
            {
                CardNumber = "4111111111111111",
                Cvc = "123",
                Expiry = "09/27",
                ZipCode = "10001",
            },
            ShortName = "SALES",
            WhatsappBusinessAccount = new()
            {
                AccessToken = "EAAxxxxxxxxxxxxxxx",
                WabaID = "123456789012345",
                PhoneNumberID = "987654321098765",
            },
        };

        Assert.Null(parameters.AllowContactSharing);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_contact_sharing"));
        Assert.Null(parameters.AllowTemplateSharing);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_template_sharing"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProfileCreateParams
        {
            BillingContact = new()
            {
                Email = "billing@acmecorp.com",
                Name = "Acme Corp",
                Address = "123 Main Street, New York, NY 10001, US",
                Phone = "+12025551234",
            },
            BillingModel = "profile",
            Brand = new()
            {
                Compliance = new()
                {
                    BrandRelationship = BrandRelationship.SmallAccount,
                    Vertical = Vertical.Professional,
                    DestinationCountries = [new() { ID = "US", IsMain = false }],
                    ExpectedMessagingVolume = "10000",
                    IsTcrApplication = true,
                    Notes = null,
                    PhoneNumberPrefix = "+1",
                    PrimaryUseCase = "Customer notifications and appointment reminders",
                },
                Contact = new()
                {
                    Name = "John Smith",
                    BusinessName = "Acme Corp",
                    Email = "john@acmecorp.com",
                    Phone = "+12025551234",
                    PhoneCountryCode = "1",
                    Role = "CEO",
                },
                Business = new()
                {
                    City = "New York",
                    Country = "US",
                    CountryOfRegistration = "US",
                    EntityType = EntityType.PrivateProfit,
                    LegalName = "Acme Corporation LLC",
                    PostalCode = "10001",
                    State = "NY",
                    Street = "123 Main Street",
                    TaxID = "12-3456789",
                    TaxIDType = "us_ein",
                    Url = "https://acmecorp.com",
                },
            },
            Description = "Sales department sender profile",
            Icon = "https://example.com/sales-icon.png",
            InheritContacts = true,
            InheritTcrBrand = false,
            InheritTcrCampaign = false,
            InheritTemplates = true,
            PaymentDetails = new()
            {
                CardNumber = "4111111111111111",
                Cvc = "123",
                Expiry = "09/27",
                ZipCode = "10001",
            },
            ShortName = "SALES",
            WhatsappBusinessAccount = new()
            {
                AccessToken = "EAAxxxxxxxxxxxxxxx",
                WabaID = "123456789012345",
                PhoneNumberID = "987654321098765",
            },

            // Null should be interpreted as omitted for these properties
            AllowContactSharing = null,
            AllowTemplateSharing = null,
            Name = null,
            Sandbox = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.AllowContactSharing);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_contact_sharing"));
        Assert.Null(parameters.AllowTemplateSharing);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_template_sharing"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProfileCreateParams
        {
            AllowContactSharing = true,
            AllowTemplateSharing = false,
            Name = "Sales Team",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.BillingContact);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_contact"));
        Assert.Null(parameters.BillingModel);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_model"));
        Assert.Null(parameters.Brand);
        Assert.False(parameters.RawBodyData.ContainsKey("brand"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Icon);
        Assert.False(parameters.RawBodyData.ContainsKey("icon"));
        Assert.Null(parameters.InheritContacts);
        Assert.False(parameters.RawBodyData.ContainsKey("inherit_contacts"));
        Assert.Null(parameters.InheritTcrBrand);
        Assert.False(parameters.RawBodyData.ContainsKey("inherit_tcr_brand"));
        Assert.Null(parameters.InheritTcrCampaign);
        Assert.False(parameters.RawBodyData.ContainsKey("inherit_tcr_campaign"));
        Assert.Null(parameters.InheritTemplates);
        Assert.False(parameters.RawBodyData.ContainsKey("inherit_templates"));
        Assert.Null(parameters.PaymentDetails);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_details"));
        Assert.Null(parameters.ShortName);
        Assert.False(parameters.RawBodyData.ContainsKey("short_name"));
        Assert.Null(parameters.WhatsappBusinessAccount);
        Assert.False(parameters.RawBodyData.ContainsKey("whatsapp_business_account"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ProfileCreateParams
        {
            AllowContactSharing = true,
            AllowTemplateSharing = false,
            Name = "Sales Team",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            BillingContact = null,
            BillingModel = null,
            Brand = null,
            Description = null,
            Icon = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
            PaymentDetails = null,
            ShortName = null,
            WhatsappBusinessAccount = null,
        };

        Assert.Null(parameters.BillingContact);
        Assert.True(parameters.RawBodyData.ContainsKey("billing_contact"));
        Assert.Null(parameters.BillingModel);
        Assert.True(parameters.RawBodyData.ContainsKey("billing_model"));
        Assert.Null(parameters.Brand);
        Assert.True(parameters.RawBodyData.ContainsKey("brand"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Icon);
        Assert.True(parameters.RawBodyData.ContainsKey("icon"));
        Assert.Null(parameters.InheritContacts);
        Assert.True(parameters.RawBodyData.ContainsKey("inherit_contacts"));
        Assert.Null(parameters.InheritTcrBrand);
        Assert.True(parameters.RawBodyData.ContainsKey("inherit_tcr_brand"));
        Assert.Null(parameters.InheritTcrCampaign);
        Assert.True(parameters.RawBodyData.ContainsKey("inherit_tcr_campaign"));
        Assert.Null(parameters.InheritTemplates);
        Assert.True(parameters.RawBodyData.ContainsKey("inherit_templates"));
        Assert.Null(parameters.PaymentDetails);
        Assert.True(parameters.RawBodyData.ContainsKey("payment_details"));
        Assert.Null(parameters.ShortName);
        Assert.True(parameters.RawBodyData.ContainsKey("short_name"));
        Assert.Null(parameters.WhatsappBusinessAccount);
        Assert.True(parameters.RawBodyData.ContainsKey("whatsapp_business_account"));
    }

    [Fact]
    public void Url_Works()
    {
        ProfileCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.sent.dm/v3/profiles"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ProfileCreateParams parameters = new()
        {
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
        Assert.Equal(
            ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            requestMessage.Headers.GetValues("x-profile-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProfileCreateParams
        {
            AllowContactSharing = true,
            AllowTemplateSharing = false,
            BillingContact = new()
            {
                Email = "billing@acmecorp.com",
                Name = "Acme Corp",
                Address = "123 Main Street, New York, NY 10001, US",
                Phone = "+12025551234",
            },
            BillingModel = "profile",
            Brand = new()
            {
                Compliance = new()
                {
                    BrandRelationship = BrandRelationship.SmallAccount,
                    Vertical = Vertical.Professional,
                    DestinationCountries = [new() { ID = "US", IsMain = false }],
                    ExpectedMessagingVolume = "10000",
                    IsTcrApplication = true,
                    Notes = null,
                    PhoneNumberPrefix = "+1",
                    PrimaryUseCase = "Customer notifications and appointment reminders",
                },
                Contact = new()
                {
                    Name = "John Smith",
                    BusinessName = "Acme Corp",
                    Email = "john@acmecorp.com",
                    Phone = "+12025551234",
                    PhoneCountryCode = "1",
                    Role = "CEO",
                },
                Business = new()
                {
                    City = "New York",
                    Country = "US",
                    CountryOfRegistration = "US",
                    EntityType = EntityType.PrivateProfit,
                    LegalName = "Acme Corporation LLC",
                    PostalCode = "10001",
                    State = "NY",
                    Street = "123 Main Street",
                    TaxID = "12-3456789",
                    TaxIDType = "us_ein",
                    Url = "https://acmecorp.com",
                },
            },
            Description = "Sales department sender profile",
            Icon = "https://example.com/sales-icon.png",
            InheritContacts = true,
            InheritTcrBrand = false,
            InheritTcrCampaign = false,
            InheritTemplates = true,
            Name = "Sales Team",
            PaymentDetails = new()
            {
                CardNumber = "4111111111111111",
                Cvc = "123",
                Expiry = "09/27",
                ZipCode = "10001",
            },
            Sandbox = false,
            ShortName = "SALES",
            WhatsappBusinessAccount = new()
            {
                AccessToken = "EAAxxxxxxxxxxxxxxx",
                WabaID = "123456789012345",
                PhoneNumberID = "987654321098765",
            },
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ProfileCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BillingContactTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingContact
        {
            Email = "billing@acmecorp.com",
            Name = "Acme Corp",
            Address = "123 Main Street, New York, NY 10001, US",
            Phone = "+12025551234",
        };

        string expectedEmail = "billing@acmecorp.com";
        string expectedName = "Acme Corp";
        string expectedAddress = "123 Main Street, New York, NY 10001, US";
        string expectedPhone = "+12025551234";

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedPhone, model.Phone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillingContact
        {
            Email = "billing@acmecorp.com",
            Name = "Acme Corp",
            Address = "123 Main Street, New York, NY 10001, US",
            Phone = "+12025551234",
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
            Email = "billing@acmecorp.com",
            Name = "Acme Corp",
            Address = "123 Main Street, New York, NY 10001, US",
            Phone = "+12025551234",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingContact>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "billing@acmecorp.com";
        string expectedName = "Acme Corp";
        string expectedAddress = "123 Main Street, New York, NY 10001, US";
        string expectedPhone = "+12025551234";

        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedPhone, deserialized.Phone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillingContact
        {
            Email = "billing@acmecorp.com",
            Name = "Acme Corp",
            Address = "123 Main Street, New York, NY 10001, US",
            Phone = "+12025551234",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BillingContact { Email = "billing@acmecorp.com", Name = "Acme Corp" };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BillingContact { Email = "billing@acmecorp.com", Name = "Acme Corp" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BillingContact
        {
            Email = "billing@acmecorp.com",
            Name = "Acme Corp",

            Address = null,
            Phone = null,
        };

        Assert.Null(model.Address);
        Assert.True(model.RawData.ContainsKey("address"));
        Assert.Null(model.Phone);
        Assert.True(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BillingContact
        {
            Email = "billing@acmecorp.com",
            Name = "Acme Corp",

            Address = null,
            Phone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BillingContact
        {
            Email = "billing@acmecorp.com",
            Name = "Acme Corp",
            Address = "123 Main Street, New York, NY 10001, US",
            Phone = "+12025551234",
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
            Compliance = new()
            {
                BrandRelationship = BrandRelationship.SmallAccount,
                Vertical = Vertical.Professional,
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PrimaryUseCase = "Customer notifications and appointment reminders",
            },
            Contact = new()
            {
                Name = "John Smith",
                BusinessName = "Acme Corp",
                Email = "john@acmecorp.com",
                Phone = "+12025551234",
                PhoneCountryCode = "1",
                Role = "CEO",
            },
            Business = new()
            {
                City = "New York",
                Country = "US",
                CountryOfRegistration = "US",
                EntityType = EntityType.PrivateProfit,
                LegalName = "Acme Corporation LLC",
                PostalCode = "10001",
                State = "NY",
                Street = "123 Main Street",
                TaxID = "12-3456789",
                TaxIDType = "us_ein",
                Url = "https://acmecorp.com",
            },
        };

        Compliance expectedCompliance = new()
        {
            BrandRelationship = BrandRelationship.SmallAccount,
            Vertical = Vertical.Professional,
            DestinationCountries = [new() { ID = "US", IsMain = false }],
            ExpectedMessagingVolume = "10000",
            IsTcrApplication = true,
            Notes = null,
            PhoneNumberPrefix = "+1",
            PrimaryUseCase = "Customer notifications and appointment reminders",
        };
        Contact expectedContact = new()
        {
            Name = "John Smith",
            BusinessName = "Acme Corp",
            Email = "john@acmecorp.com",
            Phone = "+12025551234",
            PhoneCountryCode = "1",
            Role = "CEO",
        };
        Business expectedBusiness = new()
        {
            City = "New York",
            Country = "US",
            CountryOfRegistration = "US",
            EntityType = EntityType.PrivateProfit,
            LegalName = "Acme Corporation LLC",
            PostalCode = "10001",
            State = "NY",
            Street = "123 Main Street",
            TaxID = "12-3456789",
            TaxIDType = "us_ein",
            Url = "https://acmecorp.com",
        };

        Assert.Equal(expectedCompliance, model.Compliance);
        Assert.Equal(expectedContact, model.Contact);
        Assert.Equal(expectedBusiness, model.Business);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Brand
        {
            Compliance = new()
            {
                BrandRelationship = BrandRelationship.SmallAccount,
                Vertical = Vertical.Professional,
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PrimaryUseCase = "Customer notifications and appointment reminders",
            },
            Contact = new()
            {
                Name = "John Smith",
                BusinessName = "Acme Corp",
                Email = "john@acmecorp.com",
                Phone = "+12025551234",
                PhoneCountryCode = "1",
                Role = "CEO",
            },
            Business = new()
            {
                City = "New York",
                Country = "US",
                CountryOfRegistration = "US",
                EntityType = EntityType.PrivateProfit,
                LegalName = "Acme Corporation LLC",
                PostalCode = "10001",
                State = "NY",
                Street = "123 Main Street",
                TaxID = "12-3456789",
                TaxIDType = "us_ein",
                Url = "https://acmecorp.com",
            },
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
            Compliance = new()
            {
                BrandRelationship = BrandRelationship.SmallAccount,
                Vertical = Vertical.Professional,
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PrimaryUseCase = "Customer notifications and appointment reminders",
            },
            Contact = new()
            {
                Name = "John Smith",
                BusinessName = "Acme Corp",
                Email = "john@acmecorp.com",
                Phone = "+12025551234",
                PhoneCountryCode = "1",
                Role = "CEO",
            },
            Business = new()
            {
                City = "New York",
                Country = "US",
                CountryOfRegistration = "US",
                EntityType = EntityType.PrivateProfit,
                LegalName = "Acme Corporation LLC",
                PostalCode = "10001",
                State = "NY",
                Street = "123 Main Street",
                TaxID = "12-3456789",
                TaxIDType = "us_ein",
                Url = "https://acmecorp.com",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Brand>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        Compliance expectedCompliance = new()
        {
            BrandRelationship = BrandRelationship.SmallAccount,
            Vertical = Vertical.Professional,
            DestinationCountries = [new() { ID = "US", IsMain = false }],
            ExpectedMessagingVolume = "10000",
            IsTcrApplication = true,
            Notes = null,
            PhoneNumberPrefix = "+1",
            PrimaryUseCase = "Customer notifications and appointment reminders",
        };
        Contact expectedContact = new()
        {
            Name = "John Smith",
            BusinessName = "Acme Corp",
            Email = "john@acmecorp.com",
            Phone = "+12025551234",
            PhoneCountryCode = "1",
            Role = "CEO",
        };
        Business expectedBusiness = new()
        {
            City = "New York",
            Country = "US",
            CountryOfRegistration = "US",
            EntityType = EntityType.PrivateProfit,
            LegalName = "Acme Corporation LLC",
            PostalCode = "10001",
            State = "NY",
            Street = "123 Main Street",
            TaxID = "12-3456789",
            TaxIDType = "us_ein",
            Url = "https://acmecorp.com",
        };

        Assert.Equal(expectedCompliance, deserialized.Compliance);
        Assert.Equal(expectedContact, deserialized.Contact);
        Assert.Equal(expectedBusiness, deserialized.Business);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Brand
        {
            Compliance = new()
            {
                BrandRelationship = BrandRelationship.SmallAccount,
                Vertical = Vertical.Professional,
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PrimaryUseCase = "Customer notifications and appointment reminders",
            },
            Contact = new()
            {
                Name = "John Smith",
                BusinessName = "Acme Corp",
                Email = "john@acmecorp.com",
                Phone = "+12025551234",
                PhoneCountryCode = "1",
                Role = "CEO",
            },
            Business = new()
            {
                City = "New York",
                Country = "US",
                CountryOfRegistration = "US",
                EntityType = EntityType.PrivateProfit,
                LegalName = "Acme Corporation LLC",
                PostalCode = "10001",
                State = "NY",
                Street = "123 Main Street",
                TaxID = "12-3456789",
                TaxIDType = "us_ein",
                Url = "https://acmecorp.com",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Brand
        {
            Compliance = new()
            {
                BrandRelationship = BrandRelationship.SmallAccount,
                Vertical = Vertical.Professional,
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PrimaryUseCase = "Customer notifications and appointment reminders",
            },
            Contact = new()
            {
                Name = "John Smith",
                BusinessName = "Acme Corp",
                Email = "john@acmecorp.com",
                Phone = "+12025551234",
                PhoneCountryCode = "1",
                Role = "CEO",
            },
        };

        Assert.Null(model.Business);
        Assert.False(model.RawData.ContainsKey("business"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Brand
        {
            Compliance = new()
            {
                BrandRelationship = BrandRelationship.SmallAccount,
                Vertical = Vertical.Professional,
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PrimaryUseCase = "Customer notifications and appointment reminders",
            },
            Contact = new()
            {
                Name = "John Smith",
                BusinessName = "Acme Corp",
                Email = "john@acmecorp.com",
                Phone = "+12025551234",
                PhoneCountryCode = "1",
                Role = "CEO",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Brand
        {
            Compliance = new()
            {
                BrandRelationship = BrandRelationship.SmallAccount,
                Vertical = Vertical.Professional,
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PrimaryUseCase = "Customer notifications and appointment reminders",
            },
            Contact = new()
            {
                Name = "John Smith",
                BusinessName = "Acme Corp",
                Email = "john@acmecorp.com",
                Phone = "+12025551234",
                PhoneCountryCode = "1",
                Role = "CEO",
            },

            Business = null,
        };

        Assert.Null(model.Business);
        Assert.True(model.RawData.ContainsKey("business"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Brand
        {
            Compliance = new()
            {
                BrandRelationship = BrandRelationship.SmallAccount,
                Vertical = Vertical.Professional,
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PrimaryUseCase = "Customer notifications and appointment reminders",
            },
            Contact = new()
            {
                Name = "John Smith",
                BusinessName = "Acme Corp",
                Email = "john@acmecorp.com",
                Phone = "+12025551234",
                PhoneCountryCode = "1",
                Role = "CEO",
            },

            Business = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Brand
        {
            Compliance = new()
            {
                BrandRelationship = BrandRelationship.SmallAccount,
                Vertical = Vertical.Professional,
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PrimaryUseCase = "Customer notifications and appointment reminders",
            },
            Contact = new()
            {
                Name = "John Smith",
                BusinessName = "Acme Corp",
                Email = "john@acmecorp.com",
                Phone = "+12025551234",
                PhoneCountryCode = "1",
                Role = "CEO",
            },
            Business = new()
            {
                City = "New York",
                Country = "US",
                CountryOfRegistration = "US",
                EntityType = EntityType.PrivateProfit,
                LegalName = "Acme Corporation LLC",
                PostalCode = "10001",
                State = "NY",
                Street = "123 Main Street",
                TaxID = "12-3456789",
                TaxIDType = "us_ein",
                Url = "https://acmecorp.com",
            },
        };

        Brand copied = new(model);

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
            BrandRelationship = BrandRelationship.BasicAccount,
            Vertical = Vertical.Professional,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PrimaryUseCase = "primaryUseCase",
        };

        ApiEnum<string, BrandRelationship> expectedBrandRelationship =
            BrandRelationship.BasicAccount;
        ApiEnum<string, Vertical> expectedVertical = Vertical.Professional;
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
            BrandRelationship = BrandRelationship.BasicAccount,
            Vertical = Vertical.Professional,
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
            BrandRelationship = BrandRelationship.BasicAccount,
            Vertical = Vertical.Professional,
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

        ApiEnum<string, BrandRelationship> expectedBrandRelationship =
            BrandRelationship.BasicAccount;
        ApiEnum<string, Vertical> expectedVertical = Vertical.Professional;
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
            BrandRelationship = BrandRelationship.BasicAccount,
            Vertical = Vertical.Professional,
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
            BrandRelationship = BrandRelationship.BasicAccount,
            Vertical = Vertical.Professional,
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
            BrandRelationship = BrandRelationship.BasicAccount,
            Vertical = Vertical.Professional,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Compliance
        {
            BrandRelationship = BrandRelationship.BasicAccount,
            Vertical = Vertical.Professional,

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
            BrandRelationship = BrandRelationship.BasicAccount,
            Vertical = Vertical.Professional,

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
            BrandRelationship = BrandRelationship.BasicAccount,
            Vertical = Vertical.Professional,
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

public class BrandRelationshipTest : TestBase
{
    [Theory]
    [InlineData(BrandRelationship.BasicAccount)]
    [InlineData(BrandRelationship.MediumAccount)]
    [InlineData(BrandRelationship.LargeAccount)]
    [InlineData(BrandRelationship.SmallAccount)]
    [InlineData(BrandRelationship.KeyAccount)]
    public void Validation_Works(BrandRelationship rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BrandRelationship> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BrandRelationship>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BrandRelationship.BasicAccount)]
    [InlineData(BrandRelationship.MediumAccount)]
    [InlineData(BrandRelationship.LargeAccount)]
    [InlineData(BrandRelationship.SmallAccount)]
    [InlineData(BrandRelationship.KeyAccount)]
    public void SerializationRoundtrip_Works(BrandRelationship rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BrandRelationship> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BrandRelationship>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BrandRelationship>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BrandRelationship>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VerticalTest : TestBase
{
    [Theory]
    [InlineData(Vertical.Professional)]
    [InlineData(Vertical.RealEstate)]
    [InlineData(Vertical.Healthcare)]
    [InlineData(Vertical.HumanResources)]
    [InlineData(Vertical.Energy)]
    [InlineData(Vertical.Entertainment)]
    [InlineData(Vertical.Retail)]
    [InlineData(Vertical.Transportation)]
    [InlineData(Vertical.Agriculture)]
    [InlineData(Vertical.Insurance)]
    [InlineData(Vertical.Postal)]
    [InlineData(Vertical.Education)]
    [InlineData(Vertical.Hospitality)]
    [InlineData(Vertical.Financial)]
    [InlineData(Vertical.Political)]
    [InlineData(Vertical.Gambling)]
    [InlineData(Vertical.Legal)]
    [InlineData(Vertical.Construction)]
    [InlineData(Vertical.Ngo)]
    [InlineData(Vertical.Manufacturing)]
    [InlineData(Vertical.Government)]
    [InlineData(Vertical.Technology)]
    [InlineData(Vertical.Communication)]
    public void Validation_Works(Vertical rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Vertical> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Vertical>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Vertical.Professional)]
    [InlineData(Vertical.RealEstate)]
    [InlineData(Vertical.Healthcare)]
    [InlineData(Vertical.HumanResources)]
    [InlineData(Vertical.Energy)]
    [InlineData(Vertical.Entertainment)]
    [InlineData(Vertical.Retail)]
    [InlineData(Vertical.Transportation)]
    [InlineData(Vertical.Agriculture)]
    [InlineData(Vertical.Insurance)]
    [InlineData(Vertical.Postal)]
    [InlineData(Vertical.Education)]
    [InlineData(Vertical.Hospitality)]
    [InlineData(Vertical.Financial)]
    [InlineData(Vertical.Political)]
    [InlineData(Vertical.Gambling)]
    [InlineData(Vertical.Legal)]
    [InlineData(Vertical.Construction)]
    [InlineData(Vertical.Ngo)]
    [InlineData(Vertical.Manufacturing)]
    [InlineData(Vertical.Government)]
    [InlineData(Vertical.Technology)]
    [InlineData(Vertical.Communication)]
    public void SerializationRoundtrip_Works(Vertical rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Vertical> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Vertical>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Vertical>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Vertical>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DestinationCountryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DestinationCountry { ID = "id", IsMain = true };

        string expectedID = "id";
        bool expectedIsMain = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedIsMain, model.IsMain);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DestinationCountry { ID = "id", IsMain = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DestinationCountry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DestinationCountry { ID = "id", IsMain = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DestinationCountry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        bool expectedIsMain = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedIsMain, deserialized.IsMain);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DestinationCountry { ID = "id", IsMain = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DestinationCountry { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.IsMain);
        Assert.False(model.RawData.ContainsKey("isMain"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DestinationCountry { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DestinationCountry
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            IsMain = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.IsMain);
        Assert.False(model.RawData.ContainsKey("isMain"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DestinationCountry
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            IsMain = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DestinationCountry { ID = "id", IsMain = true };

        DestinationCountry copied = new(model);

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
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
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

public class PaymentDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaymentDetails
        {
            CardNumber = "4111111111111111",
            Cvc = "123",
            Expiry = "09/27",
            ZipCode = "10001",
        };

        string expectedCardNumber = "4111111111111111";
        string expectedCvc = "123";
        string expectedExpiry = "09/27";
        string expectedZipCode = "10001";

        Assert.Equal(expectedCardNumber, model.CardNumber);
        Assert.Equal(expectedCvc, model.Cvc);
        Assert.Equal(expectedExpiry, model.Expiry);
        Assert.Equal(expectedZipCode, model.ZipCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PaymentDetails
        {
            CardNumber = "4111111111111111",
            Cvc = "123",
            Expiry = "09/27",
            ZipCode = "10001",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaymentDetails
        {
            CardNumber = "4111111111111111",
            Cvc = "123",
            Expiry = "09/27",
            ZipCode = "10001",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCardNumber = "4111111111111111";
        string expectedCvc = "123";
        string expectedExpiry = "09/27";
        string expectedZipCode = "10001";

        Assert.Equal(expectedCardNumber, deserialized.CardNumber);
        Assert.Equal(expectedCvc, deserialized.Cvc);
        Assert.Equal(expectedExpiry, deserialized.Expiry);
        Assert.Equal(expectedZipCode, deserialized.ZipCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PaymentDetails
        {
            CardNumber = "4111111111111111",
            Cvc = "123",
            Expiry = "09/27",
            ZipCode = "10001",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PaymentDetails
        {
            CardNumber = "4111111111111111",
            Cvc = "123",
            Expiry = "09/27",
            ZipCode = "10001",
        };

        PaymentDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WhatsappBusinessAccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WhatsappBusinessAccount
        {
            AccessToken = "EAAxxxxxxxxxxxxxxx",
            WabaID = "123456789012345",
            PhoneNumberID = "987654321098765",
        };

        string expectedAccessToken = "EAAxxxxxxxxxxxxxxx";
        string expectedWabaID = "123456789012345";
        string expectedPhoneNumberID = "987654321098765";

        Assert.Equal(expectedAccessToken, model.AccessToken);
        Assert.Equal(expectedWabaID, model.WabaID);
        Assert.Equal(expectedPhoneNumberID, model.PhoneNumberID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WhatsappBusinessAccount
        {
            AccessToken = "EAAxxxxxxxxxxxxxxx",
            WabaID = "123456789012345",
            PhoneNumberID = "987654321098765",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsappBusinessAccount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WhatsappBusinessAccount
        {
            AccessToken = "EAAxxxxxxxxxxxxxxx",
            WabaID = "123456789012345",
            PhoneNumberID = "987654321098765",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsappBusinessAccount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccessToken = "EAAxxxxxxxxxxxxxxx";
        string expectedWabaID = "123456789012345";
        string expectedPhoneNumberID = "987654321098765";

        Assert.Equal(expectedAccessToken, deserialized.AccessToken);
        Assert.Equal(expectedWabaID, deserialized.WabaID);
        Assert.Equal(expectedPhoneNumberID, deserialized.PhoneNumberID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WhatsappBusinessAccount
        {
            AccessToken = "EAAxxxxxxxxxxxxxxx",
            WabaID = "123456789012345",
            PhoneNumberID = "987654321098765",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WhatsappBusinessAccount
        {
            AccessToken = "EAAxxxxxxxxxxxxxxx",
            WabaID = "123456789012345",
        };

        Assert.Null(model.PhoneNumberID);
        Assert.False(model.RawData.ContainsKey("phone_number_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WhatsappBusinessAccount
        {
            AccessToken = "EAAxxxxxxxxxxxxxxx",
            WabaID = "123456789012345",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WhatsappBusinessAccount
        {
            AccessToken = "EAAxxxxxxxxxxxxxxx",
            WabaID = "123456789012345",

            PhoneNumberID = null,
        };

        Assert.Null(model.PhoneNumberID);
        Assert.True(model.RawData.ContainsKey("phone_number_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WhatsappBusinessAccount
        {
            AccessToken = "EAAxxxxxxxxxxxxxxx",
            WabaID = "123456789012345",

            PhoneNumberID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WhatsappBusinessAccount
        {
            AccessToken = "EAAxxxxxxxxxxxxxxx",
            WabaID = "123456789012345",
            PhoneNumberID = "987654321098765",
        };

        WhatsappBusinessAccount copied = new(model);

        Assert.Equal(model, copied);
    }
}
