using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Brands;

namespace SentDm.Tests.Models.Brands;

public class DestinationCountryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DestinationCountry { ID = "id", IsMain = true };

        string expectedID = "id";
        bool expectedIsMain = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedIsMain, model.IsMain);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DestinationCountry { ID = "id", IsMain = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DestinationCountry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DestinationCountry { ID = "id", IsMain = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DestinationCountry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        bool expectedIsMain = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedIsMain, deserialized.IsMain);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DestinationCountry { ID = "id", IsMain = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DestinationCountry { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.IsMain);
        Assert.False(model.RawData.ContainsKey("isMain"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DestinationCountry { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DestinationCountry
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            IsMain = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.IsMain);
        Assert.False(model.RawData.ContainsKey("isMain"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DestinationCountry
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            IsMain = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DestinationCountry { ID = "id", IsMain = true };

        DestinationCountry copied = new(model);

        Assert.Equal(model, copied);
    }
}
