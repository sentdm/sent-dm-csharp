using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Calls.Participants;

namespace Sentdm.Tests.Models.Calls.Participants;

public class CallParticipantTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallParticipant
        {
            ID = "id",
            DurationSeconds = 0,
            Kind = "kind",
            Muted = true,
            Value = "value",
        };

        string expectedID = "id";
        int expectedDurationSeconds = 0;
        string expectedKind = "kind";
        bool expectedMuted = true;
        string expectedValue = "value";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDurationSeconds, model.DurationSeconds);
        Assert.Equal(expectedKind, model.Kind);
        Assert.Equal(expectedMuted, model.Muted);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallParticipant
        {
            ID = "id",
            DurationSeconds = 0,
            Kind = "kind",
            Muted = true,
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallParticipant>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallParticipant
        {
            ID = "id",
            DurationSeconds = 0,
            Kind = "kind",
            Muted = true,
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallParticipant>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        int expectedDurationSeconds = 0;
        string expectedKind = "kind";
        bool expectedMuted = true;
        string expectedValue = "value";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDurationSeconds, deserialized.DurationSeconds);
        Assert.Equal(expectedKind, deserialized.Kind);
        Assert.Equal(expectedMuted, deserialized.Muted);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallParticipant
        {
            ID = "id",
            DurationSeconds = 0,
            Kind = "kind",
            Muted = true,
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallParticipant { Value = "value" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.DurationSeconds);
        Assert.False(model.RawData.ContainsKey("duration_seconds"));
        Assert.Null(model.Kind);
        Assert.False(model.RawData.ContainsKey("kind"));
        Assert.Null(model.Muted);
        Assert.False(model.RawData.ContainsKey("muted"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallParticipant { Value = "value" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CallParticipant
        {
            Value = "value",

            // Null should be interpreted as omitted for these properties
            ID = null,
            DurationSeconds = null,
            Kind = null,
            Muted = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.DurationSeconds);
        Assert.False(model.RawData.ContainsKey("duration_seconds"));
        Assert.Null(model.Kind);
        Assert.False(model.RawData.ContainsKey("kind"));
        Assert.Null(model.Muted);
        Assert.False(model.RawData.ContainsKey("muted"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallParticipant
        {
            Value = "value",

            // Null should be interpreted as omitted for these properties
            ID = null,
            DurationSeconds = null,
            Kind = null,
            Muted = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallParticipant
        {
            ID = "id",
            DurationSeconds = 0,
            Kind = "kind",
            Muted = true,
        };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallParticipant
        {
            ID = "id",
            DurationSeconds = 0,
            Kind = "kind",
            Muted = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CallParticipant
        {
            ID = "id",
            DurationSeconds = 0,
            Kind = "kind",
            Muted = true,

            Value = null,
        };

        Assert.Null(model.Value);
        Assert.True(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallParticipant
        {
            ID = "id",
            DurationSeconds = 0,
            Kind = "kind",
            Muted = true,

            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallParticipant
        {
            ID = "id",
            DurationSeconds = 0,
            Kind = "kind",
            Muted = true,
            Value = "value",
        };

        CallParticipant copied = new(model);

        Assert.Equal(model, copied);
    }
}
