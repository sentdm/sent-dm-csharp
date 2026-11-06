using System;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Messages;

namespace Sentdm.Tests.Models.Messages;

public class MessageActivityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageActivity
        {
            ActiveContactPrice = "active_contact_price",
            Description = "description",
            From = "from",
            Price = "price",
            Reason = "reason",
            ReasonCode = "reason_code",
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedActiveContactPrice = "active_contact_price";
        string expectedDescription = "description";
        string expectedFrom = "from";
        string expectedPrice = "price";
        string expectedReason = "reason";
        string expectedReasonCode = "reason_code";
        DateTimeOffset expectedScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedActiveContactPrice, model.ActiveContactPrice);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReasonCode, model.ReasonCode);
        Assert.Equal(expectedScheduledAt, model.ScheduledAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageActivity
        {
            ActiveContactPrice = "active_contact_price",
            Description = "description",
            From = "from",
            Price = "price",
            Reason = "reason",
            ReasonCode = "reason_code",
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageActivity>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageActivity
        {
            ActiveContactPrice = "active_contact_price",
            Description = "description",
            From = "from",
            Price = "price",
            Reason = "reason",
            ReasonCode = "reason_code",
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageActivity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedActiveContactPrice = "active_contact_price";
        string expectedDescription = "description";
        string expectedFrom = "from";
        string expectedPrice = "price";
        string expectedReason = "reason";
        string expectedReasonCode = "reason_code";
        DateTimeOffset expectedScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedActiveContactPrice, deserialized.ActiveContactPrice);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReasonCode, deserialized.ReasonCode);
        Assert.Equal(expectedScheduledAt, deserialized.ScheduledAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageActivity
        {
            ActiveContactPrice = "active_contact_price",
            Description = "description",
            From = "from",
            Price = "price",
            Reason = "reason",
            ReasonCode = "reason_code",
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageActivity
        {
            ActiveContactPrice = "active_contact_price",
            From = "from",
            Price = "price",
            Reason = "reason",
            ReasonCode = "reason_code",
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageActivity
        {
            ActiveContactPrice = "active_contact_price",
            From = "from",
            Price = "price",
            Reason = "reason",
            ReasonCode = "reason_code",
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageActivity
        {
            ActiveContactPrice = "active_contact_price",
            From = "from",
            Price = "price",
            Reason = "reason",
            ReasonCode = "reason_code",
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Description = null,
            Status = null,
            Timestamp = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageActivity
        {
            ActiveContactPrice = "active_contact_price",
            From = "from",
            Price = "price",
            Reason = "reason",
            ReasonCode = "reason_code",
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Description = null,
            Status = null,
            Timestamp = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageActivity
        {
            Description = "description",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ActiveContactPrice);
        Assert.False(model.RawData.ContainsKey("active_contact_price"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.ReasonCode);
        Assert.False(model.RawData.ContainsKey("reason_code"));
        Assert.Null(model.ScheduledAt);
        Assert.False(model.RawData.ContainsKey("scheduled_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageActivity
        {
            Description = "description",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MessageActivity
        {
            Description = "description",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ActiveContactPrice = null,
            From = null,
            Price = null,
            Reason = null,
            ReasonCode = null,
            ScheduledAt = null,
        };

        Assert.Null(model.ActiveContactPrice);
        Assert.True(model.RawData.ContainsKey("active_contact_price"));
        Assert.Null(model.From);
        Assert.True(model.RawData.ContainsKey("from"));
        Assert.Null(model.Price);
        Assert.True(model.RawData.ContainsKey("price"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.ReasonCode);
        Assert.True(model.RawData.ContainsKey("reason_code"));
        Assert.Null(model.ScheduledAt);
        Assert.True(model.RawData.ContainsKey("scheduled_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageActivity
        {
            Description = "description",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ActiveContactPrice = null,
            From = null,
            Price = null,
            Reason = null,
            ReasonCode = null,
            ScheduledAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageActivity
        {
            ActiveContactPrice = "active_contact_price",
            Description = "description",
            From = "from",
            Price = "price",
            Reason = "reason",
            ReasonCode = "reason_code",
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        MessageActivity copied = new(model);

        Assert.Equal(model, copied);
    }
}
