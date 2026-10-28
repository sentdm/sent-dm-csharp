using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Voice.Agents;

namespace Sentdm.Tests.Models.Voice.Agents;

public class VoiceAgentTranscriptsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceAgentTranscripts { RetentionDays = 0, Store = true };

        int expectedRetentionDays = 0;
        bool expectedStore = true;

        Assert.Equal(expectedRetentionDays, model.RetentionDays);
        Assert.Equal(expectedStore, model.Store);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceAgentTranscripts { RetentionDays = 0, Store = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentTranscripts>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceAgentTranscripts { RetentionDays = 0, Store = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentTranscripts>(
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
        var model = new VoiceAgentTranscripts { RetentionDays = 0, Store = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceAgentTranscripts { };

        Assert.Null(model.RetentionDays);
        Assert.False(model.RawData.ContainsKey("retention_days"));
        Assert.Null(model.Store);
        Assert.False(model.RawData.ContainsKey("store"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceAgentTranscripts { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceAgentTranscripts
        {
            // Null should be interpreted as omitted for these properties
            RetentionDays = null,
            Store = null,
        };

        Assert.Null(model.RetentionDays);
        Assert.False(model.RawData.ContainsKey("retention_days"));
        Assert.Null(model.Store);
        Assert.False(model.RawData.ContainsKey("store"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceAgentTranscripts
        {
            // Null should be interpreted as omitted for these properties
            RetentionDays = null,
            Store = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceAgentTranscripts { RetentionDays = 0, Store = true };

        VoiceAgentTranscripts copied = new(model);

        Assert.Equal(model, copied);
    }
}
