using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Body of an agent.* webhook (Sent Agents). The event is the agent service's own
/// record, forwarded without renaming: EventId is its id, so a subscriber can dedupe
/// a redelivery.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AgentEventPayload, AgentEventPayloadFromRaw>))]
public sealed record class AgentEventPayload : JsonModel
{
    /// <summary>
    /// The agent service's event id. The same event is never delivered under two ids.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_id");
        }
        init { this._rawData.Set("event_id", value); }
    }

    /// <summary>
    /// When the agent service recorded it, UTC, to the millisecond.
    /// </summary>
    public required string OccurredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("occurred_at");
        }
        init { this._rawData.Set("occurred_at", value); }
    }

    /// <summary>
    /// The sender profile the agent runs on.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_id", value);
        }
    }

    /// <summary>
    /// Who caused it: system, the agent service's customer, or an approver.
    /// </summary>
    public string? Actor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("actor");
        }
        init { this._rawData.Set("actor", value); }
    }

    /// <summary>
    /// The agent.
    /// </summary>
    public string? AgentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("agent_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("agent_id", value);
        }
    }

    /// <summary>
    /// The agent's name, as it is listed. Absent for an agent services no longer holds.
    /// </summary>
    public string? AgentName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("agent_name");
        }
        init { this._rawData.Set("agent_name", value); }
    }

    /// <summary>
    /// The version of the agent the event is of: the one its conversation runs,
    /// or the active one for an event of the agent itself. Absent when the agent
    /// service does not say it.
    /// </summary>
    public int? AgentVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("agent_version");
        }
        init { this._rawData.Set("agent_version", value); }
    }

    /// <summary>
    /// The contact of that conversation; absent on agent-level events.
    /// </summary>
    public string? ContactID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contact_id");
        }
        init { this._rawData.Set("contact_id", value); }
    }

    /// <summary>
    /// The contact's phone number, in E.164, so a receiver knows who the event is
    /// about without asking for the contact. Read from the account's contacts as
    /// the webhook is built: the agent service's own record names a contact by id
    /// only. Absent on agent-level events, and for a contact the account no longer holds.
    /// </summary>
    public string? ContactPhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contact_phone_number");
        }
        init { this._rawData.Set("contact_phone_number", value); }
    }

    /// <summary>
    /// The event's own fields (outcome, reason, ...), exactly as the agent service
    /// recorded them.
    /// </summary>
    public JsonElement? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <summary>
    /// The conversation (agent × contact) the event belongs to; absent on agent-level events.
    /// </summary>
    public string? InstanceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instance_id");
        }
        init { this._rawData.Set("instance_id", value); }
    }

    /// <summary>
    /// Where the event stands among the agent's events: a number that grows with
    /// each, so two events of the same second are put in order by it. Not a count:
    /// there are gaps between an agent's own. Absent from an agent service that does
    /// not say it.
    /// </summary>
    public long? Sequence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sequence");
        }
        init { this._rawData.Set("sequence", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EventID;
        _ = this.OccurredAt;
        _ = this.AccountID;
        _ = this.Actor;
        _ = this.AgentID;
        _ = this.AgentName;
        _ = this.AgentVersion;
        _ = this.ContactID;
        _ = this.ContactPhoneNumber;
        _ = this.Data;
        _ = this.InstanceID;
        _ = this.Sequence;
    }

    public AgentEventPayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentEventPayload(AgentEventPayload agentEventPayload)
        : base(agentEventPayload) { }
#pragma warning restore CS8618

    public AgentEventPayload(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentEventPayload(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentEventPayloadFromRaw.FromRawUnchecked"/>
    public static AgentEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentEventPayloadFromRaw : IFromRawJson<AgentEventPayload>
{
    /// <inheritdoc/>
    public AgentEventPayload FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentEventPayload.FromRawUnchecked(rawData);
}
