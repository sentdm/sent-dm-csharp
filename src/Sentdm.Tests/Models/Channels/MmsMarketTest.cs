using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels;

namespace Sentdm.Tests.Models.Channels;

public class MmsMarketTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MmsMarket
        {
            Country = "country",
            NumberType = "number_type",
            SenderValue = "sender_value",
            Status = "status",
        };

        string expectedCountry = "country";
        string expectedNumberType = "number_type";
        string expectedSenderValue = "sender_value";
        string expectedStatus = "status";

        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedNumberType, model.NumberType);
        Assert.Equal(expectedSenderValue, model.SenderValue);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MmsMarket
        {
            Country = "country",
            NumberType = "number_type",
            SenderValue = "sender_value",
            Status = "status",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MmsMarket>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MmsMarket
        {
            Country = "country",
            NumberType = "number_type",
            SenderValue = "sender_value",
            Status = "status",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MmsMarket>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCountry = "country";
        string expectedNumberType = "number_type";
        string expectedSenderValue = "sender_value";
        string expectedStatus = "status";

        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedNumberType, deserialized.NumberType);
        Assert.Equal(expectedSenderValue, deserialized.SenderValue);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MmsMarket
        {
            Country = "country",
            NumberType = "number_type",
            SenderValue = "sender_value",
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MmsMarket { };

        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.NumberType);
        Assert.False(model.RawData.ContainsKey("number_type"));
        Assert.Null(model.SenderValue);
        Assert.False(model.RawData.ContainsKey("sender_value"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MmsMarket { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MmsMarket
        {
            Country = null,
            NumberType = null,
            SenderValue = null,
            Status = null,
        };

        Assert.Null(model.Country);
        Assert.True(model.RawData.ContainsKey("country"));
        Assert.Null(model.NumberType);
        Assert.True(model.RawData.ContainsKey("number_type"));
        Assert.Null(model.SenderValue);
        Assert.True(model.RawData.ContainsKey("sender_value"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MmsMarket
        {
            Country = null,
            NumberType = null,
            SenderValue = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MmsMarket
        {
            Country = "country",
            NumberType = "number_type",
            SenderValue = "sender_value",
            Status = "status",
        };

        MmsMarket copied = new(model);

        Assert.Equal(model, copied);
    }
}
