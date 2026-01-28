using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Contacts;

namespace Sentdm.Tests.Models.Contacts;

public class ContactListItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContactListItem
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AvailableChannels = "availableChannels",
            CountryCode = "countryCode",
            DefaultChannel = "defaultChannel",
            FormatE164 = "formatE164",
            FormatInternational = "formatInternational",
            FormatNational = "formatNational",
            FormatRfc = "formatRfc",
            PhoneNumber = "phoneNumber",
            RegionCode = "regionCode",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAvailableChannels = "availableChannels";
        string expectedCountryCode = "countryCode";
        string expectedDefaultChannel = "defaultChannel";
        string expectedFormatE164 = "formatE164";
        string expectedFormatInternational = "formatInternational";
        string expectedFormatNational = "formatNational";
        string expectedFormatRfc = "formatRfc";
        string expectedPhoneNumber = "phoneNumber";
        string expectedRegionCode = "regionCode";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAvailableChannels, model.AvailableChannels);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedDefaultChannel, model.DefaultChannel);
        Assert.Equal(expectedFormatE164, model.FormatE164);
        Assert.Equal(expectedFormatInternational, model.FormatInternational);
        Assert.Equal(expectedFormatNational, model.FormatNational);
        Assert.Equal(expectedFormatRfc, model.FormatRfc);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedRegionCode, model.RegionCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContactListItem
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AvailableChannels = "availableChannels",
            CountryCode = "countryCode",
            DefaultChannel = "defaultChannel",
            FormatE164 = "formatE164",
            FormatInternational = "formatInternational",
            FormatNational = "formatNational",
            FormatRfc = "formatRfc",
            PhoneNumber = "phoneNumber",
            RegionCode = "regionCode",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactListItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContactListItem
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AvailableChannels = "availableChannels",
            CountryCode = "countryCode",
            DefaultChannel = "defaultChannel",
            FormatE164 = "formatE164",
            FormatInternational = "formatInternational",
            FormatNational = "formatNational",
            FormatRfc = "formatRfc",
            PhoneNumber = "phoneNumber",
            RegionCode = "regionCode",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactListItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAvailableChannels = "availableChannels";
        string expectedCountryCode = "countryCode";
        string expectedDefaultChannel = "defaultChannel";
        string expectedFormatE164 = "formatE164";
        string expectedFormatInternational = "formatInternational";
        string expectedFormatNational = "formatNational";
        string expectedFormatRfc = "formatRfc";
        string expectedPhoneNumber = "phoneNumber";
        string expectedRegionCode = "regionCode";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAvailableChannels, deserialized.AvailableChannels);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedDefaultChannel, deserialized.DefaultChannel);
        Assert.Equal(expectedFormatE164, deserialized.FormatE164);
        Assert.Equal(expectedFormatInternational, deserialized.FormatInternational);
        Assert.Equal(expectedFormatNational, deserialized.FormatNational);
        Assert.Equal(expectedFormatRfc, deserialized.FormatRfc);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedRegionCode, deserialized.RegionCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContactListItem
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AvailableChannels = "availableChannels",
            CountryCode = "countryCode",
            DefaultChannel = "defaultChannel",
            FormatE164 = "formatE164",
            FormatInternational = "formatInternational",
            FormatNational = "formatNational",
            FormatRfc = "formatRfc",
            PhoneNumber = "phoneNumber",
            RegionCode = "regionCode",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContactListItem { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AvailableChannels);
        Assert.False(model.RawData.ContainsKey("availableChannels"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.DefaultChannel);
        Assert.False(model.RawData.ContainsKey("defaultChannel"));
        Assert.Null(model.FormatE164);
        Assert.False(model.RawData.ContainsKey("formatE164"));
        Assert.Null(model.FormatInternational);
        Assert.False(model.RawData.ContainsKey("formatInternational"));
        Assert.Null(model.FormatNational);
        Assert.False(model.RawData.ContainsKey("formatNational"));
        Assert.Null(model.FormatRfc);
        Assert.False(model.RawData.ContainsKey("formatRfc"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.RegionCode);
        Assert.False(model.RawData.ContainsKey("regionCode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContactListItem { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContactListItem
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            AvailableChannels = null,
            CountryCode = null,
            DefaultChannel = null,
            FormatE164 = null,
            FormatInternational = null,
            FormatNational = null,
            FormatRfc = null,
            PhoneNumber = null,
            RegionCode = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AvailableChannels);
        Assert.False(model.RawData.ContainsKey("availableChannels"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.DefaultChannel);
        Assert.False(model.RawData.ContainsKey("defaultChannel"));
        Assert.Null(model.FormatE164);
        Assert.False(model.RawData.ContainsKey("formatE164"));
        Assert.Null(model.FormatInternational);
        Assert.False(model.RawData.ContainsKey("formatInternational"));
        Assert.Null(model.FormatNational);
        Assert.False(model.RawData.ContainsKey("formatNational"));
        Assert.Null(model.FormatRfc);
        Assert.False(model.RawData.ContainsKey("formatRfc"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.RegionCode);
        Assert.False(model.RawData.ContainsKey("regionCode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContactListItem
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            AvailableChannels = null,
            CountryCode = null,
            DefaultChannel = null,
            FormatE164 = null,
            FormatInternational = null,
            FormatNational = null,
            FormatRfc = null,
            PhoneNumber = null,
            RegionCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContactListItem
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AvailableChannels = "availableChannels",
            CountryCode = "countryCode",
            DefaultChannel = "defaultChannel",
            FormatE164 = "formatE164",
            FormatInternational = "formatInternational",
            FormatNational = "formatNational",
            FormatRfc = "formatRfc",
            PhoneNumber = "phoneNumber",
            RegionCode = "regionCode",
        };

        ContactListItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
