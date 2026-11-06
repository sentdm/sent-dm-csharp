using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Numbers;

[JsonConverter(typeof(JsonModelConverter<NumberLookupResult, NumberLookupResultFromRaw>))]
public sealed record class NumberLookupResult : JsonModel
{
    public string? CarrierName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("carrier_name");
        }
        init { this._rawData.Set("carrier_name", value); }
    }

    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_code");
        }
        init { this._rawData.Set("country_code", value); }
    }

    public bool? IsPorted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_ported");
        }
        init { this._rawData.Set("is_ported", value); }
    }

    public bool? IsValid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_valid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_valid", value);
        }
    }

    public bool? IsVoip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_voip");
        }
        init { this._rawData.Set("is_voip", value); }
    }

    public string? LineType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line_type");
        }
        init { this._rawData.Set("line_type", value); }
    }

    public string? MobileCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mobile_country_code");
        }
        init { this._rawData.Set("mobile_country_code", value); }
    }

    public string? MobileNetworkCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mobile_network_code");
        }
        init { this._rawData.Set("mobile_network_code", value); }
    }

    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CarrierName;
        _ = this.CountryCode;
        _ = this.IsPorted;
        _ = this.IsValid;
        _ = this.IsVoip;
        _ = this.LineType;
        _ = this.MobileCountryCode;
        _ = this.MobileNetworkCode;
        _ = this.PhoneNumber;
    }

    public NumberLookupResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberLookupResult(NumberLookupResult numberLookupResult)
        : base(numberLookupResult) { }
#pragma warning restore CS8618

    public NumberLookupResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberLookupResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NumberLookupResultFromRaw.FromRawUnchecked"/>
    public static NumberLookupResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NumberLookupResultFromRaw : IFromRawJson<NumberLookupResult>
{
    /// <inheritdoc/>
    public NumberLookupResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NumberLookupResult.FromRawUnchecked(rawData);
}
