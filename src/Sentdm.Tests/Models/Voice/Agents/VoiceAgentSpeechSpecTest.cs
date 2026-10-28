using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Voice.Agents;

namespace Sentdm.Tests.Models.Voice.Agents;

public class VoiceAgentSpeechSpecTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceAgentSpeechSpec
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
        var model = new VoiceAgentSpeechSpec
        {
            Language = "language",
            Setting = "setting",
            Voice = "voice",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentSpeechSpec>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceAgentSpeechSpec
        {
            Language = "language",
            Setting = "setting",
            Voice = "voice",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentSpeechSpec>(
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
        var model = new VoiceAgentSpeechSpec
        {
            Language = "language",
            Setting = "setting",
            Voice = "voice",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceAgentSpeechSpec { };

        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.Setting);
        Assert.False(model.RawData.ContainsKey("setting"));
        Assert.Null(model.Voice);
        Assert.False(model.RawData.ContainsKey("voice"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceAgentSpeechSpec { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VoiceAgentSpeechSpec
        {
            Language = null,
            Setting = null,
            Voice = null,
        };

        Assert.Null(model.Language);
        Assert.True(model.RawData.ContainsKey("language"));
        Assert.Null(model.Setting);
        Assert.True(model.RawData.ContainsKey("setting"));
        Assert.Null(model.Voice);
        Assert.True(model.RawData.ContainsKey("voice"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceAgentSpeechSpec
        {
            Language = null,
            Setting = null,
            Voice = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceAgentSpeechSpec
        {
            Language = "language",
            Setting = "setting",
            Voice = "voice",
        };

        VoiceAgentSpeechSpec copied = new(model);

        Assert.Equal(model, copied);
    }
}
