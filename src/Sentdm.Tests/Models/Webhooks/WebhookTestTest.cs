using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookTestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookTest { Message = "message", Success = true };

        string expectedMessage = "message";
        bool expectedSuccess = true;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookTest { Message = "message", Success = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookTest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookTest { Message = "message", Success = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookTest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        bool expectedSuccess = true;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookTest { Message = "message", Success = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookTest { };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookTest { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookTest
        {
            // Null should be interpreted as omitted for these properties
            Message = null,
            Success = null,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookTest
        {
            // Null should be interpreted as omitted for these properties
            Message = null,
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookTest { Message = "message", Success = true };

        WebhookTest copied = new(model);

        Assert.Equal(model, copied);
    }
}
