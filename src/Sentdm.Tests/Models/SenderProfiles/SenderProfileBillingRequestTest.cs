using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.SenderProfiles;

namespace Sentdm.Tests.Models.SenderProfiles;

public class SenderProfileBillingRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SenderProfileBillingRequest { Inherit = true };

        bool expectedInherit = true;

        Assert.Equal(expectedInherit, model.Inherit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SenderProfileBillingRequest { Inherit = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfileBillingRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SenderProfileBillingRequest { Inherit = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfileBillingRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedInherit = true;

        Assert.Equal(expectedInherit, deserialized.Inherit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SenderProfileBillingRequest { Inherit = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SenderProfileBillingRequest { };

        Assert.Null(model.Inherit);
        Assert.False(model.RawData.ContainsKey("inherit"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SenderProfileBillingRequest { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SenderProfileBillingRequest
        {
            // Null should be interpreted as omitted for these properties
            Inherit = null,
        };

        Assert.Null(model.Inherit);
        Assert.False(model.RawData.ContainsKey("inherit"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SenderProfileBillingRequest
        {
            // Null should be interpreted as omitted for these properties
            Inherit = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SenderProfileBillingRequest { Inherit = true };

        SenderProfileBillingRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
