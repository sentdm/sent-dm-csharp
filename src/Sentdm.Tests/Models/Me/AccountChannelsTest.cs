using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Me;

namespace Sentdm.Tests.Models.Me;

public class AccountChannelsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountChannels
        {
            Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
            Sms = new() { Configured = true, PhoneNumber = "phone_number" },
            Whatsapp = new()
            {
                BusinessName = "business_name",
                Configured = true,
                PhoneNumber = "phone_number",
            },
        };

        AccountRcsChannel expectedRcs = new() { Configured = true, PhoneNumber = "phone_number" };
        AccountSmsChannel expectedSms = new() { Configured = true, PhoneNumber = "phone_number" };
        AccountWhatsappChannel expectedWhatsapp = new()
        {
            BusinessName = "business_name",
            Configured = true,
            PhoneNumber = "phone_number",
        };

        Assert.Equal(expectedRcs, model.Rcs);
        Assert.Equal(expectedSms, model.Sms);
        Assert.Equal(expectedWhatsapp, model.Whatsapp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountChannels
        {
            Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
            Sms = new() { Configured = true, PhoneNumber = "phone_number" },
            Whatsapp = new()
            {
                BusinessName = "business_name",
                Configured = true,
                PhoneNumber = "phone_number",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountChannels>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountChannels
        {
            Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
            Sms = new() { Configured = true, PhoneNumber = "phone_number" },
            Whatsapp = new()
            {
                BusinessName = "business_name",
                Configured = true,
                PhoneNumber = "phone_number",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountChannels>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AccountRcsChannel expectedRcs = new() { Configured = true, PhoneNumber = "phone_number" };
        AccountSmsChannel expectedSms = new() { Configured = true, PhoneNumber = "phone_number" };
        AccountWhatsappChannel expectedWhatsapp = new()
        {
            BusinessName = "business_name",
            Configured = true,
            PhoneNumber = "phone_number",
        };

        Assert.Equal(expectedRcs, deserialized.Rcs);
        Assert.Equal(expectedSms, deserialized.Sms);
        Assert.Equal(expectedWhatsapp, deserialized.Whatsapp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountChannels
        {
            Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
            Sms = new() { Configured = true, PhoneNumber = "phone_number" },
            Whatsapp = new()
            {
                BusinessName = "business_name",
                Configured = true,
                PhoneNumber = "phone_number",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountChannels { };

        Assert.Null(model.Rcs);
        Assert.False(model.RawData.ContainsKey("rcs"));
        Assert.Null(model.Sms);
        Assert.False(model.RawData.ContainsKey("sms"));
        Assert.Null(model.Whatsapp);
        Assert.False(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountChannels { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AccountChannels
        {
            // Null should be interpreted as omitted for these properties
            Rcs = null,
            Sms = null,
            Whatsapp = null,
        };

        Assert.Null(model.Rcs);
        Assert.False(model.RawData.ContainsKey("rcs"));
        Assert.Null(model.Sms);
        Assert.False(model.RawData.ContainsKey("sms"));
        Assert.Null(model.Whatsapp);
        Assert.False(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountChannels
        {
            // Null should be interpreted as omitted for these properties
            Rcs = null,
            Sms = null,
            Whatsapp = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountChannels
        {
            Rcs = new() { Configured = true, PhoneNumber = "phone_number" },
            Sms = new() { Configured = true, PhoneNumber = "phone_number" },
            Whatsapp = new()
            {
                BusinessName = "business_name",
                Configured = true,
                PhoneNumber = "phone_number",
            },
        };

        AccountChannels copied = new(model);

        Assert.Equal(model, copied);
    }
}
