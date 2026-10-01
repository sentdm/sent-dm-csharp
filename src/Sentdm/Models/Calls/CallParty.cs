using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Calls;

/// <summary>
/// One end of a call
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallParty, CallPartyFromRaw>))]
public sealed record class CallParty : JsonModel
{
    /// <summary>
    /// user for one of your app users, number for a phone number, conference for
    /// a room, anonymous for a caller who withheld their number
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
    /// The app user's identity, the phone number in E.164 format, or the room name.
    /// Null when the kind is anonymous
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
        _ = this.Kind;
        _ = this.Value;
    }

    public CallParty() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallParty(CallParty callParty)
        : base(callParty) { }
#pragma warning restore CS8618

    public CallParty(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallParty(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallPartyFromRaw.FromRawUnchecked"/>
    public static CallParty FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallPartyFromRaw : IFromRawJson<CallParty>
{
    /// <inheritdoc/>
    public CallParty FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CallParty.FromRawUnchecked(rawData);
}
