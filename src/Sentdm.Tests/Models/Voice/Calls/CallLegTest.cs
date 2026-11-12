using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Voice.Calls;

namespace Sentdm.Tests.Models.Voice.Calls;

public class CallLegTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallLeg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",
            Number = "number",
        };

        int expectedBilledMinutes = 0;
        double expectedCost = 0;
        string expectedCurrency = "currency";
        string expectedDirection = "direction";
        string expectedNumber = "number";

        Assert.Equal(expectedBilledMinutes, model.BilledMinutes);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDirection, model.Direction);
        Assert.Equal(expectedNumber, model.Number);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallLeg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",
            Number = "number",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallLeg>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallLeg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",
            Number = "number",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallLeg>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedBilledMinutes = 0;
        double expectedCost = 0;
        string expectedCurrency = "currency";
        string expectedDirection = "direction";
        string expectedNumber = "number";

        Assert.Equal(expectedBilledMinutes, deserialized.BilledMinutes);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDirection, deserialized.Direction);
        Assert.Equal(expectedNumber, deserialized.Number);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallLeg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",
            Number = "number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallLeg { Number = "number" };

        Assert.Null(model.BilledMinutes);
        Assert.False(model.RawData.ContainsKey("billed_minutes"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Direction);
        Assert.False(model.RawData.ContainsKey("direction"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallLeg { Number = "number" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CallLeg
        {
            Number = "number",

            // Null should be interpreted as omitted for these properties
            BilledMinutes = null,
            Cost = null,
            Currency = null,
            Direction = null,
        };

        Assert.Null(model.BilledMinutes);
        Assert.False(model.RawData.ContainsKey("billed_minutes"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Direction);
        Assert.False(model.RawData.ContainsKey("direction"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallLeg
        {
            Number = "number",

            // Null should be interpreted as omitted for these properties
            BilledMinutes = null,
            Cost = null,
            Currency = null,
            Direction = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallLeg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",
        };

        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallLeg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CallLeg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",

            Number = null,
        };

        Assert.Null(model.Number);
        Assert.True(model.RawData.ContainsKey("number"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallLeg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",

            Number = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallLeg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",
            Number = "number",
        };

        CallLeg copied = new(model);

        Assert.Equal(model, copied);
    }
}
