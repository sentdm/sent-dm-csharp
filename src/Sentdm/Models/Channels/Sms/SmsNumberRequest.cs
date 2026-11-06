using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Sms;

/// <summary>
/// One entry of numbers: how many numbers to assign in one area code, or in any
/// area code when AreaCode is omitted.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SmsNumberRequest, SmsNumberRequestFromRaw>))]
public sealed record class SmsNumberRequest : JsonModel
{
    /// <summary>
    /// The area code, e.g. 212, validated against the request's country. Omit it
    /// for numbers in any area code.
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
    /// How many numbers. At least 1; omitted means 1.
    /// </summary>
    public int? Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AreaCode;
        _ = this.Quantity;
    }

    public SmsNumberRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SmsNumberRequest(SmsNumberRequest smsNumberRequest)
        : base(smsNumberRequest) { }
#pragma warning restore CS8618

    public SmsNumberRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SmsNumberRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SmsNumberRequestFromRaw.FromRawUnchecked"/>
    public static SmsNumberRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SmsNumberRequestFromRaw : IFromRawJson<SmsNumberRequest>
{
    /// <inheritdoc/>
    public SmsNumberRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SmsNumberRequest.FromRawUnchecked(rawData);
}
