using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Calls;

namespace Sentdm.Tests.Models.Calls;

public class CallPartyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallParty { Kind = "kind", Value = "value" };

        string expectedKind = "kind";
        string expectedValue = "value";

        Assert.Equal(expectedKind, model.Kind);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallParty { Kind = "kind", Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallParty>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallParty { Kind = "kind", Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallParty>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedKind = "kind";
        string expectedValue = "value";

        Assert.Equal(expectedKind, deserialized.Kind);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallParty { Kind = "kind", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallParty { Value = "value" };

        Assert.Null(model.Kind);
        Assert.False(model.RawData.ContainsKey("kind"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallParty { Value = "value" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CallParty
        {
            Value = "value",

            // Null should be interpreted as omitted for these properties
            Kind = null,
        };

        Assert.Null(model.Kind);
        Assert.False(model.RawData.ContainsKey("kind"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallParty
        {
            Value = "value",

            // Null should be interpreted as omitted for these properties
            Kind = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallParty { Kind = "kind" };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallParty { Kind = "kind" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CallParty
        {
            Kind = "kind",

            Value = null,
        };

        Assert.Null(model.Value);
        Assert.True(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallParty
        {
            Kind = "kind",

            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallParty { Kind = "kind", Value = "value" };

        CallParty copied = new(model);

        Assert.Equal(model, copied);
    }
}
