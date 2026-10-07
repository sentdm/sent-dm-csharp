using System;
using System.Net.Http;
using Sentdm.Models.Channels.Voice;

namespace Sentdm.Tests.Models.Channels.Voice;

public class VoiceCreateTokenParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VoiceCreateTokenParams
        {
            Identity = "agent-42",
            Number = "+12025550123",
            Sandbox = false,
            Ttl = 600,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedIdentity = "agent-42";
        string expectedNumber = "+12025550123";
        bool expectedSandbox = false;
        int expectedTtl = 600;
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedIdentity, parameters.Identity);
        Assert.Equal(expectedNumber, parameters.Number);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedTtl, parameters.Ttl);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VoiceCreateTokenParams { Number = "+12025550123", Ttl = 600 };

        Assert.Null(parameters.Identity);
        Assert.False(parameters.RawBodyData.ContainsKey("identity"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VoiceCreateTokenParams
        {
            Number = "+12025550123",
            Ttl = 600,

            // Null should be interpreted as omitted for these properties
            Identity = null,
            Sandbox = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.Identity);
        Assert.False(parameters.RawBodyData.ContainsKey("identity"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VoiceCreateTokenParams
        {
            Identity = "agent-42",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Number);
        Assert.False(parameters.RawBodyData.ContainsKey("number"));
        Assert.Null(parameters.Ttl);
        Assert.False(parameters.RawBodyData.ContainsKey("ttl"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new VoiceCreateTokenParams
        {
            Identity = "agent-42",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            Number = null,
            Ttl = null,
        };

        Assert.Null(parameters.Number);
        Assert.True(parameters.RawBodyData.ContainsKey("number"));
        Assert.Null(parameters.Ttl);
        Assert.True(parameters.RawBodyData.ContainsKey("ttl"));
    }

    [Fact]
    public void Url_Works()
    {
        VoiceCreateTokenParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.sent.dm/v3/channels/voice/tokens"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        VoiceCreateTokenParams parameters = new()
        {
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
        var parameters = new VoiceCreateTokenParams
        {
            Identity = "agent-42",
            Number = "+12025550123",
            Sandbox = false,
            Ttl = 600,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        VoiceCreateTokenParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
