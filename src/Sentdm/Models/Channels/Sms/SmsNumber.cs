using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Sms;

/// <summary>
/// One number of an SMS market.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SmsNumber, SmsNumberFromRaw>))]
public sealed record class SmsNumber : JsonModel
{
    /// <summary>
    /// The number's area code, e.g. 212. While the number is still to be assigned,
    /// the area code it was asked for, or null when it was asked for in any area code.
    /// </summary>
    public string? AreaCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("area_code");
        }
        init { this._rawData.Set("area_code", value); }
    }

    /// <summary>
    /// The number, or null while it is still to be assigned.
    /// </summary>
    public string? SenderValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sender_value");
        }
        init { this._rawData.Set("sender_value", value); }
    }

    /// <summary>
    /// ACTIVE once the number can send; PROVISIONING while it is still to be assigned;
    /// INACTIVE once it could send and no longer can.
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AreaCode;
        _ = this.SenderValue;
        _ = this.Status;
    }

    public SmsNumber() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SmsNumber(SmsNumber smsNumber)
        : base(smsNumber) { }
#pragma warning restore CS8618

    public SmsNumber(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SmsNumber(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SmsNumberFromRaw.FromRawUnchecked"/>
    public static SmsNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SmsNumberFromRaw : IFromRawJson<SmsNumber>
{
    /// <inheritdoc/>
    public SmsNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SmsNumber.FromRawUnchecked(rawData);
}
