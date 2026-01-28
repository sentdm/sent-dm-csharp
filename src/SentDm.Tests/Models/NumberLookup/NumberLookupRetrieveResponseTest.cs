using System.Text.Json;
using SentDm.Core;
using SentDm.Models.NumberLookup;

namespace SentDm.Tests.Models.NumberLookup;

public class NumberLookupRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NumberLookupRetrieveResponse
        {
            CountryCode = "countryCode",
            FormatE164 = "formatE164",
            FormatInternational = "formatInternational",
            FormatNational = "formatNational",
            FormatRfc = "formatRfc",
            NumberType = "numberType",
            PhoneNumber = "phoneNumber",
            PhoneTimezones = "phoneTimezones",
            RegionCode = "regionCode",
        };

        string expectedCountryCode = "countryCode";
        string expectedFormatE164 = "formatE164";
        string expectedFormatInternational = "formatInternational";
        string expectedFormatNational = "formatNational";
        string expectedFormatRfc = "formatRfc";
        string expectedNumberType = "numberType";
        string expectedPhoneNumber = "phoneNumber";
        string expectedPhoneTimezones = "phoneTimezones";
        string expectedRegionCode = "regionCode";

        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedFormatE164, model.FormatE164);
        Assert.Equal(expectedFormatInternational, model.FormatInternational);
        Assert.Equal(expectedFormatNational, model.FormatNational);
        Assert.Equal(expectedFormatRfc, model.FormatRfc);
        Assert.Equal(expectedNumberType, model.NumberType);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedPhoneTimezones, model.PhoneTimezones);
        Assert.Equal(expectedRegionCode, model.RegionCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NumberLookupRetrieveResponse
        {
            CountryCode = "countryCode",
            FormatE164 = "formatE164",
            FormatInternational = "formatInternational",
            FormatNational = "formatNational",
            FormatRfc = "formatRfc",
            NumberType = "numberType",
            PhoneNumber = "phoneNumber",
            PhoneTimezones = "phoneTimezones",
            RegionCode = "regionCode",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NumberLookupRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NumberLookupRetrieveResponse
        {
            CountryCode = "countryCode",
            FormatE164 = "formatE164",
            FormatInternational = "formatInternational",
            FormatNational = "formatNational",
            FormatRfc = "formatRfc",
            NumberType = "numberType",
            PhoneNumber = "phoneNumber",
            PhoneTimezones = "phoneTimezones",
            RegionCode = "regionCode",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NumberLookupRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCountryCode = "countryCode";
        string expectedFormatE164 = "formatE164";
        string expectedFormatInternational = "formatInternational";
        string expectedFormatNational = "formatNational";
        string expectedFormatRfc = "formatRfc";
        string expectedNumberType = "numberType";
        string expectedPhoneNumber = "phoneNumber";
        string expectedPhoneTimezones = "phoneTimezones";
        string expectedRegionCode = "regionCode";

        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedFormatE164, deserialized.FormatE164);
        Assert.Equal(expectedFormatInternational, deserialized.FormatInternational);
        Assert.Equal(expectedFormatNational, deserialized.FormatNational);
        Assert.Equal(expectedFormatRfc, deserialized.FormatRfc);
        Assert.Equal(expectedNumberType, deserialized.NumberType);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedPhoneTimezones, deserialized.PhoneTimezones);
        Assert.Equal(expectedRegionCode, deserialized.RegionCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NumberLookupRetrieveResponse
        {
            CountryCode = "countryCode",
            FormatE164 = "formatE164",
            FormatInternational = "formatInternational",
            FormatNational = "formatNational",
            FormatRfc = "formatRfc",
            NumberType = "numberType",
            PhoneNumber = "phoneNumber",
            PhoneTimezones = "phoneTimezones",
            RegionCode = "regionCode",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NumberLookupRetrieveResponse { };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.FormatE164);
        Assert.False(model.RawData.ContainsKey("formatE164"));
        Assert.Null(model.FormatInternational);
        Assert.False(model.RawData.ContainsKey("formatInternational"));
        Assert.Null(model.FormatNational);
        Assert.False(model.RawData.ContainsKey("formatNational"));
        Assert.Null(model.FormatRfc);
        Assert.False(model.RawData.ContainsKey("formatRfc"));
        Assert.Null(model.NumberType);
        Assert.False(model.RawData.ContainsKey("numberType"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.PhoneTimezones);
        Assert.False(model.RawData.ContainsKey("phoneTimezones"));
        Assert.Null(model.RegionCode);
        Assert.False(model.RawData.ContainsKey("regionCode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NumberLookupRetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NumberLookupRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            FormatE164 = null,
            FormatInternational = null,
            FormatNational = null,
            FormatRfc = null,
            NumberType = null,
            PhoneNumber = null,
            PhoneTimezones = null,
            RegionCode = null,
        };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.FormatE164);
        Assert.False(model.RawData.ContainsKey("formatE164"));
        Assert.Null(model.FormatInternational);
        Assert.False(model.RawData.ContainsKey("formatInternational"));
        Assert.Null(model.FormatNational);
        Assert.False(model.RawData.ContainsKey("formatNational"));
        Assert.Null(model.FormatRfc);
        Assert.False(model.RawData.ContainsKey("formatRfc"));
        Assert.Null(model.NumberType);
        Assert.False(model.RawData.ContainsKey("numberType"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.PhoneTimezones);
        Assert.False(model.RawData.ContainsKey("phoneTimezones"));
        Assert.Null(model.RegionCode);
        Assert.False(model.RawData.ContainsKey("regionCode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NumberLookupRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            FormatE164 = null,
            FormatInternational = null,
            FormatNational = null,
            FormatRfc = null,
            NumberType = null,
            PhoneNumber = null,
            PhoneTimezones = null,
            RegionCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NumberLookupRetrieveResponse
        {
            CountryCode = "countryCode",
            FormatE164 = "formatE164",
            FormatInternational = "formatInternational",
            FormatNational = "formatNational",
            FormatRfc = "formatRfc",
            NumberType = "numberType",
            PhoneNumber = "phoneNumber",
            PhoneTimezones = "phoneTimezones",
            RegionCode = "regionCode",
        };

        NumberLookupRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
