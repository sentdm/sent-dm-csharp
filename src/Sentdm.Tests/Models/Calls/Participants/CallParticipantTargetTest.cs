using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Calls.Participants;

namespace Sentdm.Tests.Models.Calls.Participants;

public class CallParticipantTargetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallParticipantTarget { Kind = "kind", Value = "value" };

        string expectedKind = "kind";
        string expectedValue = "value";

        Assert.Equal(expectedKind, model.Kind);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallParticipantTarget { Kind = "kind", Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallParticipantTarget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallParticipantTarget { Kind = "kind", Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallParticipantTarget>(
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
        var model = new CallParticipantTarget { Kind = "kind", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallParticipantTarget { };

        Assert.Null(model.Kind);
        Assert.False(model.RawData.ContainsKey("kind"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallParticipantTarget { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CallParticipantTarget
        {
            // Null should be interpreted as omitted for these properties
            Kind = null,
            Value = null,
        };

        Assert.Null(model.Kind);
        Assert.False(model.RawData.ContainsKey("kind"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallParticipantTarget
        {
            // Null should be interpreted as omitted for these properties
            Kind = null,
            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallParticipantTarget { Kind = "kind", Value = "value" };

        CallParticipantTarget copied = new(model);

        Assert.Equal(model, copied);
    }
}
