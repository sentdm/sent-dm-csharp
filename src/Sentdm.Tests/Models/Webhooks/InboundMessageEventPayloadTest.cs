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
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            InboundNumber = "inbound_number",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            ReceivedAt = "received_at",
            Text = "text",
            UpdatedAt = "updated_at",
        };

        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        string expectedInboundNumber = "inbound_number";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedOutboundNumber = "outbound_number";
        string expectedReceivedAt = "received_at";
        string expectedText = "text";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedInboundNumber, model.InboundNumber);
        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.Equal(expectedOutboundNumber, model.OutboundNumber);
        Assert.Equal(expectedReceivedAt, model.ReceivedAt);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundMessageEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            InboundNumber = "inbound_number",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            ReceivedAt = "received_at",
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
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            InboundNumber = "inbound_number",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            ReceivedAt = "received_at",
            Text = "text",
            UpdatedAt = "updated_at",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundMessageEventPayload>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        string expectedInboundNumber = "inbound_number";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedOutboundNumber = "outbound_number";
        string expectedReceivedAt = "received_at";
        string expectedText = "text";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedInboundNumber, deserialized.InboundNumber);
        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.Equal(expectedOutboundNumber, deserialized.OutboundNumber);
        Assert.Equal(expectedReceivedAt, deserialized.ReceivedAt);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundMessageEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            InboundNumber = "inbound_number",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            ReceivedAt = "received_at",
            Text = "text",
            UpdatedAt = "updated_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InboundMessageEventPayload { Text = "text" };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.InboundNumber);
        Assert.False(model.RawData.ContainsKey("inbound_number"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.OutboundNumber);
        Assert.False(model.RawData.ContainsKey("outbound_number"));
        Assert.Null(model.ReceivedAt);
        Assert.False(model.RawData.ContainsKey("received_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InboundMessageEventPayload { Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InboundMessageEventPayload
        {
            Text = "text",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Channel = null,
            InboundNumber = null,
            MessageID = null,
            OutboundNumber = null,
            ReceivedAt = null,
            UpdatedAt = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.InboundNumber);
        Assert.False(model.RawData.ContainsKey("inbound_number"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.OutboundNumber);
        Assert.False(model.RawData.ContainsKey("outbound_number"));
        Assert.Null(model.ReceivedAt);
        Assert.False(model.RawData.ContainsKey("received_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InboundMessageEventPayload
        {
            Text = "text",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Channel = null,
            InboundNumber = null,
            MessageID = null,
            OutboundNumber = null,
            ReceivedAt = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InboundMessageEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            InboundNumber = "inbound_number",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            ReceivedAt = "received_at",
            UpdatedAt = "updated_at",
        };

        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InboundMessageEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            InboundNumber = "inbound_number",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            ReceivedAt = "received_at",
            UpdatedAt = "updated_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InboundMessageEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            InboundNumber = "inbound_number",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            ReceivedAt = "received_at",
            UpdatedAt = "updated_at",

            Text = null,
        };

        Assert.Null(model.Text);
        Assert.True(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InboundMessageEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            InboundNumber = "inbound_number",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            ReceivedAt = "received_at",
            UpdatedAt = "updated_at",

            Text = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundMessageEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            InboundNumber = "inbound_number",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OutboundNumber = "outbound_number",
            ReceivedAt = "received_at",
            Text = "text",
            UpdatedAt = "updated_at",
        };

        InboundMessageEventPayload copied = new(model);

        Assert.Equal(model, copied);
    }
}
