using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Calls;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Calls;

public class ApiResponseOfCallsListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiResponseOfCallsList
        {
            Data = new()
            {
                Calls =
                [
                    new()
                    {
                        ID = "id",
                        AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Direction = "direction",
                        DurationSeconds = 0,
                        EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FailureReason = "failure_reason",
                        From = new() { Kind = "kind", Value = "value" },
                        Mode = "mode",
                        Number = "number",
                        Price = 0,
                        RecordingAvailable = true,
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = "status",
                        Timeline =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            },
                        ],
                        To = new() { Kind = "kind", Value = "value" },
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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

        ApiResponseOfCallsListData expectedData = new()
        {
            Calls =
            [
                new()
                {
                    ID = "id",
                    AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Direction = "direction",
                    DurationSeconds = 0,
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failure_reason",
                    From = new() { Kind = "kind", Value = "value" },
                    Mode = "mode",
                    Number = "number",
                    Price = 0,
                    RecordingAvailable = true,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    Timeline =
                    [
                        new()
                        {
                            Status = "status",
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    To = new() { Kind = "kind", Value = "value" },
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
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
        var model = new ApiResponseOfCallsList
        {
            Data = new()
            {
                Calls =
                [
                    new()
                    {
                        ID = "id",
                        AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Direction = "direction",
                        DurationSeconds = 0,
                        EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FailureReason = "failure_reason",
                        From = new() { Kind = "kind", Value = "value" },
                        Mode = "mode",
                        Number = "number",
                        Price = 0,
                        RecordingAvailable = true,
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = "status",
                        Timeline =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            },
                        ],
                        To = new() { Kind = "kind", Value = "value" },
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfCallsList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiResponseOfCallsList
        {
            Data = new()
            {
                Calls =
                [
                    new()
                    {
                        ID = "id",
                        AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Direction = "direction",
                        DurationSeconds = 0,
                        EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FailureReason = "failure_reason",
                        From = new() { Kind = "kind", Value = "value" },
                        Mode = "mode",
                        Number = "number",
                        Price = 0,
                        RecordingAvailable = true,
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = "status",
                        Timeline =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            },
                        ],
                        To = new() { Kind = "kind", Value = "value" },
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfCallsList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiResponseOfCallsListData expectedData = new()
        {
            Calls =
            [
                new()
                {
                    ID = "id",
                    AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Direction = "direction",
                    DurationSeconds = 0,
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failure_reason",
                    From = new() { Kind = "kind", Value = "value" },
                    Mode = "mode",
                    Number = "number",
                    Price = 0,
                    RecordingAvailable = true,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    Timeline =
                    [
                        new()
                        {
                            Status = "status",
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    To = new() { Kind = "kind", Value = "value" },
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
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
        var model = new ApiResponseOfCallsList
        {
            Data = new()
            {
                Calls =
                [
                    new()
                    {
                        ID = "id",
                        AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Direction = "direction",
                        DurationSeconds = 0,
                        EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FailureReason = "failure_reason",
                        From = new() { Kind = "kind", Value = "value" },
                        Mode = "mode",
                        Number = "number",
                        Price = 0,
                        RecordingAvailable = true,
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = "status",
                        Timeline =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            },
                        ],
                        To = new() { Kind = "kind", Value = "value" },
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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
        var model = new ApiResponseOfCallsList
        {
            Data = new()
            {
                Calls =
                [
                    new()
                    {
                        ID = "id",
                        AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Direction = "direction",
                        DurationSeconds = 0,
                        EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FailureReason = "failure_reason",
                        From = new() { Kind = "kind", Value = "value" },
                        Mode = "mode",
                        Number = "number",
                        Price = 0,
                        RecordingAvailable = true,
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = "status",
                        Timeline =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            },
                        ],
                        To = new() { Kind = "kind", Value = "value" },
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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
        var model = new ApiResponseOfCallsList
        {
            Data = new()
            {
                Calls =
                [
                    new()
                    {
                        ID = "id",
                        AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Direction = "direction",
                        DurationSeconds = 0,
                        EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FailureReason = "failure_reason",
                        From = new() { Kind = "kind", Value = "value" },
                        Mode = "mode",
                        Number = "number",
                        Price = 0,
                        RecordingAvailable = true,
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = "status",
                        Timeline =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            },
                        ],
                        To = new() { Kind = "kind", Value = "value" },
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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
        var model = new ApiResponseOfCallsList
        {
            Data = new()
            {
                Calls =
                [
                    new()
                    {
                        ID = "id",
                        AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Direction = "direction",
                        DurationSeconds = 0,
                        EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FailureReason = "failure_reason",
                        From = new() { Kind = "kind", Value = "value" },
                        Mode = "mode",
                        Number = "number",
                        Price = 0,
                        RecordingAvailable = true,
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = "status",
                        Timeline =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            },
                        ],
                        To = new() { Kind = "kind", Value = "value" },
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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
        var model = new ApiResponseOfCallsList
        {
            Data = new()
            {
                Calls =
                [
                    new()
                    {
                        ID = "id",
                        AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Direction = "direction",
                        DurationSeconds = 0,
                        EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FailureReason = "failure_reason",
                        From = new() { Kind = "kind", Value = "value" },
                        Mode = "mode",
                        Number = "number",
                        Price = 0,
                        RecordingAvailable = true,
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = "status",
                        Timeline =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            },
                        ],
                        To = new() { Kind = "kind", Value = "value" },
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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
        var model = new ApiResponseOfCallsList
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
        var model = new ApiResponseOfCallsList
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
        var model = new ApiResponseOfCallsList
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
        var model = new ApiResponseOfCallsList
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
        var model = new ApiResponseOfCallsList
        {
            Data = new()
            {
                Calls =
                [
                    new()
                    {
                        ID = "id",
                        AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Direction = "direction",
                        DurationSeconds = 0,
                        EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FailureReason = "failure_reason",
                        From = new() { Kind = "kind", Value = "value" },
                        Mode = "mode",
                        Number = "number",
                        Price = 0,
                        RecordingAvailable = true,
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = "status",
                        Timeline =
                        [
                            new()
                            {
                                Status = "status",
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            },
                        ],
                        To = new() { Kind = "kind", Value = "value" },
                    },
                ],
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
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

        ApiResponseOfCallsList copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ApiResponseOfCallsListDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiResponseOfCallsListData
        {
            Calls =
            [
                new()
                {
                    ID = "id",
                    AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Direction = "direction",
                    DurationSeconds = 0,
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failure_reason",
                    From = new() { Kind = "kind", Value = "value" },
                    Mode = "mode",
                    Number = "number",
                    Price = 0,
                    RecordingAvailable = true,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    Timeline =
                    [
                        new()
                        {
                            Status = "status",
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    To = new() { Kind = "kind", Value = "value" },
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        List<Call> expectedCalls =
        [
            new()
            {
                ID = "id",
                AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Direction = "direction",
                DurationSeconds = 0,
                EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FailureReason = "failure_reason",
                From = new() { Kind = "kind", Value = "value" },
                Mode = "mode",
                Number = "number",
                Price = 0,
                RecordingAvailable = true,
                StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = "status",
                Timeline =
                [
                    new()
                    {
                        Status = "status",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                To = new() { Kind = "kind", Value = "value" },
            },
        ];
        PaginationMeta expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.NotNull(model.Calls);
        Assert.Equal(expectedCalls.Count, model.Calls.Count);
        for (int i = 0; i < expectedCalls.Count; i++)
        {
            Assert.Equal(expectedCalls[i], model.Calls[i]);
        }
        Assert.Equal(expectedPagination, model.Pagination);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiResponseOfCallsListData
        {
            Calls =
            [
                new()
                {
                    ID = "id",
                    AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Direction = "direction",
                    DurationSeconds = 0,
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failure_reason",
                    From = new() { Kind = "kind", Value = "value" },
                    Mode = "mode",
                    Number = "number",
                    Price = 0,
                    RecordingAvailable = true,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    Timeline =
                    [
                        new()
                        {
                            Status = "status",
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    To = new() { Kind = "kind", Value = "value" },
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfCallsListData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiResponseOfCallsListData
        {
            Calls =
            [
                new()
                {
                    ID = "id",
                    AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Direction = "direction",
                    DurationSeconds = 0,
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failure_reason",
                    From = new() { Kind = "kind", Value = "value" },
                    Mode = "mode",
                    Number = "number",
                    Price = 0,
                    RecordingAvailable = true,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    Timeline =
                    [
                        new()
                        {
                            Status = "status",
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    To = new() { Kind = "kind", Value = "value" },
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfCallsListData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Call> expectedCalls =
        [
            new()
            {
                ID = "id",
                AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Direction = "direction",
                DurationSeconds = 0,
                EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FailureReason = "failure_reason",
                From = new() { Kind = "kind", Value = "value" },
                Mode = "mode",
                Number = "number",
                Price = 0,
                RecordingAvailable = true,
                StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = "status",
                Timeline =
                [
                    new()
                    {
                        Status = "status",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                To = new() { Kind = "kind", Value = "value" },
            },
        ];
        PaginationMeta expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.NotNull(deserialized.Calls);
        Assert.Equal(expectedCalls.Count, deserialized.Calls.Count);
        for (int i = 0; i < expectedCalls.Count; i++)
        {
            Assert.Equal(expectedCalls[i], deserialized.Calls[i]);
        }
        Assert.Equal(expectedPagination, deserialized.Pagination);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiResponseOfCallsListData
        {
            Calls =
            [
                new()
                {
                    ID = "id",
                    AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Direction = "direction",
                    DurationSeconds = 0,
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failure_reason",
                    From = new() { Kind = "kind", Value = "value" },
                    Mode = "mode",
                    Number = "number",
                    Price = 0,
                    RecordingAvailable = true,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    Timeline =
                    [
                        new()
                        {
                            Status = "status",
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    To = new() { Kind = "kind", Value = "value" },
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ApiResponseOfCallsListData { };

        Assert.Null(model.Calls);
        Assert.False(model.RawData.ContainsKey("calls"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ApiResponseOfCallsListData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ApiResponseOfCallsListData
        {
            // Null should be interpreted as omitted for these properties
            Calls = null,
            Pagination = null,
        };

        Assert.Null(model.Calls);
        Assert.False(model.RawData.ContainsKey("calls"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ApiResponseOfCallsListData
        {
            // Null should be interpreted as omitted for these properties
            Calls = null,
            Pagination = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiResponseOfCallsListData
        {
            Calls =
            [
                new()
                {
                    ID = "id",
                    AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Direction = "direction",
                    DurationSeconds = 0,
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failure_reason",
                    From = new() { Kind = "kind", Value = "value" },
                    Mode = "mode",
                    Number = "number",
                    Price = 0,
                    RecordingAvailable = true,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    Timeline =
                    [
                        new()
                        {
                            Status = "status",
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    To = new() { Kind = "kind", Value = "value" },
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        ApiResponseOfCallsListData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Call
        {
            ID = "id",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = "direction",
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            From = new() { Kind = "kind", Value = "value" },
            Mode = "mode",
            Number = "number",
            Price = 0,
            RecordingAvailable = true,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            Timeline =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            To = new() { Kind = "kind", Value = "value" },
        };

        string expectedID = "id";
        DateTimeOffset expectedAnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDirection = "direction";
        int expectedDurationSeconds = 0;
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFailureReason = "failure_reason";
        CallFrom expectedFrom = new() { Kind = "kind", Value = "value" };
        string expectedMode = "mode";
        string expectedNumber = "number";
        double expectedPrice = 0;
        bool expectedRecordingAvailable = true;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        List<CallTimeline> expectedTimeline =
        [
            new()
            {
                Status = "status",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        CallTo expectedTo = new() { Kind = "kind", Value = "value" };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAnsweredAt, model.AnsweredAt);
        Assert.Equal(expectedDirection, model.Direction);
        Assert.Equal(expectedDurationSeconds, model.DurationSeconds);
        Assert.Equal(expectedEndedAt, model.EndedAt);
        Assert.Equal(expectedFailureReason, model.FailureReason);
        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedNumber, model.Number);
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedRecordingAvailable, model.RecordingAvailable);
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.Timeline);
        Assert.Equal(expectedTimeline.Count, model.Timeline.Count);
        for (int i = 0; i < expectedTimeline.Count; i++)
        {
            Assert.Equal(expectedTimeline[i], model.Timeline[i]);
        }
        Assert.Equal(expectedTo, model.To);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Call
        {
            ID = "id",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = "direction",
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            From = new() { Kind = "kind", Value = "value" },
            Mode = "mode",
            Number = "number",
            Price = 0,
            RecordingAvailable = true,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            Timeline =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            To = new() { Kind = "kind", Value = "value" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Call>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Call
        {
            ID = "id",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = "direction",
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            From = new() { Kind = "kind", Value = "value" },
            Mode = "mode",
            Number = "number",
            Price = 0,
            RecordingAvailable = true,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            Timeline =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            To = new() { Kind = "kind", Value = "value" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Call>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedAnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDirection = "direction";
        int expectedDurationSeconds = 0;
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFailureReason = "failure_reason";
        CallFrom expectedFrom = new() { Kind = "kind", Value = "value" };
        string expectedMode = "mode";
        string expectedNumber = "number";
        double expectedPrice = 0;
        bool expectedRecordingAvailable = true;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        List<CallTimeline> expectedTimeline =
        [
            new()
            {
                Status = "status",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        CallTo expectedTo = new() { Kind = "kind", Value = "value" };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAnsweredAt, deserialized.AnsweredAt);
        Assert.Equal(expectedDirection, deserialized.Direction);
        Assert.Equal(expectedDurationSeconds, deserialized.DurationSeconds);
        Assert.Equal(expectedEndedAt, deserialized.EndedAt);
        Assert.Equal(expectedFailureReason, deserialized.FailureReason);
        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedNumber, deserialized.Number);
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedRecordingAvailable, deserialized.RecordingAvailable);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.Timeline);
        Assert.Equal(expectedTimeline.Count, deserialized.Timeline.Count);
        for (int i = 0; i < expectedTimeline.Count; i++)
        {
            Assert.Equal(expectedTimeline[i], deserialized.Timeline[i]);
        }
        Assert.Equal(expectedTo, deserialized.To);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Call
        {
            ID = "id",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = "direction",
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            From = new() { Kind = "kind", Value = "value" },
            Mode = "mode",
            Number = "number",
            Price = 0,
            RecordingAvailable = true,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            Timeline =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            To = new() { Kind = "kind", Value = "value" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Call
        {
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            Price = 0,
            Timeline =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Direction);
        Assert.False(model.RawData.ContainsKey("direction"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
        Assert.Null(model.RecordingAvailable);
        Assert.False(model.RawData.ContainsKey("recording_available"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("started_at"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Call
        {
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            Price = 0,
            Timeline =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Call
        {
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            Price = 0,
            Timeline =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],

            // Null should be interpreted as omitted for these properties
            ID = null,
            Direction = null,
            From = null,
            Mode = null,
            Number = null,
            RecordingAvailable = null,
            StartedAt = null,
            Status = null,
            To = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Direction);
        Assert.False(model.RawData.ContainsKey("direction"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
        Assert.Null(model.RecordingAvailable);
        Assert.False(model.RawData.ContainsKey("recording_available"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("started_at"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Call
        {
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            Price = 0,
            Timeline =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],

            // Null should be interpreted as omitted for these properties
            ID = null,
            Direction = null,
            From = null,
            Mode = null,
            Number = null,
            RecordingAvailable = null,
            StartedAt = null,
            Status = null,
            To = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Call
        {
            ID = "id",
            Direction = "direction",
            From = new() { Kind = "kind", Value = "value" },
            Mode = "mode",
            Number = "number",
            RecordingAvailable = true,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            To = new() { Kind = "kind", Value = "value" },
        };

        Assert.Null(model.AnsweredAt);
        Assert.False(model.RawData.ContainsKey("answered_at"));
        Assert.Null(model.DurationSeconds);
        Assert.False(model.RawData.ContainsKey("duration_seconds"));
        Assert.Null(model.EndedAt);
        Assert.False(model.RawData.ContainsKey("ended_at"));
        Assert.Null(model.FailureReason);
        Assert.False(model.RawData.ContainsKey("failure_reason"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.Timeline);
        Assert.False(model.RawData.ContainsKey("timeline"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Call
        {
            ID = "id",
            Direction = "direction",
            From = new() { Kind = "kind", Value = "value" },
            Mode = "mode",
            Number = "number",
            RecordingAvailable = true,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            To = new() { Kind = "kind", Value = "value" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Call
        {
            ID = "id",
            Direction = "direction",
            From = new() { Kind = "kind", Value = "value" },
            Mode = "mode",
            Number = "number",
            RecordingAvailable = true,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            To = new() { Kind = "kind", Value = "value" },

            AnsweredAt = null,
            DurationSeconds = null,
            EndedAt = null,
            FailureReason = null,
            Price = null,
            Timeline = null,
        };

        Assert.Null(model.AnsweredAt);
        Assert.True(model.RawData.ContainsKey("answered_at"));
        Assert.Null(model.DurationSeconds);
        Assert.True(model.RawData.ContainsKey("duration_seconds"));
        Assert.Null(model.EndedAt);
        Assert.True(model.RawData.ContainsKey("ended_at"));
        Assert.Null(model.FailureReason);
        Assert.True(model.RawData.ContainsKey("failure_reason"));
        Assert.Null(model.Price);
        Assert.True(model.RawData.ContainsKey("price"));
        Assert.Null(model.Timeline);
        Assert.True(model.RawData.ContainsKey("timeline"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Call
        {
            ID = "id",
            Direction = "direction",
            From = new() { Kind = "kind", Value = "value" },
            Mode = "mode",
            Number = "number",
            RecordingAvailable = true,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            To = new() { Kind = "kind", Value = "value" },

            AnsweredAt = null,
            DurationSeconds = null,
            EndedAt = null,
            FailureReason = null,
            Price = null,
            Timeline = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Call
        {
            ID = "id",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = "direction",
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            From = new() { Kind = "kind", Value = "value" },
            Mode = "mode",
            Number = "number",
            Price = 0,
            RecordingAvailable = true,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            Timeline =
            [
                new()
                {
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            To = new() { Kind = "kind", Value = "value" },
        };

        Call copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CallFromTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallFrom { Kind = "kind", Value = "value" };

        string expectedKind = "kind";
        string expectedValue = "value";

        Assert.Equal(expectedKind, model.Kind);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallFrom { Kind = "kind", Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallFrom>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallFrom { Kind = "kind", Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallFrom>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedKind = "kind";
        string expectedValue = "value";

        Assert.Equal(expectedKind, deserialized.Kind);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallFrom { Kind = "kind", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallFrom { Value = "value" };

        Assert.Null(model.Kind);
        Assert.False(model.RawData.ContainsKey("kind"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallFrom { Value = "value" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CallFrom
        {
            Value = "value",

            // Null should be interpreted as omitted for these properties
            Kind = null,
        };

        Assert.Null(model.Kind);
        Assert.False(model.RawData.ContainsKey("kind"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallFrom
        {
            Value = "value",

            // Null should be interpreted as omitted for these properties
            Kind = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallFrom { Kind = "kind" };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallFrom { Kind = "kind" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CallFrom
        {
            Kind = "kind",

            Value = null,
        };

        Assert.Null(model.Value);
        Assert.True(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallFrom
        {
            Kind = "kind",

            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallFrom { Kind = "kind", Value = "value" };

        CallFrom copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CallTimelineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallTimeline
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedStatus = "status";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallTimeline
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallTimeline>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallTimeline
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallTimeline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedStatus = "status";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallTimeline
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallTimeline { };

        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallTimeline { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CallTimeline
        {
            // Null should be interpreted as omitted for these properties
            Status = null,
            Timestamp = null,
        };

        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallTimeline
        {
            // Null should be interpreted as omitted for these properties
            Status = null,
            Timestamp = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallTimeline
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CallTimeline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CallToTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallTo { Kind = "kind", Value = "value" };

        string expectedKind = "kind";
        string expectedValue = "value";

        Assert.Equal(expectedKind, model.Kind);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallTo { Kind = "kind", Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallTo>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallTo { Kind = "kind", Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallTo>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedKind = "kind";
        string expectedValue = "value";

        Assert.Equal(expectedKind, deserialized.Kind);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallTo { Kind = "kind", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallTo { Value = "value" };

        Assert.Null(model.Kind);
        Assert.False(model.RawData.ContainsKey("kind"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallTo { Value = "value" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CallTo
        {
            Value = "value",

            // Null should be interpreted as omitted for these properties
            Kind = null,
        };

        Assert.Null(model.Kind);
        Assert.False(model.RawData.ContainsKey("kind"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallTo
        {
            Value = "value",

            // Null should be interpreted as omitted for these properties
            Kind = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallTo { Kind = "kind" };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallTo { Kind = "kind" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CallTo
        {
            Kind = "kind",

            Value = null,
        };

        Assert.Null(model.Value);
        Assert.True(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallTo
        {
            Kind = "kind",

            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallTo { Kind = "kind", Value = "value" };

        CallTo copied = new(model);

        Assert.Equal(model, copied);
    }
}
