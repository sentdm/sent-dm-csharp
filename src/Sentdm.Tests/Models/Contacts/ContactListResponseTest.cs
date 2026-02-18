using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Contacts;
using Webhooks = Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Contacts;

public class ContactListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContactListResponse
        {
            Data = new()
            {
                Contacts =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        AvailableChannels = "available_channels",
                        CountryCode = "country_code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        Data expectedData = new()
        {
            Contacts =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AvailableChannels = "available_channels",
                    CountryCode = "country_code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        Webhooks::ApiError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        Webhooks::ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            ResponseTimeMs = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedMeta, model.Meta);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContactListResponse
        {
            Data = new()
            {
                Contacts =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        AvailableChannels = "available_channels",
                        CountryCode = "country_code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
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
            Data = new()
            {
                Contacts =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        AvailableChannels = "available_channels",
                        CountryCode = "country_code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            Contacts =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AvailableChannels = "available_channels",
                    CountryCode = "country_code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        Webhooks::ApiError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        Webhooks::ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            ResponseTimeMs = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedMeta, deserialized.Meta);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContactListResponse
        {
            Data = new()
            {
                Contacts =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        AvailableChannels = "available_channels",
                        CountryCode = "country_code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContactListResponse
        {
            Data = new()
            {
                Contacts =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        AvailableChannels = "available_channels",
                        CountryCode = "country_code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
        };

        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContactListResponse
        {
            Data = new()
            {
                Contacts =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        AvailableChannels = "available_channels",
                        CountryCode = "country_code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContactListResponse
        {
            Data = new()
            {
                Contacts =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        AvailableChannels = "available_channels",
                        CountryCode = "country_code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },

            // Null should be interpreted as omitted for these properties
            Meta = null,
            Success = null,
        };

        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContactListResponse
        {
            Data = new()
            {
                Contacts =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        AvailableChannels = "available_channels",
                        CountryCode = "country_code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },

            // Null should be interpreted as omitted for these properties
            Meta = null,
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContactListResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContactListResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ContactListResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,

            Data = null,
            Error = null,
        };

        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContactListResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,

            Data = null,
            Error = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContactListResponse
        {
            Data = new()
            {
                Contacts =
                [
                    new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        AvailableChannels = "available_channels",
                        CountryCode = "country_code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        ContactListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            Contacts =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AvailableChannels = "available_channels",
                    CountryCode = "country_code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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

        List<Contact> expectedContacts =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AvailableChannels = "available_channels",
                CountryCode = "country_code",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        Webhooks::PaginationMeta expectedPagination = new()
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
        var model = new Data
        {
            Contacts =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AvailableChannels = "available_channels",
                    CountryCode = "country_code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            Contacts =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AvailableChannels = "available_channels",
                    CountryCode = "country_code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<Contact> expectedContacts =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AvailableChannels = "available_channels",
                CountryCode = "country_code",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        Webhooks::PaginationMeta expectedPagination = new()
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
        var model = new Data
        {
            Contacts =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AvailableChannels = "available_channels",
                    CountryCode = "country_code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new Data { };

        Assert.Null(model.Contacts);
        Assert.False(model.RawData.ContainsKey("contacts"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
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
        var model = new Data
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
        var model = new Data
        {
            Contacts =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AvailableChannels = "available_channels",
                    CountryCode = "country_code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}
