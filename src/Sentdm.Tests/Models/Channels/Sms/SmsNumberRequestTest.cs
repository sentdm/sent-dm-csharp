using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Sms;

namespace Sentdm.Tests.Models.Channels.Sms;

public class SmsNumberRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SmsNumberRequest { AreaCode = "area_code", Quantity = 0 };

        string expectedAreaCode = "area_code";
        int expectedQuantity = 0;

        Assert.Equal(expectedAreaCode, model.AreaCode);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SmsNumberRequest { AreaCode = "area_code", Quantity = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SmsNumberRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SmsNumberRequest { AreaCode = "area_code", Quantity = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SmsNumberRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAreaCode = "area_code";
        int expectedQuantity = 0;

        Assert.Equal(expectedAreaCode, deserialized.AreaCode);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SmsNumberRequest { AreaCode = "area_code", Quantity = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SmsNumberRequest { };

        Assert.Null(model.AreaCode);
        Assert.False(model.RawData.ContainsKey("area_code"));
        Assert.Null(model.Quantity);
        Assert.False(model.RawData.ContainsKey("quantity"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SmsNumberRequest { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SmsNumberRequest { AreaCode = null, Quantity = null };

        Assert.Null(model.AreaCode);
        Assert.True(model.RawData.ContainsKey("area_code"));
        Assert.Null(model.Quantity);
        Assert.True(model.RawData.ContainsKey("quantity"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SmsNumberRequest { AreaCode = null, Quantity = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SmsNumberRequest { AreaCode = "area_code", Quantity = 0 };

        SmsNumberRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
