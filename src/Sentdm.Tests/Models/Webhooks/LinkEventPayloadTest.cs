using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class LinkEventPayloadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LinkEventPayload
        {
            RecordID = "record_id",
            AccessCountry = "access_country",
            AccessOutcome = "access_outcome",
            Browser = "browser",
            BytesServed = 0,
            Channel = "channel",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Device = "device",
            LinkKind = "link_kind",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OccurredAt = "occurred_at",
            ReferenceKey = "reference_key",
            ReferrerHost = "referrer_host",
            RequestMethod = "request_method",
            SenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            StatusCode = 0,
            TrafficClass = "traffic_class",
        };

        string expectedRecordID = "record_id";
        string expectedAccessCountry = "access_country";
        string expectedAccessOutcome = "access_outcome";
        string expectedBrowser = "browser";
        long expectedBytesServed = 0;
        string expectedChannel = "channel";
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDevice = "device";
        string expectedLinkKind = "link_kind";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedOccurredAt = "occurred_at";
        string expectedReferenceKey = "reference_key";
        string expectedReferrerHost = "referrer_host";
        string expectedRequestMethod = "request_method";
        string expectedSenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        int expectedStatusCode = 0;
        string expectedTrafficClass = "traffic_class";

        Assert.Equal(expectedRecordID, model.RecordID);
        Assert.Equal(expectedAccessCountry, model.AccessCountry);
        Assert.Equal(expectedAccessOutcome, model.AccessOutcome);
        Assert.Equal(expectedBrowser, model.Browser);
        Assert.Equal(expectedBytesServed, model.BytesServed);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedDevice, model.Device);
        Assert.Equal(expectedLinkKind, model.LinkKind);
        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.Equal(expectedOccurredAt, model.OccurredAt);
        Assert.Equal(expectedReferenceKey, model.ReferenceKey);
        Assert.Equal(expectedReferrerHost, model.ReferrerHost);
        Assert.Equal(expectedRequestMethod, model.RequestMethod);
        Assert.Equal(expectedSenderProfileID, model.SenderProfileID);
        Assert.Equal(expectedStatusCode, model.StatusCode);
        Assert.Equal(expectedTrafficClass, model.TrafficClass);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LinkEventPayload
        {
            RecordID = "record_id",
            AccessCountry = "access_country",
            AccessOutcome = "access_outcome",
            Browser = "browser",
            BytesServed = 0,
            Channel = "channel",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Device = "device",
            LinkKind = "link_kind",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OccurredAt = "occurred_at",
            ReferenceKey = "reference_key",
            ReferrerHost = "referrer_host",
            RequestMethod = "request_method",
            SenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            StatusCode = 0,
            TrafficClass = "traffic_class",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LinkEventPayload>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LinkEventPayload
        {
            RecordID = "record_id",
            AccessCountry = "access_country",
            AccessOutcome = "access_outcome",
            Browser = "browser",
            BytesServed = 0,
            Channel = "channel",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Device = "device",
            LinkKind = "link_kind",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OccurredAt = "occurred_at",
            ReferenceKey = "reference_key",
            ReferrerHost = "referrer_host",
            RequestMethod = "request_method",
            SenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            StatusCode = 0,
            TrafficClass = "traffic_class",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LinkEventPayload>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRecordID = "record_id";
        string expectedAccessCountry = "access_country";
        string expectedAccessOutcome = "access_outcome";
        string expectedBrowser = "browser";
        long expectedBytesServed = 0;
        string expectedChannel = "channel";
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDevice = "device";
        string expectedLinkKind = "link_kind";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedOccurredAt = "occurred_at";
        string expectedReferenceKey = "reference_key";
        string expectedReferrerHost = "referrer_host";
        string expectedRequestMethod = "request_method";
        string expectedSenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        int expectedStatusCode = 0;
        string expectedTrafficClass = "traffic_class";

        Assert.Equal(expectedRecordID, deserialized.RecordID);
        Assert.Equal(expectedAccessCountry, deserialized.AccessCountry);
        Assert.Equal(expectedAccessOutcome, deserialized.AccessOutcome);
        Assert.Equal(expectedBrowser, deserialized.Browser);
        Assert.Equal(expectedBytesServed, deserialized.BytesServed);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedDevice, deserialized.Device);
        Assert.Equal(expectedLinkKind, deserialized.LinkKind);
        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.Equal(expectedOccurredAt, deserialized.OccurredAt);
        Assert.Equal(expectedReferenceKey, deserialized.ReferenceKey);
        Assert.Equal(expectedReferrerHost, deserialized.ReferrerHost);
        Assert.Equal(expectedRequestMethod, deserialized.RequestMethod);
        Assert.Equal(expectedSenderProfileID, deserialized.SenderProfileID);
        Assert.Equal(expectedStatusCode, deserialized.StatusCode);
        Assert.Equal(expectedTrafficClass, deserialized.TrafficClass);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LinkEventPayload
        {
            RecordID = "record_id",
            AccessCountry = "access_country",
            AccessOutcome = "access_outcome",
            Browser = "browser",
            BytesServed = 0,
            Channel = "channel",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Device = "device",
            LinkKind = "link_kind",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OccurredAt = "occurred_at",
            ReferenceKey = "reference_key",
            ReferrerHost = "referrer_host",
            RequestMethod = "request_method",
            SenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            StatusCode = 0,
            TrafficClass = "traffic_class",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LinkEventPayload
        {
            RecordID = "record_id",
            AccessCountry = "access_country",
            AccessOutcome = "access_outcome",
            Browser = "browser",
            BytesServed = 0,
            Channel = "channel",
            Device = "device",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceKey = "reference_key",
            ReferrerHost = "referrer_host",
            RequestMethod = "request_method",
            SenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            StatusCode = 0,
            TrafficClass = "traffic_class",
        };

        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customer_id"));
        Assert.Null(model.LinkKind);
        Assert.False(model.RawData.ContainsKey("link_kind"));
        Assert.Null(model.OccurredAt);
        Assert.False(model.RawData.ContainsKey("occurred_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new LinkEventPayload
        {
            RecordID = "record_id",
            AccessCountry = "access_country",
            AccessOutcome = "access_outcome",
            Browser = "browser",
            BytesServed = 0,
            Channel = "channel",
            Device = "device",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceKey = "reference_key",
            ReferrerHost = "referrer_host",
            RequestMethod = "request_method",
            SenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            StatusCode = 0,
            TrafficClass = "traffic_class",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new LinkEventPayload
        {
            RecordID = "record_id",
            AccessCountry = "access_country",
            AccessOutcome = "access_outcome",
            Browser = "browser",
            BytesServed = 0,
            Channel = "channel",
            Device = "device",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceKey = "reference_key",
            ReferrerHost = "referrer_host",
            RequestMethod = "request_method",
            SenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            StatusCode = 0,
            TrafficClass = "traffic_class",

            // Null should be interpreted as omitted for these properties
            CustomerID = null,
            LinkKind = null,
            OccurredAt = null,
        };

        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customer_id"));
        Assert.Null(model.LinkKind);
        Assert.False(model.RawData.ContainsKey("link_kind"));
        Assert.Null(model.OccurredAt);
        Assert.False(model.RawData.ContainsKey("occurred_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LinkEventPayload
        {
            RecordID = "record_id",
            AccessCountry = "access_country",
            AccessOutcome = "access_outcome",
            Browser = "browser",
            BytesServed = 0,
            Channel = "channel",
            Device = "device",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceKey = "reference_key",
            ReferrerHost = "referrer_host",
            RequestMethod = "request_method",
            SenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            StatusCode = 0,
            TrafficClass = "traffic_class",

            // Null should be interpreted as omitted for these properties
            CustomerID = null,
            LinkKind = null,
            OccurredAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LinkEventPayload
        {
            RecordID = "record_id",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LinkKind = "link_kind",
            OccurredAt = "occurred_at",
        };

        Assert.Null(model.AccessCountry);
        Assert.False(model.RawData.ContainsKey("access_country"));
        Assert.Null(model.AccessOutcome);
        Assert.False(model.RawData.ContainsKey("access_outcome"));
        Assert.Null(model.Browser);
        Assert.False(model.RawData.ContainsKey("browser"));
        Assert.Null(model.BytesServed);
        Assert.False(model.RawData.ContainsKey("bytes_served"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Device);
        Assert.False(model.RawData.ContainsKey("device"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.ReferenceKey);
        Assert.False(model.RawData.ContainsKey("reference_key"));
        Assert.Null(model.ReferrerHost);
        Assert.False(model.RawData.ContainsKey("referrer_host"));
        Assert.Null(model.RequestMethod);
        Assert.False(model.RawData.ContainsKey("request_method"));
        Assert.Null(model.SenderProfileID);
        Assert.False(model.RawData.ContainsKey("sender_profile_id"));
        Assert.Null(model.StatusCode);
        Assert.False(model.RawData.ContainsKey("status_code"));
        Assert.Null(model.TrafficClass);
        Assert.False(model.RawData.ContainsKey("traffic_class"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LinkEventPayload
        {
            RecordID = "record_id",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LinkKind = "link_kind",
            OccurredAt = "occurred_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LinkEventPayload
        {
            RecordID = "record_id",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LinkKind = "link_kind",
            OccurredAt = "occurred_at",

            AccessCountry = null,
            AccessOutcome = null,
            Browser = null,
            BytesServed = null,
            Channel = null,
            Device = null,
            MessageID = null,
            ReferenceKey = null,
            ReferrerHost = null,
            RequestMethod = null,
            SenderProfileID = null,
            StatusCode = null,
            TrafficClass = null,
        };

        Assert.Null(model.AccessCountry);
        Assert.True(model.RawData.ContainsKey("access_country"));
        Assert.Null(model.AccessOutcome);
        Assert.True(model.RawData.ContainsKey("access_outcome"));
        Assert.Null(model.Browser);
        Assert.True(model.RawData.ContainsKey("browser"));
        Assert.Null(model.BytesServed);
        Assert.True(model.RawData.ContainsKey("bytes_served"));
        Assert.Null(model.Channel);
        Assert.True(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Device);
        Assert.True(model.RawData.ContainsKey("device"));
        Assert.Null(model.MessageID);
        Assert.True(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.ReferenceKey);
        Assert.True(model.RawData.ContainsKey("reference_key"));
        Assert.Null(model.ReferrerHost);
        Assert.True(model.RawData.ContainsKey("referrer_host"));
        Assert.Null(model.RequestMethod);
        Assert.True(model.RawData.ContainsKey("request_method"));
        Assert.Null(model.SenderProfileID);
        Assert.True(model.RawData.ContainsKey("sender_profile_id"));
        Assert.Null(model.StatusCode);
        Assert.True(model.RawData.ContainsKey("status_code"));
        Assert.Null(model.TrafficClass);
        Assert.True(model.RawData.ContainsKey("traffic_class"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LinkEventPayload
        {
            RecordID = "record_id",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LinkKind = "link_kind",
            OccurredAt = "occurred_at",

            AccessCountry = null,
            AccessOutcome = null,
            Browser = null,
            BytesServed = null,
            Channel = null,
            Device = null,
            MessageID = null,
            ReferenceKey = null,
            ReferrerHost = null,
            RequestMethod = null,
            SenderProfileID = null,
            StatusCode = null,
            TrafficClass = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LinkEventPayload
        {
            RecordID = "record_id",
            AccessCountry = "access_country",
            AccessOutcome = "access_outcome",
            Browser = "browser",
            BytesServed = 0,
            Channel = "channel",
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Device = "device",
            LinkKind = "link_kind",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OccurredAt = "occurred_at",
            ReferenceKey = "reference_key",
            ReferrerHost = "referrer_host",
            RequestMethod = "request_method",
            SenderProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            StatusCode = 0,
            TrafficClass = "traffic_class",
        };

        LinkEventPayload copied = new(model);

        Assert.Equal(model, copied);
    }
}
