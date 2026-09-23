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
            AgentID = "agent_id",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            From = "from",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Text = "text",
            To = "to",
        };

        bool expectedOptOut = true;
        string expectedSource = "source";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAgentID = "agent_id";
        string expectedChannel = "channel";
        string expectedContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFrom = "from";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedText = "text";
        string expectedTo = "to";

        Assert.Equal(expectedOptOut, model.OptOut);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAgentID, model.AgentID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedContactID, model.ContactID);
        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTo, model.To);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AgentID = "agent_id",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            From = "from",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Text = "text",
            To = "to",
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
            AgentID = "agent_id",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            From = "from",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Text = "text",
            To = "to",
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
        string expectedAgentID = "agent_id";
        string expectedChannel = "channel";
        string expectedContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFrom = "from";
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedText = "text";
        string expectedTo = "to";

        Assert.Equal(expectedOptOut, deserialized.OptOut);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAgentID, deserialized.AgentID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedContactID, deserialized.ContactID);
        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedTo, deserialized.To);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AgentID = "agent_id",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            From = "from",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Text = "text",
            To = "to",
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
            AgentID = "agent_id",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Text = "text",
            To = "to",
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contact_id"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            AgentID = "agent_id",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Text = "text",
            To = "to",
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
            AgentID = "agent_id",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Text = "text",
            To = "to",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Channel = null,
            ContactID = null,
            From = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contact_id"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContactEventPayload
        {
            OptOut = true,
            Source = "source",
            AgentID = "agent_id",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Text = "text",
            To = "to",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Channel = null,
            ContactID = null,
            From = null,
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
            From = "from",
        };

        Assert.Null(model.AgentID);
        Assert.False(model.RawData.ContainsKey("agent_id"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("template_id"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
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
            From = "from",
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
            From = "from",

            AgentID = null,
            MessageID = null,
            TemplateID = null,
            Text = null,
            To = null,
        };

        Assert.Null(model.AgentID);
        Assert.True(model.RawData.ContainsKey("agent_id"));
        Assert.Null(model.MessageID);
        Assert.True(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.TemplateID);
        Assert.True(model.RawData.ContainsKey("template_id"));
        Assert.Null(model.Text);
        Assert.True(model.RawData.ContainsKey("text"));
        Assert.Null(model.To);
        Assert.True(model.RawData.ContainsKey("to"));
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
            From = "from",

            AgentID = null,
            MessageID = null,
            TemplateID = null,
            Text = null,
            To = null,
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
            AgentID = "agent_id",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            From = "from",
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Text = "text",
            To = "to",
        };

        ContactEventPayload copied = new(model);

        Assert.Equal(model, copied);
    }
}
