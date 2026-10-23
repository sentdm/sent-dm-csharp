using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Calls;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Calls;

public class ApiResponseOfCallRecordingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiResponseOfCallRecordings
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        ApiResponseOfCallRecordingsData expectedData = new()
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
        ErrorDetail expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedMeta, model.Meta);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiResponseOfCallRecordings
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfCallRecordings>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiResponseOfCallRecordings
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfCallRecordings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiResponseOfCallRecordingsData expectedData = new()
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
        ErrorDetail expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedMeta, deserialized.Meta);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiResponseOfCallRecordings
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ApiResponseOfCallRecordings
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
        };

        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ApiResponseOfCallRecordings
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ApiResponseOfCallRecordings
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },

            // Null should be interpreted as omitted for these properties
            Meta = null,
            Success = null,
        };

        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ApiResponseOfCallRecordings
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },

            // Null should be interpreted as omitted for these properties
            Meta = null,
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ApiResponseOfCallRecordings
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ApiResponseOfCallRecordings
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ApiResponseOfCallRecordings
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,

            Data = null,
            Error = null,
        };

        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ApiResponseOfCallRecordings
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,

            Data = null,
            Error = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiResponseOfCallRecordings
        {
            Data = new()
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
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        ApiResponseOfCallRecordings copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ApiResponseOfCallRecordingsDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiResponseOfCallRecordingsData
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

        List<Recording> expectedRecordings =
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
        var model = new ApiResponseOfCallRecordingsData
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
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfCallRecordingsData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiResponseOfCallRecordingsData
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
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfCallRecordingsData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Recording> expectedRecordings =
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
        var model = new ApiResponseOfCallRecordingsData
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
        var model = new ApiResponseOfCallRecordingsData { };

        Assert.Null(model.Recordings);
        Assert.False(model.RawData.ContainsKey("recordings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ApiResponseOfCallRecordingsData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ApiResponseOfCallRecordingsData
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
        var model = new ApiResponseOfCallRecordingsData
        {
            // Null should be interpreted as omitted for these properties
            Recordings = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiResponseOfCallRecordingsData
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

        ApiResponseOfCallRecordingsData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RecordingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Recording
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
        var model = new Recording
        {
            DownloadUrl = "download_url",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Recording>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Recording
        {
            DownloadUrl = "download_url",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Recording>(
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
        var model = new Recording
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
        var model = new Recording { };

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
        var model = new Recording { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Recording
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
        var model = new Recording
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
        var model = new Recording
        {
            DownloadUrl = "download_url",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UrlExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Recording copied = new(model);

        Assert.Equal(model, copied);
    }
}
