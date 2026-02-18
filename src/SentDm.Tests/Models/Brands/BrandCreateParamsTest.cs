using System;
using System.Net.Http;
using SentDm.Models.Brands;

namespace SentDm.Tests.Models.Brands;

public class BrandCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandCreateParams
        {
            Brand = new()
            {
                BrandRelationship = TcrBrandRelationship.SmallAccount,
                ContactName = "John Smith",
                Vertical = TcrVertical.Professional,
                BrandName = null,
                BusinessLegalName = "Acme Corporation LLC",
                BusinessName = "Acme Corp",
                BusinessRole = "CEO",
                BusinessUrl = "https://acmecorp.com",
                City = "New York",
                ContactEmail = "john@acmecorp.com",
                ContactPhone = "+12025551234",
                ContactPhoneCountryCode = "1",
                Country = "US",
                CountryOfRegistration = "US",
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                EntityType = EntityType.PrivateProfit,
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PostalCode = "10001",
                PrimaryUseCase = "Customer notifications and appointment reminders",
                State = "NY",
                Street = "123 Main Street",
                TaxID = "12-3456789",
                TaxIDType = "us_ein",
            },
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        BrandData expectedBrand = new()
        {
            BrandRelationship = TcrBrandRelationship.SmallAccount,
            ContactName = "John Smith",
            Vertical = TcrVertical.Professional,
            BrandName = null,
            BusinessLegalName = "Acme Corporation LLC",
            BusinessName = "Acme Corp",
            BusinessRole = "CEO",
            BusinessUrl = "https://acmecorp.com",
            City = "New York",
            ContactEmail = "john@acmecorp.com",
            ContactPhone = "+12025551234",
            ContactPhoneCountryCode = "1",
            Country = "US",
            CountryOfRegistration = "US",
            DestinationCountries = [new() { ID = "US", IsMain = false }],
            EntityType = EntityType.PrivateProfit,
            ExpectedMessagingVolume = "10000",
            IsTcrApplication = true,
            Notes = null,
            PhoneNumberPrefix = "+1",
            PostalCode = "10001",
            PrimaryUseCase = "Customer notifications and appointment reminders",
            State = "NY",
            Street = "123 Main Street",
            TaxID = "12-3456789",
            TaxIDType = "us_ein",
        };
        bool expectedTestMode = false;
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedBrand, parameters.Brand);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BrandCreateParams
        {
            Brand = new()
            {
                BrandRelationship = TcrBrandRelationship.SmallAccount,
                ContactName = "John Smith",
                Vertical = TcrVertical.Professional,
                BrandName = null,
                BusinessLegalName = "Acme Corporation LLC",
                BusinessName = "Acme Corp",
                BusinessRole = "CEO",
                BusinessUrl = "https://acmecorp.com",
                City = "New York",
                ContactEmail = "john@acmecorp.com",
                ContactPhone = "+12025551234",
                ContactPhoneCountryCode = "1",
                Country = "US",
                CountryOfRegistration = "US",
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                EntityType = EntityType.PrivateProfit,
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PostalCode = "10001",
                PrimaryUseCase = "Customer notifications and appointment reminders",
                State = "NY",
                Street = "123 Main Street",
                TaxID = "12-3456789",
                TaxIDType = "us_ein",
            },
        };

        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BrandCreateParams
        {
            Brand = new()
            {
                BrandRelationship = TcrBrandRelationship.SmallAccount,
                ContactName = "John Smith",
                Vertical = TcrVertical.Professional,
                BrandName = null,
                BusinessLegalName = "Acme Corporation LLC",
                BusinessName = "Acme Corp",
                BusinessRole = "CEO",
                BusinessUrl = "https://acmecorp.com",
                City = "New York",
                ContactEmail = "john@acmecorp.com",
                ContactPhone = "+12025551234",
                ContactPhoneCountryCode = "1",
                Country = "US",
                CountryOfRegistration = "US",
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                EntityType = EntityType.PrivateProfit,
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PostalCode = "10001",
                PrimaryUseCase = "Customer notifications and appointment reminders",
                State = "NY",
                Street = "123 Main Street",
                TaxID = "12-3456789",
                TaxIDType = "us_ein",
            },

            // Null should be interpreted as omitted for these properties
            TestMode = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void Url_Works()
    {
        BrandCreateParams parameters = new()
        {
            Brand = new()
            {
                BrandRelationship = TcrBrandRelationship.SmallAccount,
                ContactName = "John Smith",
                Vertical = TcrVertical.Professional,
                BrandName = null,
                BusinessLegalName = "Acme Corporation LLC",
                BusinessName = "Acme Corp",
                BusinessRole = "CEO",
                BusinessUrl = "https://acmecorp.com",
                City = "New York",
                ContactEmail = "john@acmecorp.com",
                ContactPhone = "+12025551234",
                ContactPhoneCountryCode = "1",
                Country = "US",
                CountryOfRegistration = "US",
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                EntityType = EntityType.PrivateProfit,
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PostalCode = "10001",
                PrimaryUseCase = "Customer notifications and appointment reminders",
                State = "NY",
                Street = "123 Main Street",
                TaxID = "12-3456789",
                TaxIDType = "us_ein",
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.sent.dm/v3/brands"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        BrandCreateParams parameters = new()
        {
            Brand = new()
            {
                BrandRelationship = TcrBrandRelationship.SmallAccount,
                ContactName = "John Smith",
                Vertical = TcrVertical.Professional,
                BrandName = null,
                BusinessLegalName = "Acme Corporation LLC",
                BusinessName = "Acme Corp",
                BusinessRole = "CEO",
                BusinessUrl = "https://acmecorp.com",
                City = "New York",
                ContactEmail = "john@acmecorp.com",
                ContactPhone = "+12025551234",
                ContactPhoneCountryCode = "1",
                Country = "US",
                CountryOfRegistration = "US",
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                EntityType = EntityType.PrivateProfit,
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PostalCode = "10001",
                PrimaryUseCase = "Customer notifications and appointment reminders",
                State = "NY",
                Street = "123 Main Street",
                TaxID = "12-3456789",
                TaxIDType = "us_ein",
            },
            IdempotencyKey = "req_abc123_retry1",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BrandCreateParams
        {
            Brand = new()
            {
                BrandRelationship = TcrBrandRelationship.SmallAccount,
                ContactName = "John Smith",
                Vertical = TcrVertical.Professional,
                BrandName = null,
                BusinessLegalName = "Acme Corporation LLC",
                BusinessName = "Acme Corp",
                BusinessRole = "CEO",
                BusinessUrl = "https://acmecorp.com",
                City = "New York",
                ContactEmail = "john@acmecorp.com",
                ContactPhone = "+12025551234",
                ContactPhoneCountryCode = "1",
                Country = "US",
                CountryOfRegistration = "US",
                DestinationCountries = [new() { ID = "US", IsMain = false }],
                EntityType = EntityType.PrivateProfit,
                ExpectedMessagingVolume = "10000",
                IsTcrApplication = true,
                Notes = null,
                PhoneNumberPrefix = "+1",
                PostalCode = "10001",
                PrimaryUseCase = "Customer notifications and appointment reminders",
                State = "NY",
                Street = "123 Main Street",
                TaxID = "12-3456789",
                TaxIDType = "us_ein",
            },
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        BrandCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
