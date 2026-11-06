using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Sms;

namespace Sentdm.Tests.Models.Channels.Sms;

public class SmsNumberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SmsNumber
        {
            AreaCode = "area_code",
            SenderValue = "sender_value",
            Status = "status",
        };

        string expectedAreaCode = "area_code";
        string expectedSenderValue = "sender_value";
        string expectedStatus = "status";

        Assert.Equal(expectedAreaCode, model.AreaCode);
        Assert.Equal(expectedSenderValue, model.SenderValue);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SmsNumber
        {
            AreaCode = "area_code",
            SenderValue = "sender_value",
            Status = "status",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SmsNumber>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SmsNumber
        {
            AreaCode = "area_code",
            SenderValue = "sender_value",
            Status = "status",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SmsNumber>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAreaCode = "area_code";
        string expectedSenderValue = "sender_value";
        string expectedStatus = "status";

        Assert.Equal(expectedAreaCode, deserialized.AreaCode);
        Assert.Equal(expectedSenderValue, deserialized.SenderValue);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SmsNumber
        {
            AreaCode = "area_code",
            SenderValue = "sender_value",
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SmsNumber { };

        Assert.Null(model.AreaCode);
        Assert.False(model.RawData.ContainsKey("area_code"));
        Assert.Null(model.SenderValue);
        Assert.False(model.RawData.ContainsKey("sender_value"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SmsNumber { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SmsNumber
        {
            AreaCode = null,
            SenderValue = null,
            Status = null,
        };

        Assert.Null(model.AreaCode);
        Assert.True(model.RawData.ContainsKey("area_code"));
        Assert.Null(model.SenderValue);
        Assert.True(model.RawData.ContainsKey("sender_value"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SmsNumber
        {
            AreaCode = null,
            SenderValue = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SmsNumber
        {
            AreaCode = "area_code",
            SenderValue = "sender_value",
            Status = "status",
        };

        SmsNumber copied = new(model);

        Assert.Equal(model, copied);
    }
}
