using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Contacts;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Contacts;

public class ContactsListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContactsList
        {
            Contacts =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AvailableChannels = "available_channels",
                    CountryCode = "country_code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    DefaultChannel = "default_channel",
                    FormatE164 = "format_e164",
                    FormatInternational = "format_international",
                    FormatNational = "format_national",
                    FormatRfc = "format_rfc",
                    IsInherited = true,
                    OptOut = true,
                    PhoneNumber = "phone_number",
                    RegionCode = "region_code",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        List<ContactResponse> expectedContacts =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AvailableChannels = "available_channels",
                CountryCode = "country_code",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                DefaultChannel = "default_channel",
                FormatE164 = "format_e164",
                FormatInternational = "format_international",
                FormatNational = "format_national",
                FormatRfc = "format_rfc",
                IsInherited = true,
                OptOut = true,
                PhoneNumber = "phone_number",
                RegionCode = "region_code",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        PaginationMeta expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.NotNull(model.Contacts);
        Assert.Equal(expectedContacts.Count, model.Contacts.Count);
        for (int i = 0; i < expectedContacts.Count; i++)
        {
            Assert.Equal(expectedContacts[i], model.Contacts[i]);
        }
        Assert.Equal(expectedPagination, model.Pagination);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContactsList
        {
            Contacts =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AvailableChannels = "available_channels",
                    CountryCode = "country_code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    DefaultChannel = "default_channel",
                    FormatE164 = "format_e164",
                    FormatInternational = "format_international",
                    FormatNational = "format_national",
                    FormatRfc = "format_rfc",
                    IsInherited = true,
                    OptOut = true,
                    PhoneNumber = "phone_number",
                    RegionCode = "region_code",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactsList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContactsList
        {
            Contacts =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AvailableChannels = "available_channels",
                    CountryCode = "country_code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    DefaultChannel = "default_channel",
                    FormatE164 = "format_e164",
                    FormatInternational = "format_international",
                    FormatNational = "format_national",
                    FormatRfc = "format_rfc",
                    IsInherited = true,
                    OptOut = true,
                    PhoneNumber = "phone_number",
                    RegionCode = "region_code",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactsList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ContactResponse> expectedContacts =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AvailableChannels = "available_channels",
                CountryCode = "country_code",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                DefaultChannel = "default_channel",
                FormatE164 = "format_e164",
                FormatInternational = "format_international",
                FormatNational = "format_national",
                FormatRfc = "format_rfc",
                IsInherited = true,
                OptOut = true,
                PhoneNumber = "phone_number",
                RegionCode = "region_code",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        PaginationMeta expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.NotNull(deserialized.Contacts);
        Assert.Equal(expectedContacts.Count, deserialized.Contacts.Count);
        for (int i = 0; i < expectedContacts.Count; i++)
        {
            Assert.Equal(expectedContacts[i], deserialized.Contacts[i]);
        }
        Assert.Equal(expectedPagination, deserialized.Pagination);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContactsList
        {
            Contacts =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AvailableChannels = "available_channels",
                    CountryCode = "country_code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    DefaultChannel = "default_channel",
                    FormatE164 = "format_e164",
                    FormatInternational = "format_international",
                    FormatNational = "format_national",
                    FormatRfc = "format_rfc",
                    IsInherited = true,
                    OptOut = true,
                    PhoneNumber = "phone_number",
                    RegionCode = "region_code",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContactsList { };

        Assert.Null(model.Contacts);
        Assert.False(model.RawData.ContainsKey("contacts"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContactsList { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContactsList
        {
            // Null should be interpreted as omitted for these properties
            Contacts = null,
            Pagination = null,
        };

        Assert.Null(model.Contacts);
        Assert.False(model.RawData.ContainsKey("contacts"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContactsList
        {
            // Null should be interpreted as omitted for these properties
            Contacts = null,
            Pagination = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContactsList
        {
            Contacts =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AvailableChannels = "available_channels",
                    CountryCode = "country_code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    DefaultChannel = "default_channel",
                    FormatE164 = "format_e164",
                    FormatInternational = "format_international",
                    FormatNational = "format_national",
                    FormatRfc = "format_rfc",
                    IsInherited = true,
                    OptOut = true,
                    PhoneNumber = "phone_number",
                    RegionCode = "region_code",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        ContactsList copied = new(model);

        Assert.Equal(model, copied);
    }
}
