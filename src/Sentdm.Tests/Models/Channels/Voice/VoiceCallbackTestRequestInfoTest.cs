using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Voice;

namespace Sentdm.Tests.Models.Channels.Voice;

public class VoiceCallbackTestRequestInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceCallbackTestRequestInfo
        {
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Url = "url",
        };

        string expectedBody = "body";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedUrl = "url";

        Assert.Equal(expectedBody, model.Body);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceCallbackTestRequestInfo
        {
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceCallbackTestRequestInfo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceCallbackTestRequestInfo
        {
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceCallbackTestRequestInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBody = "body";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedUrl = "url";

        Assert.Equal(expectedBody, deserialized.Body);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceCallbackTestRequestInfo
        {
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceCallbackTestRequestInfo { };

        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceCallbackTestRequestInfo { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceCallbackTestRequestInfo
        {
            // Null should be interpreted as omitted for these properties
            Body = null,
            Headers = null,
            Url = null,
        };

        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceCallbackTestRequestInfo
        {
            // Null should be interpreted as omitted for these properties
            Body = null,
            Headers = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceCallbackTestRequestInfo
        {
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Url = "url",
        };

        VoiceCallbackTestRequestInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}
