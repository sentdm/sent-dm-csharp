using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Messages;

namespace Sentdm.Tests.Models.Messages;

public class MessageRecipientTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageRecipient
        {
            Body = "body",
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",
        };

        string expectedBody = "body";
        string expectedChannel = "channel";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTo = "to";

        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.Equal(expectedTo, model.To);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageRecipient
        {
            Body = "body",
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageRecipient>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageRecipient
        {
            Body = "body",
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageRecipient>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBody = "body";
        string expectedChannel = "channel";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTo = "to";

        Assert.Equal(expectedBody, deserialized.Body);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.Equal(expectedTo, deserialized.To);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageRecipient
        {
            Body = "body",
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageRecipient { Body = "body", Channel = "channel" };

        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageRecipient { Body = "body", Channel = "channel" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageRecipient
        {
            Body = "body",
            Channel = "channel",

            // Null should be interpreted as omitted for these properties
            MessageID = null,
            To = null,
        };

        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageRecipient
        {
            Body = "body",
            Channel = "channel",

            // Null should be interpreted as omitted for these properties
            MessageID = null,
            To = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageRecipient
        {
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",
        };

        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageRecipient
        {
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MessageRecipient
        {
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",

            Body = null,
            Channel = null,
        };

        Assert.Null(model.Body);
        Assert.True(model.RawData.ContainsKey("body"));
        Assert.Null(model.Channel);
        Assert.True(model.RawData.ContainsKey("channel"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageRecipient
        {
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",

            Body = null,
            Channel = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageRecipient
        {
            Body = "body",
            Channel = "channel",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            To = "to",
        };

        MessageRecipient copied = new(model);

        Assert.Equal(model, copied);
    }
}
