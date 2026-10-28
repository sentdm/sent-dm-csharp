using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Voice.Agents;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Voice.Agents;

public class ApiResponseOfVoiceAgentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiResponseOfVoiceAgent
        {
            Data = new()
            {
                ID = "id",
                Audio = new() { SampleRate = 0 },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Fallback = new() { Kind = "kind", Value = "value" },
                Greeting = "greeting",
                Limits = new()
                {
                    AllowedCountries = ["string"],
                    MaxCallSeconds = 0,
                    MaxConcurrentCalls = 0,
                },
                Name = "name",
                SessionType = "session_type",
                SigningSecret = "signing_secret",
                Speech = new()
                {
                    Language = "language",
                    Setting = "setting",
                    Voice = "voice",
                },
                Tools = ["string"],
                Transcripts = new() { RetentionDays = 0, Store = true },
                TransferTargets = [new() { Kind = "kind", Value = "value" }],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WebsocketUrl = "websocket_url",
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        VoiceAgent expectedData = new()
        {
            ID = "id",
            Audio = new() { SampleRate = 0 },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Fallback = new() { Kind = "kind", Value = "value" },
            Greeting = "greeting",
            Limits = new()
            {
                AllowedCountries = ["string"],
                MaxCallSeconds = 0,
                MaxConcurrentCalls = 0,
            },
            Name = "name",
            SessionType = "session_type",
            SigningSecret = "signing_secret",
            Speech = new()
            {
                Language = "language",
                Setting = "setting",
                Voice = "voice",
            },
            Tools = ["string"],
            Transcripts = new() { RetentionDays = 0, Store = true },
            TransferTargets = [new() { Kind = "kind", Value = "value" }],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebsocketUrl = "websocket_url",
        };
        ErrorDetail expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedMeta, model.Meta);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiResponseOfVoiceAgent
        {
            Data = new()
            {
                ID = "id",
                Audio = new() { SampleRate = 0 },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Fallback = new() { Kind = "kind", Value = "value" },
                Greeting = "greeting",
                Limits = new()
                {
                    AllowedCountries = ["string"],
                    MaxCallSeconds = 0,
                    MaxConcurrentCalls = 0,
                },
                Name = "name",
                SessionType = "session_type",
                SigningSecret = "signing_secret",
                Speech = new()
                {
                    Language = "language",
                    Setting = "setting",
                    Voice = "voice",
                },
                Tools = ["string"],
                Transcripts = new() { RetentionDays = 0, Store = true },
                TransferTargets = [new() { Kind = "kind", Value = "value" }],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WebsocketUrl = "websocket_url",
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfVoiceAgent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiResponseOfVoiceAgent
        {
            Data = new()
            {
                ID = "id",
                Audio = new() { SampleRate = 0 },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Fallback = new() { Kind = "kind", Value = "value" },
                Greeting = "greeting",
                Limits = new()
                {
                    AllowedCountries = ["string"],
                    MaxCallSeconds = 0,
                    MaxConcurrentCalls = 0,
                },
                Name = "name",
                SessionType = "session_type",
                SigningSecret = "signing_secret",
                Speech = new()
                {
                    Language = "language",
                    Setting = "setting",
                    Voice = "voice",
                },
                Tools = ["string"],
                Transcripts = new() { RetentionDays = 0, Store = true },
                TransferTargets = [new() { Kind = "kind", Value = "value" }],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WebsocketUrl = "websocket_url",
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfVoiceAgent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        VoiceAgent expectedData = new()
        {
            ID = "id",
            Audio = new() { SampleRate = 0 },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Fallback = new() { Kind = "kind", Value = "value" },
            Greeting = "greeting",
            Limits = new()
            {
                AllowedCountries = ["string"],
                MaxCallSeconds = 0,
                MaxConcurrentCalls = 0,
            },
            Name = "name",
            SessionType = "session_type",
            SigningSecret = "signing_secret",
            Speech = new()
            {
                Language = "language",
                Setting = "setting",
                Voice = "voice",
            },
            Tools = ["string"],
            Transcripts = new() { RetentionDays = 0, Store = true },
            TransferTargets = [new() { Kind = "kind", Value = "value" }],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebsocketUrl = "websocket_url",
        };
        ErrorDetail expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedMeta, deserialized.Meta);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiResponseOfVoiceAgent
        {
            Data = new()
            {
                ID = "id",
                Audio = new() { SampleRate = 0 },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Fallback = new() { Kind = "kind", Value = "value" },
                Greeting = "greeting",
                Limits = new()
                {
                    AllowedCountries = ["string"],
                    MaxCallSeconds = 0,
                    MaxConcurrentCalls = 0,
                },
                Name = "name",
                SessionType = "session_type",
                SigningSecret = "signing_secret",
                Speech = new()
                {
                    Language = "language",
                    Setting = "setting",
                    Voice = "voice",
                },
                Tools = ["string"],
                Transcripts = new() { RetentionDays = 0, Store = true },
                TransferTargets = [new() { Kind = "kind", Value = "value" }],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WebsocketUrl = "websocket_url",
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ApiResponseOfVoiceAgent
        {
            Data = new()
            {
                ID = "id",
                Audio = new() { SampleRate = 0 },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Fallback = new() { Kind = "kind", Value = "value" },
                Greeting = "greeting",
                Limits = new()
                {
                    AllowedCountries = ["string"],
                    MaxCallSeconds = 0,
                    MaxConcurrentCalls = 0,
                },
                Name = "name",
                SessionType = "session_type",
                SigningSecret = "signing_secret",
                Speech = new()
                {
                    Language = "language",
                    Setting = "setting",
                    Voice = "voice",
                },
                Tools = ["string"],
                Transcripts = new() { RetentionDays = 0, Store = true },
                TransferTargets = [new() { Kind = "kind", Value = "value" }],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WebsocketUrl = "websocket_url",
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
        };

        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ApiResponseOfVoiceAgent
        {
            Data = new()
            {
                ID = "id",
                Audio = new() { SampleRate = 0 },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Fallback = new() { Kind = "kind", Value = "value" },
                Greeting = "greeting",
                Limits = new()
                {
                    AllowedCountries = ["string"],
                    MaxCallSeconds = 0,
                    MaxConcurrentCalls = 0,
                },
                Name = "name",
                SessionType = "session_type",
                SigningSecret = "signing_secret",
                Speech = new()
                {
                    Language = "language",
                    Setting = "setting",
                    Voice = "voice",
                },
                Tools = ["string"],
                Transcripts = new() { RetentionDays = 0, Store = true },
                TransferTargets = [new() { Kind = "kind", Value = "value" }],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WebsocketUrl = "websocket_url",
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ApiResponseOfVoiceAgent
        {
            Data = new()
            {
                ID = "id",
                Audio = new() { SampleRate = 0 },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Fallback = new() { Kind = "kind", Value = "value" },
                Greeting = "greeting",
                Limits = new()
                {
                    AllowedCountries = ["string"],
                    MaxCallSeconds = 0,
                    MaxConcurrentCalls = 0,
                },
                Name = "name",
                SessionType = "session_type",
                SigningSecret = "signing_secret",
                Speech = new()
                {
                    Language = "language",
                    Setting = "setting",
                    Voice = "voice",
                },
                Tools = ["string"],
                Transcripts = new() { RetentionDays = 0, Store = true },
                TransferTargets = [new() { Kind = "kind", Value = "value" }],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WebsocketUrl = "websocket_url",
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },

            // Null should be interpreted as omitted for these properties
            Meta = null,
            Success = null,
        };

        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ApiResponseOfVoiceAgent
        {
            Data = new()
            {
                ID = "id",
                Audio = new() { SampleRate = 0 },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Fallback = new() { Kind = "kind", Value = "value" },
                Greeting = "greeting",
                Limits = new()
                {
                    AllowedCountries = ["string"],
                    MaxCallSeconds = 0,
                    MaxConcurrentCalls = 0,
                },
                Name = "name",
                SessionType = "session_type",
                SigningSecret = "signing_secret",
                Speech = new()
                {
                    Language = "language",
                    Setting = "setting",
                    Voice = "voice",
                },
                Tools = ["string"],
                Transcripts = new() { RetentionDays = 0, Store = true },
                TransferTargets = [new() { Kind = "kind", Value = "value" }],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WebsocketUrl = "websocket_url",
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },

            // Null should be interpreted as omitted for these properties
            Meta = null,
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ApiResponseOfVoiceAgent
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ApiResponseOfVoiceAgent
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ApiResponseOfVoiceAgent
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,

            Data = null,
            Error = null,
        };

        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ApiResponseOfVoiceAgent
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,

            Data = null,
            Error = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiResponseOfVoiceAgent
        {
            Data = new()
            {
                ID = "id",
                Audio = new() { SampleRate = 0 },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Fallback = new() { Kind = "kind", Value = "value" },
                Greeting = "greeting",
                Limits = new()
                {
                    AllowedCountries = ["string"],
                    MaxCallSeconds = 0,
                    MaxConcurrentCalls = 0,
                },
                Name = "name",
                SessionType = "session_type",
                SigningSecret = "signing_secret",
                Speech = new()
                {
                    Language = "language",
                    Setting = "setting",
                    Voice = "voice",
                },
                Tools = ["string"],
                Transcripts = new() { RetentionDays = 0, Store = true },
                TransferTargets = [new() { Kind = "kind", Value = "value" }],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WebsocketUrl = "websocket_url",
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        ApiResponseOfVoiceAgent copied = new(model);

        Assert.Equal(model, copied);
    }
}
