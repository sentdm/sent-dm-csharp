using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Calls.Participants;

/// <summary>
/// A participant to add to a call
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallParticipantTarget, CallParticipantTargetFromRaw>))]
public sealed record class CallParticipantTarget : JsonModel
{
    /// <summary>
    /// user for one of your app users, number for a phone number
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
    /// The app user's identity, or the phone number in E.164 format
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Kind;
        _ = this.Value;
    }

    public CallParticipantTarget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallParticipantTarget(CallParticipantTarget callParticipantTarget)
        : base(callParticipantTarget) { }
#pragma warning restore CS8618

    public CallParticipantTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallParticipantTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallParticipantTargetFromRaw.FromRawUnchecked"/>
    public static CallParticipantTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallParticipantTargetFromRaw : IFromRawJson<CallParticipantTarget>
{
    /// <inheritdoc/>
    public CallParticipantTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CallParticipantTarget.FromRawUnchecked(rawData);
}
