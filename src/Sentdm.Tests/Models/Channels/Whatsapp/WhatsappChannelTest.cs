using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Channels.Whatsapp;

namespace Sentdm.Tests.Models.Channels.Whatsapp;

public class WhatsappChannelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WhatsappChannel
        {
            OwnerBusinessID = "owner_business_id",
            PhoneNumberID = "phone_number_id",
            Reason = "reason",
            ReasonCode = "reason_code",
            SolutionID = "solution_id",
            Status = Status.Provisioning,
            WabaID = "waba_id",
        };

        string expectedOwnerBusinessID = "owner_business_id";
        string expectedPhoneNumberID = "phone_number_id";
        string expectedReason = "reason";
        string expectedReasonCode = "reason_code";
        string expectedSolutionID = "solution_id";
        ApiEnum<string, Status> expectedStatus = Status.Provisioning;
        string expectedWabaID = "waba_id";

        Assert.Equal(expectedOwnerBusinessID, model.OwnerBusinessID);
        Assert.Equal(expectedPhoneNumberID, model.PhoneNumberID);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReasonCode, model.ReasonCode);
        Assert.Equal(expectedSolutionID, model.SolutionID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedWabaID, model.WabaID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WhatsappChannel
        {
            OwnerBusinessID = "owner_business_id",
            PhoneNumberID = "phone_number_id",
            Reason = "reason",
            ReasonCode = "reason_code",
            SolutionID = "solution_id",
            Status = Status.Provisioning,
            WabaID = "waba_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsappChannel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WhatsappChannel
        {
            OwnerBusinessID = "owner_business_id",
            PhoneNumberID = "phone_number_id",
            Reason = "reason",
            ReasonCode = "reason_code",
            SolutionID = "solution_id",
            Status = Status.Provisioning,
            WabaID = "waba_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsappChannel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedOwnerBusinessID = "owner_business_id";
        string expectedPhoneNumberID = "phone_number_id";
        string expectedReason = "reason";
        string expectedReasonCode = "reason_code";
        string expectedSolutionID = "solution_id";
        ApiEnum<string, Status> expectedStatus = Status.Provisioning;
        string expectedWabaID = "waba_id";

        Assert.Equal(expectedOwnerBusinessID, deserialized.OwnerBusinessID);
        Assert.Equal(expectedPhoneNumberID, deserialized.PhoneNumberID);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReasonCode, deserialized.ReasonCode);
        Assert.Equal(expectedSolutionID, deserialized.SolutionID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedWabaID, deserialized.WabaID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WhatsappChannel
        {
            OwnerBusinessID = "owner_business_id",
            PhoneNumberID = "phone_number_id",
            Reason = "reason",
            ReasonCode = "reason_code",
            SolutionID = "solution_id",
            Status = Status.Provisioning,
            WabaID = "waba_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WhatsappChannel { };

        Assert.Null(model.OwnerBusinessID);
        Assert.False(model.RawData.ContainsKey("owner_business_id"));
        Assert.Null(model.PhoneNumberID);
        Assert.False(model.RawData.ContainsKey("phone_number_id"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.ReasonCode);
        Assert.False(model.RawData.ContainsKey("reason_code"));
        Assert.Null(model.SolutionID);
        Assert.False(model.RawData.ContainsKey("solution_id"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.WabaID);
        Assert.False(model.RawData.ContainsKey("waba_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WhatsappChannel { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WhatsappChannel
        {
            OwnerBusinessID = null,
            PhoneNumberID = null,
            Reason = null,
            ReasonCode = null,
            SolutionID = null,
            Status = null,
            WabaID = null,
        };

        Assert.Null(model.OwnerBusinessID);
        Assert.True(model.RawData.ContainsKey("owner_business_id"));
        Assert.Null(model.PhoneNumberID);
        Assert.True(model.RawData.ContainsKey("phone_number_id"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.ReasonCode);
        Assert.True(model.RawData.ContainsKey("reason_code"));
        Assert.Null(model.SolutionID);
        Assert.True(model.RawData.ContainsKey("solution_id"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.WabaID);
        Assert.True(model.RawData.ContainsKey("waba_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WhatsappChannel
        {
            OwnerBusinessID = null,
            PhoneNumberID = null,
            Reason = null,
            ReasonCode = null,
            SolutionID = null,
            Status = null,
            WabaID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WhatsappChannel
        {
            OwnerBusinessID = "owner_business_id",
            PhoneNumberID = "phone_number_id",
            Reason = "reason",
            ReasonCode = "reason_code",
            SolutionID = "solution_id",
            Status = Status.Provisioning,
            WabaID = "waba_id",
        };

        WhatsappChannel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Provisioning)]
    [InlineData(Status.ActionNeeded)]
    [InlineData(Status.PendingReview)]
    [InlineData(Status.Active)]
    [InlineData(Status.Inactive)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Provisioning)]
    [InlineData(Status.ActionNeeded)]
    [InlineData(Status.PendingReview)]
    [InlineData(Status.Active)]
    [InlineData(Status.Inactive)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
