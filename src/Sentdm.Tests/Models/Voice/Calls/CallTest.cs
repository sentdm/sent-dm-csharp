using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Voice.Calls;

namespace Sentdm.Tests.Models.Voice.Calls;

public class CallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Call
        {
            ID = "id",
            AgentID = "agent_id",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallerIDUsed = "caller_id_used",
            ConnectedNumber = "connected_number",
            Direction = "direction",
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            From = new() { Kind = "kind", Value = "value" },
            Legs =
            [
                new()
                {
                    BilledMinutes = 0,
                    Cost = 0,
                    Currency = "currency",
                    Direction = "direction",
                    Number = "number",
                },
            ],
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
        string expectedAgentID = "agent_id";
        DateTimeOffset expectedAnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCallerIDUsed = "caller_id_used";
        string expectedConnectedNumber = "connected_number";
        string expectedDirection = "direction";
        int expectedDurationSeconds = 0;
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFailureReason = "failure_reason";
        CallParty expectedFrom = new() { Kind = "kind", Value = "value" };
        List<Leg> expectedLegs =
        [
            new()
            {
                BilledMinutes = 0,
                Cost = 0,
                Currency = "currency",
                Direction = "direction",
                Number = "number",
            },
        ];
        string expectedMode = "mode";
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
        Assert.Equal(expectedAgentID, model.AgentID);
        Assert.Equal(expectedAnsweredAt, model.AnsweredAt);
        Assert.Equal(expectedCallerIDUsed, model.CallerIDUsed);
        Assert.Equal(expectedConnectedNumber, model.ConnectedNumber);
        Assert.Equal(expectedDirection, model.Direction);
        Assert.Equal(expectedDurationSeconds, model.DurationSeconds);
        Assert.Equal(expectedEndedAt, model.EndedAt);
        Assert.Equal(expectedFailureReason, model.FailureReason);
        Assert.Equal(expectedFrom, model.From);
        Assert.NotNull(model.Legs);
        Assert.Equal(expectedLegs.Count, model.Legs.Count);
        for (int i = 0; i < expectedLegs.Count; i++)
        {
            Assert.Equal(expectedLegs[i], model.Legs[i]);
        }
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
            AgentID = "agent_id",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallerIDUsed = "caller_id_used",
            ConnectedNumber = "connected_number",
            Direction = "direction",
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            From = new() { Kind = "kind", Value = "value" },
            Legs =
            [
                new()
                {
                    BilledMinutes = 0,
                    Cost = 0,
                    Currency = "currency",
                    Direction = "direction",
                    Number = "number",
                },
            ],
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
            AgentID = "agent_id",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallerIDUsed = "caller_id_used",
            ConnectedNumber = "connected_number",
            Direction = "direction",
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            From = new() { Kind = "kind", Value = "value" },
            Legs =
            [
                new()
                {
                    BilledMinutes = 0,
                    Cost = 0,
                    Currency = "currency",
                    Direction = "direction",
                    Number = "number",
                },
            ],
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
        string expectedAgentID = "agent_id";
        DateTimeOffset expectedAnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCallerIDUsed = "caller_id_used";
        string expectedConnectedNumber = "connected_number";
        string expectedDirection = "direction";
        int expectedDurationSeconds = 0;
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFailureReason = "failure_reason";
        CallParty expectedFrom = new() { Kind = "kind", Value = "value" };
        List<Leg> expectedLegs =
        [
            new()
            {
                BilledMinutes = 0,
                Cost = 0,
                Currency = "currency",
                Direction = "direction",
                Number = "number",
            },
        ];
        string expectedMode = "mode";
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
        Assert.Equal(expectedAgentID, deserialized.AgentID);
        Assert.Equal(expectedAnsweredAt, deserialized.AnsweredAt);
        Assert.Equal(expectedCallerIDUsed, deserialized.CallerIDUsed);
        Assert.Equal(expectedConnectedNumber, deserialized.ConnectedNumber);
        Assert.Equal(expectedDirection, deserialized.Direction);
        Assert.Equal(expectedDurationSeconds, deserialized.DurationSeconds);
        Assert.Equal(expectedEndedAt, deserialized.EndedAt);
        Assert.Equal(expectedFailureReason, deserialized.FailureReason);
        Assert.Equal(expectedFrom, deserialized.From);
        Assert.NotNull(deserialized.Legs);
        Assert.Equal(expectedLegs.Count, deserialized.Legs.Count);
        for (int i = 0; i < expectedLegs.Count; i++)
        {
            Assert.Equal(expectedLegs[i], deserialized.Legs[i]);
        }
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
            AgentID = "agent_id",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallerIDUsed = "caller_id_used",
            ConnectedNumber = "connected_number",
            Direction = "direction",
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            From = new() { Kind = "kind", Value = "value" },
            Legs =
            [
                new()
                {
                    BilledMinutes = 0,
                    Cost = 0,
                    Currency = "currency",
                    Direction = "direction",
                    Number = "number",
                },
            ],
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
            AgentID = "agent_id",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallerIDUsed = "caller_id_used",
            ConnectedNumber = "connected_number",
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            Legs =
            [
                new()
                {
                    BilledMinutes = 0,
                    Cost = 0,
                    Currency = "currency",
                    Direction = "direction",
                    Number = "number",
                },
            ],
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
            AgentID = "agent_id",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallerIDUsed = "caller_id_used",
            ConnectedNumber = "connected_number",
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            Legs =
            [
                new()
                {
                    BilledMinutes = 0,
                    Cost = 0,
                    Currency = "currency",
                    Direction = "direction",
                    Number = "number",
                },
            ],
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
            AgentID = "agent_id",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallerIDUsed = "caller_id_used",
            ConnectedNumber = "connected_number",
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            Legs =
            [
                new()
                {
                    BilledMinutes = 0,
                    Cost = 0,
                    Currency = "currency",
                    Direction = "direction",
                    Number = "number",
                },
            ],
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
            AgentID = "agent_id",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallerIDUsed = "caller_id_used",
            ConnectedNumber = "connected_number",
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            Legs =
            [
                new()
                {
                    BilledMinutes = 0,
                    Cost = 0,
                    Currency = "currency",
                    Direction = "direction",
                    Number = "number",
                },
            ],
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

        Assert.Null(model.AgentID);
        Assert.False(model.RawData.ContainsKey("agent_id"));
        Assert.Null(model.AnsweredAt);
        Assert.False(model.RawData.ContainsKey("answered_at"));
        Assert.Null(model.CallerIDUsed);
        Assert.False(model.RawData.ContainsKey("caller_id_used"));
        Assert.Null(model.ConnectedNumber);
        Assert.False(model.RawData.ContainsKey("connected_number"));
        Assert.Null(model.DurationSeconds);
        Assert.False(model.RawData.ContainsKey("duration_seconds"));
        Assert.Null(model.EndedAt);
        Assert.False(model.RawData.ContainsKey("ended_at"));
        Assert.Null(model.FailureReason);
        Assert.False(model.RawData.ContainsKey("failure_reason"));
        Assert.Null(model.Legs);
        Assert.False(model.RawData.ContainsKey("legs"));
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

            AgentID = null,
            AnsweredAt = null,
            CallerIDUsed = null,
            ConnectedNumber = null,
            DurationSeconds = null,
            EndedAt = null,
            FailureReason = null,
            Legs = null,
            Price = null,
            Timeline = null,
        };

        Assert.Null(model.AgentID);
        Assert.True(model.RawData.ContainsKey("agent_id"));
        Assert.Null(model.AnsweredAt);
        Assert.True(model.RawData.ContainsKey("answered_at"));
        Assert.Null(model.CallerIDUsed);
        Assert.True(model.RawData.ContainsKey("caller_id_used"));
        Assert.Null(model.ConnectedNumber);
        Assert.True(model.RawData.ContainsKey("connected_number"));
        Assert.Null(model.DurationSeconds);
        Assert.True(model.RawData.ContainsKey("duration_seconds"));
        Assert.Null(model.EndedAt);
        Assert.True(model.RawData.ContainsKey("ended_at"));
        Assert.Null(model.FailureReason);
        Assert.True(model.RawData.ContainsKey("failure_reason"));
        Assert.Null(model.Legs);
        Assert.True(model.RawData.ContainsKey("legs"));
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

            AgentID = null,
            AnsweredAt = null,
            CallerIDUsed = null,
            ConnectedNumber = null,
            DurationSeconds = null,
            EndedAt = null,
            FailureReason = null,
            Legs = null,
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
            AgentID = "agent_id",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallerIDUsed = "caller_id_used",
            ConnectedNumber = "connected_number",
            Direction = "direction",
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failure_reason",
            From = new() { Kind = "kind", Value = "value" },
            Legs =
            [
                new()
                {
                    BilledMinutes = 0,
                    Cost = 0,
                    Currency = "currency",
                    Direction = "direction",
                    Number = "number",
                },
            ],
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

