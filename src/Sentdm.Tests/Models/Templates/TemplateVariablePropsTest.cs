using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateVariablePropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string expectedMediaType = "x";
        string expectedSample = "x";
        string expectedUrl = "x";
        string expectedVariableType = "x";
        string expectedAlt = "alt";
        string expectedRegex = "regex";
        string expectedShortUrl = "shortUrl";

        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.Equal(expectedSample, model.Sample);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedVariableType, model.VariableType);
        Assert.Equal(expectedAlt, model.Alt);
        Assert.Equal(expectedRegex, model.Regex);
        Assert.Equal(expectedShortUrl, model.ShortUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateVariableProps>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateVariableProps>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMediaType = "x";
        string expectedSample = "x";
        string expectedUrl = "x";
        string expectedVariableType = "x";
        string expectedAlt = "alt";
        string expectedRegex = "regex";
        string expectedShortUrl = "shortUrl";

        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.Equal(expectedSample, deserialized.Sample);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedVariableType, deserialized.VariableType);
        Assert.Equal(expectedAlt, deserialized.Alt);
        Assert.Equal(expectedRegex, deserialized.Regex);
        Assert.Equal(expectedShortUrl, deserialized.ShortUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
        };

        Assert.Null(model.Alt);
        Assert.False(model.RawData.ContainsKey("alt"));
        Assert.Null(model.Regex);
        Assert.False(model.RawData.ContainsKey("regex"));
        Assert.Null(model.ShortUrl);
        Assert.False(model.RawData.ContainsKey("shortUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",

            Alt = null,
            Regex = null,
            ShortUrl = null,
        };

        Assert.Null(model.Alt);
        Assert.True(model.RawData.ContainsKey("alt"));
        Assert.Null(model.Regex);
        Assert.True(model.RawData.ContainsKey("regex"));
        Assert.Null(model.ShortUrl);
        Assert.True(model.RawData.ContainsKey("shortUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",

            Alt = null,
            Regex = null,
            ShortUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        TemplateVariableProps copied = new(model);

        Assert.Equal(model, copied);
    }
}
