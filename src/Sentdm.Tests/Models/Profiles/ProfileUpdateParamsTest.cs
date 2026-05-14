using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
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
                    BrandRelationship =
                        ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
                    Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
                    EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
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
        ProfileUpdateParamsBillingContact expectedBillingContact = new()
        {
            Email = "dev@stainless.com",
            Name = "x",
            Address = "address",
            Phone = "phone",
        };
        string expectedBillingModel = "organization";
        ProfileUpdateParamsBrand expectedBrand = new()
        {
            Compliance = new()
            {
                BrandRelationship =
                    ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
                Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
                EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
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
        ProfileUpdateParamsPaymentDetails expectedPaymentDetails = new()
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
                    BrandRelationship =
                        ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
                    Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
                    EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
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
                    BrandRelationship =
                        ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
                    Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
                    EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
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
                    BrandRelationship =
                        ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
                    Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
                    EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
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

public class ProfileUpdateParamsBillingContactTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileUpdateParamsBillingContact
        {
            Email = "dev@stainless.com",
            Name = "x",
            Address = "address",
            Phone = "phone",
        };

        string expectedEmail = "dev@stainless.com";
        string expectedName = "x";
        string expectedAddress = "address";
        string expectedPhone = "phone";

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedPhone, model.Phone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProfileUpdateParamsBillingContact
        {
            Email = "dev@stainless.com",
            Name = "x",
            Address = "address",
            Phone = "phone",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileUpdateParamsBillingContact>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfileUpdateParamsBillingContact
        {
            Email = "dev@stainless.com",
            Name = "x",
            Address = "address",
            Phone = "phone",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileUpdateParamsBillingContact>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "dev@stainless.com";
        string expectedName = "x";
        string expectedAddress = "address";
        string expectedPhone = "phone";

        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedPhone, deserialized.Phone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProfileUpdateParamsBillingContact
        {
            Email = "dev@stainless.com",
            Name = "x",
            Address = "address",
            Phone = "phone",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProfileUpdateParamsBillingContact
        {
            Email = "dev@stainless.com",
            Name = "x",
        };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProfileUpdateParamsBillingContact
        {
            Email = "dev@stainless.com",
            Name = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProfileUpdateParamsBillingContact
        {
            Email = "dev@stainless.com",
            Name = "x",

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
        var model = new ProfileUpdateParamsBillingContact
        {
            Email = "dev@stainless.com",
            Name = "x",

            Address = null,
            Phone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProfileUpdateParamsBillingContact
        {
            Email = "dev@stainless.com",
            Name = "x",
            Address = "address",
            Phone = "phone",
        };

        ProfileUpdateParamsBillingContact copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProfileUpdateParamsBrandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileUpdateParamsBrand
        {
            Compliance = new()
            {
                BrandRelationship =
                    ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
                Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
                EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
                LegalName = "Acme Corporation LLC",
                PostalCode = "10001",
                State = "NY",
                Street = "123 Main Street",
                TaxID = "12-3456789",
                TaxIDType = "us_ein",
                Url = "https://acmecorp.com",
            },
        };

        ProfileUpdateParamsBrandCompliance expectedCompliance = new()
        {
            BrandRelationship = ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
            Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
            DestinationCountries = [new() { ID = "US", IsMain = false }],
            ExpectedMessagingVolume = "10000",
            IsTcrApplication = true,
            Notes = null,
            PhoneNumberPrefix = "+1",
            PrimaryUseCase = "Customer notifications and appointment reminders",
        };
        ProfileUpdateParamsBrandContact expectedContact = new()
        {
            Name = "John Smith",
            BusinessName = "Acme Corp",
            Email = "john@acmecorp.com",
            Phone = "+12025551234",
            PhoneCountryCode = "1",
            Role = "CEO",
        };
        ProfileUpdateParamsBrandBusiness expectedBusiness = new()
        {
            City = "New York",
            Country = "US",
            CountryOfRegistration = "US",
            EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
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
        var model = new ProfileUpdateParamsBrand
        {
            Compliance = new()
            {
                BrandRelationship =
                    ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
                Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
                EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
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
        var deserialized = JsonSerializer.Deserialize<ProfileUpdateParamsBrand>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfileUpdateParamsBrand
        {
            Compliance = new()
            {
                BrandRelationship =
                    ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
                Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
                EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
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
        var deserialized = JsonSerializer.Deserialize<ProfileUpdateParamsBrand>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ProfileUpdateParamsBrandCompliance expectedCompliance = new()
        {
            BrandRelationship = ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
            Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
            DestinationCountries = [new() { ID = "US", IsMain = false }],
            ExpectedMessagingVolume = "10000",
            IsTcrApplication = true,
            Notes = null,
            PhoneNumberPrefix = "+1",
            PrimaryUseCase = "Customer notifications and appointment reminders",
        };
        ProfileUpdateParamsBrandContact expectedContact = new()
        {
            Name = "John Smith",
            BusinessName = "Acme Corp",
            Email = "john@acmecorp.com",
            Phone = "+12025551234",
            PhoneCountryCode = "1",
            Role = "CEO",
        };
        ProfileUpdateParamsBrandBusiness expectedBusiness = new()
        {
            City = "New York",
            Country = "US",
            CountryOfRegistration = "US",
            EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
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
        var model = new ProfileUpdateParamsBrand
        {
            Compliance = new()
            {
                BrandRelationship =
                    ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
                Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
                EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
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
        var model = new ProfileUpdateParamsBrand
        {
            Compliance = new()
            {
                BrandRelationship =
                    ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
                Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
        var model = new ProfileUpdateParamsBrand
        {
            Compliance = new()
            {
                BrandRelationship =
                    ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
                Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
        var model = new ProfileUpdateParamsBrand
        {
            Compliance = new()
            {
                BrandRelationship =
                    ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
                Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
        var model = new ProfileUpdateParamsBrand
        {
            Compliance = new()
            {
                BrandRelationship =
                    ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
                Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
        var model = new ProfileUpdateParamsBrand
        {
            Compliance = new()
            {
                BrandRelationship =
                    ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount,
                Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
                EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
                LegalName = "Acme Corporation LLC",
                PostalCode = "10001",
                State = "NY",
                Street = "123 Main Street",
                TaxID = "12-3456789",
                TaxIDType = "us_ein",
                Url = "https://acmecorp.com",
            },
        };

        ProfileUpdateParamsBrand copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProfileUpdateParamsBrandComplianceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileUpdateParamsBrandCompliance
        {
            BrandRelationship = ProfileUpdateParamsBrandComplianceBrandRelationship.BasicAccount,
            Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PrimaryUseCase = "primaryUseCase",
        };

        ApiEnum<
            string,
            ProfileUpdateParamsBrandComplianceBrandRelationship
        > expectedBrandRelationship =
            ProfileUpdateParamsBrandComplianceBrandRelationship.BasicAccount;
        ApiEnum<string, ProfileUpdateParamsBrandComplianceVertical> expectedVertical =
            ProfileUpdateParamsBrandComplianceVertical.Professional;
        List<ProfileUpdateParamsBrandComplianceDestinationCountry> expectedDestinationCountries =
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
        var model = new ProfileUpdateParamsBrandCompliance
        {
            BrandRelationship = ProfileUpdateParamsBrandComplianceBrandRelationship.BasicAccount,
            Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PrimaryUseCase = "primaryUseCase",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileUpdateParamsBrandCompliance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfileUpdateParamsBrandCompliance
        {
            BrandRelationship = ProfileUpdateParamsBrandComplianceBrandRelationship.BasicAccount,
            Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PrimaryUseCase = "primaryUseCase",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileUpdateParamsBrandCompliance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ProfileUpdateParamsBrandComplianceBrandRelationship
        > expectedBrandRelationship =
            ProfileUpdateParamsBrandComplianceBrandRelationship.BasicAccount;
        ApiEnum<string, ProfileUpdateParamsBrandComplianceVertical> expectedVertical =
            ProfileUpdateParamsBrandComplianceVertical.Professional;
        List<ProfileUpdateParamsBrandComplianceDestinationCountry> expectedDestinationCountries =
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
        var model = new ProfileUpdateParamsBrandCompliance
        {
            BrandRelationship = ProfileUpdateParamsBrandComplianceBrandRelationship.BasicAccount,
            Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
        var model = new ProfileUpdateParamsBrandCompliance
        {
            BrandRelationship = ProfileUpdateParamsBrandComplianceBrandRelationship.BasicAccount,
            Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
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
        var model = new ProfileUpdateParamsBrandCompliance
        {
            BrandRelationship = ProfileUpdateParamsBrandComplianceBrandRelationship.BasicAccount,
            Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProfileUpdateParamsBrandCompliance
        {
            BrandRelationship = ProfileUpdateParamsBrandComplianceBrandRelationship.BasicAccount,
            Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,

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
        var model = new ProfileUpdateParamsBrandCompliance
        {
            BrandRelationship = ProfileUpdateParamsBrandComplianceBrandRelationship.BasicAccount,
            Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,

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
        var model = new ProfileUpdateParamsBrandCompliance
        {
            BrandRelationship = ProfileUpdateParamsBrandComplianceBrandRelationship.BasicAccount,
            Vertical = ProfileUpdateParamsBrandComplianceVertical.Professional,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            ExpectedMessagingVolume = "expectedMessagingVolume",
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phoneNumberPrefix",
            PrimaryUseCase = "primaryUseCase",
        };

        ProfileUpdateParamsBrandCompliance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProfileUpdateParamsBrandComplianceBrandRelationshipTest : TestBase
{
    [Theory]
    [InlineData(ProfileUpdateParamsBrandComplianceBrandRelationship.BasicAccount)]
    [InlineData(ProfileUpdateParamsBrandComplianceBrandRelationship.MediumAccount)]
    [InlineData(ProfileUpdateParamsBrandComplianceBrandRelationship.LargeAccount)]
    [InlineData(ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount)]
    [InlineData(ProfileUpdateParamsBrandComplianceBrandRelationship.KeyAccount)]
    public void Validation_Works(ProfileUpdateParamsBrandComplianceBrandRelationship rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProfileUpdateParamsBrandComplianceBrandRelationship> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProfileUpdateParamsBrandComplianceBrandRelationship>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProfileUpdateParamsBrandComplianceBrandRelationship.BasicAccount)]
    [InlineData(ProfileUpdateParamsBrandComplianceBrandRelationship.MediumAccount)]
    [InlineData(ProfileUpdateParamsBrandComplianceBrandRelationship.LargeAccount)]
    [InlineData(ProfileUpdateParamsBrandComplianceBrandRelationship.SmallAccount)]
    [InlineData(ProfileUpdateParamsBrandComplianceBrandRelationship.KeyAccount)]
    public void SerializationRoundtrip_Works(
        ProfileUpdateParamsBrandComplianceBrandRelationship rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProfileUpdateParamsBrandComplianceBrandRelationship> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProfileUpdateParamsBrandComplianceBrandRelationship>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProfileUpdateParamsBrandComplianceBrandRelationship>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProfileUpdateParamsBrandComplianceBrandRelationship>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProfileUpdateParamsBrandComplianceVerticalTest : TestBase
{
    [Theory]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Professional)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.RealEstate)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Healthcare)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.HumanResources)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Energy)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Entertainment)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Retail)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Transportation)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Agriculture)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Insurance)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Postal)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Education)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Hospitality)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Financial)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Political)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Gambling)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Legal)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Construction)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Ngo)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Manufacturing)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Government)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Technology)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Communication)]
    public void Validation_Works(ProfileUpdateParamsBrandComplianceVertical rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProfileUpdateParamsBrandComplianceVertical> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProfileUpdateParamsBrandComplianceVertical>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Professional)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.RealEstate)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Healthcare)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.HumanResources)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Energy)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Entertainment)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Retail)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Transportation)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Agriculture)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Insurance)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Postal)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Education)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Hospitality)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Financial)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Political)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Gambling)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Legal)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Construction)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Ngo)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Manufacturing)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Government)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Technology)]
    [InlineData(ProfileUpdateParamsBrandComplianceVertical.Communication)]
    public void SerializationRoundtrip_Works(ProfileUpdateParamsBrandComplianceVertical rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProfileUpdateParamsBrandComplianceVertical> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProfileUpdateParamsBrandComplianceVertical>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProfileUpdateParamsBrandComplianceVertical>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProfileUpdateParamsBrandComplianceVertical>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProfileUpdateParamsBrandComplianceDestinationCountryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileUpdateParamsBrandComplianceDestinationCountry
        {
            ID = "id",
            IsMain = true,
        };

        string expectedID = "id";
        bool expectedIsMain = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedIsMain, model.IsMain);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProfileUpdateParamsBrandComplianceDestinationCountry
        {
            ID = "id",
            IsMain = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ProfileUpdateParamsBrandComplianceDestinationCountry>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfileUpdateParamsBrandComplianceDestinationCountry
        {
            ID = "id",
            IsMain = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ProfileUpdateParamsBrandComplianceDestinationCountry>(
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
        var model = new ProfileUpdateParamsBrandComplianceDestinationCountry
        {
            ID = "id",
            IsMain = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProfileUpdateParamsBrandComplianceDestinationCountry { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.IsMain);
        Assert.False(model.RawData.ContainsKey("isMain"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProfileUpdateParamsBrandComplianceDestinationCountry { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ProfileUpdateParamsBrandComplianceDestinationCountry
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
        var model = new ProfileUpdateParamsBrandComplianceDestinationCountry
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
        var model = new ProfileUpdateParamsBrandComplianceDestinationCountry
        {
            ID = "id",
            IsMain = true,
        };

        ProfileUpdateParamsBrandComplianceDestinationCountry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProfileUpdateParamsBrandContactTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileUpdateParamsBrandContact
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
        var model = new ProfileUpdateParamsBrandContact
        {
            Name = "x",
            BusinessName = "businessName",
            Email = "dev@stainless.com",
            Phone = "phone",
            PhoneCountryCode = "phoneCountryCode",
            Role = "role",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileUpdateParamsBrandContact>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfileUpdateParamsBrandContact
        {
            Name = "x",
            BusinessName = "businessName",
            Email = "dev@stainless.com",
            Phone = "phone",
            PhoneCountryCode = "phoneCountryCode",
            Role = "role",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileUpdateParamsBrandContact>(
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
        var model = new ProfileUpdateParamsBrandContact
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
        var model = new ProfileUpdateParamsBrandContact { Name = "x" };

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
        var model = new ProfileUpdateParamsBrandContact { Name = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProfileUpdateParamsBrandContact
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
        var model = new ProfileUpdateParamsBrandContact
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
        var model = new ProfileUpdateParamsBrandContact
        {
            Name = "x",
            BusinessName = "businessName",
            Email = "dev@stainless.com",
            Phone = "phone",
            PhoneCountryCode = "phoneCountryCode",
            Role = "role",
        };

        ProfileUpdateParamsBrandContact copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProfileUpdateParamsBrandBusinessTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileUpdateParamsBrandBusiness
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
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
        ApiEnum<string, ProfileUpdateParamsBrandBusinessEntityType> expectedEntityType =
            ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit;
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
        var model = new ProfileUpdateParamsBrandBusiness
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
            LegalName = "legalName",
            PostalCode = "postalCode",
            State = "state",
            Street = "street",
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            Url = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileUpdateParamsBrandBusiness>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfileUpdateParamsBrandBusiness
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
            LegalName = "legalName",
            PostalCode = "postalCode",
            State = "state",
            Street = "street",
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            Url = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileUpdateParamsBrandBusiness>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedCountryOfRegistration = "countryOfRegistration";
        ApiEnum<string, ProfileUpdateParamsBrandBusinessEntityType> expectedEntityType =
            ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit;
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
        var model = new ProfileUpdateParamsBrandBusiness
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
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
        var model = new ProfileUpdateParamsBrandBusiness { };

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
        var model = new ProfileUpdateParamsBrandBusiness { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProfileUpdateParamsBrandBusiness
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
        var model = new ProfileUpdateParamsBrandBusiness
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
        var model = new ProfileUpdateParamsBrandBusiness
        {
            City = "city",
            Country = "country",
            CountryOfRegistration = "countryOfRegistration",
            EntityType = ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit,
            LegalName = "legalName",
            PostalCode = "postalCode",
            State = "state",
            Street = "street",
            TaxID = "taxId",
            TaxIDType = "taxIdType",
            Url = "https://example.com",
        };

        ProfileUpdateParamsBrandBusiness copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProfileUpdateParamsBrandBusinessEntityTypeTest : TestBase
{
    [Theory]
    [InlineData(ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit)]
    [InlineData(ProfileUpdateParamsBrandBusinessEntityType.PublicProfit)]
    [InlineData(ProfileUpdateParamsBrandBusinessEntityType.NonProfit)]
    [InlineData(ProfileUpdateParamsBrandBusinessEntityType.SoleProprietor)]
    [InlineData(ProfileUpdateParamsBrandBusinessEntityType.Government)]
    public void Validation_Works(ProfileUpdateParamsBrandBusinessEntityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProfileUpdateParamsBrandBusinessEntityType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProfileUpdateParamsBrandBusinessEntityType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProfileUpdateParamsBrandBusinessEntityType.PrivateProfit)]
    [InlineData(ProfileUpdateParamsBrandBusinessEntityType.PublicProfit)]
    [InlineData(ProfileUpdateParamsBrandBusinessEntityType.NonProfit)]
    [InlineData(ProfileUpdateParamsBrandBusinessEntityType.SoleProprietor)]
    [InlineData(ProfileUpdateParamsBrandBusinessEntityType.Government)]
    public void SerializationRoundtrip_Works(ProfileUpdateParamsBrandBusinessEntityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProfileUpdateParamsBrandBusinessEntityType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProfileUpdateParamsBrandBusinessEntityType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProfileUpdateParamsBrandBusinessEntityType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProfileUpdateParamsBrandBusinessEntityType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProfileUpdateParamsPaymentDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileUpdateParamsPaymentDetails
        {
            CardNumber = "3216699102256101",
            Cvc = "3216",
            Expiry = "11/66",
            ZipCode = "x",
        };

        string expectedCardNumber = "3216699102256101";
        string expectedCvc = "3216";
        string expectedExpiry = "11/66";
        string expectedZipCode = "x";

        Assert.Equal(expectedCardNumber, model.CardNumber);
        Assert.Equal(expectedCvc, model.Cvc);
        Assert.Equal(expectedExpiry, model.Expiry);
        Assert.Equal(expectedZipCode, model.ZipCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProfileUpdateParamsPaymentDetails
        {
            CardNumber = "3216699102256101",
            Cvc = "3216",
            Expiry = "11/66",
            ZipCode = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileUpdateParamsPaymentDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfileUpdateParamsPaymentDetails
        {
            CardNumber = "3216699102256101",
            Cvc = "3216",
            Expiry = "11/66",
            ZipCode = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileUpdateParamsPaymentDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCardNumber = "3216699102256101";
        string expectedCvc = "3216";
        string expectedExpiry = "11/66";
        string expectedZipCode = "x";

        Assert.Equal(expectedCardNumber, deserialized.CardNumber);
        Assert.Equal(expectedCvc, deserialized.Cvc);
        Assert.Equal(expectedExpiry, deserialized.Expiry);
        Assert.Equal(expectedZipCode, deserialized.ZipCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProfileUpdateParamsPaymentDetails
        {
            CardNumber = "3216699102256101",
            Cvc = "3216",
            Expiry = "11/66",
            ZipCode = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProfileUpdateParamsPaymentDetails
        {
            CardNumber = "3216699102256101",
            Cvc = "3216",
            Expiry = "11/66",
            ZipCode = "x",
        };

        ProfileUpdateParamsPaymentDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