public class LegTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Leg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",
            Number = "number",
        };

        int expectedBilledMinutes = 0;
        double expectedCost = 0;
        string expectedCurrency = "currency";
        string expectedDirection = "direction";
        string expectedNumber = "number";

        Assert.Equal(expectedBilledMinutes, model.BilledMinutes);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDirection, model.Direction);
        Assert.Equal(expectedNumber, model.Number);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Leg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",
            Number = "number",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Leg>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Leg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",
            Number = "number",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Leg>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        int expectedBilledMinutes = 0;
        double expectedCost = 0;
        string expectedCurrency = "currency";
        string expectedDirection = "direction";
        string expectedNumber = "number";

        Assert.Equal(expectedBilledMinutes, deserialized.BilledMinutes);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDirection, deserialized.Direction);
        Assert.Equal(expectedNumber, deserialized.Number);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Leg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",
            Number = "number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Leg { Number = "number" };

        Assert.Null(model.BilledMinutes);
        Assert.False(model.RawData.ContainsKey("billed_minutes"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Direction);
        Assert.False(model.RawData.ContainsKey("direction"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Leg { Number = "number" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Leg
        {
            Number = "number",

            // Null should be interpreted as omitted for these properties
            BilledMinutes = null,
            Cost = null,
            Currency = null,
            Direction = null,
        };

        Assert.Null(model.BilledMinutes);
        Assert.False(model.RawData.ContainsKey("billed_minutes"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Direction);
        Assert.False(model.RawData.ContainsKey("direction"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Leg
        {
            Number = "number",

            // Null should be interpreted as omitted for these properties
            BilledMinutes = null,
            Cost = null,
            Currency = null,
            Direction = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Leg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",
        };

        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Leg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Leg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",

            Number = null,
        };

        Assert.Null(model.Number);
        Assert.True(model.RawData.ContainsKey("number"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Leg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",

            Number = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Leg
        {
            BilledMinutes = 0,
            Cost = 0,
            Currency = "currency",
            Direction = "direction",
            Number = "number",
        };

        Leg copied = new(model);

        Assert.Equal(model, copied);
    }
}
