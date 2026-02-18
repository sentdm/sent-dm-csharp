using System;
using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Contacts;

namespace SentDm.Tests.Models.Contacts;

public class ContactTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contact
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
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAvailableChannels = "available_channels";
        string expectedCountryCode = "country_code";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDefaultChannel = "default_channel";
        string expectedFormatE164 = "format_e164";
        string expectedFormatInternational = "format_international";
        string expectedFormatNational = "format_national";
        string expectedFormatRfc = "format_rfc";
        bool expectedIsInherited = true;
        bool expectedOptOut = true;
        string expectedPhoneNumber = "phone_number";
        string expectedRegionCode = "region_code";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAvailableChannels, model.AvailableChannels);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDefaultChannel, model.DefaultChannel);
        Assert.Equal(expectedFormatE164, model.FormatE164);
        Assert.Equal(expectedFormatInternational, model.FormatInternational);
        Assert.Equal(expectedFormatNational, model.FormatNational);
        Assert.Equal(expectedFormatRfc, model.FormatRfc);
        Assert.Equal(expectedIsInherited, model.IsInherited);
        Assert.Equal(expectedOptOut, model.OptOut);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedRegionCode, model.RegionCode);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contact
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contact>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAvailableChannels = "available_channels";
        string expectedCountryCode = "country_code";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDefaultChannel = "default_channel";
        string expectedFormatE164 = "format_e164";
        string expectedFormatInternational = "format_international";
        string expectedFormatNational = "format_national";
        string expectedFormatRfc = "format_rfc";
        bool expectedIsInherited = true;
        bool expectedOptOut = true;
        string expectedPhoneNumber = "phone_number";
        string expectedRegionCode = "region_code";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAvailableChannels, deserialized.AvailableChannels);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDefaultChannel, deserialized.DefaultChannel);
        Assert.Equal(expectedFormatE164, deserialized.FormatE164);
        Assert.Equal(expectedFormatInternational, deserialized.FormatInternational);
        Assert.Equal(expectedFormatNational, deserialized.FormatNational);
        Assert.Equal(expectedFormatRfc, deserialized.FormatRfc);
        Assert.Equal(expectedIsInherited, deserialized.IsInherited);
        Assert.Equal(expectedOptOut, deserialized.OptOut);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedRegionCode, deserialized.RegionCode);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contact
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contact { UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AvailableChannels);
        Assert.False(model.RawData.ContainsKey("available_channels"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DefaultChannel);
        Assert.False(model.RawData.ContainsKey("default_channel"));
        Assert.Null(model.FormatE164);
        Assert.False(model.RawData.ContainsKey("format_e164"));
        Assert.Null(model.FormatInternational);
        Assert.False(model.RawData.ContainsKey("format_international"));
        Assert.Null(model.FormatNational);
        Assert.False(model.RawData.ContainsKey("format_national"));
        Assert.Null(model.FormatRfc);
        Assert.False(model.RawData.ContainsKey("format_rfc"));
        Assert.Null(model.IsInherited);
        Assert.False(model.RawData.ContainsKey("is_inherited"));
        Assert.Null(model.OptOut);
        Assert.False(model.RawData.ContainsKey("opt_out"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.RegionCode);
        Assert.False(model.RawData.ContainsKey("region_code"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Contact { UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contact
        {
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            AvailableChannels = null,
            CountryCode = null,
            CreatedAt = null,
            DefaultChannel = null,
            FormatE164 = null,
            FormatInternational = null,
            FormatNational = null,
            FormatRfc = null,
            IsInherited = null,
            OptOut = null,
            PhoneNumber = null,
            RegionCode = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AvailableChannels);
        Assert.False(model.RawData.ContainsKey("available_channels"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DefaultChannel);
        Assert.False(model.RawData.ContainsKey("default_channel"));
        Assert.Null(model.FormatE164);
        Assert.False(model.RawData.ContainsKey("format_e164"));
        Assert.Null(model.FormatInternational);
        Assert.False(model.RawData.ContainsKey("format_international"));
        Assert.Null(model.FormatNational);
        Assert.False(model.RawData.ContainsKey("format_national"));
        Assert.Null(model.FormatRfc);
        Assert.False(model.RawData.ContainsKey("format_rfc"));
        Assert.Null(model.IsInherited);
        Assert.False(model.RawData.ContainsKey("is_inherited"));
        Assert.Null(model.OptOut);
        Assert.False(model.RawData.ContainsKey("opt_out"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.RegionCode);
        Assert.False(model.RawData.ContainsKey("region_code"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Contact
        {
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            AvailableChannels = null,
            CountryCode = null,
            CreatedAt = null,
            DefaultChannel = null,
            FormatE164 = null,
            FormatInternational = null,
            FormatNational = null,
            FormatRfc = null,
            IsInherited = null,
            OptOut = null,
            PhoneNumber = null,
            RegionCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contact
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
        };

        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Contact
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Contact
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

            UpdatedAt = null,
        };

        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Contact
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

            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contact
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
        };

        Contact copied = new(model);

        Assert.Equal(model, copied);
    }
}
