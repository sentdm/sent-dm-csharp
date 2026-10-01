using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class CallEventPayloadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallEventPayload
        {
            CallID = "call_id",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            DurationSeconds = 0,
            Number = "number",
            Price = 0,
            Reason = "reason",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = "updated_at",
        };

        string expectedCallID = "call_id";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        int expectedDurationSeconds = 0;
        string expectedNumber = "number";
        double expectedPrice = 0;
        string expectedReason = "reason";
        string expectedRecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedDurationSeconds, model.DurationSeconds);
        Assert.Equal(expectedNumber, model.Number);
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedRecordingID, model.RecordingID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallEventPayload
        {
            CallID = "call_id",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            DurationSeconds = 0,
            Number = "number",
            Price = 0,
            Reason = "reason",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = "updated_at",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallEventPayload>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallEventPayload
        {
            CallID = "call_id",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            DurationSeconds = 0,
            Number = "number",
            Price = 0,
            Reason = "reason",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = "updated_at",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallEventPayload>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallID = "call_id";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        int expectedDurationSeconds = 0;
        string expectedNumber = "number";
        double expectedPrice = 0;
        string expectedReason = "reason";
        string expectedRecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedDurationSeconds, deserialized.DurationSeconds);
        Assert.Equal(expectedNumber, deserialized.Number);
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedRecordingID, deserialized.RecordingID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallEventPayload
        {
            CallID = "call_id",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            DurationSeconds = 0,
            Number = "number",
            Price = 0,
            Reason = "reason",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = "updated_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallEventPayload
        {
            CallID = "call_id",
            DurationSeconds = 0,
            Price = 0,
            Reason = "reason",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallEventPayload
        {
            CallID = "call_id",
            DurationSeconds = 0,
            Price = 0,
            Reason = "reason",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CallEventPayload
        {
            CallID = "call_id",
            DurationSeconds = 0,
            Price = 0,
            Reason = "reason",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Channel = null,
            Number = null,
            UpdatedAt = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallEventPayload
        {
            CallID = "call_id",
            DurationSeconds = 0,
            Price = 0,
            Reason = "reason",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Channel = null,
            Number = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallEventPayload
        {
            CallID = "call_id",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Number = "number",
            UpdatedAt = "updated_at",
        };

        Assert.Null(model.DurationSeconds);
        Assert.False(model.RawData.ContainsKey("duration_seconds"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.RecordingID);
        Assert.False(model.RawData.ContainsKey("recording_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallEventPayload
        {
            CallID = "call_id",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Number = "number",
            UpdatedAt = "updated_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CallEventPayload
        {
            CallID = "call_id",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Number = "number",
            UpdatedAt = "updated_at",

            DurationSeconds = null,
            Price = null,
            Reason = null,
            RecordingID = null,
        };

        Assert.Null(model.DurationSeconds);
        Assert.True(model.RawData.ContainsKey("duration_seconds"));
        Assert.Null(model.Price);
        Assert.True(model.RawData.ContainsKey("price"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.RecordingID);
        Assert.True(model.RawData.ContainsKey("recording_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallEventPayload
        {
            CallID = "call_id",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Number = "number",
            UpdatedAt = "updated_at",

            DurationSeconds = null,
            Price = null,
            Reason = null,
            RecordingID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallEventPayload
        {
            CallID = "call_id",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            DurationSeconds = 0,
            Number = "number",
            Price = 0,
            Reason = "reason",
            RecordingID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = "updated_at",
        };

        CallEventPayload copied = new(model);

        Assert.Equal(model, copied);
    }
}
