using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Calls;

/// <summary>
/// One leg of a call the price covers
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallLeg, CallLegFromRaw>))]
public sealed record class CallLeg : JsonModel
{
    /// <summary>
    /// The whole minutes the leg was billed for
    /// </summary>
    public int? BilledMinutes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("billed_minutes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billed_minutes", value);
        }
    }

    /// <summary>
    /// What the leg cost, in the same unit as the call's price
    /// </summary>
    public double? Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("cost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cost", value);
        }
    }

    /// <summary>
    /// The currency of the cost: USD
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// inbound for the caller's leg to your number, outbound for a leg placed on
    /// your behalf
    /// </summary>
    public string? Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("direction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("direction", value);
        }
    }

    /// <summary>
    /// The phone number the leg reached, in E.164 format: your number for the inbound
    /// leg, the number dialed for an outbound one. Null for a leg to one of your
    /// app users or a room
    /// </summary>
    public string? Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("number");
        }
        init { this._rawData.Set("number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BilledMinutes;
        _ = this.Cost;
        _ = this.Currency;
        _ = this.Direction;
        _ = this.Number;
    }

    public CallLeg() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallLeg(CallLeg callLeg)
        : base(callLeg) { }
#pragma warning restore CS8618

    public CallLeg(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallLeg(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallLegFromRaw.FromRawUnchecked"/>
    public static CallLeg FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallLegFromRaw : IFromRawJson<CallLeg>
{
    /// <inheritdoc/>
    public CallLeg FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CallLeg.FromRawUnchecked(rawData);
}
