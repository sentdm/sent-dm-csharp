using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Templates;

namespace SentDm.Tests.Models.Templates;

public class TemplateVariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateVariable
        {
            ID = 0,
            Name = "name",
            Props = new()
            {
                Alt = "alt",
                MediaType = "mediaType",
                Sample = "sample",
                ShortUrl = "shortUrl",
                Url = "url",
                VariableType = "variableType",
            },
            Type = "type",
        };

        int expectedID = 0;
        string expectedName = "name";
        TemplateVariableProps expectedProps = new()
        {
            Alt = "alt",
            MediaType = "mediaType",
            Sample = "sample",
            ShortUrl = "shortUrl",
            Url = "url",
            VariableType = "variableType",
        };
        string expectedType = "type";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProps, model.Props);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateVariable
        {
            ID = 0,
            Name = "name",
            Props = new()
            {
                Alt = "alt",
                MediaType = "mediaType",
                Sample = "sample",
                ShortUrl = "shortUrl",
                Url = "url",
                VariableType = "variableType",
            },
            Type = "type",
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
            ID = 0,
            Name = "name",
            Props = new()
            {
                Alt = "alt",
                MediaType = "mediaType",
                Sample = "sample",
                ShortUrl = "shortUrl",
                Url = "url",
                VariableType = "variableType",
            },
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateVariable>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedID = 0;
        string expectedName = "name";
        TemplateVariableProps expectedProps = new()
        {
            Alt = "alt",
            MediaType = "mediaType",
            Sample = "sample",
            ShortUrl = "shortUrl",
            Url = "url",
            VariableType = "variableType",
        };
        string expectedType = "type";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProps, deserialized.Props);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateVariable
        {
            ID = 0,
            Name = "name",
            Props = new()
            {
                Alt = "alt",
                MediaType = "mediaType",
                Sample = "sample",
                ShortUrl = "shortUrl",
                Url = "url",
                VariableType = "variableType",
            },
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateVariable { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Props);
        Assert.False(model.RawData.ContainsKey("props"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateVariable { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplateVariable
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
            Props = null,
            Type = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Props);
        Assert.False(model.RawData.ContainsKey("props"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateVariable
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
            Props = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateVariable
        {
            ID = 0,
            Name = "name",
            Props = new()
            {
                Alt = "alt",
                MediaType = "mediaType",
                Sample = "sample",
                ShortUrl = "shortUrl",
                Url = "url",
                VariableType = "variableType",
            },
            Type = "type",
        };

        TemplateVariable copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateVariablePropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateVariableProps
        {
            Alt = "alt",
            MediaType = "mediaType",
            Sample = "sample",
            ShortUrl = "shortUrl",
            Url = "url",
            VariableType = "variableType",
        };

        string expectedAlt = "alt";
        string expectedMediaType = "mediaType";
        string expectedSample = "sample";
        string expectedShortUrl = "shortUrl";
        string expectedUrl = "url";
        string expectedVariableType = "variableType";

        Assert.Equal(expectedAlt, model.Alt);
        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.Equal(expectedSample, model.Sample);
        Assert.Equal(expectedShortUrl, model.ShortUrl);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedVariableType, model.VariableType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateVariableProps
        {
            Alt = "alt",
            MediaType = "mediaType",
            Sample = "sample",
            ShortUrl = "shortUrl",
            Url = "url",
            VariableType = "variableType",
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
            Alt = "alt",
            MediaType = "mediaType",
            Sample = "sample",
            ShortUrl = "shortUrl",
            Url = "url",
            VariableType = "variableType",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateVariableProps>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAlt = "alt";
        string expectedMediaType = "mediaType";
        string expectedSample = "sample";
        string expectedShortUrl = "shortUrl";
        string expectedUrl = "url";
        string expectedVariableType = "variableType";

        Assert.Equal(expectedAlt, deserialized.Alt);
        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.Equal(expectedSample, deserialized.Sample);
        Assert.Equal(expectedShortUrl, deserialized.ShortUrl);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedVariableType, deserialized.VariableType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateVariableProps
        {
            Alt = "alt",
            MediaType = "mediaType",
            Sample = "sample",
            ShortUrl = "shortUrl",
            Url = "url",
            VariableType = "variableType",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateVariableProps { };

        Assert.Null(model.Alt);
        Assert.False(model.RawData.ContainsKey("alt"));
        Assert.Null(model.MediaType);
        Assert.False(model.RawData.ContainsKey("mediaType"));
        Assert.Null(model.Sample);
        Assert.False(model.RawData.ContainsKey("sample"));
        Assert.Null(model.ShortUrl);
        Assert.False(model.RawData.ContainsKey("shortUrl"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.VariableType);
        Assert.False(model.RawData.ContainsKey("variableType"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateVariableProps { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateVariableProps
        {
            Alt = null,
            MediaType = null,
            Sample = null,
            ShortUrl = null,
            Url = null,
            VariableType = null,
        };

        Assert.Null(model.Alt);
        Assert.True(model.RawData.ContainsKey("alt"));
        Assert.Null(model.MediaType);
        Assert.True(model.RawData.ContainsKey("mediaType"));
        Assert.Null(model.Sample);
        Assert.True(model.RawData.ContainsKey("sample"));
        Assert.Null(model.ShortUrl);
        Assert.True(model.RawData.ContainsKey("shortUrl"));
        Assert.Null(model.Url);
        Assert.True(model.RawData.ContainsKey("url"));
        Assert.Null(model.VariableType);
        Assert.True(model.RawData.ContainsKey("variableType"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateVariableProps
        {
            Alt = null,
            MediaType = null,
            Sample = null,
            ShortUrl = null,
            Url = null,
            VariableType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateVariableProps
        {
            Alt = "alt",
            MediaType = "mediaType",
            Sample = "sample",
            ShortUrl = "shortUrl",
            Url = "url",
            VariableType = "variableType",
        };

        TemplateVariableProps copied = new(model);

        Assert.Equal(model, copied);
    }
}
