using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Voice.Voices;

namespace Sentdm.Tests.Models.Voice.Voices;

public class VoiceCatalogueTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceCatalogue
        {
            Languages = ["string"],
            Voices =
            [
                new()
                {
                    Default = true,
                    Description = "description",
                    Language = "language",
                    Name = "name",
                },
            ],
        };

        List<string> expectedLanguages = ["string"];
        List<VoiceCatalogueVoice> expectedVoices =
        [
            new()
            {
                Default = true,
                Description = "description",
                Language = "language",
                Name = "name",
            },
        ];

        Assert.NotNull(model.Languages);
        Assert.Equal(expectedLanguages.Count, model.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], model.Languages[i]);
        }
        Assert.NotNull(model.Voices);
        Assert.Equal(expectedVoices.Count, model.Voices.Count);
        for (int i = 0; i < expectedVoices.Count; i++)
        {
            Assert.Equal(expectedVoices[i], model.Voices[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceCatalogue
        {
            Languages = ["string"],
            Voices =
            [
                new()
                {
                    Default = true,
                    Description = "description",
                    Language = "language",
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceCatalogue>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceCatalogue
        {
            Languages = ["string"],
            Voices =
            [
                new()
                {
                    Default = true,
                    Description = "description",
                    Language = "language",
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceCatalogue>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedLanguages = ["string"];
        List<VoiceCatalogueVoice> expectedVoices =
        [
            new()
            {
                Default = true,
                Description = "description",
                Language = "language",
                Name = "name",
            },
        ];

        Assert.NotNull(deserialized.Languages);
        Assert.Equal(expectedLanguages.Count, deserialized.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], deserialized.Languages[i]);
        }
        Assert.NotNull(deserialized.Voices);
        Assert.Equal(expectedVoices.Count, deserialized.Voices.Count);
        for (int i = 0; i < expectedVoices.Count; i++)
        {
            Assert.Equal(expectedVoices[i], deserialized.Voices[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceCatalogue
        {
            Languages = ["string"],
            Voices =
            [
                new()
                {
                    Default = true,
                    Description = "description",
                    Language = "language",
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceCatalogue { };

        Assert.Null(model.Languages);
        Assert.False(model.RawData.ContainsKey("languages"));
        Assert.Null(model.Voices);
        Assert.False(model.RawData.ContainsKey("voices"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceCatalogue { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceCatalogue
        {
            // Null should be interpreted as omitted for these properties
            Languages = null,
            Voices = null,
        };

        Assert.Null(model.Languages);
        Assert.False(model.RawData.ContainsKey("languages"));
        Assert.Null(model.Voices);
        Assert.False(model.RawData.ContainsKey("voices"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceCatalogue
        {
            // Null should be interpreted as omitted for these properties
            Languages = null,
            Voices = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceCatalogue
        {
            Languages = ["string"],
            Voices =
            [
                new()
                {
                    Default = true,
                    Description = "description",
                    Language = "language",
                    Name = "name",
                },
            ],
        };

        VoiceCatalogue copied = new(model);

        Assert.Equal(model, copied);
    }
}
