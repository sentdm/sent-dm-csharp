using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Voice.Agents;

namespace Sentdm.Tests.Models.Voice.Agents;

public class VoiceAgentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceAgent
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

        string expectedID = "id";
        VoiceAgentAudio expectedAudio = new() { SampleRate = 0 };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        VoiceAgentParty expectedFallback = new() { Kind = "kind", Value = "value" };
        string expectedGreeting = "greeting";
        VoiceAgentLimits expectedLimits = new()
        {
            AllowedCountries = ["string"],
            MaxCallSeconds = 0,
            MaxConcurrentCalls = 0,
        };
        string expectedName = "name";
        string expectedSessionType = "session_type";
        string expectedSigningSecret = "signing_secret";
        VoiceAgentSpeech expectedSpeech = new()
        {
            Language = "language",
            Setting = "setting",
            Voice = "voice",
        };
        List<string> expectedTools = ["string"];
        VoiceAgentTranscripts expectedTranscripts = new() { RetentionDays = 0, Store = true };
        List<VoiceAgentParty> expectedTransferTargets = [new() { Kind = "kind", Value = "value" }];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedWebsocketUrl = "websocket_url";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAudio, model.Audio);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFallback, model.Fallback);
        Assert.Equal(expectedGreeting, model.Greeting);
        Assert.Equal(expectedLimits, model.Limits);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSessionType, model.SessionType);
        Assert.Equal(expectedSigningSecret, model.SigningSecret);
        Assert.Equal(expectedSpeech, model.Speech);
        Assert.NotNull(model.Tools);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
        Assert.Equal(expectedTranscripts, model.Transcripts);
        Assert.NotNull(model.TransferTargets);
        Assert.Equal(expectedTransferTargets.Count, model.TransferTargets.Count);
        for (int i = 0; i < expectedTransferTargets.Count; i++)
        {
            Assert.Equal(expectedTransferTargets[i], model.TransferTargets[i]);
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedWebsocketUrl, model.WebsocketUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceAgent
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceAgent
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        VoiceAgentAudio expectedAudio = new() { SampleRate = 0 };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        VoiceAgentParty expectedFallback = new() { Kind = "kind", Value = "value" };
        string expectedGreeting = "greeting";
        VoiceAgentLimits expectedLimits = new()
        {
            AllowedCountries = ["string"],
            MaxCallSeconds = 0,
            MaxConcurrentCalls = 0,
        };
        string expectedName = "name";
        string expectedSessionType = "session_type";
        string expectedSigningSecret = "signing_secret";
        VoiceAgentSpeech expectedSpeech = new()
        {
            Language = "language",
            Setting = "setting",
            Voice = "voice",
        };
        List<string> expectedTools = ["string"];
        VoiceAgentTranscripts expectedTranscripts = new() { RetentionDays = 0, Store = true };
        List<VoiceAgentParty> expectedTransferTargets = [new() { Kind = "kind", Value = "value" }];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedWebsocketUrl = "websocket_url";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAudio, deserialized.Audio);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFallback, deserialized.Fallback);
        Assert.Equal(expectedGreeting, deserialized.Greeting);
        Assert.Equal(expectedLimits, deserialized.Limits);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSessionType, deserialized.SessionType);
        Assert.Equal(expectedSigningSecret, deserialized.SigningSecret);
        Assert.Equal(expectedSpeech, deserialized.Speech);
        Assert.NotNull(deserialized.Tools);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
        Assert.Equal(expectedTranscripts, deserialized.Transcripts);
        Assert.NotNull(deserialized.TransferTargets);
        Assert.Equal(expectedTransferTargets.Count, deserialized.TransferTargets.Count);
        for (int i = 0; i < expectedTransferTargets.Count; i++)
        {
            Assert.Equal(expectedTransferTargets[i], deserialized.TransferTargets[i]);
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedWebsocketUrl, deserialized.WebsocketUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceAgent
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceAgent
        {
            Audio = new() { SampleRate = 0 },
            Fallback = new() { Kind = "kind", Value = "value" },
            Greeting = "greeting",
            SigningSecret = "signing_secret",
            Speech = new()
            {
                Language = "language",
                Setting = "setting",
                Voice = "voice",
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebsocketUrl = "websocket_url",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Limits);
        Assert.False(model.RawData.ContainsKey("limits"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.SessionType);
        Assert.False(model.RawData.ContainsKey("session_type"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.Transcripts);
        Assert.False(model.RawData.ContainsKey("transcripts"));
        Assert.Null(model.TransferTargets);
        Assert.False(model.RawData.ContainsKey("transfer_targets"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceAgent
        {
            Audio = new() { SampleRate = 0 },
            Fallback = new() { Kind = "kind", Value = "value" },
            Greeting = "greeting",
            SigningSecret = "signing_secret",
            Speech = new()
            {
                Language = "language",
                Setting = "setting",
                Voice = "voice",
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebsocketUrl = "websocket_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceAgent
        {
            Audio = new() { SampleRate = 0 },
            Fallback = new() { Kind = "kind", Value = "value" },
            Greeting = "greeting",
            SigningSecret = "signing_secret",
            Speech = new()
            {
                Language = "language",
                Setting = "setting",
                Voice = "voice",
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebsocketUrl = "websocket_url",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Limits = null,
            Name = null,
            SessionType = null,
            Tools = null,
            Transcripts = null,
            TransferTargets = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Limits);
        Assert.False(model.RawData.ContainsKey("limits"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.SessionType);
        Assert.False(model.RawData.ContainsKey("session_type"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.Transcripts);
        Assert.False(model.RawData.ContainsKey("transcripts"));
        Assert.Null(model.TransferTargets);
        Assert.False(model.RawData.ContainsKey("transfer_targets"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceAgent
        {
            Audio = new() { SampleRate = 0 },
            Fallback = new() { Kind = "kind", Value = "value" },
            Greeting = "greeting",
            SigningSecret = "signing_secret",
            Speech = new()
            {
                Language = "language",
                Setting = "setting",
                Voice = "voice",
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebsocketUrl = "websocket_url",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Limits = null,
            Name = null,
            SessionType = null,
            Tools = null,
            Transcripts = null,
            TransferTargets = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceAgent
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limits = new()
            {
                AllowedCountries = ["string"],
                MaxCallSeconds = 0,
                MaxConcurrentCalls = 0,
            },
            Name = "name",
            SessionType = "session_type",
            Tools = ["string"],
            Transcripts = new() { RetentionDays = 0, Store = true },
            TransferTargets = [new() { Kind = "kind", Value = "value" }],
        };

        Assert.Null(model.Audio);
        Assert.False(model.RawData.ContainsKey("audio"));
        Assert.Null(model.Fallback);
        Assert.False(model.RawData.ContainsKey("fallback"));
        Assert.Null(model.Greeting);
        Assert.False(model.RawData.ContainsKey("greeting"));
        Assert.Null(model.SigningSecret);
        Assert.False(model.RawData.ContainsKey("signing_secret"));
        Assert.Null(model.Speech);
        Assert.False(model.RawData.ContainsKey("speech"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.WebsocketUrl);
        Assert.False(model.RawData.ContainsKey("websocket_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceAgent
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limits = new()
            {
                AllowedCountries = ["string"],
                MaxCallSeconds = 0,
                MaxConcurrentCalls = 0,
            },
            Name = "name",
            SessionType = "session_type",
            Tools = ["string"],
            Transcripts = new() { RetentionDays = 0, Store = true },
            TransferTargets = [new() { Kind = "kind", Value = "value" }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VoiceAgent
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limits = new()
            {
                AllowedCountries = ["string"],
                MaxCallSeconds = 0,
                MaxConcurrentCalls = 0,
            },
            Name = "name",
            SessionType = "session_type",
            Tools = ["string"],
            Transcripts = new() { RetentionDays = 0, Store = true },
            TransferTargets = [new() { Kind = "kind", Value = "value" }],

            Audio = null,
            Fallback = null,
            Greeting = null,
            SigningSecret = null,
            Speech = null,
            UpdatedAt = null,
            WebsocketUrl = null,
        };

        Assert.Null(model.Audio);
        Assert.True(model.RawData.ContainsKey("audio"));
        Assert.Null(model.Fallback);
        Assert.True(model.RawData.ContainsKey("fallback"));
        Assert.Null(model.Greeting);
        Assert.True(model.RawData.ContainsKey("greeting"));
        Assert.Null(model.SigningSecret);
        Assert.True(model.RawData.ContainsKey("signing_secret"));
        Assert.Null(model.Speech);
        Assert.True(model.RawData.ContainsKey("speech"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.WebsocketUrl);
        Assert.True(model.RawData.ContainsKey("websocket_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceAgent
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limits = new()
            {
                AllowedCountries = ["string"],
                MaxCallSeconds = 0,
                MaxConcurrentCalls = 0,
            },
            Name = "name",
            SessionType = "session_type",
            Tools = ["string"],
            Transcripts = new() { RetentionDays = 0, Store = true },
            TransferTargets = [new() { Kind = "kind", Value = "value" }],

            Audio = null,
            Fallback = null,
            Greeting = null,
            SigningSecret = null,
            Speech = null,
            UpdatedAt = null,
            WebsocketUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceAgent
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

        VoiceAgent copied = new(model);

        Assert.Equal(model, copied);
    }
}
