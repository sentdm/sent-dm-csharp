using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class InboundMessageEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundMessageEvent
        {
            Event = "event",
            Field = "field",
            Payload = new()
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
                Text = "text",
                UpdatedAt = "updated_at",
            },
            RequestID = "request_id",
            Timestamp = "timestamp",
        };

        string expectedEvent = "event";
        string expectedField = "field";
        InboundMessageEventPayload expectedPayload = new()
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
            Text = "text",
            UpdatedAt = "updated_at",
        };
        string expectedRequestID = "request_id";
        string expectedTimestamp = "timestamp";

        Assert.Equal(expectedEvent, model.Event);
        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedPayload, model.Payload);
        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundMessageEvent
        {
            Event = "event",
            Field = "field",
            Payload = new()
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
                Text = "text",
                UpdatedAt = "updated_at",
            },
            RequestID = "request_id",
            Timestamp = "timestamp",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundMessageEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundMessageEvent
        {
            Event = "event",
            Field = "field",
            Payload = new()
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
                Text = "text",
                UpdatedAt = "updated_at",
            },
            RequestID = "request_id",
            Timestamp = "timestamp",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundMessageEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEvent = "event";
        string expectedField = "field";
        InboundMessageEventPayload expectedPayload = new()
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
            Text = "text",
            UpdatedAt = "updated_at",
        };
        string expectedRequestID = "request_id";
        string expectedTimestamp = "timestamp";

        Assert.Equal(expectedEvent, deserialized.Event);
        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedPayload, deserialized.Payload);
        Assert.Equal(expectedRequestID, deserialized.RequestID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundMessageEvent
        {
            Event = "event",
            Field = "field",
            Payload = new()
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
                Text = "text",
                UpdatedAt = "updated_at",
            },
            RequestID = "request_id",
            Timestamp = "timestamp",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InboundMessageEvent
        {
            Event = "event",
            Payload = new()
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
                Text = "text",
                UpdatedAt = "updated_at",
            },
            RequestID = "request_id",
        };

        Assert.Null(model.Field);
        Assert.False(model.RawData.ContainsKey("field"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InboundMessageEvent
        {
            Event = "event",
            Payload = new()
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
                Text = "text",
                UpdatedAt = "updated_at",
            },
            RequestID = "request_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InboundMessageEvent
        {
            Event = "event",
            Payload = new()
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
                Text = "text",
                UpdatedAt = "updated_at",
            },
            RequestID = "request_id",

            // Null should be interpreted as omitted for these properties
            Field = null,
            Timestamp = null,
        };

        Assert.Null(model.Field);
        Assert.False(model.RawData.ContainsKey("field"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InboundMessageEvent
        {
            Event = "event",
            Payload = new()
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
                Text = "text",
                UpdatedAt = "updated_at",
            },
            RequestID = "request_id",

            // Null should be interpreted as omitted for these properties
            Field = null,
            Timestamp = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InboundMessageEvent { Field = "field", Timestamp = "timestamp" };

        Assert.Null(model.Event);
        Assert.False(model.RawData.ContainsKey("event"));
        Assert.Null(model.Payload);
        Assert.False(model.RawData.ContainsKey("payload"));
        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InboundMessageEvent { Field = "field", Timestamp = "timestamp" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InboundMessageEvent
        {
            Field = "field",
            Timestamp = "timestamp",

            Event = null,
            Payload = null,
            RequestID = null,
        };

        Assert.Null(model.Event);
        Assert.True(model.RawData.ContainsKey("event"));
        Assert.Null(model.Payload);
        Assert.True(model.RawData.ContainsKey("payload"));
        Assert.Null(model.RequestID);
        Assert.True(model.RawData.ContainsKey("request_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InboundMessageEvent
        {
            Field = "field",
            Timestamp = "timestamp",

            Event = null,
            Payload = null,
            RequestID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundMessageEvent
        {
            Event = "event",
            Field = "field",
            Payload = new()
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
                Text = "text",
                UpdatedAt = "updated_at",
            },
            RequestID = "request_id",
            Timestamp = "timestamp",
        };

        InboundMessageEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
