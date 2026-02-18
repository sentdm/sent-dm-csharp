using System.Collections.Generic;
using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Templates;

namespace SentDm.Tests.Models.Templates;

public class TemplateBodyContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateBodyContent
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
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
                },
            ],
        };

        string expectedTemplate = "template";
        string expectedType = "type";
        List<TemplateVariable> expectedVariables =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedTemplate, model.Template);
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.Variables);
        Assert.Equal(expectedVariables.Count, model.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.Equal(expectedVariables[i], model.Variables[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateBodyContent
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateBodyContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateBodyContent
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateBodyContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedType = "type";
        List<TemplateVariable> expectedVariables =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedTemplate, deserialized.Template);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.Variables);
        Assert.Equal(expectedVariables.Count, deserialized.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.Equal(expectedVariables[i], deserialized.Variables[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateBodyContent
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateBodyContent
        {
            Type = "type",
            Variables =
            [
                new()
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
                },
            ],
        };

        Assert.Null(model.Template);
        Assert.False(model.RawData.ContainsKey("template"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateBodyContent
        {
            Type = "type",
            Variables =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplateBodyContent
        {
            Type = "type",
            Variables =
            [
                new()
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
                },
            ],

            // Null should be interpreted as omitted for these properties
            Template = null,
        };

        Assert.Null(model.Template);
        Assert.False(model.RawData.ContainsKey("template"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateBodyContent
        {
            Type = "type",
            Variables =
            [
                new()
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
                },
            ],

            // Null should be interpreted as omitted for these properties
            Template = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateBodyContent { Template = "template" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateBodyContent { Template = "template" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateBodyContent
        {
            Template = "template",

            Type = null,
            Variables = null,
        };

        Assert.Null(model.Type);
        Assert.True(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.True(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateBodyContent
        {
            Template = "template",

            Type = null,
            Variables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateBodyContent
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
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
                },
            ],
        };

        TemplateBodyContent copied = new(model);

        Assert.Equal(model, copied);
    }
}
