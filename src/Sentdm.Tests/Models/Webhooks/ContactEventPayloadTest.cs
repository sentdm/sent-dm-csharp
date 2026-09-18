using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class ContactEventPayloadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PhoneNumber = "phone_number",
            Text = "text",
        };

        bool expectedOptOut = true;
        string expectedSource = "source";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        string expectedContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPhoneNumber = "phone_number";
        string expectedText = "text";

        Assert.Equal(expectedOptOut, model.OptOut);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedContactID, model.ContactID);
        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PhoneNumber = "phone_number",
            Text = "text",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactEventPayload>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PhoneNumber = "phone_number",
            Text = "text",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactEventPayload>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedOptOut = true;
        string expectedSource = "source";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        string expectedContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPhoneNumber = "phone_number";
        string expectedText = "text";

        Assert.Equal(expectedOptOut, deserialized.OptOut);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedContactID, deserialized.ContactID);
        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PhoneNumber = "phone_number",
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Text = "text",
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contact_id"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Channel = null,
            ContactID = null,
            PhoneNumber = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contact_id"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Channel = null,
            ContactID = null,
            PhoneNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PhoneNumber = "phone_number",
        };

        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PhoneNumber = "phone_number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PhoneNumber = "phone_number",

            MessageID = null,
            Text = null,
        };

        Assert.Null(model.MessageID);
        Assert.True(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.Text);
        Assert.True(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PhoneNumber = "phone_number",

            MessageID = null,
            Text = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PhoneNumber = "phone_number",
            Text = "text",
        };

        ContactEventPayload copied = new(model);

        Assert.Equal(model, copied);
    }
}
