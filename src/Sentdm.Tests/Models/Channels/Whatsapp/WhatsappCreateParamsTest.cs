using System;
using System.Net.Http;
using Sentdm.Models.Channels.Whatsapp;

namespace Sentdm.Tests.Models.Channels.Whatsapp;

public class WhatsappCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WhatsappCreateParams
        {
            PhoneNumberID = "106540352242922",
            Sandbox = false,
            WabaID = "102290129340398",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedPhoneNumberID = "106540352242922";
        bool expectedSandbox = false;
        string expectedWabaID = "102290129340398";
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedPhoneNumberID, parameters.PhoneNumberID);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedWabaID, parameters.WabaID);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WhatsappCreateParams { PhoneNumberID = "106540352242922" };

        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.WabaID);
        Assert.False(parameters.RawBodyData.ContainsKey("waba_id"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WhatsappCreateParams
        {
            PhoneNumberID = "106540352242922",

            // Null should be interpreted as omitted for these properties
            Sandbox = null,
            WabaID = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.WabaID);
        Assert.False(parameters.RawBodyData.ContainsKey("waba_id"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WhatsappCreateParams
        {
            Sandbox = false,
            WabaID = "102290129340398",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.PhoneNumberID);
        Assert.False(parameters.RawBodyData.ContainsKey("phone_number_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WhatsappCreateParams
        {
            Sandbox = false,
            WabaID = "102290129340398",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            PhoneNumberID = null,
        };

        Assert.Null(parameters.PhoneNumberID);
        Assert.True(parameters.RawBodyData.ContainsKey("phone_number_id"));
    }

    [Fact]
    public void Url_Works()
    {
        WhatsappCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.sent.dm/v3/channels/whatsapp"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WhatsappCreateParams parameters = new()
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
        var parameters = new WhatsappCreateParams
        {
            PhoneNumberID = "106540352242922",
            Sandbox = false,
            WabaID = "102290129340398",
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        WhatsappCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
