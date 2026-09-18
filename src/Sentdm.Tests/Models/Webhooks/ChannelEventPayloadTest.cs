using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class ChannelEventPayloadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChannelEventPayload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
            Status = "status",
            UpdatedAt = "updated_at",
        };

        string expectedCountry = "country";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        string expectedNumberType = "number_type";
        string expectedReason = "reason";
        string expectedSenderValue = "sender_value";
        string expectedStatus = "status";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedNumberType, model.NumberType);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedSenderValue, model.SenderValue);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChannelEventPayload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
            Status = "status",
            UpdatedAt = "updated_at",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChannelEventPayload>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChannelEventPayload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
            Status = "status",
            UpdatedAt = "updated_at",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChannelEventPayload>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCountry = "country";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        string expectedNumberType = "number_type";
        string expectedReason = "reason";
        string expectedSenderValue = "sender_value";
        string expectedStatus = "status";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedNumberType, deserialized.NumberType);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedSenderValue, deserialized.SenderValue);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChannelEventPayload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
            Status = "status",
            UpdatedAt = "updated_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChannelEventPayload
        {
            Country = "country",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChannelEventPayload
        {
            Country = "country",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChannelEventPayload
        {
            Country = "country",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Channel = null,
            Status = null,
            UpdatedAt = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChannelEventPayload
        {
            Country = "country",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Channel = null,
            Status = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChannelEventPayload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Status = "status",
            UpdatedAt = "updated_at",
        };

        Assert.Null(model.NumberType);
        Assert.False(model.RawData.ContainsKey("number_type"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.SenderValue);
        Assert.False(model.RawData.ContainsKey("sender_value"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChannelEventPayload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Status = "status",
            UpdatedAt = "updated_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChannelEventPayload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Status = "status",
            UpdatedAt = "updated_at",

            NumberType = null,
            Reason = null,
            SenderValue = null,
        };

        Assert.Null(model.NumberType);
        Assert.True(model.RawData.ContainsKey("number_type"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.SenderValue);
        Assert.True(model.RawData.ContainsKey("sender_value"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChannelEventPayload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            Status = "status",
            UpdatedAt = "updated_at",

            NumberType = null,
            Reason = null,
            SenderValue = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChannelEventPayload
        {
            Country = "country",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            NumberType = "number_type",
            Reason = "reason",
            SenderValue = "sender_value",
            Status = "status",
            UpdatedAt = "updated_at",
        };

        ChannelEventPayload copied = new(model);

        Assert.Equal(model, copied);
    }
}
