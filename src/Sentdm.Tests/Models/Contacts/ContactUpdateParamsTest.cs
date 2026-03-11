using System;
using System.Net.Http;
using Sentdm.Models.Contacts;

namespace Sentdm.Tests.Models.Contacts;

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
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8";
        string expectedDefaultChannel = "whatsapp";
        bool expectedOptOut = false;
        bool expectedSandbox = false;
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDefaultChannel, parameters.DefaultChannel);
        Assert.Equal(expectedOptOut, parameters.OptOut);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
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
        var parameters = new ContactUpdateParams
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            DefaultChannel = "whatsapp",
            OptOut = false,

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
        var parameters = new ContactUpdateParams
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

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
        var parameters = new ContactUpdateParams
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            DefaultChannel = "whatsapp",
            OptOut = false,
            Sandbox = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ContactUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
