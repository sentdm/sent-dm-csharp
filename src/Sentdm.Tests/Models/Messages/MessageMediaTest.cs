using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Messages;

namespace Sentdm.Tests.Models.Messages;

public class MessageMediaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageMedia
        {
            MediaType = "mediaType",
            MimeType = "mimeType",
            SizeBytes = 0,
            SourceHashSha256 = "sourceHashSha256",
            Url = "url",
        };

        string expectedMediaType = "mediaType";
        string expectedMimeType = "mimeType";
        long expectedSizeBytes = 0;
        string expectedSourceHashSha256 = "sourceHashSha256";
        string expectedUrl = "url";

        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
        Assert.Equal(expectedSourceHashSha256, model.SourceHashSha256);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageMedia
        {
            MediaType = "mediaType",
            MimeType = "mimeType",
            SizeBytes = 0,
            SourceHashSha256 = "sourceHashSha256",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageMedia>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageMedia
        {
            MediaType = "mediaType",
            MimeType = "mimeType",
            SizeBytes = 0,
            SourceHashSha256 = "sourceHashSha256",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageMedia>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMediaType = "mediaType";
        string expectedMimeType = "mimeType";
        long expectedSizeBytes = 0;
        string expectedSourceHashSha256 = "sourceHashSha256";
        string expectedUrl = "url";

        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
        Assert.Equal(expectedSourceHashSha256, deserialized.SourceHashSha256);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageMedia
        {
            MediaType = "mediaType",
            MimeType = "mimeType",
            SizeBytes = 0,
            SourceHashSha256 = "sourceHashSha256",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageMedia { };

        Assert.Null(model.MediaType);
        Assert.False(model.RawData.ContainsKey("mediaType"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mimeType"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("sizeBytes"));
        Assert.Null(model.SourceHashSha256);
        Assert.False(model.RawData.ContainsKey("sourceHashSha256"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageMedia { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MessageMedia
        {
            MediaType = null,
            MimeType = null,
            SizeBytes = null,
            SourceHashSha256 = null,
            Url = null,
        };

        Assert.Null(model.MediaType);
        Assert.True(model.RawData.ContainsKey("mediaType"));
        Assert.Null(model.MimeType);
        Assert.True(model.RawData.ContainsKey("mimeType"));
        Assert.Null(model.SizeBytes);
        Assert.True(model.RawData.ContainsKey("sizeBytes"));
        Assert.Null(model.SourceHashSha256);
        Assert.True(model.RawData.ContainsKey("sourceHashSha256"));
        Assert.Null(model.Url);
        Assert.True(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageMedia
        {
            MediaType = null,
            MimeType = null,
            SizeBytes = null,
            SourceHashSha256 = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageMedia
        {
            MediaType = "mediaType",
            MimeType = "mimeType",
            SizeBytes = 0,
            SourceHashSha256 = "sourceHashSha256",
            Url = "url",
        };

        MessageMedia copied = new(model);

        Assert.Equal(model, copied);
    }
}
