using System;
using System.Net.Http;
using Sentdm.Models.Channels.Voice;

namespace Sentdm.Tests.Models.Channels.Voice;

public class VoiceCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VoiceCreateParams
        {
            CallbackUrl = "https://example.com/voice",
            AreaCode = null,
            DefaultForAppCalls = false,
            Number = "+12125550100",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedCallbackUrl = "https://example.com/voice";
        bool expectedDefaultForAppCalls = false;
        string expectedNumber = "+12125550100";
        bool expectedSandbox = false;
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedCallbackUrl, parameters.CallbackUrl);
        Assert.Null(parameters.AreaCode);
        Assert.Equal(expectedDefaultForAppCalls, parameters.DefaultForAppCalls);
        Assert.Equal(expectedNumber, parameters.Number);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VoiceCreateParams
        {
            CallbackUrl = "https://example.com/voice",
            AreaCode = null,
            DefaultForAppCalls = false,
            Number = "+12125550100",
        };

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
        var parameters = new VoiceCreateParams
        {
            CallbackUrl = "https://example.com/voice",
            AreaCode = null,
            DefaultForAppCalls = false,
            Number = "+12125550100",

            // Null should be interpreted as omitted for these properties
            Sandbox = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

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
        var parameters = new VoiceCreateParams
        {
            CallbackUrl = "https://example.com/voice",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.AreaCode);
        Assert.False(parameters.RawBodyData.ContainsKey("area_code"));
        Assert.Null(parameters.DefaultForAppCalls);
        Assert.False(parameters.RawBodyData.ContainsKey("default_for_app_calls"));
        Assert.Null(parameters.Number);
        Assert.False(parameters.RawBodyData.ContainsKey("number"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new VoiceCreateParams
        {
            CallbackUrl = "https://example.com/voice",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            AreaCode = null,
            DefaultForAppCalls = null,
            Number = null,
        };

        Assert.Null(parameters.AreaCode);
        Assert.True(parameters.RawBodyData.ContainsKey("area_code"));
        Assert.Null(parameters.DefaultForAppCalls);
        Assert.True(parameters.RawBodyData.ContainsKey("default_for_app_calls"));
        Assert.Null(parameters.Number);
        Assert.True(parameters.RawBodyData.ContainsKey("number"));
    }

    [Fact]
    public void Url_Works()
    {
        VoiceCreateParams parameters = new() { CallbackUrl = "https://example.com/voice" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.sent.dm/v3/channels/voice"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        VoiceCreateParams parameters = new()
        {
            CallbackUrl = "https://example.com/voice",
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
        var parameters = new VoiceCreateParams
        {
            CallbackUrl = "https://example.com/voice",
            AreaCode = null,
            DefaultForAppCalls = false,
            Number = "+12125550100",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        VoiceCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
