using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Messages;

namespace Sentdm.Tests.Models.Messages;

public class MessageBodyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Content = "content",
            Footer = "footer",
            Header = "header",
            HeaderMedia = new() { Type = "type", Url = "url" },
            Media =
            [
                new()
                {
                    MediaType = "mediaType",
                    MimeType = "mimeType",
                    SizeBytes = 0,
                    SourceHashSha256 = "sourceHashSha256",
                    Url = "url",
                },
            ],
            Subject = "subject",
        };

        List<MessageButton> expectedButtons =
        [
            new()
            {
                PostbackData = "postbackData",
                Text = "text",
                Type = "type",
                Value = "value",
            },
        ];
        string expectedContent = "content";
        string expectedFooter = "footer";
        string expectedHeader = "header";
        MessageHeaderMedia expectedHeaderMedia = new() { Type = "type", Url = "url" };
        List<MessageMedia> expectedMedia =
        [
            new()
            {
                MediaType = "mediaType",
                MimeType = "mimeType",
                SizeBytes = 0,
                SourceHashSha256 = "sourceHashSha256",
                Url = "url",
            },
        ];
        string expectedSubject = "subject";

        Assert.NotNull(model.Buttons);
        Assert.Equal(expectedButtons.Count, model.Buttons.Count);
        for (int i = 0; i < expectedButtons.Count; i++)
        {
            Assert.Equal(expectedButtons[i], model.Buttons[i]);
        }
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedFooter, model.Footer);
        Assert.Equal(expectedHeader, model.Header);
        Assert.Equal(expectedHeaderMedia, model.HeaderMedia);
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
        var model = new MessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Content = "content",
            Footer = "footer",
            Header = "header",
            HeaderMedia = new() { Type = "type", Url = "url" },
            Media =
            [
                new()
                {
                    MediaType = "mediaType",
                    MimeType = "mimeType",
                    SizeBytes = 0,
                    SourceHashSha256 = "sourceHashSha256",
                    Url = "url",
                },
            ],
            Subject = "subject",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageBody>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Content = "content",
            Footer = "footer",
            Header = "header",
            HeaderMedia = new() { Type = "type", Url = "url" },
            Media =
            [
                new()
                {
                    MediaType = "mediaType",
                    MimeType = "mimeType",
                    SizeBytes = 0,
                    SourceHashSha256 = "sourceHashSha256",
                    Url = "url",
                },
            ],
            Subject = "subject",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageBody>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<MessageButton> expectedButtons =
        [
            new()
            {
                PostbackData = "postbackData",
                Text = "text",
                Type = "type",
                Value = "value",
            },
        ];
        string expectedContent = "content";
        string expectedFooter = "footer";
        string expectedHeader = "header";
        MessageHeaderMedia expectedHeaderMedia = new() { Type = "type", Url = "url" };
        List<MessageMedia> expectedMedia =
        [
            new()
            {
                MediaType = "mediaType",
                MimeType = "mimeType",
                SizeBytes = 0,
                SourceHashSha256 = "sourceHashSha256",
                Url = "url",
            },
        ];
        string expectedSubject = "subject";

        Assert.NotNull(deserialized.Buttons);
        Assert.Equal(expectedButtons.Count, deserialized.Buttons.Count);
        for (int i = 0; i < expectedButtons.Count; i++)
        {
            Assert.Equal(expectedButtons[i], deserialized.Buttons[i]);
        }
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedFooter, deserialized.Footer);
        Assert.Equal(expectedHeader, deserialized.Header);
        Assert.Equal(expectedHeaderMedia, deserialized.HeaderMedia);
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
        var model = new MessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Content = "content",
            Footer = "footer",
            Header = "header",
            HeaderMedia = new() { Type = "type", Url = "url" },
            Media =
            [
                new()
                {
                    MediaType = "mediaType",
                    MimeType = "mimeType",
                    SizeBytes = 0,
                    SourceHashSha256 = "sourceHashSha256",
                    Url = "url",
                },
            ],
            Subject = "subject",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Footer = "footer",
            Header = "header",
            HeaderMedia = new() { Type = "type", Url = "url" },
            Media =
            [
                new()
                {
                    MediaType = "mediaType",
                    MimeType = "mimeType",
                    SizeBytes = 0,
                    SourceHashSha256 = "sourceHashSha256",
                    Url = "url",
                },
            ],
            Subject = "subject",
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Footer = "footer",
            Header = "header",
            HeaderMedia = new() { Type = "type", Url = "url" },
            Media =
            [
                new()
                {
                    MediaType = "mediaType",
                    MimeType = "mimeType",
                    SizeBytes = 0,
                    SourceHashSha256 = "sourceHashSha256",
                    Url = "url",
                },
            ],
            Subject = "subject",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Footer = "footer",
            Header = "header",
            HeaderMedia = new() { Type = "type", Url = "url" },
            Media =
            [
                new()
                {
                    MediaType = "mediaType",
                    MimeType = "mimeType",
                    SizeBytes = 0,
                    SourceHashSha256 = "sourceHashSha256",
                    Url = "url",
                },
            ],
            Subject = "subject",

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Footer = "footer",
            Header = "header",
            HeaderMedia = new() { Type = "type", Url = "url" },
            Media =
            [
                new()
                {
                    MediaType = "mediaType",
                    MimeType = "mimeType",
                    SizeBytes = 0,
                    SourceHashSha256 = "sourceHashSha256",
                    Url = "url",
                },
            ],
            Subject = "subject",

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageBody { Content = "content" };

        Assert.Null(model.Buttons);
        Assert.False(model.RawData.ContainsKey("buttons"));
        Assert.Null(model.Footer);
        Assert.False(model.RawData.ContainsKey("footer"));
        Assert.Null(model.Header);
        Assert.False(model.RawData.ContainsKey("header"));
        Assert.Null(model.HeaderMedia);
        Assert.False(model.RawData.ContainsKey("headerMedia"));
        Assert.Null(model.Media);
        Assert.False(model.RawData.ContainsKey("media"));
        Assert.Null(model.Subject);
        Assert.False(model.RawData.ContainsKey("subject"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageBody { Content = "content" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MessageBody
        {
            Content = "content",

            Buttons = null,
            Footer = null,
            Header = null,
            HeaderMedia = null,
            Media = null,
            Subject = null,
        };

        Assert.Null(model.Buttons);
        Assert.True(model.RawData.ContainsKey("buttons"));
        Assert.Null(model.Footer);
        Assert.True(model.RawData.ContainsKey("footer"));
        Assert.Null(model.Header);
        Assert.True(model.RawData.ContainsKey("header"));
        Assert.Null(model.HeaderMedia);
        Assert.True(model.RawData.ContainsKey("headerMedia"));
        Assert.Null(model.Media);
        Assert.True(model.RawData.ContainsKey("media"));
        Assert.Null(model.Subject);
        Assert.True(model.RawData.ContainsKey("subject"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageBody
        {
            Content = "content",

            Buttons = null,
            Footer = null,
            Header = null,
            HeaderMedia = null,
            Media = null,
            Subject = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageBody
        {
            Buttons =
            [
                new()
                {
                    PostbackData = "postbackData",
                    Text = "text",
                    Type = "type",
                    Value = "value",
                },
            ],
            Content = "content",
            Footer = "footer",
            Header = "header",
            HeaderMedia = new() { Type = "type", Url = "url" },
            Media =
            [
                new()
                {
                    MediaType = "mediaType",
                    MimeType = "mimeType",
                    SizeBytes = 0,
                    SourceHashSha256 = "sourceHashSha256",
                    Url = "url",
                },
            ],
            Subject = "subject",
        };

        MessageBody copied = new(model);

        Assert.Equal(model, copied);
    }
}
