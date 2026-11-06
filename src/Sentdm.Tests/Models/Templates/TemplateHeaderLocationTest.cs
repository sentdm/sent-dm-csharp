using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateHeaderLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateHeaderLocation
        {
            Address = "x",
            Latitude = "x",
            Longitude = "x",
            Name = "x",
        };

        string expectedAddress = "x";
        string expectedLatitude = "x";
        string expectedLongitude = "x";
        string expectedName = "x";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedLatitude, model.Latitude);
        Assert.Equal(expectedLongitude, model.Longitude);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateHeaderLocation
        {
            Address = "x",
            Latitude = "x",
            Longitude = "x",
            Name = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateHeaderLocation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateHeaderLocation
        {
            Address = "x",
            Latitude = "x",
            Longitude = "x",
            Name = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateHeaderLocation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddress = "x";
        string expectedLatitude = "x";
        string expectedLongitude = "x";
        string expectedName = "x";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedLatitude, deserialized.Latitude);
        Assert.Equal(expectedLongitude, deserialized.Longitude);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateHeaderLocation
        {
            Address = "x",
            Latitude = "x",
            Longitude = "x",
            Name = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateHeaderLocation
        {
            Address = "x",
            Latitude = "x",
            Longitude = "x",
            Name = "x",
        };

        TemplateHeaderLocation copied = new(model);

        Assert.Equal(model, copied);
    }
}
