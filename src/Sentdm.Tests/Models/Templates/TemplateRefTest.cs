using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateRefTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateRef
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "name",
            Parameters = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "slug",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedName = "name";
        Dictionary<string, string> expectedParameters = new() { { "foo", "string" } };
        string expectedSlug = "slug";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.Parameters);
        Assert.Equal(expectedParameters.Count, model.Parameters.Count);
        foreach (var item in expectedParameters)
        {
            Assert.True(model.Parameters.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Parameters[item.Key]);
        }
        Assert.Equal(expectedSlug, model.Slug);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateRef
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "name",
            Parameters = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "slug",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateRef>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateRef
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "name",
            Parameters = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "slug",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateRef>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedName = "name";
        Dictionary<string, string> expectedParameters = new() { { "foo", "string" } };
        string expectedSlug = "slug";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.Parameters);
        Assert.Equal(expectedParameters.Count, deserialized.Parameters.Count);
        foreach (var item in expectedParameters)
        {
            Assert.True(deserialized.Parameters.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Parameters[item.Key]);
        }
        Assert.Equal(expectedSlug, deserialized.Slug);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateRef
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "name",
            Parameters = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "slug",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateRef { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Parameters);
        Assert.False(model.RawData.ContainsKey("parameters"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateRef { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateRef
        {
            ID = null,
            Name = null,
            Parameters = null,
            Slug = null,
        };

        Assert.Null(model.ID);
        Assert.True(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.Parameters);
        Assert.True(model.RawData.ContainsKey("parameters"));
        Assert.Null(model.Slug);
        Assert.True(model.RawData.ContainsKey("slug"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateRef
        {
            ID = null,
            Name = null,
            Parameters = null,
            Slug = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateRef
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "name",
            Parameters = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "slug",
        };

        TemplateRef copied = new(model);

        Assert.Equal(model, copied);
    }
}
