using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateMmsBodyContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateMmsBodyContent
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
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
                },
            ],
            Media = [new() { MediaType = "mediaType", Url = "url" }],
            Subject = "subject",
        };

        string expectedTemplate = "template";
        string expectedType = "type";
        List<TemplateVariable> expectedVariables =
        [
            new()
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
            },
        ];
        List<TemplateMediaItem> expectedMedia = [new() { MediaType = "mediaType", Url = "url" }];
        string expectedSubject = "subject";

        Assert.Equal(expectedTemplate, model.Template);
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.Variables);
        Assert.Equal(expectedVariables.Count, model.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.Equal(expectedVariables[i], model.Variables[i]);
        }
        Assert.NotNull(model.Media);
        Assert.Equal(expectedMedia.Count, model.Media.Count);
        for (int i = 0; i < expectedMedia.Count; i++)
        {
            Assert.Equal(expectedMedia[i], model.Media[i]);
        }
        Assert.Equal(expectedSubject, model.Subject);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateMmsBodyContent
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
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
                },
            ],
            Media = [new() { MediaType = "mediaType", Url = "url" }],
            Subject = "subject",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateMmsBodyContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateMmsBodyContent
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
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
                },
            ],
            Media = [new() { MediaType = "mediaType", Url = "url" }],
            Subject = "subject",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateMmsBodyContent>(
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
            },
        ];
        List<TemplateMediaItem> expectedMedia = [new() { MediaType = "mediaType", Url = "url" }];
        string expectedSubject = "subject";

        Assert.Equal(expectedTemplate, deserialized.Template);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.Variables);
        Assert.Equal(expectedVariables.Count, deserialized.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.Equal(expectedVariables[i], deserialized.Variables[i]);
        }
        Assert.NotNull(deserialized.Media);
        Assert.Equal(expectedMedia.Count, deserialized.Media.Count);
        for (int i = 0; i < expectedMedia.Count; i++)
        {
            Assert.Equal(expectedMedia[i], deserialized.Media[i]);
        }
        Assert.Equal(expectedSubject, deserialized.Subject);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateMmsBodyContent
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
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
                },
            ],
            Media = [new() { MediaType = "mediaType", Url = "url" }],
            Subject = "subject",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateMmsBodyContent { Template = "template" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
        Assert.Null(model.Media);
        Assert.False(model.RawData.ContainsKey("media"));
        Assert.Null(model.Subject);
        Assert.False(model.RawData.ContainsKey("subject"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateMmsBodyContent { Template = "template" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateMmsBodyContent
        {
            Template = "template",

            Type = null,
            Variables = null,
            Media = null,
            Subject = null,
        };

        Assert.Null(model.Type);
        Assert.True(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.True(model.RawData.ContainsKey("variables"));
        Assert.Null(model.Media);
        Assert.True(model.RawData.ContainsKey("media"));
        Assert.Null(model.Subject);
        Assert.True(model.RawData.ContainsKey("subject"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateMmsBodyContent
        {
            Template = "template",

            Type = null,
            Variables = null,
            Media = null,
            Subject = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateMmsBodyContent
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
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
                },
            ],
            Media = [new() { MediaType = "mediaType", Url = "url" }],
            Subject = "subject",
        };

        TemplateMmsBodyContent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SentDmServicesCommonEntitiesTemplateMmsBodyContentPropertiesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties
        {
            Media = [new() { MediaType = "mediaType", Url = "url" }],
            Subject = "subject",
        };

        List<TemplateMediaItem> expectedMedia = [new() { MediaType = "mediaType", Url = "url" }];
        string expectedSubject = "subject";

        Assert.NotNull(model.Media);
        Assert.Equal(expectedMedia.Count, model.Media.Count);
        for (int i = 0; i < expectedMedia.Count; i++)
        {
            Assert.Equal(expectedMedia[i], model.Media[i]);
        }
        Assert.Equal(expectedSubject, model.Subject);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties
        {
            Media = [new() { MediaType = "mediaType", Url = "url" }],
            Subject = "subject",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties
        {
            Media = [new() { MediaType = "mediaType", Url = "url" }],
            Subject = "subject",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<TemplateMediaItem> expectedMedia = [new() { MediaType = "mediaType", Url = "url" }];
        string expectedSubject = "subject";

        Assert.NotNull(deserialized.Media);
        Assert.Equal(expectedMedia.Count, deserialized.Media.Count);
        for (int i = 0; i < expectedMedia.Count; i++)
        {
            Assert.Equal(expectedMedia[i], deserialized.Media[i]);
        }
        Assert.Equal(expectedSubject, deserialized.Subject);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties
        {
            Media = [new() { MediaType = "mediaType", Url = "url" }],
            Subject = "subject",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties { };

        Assert.Null(model.Media);
        Assert.False(model.RawData.ContainsKey("media"));
        Assert.Null(model.Subject);
        Assert.False(model.RawData.ContainsKey("subject"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties
        {
            Media = null,
            Subject = null,
        };

        Assert.Null(model.Media);
        Assert.True(model.RawData.ContainsKey("media"));
        Assert.Null(model.Subject);
        Assert.True(model.RawData.ContainsKey("subject"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties
        {
            Media = null,
            Subject = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties
        {
            Media = [new() { MediaType = "mediaType", Url = "url" }],
            Subject = "subject",
        };

        SentDmServicesCommonEntitiesTemplateMmsBodyContentProperties copied = new(model);

        Assert.Equal(model, copied);
    }
}
