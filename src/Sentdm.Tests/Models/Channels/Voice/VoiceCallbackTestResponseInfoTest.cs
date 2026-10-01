using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Voice;

namespace Sentdm.Tests.Models.Channels.Voice;

public class VoiceCallbackTestResponseInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceCallbackTestResponseInfo { Body = "body", StatusCode = 0 };

        string expectedBody = "body";
        int expectedStatusCode = 0;

        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedStatusCode, model.StatusCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceCallbackTestResponseInfo { Body = "body", StatusCode = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceCallbackTestResponseInfo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceCallbackTestResponseInfo { Body = "body", StatusCode = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceCallbackTestResponseInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBody = "body";
        int expectedStatusCode = 0;

        Assert.Equal(expectedBody, deserialized.Body);
        Assert.Equal(expectedStatusCode, deserialized.StatusCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceCallbackTestResponseInfo { Body = "body", StatusCode = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceCallbackTestResponseInfo { Body = "body" };

        Assert.Null(model.StatusCode);
        Assert.False(model.RawData.ContainsKey("status_code"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceCallbackTestResponseInfo { Body = "body" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceCallbackTestResponseInfo
        {
            Body = "body",

            // Null should be interpreted as omitted for these properties
            StatusCode = null,
        };

        Assert.Null(model.StatusCode);
        Assert.False(model.RawData.ContainsKey("status_code"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceCallbackTestResponseInfo
        {
            Body = "body",

            // Null should be interpreted as omitted for these properties
            StatusCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceCallbackTestResponseInfo { StatusCode = 0 };

        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceCallbackTestResponseInfo { StatusCode = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VoiceCallbackTestResponseInfo
        {
            StatusCode = 0,

            Body = null,
        };

        Assert.Null(model.Body);
        Assert.True(model.RawData.ContainsKey("body"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceCallbackTestResponseInfo
        {
            StatusCode = 0,

            Body = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceCallbackTestResponseInfo { Body = "body", StatusCode = 0 };

        VoiceCallbackTestResponseInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}
