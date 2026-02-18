using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class MutationRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MutationRequest { TestMode = false };

        bool expectedTestMode = false;

        Assert.Equal(expectedTestMode, model.TestMode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MutationRequest { TestMode = false };

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
        var model = new MutationRequest { TestMode = false };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MutationRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedTestMode = false;

        Assert.Equal(expectedTestMode, deserialized.TestMode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MutationRequest { TestMode = false };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MutationRequest { };

        Assert.Null(model.TestMode);
        Assert.False(model.RawData.ContainsKey("test_mode"));
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
            TestMode = null,
        };

        Assert.Null(model.TestMode);
        Assert.False(model.RawData.ContainsKey("test_mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MutationRequest
        {
            // Null should be interpreted as omitted for these properties
            TestMode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MutationRequest { TestMode = false };

        MutationRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
