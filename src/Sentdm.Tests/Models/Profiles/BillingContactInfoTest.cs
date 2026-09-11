using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class BillingContactInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingContactInfo
        {
            Email = "dev@stainless.com",
            Name = "x",
            Address = "address",
            Phone = "phone",
        };

        string expectedEmail = "dev@stainless.com";
        string expectedName = "x";
        string expectedAddress = "address";
        string expectedPhone = "phone";

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedPhone, model.Phone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillingContactInfo
        {
            Email = "dev@stainless.com",
            Name = "x",
            Address = "address",
            Phone = "phone",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingContactInfo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillingContactInfo
        {
            Email = "dev@stainless.com",
            Name = "x",
            Address = "address",
            Phone = "phone",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingContactInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "dev@stainless.com";
        string expectedName = "x";
        string expectedAddress = "address";
        string expectedPhone = "phone";

        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedPhone, deserialized.Phone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillingContactInfo
        {
            Email = "dev@stainless.com",
            Name = "x",
            Address = "address",
            Phone = "phone",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BillingContactInfo { Email = "dev@stainless.com", Name = "x" };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BillingContactInfo { Email = "dev@stainless.com", Name = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BillingContactInfo
        {
            Email = "dev@stainless.com",
            Name = "x",

            Address = null,
            Phone = null,
        };

        Assert.Null(model.Address);
        Assert.True(model.RawData.ContainsKey("address"));
        Assert.Null(model.Phone);
        Assert.True(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BillingContactInfo
        {
            Email = "dev@stainless.com",
            Name = "x",

            Address = null,
            Phone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BillingContactInfo
        {
            Email = "dev@stainless.com",
            Name = "x",
            Address = "address",
            Phone = "phone",
        };

        BillingContactInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}
