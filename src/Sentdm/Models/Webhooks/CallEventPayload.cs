using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Body of a call.initiated, call.answered, call.completed, call.failed or call.recording_ready
/// event. Which of them occurred is the envelope's event.              Shaped like
/// the message, inbound, template and channel payloads: account_id names the account
/// the event is about, channel names the channel, and updated_at is when the change
/// happened on the call, in the same yyyy-MM-ddTHH:mm:ssZ form. duration_seconds
/// and price are added on call.completed, reason on call.failed and recording_id
/// on call.recording_ready; each is omitted rather than sent as null when it does
/// not apply.              Casing is snake_case because these ride the same webhook
/// stream customers already parse message_id from; the question/answer contract is
/// a separate surface and stays camelCase. Nothing here is provider-shaped: no provider
/// call id, no namespaced identity.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallEventPayload, CallEventPayloadFromRaw>))]
public sealed record class CallEventPayload : JsonModel
{
    /// <summary>
    /// Sent's call id, the same one the customer saw on the first question.
    /// </summary>
    public required string CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("call_id");
        }
        init { this._rawData.Set("call_id", value); }
    }

    /// <summary>
    /// The account the call belongs to: the key's own customer, or the sender profile
    /// it acted as.
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
    /// Always voice.
    /// </summary>
    public string? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channel", value);
        }
    }

    /// <summary>
    /// How long the call lasted. Only on call.completed.
    /// </summary>
    public int? DurationSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("duration_seconds");
        }
        init { this._rawData.Set("duration_seconds", value); }
    }

    /// <summary>
    /// The customer number that owns the call, in E.164 format.
    /// </summary>
    public string? Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("number", value);
        }
    }

    /// <summary>
    /// What the call was charged. Only on call.completed, and omitted there until
    /// billing has recorded the charge.
    /// </summary>
    public double? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// The machine-readable reason the call did not complete. Only on call.failed,
    /// and omitted when no reason was recorded.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The recording that became available, the same id GET /v3/calls/{id}/recordings
    /// lists it under. Only on call.recording_ready, which is sent once per recording.
    /// </summary>
    public string? RecordingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recording_id");
        }
        init { this._rawData.Set("recording_id", value); }
    }

    /// <summary>
    /// When the change happened on the call, as opposed to when the event was emitted.
    /// </summary>
    public string? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallID;
        _ = this.AccountID;
        _ = this.Channel;
        _ = this.DurationSeconds;
        _ = this.Number;
        _ = this.Price;
        _ = this.Reason;
        _ = this.RecordingID;
        _ = this.UpdatedAt;
    }

    public CallEventPayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallEventPayload(CallEventPayload callEventPayload)
        : base(callEventPayload) { }
#pragma warning restore CS8618

    public CallEventPayload(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallEventPayload(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallEventPayloadFromRaw.FromRawUnchecked"/>
    public static CallEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CallEventPayload(string callID)
        : this()
    {
        this.CallID = callID;
    }
}

class CallEventPayloadFromRaw : IFromRawJson<CallEventPayload>
{
    /// <inheritdoc/>
    public CallEventPayload FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CallEventPayload.FromRawUnchecked(rawData);
}
