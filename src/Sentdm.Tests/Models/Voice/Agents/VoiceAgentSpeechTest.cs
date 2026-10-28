using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Voice.Agents;

namespace Sentdm.Tests.Models.Voice.Agents;

public class VoiceAgentSpeechTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceAgentSpeech
        {
            Language = "language",
            Setting = "setting",
            Voice = "voice",
        };

        string expectedLanguage = "language";
        string expectedSetting = "setting";
        string expectedVoice = "voice";

        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedSetting, model.Setting);
        Assert.Equal(expectedVoice, model.Voice);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceAgentSpeech
        {
            Language = "language",
            Setting = "setting",
            Voice = "voice",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentSpeech>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceAgentSpeech
        {
            Language = "language",
            Setting = "setting",
            Voice = "voice",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentSpeech>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedLanguage = "language";
        string expectedSetting = "setting";
        string expectedVoice = "voice";

        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.Equal(expectedSetting, deserialized.Setting);
        Assert.Equal(expectedVoice, deserialized.Voice);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceAgentSpeech
        {
            Language = "language",
            Setting = "setting",
            Voice = "voice",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceAgentSpeech { };

        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.Setting);
        Assert.False(model.RawData.ContainsKey("setting"));
        Assert.Null(model.Voice);
        Assert.False(model.RawData.ContainsKey("voice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceAgentSpeech { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceAgentSpeech
        {
            // Null should be interpreted as omitted for these properties
            Language = null,
            Setting = null,
            Voice = null,
        };

        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.Setting);
        Assert.False(model.RawData.ContainsKey("setting"));
        Assert.Null(model.Voice);
        Assert.False(model.RawData.ContainsKey("voice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceAgentSpeech
        {
            // Null should be interpreted as omitted for these properties
            Language = null,
            Setting = null,
            Voice = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceAgentSpeech
        {
            Language = "language",
            Setting = "setting",
            Voice = "voice",
        };

        VoiceAgentSpeech copied = new(model);

        Assert.Equal(model, copied);
    }
}
