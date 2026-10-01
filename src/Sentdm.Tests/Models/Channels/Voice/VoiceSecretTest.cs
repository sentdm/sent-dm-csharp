using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Voice;

namespace Sentdm.Tests.Models.Channels.Voice;

public class VoiceSecretTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceSecret { CallbackSecret = "callback_secret" };

        string expectedCallbackSecret = "callback_secret";

        Assert.Equal(expectedCallbackSecret, model.CallbackSecret);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceSecret { CallbackSecret = "callback_secret" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceSecret>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceSecret { CallbackSecret = "callback_secret" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceSecret>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallbackSecret = "callback_secret";

        Assert.Equal(expectedCallbackSecret, deserialized.CallbackSecret);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceSecret { CallbackSecret = "callback_secret" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceSecret { };

        Assert.Null(model.CallbackSecret);
        Assert.False(model.RawData.ContainsKey("callback_secret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceSecret { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceSecret
        {
            // Null should be interpreted as omitted for these properties
            CallbackSecret = null,
        };

        Assert.Null(model.CallbackSecret);
        Assert.False(model.RawData.ContainsKey("callback_secret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceSecret
        {
            // Null should be interpreted as omitted for these properties
            CallbackSecret = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceSecret { CallbackSecret = "callback_secret" };

        VoiceSecret copied = new(model);

        Assert.Equal(model, copied);
    }
}
