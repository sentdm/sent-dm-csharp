using System;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;
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
                    BrandRelationship = TcrBrandRelationship.SmallAccount,
                    Vertical = TcrVertical.Professional,
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
        BillingContactInfo expectedBillingContact = new()
        {
            Email = "billing@acmecorp.com",
            Name = "Acme Corp",
            Address = "123 Main Street, New York, NY 10001, US",
            Phone = "+12025551234",
        };
        string expectedBillingModel = "profile";
        BrandsBrandData expectedBrand = new()
        {
            Compliance = new()
            {
                BrandRelationship = TcrBrandRelationship.SmallAccount,
                Vertical = TcrVertical.Professional,
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
                    BrandRelationship = TcrBrandRelationship.SmallAccount,
                    Vertical = TcrVertical.Professional,
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
                    BrandRelationship = TcrBrandRelationship.SmallAccount,
                    Vertical = TcrVertical.Professional,
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
                    BrandRelationship = TcrBrandRelationship.SmallAccount,
                    Vertical = TcrVertical.Professional,
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
