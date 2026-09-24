using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateHeaderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateHeader
        {
            Template = "template",
            ExampleUrl = "example_url",
            Location = new()
            {
                Address = "x",
                Latitude = "x",
                Longitude = "x",
                Name = "x",
            },
            StaticResource = true,
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
        };

        string expectedTemplate = "template";
        string expectedExampleUrl = "example_url";
        Location expectedLocation = new()
        {
            Address = "x",
            Latitude = "x",
            Longitude = "x",
            Name = "x",
        };
        bool expectedStaticResource = true;
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

        Assert.Equal(expectedTemplate, model.Template);
        Assert.Equal(expectedExampleUrl, model.ExampleUrl);
        Assert.Equal(expectedLocation, model.Location);
        Assert.Equal(expectedStaticResource, model.StaticResource);
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
        var model = new TemplateHeader
        {
            Template = "template",
            ExampleUrl = "example_url",
            Location = new()
            {
                Address = "x",
                Latitude = "x",
                Longitude = "x",
                Name = "x",
            },
            StaticResource = true,
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateHeader>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateHeader
        {
            Template = "template",
            ExampleUrl = "example_url",
            Location = new()
            {
                Address = "x",
                Latitude = "x",
                Longitude = "x",
                Name = "x",
            },
            StaticResource = true,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateHeader>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedExampleUrl = "example_url";
        Location expectedLocation = new()
        {
            Address = "x",
            Latitude = "x",
            Longitude = "x",
            Name = "x",
        };
        bool expectedStaticResource = true;
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

        Assert.Equal(expectedTemplate, deserialized.Template);
        Assert.Equal(expectedExampleUrl, deserialized.ExampleUrl);
        Assert.Equal(expectedLocation, deserialized.Location);
        Assert.Equal(expectedStaticResource, deserialized.StaticResource);
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
        var model = new TemplateHeader
        {
            Template = "template",
            ExampleUrl = "example_url",
            Location = new()
            {
                Address = "x",
                Latitude = "x",
                Longitude = "x",
                Name = "x",
            },
            StaticResource = true,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateHeader
        {
            Template = "template",
            ExampleUrl = "example_url",
            Location = new()
            {
                Address = "x",
                Latitude = "x",
                Longitude = "x",
                Name = "x",
            },
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
        };

        Assert.Null(model.StaticResource);
        Assert.False(model.RawData.ContainsKey("static_resource"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateHeader
        {
            Template = "template",
            ExampleUrl = "example_url",
            Location = new()
            {
                Address = "x",
                Latitude = "x",
                Longitude = "x",
                Name = "x",
            },
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplateHeader
        {
            Template = "template",
            ExampleUrl = "example_url",
            Location = new()
            {
                Address = "x",
                Latitude = "x",
                Longitude = "x",
                Name = "x",
            },
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

            // Null should be interpreted as omitted for these properties
            StaticResource = null,
        };

        Assert.Null(model.StaticResource);
        Assert.False(model.RawData.ContainsKey("static_resource"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateHeader
        {
            Template = "template",
            ExampleUrl = "example_url",
            Location = new()
            {
                Address = "x",
                Latitude = "x",
                Longitude = "x",
                Name = "x",
            },
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

            // Null should be interpreted as omitted for these properties
            StaticResource = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateHeader { Template = "template", StaticResource = true };

        Assert.Null(model.ExampleUrl);
        Assert.False(model.RawData.ContainsKey("example_url"));
        Assert.Null(model.Location);
        Assert.False(model.RawData.ContainsKey("location"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateHeader { Template = "template", StaticResource = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateHeader
        {
            Template = "template",
            StaticResource = true,

            ExampleUrl = null,
            Location = null,
            Type = null,
            Variables = null,
        };

        Assert.Null(model.ExampleUrl);
        Assert.True(model.RawData.ContainsKey("example_url"));
        Assert.Null(model.Location);
        Assert.True(model.RawData.ContainsKey("location"));
        Assert.Null(model.Type);
        Assert.True(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.True(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateHeader
        {
            Template = "template",
            StaticResource = true,

            ExampleUrl = null,
            Location = null,
            Type = null,
            Variables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateHeader
        {
            Template = "template",
            ExampleUrl = "example_url",
            Location = new()
            {
                Address = "x",
                Latitude = "x",
                Longitude = "x",
                Name = "x",
            },
            StaticResource = true,
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
        };

        TemplateHeader copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Location
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
        var model = new Location
        {
            Address = "x",
            Latitude = "x",
            Longitude = "x",
            Name = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Location>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Location
        {
            Address = "x",
            Latitude = "x",
            Longitude = "x",
            Name = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Location>(
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
        var model = new Location
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
        var model = new Location
        {
            Address = "x",
            Latitude = "x",
            Longitude = "x",
            Name = "x",
        };

        Location copied = new(model);

        Assert.Equal(model, copied);
    }
}
