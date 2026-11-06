using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateMediaItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateMediaItem { MediaType = "mediaType", Url = "url" };

        string expectedMediaType = "mediaType";
        string expectedUrl = "url";

        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateMediaItem { MediaType = "mediaType", Url = "url" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateMediaItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateMediaItem { MediaType = "mediaType", Url = "url" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateMediaItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMediaType = "mediaType";
        string expectedUrl = "url";

        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateMediaItem { MediaType = "mediaType", Url = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateMediaItem { MediaType = "mediaType" };

        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateMediaItem { MediaType = "mediaType" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplateMediaItem
        {
            MediaType = "mediaType",

            // Null should be interpreted as omitted for these properties
            Url = null,
        };

        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateMediaItem
        {
            MediaType = "mediaType",

            // Null should be interpreted as omitted for these properties
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateMediaItem { Url = "url" };

        Assert.Null(model.MediaType);
        Assert.False(model.RawData.ContainsKey("mediaType"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateMediaItem { Url = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateMediaItem
        {
            Url = "url",

            MediaType = null,
        };

        Assert.Null(model.MediaType);
        Assert.True(model.RawData.ContainsKey("mediaType"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateMediaItem
        {
            Url = "url",

            MediaType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateMediaItem { MediaType = "mediaType", Url = "url" };

        TemplateMediaItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
