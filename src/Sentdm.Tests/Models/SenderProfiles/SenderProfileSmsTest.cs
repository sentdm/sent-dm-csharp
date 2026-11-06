using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Sms;
using Sentdm.Models.SenderProfiles;

namespace Sentdm.Tests.Models.SenderProfiles;

public class SenderProfileSmsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SenderProfileSms
        {
            Country = "x",
            AreaCodes = ["string"],
            NumberType = "number_type",
            Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
            SenderValue = "sender_value",
        };

        string expectedCountry = "x";
        List<string> expectedAreaCodes = ["string"];
        string expectedNumberType = "number_type";
        List<SmsNumberRequest> expectedNumbers = [new() { AreaCode = "area_code", Quantity = 0 }];
        string expectedSenderValue = "sender_value";

        Assert.Equal(expectedCountry, model.Country);
        Assert.NotNull(model.AreaCodes);
        Assert.Equal(expectedAreaCodes.Count, model.AreaCodes.Count);
        for (int i = 0; i < expectedAreaCodes.Count; i++)
        {
            Assert.Equal(expectedAreaCodes[i], model.AreaCodes[i]);
        }
        Assert.Equal(expectedNumberType, model.NumberType);
        Assert.NotNull(model.Numbers);
        Assert.Equal(expectedNumbers.Count, model.Numbers.Count);
        for (int i = 0; i < expectedNumbers.Count; i++)
        {
            Assert.Equal(expectedNumbers[i], model.Numbers[i]);
        }
        Assert.Equal(expectedSenderValue, model.SenderValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SenderProfileSms
        {
            Country = "x",
            AreaCodes = ["string"],
            NumberType = "number_type",
            Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
            SenderValue = "sender_value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfileSms>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SenderProfileSms
        {
            Country = "x",
            AreaCodes = ["string"],
            NumberType = "number_type",
            Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
            SenderValue = "sender_value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfileSms>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCountry = "x";
        List<string> expectedAreaCodes = ["string"];
        string expectedNumberType = "number_type";
        List<SmsNumberRequest> expectedNumbers = [new() { AreaCode = "area_code", Quantity = 0 }];
        string expectedSenderValue = "sender_value";

        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.NotNull(deserialized.AreaCodes);
        Assert.Equal(expectedAreaCodes.Count, deserialized.AreaCodes.Count);
        for (int i = 0; i < expectedAreaCodes.Count; i++)
        {
            Assert.Equal(expectedAreaCodes[i], deserialized.AreaCodes[i]);
        }
        Assert.Equal(expectedNumberType, deserialized.NumberType);
        Assert.NotNull(deserialized.Numbers);
        Assert.Equal(expectedNumbers.Count, deserialized.Numbers.Count);
        for (int i = 0; i < expectedNumbers.Count; i++)
        {
            Assert.Equal(expectedNumbers[i], deserialized.Numbers[i]);
        }
        Assert.Equal(expectedSenderValue, deserialized.SenderValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SenderProfileSms
        {
            Country = "x",
            AreaCodes = ["string"],
            NumberType = "number_type",
            Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
            SenderValue = "sender_value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SenderProfileSms { Country = "x" };

        Assert.Null(model.AreaCodes);
        Assert.False(model.RawData.ContainsKey("area_codes"));
        Assert.Null(model.NumberType);
        Assert.False(model.RawData.ContainsKey("number_type"));
        Assert.Null(model.Numbers);
        Assert.False(model.RawData.ContainsKey("numbers"));
        Assert.Null(model.SenderValue);
        Assert.False(model.RawData.ContainsKey("sender_value"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SenderProfileSms { Country = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SenderProfileSms
        {
            Country = "x",

            AreaCodes = null,
            NumberType = null,
            Numbers = null,
            SenderValue = null,
        };

        Assert.Null(model.AreaCodes);
        Assert.True(model.RawData.ContainsKey("area_codes"));
        Assert.Null(model.NumberType);
        Assert.True(model.RawData.ContainsKey("number_type"));
        Assert.Null(model.Numbers);
        Assert.True(model.RawData.ContainsKey("numbers"));
        Assert.Null(model.SenderValue);
        Assert.True(model.RawData.ContainsKey("sender_value"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SenderProfileSms
        {
            Country = "x",

            AreaCodes = null,
            NumberType = null,
            Numbers = null,
            SenderValue = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SenderProfileSms
        {
            Country = "x",
            AreaCodes = ["string"],
            NumberType = "number_type",
            Numbers = [new() { AreaCode = "area_code", Quantity = 0 }],
            SenderValue = "sender_value",
        };

        SenderProfileSms copied = new(model);

        Assert.Equal(model, copied);
    }
}
