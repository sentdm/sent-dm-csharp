using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class MutationRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MutationRequest { Sandbox = false };

        bool expectedSandbox = false;

        Assert.Equal(expectedSandbox, model.Sandbox);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MutationRequest { Sandbox = false };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MutationRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MutationRequest { Sandbox = false };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MutationRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedSandbox = false;

        Assert.Equal(expectedSandbox, deserialized.Sandbox);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MutationRequest { Sandbox = false };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MutationRequest { };

        Assert.Null(model.Sandbox);
        Assert.False(model.RawData.ContainsKey("sandbox"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MutationRequest { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MutationRequest
        {
            // Null should be interpreted as omitted for these properties
            Sandbox = null,
        };

        Assert.Null(model.Sandbox);
        Assert.False(model.RawData.ContainsKey("sandbox"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MutationRequest
        {
            // Null should be interpreted as omitted for these properties
            Sandbox = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MutationRequest { Sandbox = false };

        MutationRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
