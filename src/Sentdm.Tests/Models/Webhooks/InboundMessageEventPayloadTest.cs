using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class InboundMessageEventPayloadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundMessageEventPayload
        {
            InboundNumber = "inbound_number",
            ReceivedAt = "received_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Media =
            [
                new()
                {
                    HashSha256 = "hash_sha256",
                    MimeType = "mime_type",
                    SizeBytes = 0,
                    Url = "url",
                },
            ],
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            Referral = JsonSerializer.Deserialize<JsonElement>("{}"),
            Text = "text",
            UpdatedAt = "updated_at",
        };

        string expectedInboundNumber = "inbound_number";
        string expectedReceivedAt = "received_at";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        List<InboundMedia> expectedMedia =
        [
            new()
            {
                HashSha256 = "hash_sha256",
                MimeType = "mime_type",
                SizeBytes = 0,
                Url = "url",
            },
        ];
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedOutboundNumber = "outbound_number";
        JsonElement expectedReferral = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedText = "text";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedInboundNumber, model.InboundNumber);
        Assert.Equal(expectedReceivedAt, model.ReceivedAt);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.NotNull(model.Media);
        Assert.Equal(expectedMedia.Count, model.Media.Count);
        for (int i = 0; i < expectedMedia.Count; i++)
        {
            Assert.Equal(expectedMedia[i], model.Media[i]);
        }
        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.Equal(expectedOutboundNumber, model.OutboundNumber);
        Assert.NotNull(model.Referral);
        Assert.True(JsonElement.DeepEquals(expectedReferral, model.Referral.Value));
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundMessageEventPayload
        {
            InboundNumber = "inbound_number",
            ReceivedAt = "received_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Media =
            [
                new()
                {
                    HashSha256 = "hash_sha256",
                    MimeType = "mime_type",
                    SizeBytes = 0,
                    Url = "url",
                },
            ],
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            Referral = JsonSerializer.Deserialize<JsonElement>("{}"),
            Text = "text",
            UpdatedAt = "updated_at",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundMessageEventPayload>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundMessageEventPayload
        {
            InboundNumber = "inbound_number",
            ReceivedAt = "received_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Media =
            [
                new()
                {
                    HashSha256 = "hash_sha256",
                    MimeType = "mime_type",
                    SizeBytes = 0,
                    Url = "url",
                },
            ],
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            Referral = JsonSerializer.Deserialize<JsonElement>("{}"),
            Text = "text",
            UpdatedAt = "updated_at",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundMessageEventPayload>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInboundNumber = "inbound_number";
        string expectedReceivedAt = "received_at";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        List<InboundMedia> expectedMedia =
        [
            new()
            {
                HashSha256 = "hash_sha256",
                MimeType = "mime_type",
                SizeBytes = 0,
                Url = "url",
            },
        ];
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedOutboundNumber = "outbound_number";
        JsonElement expectedReferral = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedText = "text";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedInboundNumber, deserialized.InboundNumber);
        Assert.Equal(expectedReceivedAt, deserialized.ReceivedAt);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.NotNull(deserialized.Media);
        Assert.Equal(expectedMedia.Count, deserialized.Media.Count);
        for (int i = 0; i < expectedMedia.Count; i++)
        {
            Assert.Equal(expectedMedia[i], deserialized.Media[i]);
        }
        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.Equal(expectedOutboundNumber, deserialized.OutboundNumber);
        Assert.NotNull(deserialized.Referral);
        Assert.True(JsonElement.DeepEquals(expectedReferral, deserialized.Referral.Value));
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundMessageEventPayload
        {
            InboundNumber = "inbound_number",
            ReceivedAt = "received_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Media =
            [
                new()
                {
                    HashSha256 = "hash_sha256",
                    MimeType = "mime_type",
                    SizeBytes = 0,
                    Url = "url",
                },
            ],
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            Referral = JsonSerializer.Deserialize<JsonElement>("{}"),
            Text = "text",
            UpdatedAt = "updated_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InboundMessageEventPayload
        {
            InboundNumber = "inbound_number",
            ReceivedAt = "received_at",
            Media =
            [
                new()
                {
                    HashSha256 = "hash_sha256",
                    MimeType = "mime_type",
                    SizeBytes = 0,
                    Url = "url",
                },
            ],
            Referral = JsonSerializer.Deserialize<JsonElement>("{}"),
            Text = "text",
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.OutboundNumber);
        Assert.False(model.RawData.ContainsKey("outbound_number"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InboundMessageEventPayload
        {
            InboundNumber = "inbound_number",
            ReceivedAt = "received_at",
            Media =
            [
                new()
                {
                    HashSha256 = "hash_sha256",
                    MimeType = "mime_type",
                    SizeBytes = 0,
                    Url = "url",
                },
            ],
            Referral = JsonSerializer.Deserialize<JsonElement>("{}"),
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InboundMessageEventPayload
        {
            InboundNumber = "inbound_number",
            ReceivedAt = "received_at",
            Media =
            [
                new()
                {
                    HashSha256 = "hash_sha256",
                    MimeType = "mime_type",
                    SizeBytes = 0,
                    Url = "url",
                },
            ],
            Referral = JsonSerializer.Deserialize<JsonElement>("{}"),
            Text = "text",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Channel = null,
            MessageID = null,
            OutboundNumber = null,
            UpdatedAt = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.OutboundNumber);
        Assert.False(model.RawData.ContainsKey("outbound_number"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InboundMessageEventPayload
        {
            InboundNumber = "inbound_number",
            ReceivedAt = "received_at",
            Media =
            [
                new()
                {
                    HashSha256 = "hash_sha256",
                    MimeType = "mime_type",
                    SizeBytes = 0,
                    Url = "url",
                },
            ],
            Referral = JsonSerializer.Deserialize<JsonElement>("{}"),
            Text = "text",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Channel = null,
            MessageID = null,
            OutboundNumber = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InboundMessageEventPayload
        {
            InboundNumber = "inbound_number",
            ReceivedAt = "received_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            UpdatedAt = "updated_at",
        };

        Assert.Null(model.Media);
        Assert.False(model.RawData.ContainsKey("media"));
        Assert.Null(model.Referral);
        Assert.False(model.RawData.ContainsKey("referral"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InboundMessageEventPayload
        {
            InboundNumber = "inbound_number",
            ReceivedAt = "received_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            UpdatedAt = "updated_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InboundMessageEventPayload
        {
            InboundNumber = "inbound_number",
            ReceivedAt = "received_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            UpdatedAt = "updated_at",

            Media = null,
            Referral = null,
            Text = null,
        };

        Assert.Null(model.Media);
        Assert.True(model.RawData.ContainsKey("media"));
        Assert.Null(model.Referral);
        Assert.True(model.RawData.ContainsKey("referral"));
        Assert.Null(model.Text);
        Assert.True(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InboundMessageEventPayload
        {
            InboundNumber = "inbound_number",
            ReceivedAt = "received_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            UpdatedAt = "updated_at",

            Media = null,
            Referral = null,
            Text = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundMessageEventPayload
        {
            InboundNumber = "inbound_number",
            ReceivedAt = "received_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Media =
            [
                new()
                {
                    HashSha256 = "hash_sha256",
                    MimeType = "mime_type",
                    SizeBytes = 0,
                    Url = "url",
                },
            ],
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            Referral = JsonSerializer.Deserialize<JsonElement>("{}"),
            Text = "text",
            UpdatedAt = "updated_at",
        };

        InboundMessageEventPayload copied = new(model);

        Assert.Equal(model, copied);
    }
}
