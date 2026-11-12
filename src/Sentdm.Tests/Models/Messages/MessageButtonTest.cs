using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Messages;

namespace Sentdm.Tests.Models.Messages;

public class MessageButtonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageButton
        {
            PostbackData = "postbackData",
            Text = "text",
            Type = "type",
            Value = "value",
        };

        string expectedPostbackData = "postbackData";
        string expectedText = "text";
        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedPostbackData, model.PostbackData);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageButton
        {
            PostbackData = "postbackData",
            Text = "text",
            Type = "type",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageButton>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageButton
        {
            PostbackData = "postbackData",
            Text = "text",
            Type = "type",
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageButton>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPostbackData = "postbackData";
        string expectedText = "text";
        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedPostbackData, deserialized.PostbackData);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageButton
        {
            PostbackData = "postbackData",
            Text = "text",
            Type = "type",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageButton { PostbackData = "postbackData", Text = "text" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageButton { PostbackData = "postbackData", Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageButton
        {
            PostbackData = "postbackData",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Type = null,
            Value = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageButton
        {
            PostbackData = "postbackData",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Type = null,
            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageButton { Type = "type", Value = "value" };

        Assert.Null(model.PostbackData);
        Assert.False(model.RawData.ContainsKey("postbackData"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageButton { Type = "type", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MessageButton
        {
            Type = "type",
            Value = "value",

            PostbackData = null,
            Text = null,
        };

        Assert.Null(model.PostbackData);
        Assert.True(model.RawData.ContainsKey("postbackData"));
        Assert.Null(model.Text);
        Assert.True(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageButton
        {
            Type = "type",
            Value = "value",

            PostbackData = null,
            Text = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageButton
        {
            PostbackData = "postbackData",
            Text = "text",
            Type = "type",
            Value = "value",
        };

        MessageButton copied = new(model);

        Assert.Equal(model, copied);
    }
}
