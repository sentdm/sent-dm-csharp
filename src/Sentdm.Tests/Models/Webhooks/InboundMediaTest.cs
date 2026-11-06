using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class InboundMediaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundMedia
        {
            HashSha256 = "hash_sha256",
            MimeType = "mime_type",
            SizeBytes = 0,
            Url = "url",
        };

        string expectedHashSha256 = "hash_sha256";
        string expectedMimeType = "mime_type";
        long expectedSizeBytes = 0;
        string expectedUrl = "url";

        Assert.Equal(expectedHashSha256, model.HashSha256);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundMedia
        {
            HashSha256 = "hash_sha256",
            MimeType = "mime_type",
            SizeBytes = 0,
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundMedia>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundMedia
        {
            HashSha256 = "hash_sha256",
            MimeType = "mime_type",
            SizeBytes = 0,
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundMedia>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedHashSha256 = "hash_sha256";
        string expectedMimeType = "mime_type";
        long expectedSizeBytes = 0;
        string expectedUrl = "url";

        Assert.Equal(expectedHashSha256, deserialized.HashSha256);
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundMedia
        {
            HashSha256 = "hash_sha256",
            MimeType = "mime_type",
            SizeBytes = 0,
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InboundMedia { };

        Assert.Null(model.HashSha256);
        Assert.False(model.RawData.ContainsKey("hash_sha256"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("size_bytes"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InboundMedia { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InboundMedia
        {
            HashSha256 = null,
            MimeType = null,
            SizeBytes = null,
            Url = null,
        };

        Assert.Null(model.HashSha256);
        Assert.True(model.RawData.ContainsKey("hash_sha256"));
        Assert.Null(model.MimeType);
        Assert.True(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.SizeBytes);
        Assert.True(model.RawData.ContainsKey("size_bytes"));
        Assert.Null(model.Url);
        Assert.True(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InboundMedia
        {
            HashSha256 = null,
            MimeType = null,
            SizeBytes = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundMedia
        {
            HashSha256 = "hash_sha256",
            MimeType = "mime_type",
            SizeBytes = 0,
            Url = "url",
        };

        InboundMedia copied = new(model);

        Assert.Equal(model, copied);
    }
}
