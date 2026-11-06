using System;
using System.Net.Http;
using Sentdm.Models.SenderProfiles;

namespace Sentdm.Tests.Models.SenderProfiles;

public class SenderProfileUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SenderProfileUpdateParams
        {
            ID = "770e8400-e29b-41d4-a716-446655440002",
            Description = null,
            Name = "Example Retail Renamed",
            Notifications = null,
            Sandbox = false,
            ShortName = "EXMPL",
            IdempotencyKey = "req_abc123_retry1",
        };

        string expectedID = "770e8400-e29b-41d4-a716-446655440002";
        string expectedName = "Example Retail Renamed";
        bool expectedSandbox = false;
        string expectedShortName = "EXMPL";
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Null(parameters.Description);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Null(parameters.Notifications);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedShortName, parameters.ShortName);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SenderProfileUpdateParams
        {
            ID = "770e8400-e29b-41d4-a716-446655440002",
            Description = null,
            Notifications = null,
            ShortName = "EXMPL",
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SenderProfileUpdateParams
        {
            ID = "770e8400-e29b-41d4-a716-446655440002",
            Description = null,
            Notifications = null,
            ShortName = "EXMPL",

            // Null should be interpreted as omitted for these properties
            Name = null,
            Sandbox = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SenderProfileUpdateParams
        {
            ID = "770e8400-e29b-41d4-a716-446655440002",
            Name = "Example Retail Renamed",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Notifications);
        Assert.False(parameters.RawBodyData.ContainsKey("notifications"));
        Assert.Null(parameters.ShortName);
        Assert.False(parameters.RawBodyData.ContainsKey("short_name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SenderProfileUpdateParams
        {
            ID = "770e8400-e29b-41d4-a716-446655440002",
            Name = "Example Retail Renamed",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",

            Description = null,
            Notifications = null,
            ShortName = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Notifications);
        Assert.True(parameters.RawBodyData.ContainsKey("notifications"));
        Assert.Null(parameters.ShortName);
        Assert.True(parameters.RawBodyData.ContainsKey("short_name"));
    }

    [Fact]
    public void Url_Works()
    {
        SenderProfileUpdateParams parameters = new()
        {
            ID = "770e8400-e29b-41d4-a716-446655440002",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/sender-profiles/770e8400-e29b-41d4-a716-446655440002"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SenderProfileUpdateParams parameters = new()
        {
            ID = "770e8400-e29b-41d4-a716-446655440002",
            IdempotencyKey = "req_abc123_retry1",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SenderProfileUpdateParams
        {
            ID = "770e8400-e29b-41d4-a716-446655440002",
            Description = null,
            Name = "Example Retail Renamed",
            Notifications = null,
            Sandbox = false,
            ShortName = "EXMPL",
            IdempotencyKey = "req_abc123_retry1",
        };

        SenderProfileUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
