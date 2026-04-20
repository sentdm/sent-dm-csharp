using System;
using System.Net.Http;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class ProfileCompleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileCompleteParams
        {
            ProfileID = "660e8400-e29b-41d4-a716-446655440000",
            WebHookUrl = "https://your-app.com/webhook/profile-complete",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedProfileID = "660e8400-e29b-41d4-a716-446655440000";
        string expectedWebHookUrl = "https://your-app.com/webhook/profile-complete";
        bool expectedSandbox = false;
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedProfileID, parameters.ProfileID);
        Assert.Equal(expectedWebHookUrl, parameters.WebHookUrl);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProfileCompleteParams
        {
            ProfileID = "660e8400-e29b-41d4-a716-446655440000",
            WebHookUrl = "https://your-app.com/webhook/profile-complete",
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
        var parameters = new ProfileCompleteParams
        {
            ProfileID = "660e8400-e29b-41d4-a716-446655440000",
            WebHookUrl = "https://your-app.com/webhook/profile-complete",

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
    public void Url_Works()
    {
        ProfileCompleteParams parameters = new()
        {
            ProfileID = "660e8400-e29b-41d4-a716-446655440000",
            WebHookUrl = "https://your-app.com/webhook/profile-complete",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/profiles/660e8400-e29b-41d4-a716-446655440000/complete"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ProfileCompleteParams parameters = new()
        {
            ProfileID = "660e8400-e29b-41d4-a716-446655440000",
            WebHookUrl = "https://your-app.com/webhook/profile-complete",
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
        var parameters = new ProfileCompleteParams
        {
            ProfileID = "660e8400-e29b-41d4-a716-446655440000",
            WebHookUrl = "https://your-app.com/webhook/profile-complete",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ProfileCompleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
