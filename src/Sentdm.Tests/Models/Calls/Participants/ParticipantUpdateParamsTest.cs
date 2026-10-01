using System;
using System.Net.Http;
using Sentdm.Models.Calls.Participants;

namespace Sentdm.Tests.Models.Calls.Participants;

public class ParticipantUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ParticipantUpdateParams
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
            ParticipantID = "call_9f2ab000-0000-4000-8000-000000000002",
            Muted = true,
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "call_9f2ab000-0000-4000-8000-000000000001";
        string expectedParticipantID = "call_9f2ab000-0000-4000-8000-000000000002";
        bool expectedMuted = true;
        bool expectedSandbox = false;
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedParticipantID, parameters.ParticipantID);
        Assert.Equal(expectedMuted, parameters.Muted);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ParticipantUpdateParams
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
            ParticipantID = "call_9f2ab000-0000-4000-8000-000000000002",
        };

        Assert.Null(parameters.Muted);
        Assert.False(parameters.RawBodyData.ContainsKey("muted"));
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
        var parameters = new ParticipantUpdateParams
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
            ParticipantID = "call_9f2ab000-0000-4000-8000-000000000002",

            // Null should be interpreted as omitted for these properties
            Muted = null,
            Sandbox = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.Muted);
        Assert.False(parameters.RawBodyData.ContainsKey("muted"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void Url_Works()
    {
        ParticipantUpdateParams parameters = new()
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
            ParticipantID = "call_9f2ab000-0000-4000-8000-000000000002",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/calls/call_9f2ab000-0000-4000-8000-000000000001/participants/call_9f2ab000-0000-4000-8000-000000000002"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ParticipantUpdateParams parameters = new()
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
            ParticipantID = "call_9f2ab000-0000-4000-8000-000000000002",
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
        var parameters = new ParticipantUpdateParams
        {
            ID = "call_9f2ab000-0000-4000-8000-000000000001",
            ParticipantID = "call_9f2ab000-0000-4000-8000-000000000002",
            Muted = true,
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ParticipantUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
