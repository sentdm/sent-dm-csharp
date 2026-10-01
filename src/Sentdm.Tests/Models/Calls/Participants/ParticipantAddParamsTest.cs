using System;
using System.Net.Http;
using Sentdm.Models.Calls.Participants;

namespace Sentdm.Tests.Models.Calls.Participants;

public class ParticipantAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ParticipantAddParams
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
            CallerID = "+12025550123",
            Sandbox = false,
            To = new() { Kind = "number", Value = "+14155551234" },
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "call_9f2ab000-0000-4000-8000-000000000001";
        string expectedCallerID = "+12025550123";
        bool expectedSandbox = false;
        CallParticipantTarget expectedTo = new() { Kind = "number", Value = "+14155551234" };
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCallerID, parameters.CallerID);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedTo, parameters.To);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ParticipantAddParams
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
            CallerID = "+12025550123",
        };

        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawBodyData.ContainsKey("to"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ParticipantAddParams
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
            CallerID = "+12025550123",

            // Null should be interpreted as omitted for these properties
            Sandbox = null,
            To = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawBodyData.ContainsKey("to"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ParticipantAddParams
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
            Sandbox = false,
            To = new() { Kind = "number", Value = "+14155551234" },
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.CallerID);
        Assert.False(parameters.RawBodyData.ContainsKey("caller_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ParticipantAddParams
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
            Sandbox = false,
            To = new() { Kind = "number", Value = "+14155551234" },
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            CallerID = null,
        };

        Assert.Null(parameters.CallerID);
        Assert.True(parameters.RawBodyData.ContainsKey("caller_id"));
    }

    [Fact]
    public void Url_Works()
    {
        ParticipantAddParams parameters = new()
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/calls/call_9f2ab000-0000-4000-8000-000000000001/participants"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ParticipantAddParams parameters = new()
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
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
        var parameters = new ParticipantAddParams
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
            CallerID = "+12025550123",
            Sandbox = false,
            To = new() { Kind = "number", Value = "+14155551234" },
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ParticipantAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
