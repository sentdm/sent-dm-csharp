using System;
using System.Net.Http;
using SentDm.Models.Contacts;

namespace SentDm.Tests.Models.Contacts;

public class ContactUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactUpdateParams
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            DefaultChannel = "whatsapp",
            OptOut = false,
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        string expectedID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8";
        string expectedDefaultChannel = "whatsapp";
        bool expectedOptOut = false;
        bool expectedTestMode = false;
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDefaultChannel, parameters.DefaultChannel);
        Assert.Equal(expectedOptOut, parameters.OptOut);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ContactUpdateParams
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            DefaultChannel = "whatsapp",
            OptOut = false,
        };

        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ContactUpdateParams
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            DefaultChannel = "whatsapp",
            OptOut = false,

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
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ContactUpdateParams
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        Assert.Null(parameters.DefaultChannel);
        Assert.False(parameters.RawBodyData.ContainsKey("default_channel"));
        Assert.Null(parameters.OptOut);
        Assert.False(parameters.RawBodyData.ContainsKey("opt_out"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ContactUpdateParams
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",

            DefaultChannel = null,
            OptOut = null,
        };

        Assert.Null(parameters.DefaultChannel);
        Assert.True(parameters.RawBodyData.ContainsKey("default_channel"));
        Assert.Null(parameters.OptOut);
        Assert.True(parameters.RawBodyData.ContainsKey("opt_out"));
    }

    [Fact]
    public void Url_Works()
    {
        ContactUpdateParams parameters = new() { ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/contacts/6ba7b810-9dad-11d1-80b4-00c04fd430c8"),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ContactUpdateParams parameters = new()
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            IdempotencyKey = "req_abc123_retry1",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactUpdateParams
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            DefaultChannel = "whatsapp",
            OptOut = false,
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        ContactUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
