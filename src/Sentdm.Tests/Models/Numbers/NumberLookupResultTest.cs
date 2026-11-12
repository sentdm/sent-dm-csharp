using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Numbers;

namespace Sentdm.Tests.Models.Numbers;

public class NumberLookupResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NumberLookupResult
        {
            CarrierName = "carrier_name",
            CountryCode = "country_code",
            IsPorted = true,
            IsValid = true,
            IsVoip = true,
            LineType = "line_type",
            MobileCountryCode = "mobile_country_code",
            MobileNetworkCode = "mobile_network_code",
            PhoneNumber = "phone_number",
        };

        string expectedCarrierName = "carrier_name";
        string expectedCountryCode = "country_code";
        bool expectedIsPorted = true;
        bool expectedIsValid = true;
        bool expectedIsVoip = true;
        string expectedLineType = "line_type";
        string expectedMobileCountryCode = "mobile_country_code";
        string expectedMobileNetworkCode = "mobile_network_code";
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedCarrierName, model.CarrierName);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedIsPorted, model.IsPorted);
        Assert.Equal(expectedIsValid, model.IsValid);
        Assert.Equal(expectedIsVoip, model.IsVoip);
        Assert.Equal(expectedLineType, model.LineType);
        Assert.Equal(expectedMobileCountryCode, model.MobileCountryCode);
        Assert.Equal(expectedMobileNetworkCode, model.MobileNetworkCode);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NumberLookupResult
        {
            CarrierName = "carrier_name",
            CountryCode = "country_code",
            IsPorted = true,
            IsValid = true,
            IsVoip = true,
            LineType = "line_type",
            MobileCountryCode = "mobile_country_code",
            MobileNetworkCode = "mobile_network_code",
            PhoneNumber = "phone_number",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NumberLookupResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NumberLookupResult
        {
            CarrierName = "carrier_name",
            CountryCode = "country_code",
            IsPorted = true,
            IsValid = true,
            IsVoip = true,
            LineType = "line_type",
            MobileCountryCode = "mobile_country_code",
            MobileNetworkCode = "mobile_network_code",
            PhoneNumber = "phone_number",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NumberLookupResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCarrierName = "carrier_name";
        string expectedCountryCode = "country_code";
        bool expectedIsPorted = true;
        bool expectedIsValid = true;
        bool expectedIsVoip = true;
        string expectedLineType = "line_type";
        string expectedMobileCountryCode = "mobile_country_code";
        string expectedMobileNetworkCode = "mobile_network_code";
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedCarrierName, deserialized.CarrierName);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedIsPorted, deserialized.IsPorted);
        Assert.Equal(expectedIsValid, deserialized.IsValid);
        Assert.Equal(expectedIsVoip, deserialized.IsVoip);
        Assert.Equal(expectedLineType, deserialized.LineType);
        Assert.Equal(expectedMobileCountryCode, deserialized.MobileCountryCode);
        Assert.Equal(expectedMobileNetworkCode, deserialized.MobileNetworkCode);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NumberLookupResult
        {
            CarrierName = "carrier_name",
            CountryCode = "country_code",
            IsPorted = true,
            IsValid = true,
            IsVoip = true,
            LineType = "line_type",
            MobileCountryCode = "mobile_country_code",
            MobileNetworkCode = "mobile_network_code",
            PhoneNumber = "phone_number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NumberLookupResult
        {
            CarrierName = "carrier_name",
            CountryCode = "country_code",
            IsPorted = true,
            IsVoip = true,
            LineType = "line_type",
            MobileCountryCode = "mobile_country_code",
            MobileNetworkCode = "mobile_network_code",
        };

        Assert.Null(model.IsValid);
        Assert.False(model.RawData.ContainsKey("is_valid"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NumberLookupResult
        {
            CarrierName = "carrier_name",
            CountryCode = "country_code",
            IsPorted = true,
            IsVoip = true,
            LineType = "line_type",
            MobileCountryCode = "mobile_country_code",
            MobileNetworkCode = "mobile_network_code",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NumberLookupResult
        {
            CarrierName = "carrier_name",
            CountryCode = "country_code",
            IsPorted = true,
            IsVoip = true,
            LineType = "line_type",
            MobileCountryCode = "mobile_country_code",
            MobileNetworkCode = "mobile_network_code",

            // Null should be interpreted as omitted for these properties
            IsValid = null,
            PhoneNumber = null,
        };

        Assert.Null(model.IsValid);
        Assert.False(model.RawData.ContainsKey("is_valid"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NumberLookupResult
        {
            CarrierName = "carrier_name",
            CountryCode = "country_code",
            IsPorted = true,
            IsVoip = true,
            LineType = "line_type",
            MobileCountryCode = "mobile_country_code",
            MobileNetworkCode = "mobile_network_code",

            // Null should be interpreted as omitted for these properties
            IsValid = null,
            PhoneNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NumberLookupResult { IsValid = true, PhoneNumber = "phone_number" };

        Assert.Null(model.CarrierName);
        Assert.False(model.RawData.ContainsKey("carrier_name"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.IsPorted);
        Assert.False(model.RawData.ContainsKey("is_ported"));
        Assert.Null(model.IsVoip);
        Assert.False(model.RawData.ContainsKey("is_voip"));
        Assert.Null(model.LineType);
        Assert.False(model.RawData.ContainsKey("line_type"));
        Assert.Null(model.MobileCountryCode);
        Assert.False(model.RawData.ContainsKey("mobile_country_code"));
        Assert.Null(model.MobileNetworkCode);
        Assert.False(model.RawData.ContainsKey("mobile_network_code"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new NumberLookupResult { IsValid = true, PhoneNumber = "phone_number" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NumberLookupResult
        {
            IsValid = true,
            PhoneNumber = "phone_number",

            CarrierName = null,
            CountryCode = null,
            IsPorted = null,
            IsVoip = null,
            LineType = null,
            MobileCountryCode = null,
            MobileNetworkCode = null,
        };

        Assert.Null(model.CarrierName);
        Assert.True(model.RawData.ContainsKey("carrier_name"));
        Assert.Null(model.CountryCode);
        Assert.True(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.IsPorted);
        Assert.True(model.RawData.ContainsKey("is_ported"));
        Assert.Null(model.IsVoip);
        Assert.True(model.RawData.ContainsKey("is_voip"));
        Assert.Null(model.LineType);
        Assert.True(model.RawData.ContainsKey("line_type"));
        Assert.Null(model.MobileCountryCode);
        Assert.True(model.RawData.ContainsKey("mobile_country_code"));
        Assert.Null(model.MobileNetworkCode);
        Assert.True(model.RawData.ContainsKey("mobile_network_code"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NumberLookupResult
        {
            IsValid = true,
            PhoneNumber = "phone_number",

            CarrierName = null,
            CountryCode = null,
            IsPorted = null,
            IsVoip = null,
            LineType = null,
            MobileCountryCode = null,
            MobileNetworkCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NumberLookupResult
        {
            CarrierName = "carrier_name",
            CountryCode = "country_code",
            IsPorted = true,
            IsValid = true,
            IsVoip = true,
            LineType = "line_type",
            MobileCountryCode = "mobile_country_code",
            MobileNetworkCode = "mobile_network_code",
            PhoneNumber = "phone_number",
        };

        NumberLookupResult copied = new(model);

        Assert.Equal(model, copied);
    }
}
