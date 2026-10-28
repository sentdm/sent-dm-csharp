using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Voice.Agents;

namespace Sentdm.Tests.Models.Voice.Agents;

public class VoiceAgentAudioTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceAgentAudio { SampleRate = 0 };

        int expectedSampleRate = 0;

        Assert.Equal(expectedSampleRate, model.SampleRate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceAgentAudio { SampleRate = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentAudio>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceAgentAudio { SampleRate = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentAudio>(
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
        var model = new VoiceAgentAudio { SampleRate = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceAgentAudio { };

        Assert.Null(model.SampleRate);
        Assert.False(model.RawData.ContainsKey("sample_rate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceAgentAudio { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceAgentAudio
        {
            // Null should be interpreted as omitted for these properties
            SampleRate = null,
        };

        Assert.Null(model.SampleRate);
        Assert.False(model.RawData.ContainsKey("sample_rate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceAgentAudio
        {
            // Null should be interpreted as omitted for these properties
            SampleRate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceAgentAudio { SampleRate = 0 };

        VoiceAgentAudio copied = new(model);

        Assert.Equal(model, copied);
    }
}
