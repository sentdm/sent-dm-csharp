using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Voice.Agents;

namespace Sentdm.Tests.Models.Voice.Agents;

public class VoiceAgentTranscriptsSpecTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceAgentTranscriptsSpec { RetentionDays = 0, Store = true };

        int expectedRetentionDays = 0;
        bool expectedStore = true;

        Assert.Equal(expectedRetentionDays, model.RetentionDays);
        Assert.Equal(expectedStore, model.Store);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceAgentTranscriptsSpec { RetentionDays = 0, Store = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentTranscriptsSpec>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceAgentTranscriptsSpec { RetentionDays = 0, Store = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentTranscriptsSpec>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedRetentionDays = 0;
        bool expectedStore = true;

        Assert.Equal(expectedRetentionDays, deserialized.RetentionDays);
        Assert.Equal(expectedStore, deserialized.Store);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceAgentTranscriptsSpec { RetentionDays = 0, Store = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceAgentTranscriptsSpec { };

        Assert.Null(model.RetentionDays);
        Assert.False(model.RawData.ContainsKey("retention_days"));
        Assert.Null(model.Store);
        Assert.False(model.RawData.ContainsKey("store"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceAgentTranscriptsSpec { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VoiceAgentTranscriptsSpec { RetentionDays = null, Store = null };

        Assert.Null(model.RetentionDays);
        Assert.True(model.RawData.ContainsKey("retention_days"));
        Assert.Null(model.Store);
        Assert.True(model.RawData.ContainsKey("store"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceAgentTranscriptsSpec { RetentionDays = null, Store = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceAgentTranscriptsSpec { RetentionDays = 0, Store = true };

        VoiceAgentTranscriptsSpec copied = new(model);

        Assert.Equal(model, copied);
    }
}
