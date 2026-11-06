using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.SenderProfiles;

namespace Sentdm.Tests.Models.SenderProfiles;

public class SenderProfileBillingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SenderProfileBilling { Inherit = true };

        bool expectedInherit = true;

        Assert.Equal(expectedInherit, model.Inherit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SenderProfileBilling { Inherit = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfileBilling>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SenderProfileBilling { Inherit = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfileBilling>(
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
        var model = new SenderProfileBilling { Inherit = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SenderProfileBilling { };

        Assert.Null(model.Inherit);
        Assert.False(model.RawData.ContainsKey("inherit"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SenderProfileBilling { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SenderProfileBilling
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
        var model = new SenderProfileBilling
        {
            // Null should be interpreted as omitted for these properties
            Inherit = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SenderProfileBilling { Inherit = true };

        SenderProfileBilling copied = new(model);

        Assert.Equal(model, copied);
    }
}
