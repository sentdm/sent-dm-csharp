using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Me;

namespace Sentdm.Tests.Models.Me;

public class AccountSmsChannelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountSmsChannel { Configured = true, PhoneNumber = "phone_number" };

        bool expectedConfigured = true;
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedConfigured, model.Configured);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountSmsChannel { Configured = true, PhoneNumber = "phone_number" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountSmsChannel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountSmsChannel { Configured = true, PhoneNumber = "phone_number" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountSmsChannel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedConfigured = true;
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedConfigured, deserialized.Configured);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountSmsChannel { Configured = true, PhoneNumber = "phone_number" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountSmsChannel { PhoneNumber = "phone_number" };

        Assert.Null(model.Configured);
        Assert.False(model.RawData.ContainsKey("configured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountSmsChannel { PhoneNumber = "phone_number" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AccountSmsChannel
        {
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
        var model = new AccountSmsChannel
        {
            PhoneNumber = "phone_number",

            // Null should be interpreted as omitted for these properties
            Configured = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountSmsChannel { Configured = true };

        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountSmsChannel { Configured = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AccountSmsChannel
        {
            Configured = true,

            PhoneNumber = null,
        };

        Assert.Null(model.PhoneNumber);
        Assert.True(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountSmsChannel
        {
            Configured = true,

            PhoneNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountSmsChannel { Configured = true, PhoneNumber = "phone_number" };

        AccountSmsChannel copied = new(model);

        Assert.Equal(model, copied);
    }
}
