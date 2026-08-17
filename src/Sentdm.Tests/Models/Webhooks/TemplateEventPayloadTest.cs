using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class TemplateEventPayloadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channel = "channel",
            Language = "language",
            Reason = "reason",
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
            WhatsappTemplateID = "whatsapp_template_id",
        };

        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCategory = "category";
        string expectedChannel = "channel";
        string expectedLanguage = "language";
        string expectedReason = "reason";
        string expectedStatus = "status";
        string expectedTemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTemplateName = "template_name";
        string expectedWhatsappTemplateID = "whatsapp_template_id";

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.Equal(expectedTemplateName, model.TemplateName);
        Assert.Equal(expectedWhatsappTemplateID, model.WhatsappTemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channel = "channel",
            Language = "language",
            Reason = "reason",
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
            WhatsappTemplateID = "whatsapp_template_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateEventPayload>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channel = "channel",
            Language = "language",
            Reason = "reason",
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
            WhatsappTemplateID = "whatsapp_template_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateEventPayload>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCategory = "category";
        string expectedChannel = "channel";
        string expectedLanguage = "language";
        string expectedReason = "reason";
        string expectedStatus = "status";
        string expectedTemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTemplateName = "template_name";
        string expectedWhatsappTemplateID = "whatsapp_template_id";

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.Equal(expectedTemplateName, deserialized.TemplateName);
        Assert.Equal(expectedWhatsappTemplateID, deserialized.WhatsappTemplateID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channel = "channel",
            Language = "language",
            Reason = "reason",
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
            WhatsappTemplateID = "whatsapp_template_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateEventPayload { Reason = "reason" };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("template_id"));
        Assert.Null(model.TemplateName);
        Assert.False(model.RawData.ContainsKey("template_name"));
        Assert.Null(model.WhatsappTemplateID);
        Assert.False(model.RawData.ContainsKey("whatsapp_template_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateEventPayload { Reason = "reason" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplateEventPayload
        {
            Reason = "reason",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Category = null,
            Channel = null,
            Language = null,
            Status = null,
            TemplateID = null,
            TemplateName = null,
            WhatsappTemplateID = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("template_id"));
        Assert.Null(model.TemplateName);
        Assert.False(model.RawData.ContainsKey("template_name"));
        Assert.Null(model.WhatsappTemplateID);
        Assert.False(model.RawData.ContainsKey("whatsapp_template_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateEventPayload
        {
            Reason = "reason",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Category = null,
            Channel = null,
            Language = null,
            Status = null,
            TemplateID = null,
            TemplateName = null,
            WhatsappTemplateID = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channel = "channel",
            Language = "language",
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
            WhatsappTemplateID = "whatsapp_template_id",
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channel = "channel",
            Language = "language",
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
            WhatsappTemplateID = "whatsapp_template_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channel = "channel",
            Language = "language",
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
            WhatsappTemplateID = "whatsapp_template_id",

            Reason = null,
        };

        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channel = "channel",
            Language = "language",
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
            WhatsappTemplateID = "whatsapp_template_id",

            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateEventPayload
        {
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channel = "channel",
            Language = "language",
            Reason = "reason",
            Status = "status",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "template_name",
            WhatsappTemplateID = "whatsapp_template_id",
        };

        TemplateEventPayload copied = new(model);

        Assert.Equal(model, copied);
    }
}
