using System;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Calls;

namespace Sentdm.Tests.Models.Calls;

public class CallRecordingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallRecording
        {
            DownloadUrl = "download_url",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedDownloadUrl = "download_url";
        string expectedRecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedUrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedDownloadUrl, model.DownloadUrl);
        Assert.Equal(expectedRecordingID, model.RecordingID);
        Assert.Equal(expectedUrlExpiresAt, model.UrlExpiresAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallRecording
        {
            DownloadUrl = "download_url",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallRecording>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallRecording
        {
            DownloadUrl = "download_url",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallRecording>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDownloadUrl = "download_url";
        string expectedRecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedUrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedDownloadUrl, deserialized.DownloadUrl);
        Assert.Equal(expectedRecordingID, deserialized.RecordingID);
        Assert.Equal(expectedUrlExpiresAt, deserialized.UrlExpiresAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallRecording
        {
            DownloadUrl = "download_url",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallRecording { };

        Assert.Null(model.DownloadUrl);
        Assert.False(model.RawData.ContainsKey("download_url"));
        Assert.Null(model.RecordingID);
        Assert.False(model.RawData.ContainsKey("recording_id"));
        Assert.Null(model.UrlExpiresAt);
        Assert.False(model.RawData.ContainsKey("url_expires_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallRecording { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CallRecording
        {
            // Null should be interpreted as omitted for these properties
            DownloadUrl = null,
            RecordingID = null,
            UrlExpiresAt = null,
        };

        Assert.Null(model.DownloadUrl);
        Assert.False(model.RawData.ContainsKey("download_url"));
        Assert.Null(model.RecordingID);
        Assert.False(model.RawData.ContainsKey("recording_id"));
        Assert.Null(model.UrlExpiresAt);
        Assert.False(model.RawData.ContainsKey("url_expires_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallRecording
        {
            // Null should be interpreted as omitted for these properties
            DownloadUrl = null,
            RecordingID = null,
            UrlExpiresAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallRecording
        {
            DownloadUrl = "download_url",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CallRecording copied = new(model);

        Assert.Equal(model, copied);
    }
}
