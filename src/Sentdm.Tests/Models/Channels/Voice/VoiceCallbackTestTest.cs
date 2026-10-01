using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Voice;

namespace Sentdm.Tests.Models.Channels.Voice;

public class VoiceCallbackTestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceCallbackTest
        {
            Answer = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "call_id",
            Error = new()
            {
                Message = "message",
                Path = "path",
                Reason = "reason",
            },
            Outcome = "outcome",
            Request = new()
            {
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Url = "url",
            },
            Response = new() { Body = "body", StatusCode = 0 },
        };

        JsonElement expectedAnswer = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedCallID = "call_id";
        VoiceCallbackTestErrorInfo expectedError = new()
        {
            Message = "message",
            Path = "path",
            Reason = "reason",
        };
        string expectedOutcome = "outcome";
        VoiceCallbackTestRequestInfo expectedRequest = new()
        {
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Url = "url",
        };
        VoiceCallbackTestResponseInfo expectedResponse = new() { Body = "body", StatusCode = 0 };

        Assert.NotNull(model.Answer);
        Assert.True(JsonElement.DeepEquals(expectedAnswer, model.Answer.Value));
        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedOutcome, model.Outcome);
        Assert.Equal(expectedRequest, model.Request);
        Assert.Equal(expectedResponse, model.Response);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceCallbackTest
        {
            Answer = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "call_id",
            Error = new()
            {
                Message = "message",
                Path = "path",
                Reason = "reason",
            },
            Outcome = "outcome",
            Request = new()
            {
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Url = "url",
            },
            Response = new() { Body = "body", StatusCode = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceCallbackTest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceCallbackTest
        {
            Answer = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "call_id",
            Error = new()
            {
                Message = "message",
                Path = "path",
                Reason = "reason",
            },
            Outcome = "outcome",
            Request = new()
            {
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Url = "url",
            },
            Response = new() { Body = "body", StatusCode = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceCallbackTest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedAnswer = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedCallID = "call_id";
        VoiceCallbackTestErrorInfo expectedError = new()
        {
            Message = "message",
            Path = "path",
            Reason = "reason",
        };
        string expectedOutcome = "outcome";
        VoiceCallbackTestRequestInfo expectedRequest = new()
        {
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Url = "url",
        };
        VoiceCallbackTestResponseInfo expectedResponse = new() { Body = "body", StatusCode = 0 };

        Assert.NotNull(deserialized.Answer);
        Assert.True(JsonElement.DeepEquals(expectedAnswer, deserialized.Answer.Value));
        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedOutcome, deserialized.Outcome);
        Assert.Equal(expectedRequest, deserialized.Request);
        Assert.Equal(expectedResponse, deserialized.Response);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceCallbackTest
        {
            Answer = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "call_id",
            Error = new()
            {
                Message = "message",
                Path = "path",
                Reason = "reason",
            },
            Outcome = "outcome",
            Request = new()
            {
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Url = "url",
            },
            Response = new() { Body = "body", StatusCode = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceCallbackTest
        {
            Answer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Error = new()
            {
                Message = "message",
                Path = "path",
                Reason = "reason",
            },
            Request = new()
            {
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Url = "url",
            },
            Response = new() { Body = "body", StatusCode = 0 },
        };

        Assert.Null(model.CallID);
        Assert.False(model.RawData.ContainsKey("call_id"));
        Assert.Null(model.Outcome);
        Assert.False(model.RawData.ContainsKey("outcome"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceCallbackTest
        {
            Answer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Error = new()
            {
                Message = "message",
                Path = "path",
                Reason = "reason",
            },
            Request = new()
            {
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Url = "url",
            },
            Response = new() { Body = "body", StatusCode = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceCallbackTest
        {
            Answer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Error = new()
            {
                Message = "message",
                Path = "path",
                Reason = "reason",
            },
            Request = new()
            {
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Url = "url",
            },
            Response = new() { Body = "body", StatusCode = 0 },

            // Null should be interpreted as omitted for these properties
            CallID = null,
            Outcome = null,
        };

        Assert.Null(model.CallID);
        Assert.False(model.RawData.ContainsKey("call_id"));
        Assert.Null(model.Outcome);
        Assert.False(model.RawData.ContainsKey("outcome"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceCallbackTest
        {
            Answer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Error = new()
            {
                Message = "message",
                Path = "path",
                Reason = "reason",
            },
            Request = new()
            {
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Url = "url",
            },
            Response = new() { Body = "body", StatusCode = 0 },

            // Null should be interpreted as omitted for these properties
            CallID = null,
            Outcome = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceCallbackTest { CallID = "call_id", Outcome = "outcome" };

        Assert.Null(model.Answer);
        Assert.False(model.RawData.ContainsKey("answer"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Request);
        Assert.False(model.RawData.ContainsKey("request"));
        Assert.Null(model.Response);
        Assert.False(model.RawData.ContainsKey("response"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceCallbackTest { CallID = "call_id", Outcome = "outcome" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VoiceCallbackTest
        {
            CallID = "call_id",
            Outcome = "outcome",

            Answer = null,
            Error = null,
            Request = null,
            Response = null,
        };

        Assert.Null(model.Answer);
        Assert.True(model.RawData.ContainsKey("answer"));
        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
        Assert.Null(model.Request);
        Assert.True(model.RawData.ContainsKey("request"));
        Assert.Null(model.Response);
        Assert.True(model.RawData.ContainsKey("response"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceCallbackTest
        {
            CallID = "call_id",
            Outcome = "outcome",

            Answer = null,
            Error = null,
            Request = null,
            Response = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceCallbackTest
        {
            Answer = JsonSerializer.Deserialize<JsonElement>("{}"),
            CallID = "call_id",
            Error = new()
            {
                Message = "message",
                Path = "path",
                Reason = "reason",
            },
            Outcome = "outcome",
            Request = new()
            {
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Url = "url",
            },
            Response = new() { Body = "body", StatusCode = 0 },
        };

        VoiceCallbackTest copied = new(model);

        Assert.Equal(model, copied);
    }
}
