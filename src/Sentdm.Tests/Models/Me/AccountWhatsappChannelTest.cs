using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Me;

namespace Sentdm.Tests.Models.Me;

public class AccountWhatsappChannelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountWhatsappChannel
        {
            BusinessName = "business_name",
            Configured = true,
            PhoneNumber = "phone_number",
        };

        string expectedBusinessName = "business_name";
        bool expectedConfigured = true;
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedBusinessName, model.BusinessName);
        Assert.Equal(expectedConfigured, model.Configured);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountWhatsappChannel
        {
            BusinessName = "business_name",
            Configured = true,
            PhoneNumber = "phone_number",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountWhatsappChannel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountWhatsappChannel
        {
            BusinessName = "business_name",
            Configured = true,
            PhoneNumber = "phone_number",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountWhatsappChannel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessName = "business_name";
        bool expectedConfigured = true;
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedBusinessName, deserialized.BusinessName);
        Assert.Equal(expectedConfigured, deserialized.Configured);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountWhatsappChannel
        {
            BusinessName = "business_name",
            Configured = true,
            PhoneNumber = "phone_number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountWhatsappChannel
        {
            BusinessName = "business_name",
            PhoneNumber = "phone_number",
        };

        Assert.Null(model.Configured);
        Assert.False(model.RawData.ContainsKey("configured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountWhatsappChannel
        {
            BusinessName = "business_name",
            PhoneNumber = "phone_number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AccountWhatsappChannel
        {
            BusinessName = "business_name",
            PhoneNumber = "phone_number",

            // Null should be interpreted as omitted for these properties
            Configured = null,
        };

        Assert.Null(model.Configured);
        Assert.False(model.RawData.ContainsKey("configured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountWhatsappChannel
        {
            BusinessName = "business_name",
            PhoneNumber = "phone_number",

            // Null should be interpreted as omitted for these properties
            Configured = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountWhatsappChannel { Configured = true };

        Assert.Null(model.BusinessName);
        Assert.False(model.RawData.ContainsKey("business_name"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountWhatsappChannel { Configured = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AccountWhatsappChannel
        {
            Configured = true,

            BusinessName = null,
            PhoneNumber = null,
        };

        Assert.Null(model.BusinessName);
        Assert.True(model.RawData.ContainsKey("business_name"));
        Assert.Null(model.PhoneNumber);
        Assert.True(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountWhatsappChannel
        {
            Configured = true,

            BusinessName = null,
            PhoneNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountWhatsappChannel
        {
            BusinessName = "business_name",
            Configured = true,
            PhoneNumber = "phone_number",
        };

        AccountWhatsappChannel copied = new(model);

        Assert.Equal(model, copied);
    }
}
