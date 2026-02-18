using System.Threading.Tasks;
using SentDm.Models.Brands;

namespace SentDm.Tests.Services;

public class BrandServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var apiResponseBrandWithKyc = await this.client.Brands.Create(
            new()
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
            },
            TestContext.Current.CancellationToken
        );
        apiResponseBrandWithKyc.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var apiResponseBrandWithKyc = await this.client.Brands.Update(
            "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            new()
            {
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
            },
            TestContext.Current.CancellationToken
        );
        apiResponseBrandWithKyc.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var brands = await this.client.Brands.List(new(), TestContext.Current.CancellationToken);
        brands.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Brands.Delete(
            "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            new() { Body = new() { TestMode = false } },
            TestContext.Current.CancellationToken
        );
    }
}
