using System.Collections.Generic;
using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Contacts;

namespace SentDm.Tests.Models.Contacts;

public class ContactListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContactListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AvailableChannels = "availableChannels",
                    CountryCode = "countryCode",
                    DefaultChannel = "defaultChannel",
                    FormatE164 = "formatE164",
                    FormatInternational = "formatInternational",
                    FormatNational = "formatNational",
                    FormatRfc = "formatRfc",
                    PhoneNumber = "phoneNumber",
                    RegionCode = "regionCode",
                },
            ],
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        List<ContactListItem> expectedItems =
        [
            new()
            {
                ID = "id",
                AvailableChannels = "availableChannels",
                CountryCode = "countryCode",
                DefaultChannel = "defaultChannel",
                FormatE164 = "formatE164",
                FormatInternational = "formatInternational",
                FormatNational = "formatNational",
                FormatRfc = "formatRfc",
                PhoneNumber = "phoneNumber",
                RegionCode = "regionCode",
            },
        ];
        int expectedPage = 0;
        int expectedPageSize = 0;
        int expectedTotalCount = 0;
        int expectedTotalPages = 0;

        Assert.NotNull(model.Items);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedPageSize, model.PageSize);
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.Equal(expectedTotalPages, model.TotalPages);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContactListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AvailableChannels = "availableChannels",
                    CountryCode = "countryCode",
                    DefaultChannel = "defaultChannel",
                    FormatE164 = "formatE164",
                    FormatInternational = "formatInternational",
                    FormatNational = "formatNational",
                    FormatRfc = "formatRfc",
                    PhoneNumber = "phoneNumber",
                    RegionCode = "regionCode",
                },
            ],
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContactListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AvailableChannels = "availableChannels",
                    CountryCode = "countryCode",
                    DefaultChannel = "defaultChannel",
                    FormatE164 = "formatE164",
                    FormatInternational = "formatInternational",
                    FormatNational = "formatNational",
                    FormatRfc = "formatRfc",
                    PhoneNumber = "phoneNumber",
                    RegionCode = "regionCode",
                },
            ],
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ContactListItem> expectedItems =
        [
            new()
            {
                ID = "id",
                AvailableChannels = "availableChannels",
                CountryCode = "countryCode",
                DefaultChannel = "defaultChannel",
                FormatE164 = "formatE164",
                FormatInternational = "formatInternational",
                FormatNational = "formatNational",
                FormatRfc = "formatRfc",
                PhoneNumber = "phoneNumber",
                RegionCode = "regionCode",
            },
        ];
        int expectedPage = 0;
        int expectedPageSize = 0;
        int expectedTotalCount = 0;
        int expectedTotalPages = 0;

        Assert.NotNull(deserialized.Items);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedPageSize, deserialized.PageSize);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.Equal(expectedTotalPages, deserialized.TotalPages);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContactListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AvailableChannels = "availableChannels",
                    CountryCode = "countryCode",
                    DefaultChannel = "defaultChannel",
                    FormatE164 = "formatE164",
                    FormatInternational = "formatInternational",
                    FormatNational = "formatNational",
                    FormatRfc = "formatRfc",
                    PhoneNumber = "phoneNumber",
                    RegionCode = "regionCode",
                },
            ],
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContactListResponse { };

        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PageSize);
        Assert.False(model.RawData.ContainsKey("pageSize"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
        Assert.Null(model.TotalPages);
        Assert.False(model.RawData.ContainsKey("totalPages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContactListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContactListResponse
        {
            // Null should be interpreted as omitted for these properties
            Items = null,
            Page = null,
            PageSize = null,
            TotalCount = null,
            TotalPages = null,
        };

        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PageSize);
        Assert.False(model.RawData.ContainsKey("pageSize"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
        Assert.Null(model.TotalPages);
        Assert.False(model.RawData.ContainsKey("totalPages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContactListResponse
        {
            // Null should be interpreted as omitted for these properties
            Items = null,
            Page = null,
            PageSize = null,
            TotalCount = null,
            TotalPages = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContactListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AvailableChannels = "availableChannels",
                    CountryCode = "countryCode",
                    DefaultChannel = "defaultChannel",
                    FormatE164 = "formatE164",
                    FormatInternational = "formatInternational",
                    FormatNational = "formatNational",
                    FormatRfc = "formatRfc",
                    PhoneNumber = "phoneNumber",
                    RegionCode = "regionCode",
                },
            ],
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        ContactListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
