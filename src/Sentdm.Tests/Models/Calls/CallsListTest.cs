using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Calls;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Calls;

public class CallsListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallsList
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
        var model = new CallsList
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
        var deserialized = JsonSerializer.Deserialize<CallsList>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallsList
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
        var deserialized = JsonSerializer.Deserialize<CallsList>(
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
        var model = new CallsList
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
        var model = new CallsList { };

        Assert.Null(model.Calls);
        Assert.False(model.RawData.ContainsKey("calls"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallsList { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CallsList
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
        var model = new CallsList
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
        var model = new CallsList
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

        CallsList copied = new(model);

        Assert.Equal(model, copied);
    }
}
