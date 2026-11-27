using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class AgentEventPayloadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentEventPayload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Actor = "actor",
            AgentID = "agent_id",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            InstanceID = "instance_id",
            Sequence = 0,
        };

        string expectedEventID = "event_id";
        string expectedOccurredAt = "occurred_at";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedActor = "actor";
        string expectedAgentID = "agent_id";
        string expectedAgentName = "agent_name";
        int expectedAgentVersion = 0;
        string expectedContactID = "contact_id";
        string expectedContactPhoneNumber = "contact_phone_number";
        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedInstanceID = "instance_id";
        long expectedSequence = 0;

        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedOccurredAt, model.OccurredAt);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedActor, model.Actor);
        Assert.Equal(expectedAgentID, model.AgentID);
        Assert.Equal(expectedAgentName, model.AgentName);
        Assert.Equal(expectedAgentVersion, model.AgentVersion);
        Assert.Equal(expectedContactID, model.ContactID);
        Assert.Equal(expectedContactPhoneNumber, model.ContactPhoneNumber);
        Assert.NotNull(model.Data);
        Assert.True(JsonElement.DeepEquals(expectedData, model.Data.Value));
        Assert.Equal(expectedInstanceID, model.InstanceID);
        Assert.Equal(expectedSequence, model.Sequence);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentEventPayload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Actor = "actor",
            AgentID = "agent_id",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            InstanceID = "instance_id",
            Sequence = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentEventPayload>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentEventPayload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Actor = "actor",
            AgentID = "agent_id",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            InstanceID = "instance_id",
            Sequence = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentEventPayload>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEventID = "event_id";
        string expectedOccurredAt = "occurred_at";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedActor = "actor";
        string expectedAgentID = "agent_id";
        string expectedAgentName = "agent_name";
        int expectedAgentVersion = 0;
        string expectedContactID = "contact_id";
        string expectedContactPhoneNumber = "contact_phone_number";
        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedInstanceID = "instance_id";
        long expectedSequence = 0;

        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedOccurredAt, deserialized.OccurredAt);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedActor, deserialized.Actor);
        Assert.Equal(expectedAgentID, deserialized.AgentID);
        Assert.Equal(expectedAgentName, deserialized.AgentName);
        Assert.Equal(expectedAgentVersion, deserialized.AgentVersion);
        Assert.Equal(expectedContactID, deserialized.ContactID);
        Assert.Equal(expectedContactPhoneNumber, deserialized.ContactPhoneNumber);
        Assert.NotNull(deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedData, deserialized.Data.Value));
        Assert.Equal(expectedInstanceID, deserialized.InstanceID);
        Assert.Equal(expectedSequence, deserialized.Sequence);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentEventPayload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Actor = "actor",
            AgentID = "agent_id",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            InstanceID = "instance_id",
            Sequence = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentEventPayload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            Actor = "actor",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            InstanceID = "instance_id",
            Sequence = 0,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.AgentID);
        Assert.False(model.RawData.ContainsKey("agent_id"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentEventPayload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            Actor = "actor",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            InstanceID = "instance_id",
            Sequence = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentEventPayload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            Actor = "actor",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            InstanceID = "instance_id",
            Sequence = 0,

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            AgentID = null,
            Data = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.AgentID);
        Assert.False(model.RawData.ContainsKey("agent_id"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentEventPayload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            Actor = "actor",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            InstanceID = "instance_id",
            Sequence = 0,

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            AgentID = null,
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentEventPayload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AgentID = "agent_id",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.Actor);
        Assert.False(model.RawData.ContainsKey("actor"));
        Assert.Null(model.AgentName);
        Assert.False(model.RawData.ContainsKey("agent_name"));
        Assert.Null(model.AgentVersion);
        Assert.False(model.RawData.ContainsKey("agent_version"));
        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contact_id"));
        Assert.Null(model.ContactPhoneNumber);
        Assert.False(model.RawData.ContainsKey("contact_phone_number"));
        Assert.Null(model.InstanceID);
        Assert.False(model.RawData.ContainsKey("instance_id"));
        Assert.Null(model.Sequence);
        Assert.False(model.RawData.ContainsKey("sequence"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentEventPayload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AgentID = "agent_id",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AgentEventPayload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AgentID = "agent_id",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),

            Actor = null,
            AgentName = null,
            AgentVersion = null,
            ContactID = null,
            ContactPhoneNumber = null,
            InstanceID = null,
            Sequence = null,
        };

        Assert.Null(model.Actor);
        Assert.True(model.RawData.ContainsKey("actor"));
        Assert.Null(model.AgentName);
        Assert.True(model.RawData.ContainsKey("agent_name"));
        Assert.Null(model.AgentVersion);
        Assert.True(model.RawData.ContainsKey("agent_version"));
        Assert.Null(model.ContactID);
        Assert.True(model.RawData.ContainsKey("contact_id"));
        Assert.Null(model.ContactPhoneNumber);
        Assert.True(model.RawData.ContainsKey("contact_phone_number"));
        Assert.Null(model.InstanceID);
        Assert.True(model.RawData.ContainsKey("instance_id"));
        Assert.Null(model.Sequence);
        Assert.True(model.RawData.ContainsKey("sequence"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentEventPayload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AgentID = "agent_id",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),

            Actor = null,
            AgentName = null,
            AgentVersion = null,
            ContactID = null,
            ContactPhoneNumber = null,
            InstanceID = null,
            Sequence = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentEventPayload
        {
            EventID = "event_id",
            OccurredAt = "occurred_at",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Actor = "actor",
            AgentID = "agent_id",
            AgentName = "agent_name",
            AgentVersion = 0,
            ContactID = "contact_id",
            ContactPhoneNumber = "contact_phone_number",
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            InstanceID = "instance_id",
            Sequence = 0,
        };

        AgentEventPayload copied = new(model);

        Assert.Equal(model, copied);
    }
}
