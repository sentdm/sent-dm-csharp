using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Voice;

namespace Sentdm.Tests.Models.Channels.Voice;

public class VoiceCallbackTestErrorInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceCallbackTestErrorInfo
        {
            Message = "message",
            Path = "path",
            Reason = "reason",
        };

        string expectedMessage = "message";
        string expectedPath = "path";
        string expectedReason = "reason";

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceCallbackTestErrorInfo
        {
            Message = "message",
            Path = "path",
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceCallbackTestErrorInfo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceCallbackTestErrorInfo
        {
            Message = "message",
            Path = "path",
            Reason = "reason",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceCallbackTestErrorInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        string expectedPath = "path";
        string expectedReason = "reason";

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceCallbackTestErrorInfo
        {
            Message = "message",
            Path = "path",
            Reason = "reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceCallbackTestErrorInfo { Path = "path" };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceCallbackTestErrorInfo { Path = "path" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceCallbackTestErrorInfo
        {
            Path = "path",

            // Null should be interpreted as omitted for these properties
            Message = null,
            Reason = null,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceCallbackTestErrorInfo
        {
            Path = "path",

            // Null should be interpreted as omitted for these properties
            Message = null,
            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceCallbackTestErrorInfo { Message = "message", Reason = "reason" };

        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceCallbackTestErrorInfo { Message = "message", Reason = "reason" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VoiceCallbackTestErrorInfo
        {
            Message = "message",
            Reason = "reason",

            Path = null,
        };

        Assert.Null(model.Path);
        Assert.True(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceCallbackTestErrorInfo
        {
            Message = "message",
            Reason = "reason",

            Path = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceCallbackTestErrorInfo
        {
            Message = "message",
            Path = "path",
            Reason = "reason",
        };

        VoiceCallbackTestErrorInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}
