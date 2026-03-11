using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfoTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo
        {
            Name = "x",
            BusinessName = "businessName",
            Email = "dev@stainless.com",
            Phone = "phone",
            PhoneCountryCode = "phoneCountryCode",
            Role = "role",
        };

        string expectedName = "x";
        string expectedBusinessName = "businessName";
        string expectedEmail = "dev@stainless.com";
        string expectedPhone = "phone";
        string expectedPhoneCountryCode = "phoneCountryCode";
        string expectedRole = "role";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBusinessName, model.BusinessName);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedPhone, model.Phone);
        Assert.Equal(expectedPhoneCountryCode, model.PhoneCountryCode);
        Assert.Equal(expectedRole, model.Role);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo
        {
            Name = "x",
            BusinessName = "businessName",
            Email = "dev@stainless.com",
            Phone = "phone",
            PhoneCountryCode = "phoneCountryCode",
            Role = "role",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo
        {
            Name = "x",
            BusinessName = "businessName",
            Email = "dev@stainless.com",
            Phone = "phone",
            PhoneCountryCode = "phoneCountryCode",
            Role = "role",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        string expectedBusinessName = "businessName";
        string expectedEmail = "dev@stainless.com";
        string expectedPhone = "phone";
        string expectedPhoneCountryCode = "phoneCountryCode";
        string expectedRole = "role";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBusinessName, deserialized.BusinessName);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedPhone, deserialized.Phone);
        Assert.Equal(expectedPhoneCountryCode, deserialized.PhoneCountryCode);
        Assert.Equal(expectedRole, deserialized.Role);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo
        {
            Name = "x",
            BusinessName = "businessName",
            Email = "dev@stainless.com",
            Phone = "phone",
            PhoneCountryCode = "phoneCountryCode",
            Role = "role",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo
        {
            Name = "x",
        };

        Assert.Null(model.BusinessName);
        Assert.False(model.RawData.ContainsKey("businessName"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
        Assert.Null(model.PhoneCountryCode);
        Assert.False(model.RawData.ContainsKey("phoneCountryCode"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo
        {
            Name = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo
        {
            Name = "x",

            BusinessName = null,
            Email = null,
            Phone = null,
            PhoneCountryCode = null,
            Role = null,
        };

        Assert.Null(model.BusinessName);
        Assert.True(model.RawData.ContainsKey("businessName"));
        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.Phone);
        Assert.True(model.RawData.ContainsKey("phone"));
        Assert.Null(model.PhoneCountryCode);
        Assert.True(model.RawData.ContainsKey("phoneCountryCode"));
        Assert.Null(model.Role);
        Assert.True(model.RawData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo
        {
            Name = "x",

            BusinessName = null,
            Email = null,
            Phone = null,
            PhoneCountryCode = null,
            Role = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo
        {
            Name = "x",
            BusinessName = "businessName",
            Email = "dev@stainless.com",
            Phone = "phone",
            PhoneCountryCode = "phoneCountryCode",
            Role = "role",
        };

        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandContactInfo copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}
