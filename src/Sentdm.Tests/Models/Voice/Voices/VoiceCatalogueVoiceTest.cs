using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Voice.Voices;

namespace Sentdm.Tests.Models.Voice.Voices;

public class VoiceCatalogueVoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceCatalogueVoice
        {
            Default = true,
            Description = "description",
            Language = "language",
            Name = "name",
        };

        bool expectedDefault = true;
        string expectedDescription = "description";
        string expectedLanguage = "language";
        string expectedName = "name";

        Assert.Equal(expectedDefault, model.Default);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceCatalogueVoice
        {
            Default = true,
            Description = "description",
            Language = "language",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceCatalogueVoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceCatalogueVoice
        {
            Default = true,
            Description = "description",
            Language = "language",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceCatalogueVoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedDefault = true;
        string expectedDescription = "description";
        string expectedLanguage = "language";
        string expectedName = "name";

        Assert.Equal(expectedDefault, deserialized.Default);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceCatalogueVoice
        {
            Default = true,
            Description = "description",
            Language = "language",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceCatalogueVoice { };

        Assert.Null(model.Default);
        Assert.False(model.RawData.ContainsKey("default"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceCatalogueVoice { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceCatalogueVoice
        {
            // Null should be interpreted as omitted for these properties
            Default = null,
            Description = null,
            Language = null,
            Name = null,
        };

        Assert.Null(model.Default);
        Assert.False(model.RawData.ContainsKey("default"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceCatalogueVoice
        {
            // Null should be interpreted as omitted for these properties
            Default = null,
            Description = null,
            Language = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceCatalogueVoice
        {
            Default = true,
            Description = "description",
            Language = "language",
            Name = "name",
        };

        VoiceCatalogueVoice copied = new(model);

        Assert.Equal(model, copied);
    }
}
