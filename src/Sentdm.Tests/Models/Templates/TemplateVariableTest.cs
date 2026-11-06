using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateVariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateVariable
        {
            Name = "x",
            Props = new()
            {
                MediaType = "x",
                Sample = "x",
                Url = "x",
                VariableType = "x",
                Alt = "alt",
                Regex = "regex",
                ShortUrl = "shortUrl",
            },
            Type = "x",
            ID = 0,
        };

        string expectedName = "x";
        TemplateVariableProps expectedProps = new()
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProps, model.Props);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateVariable
        {
            Name = "x",
            Props = new()
            {
                MediaType = "x",
                Sample = "x",
                Url = "x",
                VariableType = "x",
                Alt = "alt",
                Regex = "regex",
                ShortUrl = "shortUrl",
            },
            Type = "x",
            ID = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateVariable>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateVariable
        {
            Name = "x",
            Props = new()
            {
                MediaType = "x",
                Sample = "x",
                Url = "x",
                VariableType = "x",
                Alt = "alt",
                Regex = "regex",
                ShortUrl = "shortUrl",
            },
            Type = "x",
            ID = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateVariable>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        TemplateVariableProps expectedProps = new()
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProps, deserialized.Props);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateVariable
        {
            Name = "x",
            Props = new()
            {
                MediaType = "x",
                Sample = "x",
                Url = "x",
                VariableType = "x",
                Alt = "alt",
                Regex = "regex",
                ShortUrl = "shortUrl",
            },
            Type = "x",
            ID = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateVariable
        {
            Name = "x",
            Props = new()
            {
                MediaType = "x",
                Sample = "x",
                Url = "x",
                VariableType = "x",
                Alt = "alt",
                Regex = "regex",
                ShortUrl = "shortUrl",
            },
            Type = "x",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateVariable
        {
            Name = "x",
            Props = new()
            {
                MediaType = "x",
                Sample = "x",
                Url = "x",
                VariableType = "x",
                Alt = "alt",
                Regex = "regex",
                ShortUrl = "shortUrl",
            },
            Type = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplateVariable
        {
            Name = "x",
            Props = new()
            {
                MediaType = "x",
                Sample = "x",
                Url = "x",
                VariableType = "x",
                Alt = "alt",
                Regex = "regex",
                ShortUrl = "shortUrl",
            },
            Type = "x",

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateVariable
        {
            Name = "x",
            Props = new()
            {
                MediaType = "x",
                Sample = "x",
                Url = "x",
                VariableType = "x",
                Alt = "alt",
                Regex = "regex",
                ShortUrl = "shortUrl",
            },
            Type = "x",

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateVariable
        {
            Name = "x",
            Props = new()
            {
                MediaType = "x",
                Sample = "x",
                Url = "x",
                VariableType = "x",
                Alt = "alt",
                Regex = "regex",
                ShortUrl = "shortUrl",
            },
            Type = "x",
            ID = 0,
        };

        TemplateVariable copied = new(model);

        Assert.Equal(model, copied);
    }
}
