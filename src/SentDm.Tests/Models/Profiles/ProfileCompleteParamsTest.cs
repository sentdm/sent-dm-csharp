using System;
using System.Net.Http;
using SentDm.Models.Profiles;

namespace SentDm.Tests.Models.Profiles;

public class ProfileCompleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileCompleteParams
        {
            ProfileID = "660e8400-e29b-41d4-a716-446655440000",
            WebHookUrl = "https://your-app.com/webhook/profile-complete",
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        string expectedProfileID = "660e8400-e29b-41d4-a716-446655440000";
        string expectedWebHookUrl = "https://your-app.com/webhook/profile-complete";
        bool expectedTestMode = false;
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedProfileID, parameters.ProfileID);
        Assert.Equal(expectedWebHookUrl, parameters.WebHookUrl);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProfileCompleteParams
        {
            ProfileID = "660e8400-e29b-41d4-a716-446655440000",
            WebHookUrl = "https://your-app.com/webhook/profile-complete",
        };

        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProfileCompleteParams
        {
            ProfileID = "660e8400-e29b-41d4-a716-446655440000",
            WebHookUrl = "https://your-app.com/webhook/profile-complete",

            // Null should be interpreted as omitted for these properties
            TestMode = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
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

        Assert.Equal(
            new Uri(
                "https://api.sent.dm/v3/profiles/660e8400-e29b-41d4-a716-446655440000/complete"
            ),
            url
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
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProfileCompleteParams
        {
            ProfileID = "660e8400-e29b-41d4-a716-446655440000",
            WebHookUrl = "https://your-app.com/webhook/profile-complete",
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        ProfileCompleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
