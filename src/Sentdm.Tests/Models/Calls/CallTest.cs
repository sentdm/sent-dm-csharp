using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Calls;

namespace Sentdm.Tests.Models.Calls;

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
        CallParty expectedFrom = new() { Kind = "kind", Value = "value" };
        string expectedNumber = "number";
        double expectedPrice = 0;
        bool expectedRecordingAvailable = true;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        List<CallTimelineEntry> expectedTimeline =
        [
            new()
            {
                Status = "status",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        CallParty expectedTo = new() { Kind = "kind", Value = "value" };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAnsweredAt, model.AnsweredAt);
        Assert.Equal(expectedDirection, model.Direction);
        Assert.Equal(expectedDurationSeconds, model.DurationSeconds);
        Assert.Equal(expectedEndedAt, model.EndedAt);
        Assert.Equal(expectedFailureReason, model.FailureReason);
        Assert.Equal(expectedFrom, model.From);
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
        CallParty expectedFrom = new() { Kind = "kind", Value = "value" };
        string expectedNumber = "number";
        double expectedPrice = 0;
        bool expectedRecordingAvailable = true;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        List<CallTimelineEntry> expectedTimeline =
        [
            new()
            {
                Status = "status",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        CallParty expectedTo = new() { Kind = "kind", Value = "value" };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAnsweredAt, deserialized.AnsweredAt);
        Assert.Equal(expectedDirection, deserialized.Direction);
        Assert.Equal(expectedDurationSeconds, deserialized.DurationSeconds);
        Assert.Equal(expectedEndedAt, deserialized.EndedAt);
        Assert.Equal(expectedFailureReason, deserialized.FailureReason);
        Assert.Equal(expectedFrom, deserialized.From);
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
