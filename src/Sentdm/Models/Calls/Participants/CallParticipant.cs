using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Calls.Participants;

/// <summary>
/// A participant of a conference call
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallParticipant, CallParticipantFromRaw>))]
public sealed record class CallParticipant : JsonModel
{
    /// <summary>
    /// The participant's own call id: what the mute and remove endpoints take, and
    /// what GET /v3/calls/{id} accepts
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// How long the participant has been connected to the room, in seconds
    /// </summary>
    public int? DurationSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("duration_seconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("duration_seconds", value);
        }
    }

    /// <summary>
    /// user for one of your app users, number for a phone number, anonymous for
    /// a caller who withheld their number
    /// </summary>
    public string? Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("kind");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("kind", value);
        }
    }

    /// <summary>
    /// True while the room mutes this participant
    /// </summary>
    public bool? Muted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("muted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("muted", value);
        }
    }

    /// <summary>
    /// The app user's identity or the phone number in E.164 format. Null when the
    /// kind is anonymous
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.DurationSeconds;
        _ = this.Kind;
        _ = this.Muted;
        _ = this.Value;
    }

    public CallParticipant() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallParticipant(CallParticipant callParticipant)
        : base(callParticipant) { }
#pragma warning restore CS8618

    public CallParticipant(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallParticipant(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallParticipantFromRaw.FromRawUnchecked"/>
    public static CallParticipant FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallParticipantFromRaw : IFromRawJson<CallParticipant>
{
    /// <inheritdoc/>
    public CallParticipant FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CallParticipant.FromRawUnchecked(rawData);
}
