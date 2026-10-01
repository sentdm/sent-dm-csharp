using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Calls;

namespace Sentdm.Tests.Models.Calls;

public class CallRecordingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallRecordings
        {
            Recordings =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    UrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<CallRecording> expectedRecordings =
        [
            new()
            {
                DownloadUrl = "download_url",
                RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                UrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.NotNull(model.Recordings);
        Assert.Equal(expectedRecordings.Count, model.Recordings.Count);
        for (int i = 0; i < expectedRecordings.Count; i++)
        {
            Assert.Equal(expectedRecordings[i], model.Recordings[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallRecordings
        {
            Recordings =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    UrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallRecordings>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallRecordings
        {
            Recordings =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    UrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallRecordings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CallRecording> expectedRecordings =
        [
            new()
            {
                DownloadUrl = "download_url",
                RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                UrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.NotNull(deserialized.Recordings);
        Assert.Equal(expectedRecordings.Count, deserialized.Recordings.Count);
        for (int i = 0; i < expectedRecordings.Count; i++)
        {
            Assert.Equal(expectedRecordings[i], deserialized.Recordings[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallRecordings
        {
            Recordings =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    UrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallRecordings { };

        Assert.Null(model.Recordings);
        Assert.False(model.RawData.ContainsKey("recordings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallRecordings { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CallRecordings
        {
            // Null should be interpreted as omitted for these properties
            Recordings = null,
        };

        Assert.Null(model.Recordings);
        Assert.False(model.RawData.ContainsKey("recordings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallRecordings
        {
            // Null should be interpreted as omitted for these properties
            Recordings = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallRecordings
        {
            Recordings =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    UrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        CallRecordings copied = new(model);

        Assert.Equal(model, copied);
    }
}
