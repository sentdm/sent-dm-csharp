using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.NumberLookup;

/// <summary>
/// Response containing phone number lookup data
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<NumberLookupRetrieveResponse, NumberLookupRetrieveResponseFromRaw>)
)]
public sealed record class NumberLookupRetrieveResponse : JsonModel
{
    /// <summary>
    /// The country calling code (e.g., 1 for US/Canada)
    /// </summary>
    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("countryCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("countryCode", value);
        }
    }

    /// <summary>
    /// The phone number formatted in E.164 standard (e.g., +1234567890)
    /// </summary>
    public string? FormatE164
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("formatE164");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("formatE164", value);
        }
    }

    /// <summary>
    /// The phone number formatted for international dialing (e.g., +1 234-567-890)
    /// </summary>
    public string? FormatInternational
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("formatInternational");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("formatInternational", value);
        }
    }

    /// <summary>
    /// The phone number formatted for national dialing (e.g., (234) 567-890)
    /// </summary>
    public string? FormatNational
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("formatNational");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("formatNational", value);
        }
    }

    /// <summary>
    /// The phone number formatted according to RFC 3966 (e.g., tel:+1-234-567-890)
    /// </summary>
    public string? FormatRfc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("formatRfc");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("formatRfc", value);
        }
    }

    /// <summary>
    /// The type of phone number (e.g., mobile, fixed_line, voip)
    /// </summary>
    public string? NumberType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("numberType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("numberType", value);
        }
    }

    /// <summary>
    /// The phone number in its original format
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phoneNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phoneNumber", value);
        }
    }

    /// <summary>
    /// The timezones associated with the phone number
    /// </summary>
    public string? PhoneTimezones
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phoneTimezones");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phoneTimezones", value);
        }
    }

    /// <summary>
    /// The ISO 3166-1 alpha-2 country code (e.g., US, CA, GB)
    /// </summary>
    public string? RegionCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("regionCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("regionCode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CountryCode;
        _ = this.FormatE164;
        _ = this.FormatInternational;
        _ = this.FormatNational;
        _ = this.FormatRfc;
        _ = this.NumberType;
        _ = this.PhoneNumber;
        _ = this.PhoneTimezones;
        _ = this.RegionCode;
    }

    public NumberLookupRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberLookupRetrieveResponse(NumberLookupRetrieveResponse numberLookupRetrieveResponse)
        : base(numberLookupRetrieveResponse) { }
#pragma warning restore CS8618

    public NumberLookupRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberLookupRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NumberLookupRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static NumberLookupRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NumberLookupRetrieveResponseFromRaw : IFromRawJson<NumberLookupRetrieveResponse>
{
    /// <inheritdoc/>
    public NumberLookupRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NumberLookupRetrieveResponse.FromRawUnchecked(rawData);
}
