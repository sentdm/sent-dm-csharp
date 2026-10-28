using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Voice.Agents;

namespace Sentdm.Tests.Models.Voice.Agents;

public class VoiceAgentPartySpecTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceAgentPartySpec { Kind = "kind", Value = "value" };

        string expectedKind = "kind";
        string expectedValue = "value";

        Assert.Equal(expectedKind, model.Kind);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceAgentPartySpec { Kind = "kind", Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentPartySpec>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceAgentPartySpec { Kind = "kind", Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentPartySpec>(
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
        var model = new VoiceAgentPartySpec { Kind = "kind", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceAgentPartySpec { };

        Assert.Null(model.Kind);
        Assert.False(model.RawData.ContainsKey("kind"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceAgentPartySpec { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VoiceAgentPartySpec { Kind = null, Value = null };

        Assert.Null(model.Kind);
        Assert.True(model.RawData.ContainsKey("kind"));
        Assert.Null(model.Value);
        Assert.True(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceAgentPartySpec { Kind = null, Value = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceAgentPartySpec { Kind = "kind", Value = "value" };

        VoiceAgentPartySpec copied = new(model);

        Assert.Equal(model, copied);
    }
}
