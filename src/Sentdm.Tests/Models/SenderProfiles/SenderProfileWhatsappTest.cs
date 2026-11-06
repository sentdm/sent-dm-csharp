using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.SenderProfiles;

namespace Sentdm.Tests.Models.SenderProfiles;

public class SenderProfileWhatsappTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SenderProfileWhatsapp
        {
            PhoneNumberID = "phone_number_id",
            WabaID = "waba_id",
        };

        string expectedPhoneNumberID = "phone_number_id";
        string expectedWabaID = "waba_id";

        Assert.Equal(expectedPhoneNumberID, model.PhoneNumberID);
        Assert.Equal(expectedWabaID, model.WabaID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SenderProfileWhatsapp
        {
            PhoneNumberID = "phone_number_id",
            WabaID = "waba_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfileWhatsapp>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SenderProfileWhatsapp
        {
            PhoneNumberID = "phone_number_id",
            WabaID = "waba_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderProfileWhatsapp>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPhoneNumberID = "phone_number_id";
        string expectedWabaID = "waba_id";

        Assert.Equal(expectedPhoneNumberID, deserialized.PhoneNumberID);
        Assert.Equal(expectedWabaID, deserialized.WabaID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SenderProfileWhatsapp
        {
            PhoneNumberID = "phone_number_id",
            WabaID = "waba_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SenderProfileWhatsapp { };

        Assert.Null(model.PhoneNumberID);
        Assert.False(model.RawData.ContainsKey("phone_number_id"));
        Assert.Null(model.WabaID);
        Assert.False(model.RawData.ContainsKey("waba_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SenderProfileWhatsapp { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SenderProfileWhatsapp { PhoneNumberID = null, WabaID = null };

        Assert.Null(model.PhoneNumberID);
        Assert.True(model.RawData.ContainsKey("phone_number_id"));
        Assert.Null(model.WabaID);
        Assert.True(model.RawData.ContainsKey("waba_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SenderProfileWhatsapp { PhoneNumberID = null, WabaID = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SenderProfileWhatsapp
        {
            PhoneNumberID = "phone_number_id",
            WabaID = "waba_id",
        };

        SenderProfileWhatsapp copied = new(model);

        Assert.Equal(model, copied);
    }
}
