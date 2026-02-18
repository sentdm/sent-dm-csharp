using System;
using System.Net.Http;
using Sentdm.Models.Brands;

namespace Sentdm.Tests.Models.Brands;

public class BrandUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandUpdateParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            Brand = new()
            {
                BrandRelationship = TcrBrandRelationship.SmallAccount,
                ContactName = "John Smith",
                Vertical = TcrVertical.Professional,
                BrandName = null,
                BusinessLegalName = "Acme Corporation LLC",
                BusinessName = "Acme Corp Updated",
                BusinessRole = "CTO",
                BusinessUrl = null,
                City = null,
                ContactEmail = "john@acmecorp.com",
                ContactPhone = "+12025551234",
                ContactPhoneCountryCode = "1",
                Country = "US",
                CountryOfRegistration = null,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                EntityType = null,
                ExpectedMessagingVolume = null,
                IsTcrApplication = null,
                Notes = null,
                PhoneNumberPrefix = null,
                PostalCode = null,
                PrimaryUseCase = null,
                State = null,
                Street = null,
                TaxID = null,
                TaxIDType = null,
            },
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        string expectedBrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890";
        BrandData expectedBrand = new()
        {
            BrandRelationship = TcrBrandRelationship.SmallAccount,
            ContactName = "John Smith",
            Vertical = TcrVertical.Professional,
            BrandName = null,
            BusinessLegalName = "Acme Corporation LLC",
            BusinessName = "Acme Corp Updated",
            BusinessRole = "CTO",
            BusinessUrl = null,
            City = null,
            ContactEmail = "john@acmecorp.com",
            ContactPhone = "+12025551234",
            ContactPhoneCountryCode = "1",
            Country = "US",
            CountryOfRegistration = null,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            EntityType = null,
            ExpectedMessagingVolume = null,
            IsTcrApplication = null,
            Notes = null,
            PhoneNumberPrefix = null,
            PostalCode = null,
            PrimaryUseCase = null,
            State = null,
            Street = null,
            TaxID = null,
            TaxIDType = null,
        };
        bool expectedTestMode = false;
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedBrand, parameters.Brand);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BrandUpdateParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            Brand = new()
            {
                BrandRelationship = TcrBrandRelationship.SmallAccount,
                ContactName = "John Smith",
                Vertical = TcrVertical.Professional,
                BrandName = null,
                BusinessLegalName = "Acme Corporation LLC",
                BusinessName = "Acme Corp Updated",
                BusinessRole = "CTO",
                BusinessUrl = null,
                City = null,
                ContactEmail = "john@acmecorp.com",
                ContactPhone = "+12025551234",
                ContactPhoneCountryCode = "1",
                Country = "US",
                CountryOfRegistration = null,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                EntityType = null,
                ExpectedMessagingVolume = null,
                IsTcrApplication = null,
                Notes = null,
                PhoneNumberPrefix = null,
                PostalCode = null,
                PrimaryUseCase = null,
                State = null,
                Street = null,
                TaxID = null,
                TaxIDType = null,
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
        var parameters = new BrandUpdateParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            Brand = new()
            {
                BrandRelationship = TcrBrandRelationship.SmallAccount,
                ContactName = "John Smith",
                Vertical = TcrVertical.Professional,
                BrandName = null,
                BusinessLegalName = "Acme Corporation LLC",
                BusinessName = "Acme Corp Updated",
                BusinessRole = "CTO",
                BusinessUrl = null,
                City = null,
                ContactEmail = "john@acmecorp.com",
                ContactPhone = "+12025551234",
                ContactPhoneCountryCode = "1",
                Country = "US",
                CountryOfRegistration = null,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                EntityType = null,
                ExpectedMessagingVolume = null,
                IsTcrApplication = null,
                Notes = null,
                PhoneNumberPrefix = null,
                PostalCode = null,
                PrimaryUseCase = null,
                State = null,
                Street = null,
                TaxID = null,
                TaxIDType = null,
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
        BrandUpdateParams parameters = new()
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            Brand = new()
            {
                BrandRelationship = TcrBrandRelationship.SmallAccount,
                ContactName = "John Smith",
                Vertical = TcrVertical.Professional,
                BrandName = null,
                BusinessLegalName = "Acme Corporation LLC",
                BusinessName = "Acme Corp Updated",
                BusinessRole = "CTO",
                BusinessUrl = null,
                City = null,
                ContactEmail = "john@acmecorp.com",
                ContactPhone = "+12025551234",
                ContactPhoneCountryCode = "1",
                Country = "US",
                CountryOfRegistration = null,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                EntityType = null,
                ExpectedMessagingVolume = null,
                IsTcrApplication = null,
                Notes = null,
                PhoneNumberPrefix = null,
                PostalCode = null,
                PrimaryUseCase = null,
                State = null,
                Street = null,
                TaxID = null,
                TaxIDType = null,
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/brands/a1b2c3d4-e5f6-7890-abcd-ef1234567890"),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        BrandUpdateParams parameters = new()
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            Brand = new()
            {
                BrandRelationship = TcrBrandRelationship.SmallAccount,
                ContactName = "John Smith",
                Vertical = TcrVertical.Professional,
                BrandName = null,
                BusinessLegalName = "Acme Corporation LLC",
                BusinessName = "Acme Corp Updated",
                BusinessRole = "CTO",
                BusinessUrl = null,
                City = null,
                ContactEmail = "john@acmecorp.com",
                ContactPhone = "+12025551234",
                ContactPhoneCountryCode = "1",
                Country = "US",
                CountryOfRegistration = null,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                EntityType = null,
                ExpectedMessagingVolume = null,
                IsTcrApplication = null,
                Notes = null,
                PhoneNumberPrefix = null,
                PostalCode = null,
                PrimaryUseCase = null,
                State = null,
                Street = null,
                TaxID = null,
                TaxIDType = null,
            },
            IdempotencyKey = "req_abc123_retry1",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BrandUpdateParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            Brand = new()
            {
                BrandRelationship = TcrBrandRelationship.SmallAccount,
                ContactName = "John Smith",
                Vertical = TcrVertical.Professional,
                BrandName = null,
                BusinessLegalName = "Acme Corporation LLC",
                BusinessName = "Acme Corp Updated",
                BusinessRole = "CTO",
                BusinessUrl = null,
                City = null,
                ContactEmail = "john@acmecorp.com",
                ContactPhone = "+12025551234",
                ContactPhoneCountryCode = "1",
                Country = "US",
                CountryOfRegistration = null,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                EntityType = null,
                ExpectedMessagingVolume = null,
                IsTcrApplication = null,
                Notes = null,
                PhoneNumberPrefix = null,
                PostalCode = null,
                PrimaryUseCase = null,
                State = null,
                Street = null,
                TaxID = null,
                TaxIDType = null,
            },
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        BrandUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
