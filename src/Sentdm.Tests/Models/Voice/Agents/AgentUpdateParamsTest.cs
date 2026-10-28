using System;
using System.Collections.Generic;
using System.Net.Http;
using Sentdm.Models.Voice.Agents;

namespace Sentdm.Tests.Models.Voice.Agents;

public class AgentUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentUpdateParams
        {
            ID = "id",
            Audio = new() { SampleRate = 0 },
            Fallback = new() { Kind = "kind", Value = "value" },
            Greeting = "greeting",
            Limits = new()
            {
                AllowedCountries = ["string"],
                MaxCallSeconds = 0,
                MaxConcurrentCalls = 0,
            },
            Name = "name",
            Sandbox = false,
            SessionType = "session_type",
            Speech = new()
            {
                Language = "language",
                Setting = "setting",
                Voice = "voice",
            },
            Tools = ["string"],
            Transcripts = new() { RetentionDays = 0, Store = true },
            TransferTargets = [new() { Kind = "kind", Value = "value" }],
            WebsocketUrl = "websocket_url",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "id";
        VoiceAgentAudioSpec expectedAudio = new() { SampleRate = 0 };
        VoiceAgentPartySpec expectedFallback = new() { Kind = "kind", Value = "value" };
        string expectedGreeting = "greeting";
        VoiceAgentLimitsSpec expectedLimits = new()
        {
            AllowedCountries = ["string"],
            MaxCallSeconds = 0,
            MaxConcurrentCalls = 0,
        };
        string expectedName = "name";
        bool expectedSandbox = false;
        string expectedSessionType = "session_type";
        VoiceAgentSpeechSpec expectedSpeech = new()
        {
            Language = "language",
            Setting = "setting",
            Voice = "voice",
        };
        List<string> expectedTools = ["string"];
        VoiceAgentTranscriptsSpec expectedTranscripts = new() { RetentionDays = 0, Store = true };
        List<VoiceAgentPartySpec> expectedTransferTargets =
        [
            new() { Kind = "kind", Value = "value" },
        ];
        string expectedWebsocketUrl = "websocket_url";
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAudio, parameters.Audio);
        Assert.Equal(expectedFallback, parameters.Fallback);
        Assert.Equal(expectedGreeting, parameters.Greeting);
        Assert.Equal(expectedLimits, parameters.Limits);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedSessionType, parameters.SessionType);
        Assert.Equal(expectedSpeech, parameters.Speech);
        Assert.NotNull(parameters.Tools);
        Assert.Equal(expectedTools.Count, parameters.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], parameters.Tools[i]);
        }
        Assert.Equal(expectedTranscripts, parameters.Transcripts);
        Assert.NotNull(parameters.TransferTargets);
        Assert.Equal(expectedTransferTargets.Count, parameters.TransferTargets.Count);
        for (int i = 0; i < expectedTransferTargets.Count; i++)
        {
            Assert.Equal(expectedTransferTargets[i], parameters.TransferTargets[i]);
        }
        Assert.Equal(expectedWebsocketUrl, parameters.WebsocketUrl);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentUpdateParams
        {
            ID = "id",
            Audio = new() { SampleRate = 0 },
            Fallback = new() { Kind = "kind", Value = "value" },
            Greeting = "greeting",
            Limits = new()
            {
                AllowedCountries = ["string"],
                MaxCallSeconds = 0,
                MaxConcurrentCalls = 0,
            },
            Speech = new()
            {
                Language = "language",
                Setting = "setting",
                Voice = "voice",
            },
            Tools = ["string"],
            Transcripts = new() { RetentionDays = 0, Store = true },
            TransferTargets = [new() { Kind = "kind", Value = "value" }],
            WebsocketUrl = "websocket_url",
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.SessionType);
        Assert.False(parameters.RawBodyData.ContainsKey("session_type"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AgentUpdateParams
        {
            ID = "id",
            Audio = new() { SampleRate = 0 },
            Fallback = new() { Kind = "kind", Value = "value" },
            Greeting = "greeting",
            Limits = new()
            {
                AllowedCountries = ["string"],
                MaxCallSeconds = 0,
                MaxConcurrentCalls = 0,
            },
            Speech = new()
            {
                Language = "language",
                Setting = "setting",
                Voice = "voice",
            },
            Tools = ["string"],
            Transcripts = new() { RetentionDays = 0, Store = true },
            TransferTargets = [new() { Kind = "kind", Value = "value" }],
            WebsocketUrl = "websocket_url",

            // Null should be interpreted as omitted for these properties
            Name = null,
            Sandbox = null,
            SessionType = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.SessionType);
        Assert.False(parameters.RawBodyData.ContainsKey("session_type"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentUpdateParams
        {
            ID = "id",
            Name = "name",
            Sandbox = false,
            SessionType = "session_type",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Audio);
        Assert.False(parameters.RawBodyData.ContainsKey("audio"));
        Assert.Null(parameters.Fallback);
        Assert.False(parameters.RawBodyData.ContainsKey("fallback"));
        Assert.Null(parameters.Greeting);
        Assert.False(parameters.RawBodyData.ContainsKey("greeting"));
        Assert.Null(parameters.Limits);
        Assert.False(parameters.RawBodyData.ContainsKey("limits"));
        Assert.Null(parameters.Speech);
        Assert.False(parameters.RawBodyData.ContainsKey("speech"));
        Assert.Null(parameters.Tools);
        Assert.False(parameters.RawBodyData.ContainsKey("tools"));
        Assert.Null(parameters.Transcripts);
        Assert.False(parameters.RawBodyData.ContainsKey("transcripts"));
        Assert.Null(parameters.TransferTargets);
        Assert.False(parameters.RawBodyData.ContainsKey("transfer_targets"));
        Assert.Null(parameters.WebsocketUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("websocket_url"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AgentUpdateParams
        {
            ID = "id",
            Name = "name",
            Sandbox = false,
            SessionType = "session_type",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            Audio = null,
            Fallback = null,
            Greeting = null,
            Limits = null,
            Speech = null,
            Tools = null,
            Transcripts = null,
            TransferTargets = null,
            WebsocketUrl = null,
        };

        Assert.Null(parameters.Audio);
        Assert.True(parameters.RawBodyData.ContainsKey("audio"));
        Assert.Null(parameters.Fallback);
        Assert.True(parameters.RawBodyData.ContainsKey("fallback"));
        Assert.Null(parameters.Greeting);
        Assert.True(parameters.RawBodyData.ContainsKey("greeting"));
        Assert.Null(parameters.Limits);
        Assert.True(parameters.RawBodyData.ContainsKey("limits"));
        Assert.Null(parameters.Speech);
        Assert.True(parameters.RawBodyData.ContainsKey("speech"));
        Assert.Null(parameters.Tools);
        Assert.True(parameters.RawBodyData.ContainsKey("tools"));
        Assert.Null(parameters.Transcripts);
        Assert.True(parameters.RawBodyData.ContainsKey("transcripts"));
        Assert.Null(parameters.TransferTargets);
        Assert.True(parameters.RawBodyData.ContainsKey("transfer_targets"));
        Assert.Null(parameters.WebsocketUrl);
        Assert.True(parameters.RawBodyData.ContainsKey("websocket_url"));
    }

    [Fact]
    public void Url_Works()
    {
        AgentUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.sent.dm/v3/voice/agents/id"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AgentUpdateParams parameters = new()
        {
            ID = "id",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
        Assert.Equal(
            ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            requestMessage.Headers.GetValues("x-profile-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AgentUpdateParams
        {
            ID = "id",
            Audio = new() { SampleRate = 0 },
            Fallback = new() { Kind = "kind", Value = "value" },
            Greeting = "greeting",
            Limits = new()
            {
                AllowedCountries = ["string"],
                MaxCallSeconds = 0,
                MaxConcurrentCalls = 0,
            },
            Name = "name",
            Sandbox = false,
            SessionType = "session_type",
            Speech = new()
            {
                Language = "language",
                Setting = "setting",
                Voice = "voice",
            },
            Tools = ["string"],
            Transcripts = new() { RetentionDays = 0, Store = true },
            TransferTargets = [new() { Kind = "kind", Value = "value" }],
            WebsocketUrl = "websocket_url",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        AgentUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
