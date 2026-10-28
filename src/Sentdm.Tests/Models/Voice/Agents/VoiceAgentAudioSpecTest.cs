using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Voice.Agents;

namespace Sentdm.Tests.Models.Voice.Agents;

public class VoiceAgentAudioSpecTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceAgentAudioSpec { SampleRate = 0 };

        int expectedSampleRate = 0;

        Assert.Equal(expectedSampleRate, model.SampleRate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceAgentAudioSpec { SampleRate = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentAudioSpec>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceAgentAudioSpec { SampleRate = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentAudioSpec>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedSampleRate = 0;

        Assert.Equal(expectedSampleRate, deserialized.SampleRate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceAgentAudioSpec { SampleRate = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceAgentAudioSpec { };

        Assert.Null(model.SampleRate);
        Assert.False(model.RawData.ContainsKey("sample_rate"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceAgentAudioSpec { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VoiceAgentAudioSpec { SampleRate = null };

        Assert.Null(model.SampleRate);
        Assert.True(model.RawData.ContainsKey("sample_rate"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceAgentAudioSpec { SampleRate = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceAgentAudioSpec { SampleRate = 0 };

        VoiceAgentAudioSpec copied = new(model);

        Assert.Equal(model, copied);
    }
}
