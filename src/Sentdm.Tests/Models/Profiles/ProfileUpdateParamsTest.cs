using System;
using System.Net.Http;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class ProfileUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            ProfileID = "profileId",
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = null,
            AllowTemplateSharing = null,
            BillingContact = new()
            {
                Email = "dev@stainless.com",
                Name = "x",
                Address = "address",
                Phone = "phone",
            },
            BillingModel = "organization",
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
            Description = "Updated sales department sender profile",
            Icon = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
            Name = "Sales Team - Updated",
            PaymentDetails = new()
            {
                CardNumber = "3216699102256101",
                Cvc = "3216",
                Expiry = "11/66",
                ZipCode = "x",
            },
            Sandbox = false,
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            SendingWhatsappNumberProfileID = null,
            ShortName = "SALES",
            WhatsappPhoneNumber = null,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedProfileID = "profileId";
        bool expectedAllowContactSharing = true;
        BillingContactInfo expectedBillingContact = new()
        {
            Email = "dev@stainless.com",
            Name = "x",
            Address = "address",
            Phone = "phone",
        };
        string expectedBillingModel = "organization";
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
        string expectedDescription = "Updated sales department sender profile";
        string expectedName = "Sales Team - Updated";
        PaymentDetails expectedPaymentDetails = new()
        {
            CardNumber = "3216699102256101",
            Cvc = "3216",
            Expiry = "11/66",
            ZipCode = "x",
        };
        bool expectedSandbox = false;
        string expectedShortName = "SALES";
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedProfileID, parameters.ProfileID);
        Assert.Equal(expectedAllowContactSharing, parameters.AllowContactSharing);
        Assert.Null(parameters.AllowNumberChangeDuringOnboarding);
        Assert.Null(parameters.AllowTemplateSharing);
        Assert.Equal(expectedBillingContact, parameters.BillingContact);
        Assert.Equal(expectedBillingModel, parameters.BillingModel);
        Assert.Equal(expectedBrand, parameters.Brand);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Null(parameters.Icon);
        Assert.Null(parameters.InheritContacts);
        Assert.Null(parameters.InheritTcrBrand);
        Assert.Null(parameters.InheritTcrCampaign);
        Assert.Null(parameters.InheritTemplates);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPaymentDetails, parameters.PaymentDetails);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Null(parameters.SendingPhoneNumber);
        Assert.Null(parameters.SendingPhoneNumberProfileID);
        Assert.Null(parameters.SendingWhatsappNumberProfileID);
        Assert.Equal(expectedShortName, parameters.ShortName);
        Assert.Null(parameters.WhatsappPhoneNumber);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            ProfileID = "profileId",
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = null,
            AllowTemplateSharing = null,
            BillingContact = new()
            {
                Email = "dev@stainless.com",
                Name = "x",
                Address = "address",
                Phone = "phone",
            },
            BillingModel = "organization",
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
            Description = "Updated sales department sender profile",
            Icon = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
            Name = "Sales Team - Updated",
            PaymentDetails = new()
            {
                CardNumber = "3216699102256101",
                Cvc = "3216",
                Expiry = "11/66",
                ZipCode = "x",
            },
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            SendingWhatsappNumberProfileID = null,
            ShortName = "SALES",
            WhatsappPhoneNumber = null,
        };

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
        var parameters = new ProfileUpdateParams
        {
            ProfileID = "profileId",
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = null,
            AllowTemplateSharing = null,
            BillingContact = new()
            {
                Email = "dev@stainless.com",
                Name = "x",
                Address = "address",
                Phone = "phone",
            },
            BillingModel = "organization",
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
            Description = "Updated sales department sender profile",
            Icon = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
            Name = "Sales Team - Updated",
            PaymentDetails = new()
            {
                CardNumber = "3216699102256101",
                Cvc = "3216",
                Expiry = "11/66",
                ZipCode = "x",
            },
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            SendingWhatsappNumberProfileID = null,
            ShortName = "SALES",
            WhatsappPhoneNumber = null,

            // Null should be interpreted as omitted for these properties
            Sandbox = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

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
        var parameters = new ProfileUpdateParams
        {
            ProfileID = "profileId",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.AllowContactSharing);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_contact_sharing"));
        Assert.Null(parameters.AllowNumberChangeDuringOnboarding);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_number_change_during_onboarding"));
        Assert.Null(parameters.AllowTemplateSharing);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_template_sharing"));
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
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.PaymentDetails);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_details"));
        Assert.Null(parameters.SendingPhoneNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("sending_phone_number"));
        Assert.Null(parameters.SendingPhoneNumberProfileID);
        Assert.False(parameters.RawBodyData.ContainsKey("sending_phone_number_profile_id"));
        Assert.Null(parameters.SendingWhatsappNumberProfileID);
        Assert.False(parameters.RawBodyData.ContainsKey("sending_whatsapp_number_profile_id"));
        Assert.Null(parameters.ShortName);
        Assert.False(parameters.RawBodyData.ContainsKey("short_name"));
        Assert.Null(parameters.WhatsappPhoneNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("whatsapp_phone_number"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            ProfileID = "profileId",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            AllowContactSharing = null,
            AllowNumberChangeDuringOnboarding = null,
            AllowTemplateSharing = null,
            BillingContact = null,
            BillingModel = null,
            Brand = null,
            Description = null,
            Icon = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
            Name = null,
            PaymentDetails = null,
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            SendingWhatsappNumberProfileID = null,
            ShortName = null,
            WhatsappPhoneNumber = null,
        };

        Assert.Null(parameters.AllowContactSharing);
        Assert.True(parameters.RawBodyData.ContainsKey("allow_contact_sharing"));
        Assert.Null(parameters.AllowNumberChangeDuringOnboarding);
        Assert.True(parameters.RawBodyData.ContainsKey("allow_number_change_during_onboarding"));
        Assert.Null(parameters.AllowTemplateSharing);
        Assert.True(parameters.RawBodyData.ContainsKey("allow_template_sharing"));
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
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.PaymentDetails);
        Assert.True(parameters.RawBodyData.ContainsKey("payment_details"));
        Assert.Null(parameters.SendingPhoneNumber);
        Assert.True(parameters.RawBodyData.ContainsKey("sending_phone_number"));
        Assert.Null(parameters.SendingPhoneNumberProfileID);
        Assert.True(parameters.RawBodyData.ContainsKey("sending_phone_number_profile_id"));
        Assert.Null(parameters.SendingWhatsappNumberProfileID);
        Assert.True(parameters.RawBodyData.ContainsKey("sending_whatsapp_number_profile_id"));
        Assert.Null(parameters.ShortName);
        Assert.True(parameters.RawBodyData.ContainsKey("short_name"));
        Assert.Null(parameters.WhatsappPhoneNumber);
        Assert.True(parameters.RawBodyData.ContainsKey("whatsapp_phone_number"));
    }

    [Fact]
    public void Url_Works()
    {
        ProfileUpdateParams parameters = new() { ProfileID = "profileId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.sent.dm/v3/profiles/profileId"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ProfileUpdateParams parameters = new()
        {
            ProfileID = "profileId",
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
        var parameters = new ProfileUpdateParams
        {
            ProfileID = "profileId",
            AllowContactSharing = true,
            AllowNumberChangeDuringOnboarding = null,
            AllowTemplateSharing = null,
            BillingContact = new()
            {
                Email = "dev@stainless.com",
                Name = "x",
                Address = "address",
                Phone = "phone",
            },
            BillingModel = "organization",
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
            Description = "Updated sales department sender profile",
            Icon = null,
            InheritContacts = null,
            InheritTcrBrand = null,
            InheritTcrCampaign = null,
            InheritTemplates = null,
            Name = "Sales Team - Updated",
            PaymentDetails = new()
            {
                CardNumber = "3216699102256101",
                Cvc = "3216",
                Expiry = "11/66",
                ZipCode = "x",
            },
            Sandbox = false,
            SendingPhoneNumber = null,
            SendingPhoneNumberProfileID = null,
            SendingWhatsappNumberProfileID = null,
            ShortName = "SALES",
            WhatsappPhoneNumber = null,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ProfileUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
